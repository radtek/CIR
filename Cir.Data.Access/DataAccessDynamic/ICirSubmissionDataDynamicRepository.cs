using System.Linq;
using Cir.Data.Access.Models;
using System.Collections.Generic;
using System;

namespace Cir.Data.Access.DataAccessDynamic
{
    public interface ICirSubmissionDataDynamicRepository
    {
        CirSubmissionData Get(string id, string cirBrandCollectionName);
        CirSubmissionData GetByCirId(long cirId, string cirBrandCollectionName);
        IQueryable<CirSubmissionData> GetAll(string cirBrandCollectionName);
        List<CirSubmissionData> GetAllRelatedToUser(string userId, string collections);
        List<CirSubmissionData> GetAllBySyncData(List<CirSubmissionSyncData> reportsToSync);
        long Add(CirSubmissionData report, string cirBrandCollectionName);
        long AddForMigration(CirSubmissionData report, string cirBrandCollectionName);
        void Update(CirSubmissionData report, string cirBrandCollectionName);
        void UpdateState(CirSubmissionData report, string cirBrandCollectionName);
        void Delete(string reportId, string cirBrandCollectionName);
        CirSubmissionData LockCir(long id, string cirBrandCollectionName, string lockedBy);
        CirSubmissionData UnlockCir(long cirId, string cirBrandCollectionName);
        bool Exists(string id);
        bool Exists(long cirId);
        bool CheckCirExistsInCirSyncLog(string id);
        void InsertIntoCirSyncLog(CirSubmissionData data);
        void DeleteFromCirSyncLog(CirSubmissionData report);
        void UpdateCir(CirSubmissionData report, string cirBrandCollectionName);
    }
}
