using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Cir.Data.Access.Models;
using System.Configuration;
using System.Dynamic;
using System.Collections;
using Cir.Azure.MobileApp.Service.Utilities;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CirLockUnlockJob
{
    public class Functions
    {
        public static string DatabaseId = ConfigurationManager.AppSettings["Database"];
        public static string EndPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string CirTemplates = ConfigurationManager.AppSettings["CirTemplateCollection"];
        public static string BrandNames = ConfigurationManager.AppSettings["CirBrandName"];
        public static string _cirSyncLogCollectionName = ConfigurationManager.AppSettings["CirSyncLogCollection"];
        public static string ComponentInspectionReport = ConfigurationManager.AppSettings["CirCommonBrandColletionName"];
        public static string _crReportHistoryColletion = ConfigurationManager.AppSettings["CirReportHistoryColletion"];
        public static DocumentClient _documentClient = new DocumentClient(new Uri(EndPointURI), PrimaryKey);
        public static CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
        public static CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        public static CloudBlobContainer sourceContainer = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageContainerName"]);
        public static string dataType = "CIR";
        public static string blobStorage = ConfigurationManager.AppSettings["StorageConnection"];

        public static long cirId = 0;
        public static string cirTemplateName = "";
        public static string log = string.Empty;
        public static void ProcessQueueMessage(TextWriter loge, int value, [Queue("queueCosmosData")] out string message)
        {
            message = "Cosmos SQL data Sync Started successfully";
            loge.WriteLine(message);
            ReadCosmos();

        }
        private static void ReadCosmos()
        {
            try
            {
                string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.lockedBy!='' and  c.lockedBy!=null  and c.modifiedBy!= c.lockedBy and c.modifiedOn >='"+ DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss.ff")+ "'";


                List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                        stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();
                foreach (var report in reports)
                {
                    if (report != null && report.Data != null)
                    {
                        UnlockCirs(report);
                    }
                }

                #region  Saving Logs in Azure , if required uncomment code

                if (!string.IsNullOrEmpty(log))
                {

                    try
                    {
                        var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                        CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageLogContainerName"]);
                        string binaryDataFileName = "LockUnlockCirs" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt";
                        CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                        if (binaryDataBlockBlob.Exists())
                        {
                            string downloadedLog = binaryDataBlockBlob.DownloadText();
                            log = downloadedLog + " # " + log;
                        }
                        binaryDataBlockBlob.UploadText(log);
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                string message = "CirCosmosDataSync.fetchCosmosData()";
                Service.Log(message, ex.Message, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Error);
            }
        }
        private static void UnlockCirs(CirSubmissionData cir)
        {
            string _cirLogCollectionName = System.Configuration.ConfigurationManager.AppSettings["CirSyncLogCollection"];
            if (cir.LockedBy != null && cir.LockedBy != "" && cir.LockedBy != cir.ModifiedBy)
            {
                if (string.IsNullOrEmpty(log))
                    log = "CirId : " + cir.CirId + " , Locked By : " + cir.LockedBy + " , Last Modified On : " + cir.ModifiedOn;
                else

                    log = log + " # CirId : " + cir.CirId + " , Locked By : " + cir.LockedBy + " , Last Modified On : " + cir.ModifiedOn;
                cir.LockedBy = null;
                cir.ModifiedOn = DateTime.Now;
              //_documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, _cirLogCollectionName, cir.Id), cir);
               _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, cir.Id), cir);
                SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                Service.UnlockCirDataByCirID(CirID: cir.CirId);
                DeleteFromCirSyncLog(cir, _cirLogCollectionName);
            }
        }
        public static void DeleteFromCirSyncLog(CirSubmissionData report, string cirLogCollectionName)
        {
            DeleteDraftCir(report, cirLogCollectionName).Wait();
        }

        protected static async Task DeleteDraftCir(CirSubmissionData report, string cirLogCollectionName)
        {
            if (CheckCirExistsInCirSyncLog(report.Id, cirLogCollectionName))
            {
                await _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, cirLogCollectionName, report.Id),
                       new RequestOptions { PartitionKey = new PartitionKey(keyValue: getPartition(report.CirId)) }
                       );
            }
        }
        public static string getPartition(Int64 cirId)
        {
            string partitionName;
            decimal partitionValue;

            if (ConfigurationManager.AppSettings["PartitionDivisionValue"] != null)
                partitionValue = (cirId / Convert.ToInt64(ConfigurationManager.AppSettings["PartitionDivisionValue"]));
            else
                partitionValue = (cirId / 50000);

            partitionName = "partition" + (int)partitionValue;

            return partitionName;
        }
        public static bool CheckCirExistsInCirSyncLog(string id, string cirLogCollectionName)
        {
            return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                   UriFactory.CreateDocumentCollectionUri(DatabaseId, cirLogCollectionName),
                   new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
               .Where(f => f.Id == id).AsEnumerable().Any();
        }

    }
}
