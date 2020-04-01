using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class CirRevisionDetails: IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cirSubmissionData")]
        public CirSubmissionData CirSubmissionData { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition => "history_partition";
    }
}
