using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Utilities;

namespace UpdateExistingPDFData
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        [NoAutomaticTrigger]
        public static void UpdatePDFData(TextWriter log, int value, [Queue("queuePDFData")] out string message)
        {
            //message = value.ToString();
            log.WriteLine("UpdatePDFData Started at " + System.DateTime.Now);

            try
            {
                var Service =new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                var oResponse = Service.UpdatePDFData();
                log.WriteLine("CIR ID = " + oResponse.CirID + " PDF Updated !");
                message = oResponse.ToString();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                log.WriteLine("CIR Exception error details.!" + ex.Message);
            }
        }


    }
}
