using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    class AiDamagesPostHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly ICirRepository cirRepo;
        private readonly IQueryParameterGetter parameterGetter;
        private readonly IDefectDetectionItemRepository defectDetectionItemRepo;

        public AiDamagesPostHandler(ICirRepository cirRepo, IDefectDetectionItemRepository defectDetectionItemRepo, IHttpAuthorizer authorizer, IQueryParameterGetter parameterGetter) 
            : base(authorizer)            
        {
            this.cirRepo = cirRepo;
            this.defectDetectionItemRepo = defectDetectionItemRepo;
            this.parameterGetter = parameterGetter;
        }

        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null)
        {
            log.LogInformation("AiDamages POST Function called");

            var body = await req.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<AIDamages>(body);

            log.LogInformation("TurbineId: " + data.TurbineId);
            log.LogInformation("CirId: " + data.CirId);
            if(string.IsNullOrEmpty(data.TurbineId) || string.IsNullOrEmpty(data.CirId))
            {
                log.LogInformation("Could not read turbine-number or cirId");
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Data not found. Please pass valid turbineNumber and cirId")
                };
            }
            var storeResponse = await cirRepo.StoreFileByCirAsync(data.TurbineId, data.CirId, "AIDamages.json", JsonConvert.SerializeObject(data));

            if (!storeResponse)
            {
                log.LogError("File was stored unsucessfully");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            log.LogInformation("Stored sucessfully");
            await defectDetectionItemRepo.DeleteAsync(data.Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
