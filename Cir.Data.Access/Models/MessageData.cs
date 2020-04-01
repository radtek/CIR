using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class MessageData : ICosmosDbIDataModel,IDataModel
    {
      
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }// => "partition";

        [JsonProperty(PropertyName = "messageText")]
        public string MessageText { get; set; }
        
        [JsonProperty(PropertyName = "isReceived")]
        public bool IsReceived { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public string Sender { get; set; }
        
        [JsonProperty(PropertyName = "receiver")]
        public string Receiver { get; set; }             
      
    }
}