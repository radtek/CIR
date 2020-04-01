using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal class CirSubmissionHistoricDataRepository : ICirSubmissionHistoricDataRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;
        private readonly ICirImageStorageRepository _cirImageStorageRepository;

        public CirSubmissionHistoricDataRepository(DataRepositoryConfig config, BaseRepository baseRepo, CirImageStorageRepository cirImageStorageRepository)
        {
            _config = config;
            _baseRepo = baseRepo;
            _cirImageStorageRepository = cirImageStorageRepository;
        }

        public void StoreRevision(CirSubmissionData cir)
        {
            //    var revision = new CirRevisionDetails
            //    {
            //        CirSubmissionData = cir
            //    };

            //    _baseRepo.Insert(revision, _config.DatabaseId, _config.CollectionId).Wait();
            _cirImageStorageRepository.AddRevisionHistory(cir);
        }

        public IEnumerable<CirRevisionDetails> GetCirRevisionItems(long turbineNumber, string cirGUID)
        {
            //return _baseRepo.DocumentClient
            //    .CreateDocumentQuery<CirRevisionDetails>(
            //        UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
            //        new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
            //    .Where(x => x.CirSubmissionData.CirId == cirId)
            //    .Select(x => new CirRevisionDetailsItem
            //    {
            //        CirId = x.CirSubmissionData.CirId,
            //        Revision = x.CirSubmissionData.Revision,
            //        CirGuid = x.CirSubmissionData.Id,
            //        ModifiedBy = x.CirSubmissionData.ModifiedBy,
            //        ModifiedOn = x.CirSubmissionData.ModifiedOn,
            //        Id = x.Id,
            //        CirCollectionName = x.CirSubmissionData.CirCollectionName
            //    })
            //    .AsEnumerable()
            //    .OrderByDescending(x => x.Revision);
           return _cirImageStorageRepository.GetRevisionHistoryByCirId(turbineNumber, cirGUID).AsEnumerable();
        }

        public CirRevisionDetails GetCirRevision(string cirRevisionId)
        {
            return _baseRepo.DocumentClient
                .CreateDocumentQuery<CirRevisionDetails>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions {MaxItemCount = 1, EnableCrossPartitionQuery = true})
                .Where(x => x.Id == cirRevisionId).AsEnumerable().First();
        }

        public async Task<IList<CirRevisionDetails>> GetAllCirsRevisionItems(long turbineNumber)
        {
            return await _cirImageStorageRepository.GetRevHistByTurbineNo(turbineNumber);
        }

        public CirSubmissionData ValidateCirImgReference(CirSubmissionData report)
        {
            if (report != null && report.ImageReferences != null)
            {
                var unsycedImages = report.ImageReferences.Where(x => x.BinaryData != "").ToList();
                if (unsycedImages.Count > 0)
                {
                    for (int i = 0; i < unsycedImages.Count; i++)
                    {
                        if (unsycedImages[i].BinaryData != null)
                        {
                            var index = report.ImageReferences.IndexOf(unsycedImages[i]);
                            report.ImageReferences[index] = _cirImageStorageRepository.Add(unsycedImages[i]);
                        }
                    }
                }
            }
            return report;
        }
    }
}
