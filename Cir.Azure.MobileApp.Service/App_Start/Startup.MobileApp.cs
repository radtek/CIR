using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Azure.MobileApp.Service.DataObjects;
using Cir.Azure.MobileApp.Service.Models;
using Owin;
using Cir.Azure.MobileApp.Service.Filters;

namespace Cir.Azure.MobileApp.Service
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.Filters.Add(new LoggingFilters());
            config.EnableSystemDiagnosticsTracing();
            config.MapHttpAttributeRoutes();
            //Registering filters for Graph Api Error
           

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);
           
            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new vestascirmobileappInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<vestascirmobileappContext, Configuration>()); 

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<vestascirmobileappContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
            
        }
    }

    public class vestascirmobileappInitializer : CreateDatabaseIfNotExists<vestascirmobileappContext>
    {
        protected override void Seed(vestascirmobileappContext context)
        {
            List<UserCirData> uds = new List<UserCirData>
            {
                new UserCirData { Id = Guid.NewGuid().ToString(), CirDataLocalID = 1,Status = 0, UserInitial ="mukes@vestas.com", UpdateBy = "mukes@vestas.com", RowVersion = DateTime.UtcNow.Ticks },
               
            };

            foreach (UserCirData ud in uds)
            {
                context.Set<UserCirData>().Add(ud);
            }
            context.Set<UserLoginDetails>().Add(new UserLoginDetails { Id = Guid.NewGuid().ToString(), UserPricipleName = "mukes@vestas.com", LastOnlineTime = DateTime.UtcNow });
            base.Seed(context);
        }
    }
}

