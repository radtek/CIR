using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cir.Azure.Functions.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Cir.Azure.Functions
{
    public static class AiDamages
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("AiDamagesPost")]
        public static async Task<HttpResponseMessage> RunAsyncPost([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "api/AiDamages")]HttpRequest req, ILogger log) // TODO: change route to v1/
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<AiDamagesPostHandler>();
            
            return await handler.HandleAsync(req, log);
        }

        [FunctionName("AiDamagesGet")]
        public static async Task<HttpResponseMessage> RunAsyncGet([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/AiDamages")]HttpRequest req, ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<AiDamagesGetHandler>();

            return await handler.HandleAsync(req, log);
        }
    }
}
