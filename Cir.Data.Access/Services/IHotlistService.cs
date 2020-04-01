using Cir.Data.Access.Models;
using System.Collections.Generic;

namespace Cir.Data.Access.Services
{
    public interface IHotlistService
    {
        string TableName { get; }
        HotlistDataModel Get(string id);
        IEnumerable<HotlistDataModel> GetAll();
        HotlistDataModel Add(HotlistDataModel hotlistData);
        void Delete(string id);
        HotlistDataModel GetByHotItemId(long hotItemId);
        void Update(HotlistDataModel hotlistData);
        void DeleteByHotItemId(long hotItemId);
        IList<object> GetTableData(List<string> brandIds);
    }
}
