using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public interface IMetadataGetter
    {
        bool TryGetBool(IDictionary<string, string> metadata, string name, out bool result);
        bool TryGetDateTime(IDictionary<string, string> metadata, string name, out DateTime dateTime);
        bool TryGetIntList(IDictionary<string, string> metadata, string name, out IList<int> result);
    }
}
