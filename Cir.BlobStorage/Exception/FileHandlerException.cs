using System;
using System.Collections.Generic;

namespace Cir.BlobStorage
{
    public class FileHandlerException: Exception
    {
        public IReadOnlyCollection<IFile> Files { get; set; }
        public IFile File { get; set; }
        public FileHandlerException(IReadOnlyCollection<IFile> files, IFile file, Exception e)
            : base($"An exception occured when handling file {file.FullPath}.", e)
        {
            Files = files;
            File = file;
        }
        public FileHandlerException(IReadOnlyCollection<IFile> files, Exception e)
            : base($"An exception occured when processing multiple files.", e)
        {
            Files = files;
        }
    }
}
