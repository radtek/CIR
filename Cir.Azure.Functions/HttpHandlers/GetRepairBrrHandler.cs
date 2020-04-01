using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: InternalsVisibleTo("Cir.Azure.Functions.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Cir.Azure.Functions
{
    class GetRepairBrrHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly IBrrRepository repo;
        private readonly IBrrConverter converter;
        private readonly IQueryParameterGetter parameterGetter;

        public GetRepairBrrHandler(
            IBrrRepository repo,
            IBrrConverter converter,
            IHttpAuthorizer authorizer,
            IQueryParameterGetter parameterGetter)
            : base(authorizer)
        {
            this.repo = repo;
            this.converter = converter;
            this.parameterGetter = parameterGetter;
        }
        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null)
        {
            var turbineIds = await parameterGetter.GetCollectionAsync("turbineId", req);
            var repairIds = await parameterGetter.GetCollectionAsync("repairId", req);

            var repairs = await repo.GetAllAsync(turbineIds, repairIds);
            var repairBrrDto = converter.Convert(repairs);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<RepairBrrDto>(repairBrrDto, new JsonMediaTypeFormatter())
            };
        }

    }
}
