using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Azure.MobileApp.DataObjects;
using Cir.Azure.MobileApp.Models;
using System.Web.Http.Cors;
using System.Web.Http.OData.Formatter.Deserialization;
using Microsoft.Data.OData;
using Microsoft.Data.Edm;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Http.OData.Formatter;
using System.Web.Http.OData.Formatter.Serialization;
using Cir.Azure.MobileApp.Migrations;

namespace Cir.Azure.MobileApp
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));



            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new vestascirmobileappInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<vestascirmobileappContext, Configuration>()); 

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

