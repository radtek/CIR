using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class GBXirDataDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "gbxDataID")]
        public long GbxDataID { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "gbxCode")]
        public string GbxCode { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "revisionNumber")]
        public int RevisionNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "oilAnalysis")]
        public string OilAnalysis { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cMSAnalysis")]
        public string CMSAnalysis { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "analysis")]
        public string Analysis { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "conclusionsAndRecommendations")]
        public string ConclusionsAndRecommendations { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirIDs")]
        public string CirIDs { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }
       
        [DataMember]
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "gearboxSerialNos")]
        public string GearboxSerialNos { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineId")]
        public string TurbineId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordBytesUrl")]
        public Uri WordBytesUrl { get; set; }
    }
}