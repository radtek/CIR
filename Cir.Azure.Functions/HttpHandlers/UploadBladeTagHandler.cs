using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cir.Azure.Functions.DTO;
using Cir.BlobStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cir.Azure.Functions
{
    public class UploadBladeTagHandler : AbstractAuthorizerAndErrorHttpHandler
    {
        private readonly IFileFactory fileFactory;
        private readonly IQueryParameterGetter parameterGetter;
        private readonly HttpClient httpClient;

        public UploadBladeTagHandler(
            IHttpAuthorizer authorizer,
            IFileFactory fileFactory,
            IQueryParameterGetter parameterGetter,
            HttpClient httpClient) 
            : base(authorizer)
        {
            this.fileFactory = fileFactory;
            this.parameterGetter = parameterGetter;
            this.httpClient = httpClient;
        }

        public override async Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null)
        {
            var turbineId = await parameterGetter.GetStringAsync("turbineId", req, true);
            var cirId = await parameterGetter.GetStringAsync("cirId", req, true);

            var tagId = Guid.NewGuid().ToString();

            var file = fileFactory.CreateFile($"{turbineId}/CIR/{cirId}/bladetag/{tagId}.jpg");
            try
            {
                if (req.Body.Length == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Missing image data")
                    };
                }
                await file.WriteStreamAsync(req.Body);

                var cornisOCRRequest = new CornisOCRRequest
                {
                    CirId = cirId,
                    TurbineId = turbineId,
                    Images = new List<PathObject>
                {
                    new PathObject
                    {
                        Path = file.Uri
                    }
                }
                };

                var defaultHeaders = httpClient.DefaultRequestHeaders;
                defaultHeaders.Clear();
                defaultHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("CornisApiKey"));

                var content = new StringContent(JsonConvert.SerializeObject(cornisOCRRequest), Encoding.UTF8, "text/plain");

                var response = await httpClient.PostAsync("https://vestas.cornis.fr/alpha-v0/ocr", content);

                if (!response.IsSuccessStatusCode)
                {
                    log.LogError($"Error response from Cornis OCR: {response.StatusCode} {response.ReasonPhrase}");
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

                var responseString = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<CornisOCRResponse>(responseString);

                if (responseObject == null || responseObject.Images.Count == 0)
                {
                    log.LogError($"Invalid response from Cornis OCR: {response.StatusCode} {response.ReasonPhrase} - Missing images");
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

                var firstImage = responseObject.Images.First();

                var ocrResponse = new OCRResponse
                {
                    BladeColor = firstImage.OCR.SingleOrDefault(x => x.FieldName == "blade_color")?.DetectedText,
                    BladeId = firstImage.OCR.SingleOrDefault(x => x.FieldName == "blade_id")?.DetectedText,
                    BladeSerialNumber = firstImage.OCR.SingleOrDefault(x => x.FieldName == "blade_serial_number")?.DetectedText,
                };

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ocrResponse), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                log.LogError("Error while processing request", e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            finally
            {
                await file.DeleteFile();
            }
        }
    }
}
