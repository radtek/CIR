using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using Cir.Azure.MobileApp.Service.DataObjects;

namespace Cir.Azure.MobileApp.Service.Models
{
    public class vestascirmobileappContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public vestascirmobileappContext()
            : base(connectionStringName)
        {
        }
        public DbSet<UserCirData> UserCirDataSet { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetailsSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Changes made as per the method is removed from SDK ref : https://azure.microsoft.com/en-in/blog/azure-mobile-apps-september-2015-update/
            //string schema = MobileAppSettingsDictionary.GetSchemaName(); 
            string schema = System.Configuration.ConfigurationManager.AppSettings.Get("MS_MobileServiceName");
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }

}
