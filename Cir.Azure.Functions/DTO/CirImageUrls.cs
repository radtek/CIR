using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirImageUrlsListDto
    {
        [JsonProperty(PropertyName = "data")]
        public List<CirImageUrlsData> Data { get; set; }
    }
    class CirImageUrlsSingleDto
    {
        [JsonProperty(PropertyName = "data")]
        public CirImageUrlsData Data { get; set; }
    }


    class CirImageUrlsData
    {
        [JsonProperty("cirId")]
        public int? CirId { get; set; }
        [JsonProperty("cirGuid")]
        public string CirGuid { get; set; }
        [JsonProperty("turbineId")]
        public int? TurbineId { get; set; }
        [JsonProperty("imageUrls")]
        public IList<CirImageUrl> ImageUrls { get; set; }
    }

    class CirImageUrl
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

}
