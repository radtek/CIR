using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions.DTO
{
    public class CornisOCRRequest
    {
        [JsonProperty("cir_id")]
        public string CirId { get; set; }

        [JsonProperty("turbine_id")]
        public string TurbineId { get; set; }

        [JsonProperty("images")]
        public List<PathObject> Images { get; set; }

        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; } = "vestas_0.0.3";
    }

    public class PathObject
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
