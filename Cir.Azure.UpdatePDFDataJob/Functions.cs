using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Data.SqlClient;
using System.Data;
using System;
using Newtonsoft.Json;
using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.Controllers;

namespace Cir.Azure.UpdatePDFDataJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.       

        [NoAutomaticTrigger]
        public static void UpdatePDFData(TextWriter log, int value, [Queue("queuePDFData")] out string message)
        {
            message = value.ToString();
            //log.WriteLine("Following message will be written on the Queue={0}", message);            
            log.WriteLine("SyncJob Started at " + System.DateTime.Now);

            try
            {
                var Service = new Cir.Azure.MobileApp.Service.Utilities.SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);               
                var oResponse = Service.UpdatePDFData(0);
                log.WriteLine("CIR ID = " + oResponse.CirID + " PDF Updated !");
            }
            catch (Exception ex)
            {
                log.WriteLine("CIR Exception error details.!" + ex.Message);
            }
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MS_TableConnectionString"].ConnectionString;
            //DataSet dsCirData = new DataSet();
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        string queryString = "SELECT  DISTINCT CirId  FROM [CIM_ComponentInspectionReports].[dbo].[CirData] WHERE Created BETWEEN '2017-12-01' AND '2017-12-05'";
            //        //string queryString = "SELECT TOP 30 * INTO #userData  FROM [" + schemaname + "].[UserCirDatas] WHERE Status = 2 AND [Deleted] = 0; UPDATE [" + schemaname + "].[UserCirDatas] SET Status = 5 WHERE Id IN (SELECT Id FROM #userData); SELECT * FROM #userData";
            //        SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);

            //        adapter.Fill(dsCirData, "CirData");
            //        log.WriteLine(dsCirData.Tables["CirData"].Rows.Count + " records selected at " + System.DateTime.Now);
            //    }
            //    if (dsCirData != null)
            //    {
            //        for (int i = 0; i < dsCirData.Tables["CirData"].Rows.Count; i++)
            //        {
            //            try
            //            {
            //                var Service = new Cir.Azure.MobileApp.Service.Utilities.SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            //                Int64 CIRID = Convert.ToInt64(dsCirData.Tables["CirData"].Rows[i]["CirId"]);
            //                var oResponse = Service.UpdatePDFData(CIRID);
            //                log.WriteLine("CIR ID = " + oResponse.CirID + " PDF Updated !");
            //            }
            //            catch (Exception ex)
            //            {
            //                log.WriteLine("CIR Exception error details.!" + ex.Message);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        log.WriteLine("Exception: DataSet Is blank: No data fetched from Database.!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.WriteLine("error " + ex.Message + "Details : " + ex.StackTrace);
            //}
        }
    }
}
