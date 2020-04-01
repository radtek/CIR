using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
    public class UserData : DataModel
    {
        public string TableName { get; set; }

        public IList<object> DataList { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public object Roles { get; set; }

        public void SetRoles(List<string> ids)
        {
            Roles = GetJsonObjectsListSerialized(ids);
        }

        public List<string> GetRoles()
        {
            return GetJsonObjectsListDeserialized(Roles);
        }
    }
}
