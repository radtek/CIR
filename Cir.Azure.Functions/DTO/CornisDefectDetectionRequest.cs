using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    class CornisDefectDetectionRequest
    {
        [JsonProperty("images")]
        public List<CDDImage> Images { get; set; }
        [JsonProperty("cir_id")]
        public string CirId { get; set; }
        [JsonProperty("turbine_id")]
        public string TurbineId { get; set; }
        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; }
        [JsonProperty("options")]
        public CDDOptions Options { get; set; }
    }

    class CDDImage
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }

    class CDDOptions
    {
        [JsonProperty("dev")]
        public CDDDev Dev { get; set; }
    }

    class CDDDev
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
