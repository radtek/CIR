using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirDelegationService
    {
        CirSubmissionData DelegateCirTo(string id, string delegateTo, string delegatedBy);
        CirSubmissionData RevokeDelegate(string id);
    }
}
