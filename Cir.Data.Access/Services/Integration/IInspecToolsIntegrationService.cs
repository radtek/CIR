using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services.Integration
{
    public interface IInspecToolsIntegrationService
    {
        void PostCirLock(CirSubmissionData cir, string userName);
        void PostCirUnlock(CirSubmissionData cir, string userName);
        void PostCir(CirSubmissionData cir, string userName);
        void Run();
    }
}
