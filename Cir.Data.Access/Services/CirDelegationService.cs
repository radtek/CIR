using System;
using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    internal class CirDelegationService : ICirDelegationService
    {
        private readonly ICirSyncLogRepository _cirSyncLogRepository;
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private readonly SyncServiceClient _syncServiceClient;

        public CirDelegationService(ICirSyncLogRepository cirSyncLogRepository,
            ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository,
            SyncServiceClient syncServiceClient)
        {
            _cirSyncLogRepository = cirSyncLogRepository;
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
            _syncServiceClient = syncServiceClient;
        }

        public CirSubmissionData DelegateCirTo(string id, string delegateTo, string delegatedBy)
        {
            var logReport = _cirSyncLogRepository.Get(id);
            
            var masterReport = _cirSubmissionDataDynamicRepository.Get(id, logReport.CirCollectionName);

            if (masterReport != null)
            {
                _cirSubmissionDataDynamicRepository.LockCir(masterReport.CirId, masterReport.CirCollectionName,
                    delegateTo);

                _syncServiceClient.LockCirDataByCirID(masterReport.CirId, delegateTo);
            }

            logReport.State = CirState.Draft;
            logReport.DelegatedTo = delegateTo;
            logReport.DelegatedBy = delegatedBy;
            logReport.LockedBy = delegateTo;
            logReport.ModifiedOn = DateTime.UtcNow;

            _cirSyncLogRepository.Upsert(logReport);

            return logReport;
        }

        public CirSubmissionData RevokeDelegate(string id)
        {
            var logReport = _cirSyncLogRepository.Get(id);
            var masterReport = _cirSubmissionDataDynamicRepository.Get(id, logReport.CirCollectionName);

            if (masterReport != null)
            {
                _cirSubmissionDataDynamicRepository.LockCir(masterReport.CirId, masterReport.CirCollectionName,
                    logReport.DelegatedBy);

                _syncServiceClient.LockCirDataByCirID(masterReport.CirId, logReport.DelegatedBy);
            }

            logReport.State = CirState.Draft;
            logReport.LockedBy = logReport.DelegatedBy;
            logReport.DelegatedTo = string.Empty;
            logReport.DelegatedBy = string.Empty;
            logReport.ModifiedOn = DateTime.UtcNow;

            _cirSyncLogRepository.Upsert(logReport);

            return logReport;
        }
    }
}
