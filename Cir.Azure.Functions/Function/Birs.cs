using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Cir.Azure.Functions.Util;

namespace Cir.Azure.Functions.Function
{
    public static class Birs
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("birs")]
        public static async Task<HttpResponseMessage> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/birs/{birGuid?}")]HttpRequest req,
            string birGuid, 
            ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<BirsHandler>();

            return await handler.HandleAsync(req, log, birGuid);
        }
    }
}
