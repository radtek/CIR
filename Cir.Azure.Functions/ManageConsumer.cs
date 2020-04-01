using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Cir.Azure.Functions.Function
{
    public static class ManageConsumer
    {
        [FunctionName("ManageConsumer")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("ManageConsumer Function called");
                // Get request body
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                log.LogInformation("Consumer Name: " + consumerName);

                string isActive = req.Query.FirstOrDefault(q => string.Compare(q.Key, "isActive", true) == 0).Value;
                log.LogInformation("Activate User: " + isActive);

                string consumerKey = req.Headers.FirstOrDefault(x => x.Key == "ConsumerKey").Value;
                if (!string.IsNullOrEmpty(consumerKey))
                    log.LogInformation("Consumer Key: " + consumerKey);

                string adminKey = req.Headers.FirstOrDefault(x => x.Key == "AdminKey").Value;
                if (!string.IsNullOrEmpty(adminKey))
                    log.LogInformation("Admin Key: " + adminKey);

                bool hasConsumerUpdated = await Consumer.ManageConsumer(consumerName, consumerKey, adminKey, isActive);

                if (hasConsumerUpdated)
                {
                    log.LogInformation("Consumer created successfully");
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("Consumer created successfully")
                    };
                }
                else
                {
                    log.LogInformation("Some error occurred while creating Consumer");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Some error occurred while creating Consumer")
                    };
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
