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
    public static class SecondNotificationMigration
    {
        /// <summary>
        /// This is use to getGIR data and 
        /// Also call method for SAVE GIR data
        /// </summary>
        public static void SaveSecondNotificationMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            SecondNotificationDetails objSecondNotificationDetails = null;
            bool retFlag = false;
            string message = "SecondNotificationMigration.SaveNotificationMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            try
            {
                retFlag = Service.SaveSecondNotificationDataDetailstoCosmosDb(objSecondNotificationDetails, string.Empty);
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "SecondNotificationMigration",
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + "Second Notification save in CosmosDB successfully and Return Flag is "+ retFlag,
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
                        CirType = "Second Notification Not Found",
                        CirDataId = 0,
                        Message = "SecondNotificationMigration.GetSecondNotificationList()",
                        Details = ex.InnerException.Message ?? ex.Message,
                        Timestamp = DateTime.UtcNow
                    };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }

        /// <summary>
        /// This is use to SAVE GIR data into Container and cosmosDB        
        /// </summary>
        /// <param name="objSN"></param>
        /// <param name="Service"></param>
        public static void SaveSecondNotificationMigrationData(SecondNotificationDetails objSN, SyncServiceUtilities Service)
        {
            bool retFlag = false;
            string message = "SecondNotificationMigration.SaveNotificationMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            SecondNotificationDetails objSecondNotificationDetails = new SecondNotificationDetails();
            CirAttachmentsDetails objCirAttachment = new CirAttachmentsDetails();
            try
            {
                objSecondNotificationDetails.SecondNotificationId = objSN.SecondNotificationId;
                objSecondNotificationDetails.ComponentInspectionReportId = objSN.ComponentInspectionReportId;
                objSecondNotificationDetails.SendOn = objSN.SendOn;
                objSecondNotificationDetails.ManufacturerId = objSN.ManufacturerId;
                objSecondNotificationDetails.SBUId = objSN.SBUId;
                objSecondNotificationDetails.ComponentType = objSN.ComponentType;
                objSecondNotificationDetails.CIRTemplate = objSN.CIRTemplate;
                objSecondNotificationDetails.CIMCaseNumber = objSN.CIMCaseNumber;
                objSecondNotificationDetails.TurbineMatrixId = objSN.TurbineMatrixId;
                objSecondNotificationDetails.CirDataId = objSN.CirDataId;               
                objCirAttachment.CirAttachmentId = objSN.cirAttachments.CirAttachmentId;
                objCirAttachment.Filename = objSN.cirAttachments.Filename;
                 objCirAttachment.BinaryData = objSN.cirAttachments.BinaryData;

                retFlag = Service.SaveSecondNotificationDataDetailstoCosmosDb(objSecondNotificationDetails, string.Empty);
                string uploaded = (retFlag) ? "uploaded" : "not uploaded";
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirType = "Component Inspection Report Id : " + objSN.ComponentInspectionReportId + "SecondNotification Id:" + objSN.SecondNotificationId,
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + " SecondNotification Id: " + objSN.SecondNotificationId + " has " + uploaded + " into CosmosDB successfully",
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
                    CirType = "Component Inspection Report Id : " + objSN.ComponentInspectionReportId + "SecondNotification Id:" + objSN.SecondNotificationId,
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
