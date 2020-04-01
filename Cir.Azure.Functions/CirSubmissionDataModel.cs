using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class CirSubmissionDataModel : CirSubmissionSyncData, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } 

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

    }
    public class CirSubmissionSyncData : IDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public long CirId { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public int Revision { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [JsonProperty(PropertyName = "cirCollectionName")]
        public string CirCollectionName { get; set; }

        [JsonProperty(PropertyName = "cirBrand")]
        public string CirBrandName { get; set; }

        [JsonProperty(PropertyName = "cirTemplateName")]
        public string CirTemplateName { get; set; }

        [JsonProperty(PropertyName = "cirTemplateId")]
        public string CirTemplateId { get; set; }

        [JsonProperty(PropertyName = "templateVersion")]
        public double templateVersion { get; set; }

        [JsonProperty(PropertyName = "sqlProcessStatus")]
        public string SqlProcessStatus { get; set; }

        [JsonProperty(PropertyName = "imageProcessStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.ImageProcessStatus ImageProcessStatus { get; set; }

        [JsonProperty(PropertyName = "browserDetails")]
        public string BrowserDetails { get; set; }

        [JsonProperty(PropertyName = "isNewCirData")]
        public string IsNewCirData { get; set; }

        [JsonProperty(PropertyName = "lockedBy")]
        public string LockedBy { get; set; }

        [JsonProperty(PropertyName = "imageReferences")]
        public IList<ImageDataModel> ImageReferences { get; set; }

        [JsonProperty(PropertyName = "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.CirState State { get; set; }

        [JsonProperty(PropertyName = "deletedFromCache")]
        public string DeletedFromCache { get; set; }

        [JsonProperty(PropertyName = "relatedCirs")]
        public List<RelatedIds> RelatedCirs { get; set; }

        [JsonProperty(PropertyName = "revisionsHistory")]
        public List<RevisionHistory> RevisionHistory { get; set; }

        [JsonProperty(PropertyName = "mailStatus")]
        public string MailStatus { get; set; }

    }
    public class RelatedIds
    {
        public string id { get; set; }
    }
    public class RevisionHistory
    {
        public DateTime editedOn { get; set; }
        public string editedBy { get; set; }
        public string Comments { get; set; }
    }
    public class ImageDataModel : ICirBlobStorageData
    {
        [JsonProperty(PropertyName = "imageId")]
        public string ImageId { get; set; }

        [JsonProperty(PropertyName = "blobGuid")]
        public string BlobGuid { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public string CirId { get; set; }

        [JsonProperty(PropertyName = "templateId")]
        public string TemplateId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "binaryDataUrl")]
        public string BinaryDataUrl { get; set; }

        [JsonProperty(PropertyName = "binaryData")]
        public string BinaryData { get; set; }

        [JsonProperty(PropertyName = "contentType")]
        public string ContentType => "jpeg";

        [JsonProperty(PropertyName = "binaryContentType")]
        public string BinaryContentType => "txt";

        [JsonProperty(PropertyName = "turbineNumber")]
        public string TurbineNumber { get; set; }

        [JsonProperty(PropertyName = "flangeNo")]
        public int FlangeNo { get; set; }

        [JsonProperty(PropertyName = "imageDescription")]
        public string ImageDescription { get; set; }
    }
    public class ICirBlobStorageData
    {
        string BlobGuid { get; set; }
        string CirId { get; set; }
        string TemplateId { get; set; }
        string Url { get; set; }
        string BinaryDataUrl { get; set; }
        string BinaryData { get; set; }
        string ContentType { get; }
        string BinaryContentType { get; }
        string TurbineNumber { get; set; }
    }
}
