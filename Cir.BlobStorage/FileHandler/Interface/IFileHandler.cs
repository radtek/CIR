using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.BlobStorage.FileHandlerNS
{
    public interface IFileHandler
    {
        Task HandleAsync(IReadOnlyCollection<IFile> files);
    }
}
