using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public interface IHttpAuthorizer
    {
        Task<bool> IsAuthorizedAsync(HttpRequest req);
    }
}
