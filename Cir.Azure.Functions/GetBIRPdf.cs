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
    public static class GetBIRPdf
    {
        [FunctionName("GetBIRPdf")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("GetBIRPdf Function called");
                // parse query parameter
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                string turbineNumber = req.Query.FirstOrDefault(q => string.Compare(q.Key, "turbineNumber", true) == 0).Value;
                string birGuid = req.Query.FirstOrDefault(q => string.Compare(q.Key, "birGuid", true) == 0).Value;

                log.LogInformation("Turbine Number: " + turbineNumber);
                log.LogInformation("Consumer Name: " + consumerName);
                log.LogInformation("BIR Guid: " + birGuid);

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

                BirFileModel birData = null;
                if (!(string.IsNullOrEmpty(turbineNumber) || string.IsNullOrEmpty(birGuid)))
                {
                    birData = await GetBirData(turbineNumber, birGuid);
                }

                if (birData == null)
                {
                    log.LogInformation("Data not found for the requested Turbine Number and BIR Guid");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Data not found. Please pass valid turbineNumber/birGuid")
                    };
                }
                else
                {
                    log.LogInformation("Data found");
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<BirFileModel>(birData, new JsonMediaTypeFormatter())
                    };

                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static async Task<BirFileModel> GetBirData(string turbineNumber, string birGuid)
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
                    string birDirectoryName = $"{turbineNumber}/{dataType}/{contentType}/{birGuid}";
                    var sasBlobUri = GetBlobSasUri.GetByBlobName(birDirectoryName, container);
                    CloudBlockBlob blob = new CloudBlockBlob(sasBlobUri);
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
                    return birFileData;
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
