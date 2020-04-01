using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class BirListDto
    {
        [JsonProperty("data")]
        public IList<Bir> Data { get; set; }
    }

    class BirSingleDto
    {
        [JsonProperty("data")]
        public Bir Data { get; set; }
    }

    class Bir
    {
        [JsonProperty("turbineId")]
        public string TurbineId { get; set; }
        [JsonProperty("birGuid")]
        public string BirGuid { get; set; }
        [JsonProperty("isAnnual")]
        public bool? IsAnnual { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("fileName")]
        public string Filename { get; set; }
        [JsonProperty("birDataString", NullValueHandling = NullValueHandling.Ignore)]
        public string BirDataString { get; set; }
        [JsonProperty("relatedCirs")]
        public List<int> RelatedCirs { get; set; }
    }
}
