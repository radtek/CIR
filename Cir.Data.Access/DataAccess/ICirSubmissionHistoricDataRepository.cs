using System.Collections.Generic;
using Cir.Data.Access.Models;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    internal interface ICirSubmissionHistoricDataRepository
    {
        void StoreRevision(CirSubmissionData cir);
        IEnumerable<CirRevisionDetails> GetCirRevisionItems(long turbineNumber, string cirGUID);
        Task<IList<CirRevisionDetails>> GetAllCirsRevisionItems(long turbineNumber);
        CirRevisionDetails GetCirRevision(string cirGuid);
        CirSubmissionData ValidateCirImgReference(CirSubmissionData report);
    }
}
