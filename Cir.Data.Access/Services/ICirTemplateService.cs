using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface ICirTemplateService
    {
        string TableName { get; }
        string WindAmsBrandPostfix { get; }
        CirTemplateDataModel GetHighestRevisionByBrandCollectionName(string cirBrandCollectionName);
        CirTemplateDataModel GetOldVersionByBrandCollectionName(string templateId);      
    }
}
