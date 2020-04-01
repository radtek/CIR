using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Cir.Azure.Functions
{
    class GetRepairDetailsHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly ICirRepository repo;
        private readonly IRepairDetailsConverter converter;
        private readonly IQueryParameterGetter parameterGetter;

        public GetRepairDetailsHandler(
            ICirRepository repo,
            IRepairDetailsConverter converter,
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
            var turbineId = await parameterGetter.GetStringAsync("turbineId", req);
            var repairId = await parameterGetter.GetStringAsync("repairId", req);


            var spec = new AndSpecification(
                new RepairSpecification(),
                new CirGuidSpecification(repairId));
            var repair = await repo.GetExactlyOneAsync(turbineId, spec);

            if (repair == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            RepairDetailsDto dto = converter.Convert(repair);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<RepairDetailsDto>(dto, new JsonMediaTypeFormatter())
            };
        }
    }
}
