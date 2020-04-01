using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    public interface ICirBlobStorageService
    {
        Task<Uri> Get(string fileName);
        Task<List<Uri>> GetAll(string cirId);
        Task<ImageDataList> Add(ImageDataList imgData);
        Task DeleteBlob(string fileName);
        Task DeleteAllBlob(string cirID);
    }
}
