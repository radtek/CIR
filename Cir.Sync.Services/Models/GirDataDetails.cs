using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class GirDataDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }// => "partition";

        [DataMember]
        [JsonProperty(PropertyName = "girCode")]
        public string GirCode { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "girDataID")]
        public long GirDataID { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "revisionNumber")]
        public int RevisionNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "classificationOfDamage")]
        public string ClassificationOfDamage { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "analysisOfPicture")]
        public string AnalysisOfPicture { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "analysisOfMeasurments")]
        public string AnalysisOfMeasurments { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "conclusionsAndRecommendations")]
        public string ConclusionsAndRecommendations { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirIds")]
        public string CirIDs { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "masterId")]
        public string MasterId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineId")]
        public string TurbineId { get; set; }

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
        [JsonProperty(PropertyName = "generalSerialNos")]
        public string GeneralSerialNos { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordBytesUrl")]
        public Uri WordBytesUrl { get; set; }
    }
}