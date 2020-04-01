using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public interface IFile: IFSNode
    {
        string Text { get; }
        byte[] Bytes { get; }
        string Path { get; }
        string Uri { get; }
        IDictionary<string, string> Metadata { get; }
        FileProperties Properties { get; }
        Task GetTextAsync();
        Task GetMetadataAsync();
        Task GetBytesAsync();
        Task WriteTextAsync(string text);
        Task WriteBytesAsync(byte[] bytes);
        Task WriteStreamAsync(Stream stream);
        Task<bool> DeleteFile();
    }
}
