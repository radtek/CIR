using Newtonsoft.Json;
using System;
using static Cir.Data.Access.Enumerations.Enumeration;

namespace Cir.Data.Access.Models
{
    internal class CirLogDetails 
    {       
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }       

        [JsonProperty(PropertyName = "modifiedBy")]
        public DateTime ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "logType")]
        public LogType LogType { get; set; }

       
    }
}
