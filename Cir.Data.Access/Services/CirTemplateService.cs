using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    internal class CirTemplateService : ICirTemplateService
    {
        public string TableName => "CirTemplates";

        public string WindAmsBrandPostfix => "_WindAMS";

        private readonly ICirTemplateRepository _cirTemplateRepository;

        public CirTemplateService(ICirTemplateRepository cirTemplateRepository)
        {
            _cirTemplateRepository = cirTemplateRepository;
        }

        public CirTemplateDataModel GetHighestRevisionByBrandCollectionName(string cirBrandCollectionName)
        {
            return _cirTemplateRepository.GetHighestRevisionByBrandCollectionName(cirBrandCollectionName);
        }
        public CirTemplateDataModel GetOldVersionByBrandCollectionName(string templateId)
        {
            return _cirTemplateRepository.GetOldVersionByBrandCollectionName(templateId);
        }
        
    }
}
