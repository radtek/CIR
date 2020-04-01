using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using static Cir.Data.Access.Enumerations.Enumeration;

namespace Cir.Data.Access.Models
{
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
        public ImageProcessStatus ImageProcessStatus { get; set; }

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
        public CirState State { get; set; }

        [JsonProperty(PropertyName = "deletedFromCache")]
        public string DeletedFromCache { get; set; }

        [JsonProperty(PropertyName = "relatedCirs")]
        public List<RelatedIds> RelatedCirs { get; set; }

        [JsonProperty(PropertyName = "revisionsHistory")]
        public List<RevisionHistory> RevisionHistory { get; set; }

        [JsonProperty(PropertyName = "mailStatus")]
        public string MailStatus { get; set; }

    }
    public class RelatedIds {
       public string id { get; set; }
    }

    public class RevisionHistory
    {
        public DateTime editedOn { get; set; }
        public string editedBy { get; set; }
        public string Comments { get; set; }
    }
}

