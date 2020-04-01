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
    public static class DefectDetection
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("DefectDetection")]
        public static async Task<HttpResponseMessage> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/DefectDetection")]HttpRequest req,
            ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<DefectDetectionHandler>();

            return await handler.HandleAsync(req, log, null);
        }
    }
}
