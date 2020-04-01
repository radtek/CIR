using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Data.Access.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;
using Cir.Azure.MobileApp.Service.Utilities;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CirSQLDataMigration
{
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 20 * 60 * 1000;
            return w;
        }
    }
    public class ImageData
    {
        private static readonly string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageContainerName"];
        static Dictionary<string, string> dicDescription;// = new Dictionary<string, string>();
        public static string apiAddress = ConfigurationManager.AppSettings["apiAddress"];

        public ImageData()
        {
            var storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
        }

        #region New image control functions
        /// <summary>
        /// Describing SeverityColors
        /// </summary>
        public static class SeverityColors
        {
            public static readonly string AssignedColor = "#0094FF";
            public static readonly string UnassignedColor = "#C7C7C7";
            public static readonly string Severity0 = "#808080";
            public static readonly string Severity1 = "#00963D";
            public static readonly string Severity2 = "#8BC34A";
            public static readonly string Severity3 = "#FFDF25";
            public static readonly string Severity4 = "#FFB700";
            public static readonly string Severity5 = "#CC0000";
        }

        /// <summary>
        /// This method would populate the missing custom image control fields in the cosmos db json object
        /// </summary>
        /// <param name="cosmosJson">cosmosdb json</param>
        /// <returns></returns>
        public static CirSubmissionData AddBladeImageControlFields(CirSubmissionData reportToSubmit, List<ImageDataModel> uploadedImageList)
        {
            try
            {
                //fields needed for new custom image control in new blade inspection template.
                var uploadedImagesCache = string.Empty;
                var sections = string.Empty;
                var plate = string.Empty;
                var reason = string.Empty;
                var withPlatePicture = true;

                //Check and add if imagecomponentKey is not present in the blade inspection object
                try
                {
                    ((Dictionary<string, object>)reportToSubmit.Data).Add("imagecomponentKey", new { });
                }
                catch (Exception e)
                {
                    //catch is triggered when key already exist in the dictionary.
                }

                //add uploadedimagescache and sections attribute values for old blade inspection images
                try
                {
                    uploadedImagesCache = "[";
                    sections = "{\"section2\": {\"side\": \"Leeward side\",\"damageSeverity\": 4,\"images\": [";
                    int i = 1;
                    //traverse through all the old blade inspection images and populate the respective values in new custom image control fields
                    foreach (var oldBladeImage in reportToSubmit.ImageReferences)
                    {
                        var imageName = Convert.ToString(i) + ".jpg";
                        var imageNumber = i++;
                        var damageSeverity = 3;
                        var damagePlacement = "external";
                        var damageType = "Trailing edge";
                        var radius = 1;
                        var damageDescription = "Trailing edge";
                        var side = "Trailing edge";
                        var damageIdentified = false;
                        var color = (damageSeverity == 0 ? SeverityColors.Severity0 : (damageSeverity == 1 ? SeverityColors.Severity1 : (damageSeverity == 2 ? SeverityColors.Severity2 : (damageSeverity == 3 ? SeverityColors.Severity3 : (damageSeverity == 4 ? SeverityColors.Severity4 : (damageSeverity == 5 ? SeverityColors.Severity5 : SeverityColors.UnassignedColor))))));

                        uploadedImagesCache += "{\"width\": \"1024\",\"height\": 768,\"checked\": false, \"color\": \"" + color + "\", \"region\": -1, \"imageName\": \"" + Convert.ToString(imageName) + "\", \"imageNumber\": " + Convert.ToInt32(imageNumber) + ", \"uploadedAt\": \"" + DateTime.UtcNow + "\", \"damagePlacement\": \"" + Convert.ToString(damagePlacement) + "\", \"damageType\": \"" + Convert.ToString(damageType) + "\", \"radius\": " + Convert.ToInt32(radius) + ", \"damageDescription\": \"" + Convert.ToString(damageDescription) + "\", \"damageDescriptionText\": \"" + Convert.ToString(damageDescription) + "\", \"side\": \"" + Convert.ToString(side) + "\", \"saved\": false, \"observations\": [{\"observationType\": null, \"surfaceType\": null, \"location\": null, \"size\": {\"width\": \"1024\", \"height\": 768, \"depth\": null}, \"severity\": " + Convert.ToInt32(damageSeverity) + ", \"date\": null, \"name\": null,\"findingType\": \"" + Convert.ToString(damageType) + "\", \"comment\": null, \"polygons\": [{\"text\": \"\", \"center\": {\"z\": null, \"x\": 512, \"y\": 384 }, \"severity\": " + Convert.ToInt32(damageSeverity) + ", \"geometry\": [{ \"z\": null, \"x\": 0, \"y\": 0}, { \"z\": null, \"x\": \"1024\", \"y\": 0 }, { \"z\": null, \"x\": \"1024\", \"y\": 768}, { \"z\": null, \"x\": 0, \"y\": 768 }]}]}], \"damageIdentified\": " + damageIdentified.ToString().ToLower() + ", \"groupId\": -1, \"damageSeverity\": " + Convert.ToInt32(damageSeverity) + ", \"imageId\": \"" + Convert.ToString(oldBladeImage.ImageId) + "\"},";

                        sections += "{\"coords\": [\"0.5\",\"0.16\"],\"fileInfo\": {\"name\": \"1.JPG\"},\"imageId\": \"" + Convert.ToString(oldBladeImage.ImageId) + "\",\"number\": 1,\"damagePlacement\": \"external\",\"radius\": " + radius + ",\"damageDescription\": \"" + Convert.ToString(damageDescription) + "\",\"damageSeverity\": " + Convert.ToInt32(damageSeverity) + ",\"side\": \"" + Convert.ToString(side) + "\",\"observations\": [{\"observationType\": null,\"surfaceType\": null,\"location\": null,\"size\": {\"width\": \"1024\",\"height\": 889.9047619047619,\"depth\": null},\"severity\": 4,\"date\": null,\"name\": null,\"findingType\": \"" + Convert.ToString(damageType) + "\",\"comment\": null,\"polygons\": [{\"text\": \"\",\"center\": {\"z\": null,\"x\": 512,\"y\": 444.95238095238096},\"severity\": 4,\"geometry\": [{\"z\": null,\"x\": 0,\"y\": 0},{\"z\": null,\"x\": \"1024\",\"y\": 0},{\"z\": null,\"x\": \"1024\",\"y\": 889.9047619047619},{\"z\": null,\"x\": 0,\"y\": 889.9047619047619}]}]}],\"damageIdentified\": " + Convert.ToString(damageIdentified).ToLower() + "},";
                    }
                    uploadedImagesCache += "]";
                    uploadedImagesCache = uploadedImagesCache.Remove(uploadedImagesCache.Length - 2, 1);

                    sections += "]}}";
                    sections = sections.Remove(sections.Length - 4, 1);
                }
                catch (Exception e)
                {
                    //exception log
                }
                try
                {
                    //set plate image's value for ols blade inspection images
                    var plateImageId = Convert.ToString(reportToSubmit.ImageReferences[0].ImageId);
                    var plateImageName = "0.jpg";
                    plate = "{\"fileInfo\": {\"name\": \"" + plateImageName + "\"},\"imageId\": \"" + plateImageId + "\"}";
                }
                catch (Exception e)
                {
                    //exception log
                }

                if (withPlatePicture)
                    ((Dictionary<string, object>)reportToSubmit.Data)["imagecomponentKey"] = JToken.Parse("{\"withPlatePicture\": " + withPlatePicture.ToString().ToLower() + ",\"uploadedImagesCache\":" + uploadedImagesCache + ", \"sections\":" + sections + ", \"plate\": " + plate + "}");
                else
                    ((Dictionary<string, object>)reportToSubmit.Data)["imagecomponentKey"] = JToken.Parse("{\"withPlatePicture\": " + withPlatePicture.ToString().ToLower() + ",\"uploadedImagesCache\":" + uploadedImagesCache + ", \"sections\":" + sections + ", \"reason\": " + reason + "}");
                object imagecomponentKey = null;
                ((Dictionary<string, object>)reportToSubmit.Data).TryGetValue("imagecomponentKey", out imagecomponentKey);
            }
            catch (Exception ex)
            {
                //  throw ex;
            }
            return reportToSubmit;
        }
        #endregion

        /// <summary>
        /// This is used to get the Image Data from [dbo].[ImageData] table for migration
        /// </summary>
        /// <param name="arrImageData"></param>
        /// <param name="reportGuid"></param>
        /// <param name="templateGuid"></param>
        /// <returns></returns>
        public static List<ImageDataModel> GetSQLImageDataToBlobMigration(Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] arrImageData, string reportGuid, string templateGuid, string turbineNumber)
        {
            List<ImageDataModel> lstRetImageDataModel = new List<ImageDataModel>();
            dicDescription = new Dictionary<string, string>();

            try
            {
                List<ImageDataModel> lstImgDataModel = new List<ImageDataModel>();

                foreach (var imageData in arrImageData)
                {
                    ImageDataModel objImgDataModel = new ImageDataModel();
                    objImgDataModel.ImageId = Convert.ToString(Guid.NewGuid());
                    objImgDataModel.BlobGuid = Convert.ToString(Guid.NewGuid());
                    objImgDataModel.CirId = reportGuid;
                    objImgDataModel.TemplateId = templateGuid;
                    objImgDataModel.Url = string.Empty;
                    objImgDataModel.BinaryDataUrl = string.Empty;
                    objImgDataModel.BinaryData = imageData.ImageDataString;
                    objImgDataModel.TurbineNumber = turbineNumber;

                    dicDescription.Add(objImgDataModel.ImageId, imageData.ImageDescription == null ? "" : imageData.ImageDescription);
                    lstImgDataModel.Add(objImgDataModel);

                }

                var strImgDataJson = JsonConvert.SerializeObject(lstImgDataModel);

                using (MyWebClient client = new MyWebClient())
                {
                    client.Headers["Content-type"] = "application/json";                    
                    client.Encoding = Encoding.UTF8;
                    client.Headers["ZUMO-API-VERSION"] = "2.0.0";

                    string Url = apiAddress + "api/CirMigrationData/UploadSQLDataToBlob";
                    var result = client.UploadString(Url, strImgDataJson);
                    string uploadImage = "uploaded";
                    if (result == "[]")
                    {
                        result = ""; uploadImage = "does not uploaded";
                    }

                    lstRetImageDataModel = JsonConvert.DeserializeObject<List<ImageDataModel>>(result);
                    Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetSQLImageDataToBlobMigration()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", (uploadImage == "uploaded") ? LogType.ImageSync : LogType.Error, (uploadImage == "uploaded") ? LogType.ImageSync.ToString() + ": Image(s) " + uploadImage + " successfully" : "Image Sync failed");

                }
            }
            catch (Exception ex)
            {
                dicDescription = null;
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetSQLImageDataToBlobMigration()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
            }
            return lstRetImageDataModel;
        }
        public static List<ImageDataModel> GetSQLImageDataToBlobMigrationSimplifiedCIR(Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] arrImageData, string reportGuid, string templateGuid, string turbineNumber)
        {
            List<ImageDataModel> lstRetImageDataModel = new List<ImageDataModel>();
            dicDescription = new Dictionary<string, string>();

            try
            {
                List<ImageDataModel> lstImgDataModel = new List<ImageDataModel>();

                foreach (var imageData in arrImageData)
                {
                    ImageDataModel objImgDataModel = new ImageDataModel();
                    objImgDataModel.ImageId = Convert.ToString(Guid.NewGuid());
                    objImgDataModel.BlobGuid = Convert.ToString(Guid.NewGuid());
                    objImgDataModel.CirId = reportGuid;
                    objImgDataModel.TemplateId = templateGuid;
                    objImgDataModel.Url = string.Empty;
                    objImgDataModel.BinaryDataUrl = string.Empty;
                    objImgDataModel.BinaryData = imageData.ImageDataString;
                    objImgDataModel.TurbineNumber = turbineNumber;
                    objImgDataModel.FlangeNo = imageData.FlangNo;
                    objImgDataModel.ImageDescription = imageData.ImageDescription;
                    dicDescription.Add(objImgDataModel.ImageId, imageData.ImageDescription);
                    lstImgDataModel.Add(objImgDataModel);

                }
                var strImgDataJson = JsonConvert.SerializeObject(lstImgDataModel);

                using (MyWebClient client = new MyWebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    client.Headers["ZUMO-API-VERSION"] = "2.0.0";
                    string Url = apiAddress + "api/CirMigrationData/UploadSQLDataToBlob";
                    var result = client.UploadString(Url, strImgDataJson);
                    string uploadImage = "uploaded";
                    if (result == "[]")
                    {
                        result = ""; uploadImage = "does not uploaded";
                    }
                    lstRetImageDataModel = JsonConvert.DeserializeObject<List<ImageDataModel>>(result);
                    Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetSQLImageDataToBlobMigrationSimplifiedCIR()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", (uploadImage == "uploaded") ? LogType.ImageSync : LogType.Error, (uploadImage == "uploaded") ? LogType.ImageSync.ToString() + ": Image(s) " + uploadImage + " successfully" : "Image Sync failed");


                }
            }
            catch (Exception ex)
            {
                dicDescription = null;
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetSQLImageDataToBlobMigrationSimplifiedCIR()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);

            }
            return lstRetImageDataModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9900;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        /// <summary>
        /// This is used to get the list of Page3UploadImages object 
        /// </summary>
        /// <param name="lstUploadImages"></param>
        /// <returns></returns>
        public static List<page3UploadImages> GetPageUploadImagesJson(List<ImageDataModel> lstUploadImages)
        {
            try
            {
                List<page3UploadImages> lstPage3UploadImages = new List<page3UploadImages>();
                if (null != dicDescription)
                {
                    int randomNo = GenerateRandomNo();
                    foreach (KeyValuePair<string, string> pair in dicDescription)
                    {
                        page3UploadImages objPage3UploadImages = new page3UploadImages();
                        if (pair.Value.Contains("##"))
                        {
                            objPage3UploadImages.fileInfo = new Fileinfo { name = (pair.Value).Split(new string[] { "##" }, StringSplitOptions.None)[0] };
                            objPage3UploadImages.description = (pair.Value).Split(new string[] { "##" }, StringSplitOptions.None)[1];
                        }
                        else
                        {
                            objPage3UploadImages.fileInfo = new Fileinfo { name = "NotFoundImage.jpg" };
                            objPage3UploadImages.description = pair.Value;
                        }
                        objPage3UploadImages.imageId = pair.Key;
                        objPage3UploadImages.hashKey = "object:" + (randomNo);

                        lstPage3UploadImages.Add(objPage3UploadImages);
                        randomNo++;
                    }
                }
                return lstPage3UploadImages;
            }
            catch (Exception ex)
            {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetPageUploadImagesJson()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                return null;
            }
        }

        public static List<page3UploadImages> GetPageUploadSimplifiedCIRImagesJson(List<ImageDataModel> lstUploadImages)
        {
            try
            {
                Dictionary<string, string> dicDescriptionFlange = new Dictionary<string, string>();
                foreach (var item in lstUploadImages)
                {
                    dicDescriptionFlange.Add(item.ImageId, item.ImageDescription);
                }

                int count = 0;
                List<page3UploadImages> lstPage3UploadImages = new List<page3UploadImages>();
                if (null != dicDescriptionFlange)
                {

                    foreach (KeyValuePair<string, string> pair in dicDescriptionFlange)
                    {
                        page3UploadImages objPage3UploadImages = new page3UploadImages();
                        if (pair.Value.Contains("##"))
                        {
                            objPage3UploadImages.fileInfo = new Fileinfo { name = (pair.Value).Split(new string[] { "##" }, StringSplitOptions.None)[0] };
                            objPage3UploadImages.description = (pair.Value).Split(new string[] { "##" }, StringSplitOptions.None)[1];
                        }
                        else
                        {
                            objPage3UploadImages.fileInfo = new Fileinfo { name = "NotFoundImage.jpg" };
                            objPage3UploadImages.description = pair.Value;
                        }
                        objPage3UploadImages.imageId = pair.Key;
                        objPage3UploadImages.hashKey = "object:" + GenerateRandomNo() + (count + 1);

                        lstPage3UploadImages.Add(objPage3UploadImages);
                        count++;
                    }

                    count = 0;
                }
                return lstPage3UploadImages;
            }
            catch (Exception ex)
            {
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.GetPageUploadSimplifiedCIRImagesJson()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Upload PDF data into Blob
        /// </summary>
        /// <param name="lstPdf"></param>
        public static void UploadPDFDataIntoBlob(Cir.Azure.MobileApp.Service.CirSyncService.PDFModel pdfdata, string reportGUID, string strTurbineNumber,string strRevisionCount, string strModifiedOn)
        {
            try
            {
                PDFModel objPdf = new PDFModel
                {
                    CIRName = pdfdata.CIRName,
                    CIRState = pdfdata.CIRState,
                    CIRTemplateGUID = pdfdata.CIRTemplateGUID,
                    PDFData = pdfdata.PDFData,
                    TurbineNumber = strTurbineNumber,
                    BlobGuid = Convert.ToString(Guid.NewGuid()),
                    CIRID = reportGUID,
                    Revision = strRevisionCount,
                    Modified = strModifiedOn
                };

                var strPDFDataJson = JsonConvert.SerializeObject(objPdf);

                using (var client = new MyWebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    client.Headers["ZUMO-API-VERSION"] = "2.0.0";
                    string Url = apiAddress + "api/CirMigrationData/UploadPDFDataToBlob";
                    var result = client.UploadString(Url, strPDFDataJson);
                    PDFModel1 objPdf1 = new PDFModel1();
                    objPdf1 = JsonConvert.DeserializeObject<PDFModel1>(result);

                    Common.SaveSqlLogs(String.Format("Version{0},Success,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.UploadPDFDataIntoBlob()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.PdfSync, LogType.PdfSync.ToString() + ": PDF Uploaded successfully");

                }
            }
            catch (Exception ex)
            {
                dicDescription = null;
                Common.SaveSqlLogs(String.Format("Version{0},Error,MethodName: {1}", MigrationFunctions.templateVersion, "ImageData.UploadPDFDataIntoBlob()"), MigrationFunctions.strCirId, MigrationFunctions.strCirType ?? "", LogType.Error, ex.Message + " StackTrace" + ex.StackTrace);

            }
        }

    }
}
