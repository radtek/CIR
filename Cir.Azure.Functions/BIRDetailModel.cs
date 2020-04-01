using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class BIRDetailModel
    {
        [JsonProperty(PropertyName = "birGuid")]
        public string BirGuid { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "isAnnual")]
        public string IsAnnual { get; set; }

        [JsonProperty(PropertyName = "relatedCIRs")]
        public string RelatedCIRs { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
