using System;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirIdModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cirId")]
        public long CirId { get; set; }

        [JsonProperty("cirBrandCollectionName")]
        public string CirBrandCollectionName { get; set; }

        [JsonProperty("counter")]
        public bool IsCounter { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }  //=> "partition";
    }
}
