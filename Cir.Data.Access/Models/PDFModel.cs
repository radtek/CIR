using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cir.Data.Access.Models
{
    public class PDFModel : ICirPDFBlobStorageData
    {
        [JsonProperty(PropertyName = "pdfId")]
        public long PDFId { get; set; }

        [JsonProperty(PropertyName = "pdfData")]
        public byte[] PDFData { get; set; }

        [JsonProperty(PropertyName = "cirState")]
        public int CIRState { get; set; }

        [JsonProperty(PropertyName = "cirTemplateGuid")]
        public string CIRTemplateGUID { get; set; }

        [JsonProperty(PropertyName = "cirName")]
        public string CIRName { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public string CIRID { get; set; }

        [JsonProperty(PropertyName = "turbineNumber")]
        public string TurbineNumber { get; set; }

        [JsonProperty(PropertyName = "blobGuid")]
        public string BlobGuid { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public string Modified { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public string Revision { get; set; }
    }

    public class PDFModel1
    {
        [JsonProperty(PropertyName = "pdfId")]
        public long PDFId { get; set; }

        [JsonProperty(PropertyName = "pdfData")]
        public string PDFData { get; set; }

        [JsonProperty(PropertyName = "cirState")]
        public int CIRState { get; set; }

        [JsonProperty(PropertyName = "cirTemplateGuid")]
        public string CIRTemplateGUID { get; set; }

        [JsonProperty(PropertyName = "cirName")]
        public string CIRName { get; set; }

        [JsonProperty(PropertyName = "cirId")]
        public string CIRID { get; set; }

        [JsonProperty(PropertyName = "turbineNumber")]
        public string TurbineNumber { get; set; }

        [JsonProperty(PropertyName = "blobGuid")]
        public string BlobGuid { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }


        [JsonProperty(PropertyName = "modified")]
        public string Modified { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public string Revision { get; set; }
    }

    public class CirPDFResponse
    {
        public string DownloadUrl { get; set; }
        public string FileName { get; set; }
    }
}
