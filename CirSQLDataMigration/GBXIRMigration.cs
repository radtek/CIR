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
    public static class GBXIRMigration
    {
        /// <summary>
        /// This is use to getGBXIR data and also call method 
        /// for SAVE GBXIR data into CosmosDB & Azure container
        /// </summary>
        public static void GetGBXIRMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            try
            {
                List<Cir.Azure.MobileApp.Service.CirSyncService.Gbx> lstObjGbxir = Service.GetGBXirMigrationData();

                foreach (Cir.Azure.MobileApp.Service.CirSyncService.Gbx objGbxir in lstObjGbxir)
                {
                    SaveGBXIRMigrationData(objGbxir, Service);
                }
            }
            catch (Exception ex)
            {
                Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging
                    = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                    {
                        LogType = (short)LogType.Error,
                        CirId = 0L,
                        CirType = "Gearbox",
                        CirDataId = 0,
                        Message = "GBXIRMigration.GetGBXIRMigrationData()",
                        Details = Convert.ToString(ex.Message),
                        Timestamp = DateTime.UtcNow
                    };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);
            }
        }
        /// <summary>
        /// This is use to SAVE GBXIR data into Container and cosmosDB        
        /// </summary>
        /// <param name="objGbx"></param>
        /// <param name="Service"></param>
        public static void SaveGBXIRMigrationData(Gbx objGbx, SyncServiceUtilities Service)
        {
            bool retFlag = false;
            string message = "GBXIRMigration.SaveGBXIRMigrationData()";
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging = null;
            Cir.Azure.MobileApp.Service.CirSyncService.GBXirDataDetails objGbxirDetails = new
                Cir.Azure.MobileApp.Service.CirSyncService.GBXirDataDetails();
            try
            {
                //need to update the following fields
                objGbxirDetails.GbxDataID = objGbx.GbxDataID;
                objGbxirDetails.GbxCode = objGbx.GbxCode;
                objGbxirDetails.CirIDs = objGbx.CirIDs;
                objGbxirDetails.GearboxSerialNos = objGbx.GearboxSerialNos;
                objGbxirDetails.ConclusionsAndRecommendations = objGbx.ConclusionsAndRecommendations;
                objGbxirDetails.Created = objGbx.Created;
                objGbxirDetails.CreatedBy = objGbx.CreatedBy;
                objGbxirDetails.Deleted = objGbx.Deleted;
                objGbxirDetails.Modified = objGbx.Modified;
                objGbxirDetails.ModifiedBy = objGbx.ModifiedBy;                
                objGbxirDetails.RevisionNumber = objGbx.RevisionNumber;
                objGbxirDetails.TurbineId = Convert.ToString(objGbx.TurbineID);
                objGbxirDetails.Analysis = objGbx.Analysis;
                objGbxirDetails.OilAnalysis = objGbx.OilAnalysis;
                objGbxirDetails.CMSAnalysis = objGbx.CMSAnalysis;
                objGbxirDetails.WordBytesUrl = null;
                
                retFlag = Service.SaveGBXirDataDetailstoCosmosDb(objGbxirDetails, string.Empty);
                string uploaded = (retFlag) ? "uploaded" : "not uploaded";
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (retFlag) ? (short)LogType.Success : (short)LogType.Error,
                    CirId = objGbx.GbxDataID,
                    CirType = "Gearbox: " + objGbx.GbxCode,
                    CirDataId = 0,
                    Message = message,
                    Details = LogType.Success.ToString() + " GBXIR Id: " + objGbx.GbxDataID + " has " + uploaded+ " into CosmosDB successfully",
                    Timestamp = DateTime.UtcNow
                };
                bool retValue = Service.SaveSqlToCosmosDBMigrationLog(objMigrationStepLogging);

            }
            catch (Exception ex)
            {
                objMigrationStepLogging = new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (short)LogType.Error,
                    CirId = objGbx.GbxDataID,
                    CirType = "Gearbox: " + objGbx.GbxCode,
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
