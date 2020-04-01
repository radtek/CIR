using System.Collections.Generic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirSubmissionService
    {
        CirSubmissionData Get(string id);
        IEnumerable<CirSubmissionData> GetAll();
        IEnumerable<CirSubmissionData> SyncRequest(string userId, IEnumerable<CirSubmissionSyncData> reportsToSync);
        void SyncUpdate(CirSubmissionData reportToUpdate);
        CirSubmissionData Add(CirSubmissionData report);
        CirSubmissionData Update(CirSubmissionData report);
        void Delete(string reportId);
    }
}
