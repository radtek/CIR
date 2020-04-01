
namespace Cir.BlobStorage
{
    public class BlobContinuationToken: IContinuationToken
    {
        public Microsoft.Azure.Storage.Blob.BlobContinuationToken Token { get; set; }

        public BlobContinuationToken(Microsoft.Azure.Storage.Blob.BlobContinuationToken token)
        {
            Token = token;
        }
    }
}
