using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
    public class ImageDataModel : ICirBlobStorageData
    {
        [JsonProperty(PropertyName = "cirID")]
        public string CirID { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "binaryData")]
        public string BinaryData { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string ImageDescription { get; set; }

        [JsonProperty(PropertyName = "contentType")]
        public string ContentType => "Jpeg";
    }

    public class ImageDataList
    {
        public List<ImageDataModel> imageData { get; set; }
    }
}