using System.Configuration;
using LightInject;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;

namespace Cir.Data.Access
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            var cirRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["EndPointUrl"],
                ConfigurationManager.AppSettings["PrimaryKey"],
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirCollection"]);

            var cirTemplateRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["EndPointUrl"],
                ConfigurationManager.AppSettings["PrimaryKey"],
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirTemplateCollection"]);

            var blobStorageConfig = new BlobStorageConfig(
                ConfigurationManager.AppSettings["AzureStorageConnectionString"]);

            var validationConfig = new SapValidationConfig(
                ConfigurationManager.AppSettings["UseSapWebService"],
                ConfigurationManager.AppSettings["SapWebServiceUserName"],
                ConfigurationManager.AppSettings["SapWebServicePassword"],
                ConfigurationManager.AppSettings["SapNotificationNumberWebServiceUrl"],
                ConfigurationManager.AppSettings["SapServiceReportNumberWebServiceUrl"]);

            serviceRegistry.Register<ICirSubmissionService, CirSubmissionService>();
            serviceRegistry.Register<ICirBlobStorageService, CirBlobStorageService>();
            serviceRegistry.Register<IUserDataService, UserDataService>();

            serviceRegistry.Register<ICirSubmissionDataRepository>((factory) => new CirSubmissionDataRepository(cirRepositoryConfig));
            serviceRegistry.Register<ICirTemplateRepository>((factory) => new CirTemplateRepository(cirTemplateRepositoryConfig));

            serviceRegistry.Register<ICirImageStorageRepository>(factory => new CirImageStorageRepository(blobStorageConfig));
            serviceRegistry.Register<ICirValidationService>(factory => new CirValidationService(validationConfig));
            serviceRegistry.Register<IValidationMethodsService, ValidationMethodsService>();
        }
    }
}