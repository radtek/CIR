using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    class DefectDetectionRequest
    {
        [JsonProperty("turbineId", Required = Required.Always)]
        public int TurbineId { get; set; }
        [JsonProperty("cirGuid", Required = Required.Always)]
        public string CirGuid { get; set; }
        [JsonProperty("images", Required = Required.Always)]
        public List<DDImage> Images { get; set; }
    }

    class DDImage
    {
        [JsonProperty("path", Required = Required.Always)]
        public string Path { get; set; }
    }
}
