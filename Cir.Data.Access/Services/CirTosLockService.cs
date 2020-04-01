using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services.Integration;

namespace Cir.Data.Access.Services
{
    internal class CirTosLockService : ICirTosLockService
    {
        private readonly ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private readonly ICirTemplateRepository _cirTemplateService;
        private readonly IInspecToolsIntegrationService _inspecToolsIntegrationService;

        public CirTosLockService(
            ICirSubmissionDataDynamicRepository cirSubmissionDataDynamicRepository,
            ICirTemplateRepository cirTemplateService,
            IInspecToolsIntegrationService inspecToolsIntegrationService)
        {
            _cirSubmissionDataDynamicRepository = cirSubmissionDataDynamicRepository;
            _cirTemplateService = cirTemplateService;
            _inspecToolsIntegrationService = inspecToolsIntegrationService;
        }

        public bool IsCirLocked(string id, string cirTemplateId)
        {
            var template = _cirTemplateService.Get(cirTemplateId);
            var cir = _cirSubmissionDataDynamicRepository.Get(id, template.CirBrandCollectionName);

            return cir.IsLockedByTos;
        }

        public CirSubmissionData LockCirByTos(string id, string cirTemplateId, string userName)
        {
            var template = _cirTemplateService.Get(cirTemplateId);
            var cir = _cirSubmissionDataDynamicRepository.Get(id, template.CirBrandCollectionName);

            cir.IsLockedByTos = true;

            _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);

            _inspecToolsIntegrationService.PostCirLock(cir, userName); 

            return cir;
        }

        public void UnlockCirByTos(string id, string cirTemplateId, string userName)
        {
            var template = _cirTemplateService.Get(cirTemplateId);
            var cir = _cirSubmissionDataDynamicRepository.Get(id, template.CirBrandCollectionName);

            cir.IsLockedByTos = false;

            _cirSubmissionDataDynamicRepository.Update(cir, cir.CirCollectionName);

            _inspecToolsIntegrationService.PostCirUnlock(cir, userName);
        }
    }
}
