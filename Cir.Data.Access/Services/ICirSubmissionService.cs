using System.Collections.Generic;
using System.Threading.Tasks;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Services
{
    public interface ICirSubmissionService : IUserTable
    {
        CirSubmissionData Get(string id, string templateId);
        CirSubmissionData GetFromCirSyncLog(string id);
        CirSubmissionData GetByCirId(long cirId);
        IEnumerable<CirSubmissionData> GetAll(string templateId);
       // Task<SyncResponse> SyncRequestAsync(UserInformation user, IEnumerable<CirSubmissionSyncData> reportsToSync);
        SyncResponse SyncRequest(UserInformation user, IEnumerable<CirSubmissionData> reportsToSync);
        long SyncUpdate(CirSubmissionData reportToUpdate, string userName);
        CirSubmissionData Add(CirSubmissionData report);
        CirSubmissionData AddForMigration(CirSubmissionData report);
        CirSubmissionData Update(CirSubmissionData report, string userName);
        void Submit(long cirId, string currentUser);
        void SubmitFromApprove(long cirId, string currentUser, string comment);
        void Approve(long cirId, string currentUser,string comment);
        void Reject(long cirId, string currentUser,string comment);
        void Delete(long cirId, string currentUser, string originalCirId);
        void SetSynced(string reportId, string templateId);
        void Delete(string reportId, string templateId);
        IEnumerable<CirRevisionDetails> GetRevisionHistory(long turbineNumber, string cirGUID);
        CirRevisionDetails GetHistoryCir(string cirId);
        Task<IList<CirRevisionDetails>> GetRevHistByTurbineNo(long turbineNumber);
        CirSubmissionData CreateEmptyBladeInspection(string userName);
        CirSubmissionData UpdateSyncLog(CirSubmissionData report, string userName);
        CirSubmissionData UpdateSyncLogNoValidate(CirSubmissionData report);
        List<ImageDataModel> Add_Migration(List<ImageDataModel> imgData);
        PDFModel AddPDFMigration(PDFModel lstPdfData);
        CirPDFResponse GetCirPdf(long cirId, string currentUser);
        CirPDFResponse GetCirPdfZip(string cirIds, string currentUser);
        Task<byte[]> GeneratePDF(CirSubmissionData cirData);
    }
}
