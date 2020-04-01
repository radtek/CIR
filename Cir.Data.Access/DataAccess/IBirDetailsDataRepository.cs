using System.Linq;
using Cir.Data.Access.Models;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.DataAccess
{
    internal interface IBirDetailsDataRepository
    {
        BirDetailsData Get(string id);
        IQueryable<BirDetailsData> GetAll();        
        void Add(BirDetailsData report);
        void Update(BirDetailsData report);
        void Delete(string reportId);

        void SaveBirData(Bir bir);
    }

}