using Cir.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    public interface ICirBlobImageService : IUserTable
    {
        string Get(string imageUrl);
        string GetBlobContentByUrl(string blobUrl);
        Task<List<Uri>> GetAll(string cirID);
        ImageDataModel Add(ImageDataModel imgData);
        Task DeleteBlob(ImageDataModel imageReference);
        Task DeleteAllBlob(string cirID);
        void DeleteAllBlobByURL(IList<ImageDataModel> imageReference);
    }
}
