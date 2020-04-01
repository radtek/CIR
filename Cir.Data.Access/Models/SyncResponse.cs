using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
    public class SyncResponse
    {
        public IEnumerable<string> ResendCirs { get; set; }
        public IEnumerable<CirSubmissionData> UpdateClientCirs { get; set; }
        public IEnumerable<string> RemoveClientCirs  { get; set; }
    }
}
