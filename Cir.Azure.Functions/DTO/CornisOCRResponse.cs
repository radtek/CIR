using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions.DTO
{
    public class CornisOCRResponse
    {
        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("images")]
        public List<CornisImageResponse> Images { get; set; }

        [JsonProperty("cir_id")]
        public string CirId { get; set; }

        [JsonProperty("turbine_id")]
        public string TurbineId { get; set; }

        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; }
    }

    public class CornisImageResponse
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("ocr")]
        public List<CornisOCRObject> OCR { get; set; }
    }

    public class CornisOCRObject
    {
        [JsonProperty("detected_text")]
        public string DetectedText { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("field_name")]
        public string FieldName { get; set; }
    }

    public class OCRResponse
    {
        [JsonProperty("bladeColor")]
        public string BladeColor { get; set; }

        [JsonProperty("bladeId")]
        public string BladeId { get; set; }

        [JsonProperty("bladeSerialNumber")]
        public string BladeSerialNumber { get; set; }
    }
}
