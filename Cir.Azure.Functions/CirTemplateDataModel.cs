using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
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

    public class BrandDataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; } // => "partition";
    }

    public class CirTemplateShortDataModel : IDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    internal interface ICosmosDbIDataModel
    {
        string Partition { get; }
    }

    public interface IDataModel
    {
        string Id { get; }
    }

    public class TurbineNumberList
    {
        public IList<string> lstTurbineNumber { get; set; }
    }
}
