using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Cir.Azure.Functions.Util;

namespace Cir.Azure.Functions.Function
{
    public static class GetRepairDetails
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("GetRepairDetails")]
        public static async Task<HttpResponseMessage> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<GetRepairDetailsHandler>();

            return await handler.HandleAsync(req, log);
        }

    }
}
