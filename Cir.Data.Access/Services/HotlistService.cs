using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Services
{
    internal class HotlistService : IHotlistService
    {
        public string TableName => "HotList";
        private readonly IHotlistRepository _hotlistRepository;
        private readonly IGroupUserBrandRepository _groupUserBrandRepository;

        public HotlistService(IHotlistRepository hotlistRepository, IGroupUserBrandRepository groupUserBrandRepository)
        {
            _hotlistRepository = hotlistRepository;
            _groupUserBrandRepository = groupUserBrandRepository;
        }

        public HotlistDataModel Get(string id)
        {
            return _hotlistRepository.Get(id);
        }

        public IEnumerable<HotlistDataModel> GetAll()
        {
            return _hotlistRepository.GetAll();
        }

        public HotlistDataModel Add(HotlistDataModel hotlistData)
        {
            if(hotlistData.HotItemId == 0)
            {
                var list = GetAll();
                var ids = list.Select(l => l.HotItemId).ToList();
                var max = ids.Max();
                var nextId = ++max;

                hotlistData.HotItemId = nextId;
            }

            _hotlistRepository.Add(hotlistData);

            return hotlistData;
        }

        public void Delete(string id)
        {
            _hotlistRepository.Delete(id);
        }

        public IList<object> GetTableData(List<string> brandIds)
        {
            return _hotlistRepository.GetAll().Where(x => brandIds.Any(b => b == x.Brand.Id)).ToList<object>();
        }

        public HotlistDataModel GetByHotItemId(long hotItemId)
        {
            return _hotlistRepository.GetByHotItemId(hotItemId);
        }

        public void Update(HotlistDataModel hotlistData)
        {
            _hotlistRepository.Update(hotlistData);
        }

        public void DeleteByHotItemId(long hotItemId)
        {
            var hotList = GetByHotItemId(hotItemId);

            _hotlistRepository.Delete(hotList.Id);
        }
    }
}
