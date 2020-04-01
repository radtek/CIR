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
    public static class GetRepairList
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("GetRepairList")]
        public static async Task<HttpResponseMessage> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);
            var handler = ServiceProvider.GetService<GetRepairListHandler>();

            return await handler.HandleAsync(req, log);
        }
            
    }
}
