using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models;
using Cir.Data.Access.DataAccess;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Configuration;
using System;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.DataAccessDynamic
{
    internal class CirSubmissionDataDynamicRepository : ICirSubmissionDataDynamicRepository
    {
        private readonly BaseRepository _baseRepo;
        private readonly DataRepositoryConfig _config;
        private readonly ICirSubmissionHistoricDataRepository _cirHistoryRepository;
        private readonly SyncServiceClient _serviceClient;
        string _cirBrandCollectionName;
        public string _cirLogCollectionName => "CirUserData";
        public const string SqlNotTransferred = "NotTransferred";
        public string _cirCommonnBrandCollectionName = ConfigurationManager.AppSettings["CirCommonBrandCollectionName"];
        public string _cirSyncLogCollection = ConfigurationManager.AppSettings["CirSyncLogCollection"];
        public string _CirIdCollection = ConfigurationManager.AppSettings["CirIdCollection"];
        public CirSubmissionDataDynamicRepository(DataRepositoryConfig config,
            BaseRepository baseRepo,
            ICirSubmissionHistoricDataRepository cirHistoryRepository)
        {
            _cirHistoryRepository = cirHistoryRepository;
            _config = config;
            _baseRepo = baseRepo;
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public CirSubmissionData Get(string reportId, string cirBrandCollectionName)
        {
            cirBrandCollectionName = _cirCommonnBrandCollectionName;
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, cirBrandCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(f => f.Id == reportId).AsEnumerable().FirstOrDefault();
        }

        public CirSubmissionData GetBySyncCirId(long cirId, string cirBrandCollectionName)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
           UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, cirBrandCollectionName),
           new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = false, PartitionKey = new PartitionKey(CirSubmissionDataDynamicRepository.getPartition(cirId)) })
       .Where(x => x.CirId == cirId).AsEnumerable().FirstOrDefault();
        }
        public CirSubmissionData GetByCirId(long cirId, string cirBrandCollectionName)
        {
            cirBrandCollectionName = _cirCommonnBrandCollectionName;
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, cirBrandCollectionName),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = false, PartitionKey = new PartitionKey(CirSubmissionDataDynamicRepository.getPartition(cirId)) })
                .Where(x => x.CirId == cirId).AsEnumerable().FirstOrDefault();
        }

        public IQueryable<CirSubmissionData> GetAll(string cirBrandCollectionName)
        {
            cirBrandCollectionName = _cirCommonnBrandCollectionName;
            IQueryable<CirSubmissionData> reports = _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, cirBrandCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });

            return reports;
        }

        public List<CirSubmissionData> GetAllRelatedToUser(string userId, string collections)
        {
            var reports = new List<CirSubmissionData>();
            var tasks = new List<Task>();

            userId = userId.ToLower();
            tasks.Add(Task.Run(() =>
            {
                reports.AddRange(_baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                        UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, collections),
                        new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                        .Where(r => (r.ModifiedOn >= DateTime.Now.AddDays(-30))
                         && r.State != CirState.Removed &&
                               (r.ModifiedBy.ToLower() == userId || r.CreatedBy.ToLower() == userId || r.DelegatedTo.ToLower() == userId)).AsEnumerable());
            }));

            Task.WaitAll(tasks.ToArray());
            return reports;
        }

        public List<CirSubmissionData> GetAllBySyncData(List<CirSubmissionSyncData> reportsToSync)
        {
            var reports = new List<CirSubmissionData>();
            var collections = new HashSet<string>();

            reportsToSync.ForEach(r => collections.Add(r.CirCollectionName));
            var tasks = new List<Task>();

            foreach (var collectionName in collections.ToList())
            {
                tasks.Add(Task.Run(() =>
                {
                    var ids = reportsToSync
                        .Where(r => Equals(r.CirCollectionName, collectionName))
                        .Select(r => r.Id)
                        .ToList();

                    reports.AddRange(_baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                        UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, collectionName),
                        _baseRepo.GenerateQueryWithListFilterOnStringProperty("c.id", ids, "partition"),
                        new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }));
                }));
            }

            Task.WaitAll(tasks.ToArray());
            return reports;
        }

        public long Add(CirSubmissionData report, string cirBrandCollectionName)
        {
            report.Revision = 1;
            report.SqlProcessStatus = report.SqlProcessStatus == null ? SqlNotTransferred : report.SqlProcessStatus;

            _cirBrandCollectionName = cirBrandCollectionName;

            Insert(report).Wait();
            _cirHistoryRepository.StoreRevision(report);

            return report.CirId;
        }
        /// <summary>
        /// For SQL to Cosmos data migration
        /// </summary>
        /// <param name="report"></param>
        /// <param name="cirBrandCollectionName"></param>
        /// <returns></returns>
        public long AddForMigration(CirSubmissionData report, string cirBrandCollectionName)
        {
            report.Revision = 1;
            //   report.SqlProcessStatus = SqlNotTransferred;  
            //_cirBrandCollectionName = cirBrandCollectionName;
            //var reportInCosmos = GetByCirId(report.CirId, cirBrandCollectionName);
            //var objCirSubmInSyncLog = GetBySyncCirId(report.CirId, _cirSyncLogCollection);
            //if (objCirSubmInSyncLog != null)
            //{
            //    DeleteDocumentInSyncLog(objCirSubmInSyncLog.Id).Wait();
            //}
            //if (reportInCosmos != null)
            //{
            //    Delete(reportInCosmos.Id, cirBrandCollectionName);
            //}
            //CirIdModel objCirId = new CirIdModel();
            //objCirId.CirBrandCollectionName = report.CirCollectionName ?? _cirCommonnBrandCollectionName;
            //objCirId.CirId = report.CirId;
            //objCirId.Partition = report.Partition ?? "partition";

            //var CirIdModel = _baseRepo.DocumentClient.CreateDocumentQuery<CirIdModel>(
            //          UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _CirIdCollection),
            //          new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
            //      .Where(x => x.CirId == report.CirId).AsEnumerable().FirstOrDefault();

            //if (null == CirIdModel)
            //{
            //    _baseRepo.DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _CirIdCollection), objCirId).ConfigureAwait(false);
            //}

            if (report != null)
            {
                if (report.RevisionHistory == null || (report.RevisionHistory != null && report.RevisionHistory.Count == 0))
                {
                    report.RevisionHistory = new List<RevisionHistory>();
                    report.RevisionHistory.AddRange(AddRevisonHistory(report.CirId));
                }
            }
            //Insert(report).Wait();
            _cirHistoryRepository.StoreRevision(report);
            //if (!Exists(report.CirId, cirBrandCollectionName))
            //{
            //    Insert(report).Wait();
            //    _cirHistoryRepository.StoreRevision(report);
            //}
            //else
            //{
            //    Update(report, cirBrandCollectionName);
            //    _cirHistoryRepository.StoreRevision(report);
            //}

            return report.CirId;
        }
        public List<RevisionHistory> AddRevisonHistory(long CirId)
        {
            List<RevisionHistory> lstRevHistory = new List<RevisionHistory>();
            var rev = _serviceClient.GetCirCommentHistoryByCirId(CirId).ToList();
            foreach (var item in rev)
            {
                RevisionHistory revHistory = new RevisionHistory();
                revHistory.editedBy = item.Initials;
                revHistory.Comments = item.Comment;
                revHistory.editedOn = item.Date;
                lstRevHistory.Add(revHistory);
            }
            return lstRevHistory;

        }
        public void Update(CirSubmissionData report, string cirBrandCollectionName)
        {
            _cirBrandCollectionName = cirBrandCollectionName;

            report.Revision++;
            report.SqlProcessStatus = report.SqlProcessStatus == null ? SqlNotTransferred : report.SqlProcessStatus;

            Replace(report.Id, report).Wait();

            _cirHistoryRepository.StoreRevision(report);
        }
        public void UpdateCir(CirSubmissionData report, string cirBrandCollectionName)
        {
            _cirBrandCollectionName = cirBrandCollectionName;

            report.SqlProcessStatus = report.SqlProcessStatus == null ? SqlNotTransferred : report.SqlProcessStatus;

            Replace(report.Id, report).Wait();
        }
        public void UpdateState(CirSubmissionData report, string cirBrandCollectionName)
        {
            _cirBrandCollectionName = cirBrandCollectionName;

            report.Revision++;

            Replace(report.Id, report).Wait();

            _cirHistoryRepository.StoreRevision(report);
        }
        public void Delete(string reportId, string cirBrandCollectionName)
        {
            _cirBrandCollectionName = cirBrandCollectionName;

            DeleteDocument(reportId).Wait();
        }

        public CirSubmissionData LockCir(long cirId, string cirBrandCollectionName, string lockedBy)
        {
            bool isEdited = true;
            var objCir = GetByCirId(cirId, cirBrandCollectionName);
            if (objCir == null)
            {
                isEdited = false;
                objCir = GetBySyncCirId(cirId, _cirSyncLogCollection);
            }
            objCir.LockedBy = lockedBy;
            if (!isEdited)
            {
                _UpdateCirSyncLog(objCir).Wait();
            }
            else
            {
                Replace(objCir.Id, objCir).Wait();
            }
            return objCir;
        }

        public CirSubmissionData UnlockCir(long cirId, string cirBrandCollectionName)
        {
            var cir = GetByCirId(cirId, cirBrandCollectionName);

            _cirBrandCollectionName = cirBrandCollectionName;
            cir.LockedBy = string.Empty;

            Replace(cir.Id, cir).Wait();

            return cir;
        }
        protected async Task _UpdateCirSyncLog(CirSubmissionData report)
        {
            await _baseRepo.DocumentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_config.DatabaseId, _cirSyncLogCollection, report.Id), report).ConfigureAwait(false);
        }
        public void InsertIntoCirSyncLog(CirSubmissionData report)
        {
            InsertDraftCir(report).Wait();
        }

        protected async Task InsertDraftCir(CirSubmissionData report)
        {
            await _baseRepo.DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirSyncLogCollection), report).ConfigureAwait(false);
        }

        public void DeleteFromCirSyncLog(CirSubmissionData report)
        {
            DeleteDraftCir(report).Wait();
        }

        protected async Task DeleteDraftCir(CirSubmissionData report)
        {

            await _baseRepo.DocumentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_config.DatabaseId, _cirSyncLogCollection, report.Id),
                   new RequestOptions
                   {
                       PartitionKey = new PartitionKey(keyValue: getPartition(report.CirId))
                   }
                   ).ConfigureAwait(false);

        }

        public bool CheckCirExistsInCirSyncLog(string id)
        {
            if (id.Length > 15)
                return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                       UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirSyncLogCollection),
                       new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                   .Where(f => f.Id == id).AsEnumerable().Any();
            else
                return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                                  UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirSyncLogCollection),
                                  new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                              .Where(f => f.CirId == Convert.ToInt64(id)).AsEnumerable().Any();
        }


        public bool Exists(string id)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirCommonnBrandCollectionName),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(f => f.Id == id).AsEnumerable().Any();
        }

        public bool Exists(long cirId)
        {
            return _baseRepo.DocumentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirCommonnBrandCollectionName),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true/*, PartitionKey = new PartitionKey(getPartition(cirId))*/ })
                .Where(f => f.CirId == cirId).AsEnumerable().Any();
        }

        protected async Task Insert(CirSubmissionData report)
        {
            report.ModifiedBy = report.ModifiedBy.Contains("_") ? report.ModifiedBy.Split('_')[0] : report.ModifiedBy;
            _cirBrandCollectionName = _cirCommonnBrandCollectionName;
            report = _cirHistoryRepository.ValidateCirImgReference(report);
            await _baseRepo.DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirBrandCollectionName), report).ConfigureAwait(false);
        }


        protected async Task Replace(string reportId, CirSubmissionData report)
        {
            report.ModifiedBy = report.ModifiedBy.Contains("_") ? report.ModifiedBy.Split('_')[0] : report.ModifiedBy;
            _cirBrandCollectionName = _cirCommonnBrandCollectionName;
            report = _cirHistoryRepository.ValidateCirImgReference(report);
            await _baseRepo.DocumentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_config.DatabaseId, _cirBrandCollectionName, reportId), report).ConfigureAwait(false);
        }

        protected async Task DeleteDocument(string reportId)
        {
            _cirBrandCollectionName = _cirCommonnBrandCollectionName;
            Document report = _baseRepo.DocumentClient.CreateDocumentQuery(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirBrandCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(r => r.Id == reportId)
                .AsEnumerable()
                .FirstOrDefault();

            await _baseRepo.DocumentClient.DeleteDocumentAsync(report.SelfLink,
                new RequestOptions { PartitionKey = new PartitionKey(keyValue: ((CirSubmissionData)(dynamic)report).Partition) })
                .ConfigureAwait(false);
        }

        public static string getPartition(Int64 cirId)
        {
            string partitionName;
            decimal partitionValue;
            //1 - 99999
            //100000 - 199999
            if (ConfigurationManager.AppSettings["PartitionDivisionValue"] != null)
                partitionValue = (cirId / Convert.ToInt64(ConfigurationManager.AppSettings["PartitionDivisionValue"]));
            else
                partitionValue = (cirId / 50000);
            //cirId = 99999;


            partitionName = "partition" + (int)partitionValue;

            return partitionName;
        }

        /// <summary>
        /// Delete the documnet from Synclog collection using reportId
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        protected async Task DeleteDocumentInSyncLog(string reportId)
        {
            Document report = _baseRepo.DocumentClient.CreateDocumentQuery(
                UriFactory.CreateDocumentCollectionUri(_config.DatabaseId, _cirSyncLogCollection),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(r => r.Id == reportId)
                .AsEnumerable()
                .FirstOrDefault();

            await _baseRepo.DocumentClient.DeleteDocumentAsync(report.SelfLink,
                new RequestOptions { PartitionKey = new PartitionKey(keyValue: ((CirSubmissionData)(dynamic)report).Partition) })
                .ConfigureAwait(false);
        }

    }
}
