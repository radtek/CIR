using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.BlobStorage.FileHandlerNS
{
    public class AggregateFileHandler : IFileCollector
    {
        private readonly List<IFile> _files = new List<IFile>();
        public IList<IFile> Files { get { return _files; } }
        public Task HandleAsync(IReadOnlyCollection<IFile> files)
        {
            _files.AddRange(files);
            return Task.CompletedTask;
        }
    }
}
