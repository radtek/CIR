using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cir.Data.Access.Enumerations.Enumeration;

namespace Cir.Data.Access.DataAccess
{
    internal class CirLogRepository :ICirLogRepository
    {
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;

        //Added
        private string containername;
        public CirLogRepository(BlobStorageConfig config)
        {          
     
                var storageAccount = CloudStorageAccount.Parse(config.AzureStorageConnectionString);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(config.AzureStorageContainerName);

            //Added
            containername = config.AzureStorageContainerName;

        }
        public void AddLogs(string id, string turbineNumber, string logText, DateTime date, LogType logType)
        {
            try
            {
                string dataType = "CIR", blobType = "Logs", contentType = ".json";
                //Checking if blobs present in the storage for CIR
                if (!(container.GetDirectoryReference($"{turbineNumber}/{ dataType}/{id}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(id);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }
                //end
                var binaryDataFileName = $"{turbineNumber}/{dataType}/{id}/{blobType}/{id}{contentType}";
                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);          
                binaryDataBlockBlob.Properties.ContentType = "text/json";
                List<CirLogDetails> cirLogDetails = new List<CirLogDetails>();
                if (binaryDataBlockBlob.Exists())               
                {
                    var CirLogDetailsData = binaryDataBlockBlob.DownloadText();
                    cirLogDetails = JsonConvert.DeserializeObject<List<CirLogDetails>>(CirLogDetailsData).ToList();
                }
                var logs = new CirLogDetails();                
                logs.Text = logText;
                logs.ModifiedBy = date;
                logs.LogType = logType;
                cirLogDetails.Add(logs);
                using (var ms = new MemoryStream())
                {
                    LoadStreamWithJson(ms, cirLogDetails);
                    binaryDataBlockBlob.UploadFromStream(ms);
                }                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadStreamWithJson(Stream ms, List<CirLogDetails> revision)
        {
            var json = JsonConvert.SerializeObject(revision);
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
        }

        private string GetKey(CloudBlobContainer container)
        {
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(key);
            return (!blockBlob.Exists()) ? key : GetKey(container);
        }
    }
}
