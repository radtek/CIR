using System;
using System.Linq;
using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;
using Serilog;
using System.Configuration;

namespace Cir.Data.Access.Services
{
    internal class CirLockService : ICirLockService
    {
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private readonly ICirTemplateRepository _cirTemplateRepository;
        private readonly SyncServiceClient _syncServiceClient;
        private readonly ICirSyncLogRepository _cirSyncLogRepository;
        private readonly ICirImageStorageRepository _cirImageStorageRepository;
        private readonly ILogger _logger;
        public string _cirCommonnBrandCollectionName = ConfigurationManager.AppSettings["CirCommonBrandCollectionName"];

        public CirLockService(
            ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository,
            ICirTemplateRepository cirTemplateRepository,
            SyncServiceClient syncServiceClient,
            ICirSyncLogRepository cirSyncLogRepository,
            ICirImageStorageRepository cirImageStorageRepository,
            ILogger logger)
        {
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
            _cirTemplateRepository = cirTemplateRepository;
            _syncServiceClient = syncServiceClient;
            _cirSyncLogRepository = cirSyncLogRepository;
            _cirImageStorageRepository = cirImageStorageRepository;
            _logger = logger;
        }

        public CirSubmissionData LockCir(long cirId, string templateId, string lockedBy)
        {            
            var cirBrandCollectionName = _cirCommonnBrandCollectionName;
            var masterReport = _cirSubmissionDataDynamicRepository.LockCir(cirId, cirBrandCollectionName, lockedBy);

            //_logger.Information("Locking cir with id {@id} from collection {@cirBrandCollectionName} by {@lockedBy}", cirId, cirBrandCollectionName, lockedBy);

            if (!string.IsNullOrEmpty(masterReport.LockedBy) && masterReport.LockedBy != lockedBy)
            {
                throw new ArgumentException("CIR already locked");
            }
            masterReport.State = CirState.Draft;
            masterReport.ModifiedOn = DateTime.UtcNow;
            _cirSyncLogRepository.Upsert(masterReport);
            _syncServiceClient.LockCirDataByCirID(cirId, lockedBy);

            var template = _cirTemplateRepository.Get(masterReport.CirTemplateId);
            masterReport.Schema = template.Schema;
            return masterReport;
        }       

        public void UnlockCir(CirSubmissionSyncData report, string templateId)
        { 
            var masterReport = _cirSubmissionDataDynamicRepository.GetByCirId(report.CirId, _cirCommonnBrandCollectionName);
            var logReport = _cirSyncLogRepository.GetByCirId(report.CirId);
            if (masterReport != null)
            {
                _cirSubmissionDataDynamicRepository.UnlockCir(masterReport.CirId, report.CirCollectionName);
                //_syncServiceClient.UnlockCirDataByCirID(report.CirId);
            }
            if(logReport != null)
            {
                _cirSyncLogRepository.Delete(logReport);
            }    
        }

        public void UnlockCIRfromSql(long cirId)
        {
            _syncServiceClient.UnlockCirDataByCirID(cirId);
        }

        public void RemoveBlob(CirSubmissionSyncData report, CirSubmissionSyncData masterReport)
        {
            if (report.ImageReferences == null) return;
            if (masterReport != null)
            {
                var blobsToDelete = report.ImageReferences
                    .Where(browserImageReference => masterReport.ImageReferences.All(
                        x => x.ImageId != browserImageReference.ImageId)).ToList();
            }
        }
    }
}
