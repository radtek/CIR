using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    class DefectDetectionHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private const string CornisUrl = "https://vestas.cornis.fr/alpha-v0/detection";
        private readonly IDefectDetectionRequestConverter requestConverter;
        private readonly HttpClient httpClient;
        private readonly IDefectDetectionItemRepository repo;
        private readonly IDefectDetectionItemConverter itemConverter;

        public DefectDetectionHandler(
            IHttpAuthorizer authorizer,
            HttpClient httpClient,
            IDefectDetectionRequestConverter requestConverter,
            IDefectDetectionItemConverter itemConverter,
            IDefectDetectionItemRepository repo) : base(authorizer)
        {
            this.httpClient = httpClient;
            this.requestConverter = requestConverter;
            this.itemConverter = itemConverter;
            this.repo = repo;
        }

        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null)
        {
            var body = await req.ReadAsStringAsync();

            var dto = ParseBody(body);

            var cornisRequestDto = requestConverter.Convert(dto);

            var defaultHeaders = httpClient.DefaultRequestHeaders;
            defaultHeaders.Clear();
            defaultHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("CornisApiKey"));

            var content = new StringContent(JsonConvert.SerializeObject(cornisRequestDto), Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(CornisUrl, content);
            if (response.IsSuccessStatusCode)
            {
                var cornisResponseDto = await response.Content.ReadAsAsync<CornisDefectDetectionResponse>();
                var item = itemConverter.Convert(cornisRequestDto, cornisResponseDto);

                await repo.SetAsync(item);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private DefectDetectionRequest ParseBody(string body)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<DefectDetectionRequest>(body);
                if (result == null)
                {
                    throw new Exception("Request body was parsed to 'null'. Did you send an empty request body?");
                }
                return result;
            }
            catch (Exception e)
            {
                throw new BodyParameterException("Unable to parse http request body", body, e);
            }
        }
    }
}
