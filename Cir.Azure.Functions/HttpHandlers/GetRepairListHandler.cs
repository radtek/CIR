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

[assembly: InternalsVisibleTo("Cir.Azure.Functions.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Cir.Azure.Functions
{
    class GetRepairListHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly ICirRepository repo;
        private readonly IRepairListConverter converter;
        private readonly IQueryParameterGetter parameterGetter;

        public GetRepairListHandler(
            ICirRepository repo,
            IRepairListConverter converter,
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
            var ids = await parameterGetter.GetCollectionAsync("id", req);
            var repairs = await repo.GetAllAsync(ids, new RepairSpecification());
            var repairDto = converter.Convert(repairs);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<RepairListDto>(repairDto, new JsonMediaTypeFormatter())
            };
        }

    }
}
