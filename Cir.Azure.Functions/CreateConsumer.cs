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
    public static class CreateConsumer
    {
        [FunctionName("CreateConsumer")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("CreateConsumer Function called");
                // Get request body
                string consumerName = req.Query.FirstOrDefault(q => string.Compare(q.Key, "consumerName", true) == 0).Value;
                log.LogInformation("Consumer Name: " + consumerName);

                string adminKey = req.Headers.SingleOrDefault(x => x.Key == "adminKey").Value;
                if (!string.IsNullOrEmpty(adminKey))
                    log.LogInformation("Admin Key: " + adminKey);

                bool hasConsumerCreated = await Consumer.CreateConsumer(consumerName, adminKey);

                if (hasConsumerCreated)
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
                throw ;
            }
        }
    }
}
