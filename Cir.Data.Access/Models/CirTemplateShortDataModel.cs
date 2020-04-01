using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirTemplateShortDataModel : IDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
