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
    public static class  RejectNotificationMigration
    {
        /// <summary>
        /// This is use to getGIR data and 
        /// Also call method for SAVE GIR data
        /// </summary>
        public static void SaveRejectNotificationMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            bool retFlag = false;
            string message = "RejectNotificationMigration.SaveRejectNotificationMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            RejectNotificationDetails objRejectNotificationDetails = null;
            try
            {
                retFlag = Service.SaveRejectNotificationDataDetailstoCosmosDb(objRejectNotificationDetails, string.Empty);
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "0",
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + "  has save CosmosDB successfully"+"Return Falg is"+ retFlag,
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
                        CirId = 0,
                        CirType = "Reject Notification Not Found",
                        CirDataId = 0,
                        Message = "RejectNotificationMigration.GetRejectNotificationList()",
                        Details = ex.InnerException.Message ?? ex.Message,
                        Timestamp = DateTime.UtcNow
                    };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }

        /// <summary>
        /// This is use to SAVE GIR data into Container and cosmosDB        
        /// </summary>
        /// <param name="objRN"></param>
        /// <param name="Service"></param>
        public static void SaveRejectNotificationMigrationData1(RejectNotificationDetails objRN, SyncServiceUtilities Service)
        {
            bool retFlag = false;
            string message = "RejectNotificationMigration.SaveRejectNotificationMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            RejectNotificationDetails objRejectNotificationDetails = new RejectNotificationDetails();
            CirAttachmentsDetails objCirAttachment = new CirAttachmentsDetails();
            try
            {
                objRejectNotificationDetails.RejectNotificationId = objRN.RejectNotificationId;
                objRejectNotificationDetails.ComponentInspectionReportId = objRN.ComponentInspectionReportId;
                objRejectNotificationDetails.SendOn = objRN.SendOn;
                objRejectNotificationDetails.InfoPathFilename = objRN.InfoPathFilename;
                objRejectNotificationDetails.SendTo = objRN.SendTo;
                objRejectNotificationDetails.RejectedBy = objRN.RejectedBy;
                objRejectNotificationDetails.Comment = objRN.Comment;
                objRejectNotificationDetails.Received = objRN.Received;
                objRejectNotificationDetails.SBUId = objRN.SBUId;
                objRejectNotificationDetails.CIMCaseNo = objRN.CIMCaseNo;
              objRejectNotificationDetails.TurbineNumber = objRN.TurbineNumber;
                objCirAttachment.CirAttachmentId = objRN.cirAttachments.CirAttachmentId;
                objCirAttachment.Filename = objRN.cirAttachments.Filename;
                 objCirAttachment.BinaryData = objRN.cirAttachments.BinaryData;

                retFlag = Service.SaveRejectNotificationDataDetailstoCosmosDb(objRejectNotificationDetails, string.Empty);
                string uploaded = (retFlag) ? "uploaded" : "not uploaded";
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "Component Inspection Report Id : " + objRN.ComponentInspectionReportId + "RejectNotification Id:" + objRN.RejectNotificationId,
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + " RejectNotification Id: " + objRN.RejectNotificationId + " has " + uploaded + " into CosmosDB successfully",
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
                    CirType = "Component Inspection Report Id : " + objRN.ComponentInspectionReportId + "RejectNotification Id:" + objRN.RejectNotificationId,
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
