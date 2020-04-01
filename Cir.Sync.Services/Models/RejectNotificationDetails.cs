using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.Models
{
    [DataContract]
    public class RejectNotificationDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "rejectNotificationId")]
        public Int64 RejectNotificationId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "componentInspectionReportId")]
        public Int64 ComponentInspectionReportId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "infoPathFilename")]
        public String InfoPathFilename { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sendOn")]
        public DateTime? SendOn { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sendTo")]
        public String SendTo { get; set; }


        [DataMember]
        [JsonProperty(PropertyName = "rejectedBy")]
        public String RejectedBy { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "comment")]
        public String Comment { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "received")]
        public DateTime? Received { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sbuId")]
        public Int64? SBUId { get; set; }

        

          [DataMember]
        [JsonProperty(PropertyName = "cimCaseNo")]
        public Int64? CIMCaseNo { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "wordBytesUrl")]
        public Uri WordBytesUrl { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineNumber")]
        public Int64? TurbineNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "cirAttachmentsDetails")]
        public CirAttachmentsDetails cirAttachments { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}