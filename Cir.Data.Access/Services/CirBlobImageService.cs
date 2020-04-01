using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    internal class CirBlobImageService : ICirBlobImageService
    {
        public string TableName => "CirImageThumbnails";

        private readonly ICirImageStorageRepository _cirImageStorageRepository;
        private readonly ICirSubmissionService _cirSubmissionService;

        public CirBlobImageService(ICirImageStorageRepository cirBlobStorageRepository,
            ICirSubmissionService cirSubmissionService)
        {
            _cirImageStorageRepository = cirBlobStorageRepository;
            _cirSubmissionService = cirSubmissionService;
        }

        public string Get(string imageUrl)
        {
            return _cirImageStorageRepository.GetBlobUriByImageUrl(imageUrl);
        }

        public string GetBlobContentByUrl(string imageUrl)
        {
            return _cirImageStorageRepository.DownloadImageContent(imageUrl);
        }

        public async Task<List<Uri>> GetAll(string cirID)
        {
            return await _cirImageStorageRepository.GetAllBlobsUriByCirID(cirID);
        }

        public ImageDataModel Add(ImageDataModel imgData)
        {
            try
            {
                var cir = _cirSubmissionService.GetFromCirSyncLog(imgData.CirId);

                if (cir.ImageReferences == null)
                {
                    cir.ImageReferences = new List<ImageDataModel>();
                }

                if (cir.ImageReferences.Any(x => x.ImageId == imgData.ImageId))
                {
                    imgData.BinaryData = string.Empty;
                    return cir.ImageReferences.First(x => x.ImageId == imgData.ImageId);
                }

                var uploadedImg = _cirImageStorageRepository.Add(imgData);

                imgData.BinaryData = string.Empty;

                cir.ImageReferences.Add(uploadedImg);

                _cirSubmissionService.UpdateSyncLogNoValidate(cir);
                return imgData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteBlob(ImageDataModel imageData)
        {
            await _cirImageStorageRepository.DeleteImageData(imageData);

            var cir = _cirSubmissionService.GetFromCirSyncLog(imageData.CirId);

            var cirImageReference = cir.ImageReferences.FirstOrDefault(x => x.ImageId == imageData.ImageId);
            cir.ImageReferences.Remove(cirImageReference);
            cir.ModifiedOn = DateTime.UtcNow;

            _cirSubmissionService.UpdateSyncLogNoValidate(cir);
        }

        public async Task DeleteAllBlob(string cirID)
        {
            await _cirImageStorageRepository.DeleteAllImages(cirID);
        }

        public void DeleteAllBlobByURL(IList<ImageDataModel> imageData)
        {
            _cirImageStorageRepository.DeleteAllImagesByURL(imageData);
        }

        public async Task<IList<object>> GetTableData(IList<CirSubmissionData> cirSubmissionData)
        {
            var data = new List<object>();

            var imageReferences = cirSubmissionData
                    .Where(r => r.State == CirState.Draft && r.ImageReferences != null)
                    .SelectMany(x => x.ImageReferences);
            var tasks = new List<Task>();
            var imageBinaryList = new List<dynamic>();
            foreach (var imageReference in imageReferences)
            {
                tasks.Add(Task.Run(() =>
                {

                    var imageTasks = new List<Task>();
                    var imageBinary = _cirImageStorageRepository.DownloadImageContent(imageReference.BinaryDataUrl);

                    imageBinaryList.Add(new { imageReference.CirId, imageReference.ImageId, BinaryData = imageBinary });

                }));
            }

            Task.WaitAll(tasks.ToArray());

            var grouppedImages = imageBinaryList.GroupBy(x => x.CirId);

            foreach (var group in grouppedImages)
            {
                data.Add(new
                {
                    CirId = group.Key,
                    ImageThumbnails = group.Select(x => new { x.ImageId, x.BinaryData })
                });
            }

            return data;
        }
    }
}