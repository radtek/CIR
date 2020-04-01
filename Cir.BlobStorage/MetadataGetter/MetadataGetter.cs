using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public class MetadataGetter : IMetadataGetter
    {
        public bool TryGetBool(IDictionary<string, string> metadata, string name, out bool result)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (name == null)
                throw new ArgumentNullException("name");

            if (metadata.TryGetValue(name, out var value) &&
                bool.TryParse(value, out result))
            {
                return true;
            }

            result = default(bool);
            return false;
        }

        public bool TryGetDateTime(IDictionary<string, string> metadata, string name, out DateTime result)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (name == null)
                throw new ArgumentNullException("name");

            if (metadata.TryGetValue(name, out var value) &&
                DateTime.TryParse(value, out result))
            {
                return true;
            }

            result = default(DateTime);
            return false;
        }

        public bool TryGetIntList(IDictionary<string, string> metadata, string name, out IList<int> result)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (name == null)
                throw new ArgumentNullException("name");

            if (metadata.TryGetValue(name, out string value))
            {
                try
                {
                    result = value
                        .Split(',')
                        .Select(int.Parse)
                        .ToList();
                    return true;
                }
                catch
                {}
            }

            result = null;
            return false;
        }
    }
}
