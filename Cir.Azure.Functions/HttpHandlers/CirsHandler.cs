using System;
using System.Collections;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cir.Azure.Functions
{
    class CirsHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly ICirRepository repo;
        private readonly IBirRepository birRepo;
        private readonly IQueryParameterGetter parameterGetter;
        private readonly IList<IConverter> converters;
        private readonly ISpecificationBuilderFactory specBuilderFactory;

        public CirsHandler(
            ICirRepository repo,
            IBirRepository birRepo,
            IEnumerable<IConverter> converters,
            IHttpAuthorizer authorizer,
            IQueryParameterGetter parameterGetter,
            ISpecificationBuilderFactory specBuilderFactory)
            : base(authorizer)
        {
            this.repo = repo;
            this.birRepo = birRepo;
            this.converters = converters.ToList();
            this.parameterGetter = parameterGetter;
            this.specBuilderFactory = specBuilderFactory;
        }


        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string cirGuid = null)
        {
            var turbineIds = await parameterGetter.GetCollectionAsync("turbineId", req);
            var format = await parameterGetter.GetEnumAsync("format", converters.Select(c => c.Format).ToList(), req);
            var hasDamages = await parameterGetter.GetValueAsync<bool?>("hasDamages", req, false);

            var birs = birRepo.GetAsync(turbineIds, null, new List<int>(), null, true);
            var validCirIds = birs.Result.SelectMany(b => b.RelatedCirs).ToList();

            var spec = specBuilderFactory
                .Create()
                .BladeInspection()
                .CirIds(validCirIds)
                .CirGuid(cirGuid)
                .Damages(hasDamages)
                .Build();

            var cirs = await repo.GetAllAsync(turbineIds, spec);

            var converter = converters.First(c => c.Format == format);
            
            JObject dto;
            if (cirGuid != null)
            {
                var cir = cirs.FirstOrDefault();
                if (cir == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                dto = converter.Convert(cir);
                if (dto == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            else
            {
                dto = converter.Convert(cirs);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(dto.ToString(), Encoding.UTF8, "application/json")
            };
        }
    }
}
