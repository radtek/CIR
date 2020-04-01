using Newtonsoft.Json;
using System;

namespace Cir.Data.Access.Models
{
    public class CirSubmissionData : CirSubmissionSyncData, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get { return "partition"; } set { } }

        [JsonProperty(PropertyName = "state")]
        public CirState State { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }
    }
}