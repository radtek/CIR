using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal abstract class BlobPDfStorageRepository<T> where T : ICirPDFBlobStorageData
    {
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;

        //Added for multiple storage
        private string containername;

        public BlobPDfStorageRepository(BlobStorageConfig config)
        {
            var storageAccount = CloudStorageAccount.Parse(config.AzureStorageConnectionString);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(config.AzureStorageContainerName);
            //container.CreateIfNotExists();
            //Added for multiple storages
            containername = config.AzureStorageContainerName;
        }

        /// <summary>
        /// Insert blob PDF as a Byte Array
        /// </summary>
        /// <param name="blobData"></param>
        /// <returns></returns>
        protected virtual CloudBlockBlob InsertBlobPdfAsByteArray(T blobData)
        {
            try
            {
                string dataType = "CIR", blobType = "PDF";
                
                if (!(container.GetDirectoryReference($"{blobData.TurbineNumber}/{dataType}/{blobData.CIRID}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(blobData.CIRID);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }
               
                if (string.IsNullOrEmpty(blobData.BlobGuid))
                {
                    blobData.BlobGuid = GetKey(container);
                }
                byte[] blobBytes = blobData.PDFData;
                var directoryName = $"{blobData.TurbineNumber}/{dataType}/{blobData.CIRID}/{blobType}/{blobData.CIRTemplateGUID}.{blobType}";
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(directoryName);
                blockBlob.Properties.ContentType = "application/pdf";

                blockBlob.Metadata.Add("modified", blobData.Modified);
                blockBlob.Metadata.Add("revision", blobData.Revision);
                blockBlob.UploadFromByteArray(blobBytes, 0, blobBytes.Length);
                return blockBlob;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected byte[] GetPdfBytesFromBlob(long turbineNumber, string cirGUID , int revision , long cirId)
        {
            try
            {
                string blobType = "PDF";
                string dataType = "CIR";
                
                if (!(container.GetDirectoryReference($"{turbineNumber}/{dataType}/{cirGUID}").ListBlobs().Count() > 0))
                {
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(cirGUID);
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(containername);
                }               
                CloudBlobDirectory pdfDirectoryContainer = container.GetDirectoryReference($"{turbineNumber}/{dataType}/{cirGUID}/{blobType}");
                byte[] pdfbytes = new byte[0];
                foreach (var item in pdfDirectoryContainer.ListBlobs())
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        blob = container.GetBlockBlobReference(blob.Name);
                        if (blob.Exists())
                        {
                            blob.FetchAttributes();
                            if (blob.Metadata.ContainsKey("revision") && blob.Metadata["revision"] == revision.ToString())
                            {
                                byte[] byteArray = new byte[blob.Properties.Length];
                                blob.DownloadToByteArray(byteArray, 0);
                                pdfbytes = byteArray;
                            }
                        }
                    }
                }
                return pdfbytes;
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
    }
}

