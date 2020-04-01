using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirLockService
    {
        CirSubmissionData LockCir(long id, string templateId, string lockedBy);
        void UnlockCir(CirSubmissionSyncData report, string templateId);
        void UnlockCIRfromSql(long cirId);
    }
}
