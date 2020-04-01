using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
    public class GroupUserBrand : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } //=> "partition";

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "brands")]
        public IList<string> Brands { get; set; }
    }
}
