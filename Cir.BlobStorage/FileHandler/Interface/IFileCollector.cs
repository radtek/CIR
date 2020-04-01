using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.BlobStorage.FileHandlerNS
{
    public interface IFileCollector: IFileHandler
    {
        IList<IFile> Files { get; }
    }
}
