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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http.Formatting;

namespace Cir.Azure.Functions.Function
{
    public static class GetBIRDetails
    {
        [FunctionName("GetBIRDetails")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("GetBIRDetails Function called");
                // parse query parameter
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                string turbineNumber = req.Query.FirstOrDefault(q => string.Compare(q.Key, "turbineNumber", true) == 0).Value;
                string isAnnual = req.Query.FirstOrDefault(q => string.Compare(q.Key, "isAnnual", true) == 0).Value;
                string modifiedYear = req.Query.FirstOrDefault(q => string.Compare(q.Key, "modifiedYear", true) == 0).Value;

                log.LogInformation("Turbine Number: " + turbineNumber);
                log.LogInformation("Consumer Name: " + consumerName);
                log.LogInformation("Is Annual: " + isAnnual);
                log.LogInformation("Modified Year: " + modifiedYear);

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

                IList<BIRDetailModel> lstBIRData = null;
                if (!(string.IsNullOrEmpty(turbineNumber) || string.IsNullOrEmpty(isAnnual) || string.IsNullOrEmpty(modifiedYear)))
                    lstBIRData = await GetBirList(turbineNumber, isAnnual, modifiedYear);

                if (lstBIRData == null || lstBIRData.Count == 0)
                {
                    log.LogInformation("Data not found for the corresponding request");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Data not found. Please pass valid turbineNumber/isAnnual/modifiedYear")
                    };
                }
                else
                {
                    log.LogInformation("Data found");
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<IList<BIRDetailModel>>(lstBIRData, new JsonMediaTypeFormatter())
                    };
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static async Task<IList<BIRDetailModel>> GetBirList(string turbineNumber, string isAnnual, string modifiedYear)
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
                    List<BIRDetailModel> lstBIRDatail = new List<BIRDetailModel>();
                    var birList = await container.ListBlobsSegmentedAsync($"{turbineNumber}/{dataType}/{contentType}/", true, BlobListingDetails.Metadata, null, null, null, null);
                    var filteredBIRs = birList.Results.OfType<CloudBlob>().Where(b => (b.Metadata.ContainsKey("isAnnual") && b.Metadata["isAnnual"] == isAnnual && b.Metadata.ContainsKey("modified") && Convert.ToDateTime(b.Metadata["modified"]).Year.ToString() == modifiedYear));
                    foreach (CloudBlob BIR in filteredBIRs)
                    {
                        BIRDetailModel birFileData = new BIRDetailModel
                        {
                            BirGuid = BIR.Name.ToString().Split('/').Last(),
                            FileName = BIR.Metadata.ContainsKey("fileName") ? BIR.Metadata["fileName"] : null,
                            IsAnnual = BIR.Metadata.ContainsKey("isAnnual") ? BIR.Metadata["isAnnual"] : null,
                            RelatedCIRs = BIR.Metadata.ContainsKey("relatedCirs") ? BIR.Metadata["relatedCirs"] : null,
                            ModifiedDate = Convert.ToDateTime(BIR.Metadata["modified"])
                        };
                        lstBIRDatail.Add(birFileData);
                    }
                    return lstBIRDatail;
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
