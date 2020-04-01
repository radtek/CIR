using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirTemplateDataModel : CirTemplateShortDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "versionNumber")]
        public double VersionNumber { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }  //=> "partition";

        [JsonProperty(PropertyName = "cirBrand")]
        public BrandDataModel CirBrand { get; set; }

        [JsonProperty(PropertyName = "cirBrandCollectionName")]
        public string CirBrandCollectionName { get; set; }
    }
}
