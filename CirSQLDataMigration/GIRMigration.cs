using System;
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
using System.Collections.Generic;

namespace CirSQLDataMigration
{
    public static class GIRMigration
    {
        /// <summary>
        /// This is use to getGIR data and 
        /// Also call method for SAVE GIR data
        /// </summary>
        public static void GetGIRMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            try
            {
                List<Cir.Azure.MobileApp.Service.CirSyncService.Gir> lstObjGir = Service.GetGirMigrationData();

                foreach (Cir.Azure.MobileApp.Service.CirSyncService.Gir objGir in lstObjGir)
                {
                    SaveGIRMigrationData(objGir, Service);
                }
            }
            catch (Exception ex)
            {
                Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging
                    = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                    {
                        LogType = (short)LogType.Error,
                        CirId = 0L,
                        CirType = "Generator",
                        CirDataId = 0,
                        Message = "GIRMigration.GetGIRMigrationData()",
                        Details = Convert.ToString(ex.Message),
                        Timestamp = DateTime.UtcNow
                    };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }
        /// <summary>
        /// This is use to SAVE GIR data into Container and cosmosDB        
        /// </summary>
        /// <param name="objGir"></param>
        /// <param name="Service"></param>
        public static void SaveGIRMigrationData(Gir objGir, SyncServiceUtilities Service)
        {
            bool retFlag = false;
            string message = "GIRMigration.SaveGIRMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            GirDataDetails objGirDetails = new GirDataDetails();
            try
            {
                objGirDetails.GirDataID = objGir.GirDataID;
                objGirDetails.GirCode = objGir.GirCode;
                objGirDetails.CirIDs = objGir.CirIDs;
                objGirDetails.GeneralSerialNos = objGir.GeneralSerialNos;
                objGirDetails.ConclusionsAndRecommendations = objGir.ConclusionsAndRecommendations;
                objGirDetails.Created = objGir.Created;
                objGirDetails.CreatedBy = objGir.CreatedBy;
                objGirDetails.Deleted = objGir.Deleted;
                objGirDetails.Modified = objGir.Modified;
                objGirDetails.ModifiedBy = objGir.ModifiedBy;
                objGirDetails.ClassificationOfDamage = objGir.ClassificationOfDamage;
                objGirDetails.RevisionNumber = objGir.RevisionNumber;
                objGirDetails.TurbineId = Convert.ToString(objGir.TurbineID);
                objGirDetails.AnalysisOfPicture = objGir.AnalysisOfPicture;
                objGirDetails.AnalysisOfMeasurments = objGir.AnalysisOfMeasurments;
                objGirDetails.WordBytesUrl = null;
                
                retFlag = Service.SaveGirDataDetailstoCosmosDb(objGirDetails, string.Empty);
                string uploaded = (retFlag) ? "uploaded" : "not uploaded";
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirId = objGir.GirDataID,
                    CirType = "Generator: " + objGir.GirCode,
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + " GIR Id: " + objGir.GirDataID + " has " + uploaded+ " into CosmosDB successfully",
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);

            }
            catch (Exception ex)
            {
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (short)LogType.Error,
                    CirId = objGir.GirDataID,
                    CirType = "Generator: " + objGir.GirCode,
                    CirDataId = 0,
                    Message = message,
                    Details = Convert.ToString(ex.Message),
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }
    }
}
