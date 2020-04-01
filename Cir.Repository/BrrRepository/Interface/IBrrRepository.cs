using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public interface IBrrRepository
    {
        Task<IList<JObject>> GetAllAsync(
            IList<string> turbineIds,
            IList<string> repairIds);
    }
}
