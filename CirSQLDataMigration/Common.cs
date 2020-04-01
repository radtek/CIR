using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirSQLDataMigration
{
    public static class Common
    {
        public static void SaveSqlLogs(string message, long cirId, string cirType, LogType logType, string details)
        {
            SyncServiceClient _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
            Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging objMigrationStepLogging =
                new Cir.Azure.MobileApp.Service.CirSyncService.MigrationStepLogging
                {
                    LogType = (short)logType,
                    CirId = cirId,
                    CirType = cirType,
                    Message = message,
                    Details = details,
                    CirDataId = 0,

                    Timestamp = DateTime.UtcNow
                };
            bool retValue = _serviceClient.SqlToCosmosDBMigrationLog(objMigrationStepLogging);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirsubmissionobj"></param>
        /// <param name="cirdataId"></param>
        private static void SaveRevisonDataInToCosmosDb(CirSubmissionData cirsubmissionobj, long cirdataId)
        {
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            try
            {
                List<CirRevision> revisonlist = Service.GetCirRevision(cirdataId);
                short revisonCount = 2;
                if (null != revisonlist)
                {
                    foreach (CirRevision revisionobj in revisonlist)
                    {
                        cirsubmissionobj.ModifiedBy = revisionobj.EditedBy;
                        cirsubmissionobj.ModifiedOn = revisionobj.EditedOn;
                        cirsubmissionobj.LockedBy = revisionobj.LockedBy;
                        cirsubmissionobj.State = (CirState)revisionobj.CirState;
                        cirsubmissionobj.Revision = revisonCount;
                        AddRevisionHistory(cirsubmissionobj);
                        revisonCount++;
                    }
                }
                Common.SaveSqlLogs(String.Format("MethodName :{0} ,Success: {1}", "MigrationFunctions.SaveRevisonDataintocosmosdb()", ""), cirsubmissionobj.CirId, "", LogType.Success, LogType.Success.ToString() + ": Cir Id: " + cirsubmissionobj.CirId + " has been uploaded successfully");
            }
            catch (Exception ex)
            {
                Common.SaveSqlLogs(String.Format("MethodName :{0} ,Error: {1}", "MigrationFunctions.SaveRevisonDataintocosmosdb()", ex.Message), cirsubmissionobj.CirId, "", LogType.Error, ex.StackTrace);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cir"></param>
        public static void AddRevisionHistory(CirSubmissionData cir)
        {
            try
            {
                InsertRevisionHistory(cir);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cir"></param>
        public static void InsertRevisionHistory(CirSubmissionData cir)
        {
            try
            {
                CloudBlobClient blobClient;
                CloudBlobContainer container;

                // binaryDataBlockBlob.Metadata.Add("fileName", fileName);
                //binaryDataBlockBlob.UploadFromByteArray(wordBytes, 0, wordBytes.Length);

                string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageContainerName"];
                var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExists();

                string dataType = "CIR", blobType = "RevisionHistory", contentType = "json";
                var guidKey = GetKey(container);

                var binaryDataFileName = $"{cir.Data["txtTurbineNumber"]}/{dataType}/{cir.Id}/{blobType}/{guidKey}.{contentType}";

                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName); //new CloudBlockBlob(GetBlobUri(binaryDataFileName));

                binaryDataBlockBlob.Properties.ContentType = contentType;
                var revision = new CirRevisionDetails
                {
                    CirSubmissionData = cir
                };
                revision.Id = guidKey;
                revision.CirSubmissionData.Schema = "";
                using (var ms = new MemoryStream())
                {
                    // LoadStreamWithJson(ms, revision);
                    var json = JsonConvert.SerializeObject(revision);
                    StreamWriter writer = new StreamWriter(ms);
                    writer.Write(json);
                    writer.Flush();
                    ms.Position = 0;
                    binaryDataBlockBlob.UploadFromStream(ms);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static string GetKey(CloudBlobContainer container)
        {
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobUri(key));
            return (!blockBlob.Exists()) ? key : GetKey(container);
        }

        public static Uri GetBlobUri(string blobName)
        {
            CloudBlobClient blobClient;
            CloudBlobContainer container;

            string containerName = string.Empty;
            containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageContainerName"];
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            //var storedPolicy = new SharedAccessBlobPolicy()
            //{
            //    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
            //    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Delete
            //};
            //var permissions = container.GetPermissions();
            //permissions.SharedAccessPolicies.Clear();
            //permissions.SharedAccessPolicies.Add(policyName, storedPolicy);
            //container.SetPermissions(permissions);
            //var sasBlobToken = blockBlob.GetSharedAccessSignature(null, policyName);
            Uri blobUri = new Uri(Convert.ToString(blockBlob.Uri));
            return blobUri;

        }

        /// <summary>
        /// Get TemplateVersion From ComponentInspectionReport
        /// </summary>
        /// <param name="objComp"></param>
        /// <returns></returns>
        public static double GetTemplateVersionFromCIRReport(string TemplateVersion)
        {
            double CosmosVersion = 0;
            switch (TemplateVersion.Trim())
            {
                case "9":
                    CosmosVersion = 1;
                    break;
                case "8":
                    CosmosVersion = 0.8;
                    break;
                case "7":
                    CosmosVersion = 0.7;
                    break;
                case "6":
                    CosmosVersion = 0.6;
                    break;
                case "5":
                    CosmosVersion = 0.5;
                    break;
                case "4.1":
                    CosmosVersion = 0.41;
                    break;
                case "4":
                    CosmosVersion = 0.4;
                    break;
                case "3":
                    CosmosVersion = 0.3;
                    break;
                case "2":
                    CosmosVersion = 0.2;
                    break;
                case "1":
                    CosmosVersion = 0.1;
                    break;
                default:
                    CosmosVersion = 1;
                    break;
            }
            return CosmosVersion;
        }
    }
}
