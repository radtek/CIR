using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirIdGeneratorService
    {
        CirIdModel GetCirId(string cirBrandCollectionName);
    }
}
