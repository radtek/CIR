using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    internal interface ICirIdRepository
    {
        CirIdModel GetCirId(string cirBrandCollectionName);

        CirIdModel GetByCirId(long cirId);

        void Add(CirIdModel cirId);
    }
}
