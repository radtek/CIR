using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Cir.Azure.Functions.Util;
using System.Net.Http;

namespace Cir.Azure.Functions.Function
{
    public static class UploadBladeTag
    {
        internal static IServiceProvider ServiceProvider;

        [FunctionName("UploadBladeTag")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/v1/UploadBladeTag")] HttpRequest req,
            ILogger log)
        {
            ServiceProvider = DISetup.ConfigureServices(log);

            var handler = ServiceProvider.GetService<UploadBladeTagHandler>();

            return await handler.HandleAsync(req, log);
        }
    }
}
