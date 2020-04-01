using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    class CornisDefectDetectionResponse
    {
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
}
