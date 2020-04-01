using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.DataAccess
{
    public interface ICirTemplateRepository
    {
        Task<List<CirTemplateDataModel>> GetTemplatesByBrandIds(IList<string> brandIds);
        //Task<List<string>> GetTemplateNamesByBrandIds(IList<string> brandIds);
        //List<CirTemplateDataModel> GetTemplates(IList<string> templateIds);
        CirTemplateDataModel Get(string templateId);
        void Add(CirTemplateDataModel cirTemplateDataModel);
        CirTemplateDataModel GetHighestRevisionByBrandCollectionName(string brandCollectionName);
        CirTemplateDataModel GetOldVersionByBrandCollectionName(string templateId);       
    }
}
