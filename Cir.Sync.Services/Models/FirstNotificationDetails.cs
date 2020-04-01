using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Cir.Sync.Services.Models
{
    [DataContract]
    public class FirstNotificationDetails
    {
        [DataMember]
        [JsonProperty(PropertyName = "firstNotificationId")]
        public Int64 FirstNotificationId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "componentInspectionReportId")]        
        public Int64 ComponentInspectionReportId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sendOn")]
        public DateTime? SendOn { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "sbuId")]
        public Int64 SBUId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "editDate")]
        public DateTime? EditDate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "editInitials")]
        public string EditInitials { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "turbineMatrixId")]
        public Int64? TurbineMatrixId { get; set; }




        [DataMember]
        [JsonProperty(PropertyName = "siteName")]
        public string Sitename { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "countryISOId")]
        public Int64 CountryISOId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "componentType")]
        public string ComponentType { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "manufacturerID")]
        public int ManufacturerID { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "serialNo")]
        public string SerialNo { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "commisioningDate")]
        public DateTime? CommisioningDate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "failureDate")]
        public DateTime? FailureDate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "queuedOn")]
        public DateTime? QueuedOn { get; set; }

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
        [JsonProperty(PropertyName = "turbineNumber")]
        public Int64? TurbineNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
[DataContract]
public class CirAttachmentsDetails
{
    [DataMember]
    [JsonProperty(PropertyName = "cirAttachmentId")]
    public long? CirAttachmentId { get; set; } = 0;

    [DataMember]
    [JsonProperty(PropertyName = "cirId")]
    public long CirId { get; set; }

    [DataMember]
    [JsonProperty(PropertyName = "filename")]
    public string Filename { get; set; } = String.Empty;
    [DataMember]
    [JsonProperty(PropertyName = "createdBy")]
    public string CreatedBy { get; set; } = String.Empty;
    [DataMember]
    [JsonProperty(PropertyName = "created")]
    public string Created { get; set; } = String.Empty;
    [DataMember]
    [JsonProperty(PropertyName = "binaryData")]
    public byte[] BinaryData { get; set; }
}