using System.Collections.Generic;
using Cir.Data.Access.Models;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.Services
{
    public interface IBirDataService
    {
        BirDetailsData Get(string id);
        IEnumerable<BirDetailsData> GetAll();
        BirDetailsData Add(BirDetailsData report);
        BirDetailsData Update(BirDetailsData report);
        void Delete(string reportId);
        void SaveBirData(Bir bir);

    }
}