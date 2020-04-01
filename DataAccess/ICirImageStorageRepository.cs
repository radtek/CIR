using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal interface ICirImageStorageRepository
    {
        Task<Uri> GetBlobsUriByImageName(string fileName);
        Task<List<Uri>> GetAllBlobsUriByCirID(string cirID);
        Task<ImageDataList> Add(ImageDataList imgData);
        Task DeleteImageData(string fileName);
        Task DeleteAllImages(string cirID);
    }
}
