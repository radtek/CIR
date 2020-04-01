using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public class BlobNodeLister : IFSNodeLister
    {
        private readonly int blobStorageNumber;
        private readonly string blobStorageConnectionString;
        private readonly string blobStorageContainerName;
        private readonly CloudBlobContainer container;

        public BlobNodeLister(int blobStorageNumber)
        {
            blobStorageConnectionString = Environment.GetEnvironmentVariable("BlobStorage"+blobStorageNumber);
            blobStorageContainerName = Environment.GetEnvironmentVariable("AzureStorageContainerName");

            var storageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(blobStorageContainerName);
            this.blobStorageNumber = blobStorageNumber;
        }

        public async Task<FSNodeListerResult> ListAsync(string prefix, IContinuationToken continuationToken)
        {
            Console.WriteLine(blobStorageNumber + ": " + prefix);
            Microsoft.Azure.Storage.Blob.BlobContinuationToken token = null;

            if (continuationToken != null)
            {
                token = ((BlobContinuationToken)continuationToken).Token;
            }

            await ConnectionPool.Semaphore.WaitAsync();
            BlobResultSegment segment = null;
            try
            {
                segment = await container.ListBlobsSegmentedAsync(
                            prefix,
                            false,
                            BlobListingDetails.None,
                            1000,
                            token,
                            null,
                            null);
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }

           
            var fsNodes = new List<IFSNode>();

            fsNodes.AddRange(
                segment.Results
                .OfType<CloudBlobDirectory>()
                .Select(d => new BlobDirectory(d)));

            fsNodes.AddRange(
                segment.Results
                .OfType<CloudBlockBlob>()
                .Select(f => new BlobFile(f)));

            var result = new FSNodeListerResult();
            if (segment.ContinuationToken != null)
            {
                result.ContinuationToken = new BlobContinuationToken(segment.ContinuationToken);
            }
            
            result.Result = fsNodes;

            return result;
        }
    }
}
