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
        string GetBlobUriByImageUrl(string imageUrl);
        string DownloadImageContent(string imageUrl);
        Task<List<Uri>> GetAllBlobsUriByCirID(string cirID);
        ImageDataModel Add(ImageDataModel imgData);
        Task DeleteImageData(ImageDataModel imageReference);
        Task DeleteAllImages(string cirID);
        void DeleteAllImagesByURL(IList<ImageDataModel> imageReference);
        Task AddRevisionHistory(CirSubmissionData cir);
        List<CirRevisionDetails> GetRevisionHistoryByCirId(long turbineNumber, string cirGUID);
        Task<IList<CirRevisionDetails>> GetRevHistByTurbineNo(long turbineNumber);
    }
}
