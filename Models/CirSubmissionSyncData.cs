using Newtonsoft.Json;
using System;

namespace Cir.Data.Access.Models
{
    public class CirSubmissionSyncData : IDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }
    }
}

