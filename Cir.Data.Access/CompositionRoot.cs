using System.Configuration;
using Cir.Data.Access.CirSyncService;
using LightInject;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Services.Integration;
using Cir.Data.Access.Validation;
using Cir.Data.Access.Helpers;

namespace Cir.Data.Access
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            var cirRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirCollectionPrefix"]);

            var birRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["BirCollection"]);

            var messagesRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["MessagesCollection"]);

            var cirTemplateRepositoryConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirTemplateCollection"]);

            var groupUserBrandConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["GroupUserBrandCollection"]);

            var blobStorageConfig = new BlobStorageConfig(
                ConfigurationManager.AppSettings["AzureStorageConnectionString"],
                ConfigurationManager.AppSettings["AzureStorageContainerName"]);

            var cirIdDataConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirIdCollection"]);

            var cirHistoryCollectionConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirHistoryCollection"]);

            var brandDataConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["BrandDataCollection"]);

            var integrationRequestsConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["IntegrationRequestsCollection"]);

            var hotlistConfig = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["HotlistDataCollection"]);

            var cirSyncLogConfog = new DataRepositoryConfig(
                ConfigurationManager.AppSettings["Database"],
                ConfigurationManager.AppSettings["CirSyncLogCollection"]);

            var baseRepo = new BaseRepository(ConfigurationManager.AppSettings["EndPointUrl"], ConfigurationManager.AppSettings["PrimaryKey"]);
            var groupUserBrandRepository = new GroupUserBrandRepository(groupUserBrandConfig, baseRepo);
            var cirTemplateRepository = new CirTemplateRepository(cirTemplateRepositoryConfig, baseRepo);
            var cirIdRepository = new CirIdRepository(cirIdDataConfig, baseRepo);
            var cirImageStorageRepository = new CirImageStorageRepository(blobStorageConfig);
            var cirHistoryRepository = new CirSubmissionHistoricDataRepository(cirHistoryCollectionConfig, baseRepo, cirImageStorageRepository);
            var syncService = new SyncServiceClient("WSHttpBinding_ISyncService");
            var cirSubmissionDataDynamicRepository = new CirSubmissionDataDynamicRepository(cirRepositoryConfig, baseRepo, cirHistoryRepository);
            var cirPdfStorageRepository = new CirPDFStorageRepository(blobStorageConfig);
            var cirLogRepository = new CirLogRepository(blobStorageConfig);

            serviceRegistry.Register<ICirPDFStorageRepository>(factory => cirPdfStorageRepository);
            serviceRegistry.Register<ICirImageStorageRepository>(factory => cirImageStorageRepository);
            serviceRegistry.Register<ICirTemplateRepository>(factory => cirTemplateRepository);
            serviceRegistry.Register<ICirSubmissionDataDynamicRepository>(factory => cirSubmissionDataDynamicRepository);
            serviceRegistry.Register<IGroupUserBrandRepository>(factory => groupUserBrandRepository);
            serviceRegistry.Register<IBirDetailsDataRepository>((factory) => new BirDetailsDataRepository(birRepositoryConfig, baseRepo));
            serviceRegistry.Register<IMessageDataRepository>((factory) => new MessageDataRepository(messagesRepositoryConfig, baseRepo));
            serviceRegistry.Register<ICirImageStorageRepository>(factory => new CirImageStorageRepository(blobStorageConfig));
            serviceRegistry.Register<ICirIdRepository>(factory => cirIdRepository);
            serviceRegistry.Register<ICirSubmissionHistoricDataRepository>(factory => cirHistoryRepository);
            serviceRegistry.Register<IBrandDataRepository>(factory => new BrandDataRepository(brandDataConfig, baseRepo));
            serviceRegistry.Register<IIntegrationRequestsDataRepository>(factory => new IntegrationRequestsDataRepository(integrationRequestsConfig, baseRepo));
            serviceRegistry.Register<IHotlistRepository>(factory => new HotlistRepository(hotlistConfig, baseRepo));
            serviceRegistry.Register<SyncServiceClient>(fac => syncService);
            serviceRegistry.Register<ICirSyncLogRepository>(fac => new CirSyncLogRepository(cirSyncLogConfog, baseRepo));
            serviceRegistry.Register<ICirLogRepository>(factory => cirLogRepository);

            serviceRegistry.Register<IBirDataService, BirDataService>();
            serviceRegistry.Register<IMessageService, MessageService>();
            serviceRegistry.Register<ICirSubmissionService, CirSubmissionService>();
            serviceRegistry.Register<ICirBlobImageService, CirBlobImageService>();
            serviceRegistry.Register<IUserDataService, UserDataService>();
            serviceRegistry.Register<ICirTemplateService, CirTemplateService>();
            serviceRegistry.Register<ICirValidationService, CirValidationService>();
            serviceRegistry.Register<IValidationService, ValidationService>();
            serviceRegistry.Register<ICirIdGeneratorService, CirIdGeneratorService>();
            serviceRegistry.Register<ICirBrandService, CirBrandService>();
            serviceRegistry.Register<ICirTosLockService, CirTosLockService>();
            serviceRegistry.Register<IInspecToolsIntegrationService, InspecToolsIntegrationService>();
            serviceRegistry.Register<IHotlistService, HotlistService>();
            serviceRegistry.Register<ICimCaseService, CimCaseService>();
            serviceRegistry.Register<ICirLockService, CirLockService>();
            serviceRegistry.Register<ICirDelegationService, CirDelegationService>();
            serviceRegistry.Register<ICirNotification, CirNotification>();
            
        }
    }
}