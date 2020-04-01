using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public interface IBirRepository
    {
        Task<IList<Bir>> GetAsync(
            string turbineId,
            bool? isAnnual,
            IList<int> modifiedYears,
            string birGuid,
            bool metadataOnly = false);
        Task<IList<Bir>> GetAsync(
            IList<string> turbineIds,
            bool? isAnnual,
            IList<int> modifiedYears,
            string birGuid,
            bool metadataOnly = false);
    }
}
