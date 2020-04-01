using Cir.Data.Access.Models;
using System.Collections.Generic;

namespace Cir.Data.Access.DataAccess
{
    internal interface IHotlistRepository
    {
        HotlistDataModel Get(string id);
        List<HotlistDataModel> GetAll();
        void Add(HotlistDataModel hotlist);
        void Delete(string id);
        HotlistDataModel GetByHotItemId(long hotItemId);
        void Update(HotlistDataModel hotlistData);
    }
}
