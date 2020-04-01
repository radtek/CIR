using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirIdListDto
    {
        [JsonProperty(PropertyName = "data")]
        public List<CirIdData> Data { get; set; }
    }

    class CirIdSingleDto
    {
        [JsonProperty(PropertyName = "data")]
        public CirIdData Data { get; set; }
    }

    class CirIdData
    {
        [JsonProperty("cirGuid")]
        public string CirGuid { get; set; }
        [JsonProperty("cirId")]
        public int? CirId { get; set; }
        [JsonProperty("turbineId")]
        public int? TurbineId { get; set; }
    }

}
