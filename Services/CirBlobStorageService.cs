using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    internal class CirBlobStorageService : ICirBlobStorageService
    {
        private ICirImageStorageRepository _cirBlobStorageRepository;

        public CirBlobStorageService(ICirImageStorageRepository cirBlobStorageRepository)
        {
            _cirBlobStorageRepository = cirBlobStorageRepository;
        }

        public async Task<Uri> Get(string fileName)
        {
            return await _cirBlobStorageRepository.GetBlobsUriByImageName(fileName);
        }

        public async Task<List<Uri>> GetAll(string cirId)
        {
            return await _cirBlobStorageRepository.GetAllBlobsUriByCirID(cirId);
        }

        public async Task<ImageDataList> Add(ImageDataList imgData)
        {
           return await _cirBlobStorageRepository.Add(imgData);
        }

        public async Task DeleteBlob(string fileName)
        {
            await _cirBlobStorageRepository.DeleteImageData(fileName);
        }

        public async Task DeleteAllBlob(string cirID)
        {
            await _cirBlobStorageRepository.DeleteAllImages(cirID);
        }
    }
}