using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class BirsHandler: AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly IBirRepository repo;
        private readonly IBirConverter converter;
        private readonly IQueryParameterGetter parameterGetter;

        public BirsHandler(
            IBirRepository repo,
            IBirConverter converter,
            IHttpAuthorizer authorizer,
            IQueryParameterGetter parameterGetter)
            : base(authorizer)
        {
            this.repo = repo;
            this.converter = converter;
            this.parameterGetter = parameterGetter;
        }
        

        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string birGuid = null)
        {
            var turbineIds = await parameterGetter.GetCollectionAsync("turbineId", req);
            var isAnnual = await parameterGetter.GetValueAsync<bool?>("isAnnual", req, false);
            var modifiedYears = await parameterGetter.GetCollectionAsync<int>("modifiedYears", req);
            var format = await parameterGetter.GetEnumAsync("format", new[] { "metadata", "full" }, req, false);

            bool metadataOnly = false;
            if (format == "metadata")
            {
                metadataOnly = true;
            }
            var birs = await repo.GetAsync(turbineIds, isAnnual, modifiedYears, birGuid, metadataOnly);

            JObject dto;
            if (birGuid != null)
            {
                var bir = birs.FirstOrDefault();
                if (bir == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                dto = converter.Convert(bir);
            }
            else
            {
                dto = converter.Convert(birs);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(dto.ToString(), Encoding.UTF8, "application/json")
            };
        }
        
    }
}
