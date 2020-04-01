using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cir.Azure.Functions.Util;
using System;

namespace Cir.Azure.Functions.Function
{
    public static class GetRepairBrr
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("GetRepairBRRs")]
        public static async Task<HttpResponseMessage> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<GetRepairBrrHandler>();

            return await handler.HandleAsync(req, log);
        }

    }
}
