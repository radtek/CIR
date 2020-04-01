using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class RepairListDto
    {
        [JsonProperty(PropertyName = "repairs")]
        public List<Repair> Repairs { get; set; }
    }

    class Repair
    {
        [JsonProperty(PropertyName = "turbineId")]
        public string TurbineId { get; set; }
        [JsonProperty(PropertyName = "bladeId")]
        public string BladeId { get; set; }
        [JsonProperty(PropertyName = "damageId")]
        public string DamageId { get; set; }
        [JsonProperty(PropertyName = "repairId")]
        public string RepairId { get; set; }
        [JsonProperty(PropertyName = "damageGuid")]
        public string DamageGuid { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
    }
}
