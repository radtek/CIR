namespace Cir.Azure.MobileApp.Migrations
{
    using Cir.Azure.MobileApp.DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cir.Azure.MobileApp.Models.vestascirmobileappContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(Cir.Azure.MobileApp.Models.vestascirmobileappContext context)
        {
            //  This method will be called after migrating to the latest version.

            
            
            List<UserCirData> uds = new List<UserCirData>
            {
                new UserCirData { Id = Guid.NewGuid().ToString(), CirDataLocalID = 1,Status = 0, UserInitial ="mukes@vestas.com", UpdateBy = "mukes@vestas.com", RowVersion = DateTime.UtcNow.Ticks },
               
            };

            foreach (UserCirData ud in uds)
            {
                context.Set<UserCirData>().Add(ud);
            }
            context.Set<UserLoginDetails>().Add(new UserLoginDetails { Id = Guid.NewGuid().ToString(), UserPricipleName = "mukes@vestas.com", LastOnlineTime = DateTime.UtcNow });
           
        }
    }
}
