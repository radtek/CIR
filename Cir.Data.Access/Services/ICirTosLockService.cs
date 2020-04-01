using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirTosLockService
    {
        bool IsCirLocked(string id, string cirTemplateId);
        CirSubmissionData LockCirByTos(string id, string cirTemplateId, string userName);
        void UnlockCirByTos(string id, string cirTemplateId, string userName);
    }
}
