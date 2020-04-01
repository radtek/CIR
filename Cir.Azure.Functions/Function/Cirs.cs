using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cir.Azure.Functions.Util;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http.Internal;
using System.Net;

namespace Cir.Azure.Functions.Function
{
    public static class Cirs
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("cirs")]
        public static async Task<HttpResponseMessage> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/cirs/{cirGuid?}")]HttpRequest req,
            string cirGuid,
            ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<CirsHandler>();
            return await handler.HandleAsync(req, log, cirGuid);
        }

        [FunctionName("cirsPOST")]
        public static async Task<HttpResponseMessage> RunAsync2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/cirs/{cirGuid?}")]HttpRequest req,
            string cirGuid,
            ILogger log)
        {
            if (!req.IsPostTunnelledThroughGet())
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "POST is unly supported as a way of tunnelling GET requests " +
                        "(mainly useful when the the query string gets so large that the url length limit is exceeded). " +
                        "To use this feature, set the 'X-HTTP-Method-Override' header to 'GET' and 'Content-Type' to 'application/x-www-form-urlencoded'")
                };
            }

            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<CirsHandler>();
            return await handler.HandleAsync(req, log, cirGuid);
        }
    }
}
