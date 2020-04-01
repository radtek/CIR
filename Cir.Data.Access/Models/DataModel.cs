using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Cir.Data.Access.Models
{
    public class DataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // => "partition";

        protected virtual object GetJsonObjectsListSerialized(List<string> list)
        {
            return JsonConvert.SerializeObject(list);
        }

        protected List<string> GetJsonObjectsListDeserialized(object o)
        {
            return JsonConvert.DeserializeObject<IEnumerable<string>>(o.ToString()).ToList();
        }
    }
}
