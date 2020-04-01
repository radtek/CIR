using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirTemplateDataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "schema")]
        public object Schema { get; set; }

        [JsonProperty(PropertyName = "versionNumber")]
        public double VersionNumber => 1.0;

        [JsonProperty(PropertyName = "partition")]
        public string Partition => "partition";
    }
}
