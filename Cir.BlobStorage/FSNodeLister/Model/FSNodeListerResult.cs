using System.Collections.Generic;

namespace Cir.BlobStorage
{
    public class FSNodeListerResult
    {
        public IContinuationToken ContinuationToken { get; set; }
        public IReadOnlyList<IFSNode> Result { get; set; }
    }
}
