using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Helpers;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Configuration;
using System;

namespace Cir.Data.Access.DataAccess
{
    internal class CirSyncLogRepository : ICirSyncLogRepository
    {
        private readonly DataRepositoryConfig _config;
        private readonly BaseRepository _baseRepo;
        public string _cirCommonnBrandCollectionName = ConfigurationManager.AppSettings["CirCommonBrandCollectionName"];
        public CirSyncLogRepository(DataRepositoryConfig config, BaseRepository baseRepo)
        {
            _config = config;
            _baseRepo = baseRepo;
        }

        public CirSubmissionData Get(string reportId)
        {
            try
            {
                return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                        UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                        new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                    .Where(f => f.Id == reportId).AsEnumerable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CirSubmissionData GetByCirId(long cirId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true, PartitionKey = new PartitionKey(CirSubmissionDataDynamicRepository.getPartition(cirId)) })
                .Where(x => x.CirId == cirId).AsEnumerable().FirstOrDefault();
        }

        public IEnumerable<CirSubmissionData> GetAllRelatedToUser(string userName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .WhereIsRelatedToUser(userName)
                .AsEnumerable();
        }


        public IEnumerable<CirSubmissionData> GetAllMainCollectionCirRelatedToUser(string userName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirCommonnBrandCollectionName),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .WhereIsCreatedUser(userName)
                .AsEnumerable();
        }


        public IEnumerable<CirSubmissionData> GetAllRelatedToUserForSync(string userName)
        {
            string queryString = string.Format("SELECT * FROM c where c.data != null AND (c.createdBy = \"{0}\" OR c.modifiedBy = \"{0}\" OR c.lockedBy = \"{0}\" OR c.delegatedTo = \"{0}\" OR c.delegatedBy = \"{0}\") AND (c.statusChangedBy != \"{0}\" OR c.createdBy = \"{0}\" OR c.modifiedBy = \"{0}\")", userName);
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                queryString, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsEnumerable();
        }

        public long Upsert(CirSubmissionData report)
        {
            try
            {
                report.SqlProcessStatus = report.SqlProcessStatus == null ? CirSubmissionDataDynamicRepository.SqlNotTransferred : report.SqlProcessStatus;
                UpsertReport(report).Wait();
                return report.CirId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long UpsertState(CirSubmissionData report)
        {
            UpsertReport(report).Wait();

            return report.CirId;
        }
        public void Delete(CirSubmissionData report)
        {
            report.State = CirState.Removed;

            DeleteReport(report).Wait();
        }

        public void Unlock(CirSubmissionData report)
        {
            report.LockedBy = string.Empty;

            UpsertReport(report).Wait();
        }

        public IEnumerable<CirSubmissionData> GetAllByIds(List<string> ids)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId),
                _baseRepo.GenerateQueryWithListFilterOnStringProperty("c.id", ids/*, "partition10"*/),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsEnumerable();
        }
        public IEnumerable<CirSubmissionData> MainCollctionGetAllByIds(List<string> ids)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirCommonnBrandCollectionName),
                _baseRepo.GenerateQueryWithListFilterOnStringProperty("c.id", ids/*, "partition10"*/),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsEnumerable();
        }
        /// <summary>
        /// Added the logic to check whether cir already exist in the CirSyncLog collection or not and insert the CIR accordingly.
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private async Task UpsertReport(CirSubmissionData report)
        {
            try
            {
                await _baseRepo.DocumentClient
                .UpsertDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _config.CollectionId), report)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task DeleteReport(CirSubmissionData report)
        {
            await _baseRepo.DocumentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_config.DatabaseId, _config.CollectionId, report.Id),
                    new RequestOptions { PartitionKey = new PartitionKey(keyValue: ((CirSubmissionData)(dynamic)report).Partition) })
                .ConfigureAwait(false);
        }
    }
}
