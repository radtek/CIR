using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Cir.Repository
{
    public class BrrRepositoryMock : IBrrRepository
    {
        private readonly JObject[] brrs;

        public BrrRepositoryMock()
        {
            brrs = new JObject[]
            {
                JObject.Parse("{\"repairId\": \"1\", \"filename\": \"brr_1.pdf\", \"brrDataString\": \"qwerty\"}"),
                JObject.Parse("{\"repairId\": \"2\", \"filename\": \"brr_2.pdf\", \"brrDataString\": \"asdfg\"}")
            };
        }
        public async Task<IList<JObject>> GetAllAsync(IList<string> turbineIds, IList<string> repairIds)
        {
            return brrs
                .Where(b => repairIds.Contains(b["repairIds"].Value<string>()))
                .ToList();
        }
    }
}
