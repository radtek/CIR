using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cir.Data.Access.Models
{
    class CirUserData
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public long CirId { get; set; }

        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // { get { return "partition"; } set { } }

        [JsonProperty(PropertyName = "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CirState State { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public IList<string> Errors { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [JsonProperty(PropertyName = "delegatedBy")]
        public string DelegatedBy { get; set; }

        [JsonProperty(PropertyName = "delegatedTo")]
        public string DelegatedTo { get; set; }

        [JsonProperty(PropertyName = "sqlProcessStatus ")]
        public string SqlProcessStatus { get; set; }

        [JsonProperty(PropertyName = "cirTemplateId")]
        public string CirTemplateId { get; set; }

        [JsonProperty(PropertyName = "cirTemplateName")]
        public string CirTemplateName { get; set; }

        [JsonProperty(PropertyName = "lockedBy")]
        public string LockedBy { get; set; }

        [JsonProperty(PropertyName = "isSynced")]
        public bool IsSynced { get; set; }
    }
}
