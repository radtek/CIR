using Cir.Data.Access.Services;
using Cir.Data.Access.Services.Integration;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.Filters;
using LightInject;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using Serilog;
using System;
using System.Configuration;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cir.Data.Api
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            
            httpConfiguration.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            httpConfiguration.Filters.Add(new LoggingFilters());
            httpConfiguration.Filters.Add(new ActivityLogFilter());
            //httpConfiguration.EnableSystemDiagnosticsTracing();

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            ServiceContainer container = SetupServiceContainer(httpConfiguration);

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .MapApiControllers()
                .ApplyTo(httpConfiguration);

            ConfigureAuth(app, httpConfiguration);
            ConfigureSwagger(httpConfiguration);

            app.UseWebApi(httpConfiguration);

            //StartIntegrationRequests(container);
        }

        private static ServiceContainer SetupServiceContainer(HttpConfiguration httpConfiguration)
        {
            var container = new ServiceContainer();

            container.RegisterAssembly(typeof(ICirSubmissionService).Assembly);
            container.RegisterApiControllers();
            container.EnableWebApi(httpConfiguration);

            var logger = new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.ApplicationInsightsEvents(
                    ConfigurationManager.AppSettings.Get("ApplicationInsightsInstrumentationKey")).CreateLogger();

            container.Register<ILogger>(fac => logger);
            container.Register<IGraphApiService>(
                fac => new GraphApiService(
                    GraphApiClient.CreateInstance(),
                    MemoryCache.Default,
                    ConfigurationManager.AppSettings.Get("UserDataCachePostfix"),
                    TimeSpan.FromMinutes(
                        double.Parse(ConfigurationManager.AppSettings.Get("UserDataCacheTtlMinutes"))),
                    logger), new PerContainerLifetime());

            return container;
        }

        private static void StartIntegrationRequests(IServiceFactory containter)
        {
            var inspecToolIntegrationService = containter.GetInstance<IInspecToolsIntegrationService>();
            inspecToolIntegrationService.Run();
        }
    }
}