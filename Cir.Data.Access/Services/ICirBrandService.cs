using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    public interface ICirBrandService
    {
        BrandDataModel Get(string id);
        IEnumerable<BrandDataModel> GetAll();
        Task<IEnumerable<BrandDataModel>> GetAllByUserId(string userId);
        Task<IEnumerable<BrandDataModel>> GetAllByGroupName(string groupName);
        GroupUserBrand AssignBrandToUserGroup(string id, string brandId);
        GroupUserBrand AssignBrandToGroup(string id, string brandId);
        GroupUserBrand UnassignBrandFromUserGroup(string id, string brandId);
    }
}
