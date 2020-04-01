using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    interface IHttpHandler
    {
        Task<HttpResponseMessage> HandleAsync(HttpRequest req, ILogger log, string id = null);
    }
}
