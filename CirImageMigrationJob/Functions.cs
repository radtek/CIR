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
using Newtonsoft.Json.Linq;
using System.Reflection;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.Helpers;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CirImageMigrationJob
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
        public static string versionNumber = ConfigurationManager.AppSettings["VersionNumber"];
        public static long cirId = 0;
        public static string cirTemplateName = "";
        public static void ProcessQueueMessage(TextWriter log, int value, [Queue("queueCosmosData")] out string message)
        {
            try
            {
                message = "Image Migration Job Started successfully";
                log.WriteLine(message);
                CopyCirData();
                Console.WriteLine("Web Job has finished.");
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "MigrationFunctions.ReadDocument()"), 0, "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                message = "Image Migration Job Failed" + ex.Message;
            }

        }
        public static List<CirSubmissionData> GetCirData()
        {
            try
            {
                List<CirSubmissionData> cirRecords = new List<CirSubmissionData>();
                Uri uriGetCirList = UriFactory.CreateStoredProcedureUri(DatabaseId, ComponentInspectionReport, "GetCIRMigrationListRange");
                var result = (_documentClient.ExecuteStoredProcedureAsync<string>(uriGetCirList, new RequestOptions() { PartitionKey = new PartitionKey(keyValue: "partition6") }).Result);
                if (result.Response.Contains("#"))
                {
                    string[] Points = result.Response.Split('#');
                    var stringPoint = Points[0]; var endingPoint = Points[1];
                    var TemplateVersion = Points[2]; var otherWhereClause = Points[3];

                    string stQry = "SELECT* FROM  c WHERE c.templateVersion = " + TemplateVersion + " and c.cirId <= " + stringPoint + " and c.cirId >= " + endingPoint + " " + otherWhereClause + "";

                    cirRecords = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                                 UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                           stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();

                }
                return cirRecords;
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.GetCirData()"), 0, "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                throw;
            }
        }

        public static void CopyCirData()
        {
            List<CirSubmissionData> cirRecords = GetCirData();
            foreach (CirSubmissionData cirRecord in cirRecords)
            {
                try
                {
                    string turbineNumber = cirRecord.Data["txtTurbineNumber"] == null ? "" : Convert.ToString(cirRecord.Data["txtTurbineNumber"].Value);
                    int destinationStorageBlob = GetStorageAccount(cirRecord.Id);
                    CloudStorageAccount destinationStorageAccount = destinationStorageBlob == 0 ? CloudStorageAccount.Parse(ConfigurationManager.AppSettings[blobStorage]) : CloudStorageAccount.Parse(ConfigurationManager.AppSettings[blobStorage + Convert.ToString(destinationStorageBlob)]);
                    CloudBlobClient destBlobClient = destinationStorageAccount.CreateCloudBlobClient();
                    CloudBlobContainer destinationContainer = destBlobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageContainerName"]);
                    string destinationSasKey = GetBlobSASUri(Convert.ToString(destinationStorageBlob));
                    string sourceSasKey = string.Empty;
                    string dataType = "CIR", blobType = "Images", blobExtn = "jpeg";
                    List<ImageDataModel> imageRefList = new List<ImageDataModel>();
                    if (cirRecord.ImageReferences != null)
                    {
                        foreach (var imageRef in cirRecord.ImageReferences)
                        {
                            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                            string sourceStorageHost = imageRef.Url.Split('.')[0];
                            string sourceStorageBlob = Regex.Match(sourceStorageHost, @"\d+").Value;
                            sourceSasKey = GetBlobSASUri(sourceStorageBlob);
                            string sourceUriString = imageRef.Url + sourceSasKey;
                            CloudBlockBlob sourceBlob = new CloudBlockBlob(new Uri(sourceUriString));
                            string destinationUriString = string.Empty;
                            string blobPath = $"{turbineNumber}/{dataType}/{cirRecord.Id}/{blobType}/{imageRef.BlobGuid}.{blobExtn}";
                            if (sourceBlob.Exists())
                            {
                                destinationUriString = destinationContainer.Uri.ToString() + "/" + blobPath + destinationSasKey;
                                CloudBlockBlob destinationBlob = new CloudBlockBlob(new Uri(destinationUriString));
                                destinationBlob.StartCopy(sourceBlob);
                                imageRef.Url = destinationBlob.Uri.AbsoluteUri;
                            }
                            string sourceUriStringText = sourceUriString.Replace("jpeg", "txt");
                            CloudBlockBlob sourceBlobText = new CloudBlockBlob(new Uri(sourceUriStringText));
                            if (sourceBlobText.Exists())
                            {
                                string destinationUriStringText = destinationUriString.Replace("jpeg", "txt");
                                CloudBlockBlob destinationBlobText = new CloudBlockBlob(new Uri(destinationUriStringText));
                                destinationBlobText.StartCopy(sourceBlobText);
                                imageRef.BinaryDataUrl = destinationBlobText.Uri.AbsoluteUri;
                            }
                            imageRef.CirId = cirRecord.Id;
                            imageRefList.Add(imageRef);
                        }
                        SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyCirData()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "Image(s) uploaded successfully in Blob");
                        cirRecord.ImageReferences = imageRefList;
                        UpdateImageReferenceInCosmos(cirRecord);
                    }
                    else
                    {
                        SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyCirData()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "Images not found");
                    }
                    sourceSasKey = GetBlobSASUri("0");
                    CopyRevisionHistoryDocumentInMultipleBlob(cirRecord, sourceSasKey, destinationSasKey, turbineNumber, destinationContainer);
                    CopyPdfDocumentInMultipleBlob(cirRecord, sourceSasKey, destinationSasKey, turbineNumber, destinationContainer);
                }
                catch (Exception ex)
                {
                    SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.UpdateImageReference()"), cirRecord.CirId, cirRecord.CirTemplateName, LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                }
            }
        }

        public static void UpdateImageReferenceInCosmos(CirSubmissionData cirRecord)
        {
            try
            {
                _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, cirRecord.Id), cirRecord).ConfigureAwait(false);
                SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.UpdateImageReferenceInCosmos()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "Image(s) uploaded successfully in Cosmos");
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.UpdateImageReferenceInCosmos()"), cirRecord.CirId, cirRecord.CirTemplateName, LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
            }
        }

        public static void CopyRevisionHistoryDocumentInMultipleBlob(CirSubmissionData cirRecord, string sourceSasKey, string destinationSasKey, string turbineNumber, CloudBlobContainer destinationContainer)
        {
            try
            {
                string dataType = "CIR", blobType = "RevisionHistory";
                var birList = sourceContainer.ListBlobsSegmented($"{turbineNumber}/{dataType}/{cirRecord.Id}/{blobType}", true, BlobListingDetails.Metadata, null, null, null, null);
                var latestBir = birList.Results;
                string destinationUriString = string.Empty;

                if (latestBir.Count() > 0)
                {
                    foreach (CloudBlob item in latestBir)
                    {
                        CloudBlockBlob sourceBlob = new CloudBlockBlob(new Uri(sourceContainer.Uri.ToString() + "/" + item.Name + sourceSasKey));
                        destinationUriString = destinationContainer.Uri.ToString() + "/" + item.Name + destinationSasKey;
                        CloudBlockBlob destinationBlob = new CloudBlockBlob(new Uri(destinationUriString));
                        destinationBlob.StartCopy(sourceBlob);
                    }

                    SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyRevisionHistoryDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "Revision History uploaded successfully");
                }

                else
                    SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyRevisionHistoryDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "Revision History not found");
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.CopyRevisionHistoryDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName, LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
            }
        }

        public static void CopyPdfDocumentInMultipleBlob(CirSubmissionData cirRecord, string sourceSasKey, string destinationSasKey, string turbineNumber, CloudBlobContainer destinationContainer)
        {
            try
            {
                string dataType = "CIR", blobType = "PDF";
                var birList = sourceContainer.ListBlobsSegmented($"{turbineNumber}/{dataType}/{cirRecord.Id}/{blobType}", true, BlobListingDetails.Metadata, null, null, null, null);
                var latestBir = birList.Results;
                string destinationUriString = string.Empty;
                if (latestBir.Count() > 0)
                {
                    foreach (CloudBlob item in latestBir)
                    {
                        CloudBlockBlob sourceBlob = new CloudBlockBlob(new Uri(sourceContainer.Uri.ToString() + "/" + item.Name + sourceSasKey));
                        destinationUriString = destinationContainer.Uri.ToString() + "/" + item.Name + destinationSasKey;
                        CloudBlockBlob destinationBlob = new CloudBlockBlob(new Uri(destinationUriString));
                        destinationBlob.StartCopy(sourceBlob);
                    }
                    SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyPdfDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "PDF uploaded successfully");
                }

                else
                    SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", versionNumber, "Functions.CopyPdfDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName ?? "", LogType.Success, "PDF not found");
            }

            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.CopyRevisionHistoryDocumentInMultipleBlob()"), cirRecord.CirId, cirRecord.CirTemplateName, LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
            }
        }

        public static int GetStorageAccount(string cirId)
        {
            try
            {
                byte[] tmpSource;
                byte[] tmpHash;
                tmpSource = ASCIIEncoding.ASCII.GetBytes(cirId);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                int intVal = Math.Abs(BitConverter.ToInt32(tmpHash, 0));
                int strgPart = intVal % 15;
                return strgPart;
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.GetStorageAccount()"), 0, "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                throw;
            }
        }

        public static string GetBlobSASUri(string blobName)
        {
            try
            {
                string sasBlobToken = string.Empty;
                switch (blobName.ToString())
                {
                    case "1":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken1"]; ;
                        break;
                    case "2":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken2"]; ;
                        break;
                    case "3":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken3"]; ;
                        break;
                    case "4":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken4"]; ;
                        break;
                    case "5":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken5"]; ;
                        break;
                    case "6":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken6"]; ;
                        break;
                    case "7":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken7"]; ;
                        break;
                    case "8":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken8"]; ;
                        break;
                    case "9":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken9"]; ;
                        break;
                    case "10":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken10"]; ;
                        break;
                    case "11":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken11"]; ;
                        break;
                    case "12":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken12"]; ;
                        break;
                    case "13":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken13"]; ;
                        break;
                    case "14":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken14"]; ;
                        break;
                    case "15":
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken15"]; ;
                        break;
                    default:
                        sasBlobToken = ConfigurationManager.AppSettings["SasBlobToken0"];
                        break;
                }
                return sasBlobToken;
            }
            catch (Exception ex)
            {
                SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", versionNumber, "Functions.GetBlobSASUri()"), 0, "",LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                throw;
            }

        }

        public static void SaveSqlLogs(string message, long cirId, string cirType, LogType logType ,string details )
        {
            SyncServiceClient _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
            Cir.Data.Access.CirSyncService.MigrationStepLogging objMigrationStepLogging =
                new Cir.Data.Access.CirSyncService.MigrationStepLogging
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
    }
}


