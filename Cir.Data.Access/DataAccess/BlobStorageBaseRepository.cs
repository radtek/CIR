using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal abstract class BlobStorageRepository<T> where T : ICirBlobStorageData
    {
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;

        //Added for multiple storage
        private string containername;

        public BlobStorageRepository(BlobStorageConfig config)
        {
            var storageAccount = CloudStorageAccount.Parse(config.AzureStorageConnectionString);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(config.AzureStorageContainerName);
            //container.CreateIfNotExists();

            //Added for multiple storages
            containername = config.AzureStorageContainerName;
        }

        protected virtual Uri GetByUrl(string url)
        {
            try
            {
                var sasBlobUri = GetBlobSASUri(url.Split('/')[2].Split(':')[0]);
                Uri blobUri = new Uri(url + sasBlobUri);
                CloudBlockBlob Blob = new CloudBlockBlob(blobUri);
                return GetByBlobName(Blob.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual Uri GetByBlobName(string blobName)
        {
            try
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                return blockBlob.Uri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual string GetBlobTextByUrl(string url)
        {
            if (url != null)
            {
                if (!url.Contains("https://servicesprod.vestas.inspectools.net"))
                {
                    var sasBlobUri = GetBlobSASUri(url.Split('/')[2].Split(':')[0]);
                    Uri blobUri = new Uri(url + sasBlobUri);
                    CloudBlockBlob Blob   = new CloudBlockBlob(blobUri);
                    try
                    {
                        return Blob.DownloadText();
                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    try
                    {
                        WebClient client = new WebClient();
                        return client.DownloadString(url);

                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }

                }
            }
            return string.Empty;
        }

        protected virtual async Task<List<Uri>> GetByCirID(string cirID)
        {
            try
            {
                List<Uri> allBlobs = new List<Uri>();
                foreach (IListBlobItem item in container.ListBlobs())
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        await blob.FetchAttributesAsync();
                        if (blob.Metadata["cirID"] == cirID)
                        {
                            allBlobs.Add(item.Uri);
                        }
                    }

                }
                return allBlobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected virtual List<CirRevisionDetails> GetCirRevisionHistory(long turbineNumber, string cirGUID)
        {
            try
            {
                string blobType = "RevisionHistory", dataType = "CIR"; 
                //checked  the directory structure
                if (!(container.GetDirectoryReference($"{turbineNumber}/{dataType}/{cirGUID}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(cirGUID);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }
                //end
                CloudBlobDirectory revisionDirectoryContainer = container.GetDirectoryReference($"{turbineNumber}/{cirGUID}/{blobType}");
                List<CirRevisionDetails> lstCirRevision = new List<CirRevisionDetails>();
                foreach (IListBlobItem item in revisionDirectoryContainer.ListBlobs())
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        var sasBlobUri = GetByBlobName(blob.Name);
                        blob = new CloudBlockBlob(sasBlobUri);
                        lstCirRevision.Add(JsonConvert.DeserializeObject<CirRevisionDetails>(blob.DownloadText()));
                    }
                }
                return lstCirRevision;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task<IList<CirRevisionDetails>> GetAllCirsRevisionHistory(long turbineNumber)
        {
            try
            {
                string blobType = "RevisionHistory";
                List<CirRevisionDetails> lstCirRevision = new List<CirRevisionDetails>();
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var cirList = await container.ListBlobsSegmentedAsync($"{turbineNumber}/", blobContinuationToken);
                    foreach (var cir in cirList.Results)
                    {
                        var results = await container.ListBlobsSegmentedAsync(cir.Uri.Segments[2].ToString() + cir.Uri.Segments[3].ToString() + blobType + "/", blobContinuationToken);
                        var listCirRevisions = results.Results.OfType<CloudBlob>().OrderByDescending(b => b.Properties.LastModified).Take(1);
                        blobContinuationToken = results.ContinuationToken;
                        foreach (CloudBlob item in listCirRevisions)
                        {
                            var ab = item.Properties.LastModified.ToString();
                            CloudBlockBlob blob = (CloudBlockBlob)item;
                            var sasBlobUri = GetByBlobName(blob.Name);
                            blob = new CloudBlockBlob(sasBlobUri);
                            var revHist = JsonConvert.DeserializeObject<CirRevisionDetails>(blob.DownloadText());
                            revHist.CirSubmissionData.Schema = "";
                            lstCirRevision.Add(revHist);
                        }
                    }
                } while (blobContinuationToken != null);
                return lstCirRevision;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task InsertRevisionHistory(CirSubmissionData cir)
        {
            try
            {
                string dataType = "CIR", blobType = "RevisionHistory", contentType = "json";
                //checked in directory for multiple storages
                if (!(container.GetDirectoryReference($"{cir.Data.txtTurbineNumber}/{dataType}/{cir.Id}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(cir.Id);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }
                //end
                var guidKey = GetKey(container);
                var binaryDataFileName = $"{cir.Data.txtTurbineNumber}/{dataType}/{cir.Id}/{blobType}/{guidKey}.{contentType}";
                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                binaryDataBlockBlob.Properties.ContentType = contentType;
                var revision = new CirRevisionDetails
                {
                    CirSubmissionData = cir
                };
                revision.Id = guidKey;
                revision.CirSubmissionData.Schema = "";
                using (var ms = new MemoryStream())
                {
                    LoadStreamWithJson(ms, revision);
                    await binaryDataBlockBlob.UploadFromStreamAsync(ms);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadStreamWithJson(Stream ms, CirRevisionDetails revision)
        {
            var json = JsonConvert.SerializeObject(revision);
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
        }

        protected virtual CloudBlockBlob InsertBlobAsText(T blobData)
        {
            try
            {
                string dataType = "CIR", blobType = "Images";
                //checked the directory for multiple storages
                if (!(container.GetDirectoryReference($"{blobData.TurbineNumber}/{dataType}/{blobData.CirId}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(blobData.CirId);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }
                //end
                if (string.IsNullOrEmpty(blobData.BlobGuid))
                {
                    blobData.BlobGuid = GetKey(container);
                }
                var binaryDataFileName = $"{blobData.TurbineNumber}/{dataType}/{blobData.CirId}/{blobType}/{blobData.BlobGuid}.{blobData.BinaryContentType}";
                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                binaryDataBlockBlob.UploadText(blobData.BinaryData);

                return binaryDataBlockBlob;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual CloudBlockBlob InsertBlobAsByteArray(T blobData)
        {
            try
            {
                string dataType = "CIR", blobType = "Images";
                //checked the directory for multiple storages
                if (!(container.GetDirectoryReference($"{blobData.TurbineNumber}/{dataType}/{blobData.CirId}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(blobData.CirId);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    //override container
                    container = blobClient.GetContainerReference(containername);
                }
                //end
                if (string.IsNullOrEmpty(blobData.BlobGuid))
                {
                    blobData.BlobGuid = GetKey(container);
                }
                byte[] blobBytes = Convert.FromBase64String(blobData.BinaryData);
                var directoryName = $"{blobData.TurbineNumber}/{dataType}/{blobData.CirId}/{blobType}/{blobData.BlobGuid}.{blobData.ContentType}";
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(directoryName);
                blockBlob.UploadFromByteArray(blobBytes, 0, blobBytes.Length);
                return blockBlob;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task DeleteBlob(string url, string binaryDataUrl)
        {
            try
            {
                if (container.Exists())
                {
                    CloudBlockBlob Blob = new CloudBlockBlob(new Uri(url));
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(Blob.Name);
                    if (blockBlob.Exists())
                    {
                        await blockBlob.FetchAttributesAsync();
                        // await blockBlob.DeleteIfExistsAsync();
                    }

                    CloudBlockBlob binaryBlob = new CloudBlockBlob(new Uri(binaryDataUrl));
                    CloudBlockBlob binaryblockBlob = container.GetBlockBlobReference(binaryBlob.Name);
                    if (binaryblockBlob.Exists())
                    {
                        // await binaryblockBlob.DeleteIfExistsAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void DeleteBlobSync(string url, string binaryDataUrl)
        {
            try
            {
                if (container.Exists())
                {
                    CloudBlockBlob Blob = new CloudBlockBlob(new Uri(url));
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(Blob.Name);
                    if (blockBlob.Exists())
                    {
                        //   blockBlob.DeleteIfExists();
                    }

                    CloudBlockBlob binaryBlob = new CloudBlockBlob(new Uri(binaryDataUrl));
                    CloudBlockBlob binaryblockBlob = container.GetBlockBlobReference(binaryBlob.Name);
                    if (binaryblockBlob.Exists())
                    {
                        // binaryblockBlob.DeleteIfExists();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task DeleteAll(string cirID)
        {
            try
            {
                List<Uri> allBlobs = new List<Uri>();
                foreach (IListBlobItem item in container.ListBlobs())
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        await blob.FetchAttributesAsync();
                        if (blob.Metadata["cirID"] == cirID)
                        {
                            // await blob.DeleteIfExistsAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetKey(CloudBlobContainer container)
        {
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(key);
            return (!blockBlob.Exists()) ? key : GetKey(container);
        }

        private string GetBlobSASUri(string blobName)
        {
            string sasBlobToken = string.Empty;
            switch (blobName.ToString())
            {
                case "cirprodblobstorage.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken0"];
                    break;
                case "cirprodblobstorage1.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken1"]; ;
                    break;
                case "cirprodblobstorage2.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken2"]; ;
                    break;
                case "cirprodblobstorage3.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken3"]; ;
                    break;
                case "cirprodblobstorage4.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken4"]; ;
                    break;
                case "cirprodblobstorage5.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken5"]; ;
                    break;
                case "cirprodblobstorage6.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken6"]; ;
                    break;
                case "cirprodblobstorage7.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken7"]; ;
                    break;
                case "cirprodblobstorage8.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken8"]; ;
                    break;
                case "cirprodblobstorage9.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken9"]; ;
                    break;
                case "cirprodblobstorage10.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken10"]; ;
                    break;
                case "cirprodblobstorage11.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken11"]; ;
                    break;
                case "cirprodblobstorage12.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken12"]; ;
                    break;
                case "cirprodblobstorage13.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken13"]; ;
                    break;
                case "cirprodblobstorage14.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken14"]; ;
                    break;
                case "cirprodblobstorage15.blob.core.windows.net":
                    sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken15"]; ;
                    break;
                default:
                    break;
            }
            return sasBlobToken;
        }
    }
}

