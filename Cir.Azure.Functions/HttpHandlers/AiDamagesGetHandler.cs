using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    public class AiDamagesGetHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private IQueryParameterGetter queryParameterGetter;
        private ICirRepository repo;
        private IAIDamagesForCirConverter converter;

        public AiDamagesGetHandler(IHttpAuthorizer authorizer, IQueryParameterGetter queryParameterGetter,
            ICirRepository repo, IAIDamagesForCirConverter converter) : base(authorizer)
        {
            this.queryParameterGetter = queryParameterGetter;
            this.repo = repo;
            this.converter = converter;
        }

        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null)
        {
            var cirId = await queryParameterGetter.GetStringAsync("cirId", req);
            var turbineID = await queryParameterGetter.GetStringAsync("turbineId", req);

            var content = await repo.GetFileByCirAsync(turbineID, cirId, "AIDamages.json");

            if(content == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var data = JsonConvert.DeserializeObject<AIDamages>(content);

            var damages = converter.Convert(data);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<AIDamagesForCir>(damages, new JsonMediaTypeFormatter())
            };
        }
    }
}