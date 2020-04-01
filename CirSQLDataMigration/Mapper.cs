using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cir.Azure.MobileApp.Service.CirSyncService;

namespace CirSQLDataMigration
{
    public class Mapper
    {
        public enum ComponentType
        {
            Blade = 1,
            Gearbox = 2,
            General = 3,
            Generator = 4,
            Transformer = 5,
            MainBearing = 6,
            Skiipack = 7,
            SimplifiedCIR = 8
        }
        public static void PopulateCirSimplifiedImageData(CirSubmissionData objSubmissionData, ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict, string cirType)
        {
            if (objSubmissionData.ImageReferences != null)
            {
                int i = 0;
                Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] lstImage = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData[objSubmissionData.ImageReferences.Count];
                if (cosmosDict.ContainsKey("imageUploader-Flange1"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange1"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 1;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            imageOrder++;
                            i++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange2"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange2"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 2;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange3"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange3"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 3;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange4"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange4"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 4;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange5"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange5"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 5;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange6"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange6"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 6;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                objComp.ImageData = lstImage;
            }
        }
        public static void PopulateImageData(CirSubmissionData objSubmissionData, ComponentInspectionReport objCIR, Dictionary<string, object> cosmosDict, string cirType)
        {
            if (cirType.ToLower() == "simplifiedcir")
            {
                PopulateCirSimplifiedImageData(objSubmissionData, objCIR, cosmosDict, cirType);
            }
            else
            {
                var dictval = cirType.ToLower() == "bladeinspection" ? (from x in cosmosDict
                                                                        where x.Key.ToLower() == "imagecomponentkey"
                                                                        select x).ToList() : (from x in cosmosDict
                                                                                              where x.Key.ToLower() == "page3uploadimages"
                                                                                              select x).ToList();
                if (dictval.Count > 0)
                {
                    if (objSubmissionData.ImageReferences != null)
                    {
                        int i = 0;
                        Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] lstImage = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData[objSubmissionData.ImageReferences.Count];
                        foreach (ImageDataModel objImage in objSubmissionData.ImageReferences)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(objImage.BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(objImage.BinaryDataUrl);

                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = objImage.BinaryDataUrl;

                            if (cirType.ToLower() == "gearbox" || cirType.ToLower() == "transformer" || cirType.ToLower() == "generator" || cirType.ToLower() == "mainbearing" || cirType.ToLower() == "general" || cirType.ToLower() == "skiipack")
                            {
                                List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["page3UploadImages"].ToString());
                                var imageInfo = lstImageInfo.First(item => item.imageId == objImage.ImageId);
                                objImageData.ImageOrder = lstImageInfo.FindIndex(item => item.imageId == objImage.ImageId);
                                objImageData.ImageDescription = imageInfo.fileInfo.name + "##" + imageInfo.description;
                            }
                            else // Populate Image Data for New Blade Inspections
                            {
                                ImagecomponentKey lstImagecomponentKey = JsonConvert.DeserializeObject<ImagecomponentKey>(cosmosDict["imagecomponentKey"].ToString());

                                #region [Populate ImageDataInfo Object]
                                ImageDataInfo objImageDataInfo = new ImageDataInfo();
                                try
                                {
                                    if (!lstImagecomponentKey.withPlatePicture)
                                    {
                                        objImageDataInfo.IsPlateTypeNotPossible = true;
                                        objImageDataInfo.PlateTypeNotPossibleReason = string.IsNullOrEmpty(lstImagecomponentKey.reason) ? string.Empty : lstImagecomponentKey.reason;
                                    }
                                    else
                                    {
                                        objImageDataInfo.IsPlateTypeNotPossible = false;
                                        objImageDataInfo.PlateTypeNotPossibleReason = string.Empty;
                                    }
                                    objCIR.ImageDataInfo = objImageDataInfo;
                                }
                                catch (Exception ex)
                                {
                                    objImageDataInfo.IsPlateTypeNotPossible = false;
                                    objImageDataInfo.PlateTypeNotPossibleReason = string.Empty;
                                    objCIR.ImageDataInfo = objImageDataInfo;
                                }
                                #endregion [Populate ImageDataInfo Object]

                                #region [Populate ImageData Object]

                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section1 != null && lstImagecomponentKey.sections.section1.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section1.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section1", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section2 != null && lstImagecomponentKey.sections.section2.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section2.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section2", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section3 != null && lstImagecomponentKey.sections.section3.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section3.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section3", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section4 != null && lstImagecomponentKey.sections.section4.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section4.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section4", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section5 != null && lstImagecomponentKey.sections.section5.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section5.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section5", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section6 != null && lstImagecomponentKey.sections.section6.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section6.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section6", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section7 != null && lstImagecomponentKey.sections.section7.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section7.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section7", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section8 != null && lstImagecomponentKey.sections.section8.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section8.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section8", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section9 != null && lstImagecomponentKey.sections.section9.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section9.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section9", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section10 != null && lstImagecomponentKey.sections.section10.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section10.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section10", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section11 != null && lstImagecomponentKey.sections.section11.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section11.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section11", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section12 != null && lstImagecomponentKey.sections.section12.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section12.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section12", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }

                                #endregion [Populate ImageData Object]

                                #region [Populate PlateType Image]

                                if (objImageData.ImageDescription == null && lstImagecomponentKey.plate != null)
                                {
                                    if (lstImagecomponentKey.plate.imageId == objImage.ImageId)
                                    {
                                        objImageData.ImageDescription = lstImagecomponentKey.plate.fileInfo.name + "##";
                                        objImageData.ImageOrder = 0;
                                        objImageData.IsPlateType = true;
                                    }
                                }
                                #endregion [Populate PlateType Image]
                            }
                            objImageData.ImageUrl = objImage.BinaryDataUrl;
                            objImageData.FormIOImageGUID = objImage.ImageId;
                            objImageData.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription") ? Convert.ToString(cosmosDict["txtInspectionDescription"]) : string.Empty;
                            objImageData.IsNewImageControl = true;
                            lstImage[i] = objImageData;
                            i++;
                        }
                        lstImage = lstImage.OrderBy(x => x.ImageOrder).ToArray();
                        objCIR.ImageData = lstImage;

                    }
                }
            }
        }
        public static string SetImageDescriptionforBlade(string section, string damageDesc)
        {
            string imageDescription = string.Empty;
            string imageSide = string.Empty;
            string area = string.Empty;
            switch (section.ToLower())
            {
                case "section2":
                case "section6":
                case "section10":
                    imageSide = "LW";
                    break;
                case "section3":
                case "section7":
                case "section11":
                    imageSide = "LE";
                    break;
                case "section1":
                case "section5":
                case "section9":
                    imageSide = "TE";
                    break;
                case "section4":
                case "section8":
                case "section12":
                    imageSide = "WW";
                    break;
                default:
                    break;
            }
            switch (section.ToLower())
            {
                case "section1":
                case "section2":
                case "section3":
                case "section4":
                    area = "Root";
                    break;
                case "section5":
                case "section6":
                case "section7":
                case "section8":
                    area = "Mid";
                    break;
                case "section9":
                case "section10":
                case "section11":
                case "section12":
                    area = "Tip";
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(damageDesc))
                damageDesc = "no damage";
            imageDescription = imageSide + " " + area + " - " + damageDesc;
            return imageDescription;
        }
        /// <summary>
        /// Template specific datatype conversion
        /// </summary>
        /// <param name="dataDictionary"></param>
        /// <param name="cirType"></param>
        public static void ReportSpecificDataTypeConversion(Dictionary<string, object> dataDictionary, string cirType)
        {
            try
            {
                //Common type conversions
                if (dataDictionary.ContainsKey("ddlInstallationDateType"))
                {
                    if (dataDictionary.ContainsKey("dtInstallationDate") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["dtInstallationDate"])))
                    { dataDictionary["ddlInstallationDateType"] = "2"; }
                    else
                    { dataDictionary["ddlInstallationDateType"] = "1"; }
                }

                if (cirType.ToLower() == "gearbox" || cirType.ToLower() == "mainbearing" || cirType.ToLower() == "skiipack" || cirType.ToLower() == "general" || cirType.ToLower() == "generator" || cirType.ToLower() == "transformer")
                {
                    if (dataDictionary.ContainsKey("cbPlateTypePictureNotPossible"))
                    {
                        dataDictionary["cbPlateTypePictureNotPossible"] = (string.IsNullOrEmpty(Convert.ToString(dataDictionary["cbPlateTypePictureNotPossible"])) == true) ? false : dataDictionary["cbPlateTypePictureNotPossible"];
                    }
                    if (dataDictionary.ContainsKey("txtAlarmLogNumber") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["txtAlarmLogNumber"])))
                    {
                        int value;
                         if (int.TryParse(dataDictionary["txtAlarmLogNumber"].ToString(), out value))
                        {
                            dataDictionary["txtAlarmLogNumber"] = Convert.ToInt32(dataDictionary["txtAlarmLogNumber"]);
                        }
                        else dataDictionary["txtAlarmLogNumber"] = -1;
                    }
                    if (dataDictionary.ContainsKey("txtNotificationnumber") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["txtNotificationnumber"])))
                        { int value;
                        if (int.TryParse(dataDictionary["txtNotificationnumber"].ToString(), out value))
                            {
                            dataDictionary["txtNotificationnumber"] = Convert.ToInt32(dataDictionary["txtNotificationnumber"]);
                            }
                    }
                    if (dataDictionary.ContainsKey("txtSmallGenerator") && dataDictionary["txtSmallGenerator"] != null)
                    {
                        dataDictionary["txtSmallGenerator"] = dataDictionary["txtSmallGenerator"].ToString();// (Convert.ToInt32(dataDictionary["txtSmallGenerator"]) == 0) ? "" : dataDictionary["txtSmallGenerator"];
                    }
                }
                if (cirType.ToLower() == "transformer")
                {
                    if (dataDictionary.ContainsKey("ddlGeneratorAuxEquipment"))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataDictionary["ddlGeneratorAuxEquipment"])))
                        {
                            dataDictionary["ddlGeneratorAuxEquipment"] = Convert.ToString(dataDictionary["ddlGeneratorAuxEquipment"]);
                        }
                        else dataDictionary["ddlGeneratorAuxEquipment"] = "1";
                    }
                }

                if (cirType.ToLower() == "blade")
                {
                    if (dataDictionary.ContainsKey("ctbUpTowerSolutionAvailable"))
                    {
                        dataDictionary["ctbUpTowerSolutionAvailable"] = Convert.ToInt32(dataDictionary["ctbUpTowerSolutionAvailable"]) > 0 ? Convert.ToBoolean(Convert.ToInt32(dataDictionary["ctbUpTowerSolutionAvailable"]) - 1) : false;
                    }
                    if (dataDictionary.ContainsKey("ctbAuxEquipment"))
                    {
                        dataDictionary["ctbAuxEquipment"] = Convert.ToInt32(dataDictionary["ctbAuxEquipment"]) > 0 ? Convert.ToBoolean(Convert.ToInt32(dataDictionary["ctbAuxEquipment"]) - 1) : false;
                    }
                    if (dataDictionary.ContainsKey("ctbBladePicturesIncluded"))
                    {
                        dataDictionary["ctbBladePicturesIncluded"] = Convert.ToInt32(dataDictionary["ctbBladePicturesIncluded"]) > 1 ? Convert.ToBoolean(Convert.ToInt32(dataDictionary["ctbBladePicturesIncluded"])) : false;
                    }
                    dataDictionary["rbReportType"] = dataDictionary["rbReportType"].ToString();
                    dataDictionary["txtSmallGenerator"] = dataDictionary["txtSmallGenerator"].ToString();
                    dataDictionary["csOverallBladeCondition"] = Convert.ToString(dataDictionary["csOverallBladeCondition"]);
                    if (dataDictionary.ContainsKey("txtAlarmLogNumber") && dataDictionary["txtAlarmLogNumber"] != null && Convert.ToString(dataDictionary["txtAlarmLogNumber"]) != string.Empty)
                    {
                        int value;
                        if (int.TryParse(dataDictionary["txtAlarmLogNumber"].ToString(), out value))
                        {
                            dataDictionary["txtAlarmLogNumber"] = Convert.ToInt32(dataDictionary["txtAlarmLogNumber"]);
                        }
                    }
                }
                else if (cirType.ToLower() == "general")
                {
                    if (dataDictionary.ContainsKey("ctbPicturesAttached") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["ctbPicturesAttached"])))
                    {
                        dataDictionary["ctbPicturesAttached"] = Convert.ToInt32(dataDictionary["ctbPicturesAttached"]) > 0 ? Convert.ToBoolean(Convert.ToInt32(dataDictionary["ctbPicturesAttached"]) - 1) : false;
                    }
                    if (dataDictionary.ContainsKey("undefinedFieldsetColumnsNa"))
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dataDictionary["txtComponentSerialNumber"])))
                        {
                            dataDictionary["undefinedFieldsetColumnsNa"] = true;
                        }
                        else dataDictionary["undefinedFieldsetColumnsNa"] = false;
                    }
                }
                else if (cirType.ToLower() == "generator")
                {
                    if (dataDictionary.ContainsKey("txtGeneratorMaxTempResetDate") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["txtGeneratorMaxTempResetDate"])))
                    {
                        dataDictionary["txtGeneratorMaxTempResetDate"] = CopyProperty.getDateTime(CopyProperty.ConvertDateType(dataDictionary["txtGeneratorMaxTempResetDate"].ToString()));
                        //return getDateTime(dateString).ToString();
                    }
                    if (dataDictionary.ContainsKey("ddlGeneratorAuxEquipment"))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataDictionary["ddlGeneratorAuxEquipment"])))
                        {
                            dataDictionary["ddlGeneratorAuxEquipment"] = Convert.ToString(dataDictionary["ddlGeneratorAuxEquipment"]);
                        }
                        else dataDictionary["ddlGeneratorAuxEquipment"] = "1";
                    }
                }
                else if (cirType.ToLower() == "gearbox")
                {
                    if (dataDictionary.ContainsKey("page2TextField") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["page2TextField"])))
                    {
                        dataDictionary["page2TextField"] = "Defect Categorization Score :\t" + dataDictionary["page2TextField"].ToString().Trim();
                    }
                    if (dataDictionary.ContainsKey("txtDateMaxTemperatureResetDate") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["txtDateMaxTemperatureResetDate"])) )
                    {
                        dataDictionary["txtDateMaxTemperatureResetDate"] = CopyProperty.ConvertDateType(Convert.ToString(dataDictionary["txtDateMaxTemperatureResetDate"]));
                    }

                    for (int a = 1; a <= 15; a++)
                    {
                        if (dataDictionary.ContainsKey("txtDecision" + a))
                        {
                            if (dataDictionary["txtDecision" + a] != null)
                            {
                                dataDictionary["txtDecision" + a] = dataDictionary["txtDecision" + a].ToString().Replace("1", "Re-use").Replace("2", "Re-work").Replace("3", "Scrap").Replace("4", "Upgrade").Replace("5", "N/A");
                            }
                            else
                            {
                                dataDictionary["txtDecision" + a] = "";
                            }
                        }

                    }
                    if (dataDictionary.ContainsKey("ddlGearboxManufacturer") && !string.IsNullOrEmpty(Convert.ToString(dataDictionary["ddlGearboxManufacturer"])))
                    {
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 1)
                        {
                            dataDictionary.Add("ddlGearboxTypeZfHansen", dataDictionary["ddlGearboxType"]);
                        }
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 13)
                        {
                            dataDictionary.Add("ddlGearboxTypeJaKe", dataDictionary["ddlGearboxType"]);
                        }
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 4)
                        {
                            dataDictionary.Add("ddlGearboxTypeLohmannRexroth", dataDictionary["ddlGearboxType"]);
                        }
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 14)
                        {
                            dataDictionary.Add("ddlGearboxTypeVestasSparepartsRepair", dataDictionary["ddlGearboxType"]);
                        }
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 5)
                        {
                            dataDictionary.Add("ddlGearboxTypeMetsoValmetSantasaloMoventas", dataDictionary["ddlGearboxType"]);
                        }
                        if (Convert.ToInt32(dataDictionary["ddlGearboxManufacturer"]) == 9)
                        {
                            dataDictionary.Add("ddlGearboxTypeWinergyFlender", dataDictionary["ddlGearboxType"]);
                        }
                        dataDictionary.Remove("ddlGearboxType");
                    }
                    for (int a = 1; a <= 15; a++)
                    {
                        if (dataDictionary.ContainsKey("ddlDamageClass" + a))
                        {
                            DamageClass obj = new DamageClass();
                            if (!string.IsNullOrEmpty(Convert.ToString(dataDictionary["ddlDamageClass" + a])))
                            {
                                obj.value = Convert.ToInt32(dataDictionary["ddlDamageClass" + a]);
                                obj.label = "Cat. " + Convert.ToString((obj.value - 1));
                            }
                            else
                            {
                                obj.value = 0;
                                obj.label = "";
                            }
                            obj.hashKey = "object:" + ImageData.GenerateRandomNo();
                            dataDictionary["ddlDamageClass" + a] = obj;
                        }
                    }
                }
            }
            //Added throw to handle exception
            catch (Exception )
            {
                throw;
            }
        }

        public static Dictionary<string, string> GetDynamicfields(DynamicTable objDynamicField)
        {
            Dictionary<string, string> dynamiclist = new Dictionary<string, string>();
            dynamiclist.Add("A1", objDynamicField.Row1Col1);
            dynamiclist.Add("B1", objDynamicField.Row1Col2);
            dynamiclist.Add("C1", objDynamicField.Row1Col3);
            dynamiclist.Add("D1", objDynamicField.Row1Col4);
            dynamiclist.Add("E1", objDynamicField.Row1Col5);
            dynamiclist.Add("F1", objDynamicField.Row1Col6);
            dynamiclist.Add("A2", objDynamicField.Row2Col1);
            dynamiclist.Add("B2", objDynamicField.Row2Col2);
            dynamiclist.Add("C2", objDynamicField.Row2Col3);
            dynamiclist.Add("D2", objDynamicField.Row2Col4);
            dynamiclist.Add("E2", objDynamicField.Row2Col5);
            dynamiclist.Add("F2", objDynamicField.Row2Col6);
            dynamiclist.Add("A3", objDynamicField.Row3Col1);
            dynamiclist.Add("B3", objDynamicField.Row3Col2);
            dynamiclist.Add("C3", objDynamicField.Row3Col3);
            dynamiclist.Add("D3", objDynamicField.Row3Col4);
            dynamiclist.Add("E3", objDynamicField.Row3Col5);
            dynamiclist.Add("F3", objDynamicField.Row3Col6);
            dynamiclist.Add("A4", objDynamicField.Row4Col1);
            dynamiclist.Add("B4", objDynamicField.Row4Col2);
            dynamiclist.Add("C4", objDynamicField.Row4Col3);
            dynamiclist.Add("D4", objDynamicField.Row4Col4);
            dynamiclist.Add("E4", objDynamicField.Row4Col5);
            dynamiclist.Add("F4", objDynamicField.Row4Col6);
            dynamiclist.Add("A5", objDynamicField.Row5Col1);
            dynamiclist.Add("B5", objDynamicField.Row5Col2);
            dynamiclist.Add("C5", objDynamicField.Row5Col3);
            dynamiclist.Add("D5", objDynamicField.Row5Col4);
            dynamiclist.Add("E5", objDynamicField.Row5Col5);
            dynamiclist.Add("F5", objDynamicField.Row5Col6);
            dynamiclist.Add("A6", objDynamicField.Row6Col1);
            dynamiclist.Add("B6", objDynamicField.Row6Col2);
            dynamiclist.Add("C6", objDynamicField.Row6Col3);
            dynamiclist.Add("D6", objDynamicField.Row6Col4);
            dynamiclist.Add("E6", objDynamicField.Row6Col5);
            dynamiclist.Add("F6", objDynamicField.Row6Col6);
            dynamiclist.Add("A7", objDynamicField.Row7Col1);
            dynamiclist.Add("B7", objDynamicField.Row7Col2);
            dynamiclist.Add("C7", objDynamicField.Row7Col3);
            dynamiclist.Add("D7", objDynamicField.Row7Col4);
            dynamiclist.Add("E7", objDynamicField.Row7Col5);
            dynamiclist.Add("F7", objDynamicField.Row7Col6);
            dynamiclist.Add("A8", objDynamicField.Row8Col1);
            dynamiclist.Add("B8", objDynamicField.Row8Col2);
            dynamiclist.Add("C8", objDynamicField.Row8Col3);
            dynamiclist.Add("D8", objDynamicField.Row8Col4);
            dynamiclist.Add("E8", objDynamicField.Row8Col5);
            dynamiclist.Add("F8", objDynamicField.Row8Col6);
            dynamiclist.Add("A9", objDynamicField.Row9Col1);
            dynamiclist.Add("B9", objDynamicField.Row9Col2);
            dynamiclist.Add("C9", objDynamicField.Row9Col3);
            dynamiclist.Add("D9", objDynamicField.Row9Col4);
            dynamiclist.Add("E9", objDynamicField.Row9Col5);
            dynamiclist.Add("F9", objDynamicField.Row9Col6);
            dynamiclist.Add("A10", objDynamicField.Row10Col1);
            dynamiclist.Add("B10", objDynamicField.Row10Col2);
            dynamiclist.Add("C10", objDynamicField.Row10Col3);
            dynamiclist.Add("D10", objDynamicField.Row10Col4);
            dynamiclist.Add("E10", objDynamicField.Row10Col5);
            dynamiclist.Add("F10", objDynamicField.Row10Col6);
            dynamiclist.Add("A11", objDynamicField.Row11Col1);
            dynamiclist.Add("B11", objDynamicField.Row11Col2);
            dynamiclist.Add("C11", objDynamicField.Row11Col3);
            dynamiclist.Add("D11", objDynamicField.Row11Col4);
            dynamiclist.Add("E11", objDynamicField.Row11Col5);
            dynamiclist.Add("F11", objDynamicField.Row11Col6);
            dynamiclist.Add("A12", objDynamicField.Row12Col1);
            dynamiclist.Add("B12", objDynamicField.Row12Col2);
            dynamiclist.Add("C12", objDynamicField.Row12Col3);
            dynamiclist.Add("D12", objDynamicField.Row12Col4);
            dynamiclist.Add("E12", objDynamicField.Row12Col5);
            dynamiclist.Add("F12", objDynamicField.Row12Col6);
            dynamiclist.Add("A13", objDynamicField.Row13Col1);
            dynamiclist.Add("B13", objDynamicField.Row13Col2);
            dynamiclist.Add("C13", objDynamicField.Row13Col3);
            dynamiclist.Add("D13", objDynamicField.Row13Col4);
            dynamiclist.Add("E13", objDynamicField.Row13Col5);
            dynamiclist.Add("F13", objDynamicField.Row13Col6);
            dynamiclist.Add("A14", objDynamicField.Row14Col1);
            dynamiclist.Add("B14", objDynamicField.Row14Col2);
            dynamiclist.Add("C14", objDynamicField.Row14Col3);
            dynamiclist.Add("D14", objDynamicField.Row14Col4);
            dynamiclist.Add("E14", objDynamicField.Row14Col5);
            dynamiclist.Add("F14", objDynamicField.Row14Col6);

            dynamiclist = dynamiclist.Where(o => o.Value != null).ToDictionary(pair => pair.Key,
                                              pair => pair.Value);

            return dynamiclist;
        }

        public class DamageClass
        {
            [JsonProperty(PropertyName = "value")]
            public int value { get; set; }

            [JsonProperty(PropertyName = "label")]
            public string label { get; set; }

            [JsonProperty(PropertyName = "$$hashKey")]
            public string hashKey { get; set; }
        }
    }
}

