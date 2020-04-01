using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.Models
{
    [DataContract]
    public class SecondNotificationDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "secondNotificationId")]
        public Int64 SecondNotificationId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "componentInspectionReportId")]
        public Int64 ComponentInspectionReportId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sendOn")]
        public DateTime? SendOn { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "manufacturerId")]
        public Int64? ManufacturerId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sbuId")]
        public Int64 SBUId { get; set; }

         [DataMember]
        [JsonProperty(PropertyName = "componentType")]
        public string ComponentType { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirTemplate")]
        public byte[] CIRTemplate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cimCaseNumber")]
        public Int64 CIMCaseNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineMatrixId")]
        public Int64? TurbineMatrixId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineNumber")]
        public Int64? TurbineNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirDataId")]
        public Int64? CirDataId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordBytesUrl")]
        public Uri WordBytesUrl { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirAttachmentsDetails")]
        public CirAttachmentsDetails cirAttachments { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}