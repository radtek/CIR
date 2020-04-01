using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public interface IFileFactory
    {
        IFile CreateFile(string path);
    }
}
