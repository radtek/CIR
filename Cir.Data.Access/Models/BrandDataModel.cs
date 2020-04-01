using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class BrandDataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // => "partition";

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
