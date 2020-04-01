using System;
using System.Net.Http;
using Cir.BlobStorage;
using Cir.BlobStorage.ErrorHandlerNS;
using Cir.BlobStorage.FileHandlerNS;
using Cir.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cir.Azure.Functions.Util
{
    public static class DISetup
    {
        public static IServiceProvider ConfigureServices(ILogger logger)
        {
            var customerAuthorizerTableName = Environment.GetEnvironmentVariable("CustomerAuthorizerTableName");

            var services = new ServiceCollection()
                    // HttpHandlers
                    .AddScoped<AiDamagesPostHandler>()
                    .AddScoped<AiDamagesGetHandler>()
                    .AddScoped<BirsHandler>()
                    .AddScoped<GetRepairBrrHandler>()
                    .AddScoped<GetRepairDetailsHandler>()
                    .AddScoped<GetRepairListHandler>()
                    .AddScoped<CirsHandler>()
                    .AddScoped<UploadBladeTagHandler>()
                    .AddScoped<DefectDetectionHandler>()

                    // Converters
                    .AddScoped<IBirConverter, BirConverter>()
                    .AddScoped<IBrrConverter, BrrConverter>()
                    .AddScoped<IRepairDetailsConverter, RepairDetailsConverter>()
                    .AddScoped<IRepairListConverter, RepairListConverter>()
                    .AddScoped<IConverter, CirDetailsConverter>()
                    .AddScoped<IConverter, CirImageUrlsConverter>()
                    .AddScoped<IConverter, CirDamagesConverter>()
                    .AddScoped<IConverter, CirIdConverter>()
                    .AddScoped<IAIDamagesForCirConverter, AIDamagesForCirConverter>()
                    .AddScoped<IDefectDetectionRequestConverter, DefectDetectionRequestConverter>()
                    .AddScoped<IDefectDetectionItemConverter, DefectDetectionItemConverter>()

                    // Auth
                    .AddScoped<IHttpAuthorizer, CustomerAuthorizer>()

                    // Util
                    .AddScoped<IHeaderParameterGetter, HeaderParameterGetter>()
                    .AddScoped<IQueryParameterGetter, QueryParameterGetter>()
                    .AddScoped((_) => new HttpClient())

                    // Blob
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(0))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(1))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(2))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(3))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(4))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(5))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(6))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(7))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(8))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(9))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(10))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(11))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(12))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(13))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(14))
                    .AddSingleton<IFSNodeLister>(new BlobNodeLister(15))
                    .AddScoped<IFileFactory, BlobFileFactory>()
                    .AddScoped<IFSNodeNavigator, FSNodeNavigator>()
                    .AddScoped<IMetadataGetter, MetadataGetter>()

                    // Repo
                    .AddScoped<ICirRepository, CirRepository>()
                    .AddScoped<IBirRepository, BirRepository>()
                    .AddScoped<IBirRepository, BirRepository>()
                    .AddScoped<IBirRepository, BirRepository>()
                    .AddSingleton<IDefectDetectionItemRepository, DefectDetectionItemRepository>()
                    .AddScoped<IFileHandlerFactory, FileHandlerFactory>()

                    // Specifications
                    .AddScoped<ISpecificationBuilderFactory, SpecificationBuilderFactory>()

                    .AddScoped<IErrorHandler, LoggerErrorHandler>()
                    .AddScoped((_) => logger);

            return services.BuildServiceProvider();
        }
    }
}
