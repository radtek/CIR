using System.Linq;
using Cir.Data.Access.Models;
using System.Collections.Generic;

namespace Cir.Data.Access.DataAccess
{
    internal interface ICirSubmissionDataRepository : IUserTable
    {
        CirSubmissionData Get(string id);
        IQueryable<CirSubmissionData> GetAll();
        IQueryable<CirSubmissionSyncData> GetAllRelatedToUser(string userId);
        IQueryable<CirSubmissionData> GetAllByIds(List<string> ids);
        void Add(CirSubmissionData report);
        void Update(CirSubmissionData report);
        void Delete(string reportId);
    }
}
