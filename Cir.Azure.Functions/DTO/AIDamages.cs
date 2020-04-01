using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class AIDamages
    {
        [JsonProperty(PropertyName = "workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty(PropertyName = "cir_id")]
        public string CirId { get; set; }

        [JsonProperty(PropertyName = "turbine_id")]
        public string TurbineId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "output_body")]
        public AIDamagesOutputBody OutputBody { get; set; }
    }

    public class AIDamagesOutputBody
    {
        [JsonProperty(PropertyName = "spec_version")]
        public string SpecVersion { get; set; }

        [JsonProperty(PropertyName = "images")]
        public List<AiDamagesImage> Images { get; set; }
    }

    public class AiDamagesImage
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "defects")]
        public List<AiDamagesDefect> Defects { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public AiDamagesMetadata Metadata { get; set; }
    }

    public class AiDamagesMetadata
    {
        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }

        [JsonProperty(PropertyName = "hub_distance_cm")]
        public int HubDistanceCm { get; set; }

        [JsonProperty(PropertyName = "hub_to_tip_order_in_blade")]
        public int HubToTipOrderInBlade { get; set; }
    }

    public class AiDamagesDefect
    {
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }

        [JsonProperty(PropertyName = "qualification")]
        public List<AiDamagesQualification> Qualification { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string DefectId { get; set; }

        [JsonProperty(PropertyName = "hub_distance_cm")]
        public int HubDistanceCm { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public AiDamageGeometry Geometry { get; set; }
    }

    public class AiDamageGeometry
    {
        [JsonProperty(PropertyName = "bounding_box")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty(PropertyName = "polygon")]
        public List<AiDamagesPolygon> Polygons { get; set; }

    }

    public class AiDamagesPolygon
    {
        [JsonProperty(PropertyName = "x")]
        public int X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public int Y { get; set; }

    }

    public class AiDamagesQualification
    {
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }

        [JsonProperty(PropertyName = "damage_level")]
        public int DamageLevel { get; set; }

        [JsonProperty(PropertyName = "damage_category")]
        public string DamageCategory { get; set; }
    }
}
