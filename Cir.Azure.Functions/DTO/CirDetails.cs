using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirDetailsListDto
    {
        [JsonProperty(PropertyName = "data")]
        public List<CirDetailsData> Data { get; set; }
    }

    class CirDetailsSingleDto
    {
        [JsonProperty(PropertyName = "data")]
        public CirDetailsData Data { get; set; }
    }

    class CirDetailsData
    {
        [JsonProperty("cirGuid")]
        public string CirGuid { get; set; }
        [JsonProperty("cirId")]
        public int? CirId { get; set; }
        [JsonProperty("turbineId")]
        public int? TurbineId { get; set; }
        [JsonProperty("localTurbineId")]
        public string LocalTurbineId { get; set; }
        [JsonProperty("inspectionDate")]
        public string InspectionDate{ get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("commissioningDate")]
        public string CommissioningDate { get; set; }
        [JsonProperty("bladeSerialNumber")]
        public string BladeSerialNumber{ get; set; }
        [JsonProperty("bladeLength")]
        public string BladeLength { get; set; }
        [JsonProperty("mkVersion")]
        public string MkVersion { get; set; }
        [JsonProperty("sbuRecommendation")]
        public string SbuRecommendation { get; set; }
        [JsonProperty("section1", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section1 { get; set; }
        [JsonProperty("section2", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section2 { get; set; }
        [JsonProperty("section3", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section3 { get; set; }
        [JsonProperty("section4", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section4 { get; set; }
        [JsonProperty("section5", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section5 { get; set; }
        [JsonProperty("section6", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section6 { get; set; }
        [JsonProperty("section7", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section7 { get; set; }
        [JsonProperty("section8", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section8 { get; set; }
        [JsonProperty("section9", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section9 { get; set; }
        [JsonProperty("section10", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section10 { get; set; }
        [JsonProperty("section11", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section11 { get; set; }
        [JsonProperty("section12", NullValueHandling = NullValueHandling.Ignore)]
        public Section Section12 { get; set; }
        [JsonProperty("noSection", NullValueHandling = NullValueHandling.Ignore)]
        public NoSection NoSection { get; set; }
        [JsonProperty("plateImageUrl")]
        public string PlateImageUrl { get; set; }
    }

    class NoSection
    {
        [JsonProperty("overallBladeCondition")]
        public int? OverallBladeCondition { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }

    class Section
    {
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }

    class Image
    {
        [JsonProperty("imageGuid")]
        public string ImageGuid { get; set; }
        [JsonProperty("imageNumber")]
        public int? ImageNumber { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Severity { get; set; }
        [JsonProperty("damageType")]
        public string DamageType { get; set; }
        [JsonProperty("damageDescription")]
        public string DamageDescription { get; set; }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public string Side { get; set; }
    }
}
