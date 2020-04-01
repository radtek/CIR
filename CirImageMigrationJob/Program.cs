using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace CirImageMigrationJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            try
            {
                var host = new JobHost();
                // The following code ensures that the WebJob will be running continuously
                host.Call(typeof(Functions).GetMethod("ProcessQueueMessage"), new { value = 40 });
            }
            catch (Exception ex)
            {                 
                Functions.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", Functions.versionNumber, "Program.Main()"), 0, "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
            }
        }
    }
}
