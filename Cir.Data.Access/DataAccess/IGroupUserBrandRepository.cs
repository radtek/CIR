using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    interface IGroupUserBrandRepository
    {
        Task<List<string>> GetAssignedBrandsIdsByUserEmailOrGroupName(UserInformation user);
        Task<List<string>> GetAssignedBrandsIdsByUserEmail(string userId);
        Task<List<string>> GetAssignedBrandsIdsByGroupName(string groupName);
        void Add(GroupUserBrand groupUserData);
        GroupUserBrand GetUserGroupByEmailOrGroupName(string userEmailOrGroupName);
        GroupUserBrand GetGroupByGroupName(string groupName);
        void Update(GroupUserBrand groupUserBrand);
    }
}
