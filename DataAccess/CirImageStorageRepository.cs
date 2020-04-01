using System;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal class CirImageStorageRepository : BlobStorageRepository<ImageDataModel>, ICirImageStorageRepository
    {
        public CirImageStorageRepository(BlobStorageConfig config) : base (config) { }

        public async Task<Uri> GetBlobsUriByImageName(string fileName)
        {
            try
            {
                return await GetByImageName(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<ImageDataList> Add(ImageDataList imgDataList)
        {
            try
            {
                foreach (var imgData in imgDataList.imageData)
                {
                    var blockBlob = await InsertBlob(imgData);
                    imgData.BinaryData = blockBlob.Metadata["binaryDataURL"];
                    imgData.ImageUrl = blockBlob.Uri.AbsoluteUri;
                    imgData.FileName = blockBlob.Name;
                }

                return imgDataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteImageData(string fileName)
        {
            try
            {
                await DeleteBlob(fileName);
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
    }
}