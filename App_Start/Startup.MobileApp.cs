using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using System.Web.Http.Cors;
using LightInject;
using Cir.Data.Access.Services;

namespace Cir.Data.Api
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            ServiceContainer container = SetupServiceContainer(httpConfiguration);

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .MapApiControllers()
                .ApplyTo(httpConfiguration);

            app.UseWebApi(httpConfiguration);
            ConfigureSwagger(httpConfiguration);
        }

        private static ServiceContainer SetupServiceContainer(HttpConfiguration httpConfiguration)
        {
            var container = new ServiceContainer();

            container.RegisterAssembly(typeof(ICirSubmissionService).Assembly);
            container.RegisterApiControllers();
            container.EnableWebApi(httpConfiguration);

            return container;
        }
    }
}