using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class BirDataDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }// => "partition";

        [DataMember]
        [JsonProperty(PropertyName = "birCode")]
        public string BirCode { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "birDataID")]
        public long BirDataID { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "revisionNumber")]
        public int RevisionNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "repairingSolutions")]
        public string RepairingSolutions { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "rawMaterials")]
        public string RawMaterials { get; set; }

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
        [JsonProperty(PropertyName = "bladeSerialNos")]
        public string BladeSerialNos { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordBytesUrl")]
        public Uri WordBytesUrl { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "isAnnualInspection")]
        public bool IsAnnualInspection { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordDocStatus")]
        public string WordDocStatus { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "pdfStatus")]
        public string PDFStatus { get; set; }


    }
}