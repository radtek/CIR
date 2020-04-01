using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal abstract class BlobStorageRepository<T> where T : ICirBlobStorageData
    {
        private CloudBlobClient blobClient;
        CloudBlobContainer container;
        private static readonly string containerName = "cirtestcontainer1";

        public BlobStorageRepository(BlobStorageConfig config)
        {
            var storageAccount = CloudStorageAccount.Parse(config.AzureStorageConnectionString);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        protected virtual async Task<Uri> GetByImageName(string fileName)
        {
            try
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                return blockBlob.Uri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        protected virtual async Task<CloudBlockBlob> InsertBlob(T blobData)
        {
            try
            {
                string imageName = string.Empty;
                if (blobData.FileName == null)
                {
                    imageName = GetKey(container, "jpeg");
                }
                else
                {
                    imageName = blobData.FileName;
                }
                string binaryDataFileName = imageName.Replace("jpeg","txt"); 
                string imgDataString = blobData.BinaryData;
                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                await binaryDataBlockBlob.UploadTextAsync(imgDataString);  
                int index = imgDataString.IndexOf(",") + 1,
                    lastIndex = imgDataString.Length - (imgDataString.IndexOf(",") + 1);
                imgDataString = imgDataString.Substring(index, lastIndex);
                byte[] blobBytes = Convert.FromBase64String(imgDataString);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
                blockBlob.Properties.ContentType = blobData.ContentType;
                blockBlob.Metadata.Add("cirID", blobData.CirID);
                blockBlob.Metadata.Add("binaryDataURL", binaryDataBlockBlob.Uri.AbsoluteUri);
                await blockBlob.UploadFromByteArrayAsync(blobBytes, 0, blobBytes.Length);

                return blockBlob;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual async Task DeleteBlob(string blobName)
        {
            try
            {
                if (container.Exists())
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                    if (blockBlob.Exists())
                    {
                       await blockBlob.DeleteIfExistsAsync();
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
                            await blob.DeleteIfExistsAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetKey(CloudBlobContainer container, string ext)
        {
            string key = Guid.NewGuid().ToString();
            key = key + "." + ext;
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(key);
            return (!blockBlob.Exists()) ? key : GetKey(container, ext);
        }
    }
}
