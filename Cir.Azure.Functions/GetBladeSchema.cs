using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Formatting;
using Microsoft.Azure.Documents.Client;

namespace Cir.Azure.Functions.Function
{
    public static class GetBladeSchema
    {
        [FunctionName("GetTemplate")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("GetTemplate Function called");
                // parse query parameter
                string templateName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "templateName", true) == 0).Value;
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                string brand = req.Query.FirstOrDefault(q => string.Compare(q.Key, "brand", true) == 0).Value;
                string version = req.Query.FirstOrDefault(q => string.Compare(q.Key, "version", true) == 0).Value;

                log.LogInformation("Template Name: " + templateName);
                log.LogInformation("Consumer Name: " + consumerName);

                if (!string.IsNullOrEmpty(brand))
                {
                    log.LogInformation("brand: " + brand);
                }
                    
                if (!string.IsNullOrEmpty(version))
                {
                    log.LogInformation("version: " + version);
                }

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

                IList<string> lstTemplateSchema = null;

                if (!string.IsNullOrEmpty(templateName))
                    lstTemplateSchema = GetTemplateSchema(log, templateName, brand, version);

                if (lstTemplateSchema == null || lstTemplateSchema.Count == 0)
                {
                    log.LogInformation("Data not found");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Data not found. Please pass valid templateName and brand/version(optional)")
                    };
                }
                else
                {
                    log.LogInformation("Data found");
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<IList<string>>(lstTemplateSchema, new JsonMediaTypeFormatter())
                    };
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public static List<string> GetTemplateSchema(ILogger log, string templateName, string brand = "", string version = "")
        {
            try
            {
                string DatabaseId = System.Environment.GetEnvironmentVariable("Database");
                string EndPointURI = System.Environment.GetEnvironmentVariable("EndPointUrl");
                string PrimaryKey = System.Environment.GetEnvironmentVariable("PrimaryKey");
                DocumentClient _documentClient = new DocumentClient(new Uri(EndPointURI), PrimaryKey);
                    

                StringBuilder stQry = new StringBuilder("SELECT * FROM CirTemplates c where LOWER(c.name) = '" + templateName.ToLower() + "'");
                if (!string.IsNullOrEmpty(brand))
                    stQry.Append(" and LOWER(c.cirBrand.name) = '" + brand.ToLower() + "'");
                else
                    stQry.Append(" and LOWER(c.cirBrand.name) = 'vestas'");

                if (!string.IsNullOrEmpty(version))
                    stQry.Append(" and c.versionNumber = " + version);

                List<CirTemplateDataModel> lstTemplates = _documentClient.CreateDocumentQuery<CirTemplateDataModel>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, "CirTemplates"),
                        stQry.ToString(), new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirTemplateDataModel>();
                List<string> lstTemplateString = new List<string>();
                lstTemplateString.Add(JsonConvert.SerializeObject(lstTemplates.OrderByDescending(i => i.VersionNumber).Take(1)));
                return lstTemplateString;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
