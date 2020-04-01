using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public class BlobFileFactory : IFileFactory
    {
        private readonly CloudBlobContainer container;
        public BlobFileFactory()
        {
            var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureStorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(Environment.GetEnvironmentVariable("AzureStorageContainerName"));
        }
        public IFile CreateFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(path);
            return new BlobFile(cloudBlockBlob);
        }
    }
}
