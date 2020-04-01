using System.Collections.Generic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    public interface ICirSyncLogRepository
    {
        CirSubmissionData Get(string reportId);
        CirSubmissionData GetByCirId(long cirId);
        long Upsert(CirSubmissionData report);
        long UpsertState(CirSubmissionData report);
        void Delete(CirSubmissionData report);
        IEnumerable<CirSubmissionData> GetAllRelatedToUser(string userName);
        IEnumerable<CirSubmissionData> GetAllRelatedToUserForSync(string userName);
        IEnumerable<CirSubmissionData> GetAllByIds(List<string> ids);
        void Unlock(CirSubmissionData report);
        IEnumerable<CirSubmissionData> GetAllMainCollectionCirRelatedToUser(string userName);
        IEnumerable<CirSubmissionData> MainCollctionGetAllByIds(List<string> ids);  

    }
}
