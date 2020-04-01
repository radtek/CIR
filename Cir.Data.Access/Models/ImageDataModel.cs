using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
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
}