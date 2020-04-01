using System.Collections.Generic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface IUserDataService
    {
        IEnumerable<UserData> GetData(string userId);
    }
}
