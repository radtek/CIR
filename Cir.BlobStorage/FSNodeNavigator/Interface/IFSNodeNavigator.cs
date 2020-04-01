using Cir.BlobStorage.FileHandlerNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public interface IFSNodeNavigator
    {
        Task RunAsync(string pattern, int groupBy, IFileHandler fileHandler);
    }
}
