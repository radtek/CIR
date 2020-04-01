using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public abstract class AbstractAuthorizerAndErrorHttpHandler : IHttpHandler
    {
        private IHttpAuthorizer authorizer;

        public AbstractAuthorizerAndErrorHttpHandler(IHttpAuthorizer authorizer)
        {
            this.authorizer = authorizer;
        }

        public abstract Task<HttpResponseMessage> HandleAuthorisedAsync(HttpRequest req, ILogger log, string id = null);

        public async Task<HttpResponseMessage> HandleAsync(HttpRequest req, ILogger log, string id = null)
        {
            try
            {
                if (!await authorizer.IsAuthorizedAsync(req))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    response.Headers.Add("WWW-Authenticate", "vestas_consumer");
                    return response;
                }

                return await HandleAuthorisedAsync(req, log, id);
            }
            catch (BodyParameterException e)
            {
                log.LogError(e.Message, e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(e.Message)
                };
            }
            catch (PathParameterException e)
            {
                log.LogError(e.Message, e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(e.Message)
                };
            }
            catch (QueryParameterException e)
            {
                log.LogError(e.Message, e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(e.Message)
                };
            }
            catch (Exception e)
            {
                log.LogError(e.Message, e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                };
            }
        }
    }
}
