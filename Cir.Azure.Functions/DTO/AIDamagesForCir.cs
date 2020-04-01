using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class AIDamagesForCir
    {
        [JsonProperty(PropertyName = "images")]
        public List<AiDamagesForCirImage> Images { get; set; }
    }

    public class AiDamagesForCirImage
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        [JsonProperty(PropertyName = "damageSeverity")]
        public int? DamageSeverity { get; set; }
        [JsonProperty(PropertyName = "damagePlacement")]
        public string DamagePlacement { get; set; }
        [JsonProperty("radius")]
        public int? Radius { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("confidence")]
        public double? Confidence { get; set; }
        [JsonProperty("boundingBox")]
        public BoundingBox BoundingBox { get; set; }      
    }

}
