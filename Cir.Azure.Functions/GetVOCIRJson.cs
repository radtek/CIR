using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
    public static class GetVOCIRJson
    {
        [FunctionName("GetVOCIRJson")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("GetVOCIRJson Function called");
                // Get request body
                dynamic body = await req.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TurbineNumberList>(body as string);

                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                

                log.LogInformation("Turbine Number: " + string.Join(",", data.lstTurbineNumber));
                log.LogInformation("Consumer Name: " + consumerName);

                string consumerKey = req.Headers.FirstOrDefault(x => x.Key == "ConsumerKey").Value;
                if (!string.IsNullOrEmpty(consumerKey))
                    log.LogInformation("Consumer Key: " + consumerKey);
                bool isAuthenticated = await Consumer.ValidateConsumer(consumerName, consumerKey);
                if (!isAuthenticated)
                {
                    log.LogInformation("Consumer Name and Consumer Key do not match or Consumer is not active");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Request not authenticated")
                    };
                }

                IList<CirBladeDataModel> lstBIRData = null;

                if (data.lstTurbineNumber.Count != 0)
                    lstBIRData = await GetJsonData(data.lstTurbineNumber);

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
                        Content = new ObjectContent<IList<CirBladeDataModel>>(lstBIRData, new JsonMediaTypeFormatter())
                    };
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static async Task<IList<CirBladeDataModel>> GetJsonData(IList<string> lstTurbineNumber)
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
                    string dataType = "CIR", blobType = "RevisionHistory";
                    IList<CirBladeDataModel> lstCIRData = new List<CirBladeDataModel>();
                    BlobContinuationToken blobContinuationToken = null;
                    foreach (var turbineNumber in lstTurbineNumber)
                    {
                        do
                        {
                            var cirList = await container.ListBlobsSegmentedAsync($"{turbineNumber}/{dataType}/", blobContinuationToken);
                            foreach (var cir in cirList.Results)
                            {
                                var results = await container.ListBlobsSegmentedAsync(cir.Uri.Segments[2].ToString() + cir.Uri.Segments[3].ToString() + cir.Uri.Segments[4].ToString() + blobType + "/", null);
                                var listCirRevisions = results.Results.OfType<CloudBlob>();
                                var newestModifiedOn = DateTime.MinValue;
                                CirBladeDataModel newestRevHist = null;
                                foreach (CloudBlob item in listCirRevisions)
                                {
                                    CloudBlockBlob blob = (CloudBlockBlob)item;
                                    var sasBlobUri = GetBlobSasUri.GetByBlobName(blob.Name, container);
                                    blob = new CloudBlockBlob(sasBlobUri);
                                    var blobData = await blob.DownloadTextAsync();
                                    CirBladeDataModel revHist = JsonConvert.DeserializeObject<CirBladeDataModel>(blobData);
                                    if (revHist.CirSubmissionData.CirTemplateName.ToLower() == "bladeinspection")
                                    {
                                        var modifiedOnString = revHist?.CirSubmissionData?.ModifiedOn;
                                        if (modifiedOnString != null &&
                                            DateTime.TryParse(modifiedOnString, out var modifiedOn) &&
                                            modifiedOn > newestModifiedOn)
                                        {
                                            newestModifiedOn = modifiedOn;
                                            newestRevHist = revHist;
                                        }
                                    }
                                }
                                if (newestRevHist != null)
                                {
                                    lstCIRData.Add(newestRevHist);
                                }
                            }
                            blobContinuationToken = cirList.ContinuationToken;
                        } while (blobContinuationToken != null);
                    }
                    return lstCIRData;
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
