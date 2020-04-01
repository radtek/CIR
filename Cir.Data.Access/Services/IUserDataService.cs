using System.Collections.Generic;
using System.Threading.Tasks;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Services
{
    public interface IUserDataService
    {
        Task<IEnumerable<UserData>> GetData(UserInformation user);
        Task<IEnumerable<UserData>> GetMasterSyncData(UserInformation user);
    }
}
