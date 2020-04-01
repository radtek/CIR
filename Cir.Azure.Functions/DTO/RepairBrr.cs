using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class RepairBrrDto
    {
        [JsonProperty(PropertyName = "brrs")]
        public List<RepairBrr> Brrs { get; set; }
    }

    class RepairBrr
    {
        [JsonProperty(PropertyName = "repairId")]
        public string RepairId { get; set; }
        [JsonProperty(PropertyName = "fileName")]
        public string Filename { get; set; }
        [JsonProperty(PropertyName = "brrDataString")]
        public string BrrDataString { get; set; }
    }
}
