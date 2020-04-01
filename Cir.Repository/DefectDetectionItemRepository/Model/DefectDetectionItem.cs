using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Repository
{
    public class DefectDetectionItem
    {
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; }
        [JsonProperty("options")]
        public Options Options { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }
        [JsonProperty("cir_id")]
        public string CirId { get; set; }
        [JsonProperty("turbine_id")]
        public string TurbineId { get; set; }
        [JsonProperty("estimated_delivery_date")]
        public string EstimatedDeliveryDate { get; set; }
    }

    public class Image
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
    public class Options
    {
        [JsonProperty("dev")]
        public Dev Dev { get; set; }
    }

    public class Dev
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
