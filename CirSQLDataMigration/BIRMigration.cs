using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirSQLDataMigration
{
    public static class BIRMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public static void GetBIRMigrationData()
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            List<Cir.Azure.MobileApp.Service.CirSyncService.Bir> objlist = Service.GetBirMigrationData();

            foreach (Bir bir in objlist)
            {
                SaveBIRMigrationData(bir);

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bir"></param>
        public static void SaveBIRMigrationData(Bir bir)
        {
            try
            {
                string relatedCirs = "";
                if (!string.IsNullOrEmpty(bir.CirIDs))
                {
                    relatedCirs = bir.CirIDs.Replace('/', ',');
                    relatedCirs = relatedCirs.Substring(relatedCirs.IndexOf(',') + 1);
                }

                SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                BirDataDetails birObj = new BirDataDetails();
                birObj.BirDataID = bir.BirDataID;
                birObj.BirCode = bir.BirCode;
                birObj.CirIDs = bir.CirIDs;
                birObj.BladeSerialNos = bir.BladeSerialNos;
                birObj.ConclusionsAndRecommendations = bir.ConclusionsAndRecommendations;
                birObj.Created = bir.Created;
                birObj.CreatedBy = bir.CreatedBy;
                birObj.Deleted = bir.Deleted;
                birObj.Modified = bir.Modified;
                birObj.ModifiedBy = bir.ModifiedBy;
                birObj.RawMaterials = bir.RawMaterials;
                birObj.RepairingSolutions = bir.RepairingSolutions;
                birObj.RevisionNumber = bir.RevisionNumber;
                birObj.TurbineId = Convert.ToString(bir.TurbineID);
                birObj.IsAnnualInspection = (relatedCirs.Split(',').Count() == 3) ? true : false;
                //Code for new changes                
                birObj.WordBytesUrl = null;

                Service.SaveBirDataDetailstoCosmosDb(birObj, string.Empty);
                Common.SaveSqlLogs(String.Format("MethodName :{0} ,Success: {1}", "MigrationFunctions.SaveBIRMigrationData()", ""), bir.BirDataID, "Blade", LogType.Error, LogType.Success.ToString() + "BIR Id: " + bir.BirDataID + "has been uploaded successfully");

            }
            catch (Exception ex)
            {
                Common.SaveSqlLogs(String.Format("MethodName :{0} ,Error: {1}", "MigrationFunctions.SaveBIRMigrationData()", ex.Message), bir.BirDataID, "Blade", LogType.Error, ex.StackTrace);

            }

        }

    }
}
