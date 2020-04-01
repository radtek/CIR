using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public interface ICirRepository
    {
        Task<IList<JObject>> GetAllAsync(string turbineId, ISpecification spec = null);
        Task<IList<JObject>> GetAllAsync(IList<string> turbineIds, ISpecification spec = null);
        Task<JObject> GetExactlyOneAsync(string turbineId, ISpecification spec = null);
        Task<bool> StoreFileByCirAsync(string turbineId, string cirId, string filename, string fileContent);
        Task<string> GetFileByCirAsync(string turbineId, string cirId, string filename);
    }
}
