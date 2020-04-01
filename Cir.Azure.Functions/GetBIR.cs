using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Formatting;

namespace Cir.Azure.Functions.Function
{
    public static class GetBIR
    {
        [FunctionName("GetBIR")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("GetBir Function called");
                // Get request body
                dynamic body = await req.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TurbineNumberList>(body as string);

                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;

                log.LogInformation("Turbine Number: " + string.Join(",", data.lstTurbineNumber));
                log.LogInformation("Consumer Name: " + consumerName);

                string consumerKey = req.Headers.FirstOrDefault(x => x.Key == "ConsumerKey").Value;
                if (!string.IsNullOrEmpty(consumerKey))
                {
                    log.LogInformation("Consumer Key: " + consumerKey);
                }
                bool isAuthenticated = await Consumer.ValidateConsumer(consumerName, consumerKey);
                if (!isAuthenticated)
                {
                    log.LogInformation("Consumer Name and Consumer Key do not match or Consumer is not active");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Request not authenticated")
                    };
                }

                IList<BirFileModel> lstBIRData = null;
                if (data.lstTurbineNumber.Count != 0)
                    lstBIRData = await GetBirData(data.lstTurbineNumber);

                if (lstBIRData == null || lstBIRData.Count == 0)
                {
                    log.LogInformation("Data not found for the requested Turbine Numbers");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Data not found. Please pass valid turbineNumber")
                    };
                }
                else
                {
                    log.LogInformation("Data found");
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<IList<BirFileModel>>(lstBIRData, new JsonMediaTypeFormatter())
                    };
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static async Task<IList<BirFileModel>> GetBirData(IList<string> lstTurbineNumber)
        {
            try
            {
                CloudBlobClient blobClient;
                CloudBlobContainer container;
                var storageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("AzureStorageConnectionString"));
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(System.Environment.GetEnvironmentVariable("AzureStorageContainerName"));
                if (container.ExistsAsync().Result)
                {
                    string dataType = "BIR", contentType = "PDF";
                    List<BirFileModel> lstBIRData = new List<BirFileModel>();
                    BlobContinuationToken blobContinuationToken = null;
                    do
                    {
                        foreach (var turbineNumber in lstTurbineNumber)
                        {
                            var birList = await container.ListBlobsSegmentedAsync($"{turbineNumber}/{dataType}/{contentType}/", true, BlobListingDetails.Metadata, null, null, null, null);
                            var latestBir = birList.Results.OfType<CloudBlob>().Where(b => (b.Metadata.ContainsKey("isAnnual") && b.Metadata["isAnnual"] == "true")).OrderByDescending(b => b.Properties.LastModified).Take(1);

                            blobContinuationToken = birList.ContinuationToken;
                            foreach (CloudBlob item in latestBir)
                            {
                                CloudBlockBlob blob = (CloudBlockBlob)item;
                                var sasBlobUri = GetBlobSasUri.GetByBlobName(blob.Name, container);
                                blob = new CloudBlockBlob(sasBlobUri);
                                await blob.FetchAttributesAsync();

                                long pdfByteLength = blob.Properties.Length;
                                Byte[] pdfByteArray = new Byte[pdfByteLength];
                                await blob.DownloadToByteArrayAsync(pdfByteArray, 0);
                                String pdfDataString = Convert.ToBase64String(pdfByteArray);

                                BirFileModel birFileData = new BirFileModel
                                {
                                    BirDataString = pdfDataString,
                                    FileName = blob.Metadata.ContainsKey("fileName") ? blob.Metadata["fileName"] : null
                                };
                                lstBIRData.Add(birFileData);
                            }
                        }
                    } while (blobContinuationToken != null);
                    return lstBIRData;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
