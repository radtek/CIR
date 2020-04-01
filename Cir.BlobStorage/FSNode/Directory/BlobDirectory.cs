using Microsoft.Azure.Storage.Blob;

namespace Cir.BlobStorage
{
    public class BlobDirectory: IDirectory
    {
        private readonly CloudBlobDirectory directory;

        public BlobDirectory(CloudBlobDirectory directory)
        {
            this.directory = directory;
        }

        public string FullPath => directory.Prefix;
    }
}
