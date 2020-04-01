using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class GetBlobSasUri
    {
        public static Uri GetByBlobName(string blobName, CloudBlobContainer container)
        {
            try
            {
                Uri sasBlobUri = GetBlobSASUri(blobName, container, "ReadBlob");
                return sasBlobUri;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Uri GetBlobSASUri(string blobName, CloudBlobContainer container, string policyName)
        {
            try
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                var storedPolicy = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                    Permissions = SharedAccessBlobPermissions.Read
                };
                var sasBlobToken = blockBlob.GetSharedAccessSignature(storedPolicy);
                Uri blobUri = new Uri(blockBlob.Uri + sasBlobToken);
                return blobUri;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CloudBlockBlob GetBlockBlob(string blobName, CloudBlobContainer container)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            return blockBlob;
        }

        public static CloudBlockBlob GetBlockBlobByURL(string url, CloudBlobContainer container)
        {
            CloudBlockBlob Blob = new CloudBlockBlob(new Uri(url));
            var blockBlob = GetBlockBlob(Blob.Name, container);
            return blockBlob;
        }
    }
}
