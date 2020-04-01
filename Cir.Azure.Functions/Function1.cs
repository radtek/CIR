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
using System.Dynamic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Formatting;

namespace Cir.Azure.Functions.Function
{
    public static class Function1
    {

        [FunctionName("GetCIRFullJsonV2")]
        public static async Task<HttpResponseMessage> RunV2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            return await Run(req, log, 2);
        }
        [FunctionName("GetCIRFullJson")]
        public static async Task<HttpResponseMessage> RunV1([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            return await Run(req, log, 1);
        }


        private static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log, int version)
        {
            try
            {
                log.LogInformation("GetCIRFullJson Function called");
                // parse query parameter
                string turbineNumber = req.Query.FirstOrDefault(q => string.Compare(q.Key, "turbineNumber", true) == 0).Value;
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                string cirType = req.Query.FirstOrDefault(q => string.Compare(q.Key, "cirType", true) == 0).Value;
                log.LogInformation("Turbine Number: " + turbineNumber);
                log.LogInformation("Consumer Name: " + consumerName);
                log.LogInformation("CIR Type: " + cirType);

                string consumerKey = req.Headers.FirstOrDefault(x=> x.Key == "ConsumerKey").Value;
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

                IList<string> lstRevisionHistory = null;

                if (!(string.IsNullOrEmpty(turbineNumber) || string.IsNullOrEmpty(cirType)))
                {
                    lstRevisionHistory = await GetAllCirsRevisionHistory(turbineNumber, cirType);
                }

                if (lstRevisionHistory == null || lstRevisionHistory.Count == 0)
                {
                    log.LogInformation("Data not found for the requested Turbine Number and CIR Type");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Data not found. Please pass valid turbineNumber and cirType")
                    };
                }
                else
                {
                    log.LogInformation("Data found");
                    if (version == 1)
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ObjectContent<IList<string>>(lstRevisionHistory, new JsonMediaTypeFormatter())
                        };
                    }
                    else
                    {
                        var result = new List<dynamic>();
                        foreach (var rev in lstRevisionHistory)
                        {
                            dynamic cir = JsonConvert.DeserializeObject<ExpandoObject>(rev);


                            if (((IDictionary<String, Object>)cir).ContainsKey("cirSubmissionData"))
                            { 
                                ((IDictionary<String, Object>)cir.cirSubmissionData).Remove("schema");
                            }
                            result.Add(cir);
                        }
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ObjectContent<IList<dynamic>>(result, new JsonMediaTypeFormatter())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static async Task<IList<string>> GetAllCirsRevisionHistory(string turbineNumber, string cirType)
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
                    List<string> lstCirRevision = new List<string>();
                    BlobContinuationToken blobContinuationToken = null;
                    do
                    {
                        var cirList = await container.ListBlobsSegmentedAsync($"{turbineNumber}/{dataType}/", blobContinuationToken);
                        foreach (var cir in cirList.Results)
                        {
                            var results = await container.ListBlobsSegmentedAsync(cir.Uri.Segments[2].ToString() + cir.Uri.Segments[3].ToString() + cir.Uri.Segments[4].ToString() + blobType + "/", null);
                            var listCirRevisions = results.Results.OfType<CloudBlob>();
                            var newestModifiedOn = DateTime.MinValue;
                            string newestBlobData = null;
                            foreach (CloudBlob item in listCirRevisions)
                            {
                                CloudBlockBlob blob = (CloudBlockBlob)item;
                                var sasBlobUri = GetBlobSasUri.GetByBlobName(blob.Name, container);
                                blob = new CloudBlockBlob(sasBlobUri);
                                var blobData = await blob.DownloadTextAsync();
                                CirBladeDataModel revHist = JsonConvert.DeserializeObject<CirBladeDataModel>(blobData);
                                if (revHist.CirSubmissionData.CirTemplateName.ToLower() == cirType.ToLower())
                                {
                                    var modifiedOnString = revHist?.CirSubmissionData?.ModifiedOn;
                                    if (modifiedOnString != null &&
                                        DateTime.TryParse(modifiedOnString, out var modifiedOn) &&
                                        modifiedOn > newestModifiedOn)
                                    {
                                        newestModifiedOn = modifiedOn;
                                        newestBlobData = blobData;
                                    }
                                }
                            }
                            if (newestBlobData != null)
                            {
                                lstCirRevision.Add(newestBlobData);
                            }
                        }
                        blobContinuationToken = cirList.ContinuationToken;
                    } while (blobContinuationToken != null);
                    return lstCirRevision;
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
