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
using Cir.Data.Access.Helpers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CirCosmosDataSync
{
    public class Functions
    {
        public static string DatabaseId = ConfigurationManager.AppSettings["Database"];
        public static string EndPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string CirTemplates = ConfigurationManager.AppSettings["CirTemplateCollection"];
        public static string BrandNames = ConfigurationManager.AppSettings["CirBrandName"];
        public static string _cirSyncLogCollectionName = System.Configuration.ConfigurationManager.AppSettings["CirSyncLogCollection"];
        public static string ComponentInspectionReport = ConfigurationManager.AppSettings["CirCommonBrandColletionName"];
        public static string _crReportHistoryColletion = ConfigurationManager.AppSettings["CirReportHistoryColletion"];
        public const string SqlNotTransferred = "NotTransferred";
        public static string log = string.Empty;

        public static DocumentClient _documentClient = new DocumentClient(new Uri(EndPointURI), PrimaryKey);

        public static void ProcessQueueMessage(TextWriter log, int value, [Queue("queueCosmosData")] out string message)
        {
            message = "Cosmos SQL data Sync Started successfully";
            log.WriteLine(message);
            ReadDocument();
        }

        private static void ReadDocument()
        {
            try
            {
                fetchCosmosData();
            }
            catch (Exception ex)
            {
                SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                string message = "CirCosmosDataSync.ReadDocument()";
                Service.Log(message, ex.Message, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Error);
            }
        }

        private static void fetchCosmosData()
        {
            try
            {
                 string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.cirId in(288483,614728, 614722,612681, 611999)";
               
                //string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.sqlProcessStatus = 'NotTransferred' and c.state in ('" + CirState.Submitted + "','" + CirState.Approved + "','" + CirState.Rejected + "')";
                //string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.sqlProcessStatus = 'NotTransferred' and c.imageProcessStatus='Synced' and c.state in ('" + CirState.Submitted + "','" + CirState.Approved + "','" + CirState.Rejected + "')";
                // string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.lockedBy!='' and  c.lockedBy!=null  and c.modifiedBy!= c.lockedBy";

                List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                        stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();
                foreach (var report in reports)
                {
                    if (report != null &&report.Data !=null)
                    {
                        UnlockCirs(report);
                    }
                    else
                    {
                        SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                        Service.UnlockCirDataByCirID(CirID: 445096);
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
                        string binaryDataFileName = "LockedIssue" + ".txt";
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
        private static void UnlockCirs(CirSubmissionData cir) {
            string _cirLogCollectionName = System.Configuration.ConfigurationManager.AppSettings["CirSyncLogCollection"];
            if (cir.LockedBy != null && cir.LockedBy != "" && cir.LockedBy != cir.ModifiedBy)
            {
                if (string.IsNullOrEmpty(log))
                    log = "CirId : " + cir.CirId + " , Locked By : " + cir.LockedBy + " , Last Modified On : " + cir.ModifiedOn;
                else

                    log = log + " # CirId : " + cir.CirId + " , Locked By : " + cir.LockedBy + " , Last Modified By : " + cir.ModifiedOn;
                cir.LockedBy = null;
                cir.ModifiedOn = DateTime.Now;
                _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, cir.Id), cir);
                SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                Service.UnlockCirDataByCirID(CirID: cir.CirId);
                DeleteFromCirSyncLog(cir, _cirLogCollectionName);
            }
        }

        private static void MapCosmostoSqlDB(Dictionary<string, object> cosmosDictionary, CirSubmissionData objSubmissionData, string cirType, string cirBrandCollectionName, string cirBrandName)
        {
            string message = "CirCosmosDataSync.MapCosmostoSqlDB()";
            string details = string.Empty;
            string _cirLogCollectionName = System.Configuration.ConfigurationManager.AppSettings["CirSyncLogCollection"];
            SyncServiceUtilities Service = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
            try
            {
                IDictionary<string, object> jsonDictionary = null;
                string offlineJson = CIROfflineMappper.GetCIROfflineJSON(cirType);
                jsonDictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(offlineJson);

                ExpandoObject expandoObject1 = new ExpandoObject();
                expandoObject1 = Mapper.Expando(jsonDictionary, cosmosDictionary);

                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport objComp = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport();
                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport>.Copy(expandoObject1, objComp);
                message = "CirCosmosDataSync.PopulateImageData() for CIR id:" + objSubmissionData.CirId;
                Mapper.PopulateImageData(objSubmissionData, objComp, cosmosDictionary, cirType);
                message = "CirCosmosDataSync.PopuateOfflineData() for CIR id:" + objSubmissionData.CirId;
                Mapper.PopuateOfflineData(objComp, objSubmissionData, cosmosDictionary, cirType, cirBrandName);
                var json1 = JsonConvert.SerializeObject(objComp);
                message = "CirCosmosDataSync.SaveCirData() for CIR id:" + objSubmissionData.CirId;
                Cir.Azure.MobileApp.Service.CirSyncService.CirResponse oResponse = Service.SaveCir(objComp);
                details = oResponse.StatusMessage + " for CIR id:" + objSubmissionData.CirId;
                if (oResponse.Status == true)
                {
                    message = "CirCosmosDataSync.UpdateCosmosJson";
                    objSubmissionData.SqlProcessStatus = "Transferred";
                    objSubmissionData.ModifiedOn = DateTime.UtcNow;

                    if (!CheckCirExistsInMainColection(objSubmissionData.CirId))
                    {
                        objSubmissionData.Schema = string.Empty;
                        objSubmissionData.LockedBy = string.Empty;
                        InsertIntoMainCollection(objSubmissionData);
                    }
                    else
                    {
                        objSubmissionData.Schema = string.Empty;
                        objSubmissionData.LockedBy = string.Empty;
                        _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, cirBrandCollectionName, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);
                    }

                    StoreCirRevision(objSubmissionData);
                    #region Submit & Approve CIR
                    if (oResponse.CirDataId > 0 && objSubmissionData.State == CirState.Approved)
                    {
                        string comment = string.Format("{0} by {1} on {2}", "Approved", objSubmissionData.ModifiedBy, DateTime.Now.ToString("dd/MM/yyyy"));
                        bool isSuccess = Service.SetApproved(oResponse.CirDataId, 2, 1, objSubmissionData.ModifiedBy, comment);
                        if (!isSuccess)
                        {
                            message = "CirCosmosDataSync.Submit&ApproveCIR";
                            details = "CIR ID = " + oResponse.CirID + " Cir Approve Error in function Setapprove";
                            Service.Log(message, details, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Error);
                        }
                        else
                        {
                            message = "CirCosmosDataSync.Submit&ApproveCIR";
                            details = "CIR ID = " + oResponse.CirID + " Cir Approved successfully!.";
                            Service.Log(message, details, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Information);
                        }
                    }
                    #endregion Submit & Approve CIR
                }
                else
                {
                    if (string.IsNullOrEmpty(oResponse.InnerExceptionMessage))
                    {
                        details = oResponse.StatusMessage + " for CIR id:" + objSubmissionData.CirId;
                    }
                    else
                    {
                        details = oResponse.InnerExceptionMessage + " for CIR id:" + objSubmissionData.CirId;
                    }
                    objSubmissionData.SqlProcessStatus = "ErrorState# " + details;
                    objSubmissionData.ModifiedOn = DateTime.UtcNow;
                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, cirBrandCollectionName, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);
                    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, _cirLogCollectionName, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);

                }
                message = "CirCosmosDataSync";
                Service.Log(message, details, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Information);
            }
            catch (Exception ex)
            {
                Service.Log(message, ex.Message, Cir.Azure.MobileApp.Service.CirSyncService.LogType.Error);
                objSubmissionData.SqlProcessStatus = "ErrorState#" + ex.Message;
                _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, cirBrandCollectionName, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);
                _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, _cirLogCollectionName, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);


            }
        }

        public static void StoreCirRevision(CirSubmissionData cir)
        {
            var revision = new CirRevisionDetails
            {
                CirSubmissionData = cir
            };



            // InsertIntoReportHistory(revision).Wait();
            ImageData obj = new ImageData();
            obj.InsertRevisionHistory(cir);
        }
        public static async Task InsertIntoReportHistory(object document)
        {
            try
            {
                await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, _crReportHistoryColletion), document).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool CheckCirExistsInMainColection(long cirId)
        {
            return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                              new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                          .Where(f => f.CirId == Convert.ToInt64(cirId)).AsEnumerable().Any();
        }

        public static void InsertIntoMainCollection(CirSubmissionData submisionReport)
        {
            MainCollection(submisionReport).Wait();
        }

        protected static async Task MainCollection(CirSubmissionData submisionReport)
        {
            await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport), submisionReport).ConfigureAwait(false);
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
        public static bool CheckCirExistsInCirSyncLog(string id, string cirLogCollectionName)
        {
            return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                   UriFactory.CreateDocumentCollectionUri(DatabaseId, cirLogCollectionName),
                   new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
               .Where(f => f.Id == id).AsEnumerable().Any();
        }

        public static CirSubmissionData GetByCirId(long cirId, string cirCollectionName)
        {
            return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, cirCollectionName),
                    new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(x => x.CirId == cirId).AsEnumerable().FirstOrDefault();
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

        # region Update Image reference data
       
        public static void UpdateImageReference(CirSubmissionData objSubmissionData, string ComponentInspectionReport)
        {
            IList<ImageDataModel> lstRefrences = objSubmissionData.ImageReferences;

            IList<ImageDataModel> newImageRefrences = new List<ImageDataModel>();

            if (lstRefrences != null && lstRefrences.Count > 0)
            {
                bool isUrlUpdated = false;
                foreach (var lstRefrence in lstRefrences)
                {
                    if (!string.IsNullOrEmpty(lstRefrence.BinaryData) && (lstRefrence.Url.Contains("undefined") || string.IsNullOrEmpty(lstRefrence.BinaryDataUrl) ||
                        lstRefrence.BinaryDataUrl.Contains("undefined") || string.IsNullOrEmpty(lstRefrence.BlobGuid)))
                    {
                        var val = newImageRefrences.Where(x => x.ImageId == lstRefrence.ImageId).FirstOrDefault();
                        if (val == null)
                        {
                            var imgDataString = lstRefrence.BinaryData;
                            var binaryDataStartIndex = imgDataString.IndexOf(",") + 1;
                            var lastIndex = imgDataString.Length - (imgDataString.IndexOf(",") + 1);

                            imgDataString = imgDataString.Substring(binaryDataStartIndex, lastIndex);
                            lstRefrence.BinaryData = imgDataString;


                            var storageAccount = CloudStorageAccount.Parse(GetConnectionString(lstRefrence.Url.Split('/')[2].Split(':')[0]));
                            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                            CloudBlobContainer container = blobClient.GetContainerReference("cirprodcontainer");
                            string dataType = "CIR", blobType = "Images";

                            if (string.IsNullOrEmpty(lstRefrence.BlobGuid) || string.IsNullOrEmpty(lstRefrence.BinaryDataUrl))
                            {
                                lstRefrence.BlobGuid = lstRefrence.ImageId;

                                var binaryDataFileName = $"{lstRefrence.TurbineNumber}/{dataType}/{lstRefrence.CirId}/{blobType}/{lstRefrence.BlobGuid}.{lstRefrence.BinaryContentType}";
                                var imageUrl = "https://" + lstRefrence.Url.Split('/')[2].Split(':')[0];
                                CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                                binaryDataBlockBlob.UploadText(lstRefrence.BinaryData);

                                lstRefrence.BinaryDataUrl = imageUrl + "/cirprodcontainer/" + binaryDataFileName;

                                var imageDataFileName = $"{lstRefrence.TurbineNumber}/{dataType}/{lstRefrence.CirId}/{blobType}/{lstRefrence.BlobGuid}.{lstRefrence.ContentType}";
                                CloudBlockBlob imageBlockBlob = container.GetBlockBlobReference(imageDataFileName);
                                byte[] blobBytes = Convert.FromBase64String(lstRefrence.BinaryData);
                                imageBlockBlob.UploadFromByteArray(blobBytes, 0, blobBytes.Length);

                                lstRefrence.Url = imageUrl + "/cirprodcontainer/" + imageDataFileName;
                                lstRefrence.BinaryData = "";
                                newImageRefrences.Add(lstRefrence);
                                isUrlUpdated = true;
                                if (string.IsNullOrEmpty(log))
                                    log = "CirId : " + objSubmissionData.CirId + " , Created By : " + objSubmissionData.CreatedBy + " , Modified By : " + objSubmissionData.ModifiedBy;
                                else

                                    log = log + " # CirId : " + objSubmissionData.CirId + " , Created By : " + objSubmissionData.CreatedBy + " , Modified By : " + objSubmissionData.ModifiedBy;
                            }
                        }
                    }
                }

                if (isUrlUpdated)
                {
                    foreach (var imageRef in newImageRefrences)
                    {
                        var previouslist = lstRefrences.Where(a => a.ImageId == imageRef.ImageId).ToList();
                        int count = 0;
                        foreach (var lst in previouslist)
                        {
                            var index = lstRefrences.IndexOf(lst);

                            if (index != -1 && count == 0)
                            {
                                lstRefrences[index] = imageRef;
                                count++;
                            }
                            else if (count > 0)
                            {
                                lstRefrences.RemoveAt(index);
                            }

                        }
                    }
                    objSubmissionData.ImageReferences = lstRefrences;
                    objSubmissionData.SqlProcessStatus = "NotTransferred";
                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, objSubmissionData.Id), objSubmissionData).ConfigureAwait(false);


                }
            }
        }

        private static string GetConnectionString(string blobName)
        {
            string connectionString = string.Empty;
            switch (blobName.ToString())
            {
                case "cirprodblobstorage.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString"];
                    break;
                case "cirprodblobstorage1.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString1"]; ;
                    break;
                case "cirprodblobstorage2.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString2"]; ;
                    break;
                case "cirprodblobstorage3.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString3"]; ;
                    break;
                case "cirprodblobstorage4.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString4"]; ;
                    break;
                case "cirprodblobstorage5.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString5"]; ;
                    break;
                case "cirprodblobstorage6.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString6"]; ;
                    break;
                case "cirprodblobstorage7.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString7"]; ;
                    break;
                case "cirprodblobstorage8.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString8"]; ;
                    break;
                case "cirprodblobstorage9.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString9"]; ;
                    break;
                case "cirprodblobstorage10.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString10"]; ;
                    break;
                case "cirprodblobstorage11.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString11"]; ;
                    break;
                case "cirprodblobstorage12.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString12"]; ;
                    break;
                case "cirprodblobstorage13.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString13"]; ;
                    break;
                case "cirprodblobstorage14.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString14"]; ;
                    break;
                case "cirprodblobstorage15.blob.core.windows.net":
                    connectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString15"]; ;
                    break;
                default:
                    break;
            }
            return connectionString;
        }

        #endregion  

    }
}
