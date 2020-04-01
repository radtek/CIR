using System;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Cir.Data.Access.DataAccess
{
    internal class CirImageStorageRepository : BlobStorageRepository<ImageDataModel>, ICirImageStorageRepository
    {
        private const int _defaultWidth = 1024;

        public CirImageStorageRepository(BlobStorageConfig config) : base(config) { }

        public string GetBlobUriByImageUrl(string imageUrl)
        {
            try
            {
                return GetByUrl(imageUrl).AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DownloadImageContent(string imageUrl)
        {
            return GetBlobTextByUrl(imageUrl);
        }

        public async Task<List<Uri>> GetAllBlobsUriByCirID(string cirID)
        {
            try
            {
                return await GetByCirID(cirID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddRevisionHistory(CirSubmissionData cir)
        {
            try
            {
                await InsertRevisionHistory(cir);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CirRevisionDetails> GetRevisionHistoryByCirId(long turbineNumber, string cirGUID)
        {
            try
            {
                return GetCirRevisionHistory(turbineNumber, cirGUID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<CirRevisionDetails>> GetRevHistByTurbineNo(long turbineNumber)
        {
            try
            {
                return await GetAllCirsRevisionHistory(turbineNumber);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ImageDataModel Add(ImageDataModel imgData)
        {
            try
            {
                var imgDataString = imgData.BinaryData;
                var binaryDataStartIndex = imgDataString.IndexOf(",") + 1;
                var lastIndex = imgDataString.Length - (imgDataString.IndexOf(",") + 1);

                imgDataString = imgDataString.Substring(binaryDataStartIndex, lastIndex);
                imgData.BinaryData = imgDataString;

                var blobkBlobByte = InsertBlobAsByteArray(imgData);
                imgData.Url = blobkBlobByte.Uri.AbsoluteUri;

                var blockBlobBynaryData = InsertBlobAsText(imgData);
                imgData.BinaryDataUrl = blockBlobBynaryData.Uri.AbsoluteUri;
                imgData.BinaryData = "";
                return imgData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteImageData(ImageDataModel imageReference)
        {
            try
            {
                await DeleteBlob(imageReference.Url, imageReference.BinaryDataUrl);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAllImages(string cirID)
        {
            try
            {
                await DeleteAll(cirID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAllImagesByURL(IList<ImageDataModel> imageReference)
        {
            try
            {
                foreach(ImageDataModel img in imageReference)
                {
                    DeleteBlobSync(img.Url, img.BinaryDataUrl);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}