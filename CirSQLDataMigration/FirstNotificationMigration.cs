using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections;
using Cir.Azure.MobileApp.Service.Utilities;
using Serilog;
using System.Net;
using System.Web.Script.Serialization;
using Cir.Data.Access.Models;
using System.Text;
using Cir.Azure.MobileApp.Service.CirSyncService;
using Newtonsoft.Json.Linq;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CirSQLDataMigration
{
    public static class FirstNotificationMigration
    {
        /// <summary>
        /// This is use to getGIR data and 
        /// Also call method for SAVE GIR data
        /// </summary>
        public static void SaveNotificationMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            bool retFlag = false;
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            Cir.Azure.MobileApp.Service.CirSyncService.FirstNotificationDetails objFN = null;
            try
            {
                retFlag = Service.SaveFirstNotificationDataDetailstoCosmosDb(objFN, string.Empty);

                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "Component Inspection Report Id : " + objFN.ComponentInspectionReportId + "FirstNotification Id:" + objFN.FirstNotificationId,
                    CirDataId = 0,
                    Message = "firstNotificationMigration.SaveNotificationMigrationData()",
                    Details = LogType.Success.ToString() + "  has save in CosmosDB successfully",
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }

            catch (Exception ex)
            {
                 objMigrationStepLogging
                    = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                    {
                        LogType = (short)LogType.Error,
                        CirId = 0L,
                        CirType = "First Notification Not Found",
                        CirDataId = 0,
                        Message = "firstNotificationMigration.GetNotifications()",
                        Details = ex.InnerException.Message ?? ex.Message,
                        Timestamp = DateTime.UtcNow
                    };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }

        /// <summary>
        /// This is use to SAVE GIR data into Container and cosmosDB        
        /// </summary>
        /// <param name="objFN"></param>
        /// <param name="Service"></param>
        public static void SaveNotificationMigrationData1(FirstNotificationDetails objFN, SyncServiceUtilities Service)
        {
            bool retFlag = false;
            string message = "firstNotificationMigration.SaveNotificationMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            FirstNotificationDetails objFirstNotificationDetails = new FirstNotificationDetails();
            CirAttachmentsDetails objCirAttachment = new CirAttachmentsDetails();
            try
            {
                objFirstNotificationDetails.FirstNotificationId = objFN.FirstNotificationId;
                objFirstNotificationDetails.ComponentInspectionReportId = objFN.ComponentInspectionReportId;
                objFirstNotificationDetails.SendOn = objFN.SendOn;
                objFirstNotificationDetails.SBUId = objFN.SBUId;
                objFirstNotificationDetails.EditDate = objFN.EditDate;
                objFirstNotificationDetails.EditInitials = objFN.EditInitials;
                objFirstNotificationDetails.TurbineMatrixId = objFN.TurbineMatrixId;
                objFirstNotificationDetails.CirDataId = objFN.CirDataId;
                objFirstNotificationDetails.Sitename = objFN.Sitename;
                objFirstNotificationDetails.CountryISOId = objFN.CountryISOId;
                objFirstNotificationDetails.ComponentType = objFN.ComponentType;
                objFirstNotificationDetails.CommisioningDate = objFN.CommisioningDate;
                objFirstNotificationDetails.FailureDate = objFN.FailureDate;
                objFirstNotificationDetails.QueuedOn = objFN.QueuedOn;
                objCirAttachment.CirAttachmentId = objFN.cirAttachments.CirAttachmentId;
                objCirAttachment.Filename = objFN.cirAttachments.Filename;
                 objCirAttachment.BinaryData = objFN.cirAttachments.BinaryData;


                retFlag = Service.SaveFirstNotificationDataDetailstoCosmosDb(objFirstNotificationDetails, string.Empty);
                string uploaded = (retFlag) ? "uploaded" : "not uploaded";
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "Component Inspection Report Id : " + objFN.ComponentInspectionReportId + "FirstNotification Id:" + objFN.FirstNotificationId,
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + " FirstNotification Id: " + objFN.FirstNotificationId + " has " + uploaded + " into CosmosDB successfully",
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);

            }
            catch (Exception ex)
            {
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (short)LogType.Error,
                    //CirId = objFN.GirDataID,
                    CirType = "Component Inspection Report Id : " + objFN.ComponentInspectionReportId + "FirstNotification Id:" + objFN.FirstNotificationId,
                    CirDataId = 0,
                    Message = message,
                    Details = ex.InnerException.Message ?? ex.Message,
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }

    }
}
