using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cir.BlobStorage
{
    public class BlobFile: IFile
    {
        private CloudBlockBlob file;
        public string Text { get; private set; }
        public byte[] Bytes { get; private set; }
        public string Path { get; }
        public string Uri {
            get
            {
                return file.Uri.ToString();
            }
        }
        public IDictionary<string, string> Metadata { get; private set; }
        public FileProperties Properties { get; private set; }

        public BlobFile(CloudBlockBlob file)
        {
            this.file = file;
        }

        public string FullPath => file.Name;

        public async Task GetTextAsync()
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                Text = await file.DownloadTextAsync();
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
        }

        public async Task GetBytesAsync()
        {
            var stream = new MemoryStream();
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                await file.DownloadToStreamAsync(stream).ConfigureAwait(false);
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
            Bytes = stream.ToArray();
        }

        public async Task WriteTextAsync(string text)
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                await file.UploadTextAsync(text);
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
        }

        public async Task WriteBytesAsync(byte[] bytes)
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                await file.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
        }

        public async Task WriteStreamAsync(Stream stream)
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                await file.UploadFromStreamAsync(stream);
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
            
        }

        public async Task GetMetadataAsync()
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                await file.FetchAttributesAsync();
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
            Metadata = new Dictionary<string, string>(
                file.Metadata,
                StringComparer.CurrentCultureIgnoreCase);
            Properties = new FileProperties
            {
                LastModified = file.Properties.LastModified
            };
        }

        public async Task<bool> DeleteFile()
        {
            await ConnectionPool.Semaphore.WaitAsync();
            try
            {
                return await file.DeleteIfExistsAsync();
            }
            finally
            {
                ConnectionPool.Semaphore.Release();
            }
        }
    }
}
