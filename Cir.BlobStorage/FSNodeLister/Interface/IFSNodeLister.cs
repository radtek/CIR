using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public interface IFSNodeLister
    {
        Task<FSNodeListerResult> ListAsync(string prefix, IContinuationToken continuationToken);
    }
}
