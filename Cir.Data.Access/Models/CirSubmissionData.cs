using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirSubmissionData : CirSubmissionSyncData, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // { get { return "partition"; } set { } }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public IList<string> Errors { get; set; }
        
        [JsonProperty(PropertyName = "delegatedBy")]
        public string DelegatedBy { get; set; }
        
        [JsonProperty(PropertyName = "delegatedTo")]
        public string DelegatedTo { get; set; }

        [JsonProperty(PropertyName = "isLockedByTos")]
        public bool IsLockedByTos { get; set; }

        [JsonProperty(PropertyName = "isSentToInspecTool")]
        public bool IsSentToInspecTool { get; set; }

        [JsonProperty(PropertyName = "statusChangedBy")]
        public string StatusChangedBy { get; set; }
        //This Property is removed as it was creating a filled in cir with null value 
        //RelatedCirs is already exist in CirSubmissionSyncData
        //[JsonProperty(PropertyName = "relatedCIRs")]
        //public string RelatedCIRs{ get; set; }

    }
}