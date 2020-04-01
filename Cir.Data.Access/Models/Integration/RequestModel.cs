using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models.Integration
{
    internal class RequestModel : ICosmosDbIDataModel, IDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public long CirId { get; set; }

        [JsonProperty(PropertyName = "cirCollectionName")]
        public string CirCollectionName { get; set; }

        [JsonProperty(PropertyName = "operationType")]
        public OperationType OperationType { get; set; }

        [JsonProperty(PropertyName = "requestState")]
        public RequestState RequestState { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }  //=> "partition";

        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [JsonProperty(PropertyName = "requestedBy")]
        public string RequestedBy { get; set; }

    }
}
