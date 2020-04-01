using System;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirRevisionDetailsItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public long CirId { get; set; }

        [JsonProperty(PropertyName = "cirGuid")]
        public string CirGuid { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public int Revision { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [JsonProperty(PropertyName = "cirCollectionName")]
        public string CirCollectionName { get; set; }
    }
}
