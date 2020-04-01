using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirDamagesListDto
    {
        [JsonProperty(PropertyName = "data")]
        public List<CirDamagesData> Data { get; set; }
    }

    class CirDamagesSingleDto
    {
        [JsonProperty(PropertyName = "data")]
        public CirDamagesData Data { get; set; }
    }

    class CirDamagesData
    {
        [JsonProperty(PropertyName = "cirId")]
        public int? CirId { get; set; }
        [JsonProperty(PropertyName = "cirGuid")]
        public string CirGuid { get; set; }
        [JsonProperty("turbineId")]
        public int? TurbineId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string InspectionDescription { get; set; }

        [JsonProperty(PropertyName = "inspectionDate")]
        public string InspectionDate { get; set; }

        [JsonProperty(PropertyName = "damages")]
        public List<CirDamage> Damages { get; set; }
    }

    public class CirDamage
    {
        [JsonProperty(PropertyName = "damageId")]
        public string DamageID { get; set; }
        [JsonProperty(PropertyName = "damageGuid")]
        public string DamageGuid { get; set; }
        [JsonProperty(PropertyName = "severity")]
        public int? Severity { get; set; }

        [JsonProperty(PropertyName = "imageName")]
        public string ImageName { get; set; }
        [JsonProperty(PropertyName = "imageId")]
        public string ImageId { get; set; }

        [JsonProperty(PropertyName = "damageImage")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }
        [JsonProperty(PropertyName = "damagePlacement")]
        public string DamagePlacement { get; set; }
        [JsonProperty(PropertyName = "damageType")]
        public string DamageType { get; set; }
        [JsonProperty(PropertyName = "radius")]
        public int? Radius { get; set; }
        [JsonProperty(PropertyName = "rootCause")]
        public string RootCause { get; set; }
        [JsonProperty(PropertyName = "recommendedActivity")]
        public string RecommendedActivity { get; set; }

        [JsonProperty("boundingBox")]
        public BoundingBox BoundingBox{get; set;}
    }
}
