using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    internal class CirBrandService : ICirBrandService
    {
        IGroupUserBrandRepository _groupUserBrandRepository;
        IBrandDataRepository _brandDataRepository;

        public CirBrandService(IGroupUserBrandRepository groupUserBrandRepository, IBrandDataRepository brandDataRepository)
        {
            _groupUserBrandRepository = groupUserBrandRepository;
            _brandDataRepository = brandDataRepository;
        }

        public BrandDataModel Get(string id)
        {
            return _brandDataRepository.Get(id);
        }

        public IEnumerable<BrandDataModel> GetAll()
        {
            return _brandDataRepository.GetAll();
        }

        public async Task<IEnumerable<BrandDataModel>> GetAllByUserId(string userId)
        {
            var brandIds = await _groupUserBrandRepository.GetAssignedBrandsIdsByUserEmail(userId);

            if (!brandIds.Any()) return new List<BrandDataModel>();

            return _brandDataRepository.GetByIds(brandIds);
        }

        public async Task<IEnumerable<BrandDataModel>> GetAllByGroupName(string groupName)
        {
            var brandIds = await _groupUserBrandRepository.GetAssignedBrandsIdsByGroupName(groupName);

            if (!brandIds.Any()) return new List<BrandDataModel>();

            return _brandDataRepository.GetByIds(brandIds);
        }

        public GroupUserBrand AssignBrandToUserGroup(string id, string brandId)
        {
            var userGroup = _groupUserBrandRepository.GetUserGroupByEmailOrGroupName(id);

            if (userGroup == null)
            {
                userGroup = new GroupUserBrand();
                userGroup.Email = id;
                userGroup.Brands = new HashSet<string>() { brandId }.ToList();
                _groupUserBrandRepository.Add(userGroup);
            }
            else
            {
                userGroup.Brands = new HashSet<string>(userGroup.Brands) { brandId }.ToList();
                _groupUserBrandRepository.Update(userGroup);
            }

            return userGroup;
        }

        public GroupUserBrand AssignBrandToGroup(string id, string brandId)
        {
            var userGroup = _groupUserBrandRepository.GetGroupByGroupName(id);

            if (userGroup == null)
            {
                userGroup = new GroupUserBrand();
                userGroup.Name = id;
                userGroup.Brands = new HashSet<string>() { brandId }.ToList();
                _groupUserBrandRepository.Add(userGroup);
            }
            else
            {
                userGroup.Brands = new HashSet<string>(userGroup.Brands) { brandId }.ToList();
                _groupUserBrandRepository.Update(userGroup);
            }

            return userGroup;
        }

        public GroupUserBrand UnassignBrandFromUserGroup(string id, string brandId)
        {
            var userGroup = _groupUserBrandRepository.GetUserGroupByEmailOrGroupName(id);

            userGroup.Brands.Remove(brandId);

            _groupUserBrandRepository.Update(userGroup);

            return userGroup;
        }
    }
}
