using System.Threading.Tasks;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Api.Authorization
{
    public interface IGraphApiService
    {
        Task<UserInformation> GetUserAsync(string userId);
    }
}
