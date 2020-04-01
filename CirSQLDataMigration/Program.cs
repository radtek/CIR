using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirSQLDataMigration
    {
    class Program
        {
       
            // Please set the following connection strings in app.config for this WebJob to run:
            // AzureWebJobsDashboard and AzureWebJobsStorage
            static void Main()
                {
                //try
                //{
                var host = new JobHost();
                // The following code ensures that the WebJob will be running continuously
                host.Call(typeof(MigrationFunctions).GetMethod("ProcessQueueMessage"), new { value = 40 });
                //}
                //catch(Exception ex)
                //{
                //    string st = ex.Message;
                //}
                }
            }
        }
