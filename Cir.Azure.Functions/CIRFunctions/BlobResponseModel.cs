using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
   public class BlobResponseModel
    {
        [JsonProperty(PropertyName = "sasKey")]
        public string SASKey { get; set; }

        [JsonProperty(PropertyName = "blobUri")]
        public Uri BlobUri { get; set; }

        [JsonProperty(PropertyName = "containerName")]
        public CloudBlobContainer ContainerName { get; set; }
    }
}
