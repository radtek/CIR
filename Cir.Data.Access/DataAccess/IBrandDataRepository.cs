using System.Collections.Generic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    interface IBrandDataRepository
    {
        BrandDataModel Get(string id);
        List<BrandDataModel> GetAll();
        void Add(BrandDataModel brandDataModel);
        List<BrandDataModel> GetByIds(IList<string> brandIds);
    }
}
