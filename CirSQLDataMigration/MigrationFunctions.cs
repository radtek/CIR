using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Cir.Data.Access.Helpers;
using Microsoft.WindowsAzure.Storage;

namespace CirSQLDataMigration
    {
    public class MigrationFunctions
        {
        public static string DatabaseId = ConfigurationManager.AppSettings["Database"];
        public static string EndPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string CirTemplates = ConfigurationManager.AppSettings["CirTemplateCollection"];
        public static string apiAddress = ConfigurationManager.AppSettings["apiAddress"];
        public static string _cirSyncLogCollectionName = System.Configuration.ConfigurationManager.AppSettings["CirSyncLogCollection"];
        public static string ComponentInspectionReport = ConfigurationManager.AppSettings["CirCommonBrandColletionName"];
        public static DocumentClient _documentClient = new DocumentClient(new Uri(EndPointURI), PrimaryKey);
        static List<CirTemplateDataModel> templates;
        public static long strCirId;
        public static string strCirType;
        public static long strCirDataId;
        public static string strTurbineNumber;
        public static int count = 0;
        static SyncServiceUtilities ServiceNew = new SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);

        public static string templateVersion = ConfigurationManager.AppSettings["TempaleteVersion"];
        public static void ProcessQueueMessage(TextWriter log, int value, [Queue("queueCosmosData")] out string message)
            {
            message = "SQL to Cosmos Cir migration Started successfully";
            log.WriteLine(message);
            Console.WriteLine("Web Job has started....");
            ReadDocument();
            //SendNotificationMail();
            //GetBIRMigrationData();
            //GIRMigration.GetGIRMigrationData();
            //GBXIRMigration.GetGBXIRMigrationData();
            //FirstNotificationMigration.SaveNotificationMigrationData();
            //SecondNotificationMigration.SaveSecondNotificationMigrationData();
            //RejectNotificationMigration.SaveRejectNotificationMigrationData();
            Console.WriteLine("Web Job has finished.");
            }
        /// <summary>
        ///   Read CIR sql data, convert into json and upload it to Cosmos
        /// </summary>
        private static void ReadDocument()
            {
            try
                {
                templates = fetchCirTemplates();
                List<Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail> objlist = ServiceNew.GetMigrationCirList();

                if (objlist != null)
                    {
                    foreach (Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetail cirData in objlist)
                        {
                        strCirId = Convert.ToInt64(cirData.CirId); strCirDataId = cirData.CirDataId;
                        CirSubmissionData report = FetchDataAndUploadImages(int.Parse(cirData.CirId));

                        //if ((cirData.TemplateVersion == "5" || cirData.TemplateVersion == "6" || cirData.TemplateVersion == "7" || cirData.TemplateVersion == "8")
                        //    && cirData.TemplateVersion != "9")
                           // {
                            if (report != null)
                                {
                                UploadCosmosJson(report);
                                }
                           // }

                        Cir.Azure.MobileApp.Service.CirSyncService.PDFModel PDFdata = ServiceNew.GetCirPDFData(cirData.CirId);
                        string strRevisionCount = Convert.ToString(report.Revision) ?? "1";
                        string strModifiedOn = Convert.ToString(report.ModifiedOn) ?? DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                        if (PDFdata != null)
                            {
                            ImageData.UploadPDFDataIntoBlob(PDFdata, report.Id, strTurbineNumber, strRevisionCount, strModifiedOn);
                            }
                        else
                            {
                            Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", templateVersion, "MigrationFunctions.ReadDocument()"), strCirId, strCirType ?? "", LogType.Success, "PDF not found");
                            }
                        ////Save the revision data of each CIR
                        ////if (null != report)
                        ////{
                        ////    SaveRevisonDataInToCosmosDb(report, cirData.CirDataId);
                        ////}
                        ///

                        count++;
                        }
                    }
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", templateVersion, "MigrationFunctions.ReadDocument()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                }
            }

        /// <summary>
        /// fetching SQL DATA on behalf of cirId
        /// </summary>
        /// <param name="cirId"></param>
        private static CirSubmissionData FetchDataAndUploadImages(long cirId)
            {
            CirSubmissionData report = new CirSubmissionData();
            try
                {
                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport objComp = ServiceNew.GetCir(cirId);
                if (objComp != null)
                    {
                    string cirType = Enum.Parse(typeof(Mapper.ComponentType), objComp.ComponentInspectionReportTypeId.ToString()).ToString();
                    Dictionary<string, object> DynamicSqlDictionary = null, turbineData = null;
                    strCirType = cirType; strCirId = cirId; strCirDataId = objComp.CirDataID; Dictionary<string, object> dataDictionary;
                    List<FlangeArray> objArraryList = new List<FlangeArray>();

                    #region Simplified  Flange

                    if (cirType.ToLower() == "simplifiedcir")
                        {
                        objArraryList = SimplifiedFlange(objComp, cirType, ref DynamicSqlDictionary, ref turbineData, objArraryList);
                        }
                    #endregion

                    IDictionary<string, object> jsonDictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(CIRCosmosMapper.GetCIRCosmosJSON(cirType));
                    Dictionary<string, object> SQLDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(objComp));
                    Dictionary<string, object> SQLDictionaryNew = CopyProperty.MergeCollection(SQLDictionary, cirType);

                    if (cirType.ToLower() == "simplifiedcir")
                        {
                        dataDictionary = CopyProperty.CopyFieldsSimplifiedCir(SQLDictionaryNew, jsonDictionary, DynamicSqlDictionary, objArraryList, turbineData, cirType);
                        }
                    else
                        {
                        dataDictionary = CopyProperty.CopyFields(SQLDictionaryNew, jsonDictionary);
                        }

                    #region Blade specific conditions

                    dataDictionary = SetBladeData(objComp, dataDictionary);

                    #endregion Blade specific conditions

                    strTurbineNumber = dataDictionary.ContainsKey("txtTurbineNumber") ? dataDictionary["txtTurbineNumber"].ToString() : "";
                    Mapper.ReportSpecificDataTypeConversion(dataDictionary, cirType.ToLower());


                    #region Dynamic fields
                    //Dynamic fields data
                    Cir.Azure.MobileApp.Service.CirSyncService.DynamicTable arrDynamicData = objComp.DynamicTableInputs;
                    if (arrDynamicData != null && cirType.ToLower() != "simplifiedcir")
                        {
                        Dictionary<string, string> dictDynamic = Mapper.GetDynamicfields(arrDynamicData);
                        dataDictionary.Add("page5DynamicFields", dictDynamic);
                        }
                    #endregion Dynamic fields   

                    if (dataDictionary.ContainsKey("txtInspectionDescription"))
                        {
                        dataDictionary["txtInspectionDescription"] = (objComp.ImageData != null && objComp.ImageData.Count() > 0) ? objComp.ImageData[0].InspectionDesc : "";
                        }

                    //Upload images in blob
                    List<ImageDataModel> uploadedImageList = UploadImageInBlob(objComp, cirType, objComp.ImageData);
                    //page3UploadImages section in data of cir json
                    List<page3UploadImages> uploadimageJson = UpdatePage3UploadImages(cirType, dataDictionary, uploadedImageList);

                    //For no images
                    if (uploadedImageList == null)
                        {
                        if (dataDictionary.ContainsKey("cbPlateTypePictureNotPossible") && string.IsNullOrEmpty(Convert.ToString(dataDictionary["cbPlateTypePictureNotPossible"])))
                            {
                            dataDictionary["cbPlateTypePictureNotPossible"] = true;
                            }

                        if (dataDictionary.ContainsKey("tbPlateTypePictureNotPossibleReason") && string.IsNullOrEmpty(Convert.ToString(dataDictionary["tbPlateTypePictureNotPossibleReason"])))
                            {
                            dataDictionary["tbPlateTypePictureNotPossibleReason"] = "NA";
                            }
                        }

                    #region Blade Related CIR
                    //Releated cir and annual inspection fields for blade templates
                    List<RelatedIds> arrRelatedIds = null;
                    if (cirType == "Blade")
                        {
                        string relatedCirs = ServiceNew.GetRelatedCirsByCirId(cirId.ToString());
                        arrRelatedIds = GetRelatedCirArray(relatedCirs);
                        if (dataDictionary.ContainsKey("ctbAnnualInspection"))
                            {
                            if (!string.IsNullOrEmpty(relatedCirs) && arrRelatedIds.Count == 3)
                                {
                                dataDictionary["ctbAnnualInspection"] = true;
                                }
                            else
                                {
                                dataDictionary["ctbAnnualInspection"] = false;
                                }
                            }
                        }
                    #endregion Blade Related CIR

                    // Create cirSubmissionData object 
                    report = CreateCosmosJson(dataDictionary, objComp, cirType, uploadedImageList, arrRelatedIds);
                    }
                return report;
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName,{1}", templateVersion, "MigrationFunctions.FetchDataAndUploadImages()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                return report;
                }
            }

        private static List<page3UploadImages> UpdatePage3UploadImages(string cirType, Dictionary<string, object> dataDictionary, List<ImageDataModel> uploadedImageList)
            {
            List<page3UploadImages> uploadimageJson = null;
            if (cirType.ToLower() == "simplifiedcir")
                {
                #region Simplified  images
                if (uploadedImageList != null)
                    {
                    List<ImageDataModel> uploadedImageList_Flange = new List<ImageDataModel>();
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 1).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange1"] = uploadimageJson;
                        }

                    uploadedImageList_Flange = null;
                    uploadimageJson = null;
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 2).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange2"] = uploadimageJson;
                        }

                    uploadedImageList_Flange = null;
                    uploadimageJson = null;
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 3).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange3"] = uploadimageJson;
                        }
                    uploadedImageList_Flange = null;
                    uploadimageJson = null;
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 4).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange4"] = uploadimageJson;
                        }
                    uploadedImageList_Flange = null;
                    uploadimageJson = null;
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 5).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange5"] = uploadimageJson;
                        }
                    uploadedImageList_Flange = null;
                    uploadimageJson = null;
                    uploadedImageList_Flange = uploadedImageList.Where(a => a.FlangeNo == 6).ToList();
                    if (uploadedImageList_Flange.Count > 0)
                        {
                        uploadimageJson = ImageData.GetPageUploadSimplifiedCIRImagesJson(uploadedImageList_Flange);
                        dataDictionary["imageUploader-Flange6"] = uploadimageJson;
                        }
                    }
                #endregion Simplified  images
                }
            else
                {
                if (uploadedImageList != null)
                    {
                    uploadimageJson = ImageData.GetPageUploadImagesJson(uploadedImageList);
                    dataDictionary["page3UploadImages"] = uploadimageJson;
                    }
                }

            return uploadimageJson;
            }

        private static List<ImageDataModel> UploadImageInBlob(ComponentInspectionReport objComp, string cirType, Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] arrImageData)
            {
            List<ImageDataModel> uploadedImageList = null;
            if (arrImageData != null && arrImageData.Length > 0)
                {
                if (cirType.ToLower() == "simplifiedcir")
                    {
                    uploadedImageList = ImageData.GetSQLImageDataToBlobMigrationSimplifiedCIR(arrImageData, objComp.FormIOGUID, objComp.CIRTemplateGUID.Trim(), strTurbineNumber);
                    }
                else
                    {
                    uploadedImageList = ImageData.GetSQLImageDataToBlobMigration(arrImageData, objComp.FormIOGUID, objComp.CIRTemplateGUID.Trim(), strTurbineNumber);
                    }
                }
            else
                {
                Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", templateVersion, "MigrationFunctions.UploadImageInBlob()"), strCirId, strCirType ?? "", LogType.Success, "Images not found");
                }

            return uploadedImageList;
            }

        private static Dictionary<string, object> SetBladeData(ComponentInspectionReport objComp, Dictionary<string, object> dataDictionary)
            {
            if (objComp.ComponentInspectionReportTypeId == 1 && (objComp.BladeData.DamageData != null && objComp.BladeData.DamageData.Length > 0))
                {
                dataDictionary.Add("ddlBladeDamageCount", objComp.BladeData.DamageData.Length.ToString());

                for (int i = 0; i < objComp.BladeData.DamageData.Length; i++)
                    {
                    int controlId = i + 1;
                    dataDictionary.Add("ddlblageInspectionId" + controlId, objComp.BladeData.DamageData[i].BladeInspectionDataId.ToString());
                    dataDictionary.Add("ddlblagedamageInspectionId" + controlId, objComp.BladeData.DamageData[i].ComponentInspectionReportBladeDamageId.ToString());
                    dataDictionary.Add("ddldamagePlacement" + controlId, objComp.BladeData.DamageData[i].BladeDamagePlacementId.ToString());
                    dataDictionary.Add("ddldamageType" + controlId, objComp.BladeData.DamageData[i].BladeInspectionDataId.ToString());
                    dataDictionary.Add("ddlbladeEdge" + controlId, objComp.BladeData.DamageData[i].BladeEdgeId.ToString());
                    dataDictionary.Add("txtBladeRadius" + controlId, objComp.BladeData.DamageData[i].BladeRadius.ToString());
                    dataDictionary.Add("txtDamageDescription" + controlId, objComp.BladeData.DamageData[i].BladeDescription.ToString());
                    dataDictionary.Add("txtDamagePictureno" + controlId, objComp.BladeData.DamageData[i].BladePictureNumber.ToString());
                    }
                }
            if (objComp.ComponentInspectionReportTypeId == 1 && objComp.BladeData.RepairRecordData != null)
                {
                dataDictionary.Add("txtAmbientTemperature", Convert.ToString(objComp.BladeData.RepairRecordData.BladeAmbientTemp));
                dataDictionary.Add("txtHumidity", Convert.ToString(objComp.BladeData.RepairRecordData.BladeHumidity));
                dataDictionary.Add("txtAdditionalDocumentReference", Convert.ToString(objComp.BladeData.RepairRecordData.BladeAdditionalDocumentReference));
                dataDictionary.Add("txtResinType", Convert.ToString(objComp.BladeData.RepairRecordData.BladeResinType));
                dataDictionary.Add("txtResinTypeBatchNumbers", Convert.ToString(objComp.BladeData.RepairRecordData.BladeResinTypeBatchNumbers));
                if (!string.IsNullOrEmpty(Convert.ToString(objComp.BladeData.RepairRecordData.BladeResinTypeExpiryDate)))
                    {
                    dataDictionary.Add("dtResinTypeExpiryDate", CopyProperty.ConvertDateType(Convert.ToString(objComp.BladeData.RepairRecordData.BladeResinTypeExpiryDate)));
                    }
                else
                    {
                    dataDictionary.Add("dtResinTypeExpiryDate", "");
                    }

                dataDictionary.Add("txtHardenerType", Convert.ToString(objComp.BladeData.RepairRecordData.BladeHardenerType));
                dataDictionary.Add("txtHardenerTypeBatchNumbers", Convert.ToString(objComp.BladeData.RepairRecordData.BladeHardenerTypeBatchNumbers));

                if (!string.IsNullOrEmpty(Convert.ToString(objComp.BladeData.RepairRecordData.BladeHardenerTypeExpiryDate)))
                    {
                    dataDictionary.Add("dtHardenerTypeExpiryDate", CopyProperty.ConvertDateType(Convert.ToString(objComp.BladeData.RepairRecordData.BladeHardenerTypeExpiryDate)));
                    }
                else
                    {
                    dataDictionary.Add("dtHardenerTypeExpiryDate", "");
                    }

                dataDictionary.Add("txtGlassSupplier", Convert.ToString(objComp.BladeData.RepairRecordData.BladeGlassSupplier));
                dataDictionary.Add("txtGlassSupplierBatchNumbers", Convert.ToString(objComp.BladeData.RepairRecordData.BladeGlassSupplierBatchNumbers));
                dataDictionary.Add("txtMaxBladeSurfaceTemp", Convert.ToString(objComp.BladeData.RepairRecordData.BladeSurfaceMaxTemperature));
                dataDictionary.Add("txtMinBladeSurfaceTemp", Convert.ToString(objComp.BladeData.RepairRecordData.BladeSurfaceMinTemperature));
                dataDictionary.Add("txtQuantityOfMixedResinUsed", Convert.ToString(objComp.BladeData.RepairRecordData.BladeResinUsed));
                dataDictionary.Add("txtMaxPostCureSurfaceTemp", Convert.ToString(objComp.BladeData.RepairRecordData.BladePostCureMaxTemperature));
                dataDictionary.Add("txtMinPostCureSurfaceTemp", Convert.ToString(objComp.BladeData.RepairRecordData.BladeSurfaceMinTemperature));
                dataDictionary.Add("txtTotalCureTime", Convert.ToString(objComp.BladeData.RepairRecordData.BladeTotalCureTime));

                if (!string.IsNullOrEmpty(Convert.ToString(objComp.BladeData.RepairRecordData.BladeTurnOffTime)))
                    {
                    dataDictionary.Add("dtHeaterInsulationAndVacuumOff", CopyProperty.ConvertDateType(Convert.ToString(objComp.BladeData.RepairRecordData.BladeTurnOffTime)));
                    }
                else
                    {
                    dataDictionary.Add("dtHeaterInsulationAndVacuumOff", "");
                    }
                }

            return dataDictionary;
            }

        private static List<FlangeArray> SimplifiedFlange(ComponentInspectionReport objComp, string cirType, ref Dictionary<string, object> DynamicSqlDictionary, ref Dictionary<string, object> turbineData, List<FlangeArray> objArraryList)
            {

            var objDynamicDecisionData = objComp.DyanamicDecisionData;
            var DynamicOutput = objComp.DynamicTableInputs;
            var objTurbineData = objComp.TurbineData;
            var objFlangeArrary = objDynamicDecisionData.Where(a => a.FlangeDamageIdentified == true).Select(i => new { FlangNo = i.FlangNo, FlangeDamageIdentified = i.FlangeDamageIdentified, RepeatedInspections = i.RepeatedInspections, AffectedBolts = i.AffectedBolts, DecisionFlange = i.Decision, InspectionDescription = i.InspectionDesc }).ToList();
            foreach (var val in objFlangeArrary)
                {
                FlangeArray objArrary = new FlangeArray();
                objArrary.FlangeDamageIdentified = val.FlangeDamageIdentified;
                objArrary.FlangeNo = Convert.ToInt16(val.FlangNo);
                objArrary.DecisionFlange = Convert.ToInt16(val.DecisionFlange);
                objArrary.AffectedBolts = Convert.ToInt16(val.AffectedBolts);
                objArrary.RepeatedInspections = Convert.ToInt16(val.RepeatedInspections);
                objArrary.InspectionDescription = val.InspectionDescription;
                objArraryList.Add(objArrary);
                }
            var DynamicOutputSqlJson = JsonConvert.SerializeObject(DynamicOutput);
            var objTurbineDataJson = JsonConvert.SerializeObject(objTurbineData);
            DynamicSqlDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(DynamicOutputSqlJson);
            turbineData = JsonConvert.DeserializeObject<Dictionary<string, object>>(objTurbineDataJson);
            return objArraryList;

            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relatedCirs"></param>
        /// <returns></returns>
        private static List<RelatedIds> GetRelatedCirArray(string relatedCirs)
            {
            List<RelatedIds> list = new List<RelatedIds>();
            if (!string.IsNullOrEmpty(relatedCirs))
                {
                string[] objarr = relatedCirs.Split(',').ToArray();
                foreach (var item in objarr)
                    {
                    RelatedIds obj = new RelatedIds();
                    obj.id = item.Trim();
                    list.Add(obj);
                    }
                }
            return list;
            }


        /// <summary>
        /// Create cirSubmissionData object 
        /// </summary>
        /// <param name="dataDictionary"></param>
        /// <param name="objComp"></param>
        /// <param name="cirType"></param>
        /// <param name="reportGuid"></param>
        /// <param name="imageReference"></param>
        /// <returns></returns>
        private static CirSubmissionData CreateCosmosJson(Dictionary<string, object> dataDictionary, ComponentInspectionReport objComp, string cirType, IList<ImageDataModel> imageReference, List<RelatedIds> relatedCirs)
            {
            var errorsList = new List<string>();
            CirSubmissionData report = new CirSubmissionData();
            report.Data = dataDictionary;
            report.Schema = "";
            report.Partition = getPartition(objComp.ComponentInspectionReportId);
            report.CreatedBy = objComp.CreatedBy;
            report.CreatedOn = objComp.Created;
            report.Errors = new List<string>();
            report.DelegatedBy = null;
            report.DelegatedTo = null;
            report.IsLockedByTos = false;
            report.IsSentToInspecTool = false;
            report.StatusChangedBy = null;
            report.Id = objComp.FormIOGUID;
            report.CirId = objComp.ComponentInspectionReportId;
            report.Revision = 1;
            report.ModifiedBy = objComp.ModifiedBy;
            report.ModifiedOn = objComp.Modified;
            report.LockedBy = "";
            report.CirCollectionName = "ComponentInspectionReport";
            report.CirBrandName = "Vestas";
            report.CirTemplateName = cirType.Replace("Blade", "BladeInspection");
            report.templateVersion = Common.GetTemplateVersionFromCIRReport(Convert.ToString(objComp.TemplateVersion)); ;
            report.CirTemplateId = GetTemplateId(report.CirTemplateName, report.templateVersion);
            report.SqlProcessStatus = "Transferred";
            report.ImageProcessStatus = ImageProcessStatus.Synced;
            report.BrowserDetails = "Platform: Win32, Agent: Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36, Version: 5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36, Language: da-DK";
            report.IsNewCirData = "false";
            report.ImageReferences = imageReference;
            report.State = (CirState)Enum.Parse(typeof(CirState), objComp.ComponentInspectionReportStateId.ToString());//CirState.Submitted;
            report.RelatedCirs = relatedCirs;//add for blade only from blade data table
            report.DeletedFromCache = null;
            return report;
            }

        /// <summary>
        /// Upload json into cosmos database
        /// </summary>
        /// <param name="report"></param>
        private static void UploadCosmosJson(CirSubmissionData report)
            {
            try
                {
                var strDataJson = JsonConvert.SerializeObject(report);
                string address = apiAddress + "api/CirMigrationData/SubmitForMigration";
                using (MyWebClient client = new MyWebClient())
                    {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    client.Headers["ZUMO-API-VERSION"] = "2.0.0";
                    var result = client.UploadString(address, strDataJson);

                   
                    string uploadImage = "uploaded";
                    if (result == "[]")
                        {
                        result = ""; uploadImage = "not uploaded";
                        }
                    CloudStorageAccount storageAccount = GetStorageHash.GetStorageAccount(report.Id);

                    string dataType = "CIR", blobType = "RevisionHistory", contentType = "json";
                    var binaryDataFileName = $"{report.Data["txtTurbineNumber"]}/{dataType}/{report.Id}/{blobType}";
 
                    Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", templateVersion, "MigrationFunctions.UploadCosmosJson(): BlobContainer path:" + storageAccount.BlobStorageUri.PrimaryUri+ ConfigurationManager.AppSettings["AzureStorageContainerName"] + "/"+binaryDataFileName), strCirId, strCirType ?? "", (uploadImage == "uploaded") ? LogType.Success : LogType.Error, LogType.Success.ToString() + ": Cosmos json " + uploadImage + " successfully");
                    }
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", templateVersion, "MigrationFunctions.UploadCosmosJson()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);


                }
            }

        private static void SendNotificationMailDataToAPI(CirSubmissionData report)
            {
            try
                {
                var strDataJson = JsonConvert.SerializeObject(report);
                string address = apiAddress + "api/CirMigrationData/SendNotificationMail";
                using (MyWebClient client = new MyWebClient())
                    {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    client.Headers["ZUMO-API-VERSION"] = "2.0.0";
                    var result = client.UploadString(address, strDataJson);

                    string uploadImage = "uploaded";
                    if (result == "[]")
                        {
                        result = ""; uploadImage = "not uploaded";
                        }
                    Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", templateVersion, "MigrationFunctions.SendNotificationMailDataToAPI()"), strCirId, strCirType ?? "", (uploadImage == "uploaded") ? LogType.Success : LogType.Error, LogType.Success.ToString() + ":Mail has been sent " + uploadImage + " successfully");

                    }
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", templateVersion, "MigrationFunctions.SendNotificationMailDataToAPI()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);

                }

            }
        /// <summary>
        /// Fetch template name and id from cosmos DB
        /// </summary>
        /// <returns>list of templates</returns>
        private static List<CirTemplateDataModel> fetchCirTemplates()
            {
            List<CirTemplateDataModel> cirTemplatesList = new List<CirTemplateDataModel>();
            try
                {
                // string stQry = "SELECT * FROM " + CirTemplates + " c where  c.cirBrand.name='Vestas' and c.versionNumber=0.7";
                string stQry = "SELECT * FROM " + CirTemplates + " c where  c.cirBrand.name='Vestas' and c.versionNumber=1 or c.versionNumber=0.8 or c.versionNumber=0.7 or c.versionNumber=0.6  or c.versionNumber=0.5";

                cirTemplatesList = _documentClient.CreateDocumentQuery<CirTemplateDataModel>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, CirTemplates),
                        stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirTemplateDataModel>();//
                                                                                                                                       //CirTemplateDataModel item = cirTemplatesList.Where(o => o.Name == "BladeInspection" && o.VersionNumber == 1).FirstOrDefault();
                                                                                                                                       //cirTemplatesList.Remove(item);
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", templateVersion, "MigrationFunctions.fetchCirTemplates()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                }
            return cirTemplatesList;
            }

        /// <summary>
        /// Get Template Id form the template list
        /// </summary>
        /// <param name="CirTemplateName">TemplateTypeName</param>
        /// <param name="templateVersion">Template Version</param>
        /// <returns></returns>
        private static string GetTemplateId(string CirTemplateName, double templateVersion)
            {
            string templateID = string.Empty;
            try
                {
                templateVersion = templateVersion < 5 ? templateVersion = 0.5 : templateVersion;
                CirTemplateDataModel isTemplates = templates != null ? templates.FirstOrDefault(s => s.Name == CirTemplateName && s.VersionNumber == templateVersion) : new CirTemplateDataModel();
                templateID = (isTemplates == null) ? "" : Convert.ToString(isTemplates.Id);
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", templateVersion, "MigrationFunctions.GetTemplateId()"), strCirId, strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                }
            return templateID;
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public static string getPartition(Int64 cirId)
            {
            string partitionName;
            decimal partitionValue;

            if (ConfigurationManager.AppSettings["PartitionDivisionValue"] != null)
                {
                partitionValue = (cirId / Convert.ToInt64(ConfigurationManager.AppSettings["PartitionDivisionValue"]));
                }
            else
                {
                partitionValue = (cirId / 50000);
                }

            partitionName = "partition" + (int)partitionValue;
            return partitionName;
            }


        private static void SendNotificationMail()
            {
            try
                {
                string whereDate = " and (c.createdOn >='2019-04-03T00: 00:00.000' AND c.createdOn <='2019-05-29T00: 00:00.000')";
                string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.sqlProcessStatus = 'Transferred' and c.imageProcessStatus='Synced' and c.state in ('" + CirState.Submitted + "','" + CirState.Approved + "','" + CirState.Rejected + "')" + whereDate;
                List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                  UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
            stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();

                foreach (CirSubmissionData cirsubmission in reports)
                    {
                    SendNotificationMailDataToAPI(cirsubmission);
                    }
                }
            catch (Exception ex)
                {
                Common.SaveSqlLogs(String.Format("MethodName :{0} ,Error: {1}", "SendNotificationMail()", ex.Message), strCirId, strCirType ?? "", LogType.Error, ex.StackTrace);
                }

            }
        }

    public class page3UploadImages
        {
        [JsonProperty(PropertyName = "fileInfo")]
        public Fileinfo fileInfo { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "imageId")]
        public string imageId { get; set; }

        [JsonProperty(PropertyName = "$$hashKey")]
        public string hashKey { get; set; }
        }
    public class TurbineData
        {
        [JsonProperty(PropertyName = "txtRotorDiameter")]
        public Fileinfo txtRotorDiameter { get; set; }

        [JsonProperty(PropertyName = "txtNominelPower")]
        public string txtNominelPower { get; set; }

        [JsonProperty(PropertyName = "txtVoltage")]
        public string txtVoltage { get; set; }

        [JsonProperty(PropertyName = "txtPowerRegulation")]
        public string txtPowerRegulation { get; set; }

        [JsonProperty(PropertyName = "txtSmallGenerator")]
        public Fileinfo txtSmallGenerator { get; set; }

        [JsonProperty(PropertyName = "txtTemperatureVariant")]
        public string txtTemperatureVariant { get; set; }

        [JsonProperty(PropertyName = "txtMKversion")]
        public string txtMKversion { get; set; }

        [JsonProperty(PropertyName = "txtOnshoreOffshore")]
        public string txtOnshoreOffshore { get; set; }

        [JsonProperty(PropertyName = "txtManufacturer")]
        public string txtManufacturer { get; set; }

        [JsonProperty(PropertyName = "txtLocalturbineId")]
        public string txtLocalturbineId { get; set; }
        }
    public class Fileinfo
        {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        }
    public enum LogType
        {
        ImageSync = 1,
        PdfSync = 2,
        DataSync = 3,
        Success = 4,
        Error = 5
        }

    public enum Decision
        {

        Halfyearly = 31,
        Friedberg = 2,
        Dokka = 3,
        Other = 4,
        M36 = 5,
        M42 = 6,
        M48 = 7,
        M56 = 8,
        M64 = 9,
        Yes = 12,
        No = 13,
        Weekly = 27,
        Monthly = 29,
        }
    }