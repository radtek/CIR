using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class Bir
    {
        [JsonProperty("turbineId")]
        public string TurbineId { get; set; }

        [JsonProperty("birGuid")]
        public string BirGuid { get; set; }

        [JsonProperty("isAnnual")]
        public bool? IsAnnual { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }
        [JsonProperty("relatedCirs")]
        public List<int> RelatedCirs { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
