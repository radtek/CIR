using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System.Globalization;
using System.Data.SqlTypes;
using System.Data.Objects;
using System.Web.Hosting;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Transactions;
using Cir.Sync.Services.Notification;
using Spire.Pdf;
using Spire.Pdf.HtmlConverter;
using Spire.Doc.Documents;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Net;

namespace Cir.Sync.Services.DAL
{
    public class DACIRData
    {
        CultureInfo CultureInf = new CultureInfo("en-US");
        public static int level = 0;
        public static string cirname = string.Empty;

        public delegate bool GeneratePDFDelegate(long cirid, string path, string licpath);
        public static bool HandleError(string error)
        {
            string path = HostingEnvironment.ApplicationPhysicalPath;

            try
            {
                string strfilename = Path.Combine(path, @"Logs\\error.txt");
                StreamWriter writer = new StreamWriter(strfilename, true);
                FileInfo f = new FileInfo(strfilename);
                long b = f.Length;

                if (f.Length < 1048576)
                {
                    writer.WriteLine("Exception:{0}",
                         error);
                    writer.Dispose();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Save cir data
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        /// 
        public static CirResponse SaveCIRData(CIR.ComponentInspectionReport CIRList)
        {
            //string tmp1 = "{\"AdditionalComments\":\"\",\"AfterInspectionTurbineRunStatusId\":1,\"AlarmLogNumber\":\"\",\"BeforeInspectionTurbineRunStatusId\":1,\"BladeData\":{\"BladeClaimRelevantBooleanAnswerId\":null,\"BladeColorId\":5,\"BladeDamageIdentified\":true,\"BladeFaultCodeAreaId\":null,\"BladeFaultCodeCauseId\":null,\"BladeFaultCodeClassificationId\":null,\"BladeFaultCodeTypeId\":null,\"BladeInspectionReportDescription\":\"\",\"BladeLengthId\":7,\"BladeLsCalibrationDate\":\"0001-01-01T00:00:00\",\"BladeLsLeewardSidePostRepair2\":null,\"BladeLsLeewardSidePostRepair3\":null,\"BladeLsLeewardSidePostRepair4\":null,\"BladeLsLeewardSidePostRepair5\":null,\"BladeLsLeewardSidePostRepair6\":null,\"BladeLsLeewardSidePostRepair7\":null,\"BladeLsLeewardSidePostRepair8\":null,\"BladeLsLeewardSidePostRepairTip\":null,\"BladeLsLeewardSidePreRepair2\":null,\"BladeLsLeewardSidePreRepair3\":null,\"BladeLsLeewardSidePreRepair4\":null,\"BladeLsLeewardSidePreRepair5\":null,\"BladeLsLeewardSidePreRepair6\":null,\"BladeLsLeewardSidePreRepair7\":null,\"BladeLsLeewardSidePreRepair8\":null,\"BladeLsLeewardSidePreRepairTip\":null,\"BladeLsVtNumber\":\"\",\"BladeLsWindwardSidePostRepair2\":null,\"BladeLsWindwardSidePostRepair3\":null,\"BladeLsWindwardSidePostRepair4\":null,\"BladeLsWindwardSidePostRepair5\":null,\"BladeLsWindwardSidePostRepair6\":null,\"BladeLsWindwardSidePostRepair7\":null,\"BladeLsWindwardSidePostRepair8\":null,\"BladeLsWindwardSidePostRepairTip\":null,\"BladeLsWindwardSidePreRepair2\":null,\"BladeLsWindwardSidePreRepair3\":null,\"BladeLsWindwardSidePreRepair4\":null,\"BladeLsWindwardSidePreRepair5\":null,\"BladeLsWindwardSidePreRepair6\":null,\"BladeLsWindwardSidePreRepair7\":null,\"BladeLsWindwardSidePreRepair8\":null,\"BladeLsWindwardSidePreRepairTip\":null,\"BladeManufacturerId\":2,\"BladeOtherSerialNumber1\":\"\",\"BladeOtherSerialNumber2\":\"\",\"BladePicturesIncludedBooleanAnswerId\":2,\"BladeSerialNumber\":\"12345\",\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportId\":0,\"DamageData\":[{\"BladeDamagePlacementId\":2,\"BladeDescription\":\"No Damage\",\"BladeEdgeId\":2,\"BladeInspectionDataId\":15,\"BladePictureNumber\":\"28\",\"BladeRadius\":9999.0,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":3,\"FormIOImageGUID\":\"40515382-2aae-4653-81b8-8ffdeed5177e\",\"PictureOrder\":null}],\"RepairRecordData\":{\"BladeAdditionalDocumentReference\":\"\",\"BladeAmbientTemp\":0.0,\"BladeGlassSupplier\":\"\",\"BladeGlassSupplierBatchNumbers\":\"\",\"BladeHardenerType\":\"\",\"BladeHardenerTypeBatchNumbers\":\"\",\"BladeHardenerTypeExpiryDate\":null,\"BladeHumidity\":0.0,\"BladePostCureMaxTemperature\":0.0,\"BladePostCureMinTemperature\":0.0,\"BladeResinType\":\"\",\"BladeResinTypeBatchNumbers\":\"\",\"BladeResinTypeExpiryDate\":null,\"BladeResinUsed\":0,\"BladeSurfaceMaxTemperature\":0.0,\"BladeSurfaceMinTemperature\":0.0,\"BladeTotalCureTime\":0,\"BladeTurnOffTime\":null,\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportBladeRepairRecordId\":0,\"strBladeHardenerTypeExpiryDate\":\"\",\"strBladeResinTypeExpiryDate\":\"\",\"strBladeTurnOffTime\":\"\"},\"VestasUniqueIdentifier\":\"65433\",\"strBladeLsCalibrationDate\":\"\"},\"Brand\":\"Vestas\",\"CIMCaseNumber\":0,\"CIRID\":500170,\"CIRTemplateGUID\":\"\",\"CirDataID\":0,\"CirName\":\"\",\"CommisioningDate\":\"0001-01-01T00:00:00\",\"ComponentInspectionReportId\":500170,\"ComponentInspectionReportName\":\"\",\"ComponentInspectionReportStateId\":1,\"ComponentInspectionReportTypeId\":1,\"ComponentInspectionReportVersion\":\"\",\"ComponentUpTowerSolutionID\":null,\"ConductedBy\":\"1\",\"Country\":\"\",\"CountryISOId\":0,\"Created\":\"0001-01-01T00:00:00\",\"CurrentUser\":\"WindAMSWebAPIDev\",\"Deleted\":\"0001-01-01T00:00:00\",\"DeletedBy\":\"\",\"Description\":\"Some Description\",\"DescriptionConsquential\":\"Some Consequential Problems\",\"DyanamicDecisionData\":null,\"DynamicTableInputs\":null,\"ErrorMessage\":\"\",\"FailureDate\":\"2018-01-17T00:00:00\",\"FlangDesc\":\"\",\"FormIOGUID\":\"94a6675f-2cf5-4219-8441-462cfd041cf3\",\"Gearbox\":null,\"General\":null,\"Generator\":null,\"Generator1Hrs\":100000,\"Generator2Hrs\":100000,\"HideLock\":\"\",\"HideProgress\":null,\"HideTemplateVer\":\"\",\"HtmlStr\":\"\",\"ImageData\":[{\"FlangNo\":0,\"FormIOImageGUID\":\"1412f3b7-51cc-4f9d-8051-616784a56d1d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ccd79761-276c-459e-bf74-e493f3acaa68/base64\",\"ImageDescription\":\"DSC06557##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":0,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ccd79761-276c-459e-bf74-e493f3acaa68/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"887f6a2d-7b08-4607-b97c-cfb3fa3f6da1\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4fcdcdd8-f99b-4725-85f9-896be88955a3/base64\",\"ImageDescription\":\"DSC06563##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":1,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4fcdcdd8-f99b-4725-85f9-896be88955a3/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a77f2870-12ee-4fe7-beea-f6563e6eee20\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/61ba700a-2511-4a24-af67-0860ae60acbb/base64\",\"ImageDescription\":\"DSC06567##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":2,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/61ba700a-2511-4a24-af67-0860ae60acbb/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"071bfe2f-cecb-485e-919d-a1f43abb265b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/02b045c7-35cd-4848-96fa-4266d5aab8ff/base64\",\"ImageDescription\":\"DSC06570##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":3,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/02b045c7-35cd-4848-96fa-4266d5aab8ff/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9f92fe91-7109-4412-9106-1481ca8cbb28\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ebe80caa-96d0-46a6-bc4f-760a2200fd57/base64\",\"ImageDescription\":\"DSC06572##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":4,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ebe80caa-96d0-46a6-bc4f-760a2200fd57/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e2fc4798-7f1f-47df-813a-5574a02f9cd5\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b211978c-a690-4f28-9743-2c4aa186a218/base64\",\"ImageDescription\":\"DSC06574##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":5,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b211978c-a690-4f28-9743-2c4aa186a218/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e19f2f66-a766-4327-aa78-15b1ccb8305b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9c99281f-f7fd-4544-b7fa-a1b7637f0d32/base64\",\"ImageDescription\":\"DSC06577##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":6,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9c99281f-f7fd-4544-b7fa-a1b7637f0d32/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d95dc35b-3ed4-49bd-aee6-71acba1ec8da\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/3e9d0914-c7e5-49f3-a135-89fc016660d4/base64\",\"ImageDescription\":\"DSC06580##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":7,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/3e9d0914-c7e5-49f3-a135-89fc016660d4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b15fb28a-589b-46f4-b628-9c3247e3fe8a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c3c69672-43fe-4b2e-a8b5-0529d8ec5dca/base64\",\"ImageDescription\":\"DSC06582##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":8,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c3c69672-43fe-4b2e-a8b5-0529d8ec5dca/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"dd4e9414-551b-4b4a-8d13-9929226f4581\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/39e4c979-770c-4cd5-ba35-849aed045614/base64\",\"ImageDescription\":\"DSC06583##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":9,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/39e4c979-770c-4cd5-ba35-849aed045614/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b4a47eb3-9414-4999-996e-bdc24a77eb91\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ebcceb1c-369b-492b-9181-f03fc2e0df12/base64\",\"ImageDescription\":\"DSC06584##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":10,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ebcceb1c-369b-492b-9181-f03fc2e0df12/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e9e0e2e7-c5ba-42de-8f64-19bcb628ad15\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/19beb582-6f6b-4d8f-a4a0-38c3d2040029/base64\",\"ImageDescription\":\"DSC06587##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":11,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/19beb582-6f6b-4d8f-a4a0-38c3d2040029/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"87eb1270-5442-4446-9191-6fe157fcedc7\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/38c41489-814b-414f-b2da-293bd69c8752/base64\",\"ImageDescription\":\"DSC06588##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":12,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/38c41489-814b-414f-b2da-293bd69c8752/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6f922a82-3cd0-46c3-8581-5fc418bd3651\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f0266eb3-a88a-470f-9cda-f8221feacc25/base64\",\"ImageDescription\":\"DSC06590##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":13,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f0266eb3-a88a-470f-9cda-f8221feacc25/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4ab7752b-2503-4036-a15d-15c59c706f60\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a306b6c5-39c4-4287-abd5-5ff68fa8c6d8/base64\",\"ImageDescription\":\"DSC06592##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":14,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a306b6c5-39c4-4287-abd5-5ff68fa8c6d8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"98cdb595-1981-49c5-856a-fc74e0e7d3cf\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c7bbfd6-f40c-4966-acf6-8d826b8cfad5/base64\",\"ImageDescription\":\"DSC06594##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":15,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c7bbfd6-f40c-4966-acf6-8d826b8cfad5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5920cda9-7841-4243-9780-d1b0785f0715\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/592cb76c-d94c-45f1-a6f0-c174ab321b4c/base64\",\"ImageDescription\":\"DSC06596##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":16,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/592cb76c-d94c-45f1-a6f0-c174ab321b4c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"00a5fedd-afba-4dad-9350-83a52c079dd2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4c5d720d-b184-426c-bc1a-bae963485476/base64\",\"ImageDescription\":\"DSC06598##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":17,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4c5d720d-b184-426c-bc1a-bae963485476/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1deb45fc-cfba-49c1-94f4-37a8891c47a6\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9e07f7e9-56ee-47d7-8630-2956d792d9c4/base64\",\"ImageDescription\":\"DSC06599##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":18,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9e07f7e9-56ee-47d7-8630-2956d792d9c4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2cdaaa96-626f-4ac8-ba7b-60a64953c3d5\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/65f9a190-0c4c-4dec-a076-4c5f37ae83d7/base64\",\"ImageDescription\":\"DSC06600##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":19,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/65f9a190-0c4c-4dec-a076-4c5f37ae83d7/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"74aed2eb-3b80-4e2d-b19f-171e328624d0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7e1c35a9-a308-4773-b5eb-7dd704a34d55/base64\",\"ImageDescription\":\"DSC06602##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":20,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7e1c35a9-a308-4773-b5eb-7dd704a34d55/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d0f42eef-c647-4c38-837b-2a870556cbd3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/44cca93e-6e29-4525-865c-6ad496d3c120/base64\",\"ImageDescription\":\"DSC06604##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":21,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/44cca93e-6e29-4525-865c-6ad496d3c120/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e07e1cb8-ce36-49e3-891b-c4d3b80e3f90\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/77b8c5b5-2518-45d3-86ec-10c475a72427/base64\",\"ImageDescription\":\"DSC06606##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":22,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/77b8c5b5-2518-45d3-86ec-10c475a72427/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c526c5a3-487f-4b37-880a-79fa2f19fde4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5f9a92b7-0515-49d0-84f7-a849f510f9d4/base64\",\"ImageDescription\":\"DSC06608##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":23,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5f9a92b7-0515-49d0-84f7-a849f510f9d4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"72e5ab8e-34ec-4c6b-8c86-baddc88894b8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/59414c4a-3348-4674-bc38-37865c10caaf/base64\",\"ImageDescription\":\"DSC06610##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":24,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/59414c4a-3348-4674-bc38-37865c10caaf/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"64665435-b60c-4820-82d2-35221e109ab4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6f0cb558-c4ff-4b38-b1a4-afb5b1f24880/base64\",\"ImageDescription\":\"DSC06611##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":25,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6f0cb558-c4ff-4b38-b1a4-afb5b1f24880/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"3946566d-b06a-4a14-bdb0-680d0bd6ba2e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/72376de5-e515-4cd4-bc5e-b5cb4dc3ed44/base64\",\"ImageDescription\":\"DSC06613##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":26,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/72376de5-e515-4cd4-bc5e-b5cb4dc3ed44/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"21ca51b4-b657-4b5e-9a8c-1b4669fc9d02\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ab25c91b-41ce-4990-a759-a7263468caee/base64\",\"ImageDescription\":\"DSC06615##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":27,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ab25c91b-41ce-4990-a759-a7263468caee/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"40515382-2aae-4653-81b8-8ffdeed5177e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b9a1ece7-c019-4d09-91ac-a0490673298b/base64\",\"ImageDescription\":\"DSC06616##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":28,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b9a1ece7-c019-4d09-91ac-a0490673298b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"eaaaeabc-00de-460d-b2ac-4e0634c5b0de\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/38354bcd-a4d4-4305-be0c-b5a7740c3c5b/base64\",\"ImageDescription\":\"DSC06633##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":29,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/38354bcd-a4d4-4305-be0c-b5a7740c3c5b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"85182bbc-c402-479c-81bc-14492f152370\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f54fa60-a359-4ffe-91f2-2eacb842c224/base64\",\"ImageDescription\":\"DSC06634##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":30,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f54fa60-a359-4ffe-91f2-2eacb842c224/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"dea39c6b-106d-4a2d-a8e3-9ab5ace359ff\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7611f6e8-ef3b-4060-b5eb-0d1b505bb67f/base64\",\"ImageDescription\":\"DSC06638##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":31,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7611f6e8-ef3b-4060-b5eb-0d1b505bb67f/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c3c23153-08c2-4109-8e2a-fbbd82c49efb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e3082d5e-5e4c-485e-8417-9011442087eb/base64\",\"ImageDescription\":\"DSC06641##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":32,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e3082d5e-5e4c-485e-8417-9011442087eb/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a1bcfed2-ae78-4c60-81da-f353c82657c7\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/94950d65-c841-46af-bf99-aa4d52abdbd9/base64\",\"ImageDescription\":\"DSC06643##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":33,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/94950d65-c841-46af-bf99-aa4d52abdbd9/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9a3c8dfd-71fa-4da9-9792-327242c454b9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/30916836-3e6e-4ae5-bbe0-6fd8c6e8512b/base64\",\"ImageDescription\":\"DSC06644##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":34,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/30916836-3e6e-4ae5-bbe0-6fd8c6e8512b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e02a5b96-d5ac-4329-98fb-60c267dac7d3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c2b14d6a-5519-4fc1-a810-707d989d137c/base64\",\"ImageDescription\":\"DSC06647##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":35,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c2b14d6a-5519-4fc1-a810-707d989d137c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fc6e4919-9c64-40f2-ac9a-d245cf517328\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/47987758-7c04-41b0-810d-1cd458488abd/base64\",\"ImageDescription\":\"DSC06650##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":36,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/47987758-7c04-41b0-810d-1cd458488abd/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c28bc22b-376b-4182-917e-a6e6d9496867\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/782f3f3c-23e5-4afc-9839-8b6bb7ae2d86/base64\",\"ImageDescription\":\"DSC06653##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":37,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/782f3f3c-23e5-4afc-9839-8b6bb7ae2d86/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ef03973e-fd52-4f0f-a54b-9558ad3b57b5\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/12ef5909-c89f-4f0a-adaf-f571cf1016d0/base64\",\"ImageDescription\":\"DSC06655##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":38,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/12ef5909-c89f-4f0a-adaf-f571cf1016d0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e20580c5-694e-4dc2-8793-51bd833bd983\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/568cb7fa-b985-4c3e-9ecd-a799a6b5198b/base64\",\"ImageDescription\":\"DSC06656##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":39,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/568cb7fa-b985-4c3e-9ecd-a799a6b5198b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"62ca8a6d-ae5d-44a0-bc8f-98155ab17556\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e48c4c9-a1de-408f-85ef-bad64a5b9461/base64\",\"ImageDescription\":\"DSC06658##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":40,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e48c4c9-a1de-408f-85ef-bad64a5b9461/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"232c5880-e7bc-412b-a057-1d1f380d143c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7613df84-4650-461b-86ff-1619078fdf40/base64\",\"ImageDescription\":\"DSC06660##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":41,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7613df84-4650-461b-86ff-1619078fdf40/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"80b48cb2-c052-4eef-9097-dc2d1ac04ab2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2e0a144b-b3e7-4c7d-8732-ca69f68b2c66/base64\",\"ImageDescription\":\"DSC06662##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":42,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2e0a144b-b3e7-4c7d-8732-ca69f68b2c66/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c1a4845f-0f01-4e47-bc4d-0137cac9ee72\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a02052c6-b23b-47dc-9007-d7f43d0d5ebd/base64\",\"ImageDescription\":\"DSC06664##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":43,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a02052c6-b23b-47dc-9007-d7f43d0d5ebd/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"aa28991f-4f88-4ec1-bc7a-4f1d087cff0c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8330b6a9-872e-4811-b461-971f9994de23/base64\",\"ImageDescription\":\"DSC06665##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":44,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8330b6a9-872e-4811-b461-971f9994de23/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d9513ed9-cb40-423b-8098-ef14e4d645d9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bacdef57-8bd7-4fd8-8326-598e8dd1f8e8/base64\",\"ImageDescription\":\"DSC06667##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":45,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bacdef57-8bd7-4fd8-8326-598e8dd1f8e8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"be69b97a-c4d1-4954-811e-36975da8db89\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/78c81838-093d-47df-8929-f37e2fc92528/base64\",\"ImageDescription\":\"DSC06669##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":46,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/78c81838-093d-47df-8929-f37e2fc92528/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"bad72212-86f2-4055-9949-d89d6302869f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5b958e0f-9fad-483b-b346-3ae247e2b73a/base64\",\"ImageDescription\":\"DSC06670##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":47,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5b958e0f-9fad-483b-b346-3ae247e2b73a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6303daf1-a615-483f-b70c-ec57af7f2b2d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bdad6200-fa4d-4225-9c73-53436b251e25/base64\",\"ImageDescription\":\"DSC06671##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":48,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bdad6200-fa4d-4225-9c73-53436b251e25/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5e5604a9-8620-4e4a-80b4-cd42a7d99d34\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1068c905-16f3-448f-ab65-b866841d738d/base64\",\"ImageDescription\":\"DSC06673##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":49,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1068c905-16f3-448f-ab65-b866841d738d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5e263177-5322-48ba-afa2-26d425cb45cd\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c680c20-e535-44cf-ac15-c61ffb03e81b/base64\",\"ImageDescription\":\"DSC06675##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":50,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c680c20-e535-44cf-ac15-c61ffb03e81b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a9d79f92-8e1c-4039-8d7c-6917cd677df0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d52bca87-c47f-4a52-911a-5b47cea3dc75/base64\",\"ImageDescription\":\"DSC06677##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":51,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d52bca87-c47f-4a52-911a-5b47cea3dc75/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b090e8cd-302c-4332-8603-79678e3d83bf\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0ce52016-f969-4a63-ac60-f351d836cea2/base64\",\"ImageDescription\":\"DSC06679##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":52,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0ce52016-f969-4a63-ac60-f351d836cea2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1036c878-edc6-440c-b184-64133b70ca61\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/11bb52f8-efc0-4529-a87e-bb2e76ce2cc8/base64\",\"ImageDescription\":\"DSC06681##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":53,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/11bb52f8-efc0-4529-a87e-bb2e76ce2cc8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8ad3741b-e7dd-4fa6-8bd6-5ab88a30b4ee\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ef5db0bb-e7e7-407b-bdcc-97c364feea47/base64\",\"ImageDescription\":\"DSC06684##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":54,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ef5db0bb-e7e7-407b-bdcc-97c364feea47/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6a67ddc1-9af5-4b3a-971e-c8cf5d0b86cc\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bc2b16f2-5f67-4890-850b-d8c9c6c2801c/base64\",\"ImageDescription\":\"DSC06687##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":55,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bc2b16f2-5f67-4890-850b-d8c9c6c2801c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a31e8c18-83df-4577-8e56-509dd23d7882\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/afa0f740-9837-48d6-97ea-ebe394e77048/base64\",\"ImageDescription\":\"DSC06688##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":56,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/afa0f740-9837-48d6-97ea-ebe394e77048/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5293800c-7bcb-40e3-a299-0bd06856562d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c145c06f-d89f-45b0-8932-9fca917bfd88/base64\",\"ImageDescription\":\"DSC06689##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":57,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c145c06f-d89f-45b0-8932-9fca917bfd88/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4535ce77-644e-4d98-a2a3-7045b8fc4717\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d2a0aa2d-d1fb-49ba-871a-a55b9673fd83/base64\",\"ImageDescription\":\"DSC06691##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":58,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d2a0aa2d-d1fb-49ba-871a-a55b9673fd83/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1632b442-0a20-49af-9cb8-0b2aded77a84\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6bbbe12e-f079-453e-80f6-ca71c4a2efa9/base64\",\"ImageDescription\":\"DSC06693##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":59,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6bbbe12e-f079-453e-80f6-ca71c4a2efa9/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"41fd6aad-e42f-4ffa-856d-ced79ee113e9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/31561783-fcd3-42f9-a0fe-589fd0f10e93/base64\",\"ImageDescription\":\"DSC06698##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":60,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/31561783-fcd3-42f9-a0fe-589fd0f10e93/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"bfacd2a2-84d9-4ff2-a560-d7628c184cd8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7d9c40e1-5f84-4ee9-ad0b-a6971505fe34/base64\",\"ImageDescription\":\"DSC06706##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":61,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7d9c40e1-5f84-4ee9-ad0b-a6971505fe34/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"435a1288-fbf9-493c-ac45-21efef548f14\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/206fb378-bd3e-48c7-8b38-acc130472ed0/base64\",\"ImageDescription\":\"DSC06714##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":62,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/206fb378-bd3e-48c7-8b38-acc130472ed0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"979caec5-4c76-4bca-a124-b790e921844a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9459550f-9ca5-4419-ba56-00512e846fea/base64\",\"ImageDescription\":\"DSC06721##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":63,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9459550f-9ca5-4419-ba56-00512e846fea/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c3df8902-7feb-47ae-a5b5-70d2736df204\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/3972d5ad-95f2-4990-bf94-e67a706e86af/base64\",\"ImageDescription\":\"DSC06722##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":64,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/3972d5ad-95f2-4990-bf94-e67a706e86af/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6632ac0b-492b-4347-90f2-b4a2ac3320f8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/308850a4-63f6-4038-b87a-a81146d2ed0e/base64\",\"ImageDescription\":\"DSC06723##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":65,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/308850a4-63f6-4038-b87a-a81146d2ed0e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8711705a-cfa8-4962-9f21-4c3f68644674\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/27fb2811-bfdb-49cb-a745-7e170c310884/base64\",\"ImageDescription\":\"DSC06727##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":66,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/27fb2811-bfdb-49cb-a745-7e170c310884/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"eb54135e-acac-465d-948c-7a6f5e0f2914\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5ef9b509-7a05-4cae-8eef-d1739d18d807/base64\",\"ImageDescription\":\"DSC06728##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":67,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5ef9b509-7a05-4cae-8eef-d1739d18d807/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c8ea86d3-0934-482f-b7ec-fcf8b51c2f8d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/83c4e0c1-b70c-4366-82aa-75d2b5109574/base64\",\"ImageDescription\":\"DSC06729##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":68,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/83c4e0c1-b70c-4366-82aa-75d2b5109574/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7ba4f34b-e1ea-421e-86c5-46f44713229d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4265a45d-8a05-43a8-8bf4-50af4bd0c02c/base64\",\"ImageDescription\":\"DSC06730##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":69,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4265a45d-8a05-43a8-8bf4-50af4bd0c02c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b6ac2f94-9cc9-40c4-acd0-818e2fb58b73\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/316773a3-bf66-46a2-896b-d641ed58e7d2/base64\",\"ImageDescription\":\"DSC06731##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":70,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/316773a3-bf66-46a2-896b-d641ed58e7d2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"cc76f3b5-0403-4b38-aa6b-6b13b3bba16a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ccaea544-8092-4a6c-86f9-7d4dbc8227c5/base64\",\"ImageDescription\":\"DSC06732##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":71,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ccaea544-8092-4a6c-86f9-7d4dbc8227c5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4e578c8b-cd6c-4eb1-a1c9-2053fabc733e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/087fe237-8635-4114-83b2-f879ec65b385/base64\",\"ImageDescription\":\"DSC06733##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":72,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/087fe237-8635-4114-83b2-f879ec65b385/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"af71c725-29bf-4b24-a134-6a4bb5ea36fc\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/384bd53f-74bc-4f25-ab6b-5b7665fdb55e/base64\",\"ImageDescription\":\"DSC06734##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":73,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/384bd53f-74bc-4f25-ab6b-5b7665fdb55e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"27eebfa3-3826-4862-bbea-e44f0177b970\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/47075d55-ec5b-4288-97f0-0dea3492c7d4/base64\",\"ImageDescription\":\"DSC06735##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":74,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/47075d55-ec5b-4288-97f0-0dea3492c7d4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a56f8aa0-43db-443a-a26a-03fe882d4f16\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/907c56a3-9daf-44c2-8a1d-733f3fb67bc0/base64\",\"ImageDescription\":\"DSC06736##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":75,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/907c56a3-9daf-44c2-8a1d-733f3fb67bc0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9eec4443-97c1-42d4-880a-b4537c01bea4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/952172d2-6f22-43d4-a518-11a4ad5bebae/base64\",\"ImageDescription\":\"DSC06737##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":76,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/952172d2-6f22-43d4-a518-11a4ad5bebae/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ec36cd9e-011d-42b6-8bbb-696c8f23e2fd\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a949834f-9855-450f-b524-7c0d30c197ae/base64\",\"ImageDescription\":\"DSC06739##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":77,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a949834f-9855-450f-b524-7c0d30c197ae/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"aa7ab661-ff75-46d0-9412-141a96db46dc\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fa8b9148-30a1-4b20-90bb-20beabf2eec7/base64\",\"ImageDescription\":\"DSC06740##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":78,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fa8b9148-30a1-4b20-90bb-20beabf2eec7/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"118f2b26-0ff6-4d64-8551-cb5271d165a4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c98f9bd3-2f0e-458f-83e8-6b1790683836/base64\",\"ImageDescription\":\"DSC06741##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":79,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c98f9bd3-2f0e-458f-83e8-6b1790683836/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ef95c138-be6e-4583-a9b9-56f9bc3083c8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/3b4d546d-d9ff-47ec-b089-a72304f7aff4/base64\",\"ImageDescription\":\"DSC06742##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":80,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/3b4d546d-d9ff-47ec-b089-a72304f7aff4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5a05d34e-440c-485b-b960-5ec1948e196b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8be55683-dea8-4042-a6ad-3a697dfba896/base64\",\"ImageDescription\":\"DSC06743##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":81,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8be55683-dea8-4042-a6ad-3a697dfba896/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"333f6c64-6600-4608-ba50-51ebd2efbb23\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f840f9d1-a749-412b-ad72-82196ae14264/base64\",\"ImageDescription\":\"DSC06744##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":82,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f840f9d1-a749-412b-ad72-82196ae14264/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"18b1fbc2-0420-4caa-a4ea-7b32a2621cc9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e26eee90-d115-4ebc-b05a-a8f07ad4f29c/base64\",\"ImageDescription\":\"DSC06745##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":83,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e26eee90-d115-4ebc-b05a-a8f07ad4f29c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0ef242fd-d3b3-48b3-b4e6-12a9f5d23b81\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f7748249-d440-4a45-abf7-8c2d213f7134/base64\",\"ImageDescription\":\"DSC06746##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":84,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f7748249-d440-4a45-abf7-8c2d213f7134/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4b0ed08d-04e3-4846-a684-612c79aadec7\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c610979a-afe3-48aa-85c6-f9413daa20a3/base64\",\"ImageDescription\":\"DSC06747##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":85,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c610979a-afe3-48aa-85c6-f9413daa20a3/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f46c332f-24b0-44e3-8b95-23b0ed331f04\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/14bfd807-5bcf-4cdb-a5cf-5f288245cf4b/base64\",\"ImageDescription\":\"DSC06748##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":86,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/14bfd807-5bcf-4cdb-a5cf-5f288245cf4b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1c78a094-76c1-4935-92b0-3afe287e4261\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d7a1fca6-a794-4bff-8e34-0944c3a22996/base64\",\"ImageDescription\":\"DSC06749##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":87,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d7a1fca6-a794-4bff-8e34-0944c3a22996/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c2730dc2-2860-4f58-8fd6-d5536b2ec916\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2ebcd329-e92a-43a3-ad2f-6e27440ad761/base64\",\"ImageDescription\":\"DSC06750##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":88,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2ebcd329-e92a-43a3-ad2f-6e27440ad761/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"820069ea-baf4-466b-bed1-e976d9256a25\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/38fba53a-3e4f-4618-b806-fd25df8b9a85/base64\",\"ImageDescription\":\"DSC06751##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":89,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/38fba53a-3e4f-4618-b806-fd25df8b9a85/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"65bfad33-9be1-4947-8201-02c9daae65d0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/635e9f0f-3666-40a1-8ca0-4db3967b91d5/base64\",\"ImageDescription\":\"DSC06752##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":90,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/635e9f0f-3666-40a1-8ca0-4db3967b91d5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b9ef6955-d134-4e41-9410-a27418a742a8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1cceab51-4b53-4b19-805b-3bd8e0e38c5c/base64\",\"ImageDescription\":\"DSC06753##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":91,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1cceab51-4b53-4b19-805b-3bd8e0e38c5c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2a3e7566-f12c-4da5-a606-5112e2e64f1f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7eddb425-ca47-4c97-804e-9c6af3ed8933/base64\",\"ImageDescription\":\"DSC06754##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":92,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7eddb425-ca47-4c97-804e-9c6af3ed8933/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"25021575-c90c-46ba-97e9-2bcd058cb282\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/887b3ad6-d471-452d-8731-b130f2d1abef/base64\",\"ImageDescription\":\"DSC06755##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":93,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/887b3ad6-d471-452d-8731-b130f2d1abef/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"12f33b00-3844-4f57-93db-b6580891d8e0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c48517c3-8bdc-4ae7-9b6d-e98c992ed42f/base64\",\"ImageDescription\":\"DSC06757##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":94,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c48517c3-8bdc-4ae7-9b6d-e98c992ed42f/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6de6d443-4fe4-4404-9264-514631fb66ee\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e6ef4ef-e2dd-4eb5-a1af-7be862341262/base64\",\"ImageDescription\":\"DSC06759##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":95,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e6ef4ef-e2dd-4eb5-a1af-7be862341262/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a019bc4e-33e5-465d-b62e-1517dc0fb982\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5761204b-0ade-478b-b054-9f969d549fc1/base64\",\"ImageDescription\":\"DSC06760##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":96,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5761204b-0ade-478b-b054-9f969d549fc1/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e26e42c3-9fe2-49f5-a6cb-3b693fe67077\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/00451d8e-9809-49d2-b9c4-d5d816826dd8/base64\",\"ImageDescription\":\"DSC06778##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":97,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/00451d8e-9809-49d2-b9c4-d5d816826dd8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"77f5dc89-f0f0-4d9c-9681-40c6e164fa07\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c9fbe4e4-ab41-46e3-bdc9-3254bd0dda2d/base64\",\"ImageDescription\":\"DSC06779##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":98,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c9fbe4e4-ab41-46e3-bdc9-3254bd0dda2d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"21a03fd0-5319-4b83-9742-1e7941fec177\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/11aa1121-1706-434f-ae82-d868ca97af12/base64\",\"ImageDescription\":\"DSC06785##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":99,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/11aa1121-1706-434f-ae82-d868ca97af12/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8c8935a6-d3a3-411e-8666-cde24c38c349\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/55d8a5c0-82bd-438e-8e95-cf676241d793/base64\",\"ImageDescription\":\"DSC06787##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":100,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/55d8a5c0-82bd-438e-8e95-cf676241d793/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"02dd0572-f6c8-486d-b5c3-6ae3e0293184\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e13347bc-a82f-4ab6-a745-cf1411405e63/base64\",\"ImageDescription\":\"DSC06789##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":101,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e13347bc-a82f-4ab6-a745-cf1411405e63/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f758f039-c102-4508-9e31-8d3072313cd4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fe72325b-142c-41ee-ae7e-43641dceab13/base64\",\"ImageDescription\":\"DSC06791##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":102,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fe72325b-142c-41ee-ae7e-43641dceab13/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"12b2f546-a3b9-47ed-a227-2f609ebfaf57\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f539b2e-926b-49b4-afa7-c22357847e19/base64\",\"ImageDescription\":\"DSC06792##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":103,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f539b2e-926b-49b4-afa7-c22357847e19/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7e7aa90a-5a79-48e0-85e5-eebf6eb70659\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e58f69ad-17fc-4d0e-a7dd-35a4c9ff63af/base64\",\"ImageDescription\":\"DSC06793##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":104,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e58f69ad-17fc-4d0e-a7dd-35a4c9ff63af/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b7401b82-892f-4459-8b81-d1319698b3a2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e6732ef-56f9-4724-b50d-ce6596e996b3/base64\",\"ImageDescription\":\"DSC06794##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":105,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5e6732ef-56f9-4724-b50d-ce6596e996b3/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"926d46e4-703b-4c2e-9b5a-6d9eea011e9a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/28132439-e2a2-476f-af99-3832478c0f64/base64\",\"ImageDescription\":\"DSC06796##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":106,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/28132439-e2a2-476f-af99-3832478c0f64/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6c6e2082-4d9b-4aad-be0e-debb79c6dddc\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/64033b66-1059-47c5-a961-b1dffa66be0a/base64\",\"ImageDescription\":\"DSC06798##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":107,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/64033b66-1059-47c5-a961-b1dffa66be0a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0b339740-1afd-4e79-a195-dcce565e5c03\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/34ddeeb5-23e0-4904-af8e-099bedaafb6d/base64\",\"ImageDescription\":\"DSC06799##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":108,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/34ddeeb5-23e0-4904-af8e-099bedaafb6d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b8049678-98c3-473d-909c-0fd69c9e9dab\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f91d6cc-00d1-448d-81fb-fc0f74fe0eb5/base64\",\"ImageDescription\":\"DSC06801##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":109,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f91d6cc-00d1-448d-81fb-fc0f74fe0eb5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"253a02c0-b4a5-4772-95cb-45250adf46c0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6afd7af0-0a07-40f7-9746-c1e3a609b0fa/base64\",\"ImageDescription\":\"DSC06802##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":110,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6afd7af0-0a07-40f7-9746-c1e3a609b0fa/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"89f6b59d-7089-45c4-9c75-2e9d1125cbd4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a5135a92-8760-4bfe-8b70-aebe13671cf2/base64\",\"ImageDescription\":\"DSC06803##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":111,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a5135a92-8760-4bfe-8b70-aebe13671cf2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8d942e15-f69c-4f20-acf1-bd616c4699e5\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf9c0cbc-0db3-4c13-bd88-64f153c4b844/base64\",\"ImageDescription\":\"DSC06805##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":112,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf9c0cbc-0db3-4c13-bd88-64f153c4b844/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8c9c8440-4393-4a70-a07d-97b27a38de62\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/25984403-50bd-4a9d-b264-085cb033e67e/base64\",\"ImageDescription\":\"DSC06806##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":113,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/25984403-50bd-4a9d-b264-085cb033e67e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"19f47407-bd19-4255-8b1b-26ed9df03aed\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2bfac576-4c1c-4d5d-b71d-67115b61cbe3/base64\",\"ImageDescription\":\"DSC06808##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":114,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2bfac576-4c1c-4d5d-b71d-67115b61cbe3/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"57ce5713-f2ba-4c08-acd5-534b0b53bcaa\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/870f7bd4-3294-4e47-90a9-ac735f7c7428/base64\",\"ImageDescription\":\"DSC06811##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":115,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/870f7bd4-3294-4e47-90a9-ac735f7c7428/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"507803d6-1520-4222-8801-7f097eaae445\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1dc38d14-5bb8-49e7-bd1b-6233399d6f93/base64\",\"ImageDescription\":\"DSC06813##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":116,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1dc38d14-5bb8-49e7-bd1b-6233399d6f93/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"94da54a9-923f-4afd-b65e-d65d6428c481\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/40ed9e59-53a1-47da-87eb-dc8c6389151c/base64\",\"ImageDescription\":\"DSC06816##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":117,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/40ed9e59-53a1-47da-87eb-dc8c6389151c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"95d93db1-da96-43e4-b4cc-6f3de7523dea\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/363b87dd-1bb6-4d5a-b1bc-e2421dd34b25/base64\",\"ImageDescription\":\"DSC06818##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":118,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/363b87dd-1bb6-4d5a-b1bc-e2421dd34b25/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"37844f77-ef88-4d44-a88a-4263cd40b11b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ec0a1dbd-548c-4114-8532-97d1c4478c6c/base64\",\"ImageDescription\":\"DSC06819##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":119,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ec0a1dbd-548c-4114-8532-97d1c4478c6c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"58cbd905-9579-4f4d-bdb2-aff33983c143\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a06c8c56-1b3b-482f-a92e-a5ff060a9e84/base64\",\"ImageDescription\":\"DSC06821##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":120,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a06c8c56-1b3b-482f-a92e-a5ff060a9e84/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8fe83884-75de-47c2-b971-b0ac9a09659b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/969228cf-7990-4e2d-bc7f-c8fd81890887/base64\",\"ImageDescription\":\"DSC06825##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":121,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/969228cf-7990-4e2d-bc7f-c8fd81890887/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"13aa6bde-21e3-406a-9f3a-973132d668dd\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7eb0628d-4cf2-4ce5-a67e-67e1170b45d8/base64\",\"ImageDescription\":\"DSC06828##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":122,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7eb0628d-4cf2-4ce5-a67e-67e1170b45d8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ad9410d8-00de-4eb6-b4aa-96795e759b32\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/27cd257e-274d-4eb3-a4fa-52fda9066edc/base64\",\"ImageDescription\":\"DSC06832##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":123,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/27cd257e-274d-4eb3-a4fa-52fda9066edc/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ac4ae375-d427-4c78-a346-39525198d785\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9a48c3e6-4619-4ce9-8920-b078bafb60b0/base64\",\"ImageDescription\":\"DSC06836##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":124,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9a48c3e6-4619-4ce9-8920-b078bafb60b0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c00e121b-420e-4094-a2a3-a51cff152824\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/75698e82-e699-4828-a46d-dd52c46701c5/base64\",\"ImageDescription\":\"DSC06837##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":125,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/75698e82-e699-4828-a46d-dd52c46701c5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false}],\"ImageDataInfo\":{\"IsPlateTypeNotPossible\":true,\"PlateTypeNotPossibleReason\":\"\"},\"InspectionDate\":\"2018-05-18T00:00:00\",\"InstallationDate\":null,\"InternalComments\":\"\",\"LocalTurbineId\":\"\",\"LocationTypeId\":6,\"MainBearing\":null,\"Modified\":\"0001-01-01T00:00:00\",\"MountedOnMainComponentBooleanAnswerId\":1,\"NotificationNumber\":\"\",\"OutSideSign\":false,\"Quantity\":0,\"ReasonForService\":\"\",\"ReconstructionBooleanAnswerId\":1,\"ReportTypeId\":1,\"RunHours\":5000,\"SBUId\":1,\"SBUName\":\"\",\"SBURecomendation\":\"\",\"SecondGeneratorBooleanAnswerId\":null,\"ServiceEngineer\":\"vestas\",\"ServiceReportNumber\":\"\",\"ServiceReportNumberTypeId\":3,\"SiteName\":\"Eckardtsheim (RNSP ISM BLA)\",\"Skiip\":null,\"TemplateVersion\":\"9\",\"TotalAcceptedRecords\":0,\"TotalProduction\":500000,\"TotalRecords\":0,\"TotalRejectedRecords\":0,\"TotalUnApprovedRecords\":0,\"Transformer\":null,\"TurbineData\":{\"Country\":\"\",\"CountryIsoId\":0,\"Frequency\":0,\"LocalTurbineId\":\"\",\"Manufacturer\":\"\",\"MarkVersion\":\"\",\"NominelPower\":0,\"NominelPowerId\":0,\"Placement\":\"\",\"PowerRegulation\":\"\",\"RotorDiameter\":0.0,\"Site\":\"\",\"SmallGenerator\":0,\"TemperatureVariant\":\"\",\"Turbine\":\"\",\"TurbineMatrixId\":0,\"Voltage\":0},\"TurbineMatrixId\":null,\"TurbineNumber\":0,\"TurbineType\":\"\",\"VestasItemNumber\":\"65433\",\"isSimplifiedCir\":false,\"strCommisioningDate\":\"\",\"strFailureDate\":\"2018/01/17T00:00:00\",\"strInspectionDate\":\"2018/05/18T00:00:00\",\"strInstallationDate\":\"\"}";
            // string tmp1 = "{\"AdditionalComments\":\"\",\"AfterInspectionTurbineRunStatusId\":1,\"AlarmLogNumber\":\"\",\"BeforeInspectionTurbineRunStatusId\":1,\"BladeData\":{\"BladeClaimRelevantBooleanAnswerId\":null,\"BladeColorId\":4,\"BladeDamageIdentified\":true,\"BladeFaultCodeAreaId\":8,\"BladeFaultCodeCauseId\":7,\"BladeFaultCodeClassificationId\":null,\"BladeFaultCodeTypeId\":18,\"BladeInspectionReportDescription\":\"\",\"BladeLengthId\":7,\"BladeLsCalibrationDate\":\"0001-01-01T00:00:00\",\"BladeLsLeewardSidePostRepair2\":null,\"BladeLsLeewardSidePostRepair3\":null,\"BladeLsLeewardSidePostRepair4\":null,\"BladeLsLeewardSidePostRepair5\":null,\"BladeLsLeewardSidePostRepair6\":null,\"BladeLsLeewardSidePostRepair7\":null,\"BladeLsLeewardSidePostRepair8\":null,\"BladeLsLeewardSidePostRepairTip\":null,\"BladeLsLeewardSidePreRepair2\":null,\"BladeLsLeewardSidePreRepair3\":null,\"BladeLsLeewardSidePreRepair4\":null,\"BladeLsLeewardSidePreRepair5\":null,\"BladeLsLeewardSidePreRepair6\":null,\"BladeLsLeewardSidePreRepair7\":null,\"BladeLsLeewardSidePreRepair8\":null,\"BladeLsLeewardSidePreRepairTip\":null,\"BladeLsVtNumber\":\"\",\"BladeLsWindwardSidePostRepair2\":null,\"BladeLsWindwardSidePostRepair3\":null,\"BladeLsWindwardSidePostRepair4\":null,\"BladeLsWindwardSidePostRepair5\":null,\"BladeLsWindwardSidePostRepair6\":null,\"BladeLsWindwardSidePostRepair7\":null,\"BladeLsWindwardSidePostRepair8\":null,\"BladeLsWindwardSidePostRepairTip\":null,\"BladeLsWindwardSidePreRepair2\":null,\"BladeLsWindwardSidePreRepair3\":null,\"BladeLsWindwardSidePreRepair4\":null,\"BladeLsWindwardSidePreRepair5\":null,\"BladeLsWindwardSidePreRepair6\":null,\"BladeLsWindwardSidePreRepair7\":null,\"BladeLsWindwardSidePreRepair8\":null,\"BladeLsWindwardSidePreRepairTip\":null,\"BladeManufacturerId\":2,\"BladeOtherSerialNumber1\":\"\",\"BladeOtherSerialNumber2\":\"\",\"BladePicturesIncludedBooleanAnswerId\":2,\"BladeSerialNumber\":\"13456\",\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportId\":0,\"DamageData\":[{\"BladeDamagePlacementId\":2,\"BladeDescription\":\"No Damage\",\"BladeEdgeId\":2,\"BladeInspectionDataId\":6,\"BladePictureNumber\":\"33\",\"BladeRadius\":9999.0,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":1,\"FormIOImageGUID\":\"354a4ad1-d9f4-4b84-9342-d3a103dbbd9e\",\"PictureOrder\":null}],\"RepairRecordData\":{\"BladeAdditionalDocumentReference\":\"\",\"BladeAmbientTemp\":0.0,\"BladeGlassSupplier\":\"\",\"BladeGlassSupplierBatchNumbers\":\"\",\"BladeHardenerType\":\"\",\"BladeHardenerTypeBatchNumbers\":\"\",\"BladeHardenerTypeExpiryDate\":null,\"BladeHumidity\":0.0,\"BladePostCureMaxTemperature\":0.0,\"BladePostCureMinTemperature\":0.0,\"BladeResinType\":\"\",\"BladeResinTypeBatchNumbers\":\"\",\"BladeResinTypeExpiryDate\":null,\"BladeResinUsed\":0,\"BladeSurfaceMaxTemperature\":0.0,\"BladeSurfaceMinTemperature\":0.0,\"BladeTotalCureTime\":0,\"BladeTurnOffTime\":null,\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportBladeRepairRecordId\":0,\"strBladeHardenerTypeExpiryDate\":\"\",\"strBladeResinTypeExpiryDate\":\"\",\"strBladeTurnOffTime\":\"\"},\"VestasUniqueIdentifier\":\"23456\",\"strBladeLsCalibrationDate\":\"\"},\"Brand\":\"Vestas\",\"CIMCaseNumber\":0,\"CIRID\":500250,\"CIRTemplateGUID\":\"\",\"CirDataID\":0,\"CirName\":\"\",\"CommisioningDate\":\"0001-01-01T00:00:00\",\"ComponentInspectionReportId\":500250,\"ComponentInspectionReportName\":\"\",\"ComponentInspectionReportStateId\":1,\"ComponentInspectionReportTypeId\":1,\"ComponentInspectionReportVersion\":\"\",\"ComponentUpTowerSolutionID\":null,\"ConductedBy\":\"1\",\"Country\":\"\",\"CountryISOId\":0,\"Created\":\"0001-01-01T00:00:00\",\"CurrentUser\":\"TEST3\",\"Deleted\":\"0001-01-01T00:00:00\",\"DeletedBy\":\"\",\"Description\":\"Description\",\"DescriptionConsquential\":\"Description of Consequential Problems\",\"DyanamicDecisionData\":null,\"DynamicTableInputs\":null,\"ErrorMessage\":\"\",\"FailureDate\":\"2018-01-20T00:00:00\",\"FlangDesc\":\"\",\"FormIOGUID\":\"59417d8e-2c5c-4bba-85fa-4adec94c24cf\",\"Gearbox\":null,\"General\":null,\"Generator\":null,\"Generator1Hrs\":100000,\"Generator2Hrs\":100000,\"HideLock\":\"\",\"HideProgress\":null,\"HideTemplateVer\":\"\",\"HtmlStr\":\"\",\"ImageData\":[{\"FlangNo\":0,\"FormIOImageGUID\":\"cb63286f-a180-4b27-826b-36503a9cdd5a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a641d778-d884-4f84-a5ce-f7fa85f128cd/base64\",\"ImageDescription\":\"_DSC0291##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":0,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a641d778-d884-4f84-a5ce-f7fa85f128cd/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"aca5aa61-0e26-4c77-816f-ed9ddc8067ad\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/30ea217a-0e28-4a9a-92f1-8e92bb90c749/base64\",\"ImageDescription\":\"_DSC0294##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":1,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/30ea217a-0e28-4a9a-92f1-8e92bb90c749/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f8a0fcc6-c034-48af-9ae7-d2811bd8ce6e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1a9c574a-ac51-4193-8525-ea41e5e80abc/base64\",\"ImageDescription\":\"_DSC0296##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":2,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1a9c574a-ac51-4193-8525-ea41e5e80abc/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a73aa0a9-b878-4ac1-befe-7f491551e96a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/256ae8a5-a0a8-4bae-be4d-da6c6aee4f1e/base64\",\"ImageDescription\":\"_DSC0297##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":3,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/256ae8a5-a0a8-4bae-be4d-da6c6aee4f1e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1ca5dc5c-314d-40a2-b1eb-d9debec60589\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b1b00cef-757a-464f-a299-d2aba10e66fd/base64\",\"ImageDescription\":\"_DSC0298##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":4,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b1b00cef-757a-464f-a299-d2aba10e66fd/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c82f0b61-b2d2-46b1-8c82-2136e5433e44\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/3193239d-4a7d-40e7-b57f-0535d9648ef0/base64\",\"ImageDescription\":\"_DSC0299##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":5,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/3193239d-4a7d-40e7-b57f-0535d9648ef0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e4416182-c35a-41d6-9aa8-f31eaa58db4e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ac35e878-d41c-4ed2-a1c9-f14bec1682cf/base64\",\"ImageDescription\":\"_DSC0300##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":6,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ac35e878-d41c-4ed2-a1c9-f14bec1682cf/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7f3dcc33-6011-4dd5-a844-757571c90a3c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/06847894-7206-471a-a7fa-324e88f314b2/base64\",\"ImageDescription\":\"_DSC0301##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":7,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/06847894-7206-471a-a7fa-324e88f314b2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2ddab4c2-2026-4287-a32f-2652195df0b4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/eaa3b179-2e46-4428-aec8-32a0bb63aef5/base64\",\"ImageDescription\":\"_DSC0303##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":8,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/eaa3b179-2e46-4428-aec8-32a0bb63aef5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a512f9ad-4d91-4be3-b162-1a63f8134660\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d7cec441-9c05-44b4-8ec0-8140e0999ab5/base64\",\"ImageDescription\":\"_DSC0305##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":9,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d7cec441-9c05-44b4-8ec0-8140e0999ab5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"053df82c-51c8-4fab-ac2d-8a0e80fdc7ca\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/aa68dbe7-bcd6-4624-ac80-36846047cb61/base64\",\"ImageDescription\":\"_DSC0306##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":10,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/aa68dbe7-bcd6-4624-ac80-36846047cb61/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9cd59c33-6598-44d1-9c09-4094bfc1037b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/07ed09da-041f-4ee7-be4d-5414e47c3206/base64\",\"ImageDescription\":\"_DSC0307##TE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":11,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/07ed09da-041f-4ee7-be4d-5414e47c3206/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"22a7cc79-e235-492e-9793-a5545421827c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1d5750e0-9985-4ce6-bc4a-9ce3ca52293e/base64\",\"ImageDescription\":\"_DSC0308##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":12,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1d5750e0-9985-4ce6-bc4a-9ce3ca52293e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"936502b0-b6dd-4728-a845-d47dd1391655\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1501f00e-5ced-49c6-b09f-4bddaa376dd9/base64\",\"ImageDescription\":\"_DSC0309##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":13,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1501f00e-5ced-49c6-b09f-4bddaa376dd9/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d7f8e09d-722e-4367-8c67-52bb87b91b5b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/05d125fe-59c3-4185-8478-8615dd851cd4/base64\",\"ImageDescription\":\"_DSC0310##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":14,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/05d125fe-59c3-4185-8478-8615dd851cd4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8f24deb3-59ec-4b2c-87aa-56474b912471\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6154c328-2c79-47d6-bfd4-672810b791e2/base64\",\"ImageDescription\":\"_DSC0311##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":15,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6154c328-2c79-47d6-bfd4-672810b791e2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4f61dbb0-df7a-4ce0-bf14-ca4e4431c20c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4f72c947-9773-46d5-aa1b-ccabd476d304/base64\",\"ImageDescription\":\"_DSC0312##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":16,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4f72c947-9773-46d5-aa1b-ccabd476d304/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"86d18228-75a5-4920-8863-2230341c1fed\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/44c40941-bc12-4ca6-a980-075470f0110e/base64\",\"ImageDescription\":\"_DSC0313##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":17,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/44c40941-bc12-4ca6-a980-075470f0110e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9082b847-68e4-4eb6-9d30-f9272fccea2f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/833f772c-ca59-43ee-a297-1be79bacf324/base64\",\"ImageDescription\":\"_DSC0314##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":18,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/833f772c-ca59-43ee-a297-1be79bacf324/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2139a139-0a82-498b-92ae-ff11b9308bd0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e7a8c46e-5293-4a2f-89bf-c3c6371dd02d/base64\",\"ImageDescription\":\"_DSC0315##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":19,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e7a8c46e-5293-4a2f-89bf-c3c6371dd02d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e9699bf8-dbf5-4a14-96e9-d616158fb430\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ad77424e-bdde-4085-a8a5-958fc1a70caa/base64\",\"ImageDescription\":\"_DSC0316##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":20,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ad77424e-bdde-4085-a8a5-958fc1a70caa/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"cbe38300-3ea5-44b8-b481-c706495ea2ba\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/38c0885e-6e78-4afd-b8ac-569f8e6c4526/base64\",\"ImageDescription\":\"_DSC0317##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":21,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/38c0885e-6e78-4afd-b8ac-569f8e6c4526/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e9b2126c-6b4b-422e-8b76-3b2eeb055b0c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6500dccb-15cf-4a45-b335-08c1f08a8479/base64\",\"ImageDescription\":\"_DSC0318##TE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":22,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6500dccb-15cf-4a45-b335-08c1f08a8479/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"73d6e140-0f60-469d-bce9-b70e41fc2a12\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/107af092-59b3-41fe-81c2-fb1d525429d8/base64\",\"ImageDescription\":\"_DSC0319##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":23,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/107af092-59b3-41fe-81c2-fb1d525429d8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1ce6ff7c-6f43-4543-a9f6-fcaebb6975b2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7469ebfb-9f7e-4d10-aa75-6a810f31f497/base64\",\"ImageDescription\":\"_DSC0320##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":24,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7469ebfb-9f7e-4d10-aa75-6a810f31f497/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7eea1756-8d6a-41ab-a337-95233a255714\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7771ec64-7eed-42c6-b083-fff5b31f3098/base64\",\"ImageDescription\":\"_DSC0321##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":25,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7771ec64-7eed-42c6-b083-fff5b31f3098/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"84b5893a-feeb-4f35-8c8e-36d026e659ce\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c8714cf-2625-49b7-814b-d2c5abf556c6/base64\",\"ImageDescription\":\"_DSC0322##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":26,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0c8714cf-2625-49b7-814b-d2c5abf556c6/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2600179a-87ff-4128-8fd3-e8d7f1e8280b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/eb9a4fbc-7cff-47e2-ad21-44d7874163ab/base64\",\"ImageDescription\":\"_DSC0323##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":27,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/eb9a4fbc-7cff-47e2-ad21-44d7874163ab/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"81c1864b-a9b2-4e25-8a48-103c9a54b7f2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce0357d6-5ad6-4362-85a1-12b670691471/base64\",\"ImageDescription\":\"_DSC0324##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":28,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce0357d6-5ad6-4362-85a1-12b670691471/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4def2cec-68db-4fc6-9c86-4f7b53704e8c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/792cc290-52e4-4b89-9856-1a5126d27023/base64\",\"ImageDescription\":\"_DSC0325##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":29,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/792cc290-52e4-4b89-9856-1a5126d27023/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b5e9fa3f-50d4-424e-9e9d-5e031b5d1e84\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/3764e256-18e5-4a48-8513-2e0deba8d33e/base64\",\"ImageDescription\":\"_DSC0326##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":30,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/3764e256-18e5-4a48-8513-2e0deba8d33e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5270e7a1-ce63-4fa1-b698-1573f163af54\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f059eceb-61fe-4276-95c7-ad5073a40eb4/base64\",\"ImageDescription\":\"_DSC0327##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":31,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f059eceb-61fe-4276-95c7-ad5073a40eb4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5b7c9492-b38e-4539-8869-4324719e6e02\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/364cb6f6-651f-4ee2-8fec-8bcf5cb1dfea/base64\",\"ImageDescription\":\"_DSC0328##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":32,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/364cb6f6-651f-4ee2-8fec-8bcf5cb1dfea/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"354a4ad1-d9f4-4b84-9342-d3a103dbbd9e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e2fda87d-c74b-454b-a166-b49683d4d05a/base64\",\"ImageDescription\":\"_DSC0329##TE Root - no damage\",\"ImageId\":0,\"ImageOrder\":33,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e2fda87d-c74b-454b-a166-b49683d4d05a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"aabe9670-1a16-4a8a-a5d3-ac38ce72ce6a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4102756c-028d-4cd9-8284-28f860d8d653/base64\",\"ImageDescription\":\"_DSC0340##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":34,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4102756c-028d-4cd9-8284-28f860d8d653/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"3839a23d-4920-4911-8304-d16745a0c4eb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1c829e87-1f82-4856-862f-07e2d32246ba/base64\",\"ImageDescription\":\"_DSC0341##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":35,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1c829e87-1f82-4856-862f-07e2d32246ba/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a2908644-1f43-4bc8-be44-a1792537c26c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/106bf7ba-7185-41c1-8230-24148b91348b/base64\",\"ImageDescription\":\"_DSC0342##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":36,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/106bf7ba-7185-41c1-8230-24148b91348b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4c4d2d54-b2f5-4bb8-b1f6-94220516ed4c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/79f0f202-1e96-4797-8552-6a66ef5a294d/base64\",\"ImageDescription\":\"_DSC0344##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":37,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/79f0f202-1e96-4797-8552-6a66ef5a294d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6225cea0-ff23-4a6b-9b8f-5afb69a455b3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/cfbe7f50-7b28-4334-a63c-219183a6774e/base64\",\"ImageDescription\":\"_DSC0346##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":38,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/cfbe7f50-7b28-4334-a63c-219183a6774e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"82f8100e-68eb-4819-9f15-e77535d8cad3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1a90ec21-61aa-488b-97cb-b638a9a99535/base64\",\"ImageDescription\":\"_DSC0348##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":39,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1a90ec21-61aa-488b-97cb-b638a9a99535/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fa02a8e4-e685-4cd9-aacc-39f847958b12\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/74131013-a03c-47da-8bf6-282282624e59/base64\",\"ImageDescription\":\"_DSC0350##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":40,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/74131013-a03c-47da-8bf6-282282624e59/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2a9837f4-66c8-446b-b470-cf9e74c9562f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5ddb9cf4-b736-491f-a7d2-3cccf6b96db4/base64\",\"ImageDescription\":\"_DSC0351##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":41,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5ddb9cf4-b736-491f-a7d2-3cccf6b96db4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a158aa94-2211-4f10-98d1-458d1b0de117\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2816148c-7716-4f4d-82d3-865cb68ff9be/base64\",\"ImageDescription\":\"_DSC0352##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":42,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2816148c-7716-4f4d-82d3-865cb68ff9be/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2d0bfa1b-0352-41b5-85f0-ecfa30dab701\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/efdaf743-da99-4d03-9b58-144501fcab83/base64\",\"ImageDescription\":\"_DSC0353##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":43,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/efdaf743-da99-4d03-9b58-144501fcab83/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fd3a48b5-54c9-47c3-b3fd-8f8a1e688d75\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/241a4895-c07c-4944-a517-f5b347ce4b2a/base64\",\"ImageDescription\":\"_DSC0354##LW Root - no damage\",\"ImageId\":0,\"ImageOrder\":44,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/241a4895-c07c-4944-a517-f5b347ce4b2a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b5adec52-f59e-469f-af2c-b28bfa8865a9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/05ee500b-3421-4407-84e8-b7848c7255fa/base64\",\"ImageDescription\":\"_DSC0355##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":45,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/05ee500b-3421-4407-84e8-b7848c7255fa/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f2ca41d4-e4d0-4c78-8118-05defa1d98ac\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/24d6016a-87f6-4f1e-a5b4-c2d11564ac00/base64\",\"ImageDescription\":\"_DSC0356##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":46,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/24d6016a-87f6-4f1e-a5b4-c2d11564ac00/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0a01ee65-bdcc-4446-a768-e2dc17f18a5d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d054b423-229c-45a7-b738-c12659da8e30/base64\",\"ImageDescription\":\"_DSC0357##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":47,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d054b423-229c-45a7-b738-c12659da8e30/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"1fc6a78c-0c42-45ec-8e2c-4938e931107c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d8c65a9b-477a-411e-b442-c8e65cf8deba/base64\",\"ImageDescription\":\"_DSC0358##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":48,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d8c65a9b-477a-411e-b442-c8e65cf8deba/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0523ab1f-f1b3-4408-855e-ab4301aa2647\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/48b6b91e-b551-4a42-8669-3c0de823c31e/base64\",\"ImageDescription\":\"_DSC0359##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":49,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/48b6b91e-b551-4a42-8669-3c0de823c31e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0d63df5b-d9ba-470c-ba3d-bbfeaa8610e8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/252641bb-c7a3-4817-8bd7-c07d4f22ed84/base64\",\"ImageDescription\":\"_DSC0360##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":50,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/252641bb-c7a3-4817-8bd7-c07d4f22ed84/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7d5bdb40-9a99-4e79-b2cf-d4ac47851af1\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce82f67f-b71f-4027-9ab3-9a526167d964/base64\",\"ImageDescription\":\"_DSC0361##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":51,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce82f67f-b71f-4027-9ab3-9a526167d964/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a80a18bf-b385-4f0d-a6a0-e2827afd69a0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf96eae1-4627-421c-bd65-e3b94fb6bb3c/base64\",\"ImageDescription\":\"_DSC0362##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":52,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf96eae1-4627-421c-bd65-e3b94fb6bb3c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6661813c-2ccb-474b-b1ad-e2eb4d12d9fb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/cf5f3359-1273-4aa7-bf20-1fe88033749b/base64\",\"ImageDescription\":\"_DSC0363##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":53,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/cf5f3359-1273-4aa7-bf20-1fe88033749b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"213c6004-2cfb-4d47-868d-a985ca26b53e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b2d9b9ab-5200-4581-89bb-e791ed783ec0/base64\",\"ImageDescription\":\"_DSC0364##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":54,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b2d9b9ab-5200-4581-89bb-e791ed783ec0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"daf49512-42ef-4d55-ba2f-569e72d7c2c6\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f8b8e17-08c4-4f51-8a57-60d2cb19d04c/base64\",\"ImageDescription\":\"_DSC0365##LW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":55,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2f8b8e17-08c4-4f51-8a57-60d2cb19d04c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f01994a7-3068-4b10-9173-4b58f70dd2c8\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/16f6875f-5c27-4b4c-a581-5f02db320531/base64\",\"ImageDescription\":\"_DSC0366##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":56,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/16f6875f-5c27-4b4c-a581-5f02db320531/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"3ceba271-0356-40bb-9a81-6fc26d5ab2af\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f25a0f0b-c96d-4f66-b5ae-c7b83c216768/base64\",\"ImageDescription\":\"_DSC0367##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":57,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f25a0f0b-c96d-4f66-b5ae-c7b83c216768/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"755417f0-fa1d-473b-9dda-8ff829adc524\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/655a4899-3a8c-46ed-9a09-a220cad46300/base64\",\"ImageDescription\":\"_DSC0368##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":58,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/655a4899-3a8c-46ed-9a09-a220cad46300/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e7af06f0-9158-4553-baf4-5f8ab25e9415\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/51d8217a-775e-4a0e-bace-61e12215b4b0/base64\",\"ImageDescription\":\"_DSC0369##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":59,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/51d8217a-775e-4a0e-bace-61e12215b4b0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ebae8dce-1929-4731-b022-7e1b1760a122\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/577a3bb4-e592-4886-9257-932035b3f7b8/base64\",\"ImageDescription\":\"_DSC0370##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":60,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/577a3bb4-e592-4886-9257-932035b3f7b8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"cb463ca9-ef57-40f4-af2a-133f921fd11e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/57711168-1f28-415b-ab59-a4322ded26fe/base64\",\"ImageDescription\":\"_DSC0371##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":61,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/57711168-1f28-415b-ab59-a4322ded26fe/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2bda9639-3352-445a-9cfe-1f6e9798fe90\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e98c32d6-1cae-416a-acc8-796e18c1b784/base64\",\"ImageDescription\":\"_DSC0373##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":62,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e98c32d6-1cae-416a-acc8-796e18c1b784/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8dd3ba99-3ee5-40ed-96a7-91d682623661\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4d0e5d33-0e2f-4539-ac61-2d12c6ec6628/base64\",\"ImageDescription\":\"_DSC0375##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":63,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4d0e5d33-0e2f-4539-ac61-2d12c6ec6628/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"738b0509-1ca1-4d6f-a1be-736f2078a4f9\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ade3cffb-3883-4c80-8160-8732a9dd3cc3/base64\",\"ImageDescription\":\"_DSC0377##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":64,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ade3cffb-3883-4c80-8160-8732a9dd3cc3/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"903df8ef-b651-4e81-b449-b70ad7e42848\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4393323d-d654-40db-b880-25f16512ae69/base64\",\"ImageDescription\":\"_DSC0379##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":65,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4393323d-d654-40db-b880-25f16512ae69/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6333a58a-5b9b-4dcd-947e-0c005d219856\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e6ad3665-6ad1-4fba-b7e8-4b4be18acb3c/base64\",\"ImageDescription\":\"_DSC0380##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":66,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e6ad3665-6ad1-4fba-b7e8-4b4be18acb3c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"cb8d7ad6-5117-4973-94c2-c63c2c6fa47e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/89a2ef1e-44f4-4641-b3fa-0fd45fda36ff/base64\",\"ImageDescription\":\"_DSC0381##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":67,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/89a2ef1e-44f4-4641-b3fa-0fd45fda36ff/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d6d6f820-5471-45d2-869e-fe7e8a123385\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ed68d162-1f78-43d7-b941-d19e399bfb13/base64\",\"ImageDescription\":\"_DSC0382##LW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":68,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ed68d162-1f78-43d7-b941-d19e399bfb13/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"abd923c9-2030-4e00-b81b-963b4289e41c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/58b7cc8c-7cce-4849-91d9-840ddf8b4db4/base64\",\"ImageDescription\":\"_DSC0384##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":69,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/58b7cc8c-7cce-4849-91d9-840ddf8b4db4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7d9ec75c-573b-49e9-80f1-6e6099a8c978\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a841c47f-0e07-4dec-8865-e6233c019605/base64\",\"ImageDescription\":\"_DSC0385##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":70,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a841c47f-0e07-4dec-8865-e6233c019605/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6cfeab55-dcfd-416a-98d4-a22ad5746fdb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0d4699ef-de3d-4dc7-8779-067d5d080ce1/base64\",\"ImageDescription\":\"_DSC0389##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":71,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0d4699ef-de3d-4dc7-8779-067d5d080ce1/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"724ffcba-715a-4a5d-bfa6-af9c7d88686f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/782dd0dd-9b61-4ee9-ae6c-c94b5125ffd4/base64\",\"ImageDescription\":\"_DSC0392##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":72,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/782dd0dd-9b61-4ee9-ae6c-c94b5125ffd4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b46329a9-ae8b-4adf-bc4e-b92a89800485\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c7d0da05-e936-485d-834e-37464b4e0c24/base64\",\"ImageDescription\":\"_DSC0394##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":73,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c7d0da05-e936-485d-834e-37464b4e0c24/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"444cccc3-1f95-41d3-b84f-25dc5d3742ce\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9d671ca4-0c2f-41b2-9582-1d3c23473ca5/base64\",\"ImageDescription\":\"_DSC0395##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":74,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9d671ca4-0c2f-41b2-9582-1d3c23473ca5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9f8d2b8e-e80d-42ec-95bb-50d4d9ff9f28\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/75336a55-bc8b-400d-9186-bf3833910c6b/base64\",\"ImageDescription\":\"_DSC0396##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":75,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/75336a55-bc8b-400d-9186-bf3833910c6b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fd2903fa-b53d-4549-9c2c-60f041645d0d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/64d83228-88c3-487b-b5ca-0bd874bb6c45/base64\",\"ImageDescription\":\"_DSC0412##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":76,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/64d83228-88c3-487b-b5ca-0bd874bb6c45/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"691a49f1-f63f-4c21-b474-d1416c7bdcba\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fa18346b-9106-4cd9-8638-645453c8ac32/base64\",\"ImageDescription\":\"_DSC0413##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":77,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fa18346b-9106-4cd9-8638-645453c8ac32/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"088b9d99-639c-4be7-9e8b-cf05116b4730\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f175293c-1824-44d8-9b9a-98694dfb2dfb/base64\",\"ImageDescription\":\"_DSC0414##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":78,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f175293c-1824-44d8-9b9a-98694dfb2dfb/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"787ad8d6-b1bb-4c57-8c04-e440a2e0994f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ea1d6a1d-348d-4dcc-93cf-e5e88d9a7fcc/base64\",\"ImageDescription\":\"_DSC0416##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":79,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ea1d6a1d-348d-4dcc-93cf-e5e88d9a7fcc/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e3b20a40-7520-4a19-92cf-dcf7cc687122\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fbfb046f-c643-497f-874c-14e8b0aef203/base64\",\"ImageDescription\":\"_DSC0417##LE Tip - no damage\",\"ImageId\":0,\"ImageOrder\":80,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fbfb046f-c643-497f-874c-14e8b0aef203/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fef45d9c-bb06-40aa-90a8-28b14b344611\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6bb107c0-083a-4e9a-ba55-61ca01adb01e/base64\",\"ImageDescription\":\"_DSC0418##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":81,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6bb107c0-083a-4e9a-ba55-61ca01adb01e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"36620ebc-6915-469f-9cf0-74d1dc8c0128\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce3aac72-28b5-4cb6-b937-0dcdf7dc2dd8/base64\",\"ImageDescription\":\"_DSC0419##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":82,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ce3aac72-28b5-4cb6-b937-0dcdf7dc2dd8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f5386dc7-f0b1-4962-aae0-047fdfa1e791\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/43a8acca-3560-4ecb-a245-649b1bdc5d17/base64\",\"ImageDescription\":\"_DSC0420##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":83,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/43a8acca-3560-4ecb-a245-649b1bdc5d17/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"66b032fe-a2cb-4b86-8bc3-243b4693096d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/44f888b2-1a7c-4fa5-8f32-894d6a4c495c/base64\",\"ImageDescription\":\"_DSC0421##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":84,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/44f888b2-1a7c-4fa5-8f32-894d6a4c495c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"be20fac8-d5aa-4273-8ead-6b8c6c9dcff4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c9e99ac6-2538-4c51-bd75-f7b0ab9db2a5/base64\",\"ImageDescription\":\"_DSC0422##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":85,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c9e99ac6-2538-4c51-bd75-f7b0ab9db2a5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b35e4d60-a046-4af5-b91f-ffc07ad76f81\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7d22c79e-a1c0-4c5c-bc10-5a6562d2a562/base64\",\"ImageDescription\":\"_DSC0423##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":86,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7d22c79e-a1c0-4c5c-bc10-5a6562d2a562/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2ed75d0b-da17-43a3-a9cc-c1fdf2e65eeb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5bfc2b84-59ad-4c4a-ac6b-1b315959c6f4/base64\",\"ImageDescription\":\"_DSC0424##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":87,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5bfc2b84-59ad-4c4a-ac6b-1b315959c6f4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"fc9c7a15-92f0-4413-9b42-a1b4e8c9622c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/cc0183ac-6608-4b49-bb09-5d989cada77d/base64\",\"ImageDescription\":\"_DSC0425##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":88,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/cc0183ac-6608-4b49-bb09-5d989cada77d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2a327da5-bdd6-4211-859d-9c50408c7268\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf7bfe58-d0de-4d31-8584-0d93dcc15e1b/base64\",\"ImageDescription\":\"_DSC0426##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":89,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bf7bfe58-d0de-4d31-8584-0d93dcc15e1b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"946635e2-f3ef-4247-8859-9e4e8a5900e6\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/aad78302-2807-4ec9-8b22-199934473816/base64\",\"ImageDescription\":\"_DSC0427##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":90,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/aad78302-2807-4ec9-8b22-199934473816/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"130044ba-724e-4ecc-b07d-76df6f4fc616\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/9dfa87cd-f67c-4fc5-b769-95bc961c9145/base64\",\"ImageDescription\":\"_DSC0428##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":91,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/9dfa87cd-f67c-4fc5-b769-95bc961c9145/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c3be1883-2d53-4415-9f32-4cedac039604\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0573c0e0-c123-4b70-8ec7-4263fa7c8a18/base64\",\"ImageDescription\":\"_DSC0429##LE Mid - no damage\",\"ImageId\":0,\"ImageOrder\":92,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0573c0e0-c123-4b70-8ec7-4263fa7c8a18/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7ddff87a-e4d1-4b01-b049-4239a5bddfcb\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fee052d0-194d-432b-8c7e-ffb656791841/base64\",\"ImageDescription\":\"_DSC0430##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":93,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fee052d0-194d-432b-8c7e-ffb656791841/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b968dea9-1409-4ce4-9f17-715c0ce73ec4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/7f713708-b0a2-4361-9e7c-a39a096865d1/base64\",\"ImageDescription\":\"_DSC0431##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":94,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/7f713708-b0a2-4361-9e7c-a39a096865d1/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e31c42e5-d05f-47b2-8587-339ccc98b02f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2261d33a-ee59-4cb8-b7fb-346f536fb19a/base64\",\"ImageDescription\":\"_DSC0432##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":95,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2261d33a-ee59-4cb8-b7fb-346f536fb19a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"08c7775a-4ee6-4c12-a0f9-0e5642d1d434\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/5043ee33-af4b-4a7a-afd8-50754fac9ef8/base64\",\"ImageDescription\":\"_DSC0433##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":96,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/5043ee33-af4b-4a7a-afd8-50754fac9ef8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d1a2b65b-bcf7-4ddc-bb97-97e3054fb48e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8e14265e-5fdc-4fa7-a10f-0e0a0bd1ae3e/base64\",\"ImageDescription\":\"_DSC0434##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":97,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8e14265e-5fdc-4fa7-a10f-0e0a0bd1ae3e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8442ed3f-019a-40ad-be73-bd87ba37ffb3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/debf16ef-5819-4ddd-9b28-c6da72e5074c/base64\",\"ImageDescription\":\"_DSC0435##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":98,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/debf16ef-5819-4ddd-9b28-c6da72e5074c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"704ebf43-04ff-41de-9bf6-01d1e3f0bad2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/934cdad5-a4e2-4a60-9650-9170841319e8/base64\",\"ImageDescription\":\"_DSC0436##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":99,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/934cdad5-a4e2-4a60-9650-9170841319e8/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e4e2e84d-433d-4dcc-8bff-be4edb78d87e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/967743c5-efe3-43cf-ba5c-92b9c3f4e58d/base64\",\"ImageDescription\":\"_DSC0437##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":100,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/967743c5-efe3-43cf-ba5c-92b9c3f4e58d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2ba58a31-ee9e-4e90-9b8d-35497ecc5d75\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/2d51278c-8ace-4552-8fe1-bb6c28bffda5/base64\",\"ImageDescription\":\"_DSC0438##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":101,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/2d51278c-8ace-4552-8fe1-bb6c28bffda5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e874e935-de69-4ec8-8d73-a9d80e9ef045\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f8734be-ba2a-4eef-ae7d-8a6bea4b998f/base64\",\"ImageDescription\":\"_DSC0439##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":102,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f8734be-ba2a-4eef-ae7d-8a6bea4b998f/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5da39703-a5e5-4a9b-bb5d-ca5c51a57fca\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f82bf5b-865e-40cc-9fe8-190bc01e06e4/base64\",\"ImageDescription\":\"_DSC0440##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":103,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f82bf5b-865e-40cc-9fe8-190bc01e06e4/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0ddf422b-e30b-478c-8bbe-c0d0b1db136a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/045dac30-b416-4592-8f9d-127ff10f0a04/base64\",\"ImageDescription\":\"_DSC0442##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":104,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/045dac30-b416-4592-8f9d-127ff10f0a04/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4db48057-5958-4e35-a8cc-b0ce0786e019\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f4e7243-4e70-4590-9638-db736d517f8f/base64\",\"ImageDescription\":\"_DSC0443##LE Root - no damage\",\"ImageId\":0,\"ImageOrder\":105,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/8f4e7243-4e70-4590-9638-db736d517f8f/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ddc5da74-a839-49ae-b344-6120cd52a841\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b172e18b-01b5-40d2-a55d-c0fc995b78f0/base64\",\"ImageDescription\":\"_DSC0454##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":106,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b172e18b-01b5-40d2-a55d-c0fc995b78f0/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2f298c96-d7b7-4f2b-9f81-ff879f1b81f5\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/094bc4be-ff8a-43aa-a6a2-3b447e15afdb/base64\",\"ImageDescription\":\"_DSC0455##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":107,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/094bc4be-ff8a-43aa-a6a2-3b447e15afdb/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ffe22a2b-1bd6-47d4-8739-951d53e091af\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/ae984855-8e79-49d2-8c49-4fad279de729/base64\",\"ImageDescription\":\"_DSC0457##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":108,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/ae984855-8e79-49d2-8c49-4fad279de729/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7cd883d1-e624-4ae9-96bd-c6f9e10ff0f3\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/07bdb984-7020-40a9-ab4f-053b5cd35f9b/base64\",\"ImageDescription\":\"_DSC0458##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":109,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/07bdb984-7020-40a9-ab4f-053b5cd35f9b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"54d0a9d8-5a2e-4252-906e-c80f565502b4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a8f1f536-750a-4d69-9d8d-bc98a78ab6ff/base64\",\"ImageDescription\":\"_DSC0459##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":110,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a8f1f536-750a-4d69-9d8d-bc98a78ab6ff/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d305bbcf-3c03-4d91-9659-e5a3cd25509f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e4bafef3-a922-4972-8feb-261cefde1c64/base64\",\"ImageDescription\":\"_DSC0461##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":111,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e4bafef3-a922-4972-8feb-261cefde1c64/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"370079eb-a0b5-4bff-b87f-849416d3b671\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/dcf09130-8a23-42bd-ac63-ec2f6f49d1e2/base64\",\"ImageDescription\":\"_DSC0464##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":112,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/dcf09130-8a23-42bd-ac63-ec2f6f49d1e2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9bf94bc9-dc33-4390-879e-6587bd0362b2\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/70822794-ec7c-446b-be2b-9d9811b73f94/base64\",\"ImageDescription\":\"_DSC0466##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":113,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/70822794-ec7c-446b-be2b-9d9811b73f94/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"321a02bd-923a-4bb9-9bbe-c5f28e0e5ec0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/08b9ed0c-a5d8-474a-9517-918def97f7f6/base64\",\"ImageDescription\":\"_DSC0467##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":114,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/08b9ed0c-a5d8-474a-9517-918def97f7f6/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0002784a-b727-4472-8360-c1b175969e14\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/fe3849d2-78ec-445c-8e04-aa6e8274b32e/base64\",\"ImageDescription\":\"_DSC0468##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":115,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/fe3849d2-78ec-445c-8e04-aa6e8274b32e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c5c59435-20cd-4b6d-9298-5e9c1ab3e8b6\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1e981114-f69c-4dfe-96a8-161d356fb13d/base64\",\"ImageDescription\":\"_DSC0469##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":116,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1e981114-f69c-4dfe-96a8-161d356fb13d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f1d148e8-4d7c-439c-befa-ccf56cafefb6\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6b100cf7-9484-4298-be9b-fd05aa7edeb2/base64\",\"ImageDescription\":\"_DSC0470##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":117,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6b100cf7-9484-4298-be9b-fd05aa7edeb2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c095aeea-1670-42a5-ba11-b2752735a17d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/cbe4eba3-02bd-4544-b468-fab02f7b0e5a/base64\",\"ImageDescription\":\"_DSC0471##WW Root - no damage\",\"ImageId\":0,\"ImageOrder\":118,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/cbe4eba3-02bd-4544-b468-fab02f7b0e5a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"16b497bf-f25e-4b3e-9fbf-a69506d9cee1\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/74fd9423-66fb-4190-9ebe-29e6c4dee82b/base64\",\"ImageDescription\":\"_DSC0472##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":119,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/74fd9423-66fb-4190-9ebe-29e6c4dee82b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"4b2c42f6-637a-4ad9-8d59-e222c87dd633\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a36bac89-5a6b-4be2-8082-383b1e7e68e2/base64\",\"ImageDescription\":\"_DSC0474##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":120,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a36bac89-5a6b-4be2-8082-383b1e7e68e2/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8b17a5e8-ffb8-4c82-a9e3-df0876f69f90\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c06d8237-8602-44a4-8c1b-d303f6bdfc95/base64\",\"ImageDescription\":\"_DSC0475##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":121,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c06d8237-8602-44a4-8c1b-d303f6bdfc95/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b2fdc37a-5677-4852-a7fe-9c1c05d8dbd0\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/c8716bdf-9df9-4c84-b5fe-9a6f9aa463fa/base64\",\"ImageDescription\":\"_DSC0476##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":122,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/c8716bdf-9df9-4c84-b5fe-9a6f9aa463fa/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d22b67ab-689a-45f3-ac42-4a4c016e0977\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/bcac1188-c899-4197-88ab-0164ae0362db/base64\",\"ImageDescription\":\"_DSC0477##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":123,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/bcac1188-c899-4197-88ab-0164ae0362db/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"dd7a0ffa-c6b7-4e1d-aa76-d80ac7af00c4\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/670825e5-cf83-4662-b706-2a72b3875c11/base64\",\"ImageDescription\":\"_DSC0478##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":124,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/670825e5-cf83-4662-b706-2a72b3875c11/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"ddd77140-4edd-4289-a2b4-904d3f651234\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/1e16c33f-c5e1-456f-b2d0-c99fe6c44144/base64\",\"ImageDescription\":\"_DSC0479##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":125,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/1e16c33f-c5e1-456f-b2d0-c99fe6c44144/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5bf57bb8-63cf-4c4f-9866-b0973e088288\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/a88e8b4e-e9b8-4ef7-95ee-b9c04e3b6400/base64\",\"ImageDescription\":\"_DSC0480##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":126,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/a88e8b4e-e9b8-4ef7-95ee-b9c04e3b6400/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"5cfae7e9-bd47-40e1-96cd-19ea2696c51d\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/dcfb18ed-74ec-4171-be8e-7e7f7370ccd9/base64\",\"ImageDescription\":\"_DSC0481##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":127,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/dcfb18ed-74ec-4171-be8e-7e7f7370ccd9/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6a08a945-756e-441e-bd30-fd30d0c059dd\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f10c7571-df56-4b47-b6fc-f62c394a9161/base64\",\"ImageDescription\":\"_DSC0482##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":128,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f10c7571-df56-4b47-b6fc-f62c394a9161/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b43e4d35-2875-472d-9727-f758edfe63a7\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/21fdef46-d4a3-46df-9b81-a3b5e0ca758e/base64\",\"ImageDescription\":\"_DSC0483##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":129,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/21fdef46-d4a3-46df-9b81-a3b5e0ca758e/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"50f80533-5b17-4caa-a385-a9f1affadf9e\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/156e3c8b-4f35-4fe7-98c3-668733a39b8c/base64\",\"ImageDescription\":\"_DSC0484##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":130,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/156e3c8b-4f35-4fe7-98c3-668733a39b8c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"30b5b1d6-8e8d-4466-b2ae-ea3c74b50a42\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/af6bdb2d-c3de-40b5-afd2-f8f8c8d0db0b/base64\",\"ImageDescription\":\"_DSC0485##WW Mid - no damage\",\"ImageId\":0,\"ImageOrder\":131,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/af6bdb2d-c3de-40b5-afd2-f8f8c8d0db0b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d56140a6-cc96-4384-b734-d144c5167f4b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/603ee780-84cf-4e07-bb3d-63523cb3a04b/base64\",\"ImageDescription\":\"_DSC0486##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":132,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/603ee780-84cf-4e07-bb3d-63523cb3a04b/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"9c66dd08-6cf5-463b-9aed-436afada5b38\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/68a82036-0a09-474a-a37f-44e02c842757/base64\",\"ImageDescription\":\"_DSC0487##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":133,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/68a82036-0a09-474a-a37f-44e02c842757/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"706dad0b-8784-431f-a901-5564566d3d96\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/d25d9052-3e08-4431-8fa1-3afcdeb1ed60/base64\",\"ImageDescription\":\"_DSC0488##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":134,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/d25d9052-3e08-4431-8fa1-3afcdeb1ed60/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d603fdcb-6c0a-4757-9c13-cce3e3d5494b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/e0afd4aa-f4b3-4036-90d7-3ba2dbf9cfad/base64\",\"ImageDescription\":\"_DSC0489##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":135,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/e0afd4aa-f4b3-4036-90d7-3ba2dbf9cfad/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"29e4cb32-a385-4397-a7f2-c47e6f89810c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/78500cd1-1495-41c1-8f70-a34deef5cd07/base64\",\"ImageDescription\":\"_DSC0490##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":136,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/78500cd1-1495-41c1-8f70-a34deef5cd07/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"59198e79-4284-4680-9400-f7372039bd35\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6b206130-26e6-49e0-90ab-c49bdb951a22/base64\",\"ImageDescription\":\"_DSC0491##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":137,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6b206130-26e6-49e0-90ab-c49bdb951a22/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"04e8fca5-8ed7-476f-8504-57ca58740368\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/f030399e-1d66-4719-8a6f-2090f97a8f2a/base64\",\"ImageDescription\":\"_DSC0492##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":138,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/f030399e-1d66-4719-8a6f-2090f97a8f2a/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"c86f5308-2f34-4747-9379-23ff76b54b9c\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/b1de7929-6e57-463a-acbf-dd1d1e5c567d/base64\",\"ImageDescription\":\"_DSC0493##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":139,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/b1de7929-6e57-463a-acbf-dd1d1e5c567d/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"176a8d11-aebe-43cf-b3bb-90ce6961620b\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/cd1e8931-6838-4824-ad5f-671f041574b5/base64\",\"ImageDescription\":\"_DSC0494##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":140,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/cd1e8931-6838-4824-ad5f-671f041574b5/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"b9e61c35-91c8-4379-ae5c-1eeb8da7d758\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/21ab4433-ce7c-472f-85fc-5fc2ca3e00b7/base64\",\"ImageDescription\":\"_DSC0496##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":141,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/21ab4433-ce7c-472f-85fc-5fc2ca3e00b7/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"87493119-6d63-4282-8f44-a2326a7b215f\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/6df73dbe-8dcd-425e-80f5-8cc879295f7f/base64\",\"ImageDescription\":\"_DSC0497##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":142,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/6df73dbe-8dcd-425e-80f5-8cc879295f7f/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"f07fc6ae-c7e1-44f9-a59b-ec5aa964d37a\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/0104644d-d534-41f2-a8cf-1ef8d1061bfc/base64\",\"ImageDescription\":\"_DSC0499##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":143,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/0104644d-d534-41f2-a8cf-1ef8d1061bfc/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"75b7972c-c370-4678-b0b6-d2be742f5678\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/00563935-566c-4251-8dd5-f28c61f4eb4c/base64\",\"ImageDescription\":\"_DSC0502##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":144,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/00563935-566c-4251-8dd5-f28c61f4eb4c/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"2d71615c-c680-47b6-b66d-2cb54434f8ba\",\"ImageDataString\":\"https://servicesdev.vestas.inspectools.net/multimedia/4dc4a665-b8ef-426d-95c4-5a35f5ac4e83/base64\",\"ImageDescription\":\"_DSC0503##WW Tip - no damage\",\"ImageId\":0,\"ImageOrder\":145,\"ImageUrl\":\"https://servicesdev.vestas.inspectools.net/multimedia/4dc4a665-b8ef-426d-95c4-5a35f5ac4e83/base64\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false}],\"ImageDataInfo\":{\"IsPlateTypeNotPossible\":true,\"PlateTypeNotPossibleReason\":\"\"},\"InspectionDate\":\"2018-06-22T00:00:00\",\"InstallationDate\":null,\"InternalComments\":\"\",\"LocalTurbineId\":\"\",\"LocationTypeId\":6,\"MainBearing\":null,\"Modified\":\"0001-01-01T00:00:00\",\"MountedOnMainComponentBooleanAnswerId\":1,\"NotificationNumber\":\"\",\"OutSideSign\":false,\"Quantity\":0,\"ReasonForService\":\"\",\"ReconstructionBooleanAnswerId\":1,\"ReportTypeId\":1,\"RunHours\":100000,\"SBUId\":1,\"SBUName\":\"\",\"SBURecomendation\":\"\",\"SecondGeneratorBooleanAnswerId\":null,\"ServiceEngineer\":\"vestas\",\"ServiceReportNumber\":\"PC20180903B\",\"ServiceReportNumberTypeId\":3,\"SiteName\":\"\",\"Skiip\":null,\"TemplateVersion\":\"9\",\"TotalAcceptedRecords\":0,\"TotalProduction\":5000000,\"TotalRecords\":0,\"TotalRejectedRecords\":0,\"TotalUnApprovedRecords\":0,\"Transformer\":null,\"TurbineData\":{\"Country\":\"\",\"CountryIsoId\":0,\"Frequency\":0,\"LocalTurbineId\":\"\",\"Manufacturer\":\"\",\"MarkVersion\":\"\",\"NominelPower\":0,\"NominelPowerId\":0,\"Placement\":\"\",\"PowerRegulation\":\"\",\"RotorDiameter\":0.0,\"Site\":\"\",\"SmallGenerator\":0,\"TemperatureVariant\":\"\",\"Turbine\":\"\",\"TurbineMatrixId\":0,\"Voltage\":0},\"TurbineMatrixId\":null,\"TurbineNumber\":13456,\"TurbineType\":\"\",\"VestasItemNumber\":\"23456\",\"isSimplifiedCir\":false,\"strCommisioningDate\":\"\",\"strFailureDate\":\"2018/01/20T00:00:00\",\"strInspectionDate\":\"2018/06/22T00:00:00\",\"strInstallationDate\":\"\"}";
            // string tmp= "{\"additionalComments\":\"\",\"afterInspectionTurbineRunStatusId\":1,\"alarmLogNumber\":\"0\",\"beforeInspectionTurbineRunStatusId\":3,\"bladeData\":{\"bladeClaimRelevantBooleanAnswerId\":null,\"bladeColorId\":0,\"bladeDamageIdentified\":false,\"bladeFaultCodeAreaId\":null,\"bladeFaultCodeCauseId\":null,\"bladeFaultCodeClassificationId\":null,\"bladeFaultCodeTypeId\":null,\"bladeInspectionReportDescription\":null,\"bladeLengthId\":0,\"bladeLsCalibrationDate\":\"0001-01-01T00:00:00\",\"bladeLsLeewardSidePostRepair2\":null,\"bladeLsLeewardSidePostRepair3\":null,\"bladeLsLeewardSidePostRepair4\":null,\"bladeLsLeewardSidePostRepair5\":null,\"bladeLsLeewardSidePostRepair6\":null,\"bladeLsLeewardSidePostRepair7\":null,\"bladeLsLeewardSidePostRepair8\":null,\"bladeLsLeewardSidePostRepairTip\":null,\"bladeLsLeewardSidePreRepair2\":null,\"bladeLsLeewardSidePreRepair3\":null,\"bladeLsLeewardSidePreRepair4\":null,\"bladeLsLeewardSidePreRepair5\":null,\"bladeLsLeewardSidePreRepair6\":null,\"bladeLsLeewardSidePreRepair7\":null,\"bladeLsLeewardSidePreRepair8\":null,\"bladeLsLeewardSidePreRepairTip\":null,\"bladeLsVtNumber\":null,\"bladeLsWindwardSidePostRepair2\":null,\"bladeLsWindwardSidePostRepair3\":null,\"bladeLsWindwardSidePostRepair4\":null,\"bladeLsWindwardSidePostRepair5\":null,\"bladeLsWindwardSidePostRepair6\":null,\"bladeLsWindwardSidePostRepair7\":null,\"bladeLsWindwardSidePostRepair8\":null,\"bladeLsWindwardSidePostRepairTip\":null,\"bladeLsWindwardSidePreRepair2\":null,\"bladeLsWindwardSidePreRepair3\":null,\"bladeLsWindwardSidePreRepair4\":null,\"bladeLsWindwardSidePreRepair5\":null,\"bladeLsWindwardSidePreRepair6\":null,\"bladeLsWindwardSidePreRepair7\":null,\"bladeLsWindwardSidePreRepair8\":null,\"bladeLsWindwardSidePreRepairTip\":null,\"bladeManufacturerId\":null,\"bladeOtherSerialNumber1\":null,\"bladeOtherSerialNumber2\":null,\"bladePicturesIncludedBooleanAnswerId\":0,\"bladeSerialNumber\":null,\"componentInspectionReportBladeId\":0,\"componentInspectionReportId\":0,\"damageData\":null,\"repairRecordData\":null,\"vestasUniqueIdentifier\":null,\"strBladeLsCalibrationDate\":null},\"brand\":null,\"cimCaseNumber\":-1,\"cirid\":0,\"cirTemplateGUID\":\"\",\"cirDataID\":0,\"cirName\":null,\"commisioningDate\":\"2018-08-01T00:00:00\",\"componentInspectionReportId\":0,\"componentInspectionReportName\":\"{SiteName}_Generator_1534_2018-07-03_-1\",\"componentInspectionReportStateId\":1,\"componentInspectionReportTypeId\":4,\"componentInspectionReportVersion\":null,\"componentUpTowerSolutionID\":null,\"conductedBy\":\"1\",\"country\":\"\",\"countryISOId\":0,\"created\":\"0001-01-01T00:00:00\",\"currentUser\":\"dhksi\",\"deleted\":\"0001-01-01T00:00:00\",\"deletedBy\":null,\"description\":\"SSDFSD\",\"descriptionConsquential\":\"\",\"dyanamicDecisionData\":null,\"dynamicTableInputs\":{\"cirId\":\"0\",\"id\":0,\"row10Col1\":\"\",\"row10Col2\":\"\",\"row10Col3\":\"\",\"row10Col4\":\"\",\"row10Col5\":\"\",\"row10Col6\":null,\"row11Col1\":null,\"row11Col2\":null,\"row11Col3\":null,\"row11Col4\":null,\"row11Col5\":null,\"row11Col6\":null,\"row12Col1\":null,\"row12Col2\":null,\"row12Col3\":null,\"row12Col4\":null,\"row12Col5\":null,\"row12Col6\":null,\"row13Col1\":null,\"row13Col2\":null,\"row13Col3\":null,\"row13Col4\":null,\"row13Col5\":null,\"row13Col6\":null,\"row14Col1\":null,\"row14Col2\":null,\"row14Col3\":null,\"row14Col4\":null,\"row14Col5\":null,\"row14Col6\":null,\"row1Col1\":\"\",\"row1Col2\":\"\",\"row1Col3\":\"\",\"row1Col4\":\"\",\"row1Col5\":\"\",\"row1Col6\":\"\",\"row2Col1\":\"\",\"row2Col2\":\"\",\"row2Col3\":\"\",\"row2Col4\":\"\",\"row2Col5\":\"\",\"row2Col6\":\"\",\"row3Col1\":\"\",\"row3Col2\":\"\",\"row3Col3\":\"\",\"row3Col4\":\"\",\"row3Col5\":\"\",\"row3Col6\":\"\",\"row4Col1\":\"\",\"row4Col2\":\"\",\"row4Col3\":\"\",\"row4Col4\":\"\",\"row4Col5\":\"\",\"row4Col6\":\"\",\"row5Col1\":\"\",\"row5Col2\":\"\",\"row5Col3\":\"\",\"row5Col4\":\"\",\"row5Col5\":\"\",\"row5Col6\":\"\",\"row6Col1\":\"\",\"row6Col2\":\"\",\"row6Col3\":\"\",\"row6Col4\":\"\",\"row6Col5\":\"\",\"row6Col6\":\"\",\"row7Col1\":\"\",\"row7Col2\":\"\",\"row7Col3\":\"\",\"row7Col4\":\"\",\"row7Col5\":\"\",\"row7Col6\":\"\",\"row8Col1\":\"\",\"row8Col2\":\"\",\"row8Col3\":\"\",\"row8Col4\":\"\",\"row8Col5\":\"\",\"row8Col6\":\"\",\"row9Col1\":\"\",\"row9Col2\":\"\",\"row9Col3\":\"\",\"row9Col4\":\"\",\"row9Col5\":\"\",\"row9Col6\":\"\"},\"errorMessage\":null,\"failureDate\":\"2018-08-01T00:00:00\",\"flangDesc\":null,\"formIOGUID\":null,\"gearbox\":{\"componentInspectionReportGearboxId\":0,\"componentInspectionReportId\":0,\"gearboxActionToBeTakenOnGearboxId\":null,\"gearboxAirBreather\":false,\"gearboxAuxEquipmentId\":null,\"gearboxAuxStageHousingErrorId\":null,\"gearboxBearingDecision1DamageDecisionId\":null,\"gearboxBearingDecision2DamageDecisionId\":null,\"gearboxBearingDecision3DamageDecisionId\":null,\"gearboxBearingDecision4DamageDecisionId\":null,\"gearboxBearingDecision5DamageDecisionId\":null,\"gearboxBearingDecision6DamageDecisionId\":null,\"gearboxBearingsDamage1BearingErrorId\":null,\"gearboxBearingsDamage2BearingErrorId\":null,\"gearboxBearingsDamage3BearingErrorId\":null,\"gearboxBearingsDamage4BearingErrorId\":null,\"gearboxBearingsDamage5BearingErrorId\":null,\"gearboxBearingsDamage6BearingErrorId\":null,\"gearboxBearingsLocation1BearingTypeId\":null,\"gearboxBearingsLocation2BearingTypeId\":null,\"gearboxBearingsLocation3BearingTypeId\":null,\"gearboxBearingsLocation4BearingTypeId\":null,\"gearboxBearingsLocation5BearingTypeId\":null,\"gearboxBearingsLocation6BearingTypeId\":null,\"gearboxBearingsPosition1BearingPosId\":null,\"gearboxBearingsPosition2BearingPosId\":null,\"gearboxBearingsPosition3BearingPosId\":null,\"gearboxBearingsPosition4BearingPosId\":null,\"gearboxBearingsPosition5BearingPosId\":null,\"gearboxBearingsPosition6BearingPosId\":null,\"gearboxBrokenBolts\":false,\"gearboxChipDetector\":false,\"gearboxClaimRelevantBooleanAnswerId\":null,\"gearboxCouplingId\":null,\"gearboxCrackedTorqueArm\":false,\"gearboxDebrisGearBoxId\":0,\"gearboxDebrisOnMagnetId\":0,\"gearboxDebrisStagesMagnetPosId\":0,\"gearboxDefectCategorizationScore\":null,\"gearboxDefectDamperElements\":false,\"gearboxDrainValve\":false,\"gearboxElectricalPumpId\":null,\"gearboxExactLocation10GearTypeId\":null,\"gearboxExactLocation11GearTypeId\":null,\"gearboxExactLocation12GearTypeId\":null,\"gearboxExactLocation13GearTypeId\":null,\"gearboxExactLocation14GearTypeId\":null,\"gearboxExactLocation15GearTypeId\":null,\"gearboxExactLocation1GearTypeId\":null,\"gearboxExactLocation2GearTypeId\":null,\"gearboxExactLocation3GearTypeId\":null,\"gearboxExactLocation4GearTypeId\":null,\"gearboxExactLocation5GearTypeId\":null,\"gearboxExactLocation6GearTypeId\":null,\"gearboxExactLocation7GearTypeId\":null,\"gearboxExactLocation8GearTypeId\":null,\"gearboxExactLocation9GearTypeId\":null,\"gearboxFilterBlockTypeId\":null,\"gearboxFilterIndicator\":false,\"gearboxFrontPlateHousingErrorId\":null,\"gearboxGearDamageClass10DamageId\":null,\"gearboxGearDamageClass11DamageId\":null,\"gearboxGearDamageClass12DamageId\":null,\"gearboxGearDamageClass13DamageId\":null,\"gearboxGearDamageClass14DamageId\":null,\"gearboxGearDamageClass15DamageId\":null,\"gearboxGearDamageClass1DamageId\":null,\"gearboxGearDamageClass2DamageId\":null,\"gearboxGearDamageClass3DamageId\":null,\"gearboxGearDamageClass4DamageId\":null,\"gearboxGearDamageClass5DamageId\":null,\"gearboxGearDamageClass6DamageId\":null,\"gearboxGearDamageClass7DamageId\":null,\"gearboxGearDamageClass8DamageId\":null,\"gearboxGearDamageClass9DamageId\":null,\"gearboxGearDecision10DamageDecisionId\":null,\"gearboxGearDecision11DamageDecisionId\":null,\"gearboxGearDecision12DamageDecisionId\":null,\"gearboxGearDecision13DamageDecisionId\":null,\"gearboxGearDecision14DamageDecisionId\":null,\"gearboxGearDecision15DamageDecisionId\":null,\"gearboxGearDecision1DamageDecisionId\":null,\"gearboxGearDecision2DamageDecisionId\":null,\"gearboxGearDecision3DamageDecisionId\":null,\"gearboxGearDecision4DamageDecisionId\":null,\"gearboxGearDecision5DamageDecisionId\":null,\"gearboxGearDecision6DamageDecisionId\":null,\"gearboxGearDecision7DamageDecisionId\":null,\"gearboxGearDecision8DamageDecisionId\":null,\"gearboxGearDecision9DamageDecisionId\":null,\"gearboxGeneratorManufacturerId\":null,\"gearboxGeneratorManufacturerId2\":null,\"gearboxHSSNRend\":false,\"gearboxHSSPTO\":false,\"gearboxHSSRend\":false,\"gearboxHSStageHousingErrorId\":null,\"gearboxHelicalStageHousingErrorId\":null,\"gearboxHoseAndPiping\":false,\"gearboxIMSNRend\":false,\"gearboxIMSRend\":false,\"gearboxImmersionHeater\":false,\"gearboxInLineFilterId\":null,\"gearboxInputShaft\":false,\"gearboxLSSNRend\":false,\"gearboxLastOilChangeDate\":\"0001-01-01T00:00:00\",\"gearboxLooseBolts\":false,\"gearboxManufacturerId\":0,\"gearboxMaxTempResetDate\":\"0001-01-01T00:00:00\",\"gearboxMechanicalOilPumpId\":0,\"gearboxNeedsToBeAligned\":false,\"gearboxNoiseId\":0,\"gearboxOffLineFilterId\":null,\"gearboxOilLevelId\":0,\"gearboxOilLevelSensor\":false,\"gearboxOilPressure\":false,\"gearboxOilTemperature\":0.0,\"gearboxOilTypeId\":0,\"gearboxOtherManufacturer\":null,\"gearboxOverallGearboxConditionId\":null,\"gearboxPT100Bearing1\":false,\"gearboxPT100Bearing2\":false,\"gearboxPT100Bearing3\":false,\"gearboxPT100OilSump\":false,\"gearboxPitchTube\":false,\"gearboxPlanetStage1HousingErrorId\":null,\"gearboxPlanetStage2HousingErrorId\":null,\"gearboxProduction\":null,\"gearboxRevisionId\":0,\"gearboxRunHours\":null,\"gearboxSerialNumber\":null,\"gearboxShaftsExactLocation1ShaftTypeId\":null,\"gearboxShaftsExactLocation2ShaftTypeId\":null,\"gearboxShaftsExactLocation3ShaftTypeId\":null,\"gearboxShaftsExactLocation4ShaftTypeId\":null,\"gearboxShaftsTypeofDamage1ShaftErrorId\":null,\"gearboxShaftsTypeofDamage2ShaftErrorId\":null,\"gearboxShaftsTypeofDamage3ShaftErrorId\":null,\"gearboxShaftsTypeofDamage4ShaftErrorId\":null,\"gearboxShrinkElementId\":null,\"gearboxShrinkElementSerialNumber\":null,\"gearboxSightGlass\":false,\"gearboxSoftwareRelease\":null,\"gearboxSplitLines\":false,\"gearboxTempBearing1\":null,\"gearboxTempBearing2\":null,\"gearboxTempBearing3\":null,\"gearboxTempOilSump\":null,\"gearboxTooMuchClearance\":false,\"gearboxTypeId\":0,\"gearboxTypeofDamage10GearErrorId\":null,\"gearboxTypeofDamage11GearErrorId\":null,\"gearboxTypeofDamage12GearErrorId\":null,\"gearboxTypeofDamage13GearErrorId\":null,\"gearboxTypeofDamage14GearErrorId\":null,\"gearboxTypeofDamage15GearErrorId\":null,\"gearboxTypeofDamage1GearErrorId\":null,\"gearboxTypeofDamage2GearErrorId\":null,\"gearboxTypeofDamage3GearErrorId\":null,\"gearboxTypeofDamage4GearErrorId\":null,\"gearboxTypeofDamage5GearErrorId\":null,\"gearboxTypeofDamage6GearErrorId\":null,\"gearboxTypeofDamage7GearErrorId\":null,\"gearboxTypeofDamage8GearErrorId\":null,\"gearboxTypeofDamage9GearErrorId\":null,\"gearboxVibrationsId\":0,\"otherGearboxType\":null,\"vestasUniqueIdentifier\":null,\"strGearboxLastOilChangeDate\":null},\"general\":{\"componentInspectionReportGeneralId\":0,\"componentInspectionReportId\":0,\"generalBlade1SerialNumber\":null,\"generalBlade2SerialNumber\":null,\"generalBlade3SerialNumber\":null,\"generalClaimRelevantBooleanAnswerId\":null,\"generalComponentGroupId\":null,\"generalComponentManufacturer\":null,\"generalComponentSerialNumber\":null,\"generalComponentType\":null,\"generalControllerTypeId\":null,\"generalExecutedBy1\":null,\"generalExecutedBy2\":null,\"generalExecutedBy3\":null,\"generalExecutedBy4\":null,\"generalGearboxManufacturerId\":null,\"generalGeneratorManufacturerId\":null,\"generalInitiatedBy1\":null,\"generalInitiatedBy2\":null,\"generalInitiatedBy3\":null,\"generalInitiatedBy4\":null,\"generalMeasurementsConducted1\":null,\"generalMeasurementsConducted2\":null,\"generalMeasurementsConducted3\":null,\"generalMeasurementsConducted4\":null,\"generalOtherGearboxManufacturer\":null,\"generalOtherGearboxType\":null,\"generalPicturesIncludedBooleanAnswerId\":0,\"generalPositionOfFailedItem\":null,\"generalRamDumpNumber\":null,\"generalSoftwareRelease\":null,\"generalTowerHeightId\":null,\"generalTowerTypeId\":null,\"generalTransformerManufacturerId\":null,\"generalVDFTrackNumber\":null,\"vestasUniqueIdentifier\":null},\"generator\":{\"actionToBeTakenOnGeneratorId\":2,\"airToAirCoolerExternalId\":null,\"airToAirCoolerInternalId\":null,\"componentInspectionReportGeneratorId\":0,\"componentInspectionReportId\":0,\"couplingId\":15,\"generatorClaimRelevantBooleanAnswerId\":2,\"generatorComments\":\"\",\"generatorCoverId\":2,\"generatorDriveEndId\":1,\"generatorInsulationComments\":\"\",\"generatorManufacturerId\":47,\"generatorMaxTemperature\":10.0,\"generatorMaxTemperatureResetDate\":\"2018-08-01T00:00:00\",\"generatorNonDriveEndId\":2,\"generatorRewoundLocally\":false,\"generatorRotorId\":2,\"generatorSerialNumber\":\"564564\",\"insulationComments\":false,\"k1L1\":10,\"k1M1\":1,\"k2L2\":10,\"k2M2\":10,\"kGround\":0.0,\"kGroundOhmUnitId\":6,\"l1M1\":1,\"l2M2\":1,\"lGround\":0.0,\"lGroundOhmUnitId\":6,\"mGround\":0.0,\"mGroundOhmUnitId\":6,\"otherManufacturer\":\"\",\"u1U2\":10,\"uGround\":0.0,\"uGroundOhmUnitId\":6,\"uv\":0.0,\"uvOhmUnitId\":6,\"uw\":0.0,\"uwOhmUnitId\":6,\"v1V2\":10,\"vGround\":0.0,\"vGroundOhmUnitId\":6,\"vw\":0.0,\"vwOhmUnitId\":6,\"vestasUniqueIdentifier\":\"231321\",\"w1W2\":10,\"wGround\":0.0,\"wGroundOhmUnitId\":6,\"strGeneratorMaxTemperatureResetDate\":\"01-08-2018\"},\"generator1Hrs\":1,\"generator2Hrs\":1,\"hideLock\":null,\"hideProgress\":null,\"hideTemplateVer\":null,\"htmlStr\":\"\",\"imageData\":[{\"flangNo\":0,\"formIOImageGUID\":null,\"imageDataString\":\"data:image/jpeg;base64,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"
            #region [Commented old code]
            // for debug;

            //string tmp1 = "{\"AdditionalComments\":\"Note: Blade has been inspected before in December 2017 without any (internal) damages. Please refer to CIR ID 354032\",\"AfterInspectionTurbineRunStatusId\":7,\"AlarmLogNumber\":\"\",\"BeforeInspectionTurbineRunStatusId\":1,\"BladeData\":{\"BladeClaimRelevantBooleanAnswerId\":null,\"BladeColorId\":11,\"BladeDamageIdentified\":true,\"BladeFaultCodeAreaId\":10,\"BladeFaultCodeCauseId\":1,\"BladeFaultCodeClassificationId\":5,\"BladeFaultCodeTypeId\":11,\"BladeInspectionReportDescription\":\"\",\"BladeLengthId\":39,\"BladeLsCalibrationDate\":\"0001-01-01T00:00:00\",\"BladeLsLeewardSidePostRepair2\":null,\"BladeLsLeewardSidePostRepair3\":null,\"BladeLsLeewardSidePostRepair4\":null,\"BladeLsLeewardSidePostRepair5\":null,\"BladeLsLeewardSidePostRepair6\":null,\"BladeLsLeewardSidePostRepair7\":null,\"BladeLsLeewardSidePostRepair8\":null,\"BladeLsLeewardSidePostRepairTip\":null,\"BladeLsLeewardSidePreRepair2\":null,\"BladeLsLeewardSidePreRepair3\":null,\"BladeLsLeewardSidePreRepair4\":null,\"BladeLsLeewardSidePreRepair5\":null,\"BladeLsLeewardSidePreRepair6\":null,\"BladeLsLeewardSidePreRepair7\":null,\"BladeLsLeewardSidePreRepair8\":null,\"BladeLsLeewardSidePreRepairTip\":null,\"BladeLsVtNumber\":\"\",\"BladeLsWindwardSidePostRepair2\":null,\"BladeLsWindwardSidePostRepair3\":null,\"BladeLsWindwardSidePostRepair4\":null,\"BladeLsWindwardSidePostRepair5\":null,\"BladeLsWindwardSidePostRepair6\":null,\"BladeLsWindwardSidePostRepair7\":null,\"BladeLsWindwardSidePostRepair8\":null,\"BladeLsWindwardSidePostRepairTip\":null,\"BladeLsWindwardSidePreRepair2\":null,\"BladeLsWindwardSidePreRepair3\":null,\"BladeLsWindwardSidePreRepair4\":null,\"BladeLsWindwardSidePreRepair5\":null,\"BladeLsWindwardSidePreRepair6\":null,\"BladeLsWindwardSidePreRepair7\":null,\"BladeLsWindwardSidePreRepair8\":null,\"BladeLsWindwardSidePreRepairTip\":null,\"BladeManufacturerId\":2,\"BladeOtherSerialNumber1\":\"\",\"BladeOtherSerialNumber2\":\"\",\"BladePicturesIncludedBooleanAnswerId\":2,\"BladeSerialNumber\":\"186506\",\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportId\":0,\"DamageData\":[{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Delamination bigger than 200x200mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"7\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":5,\"FormIOImageGUID\":\"6567ec37-cb78-4b55-880a-7cfc78f993ac\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Distance to Web less than 250mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"12\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":5,\"FormIOImageGUID\":\"de4a078f-eae2-4fd9-90e8-50eccd92a54a\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Distance to Web more than 250mm\",\"BladeEdgeId\":3,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"10\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":5,\"FormIOImageGUID\":\"6711e4a3-b1a3-4309-82fe-a992eb90c728\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Carbon Cap/Pultrusion Damage\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"5\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":5,\"FormIOImageGUID\":\"6c8b0002-3ea5-458f-9790-2fdfec279042\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Carbon Cap/Pultrusion Damage\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"3\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":5,\"FormIOImageGUID\":\"724d3f79-8861-4f46-a76b-7d3115835b71\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Down conductor cable: evidence for an arc\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"1\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"13e08546-87ee-47cb-b8a9-40b83e18aac0\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Delamination bigger than 200x200mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"4\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"7a4bda0e-2ddf-4afb-b704-ff8ba5b2fa79\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Delamination bigger than 200x200mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"6\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"d417cdf7-d477-4196-9182-6eb31613b9b9\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Carbon Cap/Pultrusion Damage\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"9\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"e59d3844-c638-4879-bd2d-961f5e013bee\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":2,\"BladeDescription\":\"Distance to Web more than 250mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"14\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"a6f39d78-a021-4197-bb91-7a1c6ec5a15d\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Delamination bigger than 200x200mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"8\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":0,\"FormIOImageGUID\":\"0d61213b-3378-4939-8e25-01bed296e1b8\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Carbon Cap/Pultrusion Damage\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"11\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":-1,\"FormIOImageGUID\":\"8a1edd72-75a7-4a1e-bdaf-a134566f5d66\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Carbon Cap/Pultrusion Damage\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"13\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":-1,\"FormIOImageGUID\":\"333a8bcb-ffcd-46b6-a01b-88f85531f061\",\"PictureOrder\":null},{\"BladeDamagePlacementId\":1,\"BladeDescription\":\"Distance to Web more than 250mm\",\"BladeEdgeId\":6,\"BladeInspectionDataId\":11,\"BladePictureNumber\":\"2\",\"BladeRadius\":12.5,\"ComponentInspectionReportBladeDamageId\":0,\"ComponentInspectionReportBladeId\":0,\"DamageSeverity\":-1,\"FormIOImageGUID\":\"98a58dfe-555f-4511-8339-8fd7db5d815e\",\"PictureOrder\":null}],\"RepairRecordData\":{\"BladeAdditionalDocumentReference\":\"\",\"BladeAmbientTemp\":0.0,\"BladeGlassSupplier\":\"\",\"BladeGlassSupplierBatchNumbers\":\"\",\"BladeHardenerType\":\"\",\"BladeHardenerTypeBatchNumbers\":\"\",\"BladeHardenerTypeExpiryDate\":null,\"BladeHumidity\":0.0,\"BladePostCureMaxTemperature\":0.0,\"BladePostCureMinTemperature\":0.0,\"BladeResinType\":\"\",\"BladeResinTypeBatchNumbers\":\"\",\"BladeResinTypeExpiryDate\":null,\"BladeResinUsed\":0,\"BladeSurfaceMaxTemperature\":0.0,\"BladeSurfaceMinTemperature\":0.0,\"BladeTotalCureTime\":0,\"BladeTurnOffTime\":null,\"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportBladeRepairRecordId\":0,\"strBladeHardenerTypeExpiryDate\":\"\",\"strBladeResinTypeExpiryDate\":\"\",\"strBladeTurnOffTime\":\"\"},\"VestasUniqueIdentifier\":\"29078093\",\"strBladeLsCalibrationDate\":\"\"},\"Brand\":\"Vestas\",\"CIMCaseNumber\":4027,\"CIRID\":414597,\"CIRTemplateGUID\":\"\",\"CirDataID\":0,\"CirName\":\"\",\"CommisioningDate\":\"2017-07-29T00:00:00\",\"ComponentInspectionReportId\":414597,\"ComponentInspectionReportName\":\"\",\"ComponentInspectionReportStateId\":1,\"ComponentInspectionReportTypeId\":1,\"ComponentInspectionReportVersion\":\"\",\"ComponentUpTowerSolutionID\":1,\"ConductedBy\":\"1\",\"Country\":\"Germany\",\"CountryISOId\":0,\"Created\":\"0001-01-01T00:00:00\",\"CurrentUser\":\"mcpet\",\"Deleted\":\"0001-01-01T00:00:00\",\"DeletedBy\":\"\",\"Description\":\"Lightning damage on carbon fleece (95 - 121cm in diameter) has been found.\\nDown conductor cable shows evidence of an arc.\\nNo flash over on blade surface has been found.\",\"DescriptionConsquential\":\"\",\"DyanamicDecisionData\":null,\"DynamicTableInputs\":null,\"ErrorMessage\":\"\",\"FailureDate\":\"2018-08-14T00:00:00\",\"FlangDesc\":\"\",\"FormIOGUID\":\"2a82aedd-da85-45e1-a326-6f9cdea98231\",\"Gearbox\":null,\"General\":null,\"Generator\":null,\"Generator1Hrs\":6316,\"Generator2Hrs\":0,\"HideLock\":\"\",\"HideProgress\":null,\"HideTemplateVer\":\"\",\"HtmlStr\":\"\",\"ImageData\":[{\"FlangNo\":0,\"FormIOImageGUID\":\"13e08546-87ee-47cb-b8a9-40b83e18aac0\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/f99bd65e-901d-4343-ae63-1417b239f550.txt\",\"ImageDescription\":\"3c453bcc-91dc-4b85-86a5-97adb940e3c0.jpg##WW Root - Down conductor cable: evidence for an arc\",\"ImageId\":0,\"ImageOrder\":1,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/f99bd65e-901d-4343-ae63-1417b239f550.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"98a58dfe-555f-4511-8339-8fd7db5d815e\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/9b39ab31-d3d3-458b-a4da-270a5a4d5813.txt\",\"ImageDescription\":\"3e91c5e9-87dd-4193-a077-5100163ae140.jpg##WW Root - Distance to Web more than 250mm\",\"ImageId\":0,\"ImageOrder\":2,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/9b39ab31-d3d3-458b-a4da-270a5a4d5813.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"724d3f79-8861-4f46-a76b-7d3115835b71\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/3fc09ae9-2077-4de5-b10b-0d73cac0470c.txt\",\"ImageDescription\":\"6f9c4bf9-7415-4b9d-99bc-7e7b1b30386f.jpg##WW Root - Carbon Cap/Pultrusion Damage\",\"ImageId\":0,\"ImageOrder\":3,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/3fc09ae9-2077-4de5-b10b-0d73cac0470c.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"7a4bda0e-2ddf-4afb-b704-ff8ba5b2fa79\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/99289d00-9fa3-4cca-b778-e1703f58e466.txt\",\"ImageDescription\":\"11bc7102-ceff-4a21-a5f4-a93ed4f31fc1.jpg##WW Root - Delamination bigger than 200x200mm\",\"ImageId\":0,\"ImageOrder\":4,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/99289d00-9fa3-4cca-b778-e1703f58e466.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6c8b0002-3ea5-458f-9790-2fdfec279042\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/245df034-9e47-4903-abca-d5d791e262ad.txt\",\"ImageDescription\":\"8ebc68f6-d1a5-4b90-945b-3059270dfe79.jpg##WW Root - Carbon Cap/Pultrusion Damage\",\"ImageId\":0,\"ImageOrder\":5,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/245df034-9e47-4903-abca-d5d791e262ad.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"d417cdf7-d477-4196-9182-6eb31613b9b9\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/e96a8338-5c2d-4dfc-a8a4-91a7aa5d771c.txt\",\"ImageDescription\":\"203f3c4a-8978-407c-94ac-855a2e30f9cc.jpg##WW Root - Delamination bigger than 200x200mm\",\"ImageId\":0,\"ImageOrder\":6,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/e96a8338-5c2d-4dfc-a8a4-91a7aa5d771c.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6567ec37-cb78-4b55-880a-7cfc78f993ac\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/5803c8c3-bf81-46b9-b0eb-2eee3505c848.txt\",\"ImageDescription\":\"b8a6fe75-0dc5-4a04-8007-3c516848c947.jpg##WW Root - Delamination bigger than 200x200mm\",\"ImageId\":0,\"ImageOrder\":7,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/5803c8c3-bf81-46b9-b0eb-2eee3505c848.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"0d61213b-3378-4939-8e25-01bed296e1b8\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/65ee92bc-9afb-4fa7-b8f2-1bfa850eeef7.txt\",\"ImageDescription\":\"501b6620-de55-4140-9edd-2f7afbf5cf92.jpg##WW Root - Delamination bigger than 200x200mm\",\"ImageId\":0,\"ImageOrder\":8,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/65ee92bc-9afb-4fa7-b8f2-1bfa850eeef7.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"e59d3844-c638-4879-bd2d-961f5e013bee\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/b829bab7-160f-4e9d-af31-19d656170d69.txt\",\"ImageDescription\":\"2065766d-40d3-4414-a211-080c0b1db57c.jpg##WW Root - Carbon Cap/Pultrusion Damage\",\"ImageId\":0,\"ImageOrder\":9,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/b829bab7-160f-4e9d-af31-19d656170d69.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"6711e4a3-b1a3-4309-82fe-a992eb90c728\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/4bb42ec7-e34d-441b-b19b-9f141c359a41.txt\",\"ImageDescription\":\"51899962-17f2-4b3a-a608-084aaa6fe2e8.jpg##WW Root - Distance to Web more than 250mm\",\"ImageId\":0,\"ImageOrder\":10,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/4bb42ec7-e34d-441b-b19b-9f141c359a41.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"8a1edd72-75a7-4a1e-bdaf-a134566f5d66\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/dc1108f8-8e33-428f-9a72-991fa053bf28.txt\",\"ImageDescription\":\"b761fbeb-6213-4383-a021-b347443d598c.jpg##WW Root - Carbon Cap/Pultrusion Damage\",\"ImageId\":0,\"ImageOrder\":11,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/dc1108f8-8e33-428f-9a72-991fa053bf28.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"de4a078f-eae2-4fd9-90e8-50eccd92a54a\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/d348a45b-2a23-43b8-8729-cd94bea00088.txt\",\"ImageDescription\":\"612f8a62-2b4e-4b04-a25a-d4ed9a2800f1.jpg##WW Root - Distance to Web less than 250mm\",\"ImageId\":0,\"ImageOrder\":12,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/d348a45b-2a23-43b8-8729-cd94bea00088.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"333a8bcb-ffcd-46b6-a01b-88f85531f061\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/4f41ff61-6d53-4382-a72d-f8645571418f.txt\",\"ImageDescription\":\"aeba6660-5d85-45c1-b7d3-2dbba8338487.jpg##WW Root - Carbon Cap/Pultrusion Damage\",\"ImageId\":0,\"ImageOrder\":13,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/4f41ff61-6d53-4382-a72d-f8645571418f.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false},{\"FlangNo\":0,\"FormIOImageGUID\":\"a6f39d78-a021-4197-bb91-7a1c6ec5a15d\",\"ImageDataString\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/636294e5-7939-4603-b477-793dd56263db.txt\",\"ImageDescription\":\"e84fe78d-109c-45ee-8874-5caaf9410586.jpg##WW Root - Distance to Web more than 250mm\",\"ImageId\":0,\"ImageOrder\":14,\"ImageUrl\":\"https://cirprodblobstorage.blob.core.windows.net/cirprodcontainer/636294e5-7939-4603-b477-793dd56263db.txt\",\"InspectionDesc\":\"\",\"IsNewImageControl\":true,\"IsPlateType\":false}],\"ImageDataInfo\":{\"IsPlateTypeNotPossible\":true,\"PlateTypeNotPossibleReason\":\"Forgot to notice by subcontractor.\"},\"InspectionDate\":\"2018-08-14T00:00:00\",\"InstallationDate\":\"2017-07-29T00:00:00\",\"InternalComments\":\"\",\"LocalTurbineId\":\"\",\"LocationTypeId\":6,\"MainBearing\":null,\"Modified\":\"0001-01-01T00:00:00\",\"MountedOnMainComponentBooleanAnswerId\":1,\"NotificationNumber\":\"306282255\",\"OutSideSign\":false,\"Quantity\":1,\"ReasonForService\":\"CIM4027 V126 C type re-route to web\\n[CIM4027 Blade Inspection Up-tower Intern]\",\"ReconstructionBooleanAnswerId\":1,\"ReportTypeId\":2,\"RunHours\":7689,\"SBUId\":1,\"SBUName\":\"\",\"SBURecomendation\":\"SST – CIM 4027 \\\\ Internal Blade Inspection \\\\ Damage\\nabove acceptance criteria \\\\ Cat 5 \\\\ Blade to be replaced \\\\\\nAccording to 0070-2765 \\\\ Retrofit According to doc 0070-4741 \\\\\\nWTG in STOP / PAUSE\",\"SecondGeneratorBooleanAnswerId\":null,\"ServiceEngineer\":\"vestas\",\"ServiceReportNumber\":\"54894657\",\"ServiceReportNumberTypeId\":4,\"SiteName\":\"Eckardtsheim (RNSP ISM BLA)\",\"Skiip\":null,\"TemplateVersion\":\"9\",\"TotalAcceptedRecords\":0,\"TotalProduction\":6318468,\"TotalRecords\":0,\"TotalRejectedRecords\":0,\"TotalUnApprovedRecords\":0,\"Transformer\":null,\"TurbineData\":{\"Country\":\"\",\"CountryIsoId\":0,\"Frequency\":50,\"LocalTurbineId\":\"WTG02\",\"Manufacturer\":\"Vestas\",\"MarkVersion\":\"MK2C\",\"NominelPower\":3300,\"NominelPowerId\":0,\"Placement\":\"Onshore\",\"PowerRegulation\":\"FSCS (Full Scale Conv. System)\",\"RotorDiameter\":126.0,\"Site\":\"\",\"SmallGenerator\":0,\"TemperatureVariant\":\"STD\",\"Turbine\":\"\",\"TurbineMatrixId\":0,\"Voltage\":650},\"TurbineMatrixId\":null,\"TurbineNumber\":218618,\"TurbineType\":\"V126\",\"VestasItemNumber\":\"29078093\",\"isSimplifiedCir\":false,\"strCommisioningDate\":\"2017/07/29T00:00:00\",\"strFailureDate\":\"2018/08/14T00:00:00\",\"strInspectionDate\":\"2018/08/14T00:00:00\",\"strInstallationDate\":\"2017/07/29T00:00:00\"}";

            // CIRList = Newtonsoft.Json.JsonConvert.DeserializeObject<CIR.ComponentInspectionReport>(tmp1);


            // CIRList = GetCIRDatabyCIRID(500391);//307066,307079
            // CIRList.CurrentUser = "akgpt@vestas.com";

            //CIRList = GetCIRDatabyCIRID(500727);//500699
            //CIRList.CurrentUser = "chpka@vestas.com";
            //CIRList.ReportTypeId = 2;

            #endregion [Commented old code]
            CirResponse oCirResponse = new CirResponse();
            string responseString = string.Empty;
            long CirDataId = 0;
            try
            {
                responseString = Newtonsoft.Json.JsonConvert.SerializeObject(CIRList);
                Edmx.ComponentInspectionReport CIRListUp = null;
                bool IsUpdate = false;
                long CIRID = 0;

                CIR.TurbineProperties objTurbine = new TurbineProperties();

                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    /*Finding the CIR value exist in database or not */

                    //CIM Case Validation
                    string CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                    bool IsCIMCaseValid = DAOnlineValidation.ValidateCIMCaseNumber(CIMCaseNumber);



                    //if (!IsCIMCaseValid)
                    //{
                    //    oCirResponse.Status = false;
                    //    oCirResponse.StatusMessage = "Invalid CIM Case number";
                    //    oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                    //    oCirResponse.StatusDetailMessage = "The CIM Case number you have provided is invalid and does not exist in the system. Edit the CIR and select a valid CIM Case number from the CIM Case number list from the Common Section";
                    //    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "The CIM Case Number is not valid", LogType.Error, responseString);
                    //    return oCirResponse;
                    //}
                    //CIM Case Validation

                    string TurbineNumber = CIRList.TurbineNumber.ToString();

                    var oTurbine = (from s in context.TurbineData
                                    where s.TurbineId == TurbineNumber
                                    select s).FirstOrDefault();

                    if (oTurbine == null)
                    {
                        TurbineNumber = System.Configuration.ConfigurationManager.AppSettings["DefaultTurbineNumber"];
                        oTurbine = (from s in context.TurbineData
                                    where s.TurbineId == TurbineNumber
                                    select s).FirstOrDefault();
                    }

                    if (context.TurbineData.Any(o => o.TurbineId == TurbineNumber))
                    {
                        CIRListUp = (from s in context.ComponentInspectionReport
                                     where s.ComponentInspectionReportId == CIRList.ComponentInspectionReportId
                                     select s).FirstOrDefault();

                        /* Turbine Data reterival */
                        objTurbine = GetTurbineRecord(CIRList.TurbineNumber.ToString(), context);
                        long hdnCirId = Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["hdnCirId"]);
                        
                            if (objTurbine != null )
                        {
                            //"MAM/SAP" Notification and Service number validation
                            var ServiceReportNumberType = context.ServiceReportNumberType.Where(x => x.ServiceReportNumberTypeId == CIRList.ServiceReportNumberTypeId).FirstOrDefault();
                            if (ServiceReportNumberType != null && CIRList.CIRID < hdnCirId)
                            {
                                if (ServiceReportNumberType.Name.ToUpper() == "MAM/SAP")
                                {
                                    try
                                    { 
                                        var serviceReportNumber = CIRList.ServiceReportNumber;                                         
                                            if (!DACirValidator.IsValidServiceReportNumber(serviceReportNumber, CIRList.TurbineNumber.ToString()))
                                            {
                                                oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                                                oCirResponse.Status = false;
                                                oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                                                oCirResponse.StatusMessage = "The Turbine number and Service Report number could not be matched in SAP";
                                                oCirResponse.StatusDetailMessage = "The Turbine number and Service Report number could not be matched in SAP. Either provide a valid Service Report number or do not choose 'SAP/MAP' from the Service Number Type dropdown from Common section";
                                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "The Turbine number and service report number could not be matched in SAP [CIRID = " + oCirResponse.CirID.ToString() + "]", LogType.Error, responseString);
                                                return oCirResponse;
                                            }                                         
                                    }
                                    catch (Exception ex)
                                    {
                                        oCirResponse.InnerExceptionMessage = ex.InnerException.InnerException.Message;
                                        oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                                        oCirResponse.Status = false;
                                        oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                                        oCirResponse.StatusMessage = "Error occurred while validating Turbine number/Service Report number";
                                        oCirResponse.StatusDetailMessage = "An error occurred while validating turbine number or service report number against SAP (" + ex.Message + ")";
                                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "An error occurred while validating turbine number and service report number against SAP [CIRID = " + oCirResponse.CirID.ToString() + "]", LogType.Error, ex.Message);
                                        return oCirResponse;
                                    }

                                }
                            }

                            if (null != CIRListUp)
                            {
                                IsUpdate = CIRListUp.ComponentInspectionReportId > 0 ? true : false;
                            }

                            using (TransactionScope scope = new TransactionScope())
                            {
                                try
                                {
                                    CIRID = InsertUpdateCIRDataNew(IsUpdate, CIRList, CIRListUp, context, objTurbine, out CirDataId);
                                    scope.Complete();
                                }

                                catch (DbEntityValidationException e)
                                {
                                    string validationErrors = "";
                                    foreach (var failure in e.EntityValidationErrors)
                                    {
                                        validationErrors = "";

                                        foreach (var error in failure.ValidationErrors)
                                        {
                                            validationErrors += error.PropertyName + "  " + error.ErrorMessage;
                                        }
                                    }
                                    var newException = new FormattedDbEntityValidationException(e);
                                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", level.ToString() + "Cir Exception in Transaction.. " + oCirResponse.InnerExceptionMessage + " [CIRID = " + CIRList.ComponentInspectionReportId + "]\n  Inner Exception : " + oCirResponse.InnerExceptionMessage, LogType.Error, responseString);
                                    oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                                    oCirResponse.Status = false;
                                    oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                                    oCirResponse.StatusMessage = String.IsNullOrEmpty(validationErrors) ? "Unknown Error Occured while Syncing" : validationErrors;
                                    oCirResponse.StatusDetailMessage = "Unknown Error Occured! Please contact system admin and mail the error description : " + HttpUtility.HtmlEncode(oCirResponse.InnerExceptionMessage);
                                    return oCirResponse;
                                }
                                catch (Exception e)
                                {
                                    scope.Dispose();
                                    if (e.InnerException == null)
                                    {
                                        oCirResponse.InnerExceptionMessage = e.Message;
                                    }
                                    else
                                    {
                                        oCirResponse.InnerExceptionMessage = e.InnerException.InnerException.Message;
                                    }
                                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", level.ToString() + "Cir Exception in Transaction.. " + oCirResponse.InnerExceptionMessage + " [CIRID = " + CIRList.ComponentInspectionReportId + "]\n  Inner Exception : " + oCirResponse.InnerExceptionMessage, LogType.Error, responseString);
                                    oCirResponse.Status = false;
                                    oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                                    oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                                    oCirResponse.StatusMessage = "Unknown Error Occured while Syncing";
                                    oCirResponse.StatusDetailMessage = "Unknown Error Occured! Please contact system admin and mail the error description : " + HttpUtility.HtmlEncode(oCirResponse.InnerExceptionMessage);
                                    return oCirResponse;
                                }
                            }
                            if (CIRID > 0)
                            {
                                string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
                                string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                                GeneratePDFDelegate d = null;
                                d = new GeneratePDFDelegate(DACIRReport.RenderCirReport);
                                IAsyncResult R = null;
                                R = d.BeginInvoke(CIRID, DocumentPath, SpireLicensePath, null, null); //invoking the method
                                bool returnVal = d.EndInvoke(R);
                            }
                        }
                    }
                    else
                    {
                        oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                        oCirResponse.Status = false;
                        oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                        oCirResponse.StatusDetailMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.TurbineNotExists) + " - The Turbine number is not found in the system. Either the Turbine number is not yet in the system or you might have entered invalid Turbine Number";
                        oCirResponse.StatusMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.TurbineNotExists);
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Turbine Number Not Exists [CIRID = " + oCirResponse.CirID.ToString() + "]", LogType.Warning, responseString);
                        return oCirResponse;
                    }

                }

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Cir " + CIRList.ComponentInspectionReportId + (!IsUpdate ? " Created" : " Updated") + " CIRID: " + CIRID.ToString(), LogType.Information, responseString);


                #region Reponse
                oCirResponse.Status = true;
                oCirResponse.StatusDetailMessage = "CIR is successfully synced with server";
                oCirResponse.StatusMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.Success);
                oCirResponse.CirID = CIRID;
                oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                oCirResponse.CirDataId = CirDataId;
                oCirResponse.CirName = getCirName(objTurbine.Site, CIRList.ComponentInspectionReportTypeId, CIRList.TurbineNumber.ToString(), CIRList.CIMCaseNumber.ToString());

                if (!ReferenceEquals(objTurbine, null))
                {
                    TurbineItem oTurbineItem = new TurbineItem();
                    oTurbineItem.TurbineID = CIRList.TurbineNumber.ToString();
                    oTurbineItem.TurbineType = objTurbine.Turbine;
                    oTurbineItem.Country = objTurbine.Country;
                    oTurbineItem.RotorDiameter = Convert.ToString(objTurbine.RotorDiameter);
                    oTurbineItem.NominelPower = Convert.ToString(objTurbine.NominelPower);
                    oTurbineItem.Voltage = Convert.ToString(objTurbine.Voltage);
                    oTurbineItem.PowerRegulation = Convert.ToString(objTurbine.PowerRegulation);
                    oTurbineItem.Frequency = Convert.ToString(objTurbine.Frequency);
                    oTurbineItem.SmallGenerator = Convert.ToString(objTurbine.SmallGenerator);
                    oTurbineItem.TemperatureVariant = Convert.ToString(objTurbine.TemperatureVariant);
                    oTurbineItem.MarkVersion = Convert.ToString(objTurbine.MarkVersion);
                    oTurbineItem.Site = Convert.ToString(objTurbine.Site);
                    oTurbineItem.Manufacturer = Convert.ToString(objTurbine.Manufacturer);
                    oCirResponse.Turbine = oTurbineItem;
                }
                #endregion
            }
            catch (DbEntityValidationException e)
            {
                string validationErrors = "";
                foreach (var failure in e.EntityValidationErrors)
                {
                    validationErrors = "";

                    foreach (var error in failure.ValidationErrors)
                    {
                        validationErrors += error.PropertyName + "  " + error.ErrorMessage;
                    }
                }
                var newException = new FormattedDbEntityValidationException(e);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Entity Error : " + newException.Message + "[CIRID = " + CIRList.ComponentInspectionReportId + "] \n Details : " + newException.StackTrace, LogType.Error, responseString);
                oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                oCirResponse.Status = false;
                oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                oCirResponse.StatusMessage = String.IsNullOrEmpty(validationErrors) ? "Data validation Error while Syncing" : validationErrors;
                oCirResponse.StatusDetailMessage = "Data validation Error Occured! Please contact system admin and mail the error description : " + HttpUtility.HtmlEncode(newException.Message);
                return oCirResponse;
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";
                innerstr = (oException.InnerException != null) ? (oException.InnerException.InnerException != null) ? oException.InnerException.InnerException.Message + "\n Details : " + oException.InnerException.InnerException.StackTrace : innerstr : innerstr;
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", level.ToString() + ": Entity Exception : " + exstr + "[CIRID = " + CIRList.ComponentInspectionReportId + "]\n  Inner Exception : " + innerstr, LogType.Error, responseString);
                oCirResponse.Status = false;
                oCirResponse.CIMCaseNumber = CIRList.CIMCaseNumber.ToString();
                oCirResponse.CirID = CIRList.ComponentInspectionReportId;
                oCirResponse.StatusMessage = "Unknown Error Occured while Syncing";
                oCirResponse.StatusDetailMessage = "Unknown Error Occured! Please contact system admin and mail the error description : " + HttpUtility.HtmlEncode(innerstr);
                return oCirResponse;
            }
            return oCirResponse;
        }

        public static CirDataActionResponse ApproveCIR(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, long CirDataId, bool callPdfGeneration = true)
        {
            CirDataDetail cirDataDetail = new CirDataDetail();
            cirDataDetail.PdfDataUri = "";
            cirDataDetail.CIMCaseNumber = "";
            cirDataDetail.CirDataId = CirDataId;
            cirDataDetail.CirId = CIRList.CIRID.ToString();
            cirDataDetail.CirState = 1;
            cirDataDetail.comment = "Approved by " + CIRList.CurrentUser;
            cirDataDetail.ComponentType = "";
            cirDataDetail.Filename = "";
            cirDataDetail.Locked = 1;
            cirDataDetail.LockedBy = CIRList.CurrentUser;
            cirDataDetail.modifiedBy = CIRList.CurrentUser;
            cirDataDetail.Progress = 2;
            cirDataDetail.ReportType = "";
            cirDataDetail.TurbineNumber = "";
            cirDataDetail.TurbineType = "";
            var oApproveResponse = DACIRView.CirProcess(cirDataDetail, callPdfGeneration);
            return oApproveResponse;
        }
        //public void PDFGenCompleted(IAsyncResult R)
        //{
        //    GeneratePDFDelegate X = (GeneratePDFDelegate)((AsyncResult)R).AsyncDelegate;
        //    if(X.EndInvoke(R))
        //    {
        //        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "PDF Generated", LogType.Information, "");
        //    }
        //    else
        //        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "PDF generation error", LogType.Error, "");
        //}
        /// <summary>
        /// Get Turbine Data
        /// </summary>
        /// <param name="TurbineNumber"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static CIR.TurbineProperties GetTurbineRecord(string TurbineNumber, CIM_CIREntities context)
        {
            CIR.TurbineProperties objTurbineData = new TurbineProperties();
            var turbineMatrixId = new ObjectParameter("turbineMatrixId", typeof(long));
            var frequency = new ObjectParameter("frequency", typeof(byte));
            var turbine = new ObjectParameter("turbine", typeof(string));
            var manufacturer = new ObjectParameter("manufacturer", typeof(string));
            var markVersion = new ObjectParameter("markVersion", typeof(string));
            var nominelPower = new ObjectParameter("nominelPower", typeof(int));
            var nominelPowerId = new ObjectParameter("nominelPowerId", typeof(long));
            var placement = new ObjectParameter("placement", typeof(string));
            var powerRegulation = new ObjectParameter("powerRegulation", typeof(string));
            var rotorDiameter = new ObjectParameter("rotorDiameter", typeof(decimal));
            var smallGenerator = new ObjectParameter("smallGenerator", typeof(int));
            var temperatureVariant = new ObjectParameter("temperatureVariant", typeof(string));
            var voltage = new ObjectParameter("voltage", typeof(int));
            var countryIsoId = new ObjectParameter("countryIsoId", typeof(long));
            var country = new ObjectParameter("country", typeof(string));
            var site = new ObjectParameter("site", typeof(string));
            var localTurbineId = new ObjectParameter("localTurbineId", typeof(string));
            context.TurbineDataGet(TurbineNumber, turbineMatrixId,
                     turbine,
                    frequency,
                     manufacturer,
                     markVersion,
                     nominelPower,
                     nominelPowerId,
                     placement,
                     powerRegulation,
                     rotorDiameter,
                     smallGenerator,
                     temperatureVariant,
                     voltage,
                     countryIsoId,
                     country,
                     site,
                     localTurbineId);
            return new TurbineProperties
            {
                Country = country.Value == DBNull.Value ? "" : country.Value.ToString(),
                CountryIsoId = countryIsoId.Value == DBNull.Value ? 0 : Convert.ToInt32(countryIsoId.Value),
                Frequency = frequency.Value == DBNull.Value ? Convert.ToByte(1) : Convert.ToByte(frequency.Value),
                LocalTurbineId = localTurbineId.Value == DBNull.Value ? "" : localTurbineId.Value.ToString(),
                Manufacturer = manufacturer.Value == DBNull.Value ? "" : manufacturer.Value.ToString(),
                MarkVersion = markVersion.Value == DBNull.Value ? "" : markVersion.Value.ToString(),
                NominelPower = nominelPower.Value == DBNull.Value ? 0 : Convert.ToInt32(nominelPower.Value),
                NominelPowerId = nominelPowerId.Value == DBNull.Value ? 0 : Convert.ToInt64(nominelPowerId.Value),
                Placement = placement.Value == DBNull.Value ? "" : placement.Value.ToString(),
                PowerRegulation = powerRegulation.Value == DBNull.Value ? "" : powerRegulation.Value.ToString(),
                RotorDiameter = rotorDiameter.Value == DBNull.Value ? 0 : Convert.ToDecimal(rotorDiameter.Value),
                Site = site.Value == DBNull.Value ? "" : site.Value.ToString(),
                SmallGenerator = smallGenerator.Value == DBNull.Value ? 0 : Convert.ToInt32(smallGenerator.Value),
                TemperatureVariant = temperatureVariant.Value == DBNull.Value ? "" : temperatureVariant.Value.ToString(),
                Turbine = turbine.Value == DBNull.Value ? "" : turbine.Value.ToString(),
                TurbineMatrixId = turbineMatrixId.Value == DBNull.Value ? 0 : 0,
                Voltage = voltage.Value == DBNull.Value ? 0 : Convert.ToInt32(voltage.Value)
            };
        }
        /// <summary>
        /// Parse Data
        /// </summary>
        /// <param name="dtdateTime"></param>
        /// <returns></returns>
        protected static DateTime ParseDatetime(DateTime? dtdateTime)
        {
            DateTime sDateTime;// DateTime dtNdateTime;
            if (dtdateTime.HasValue)
            {
                if (dtdateTime.Value < SqlDateTime.MinValue.Value)
                {
                    dtdateTime = SqlDateTime.MinValue.Value;
                }
                else if (dtdateTime.Value > SqlDateTime.MaxValue.Value)
                {
                    dtdateTime = SqlDateTime.MaxValue.Value;

                }
            }
            else
            { dtdateTime = SqlDateTime.MinValue.Value; }

            sDateTime = dtdateTime.Value;
            return sDateTime;
        }
        /// <summary>
        /// Parse date time from string
        /// </summary>
        /// <param name="dtdateTime"></param>
        /// <returns></returns>
        protected static DateTime ParseDatetime(string dtdateTime)
        {
            DateTime sDateTime;// DateTime dtNdateTime;
            if (dtdateTime == "0001-01-01T00:00:00")
                return DateTime.Today;
            if (!string.IsNullOrEmpty(dtdateTime) && DateTime.TryParse(dtdateTime, out sDateTime))
            {
                return sDateTime;
            }
            else
            {
                return DateTime.Today;
            }
        }

        protected static DateTime? ParseFailureDatetime(string dtdateTime, long reportType)
        {
            DateTime sDateTime;// DateTime dtNdateTime;
            if ((dtdateTime == "0001-01-01T00:00:00" || string.IsNullOrEmpty(dtdateTime)) && reportType != 2)
                return null;
            else if (dtdateTime == "0001-01-01T00:00:00")
                return DateTime.Today;
            if (!string.IsNullOrEmpty(dtdateTime) && DateTime.TryParse(dtdateTime, out sDateTime))
            {
                return sDateTime;
            }
            else
            {
                return DateTime.Today;
            }
        }

        private static long GenerateCirId()
        {
            long CirID = 0;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                GenerateCIRId c = new GenerateCIRId();
                context.GenerateCIRId.Add(c);
                context.SaveChanges();
                CirID = c.CIRId;
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "New CIR ID Generated  : " + CirID.ToString(), LogType.Information, "");

            }
            return CirID;
        }
        public static string getCirName(string site, long comptype, string turbineno, string CIMCaseNumber)
        {
            var cirname = "";
            var d = DateTime.Today;
            cirname = ((site == null) ? " " : site);
            cirname = cirname.Length > 17 ? cirname.Substring(0, 17) : cirname;
            cirname = cirname + "_" + Enum.GetName(typeof(ComponentType), comptype) + "_" + turbineno + "_" + d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" + d.Day.ToString().PadLeft(2, '0') + "_" + CIMCaseNumber;
            return cirname;

        }
        /// <summary>
        /// Insert CIR Data
        /// </summary>
        /// <param name="CIRList"></param>
        protected static long InsertCIRData(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, CIM_CIREntities context, CIR.TurbineProperties objTurbine, out long CirDataId)
        {
            long CirID = CIRList.CIRID;
            CIRList.ComponentInspectionReportId = CirID;

            #region [Generate a new CIR Id for old approach]
            try
            {
                var initialCIRIdForNewApproach = Convert.ToInt32(ConfigurationManager.AppSettings["InitialCIRIdForNewApproach"]);
                if (CIRList.ComponentInspectionReportId == 0)
                {
                    CIRList.ComponentInspectionReportId = Convert.ToInt32(context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId < initialCIRIdForNewApproach).Max(x => x.ComponentInspectionReportId).ToString()) + 1;
                    CirID = CIRList.ComponentInspectionReportId;
                }
            }
            catch (Exception ex)
            {
                GlobalErrorHandler oGE = new GlobalErrorHandler();
                oGE.HandleError(ex);
            }
            #endregion [Generate a new CIR Id for old approach]


            #region [Assign value to CIR Report]

            var cirname = getCirName(objTurbine.Site, CIRList.ComponentInspectionReportTypeId, CIRList.TurbineNumber.ToString(), CIRList.CIMCaseNumber.ToString());

            Edmx.CirData objCirData = new Edmx.CirData
            {
                TemplateVersion = CIRList.TemplateVersion,
                CirDataId = 0,
                CirId = CIRList.ComponentInspectionReportId,
                Filename = cirname,
                State = 1,
                Progress = 1,
                // Email = CIRList.ServiceEngineer + "@vestas.com",  
                Email = CIRList.CurrentUser + "@vestas.com",
                Created = DateTime.UtcNow,
                CreatedBy = CIRList.CurrentUser,
                Modified = DateTime.UtcNow,
                ModifiedBy = CIRList.CurrentUser,
                Deleted = false,
                Guid = System.Guid.NewGuid().ToString()
            };
            context.CirData.Add(objCirData);
            context.SaveChanges();
            CIRList.CirDataID = objCirData.CirDataId;
            CirDataId = objCirData.CirDataId;
            CIRList.CIRTemplateGUID = objCirData.Guid;
            Edmx.CirJson objCirXml = new CirJson
            {
                CirDataId = objCirData.CirDataId,
                JSON = Newtonsoft.Json.JsonConvert.SerializeObject(CIRList),
                CirJsonId = 0
            };
            context.CirJson.Add(objCirXml);
            context.SaveChanges();
            DACIRLog.SaveCirLog(objCirData.CirDataId, "CIR Created with CID ID " + CirID.ToString(), LogType.Information, objCirData.ModifiedBy);

            level++;


            Edmx.ComponentInspectionReport objCompo = new Edmx.ComponentInspectionReport
            {
                TemplateVersion = CIRList.TemplateVersion,
                ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                ComponentInspectionReportTypeId = CIRList.ComponentInspectionReportTypeId,
                ComponentInspectionReportStateId = CIRList.ComponentInspectionReportStateId,
                ReportTypeId = CIRList.ReportTypeId,
                ReconstructionBooleanAnswerId = CIRList.ReconstructionBooleanAnswerId,
                CIMCaseNumber = CIRList.CIMCaseNumber,
                ReasonForService = CIRList.ReasonForService,
                TurbineNumber = CIRList.TurbineNumber,
                CountryISOId = objTurbine.CountryIsoId,
                SiteName = objTurbine.Site,
                TurbineMatrixId = null,
                LocationTypeId = CIRList.LocationTypeId,
                LocalTurbineId = objTurbine.LocalTurbineId,
                SecondGeneratorBooleanAnswerId = CIRList.SecondGeneratorBooleanAnswerId,
                BeforeInspectionTurbineRunStatusId = CIRList.BeforeInspectionTurbineRunStatusId,
                CommisioningDate = ParseDatetime(CIRList.strCommisioningDate),
                InstallationDate = ParseDatetime(CIRList.strInstallationDate),
                FailureDate = ParseFailureDatetime(CIRList.strFailureDate, CIRList.ReportTypeId),
                InspectionDate = ParseDatetime(CIRList.strInspectionDate),
                ServiceReportNumber = CIRList.ServiceReportNumber,
                ServiceReportNumberTypeId = CIRList.ServiceReportNumberTypeId,
                ServiceEngineer = CIRList.ServiceEngineer,
                RunHours = CIRList.RunHours,
                Generator1Hrs = CIRList.Generator1Hrs,
                Generator2Hrs = CIRList.Generator2Hrs,
                TotalProduction = CIRList.TotalProduction,
                AfterInspectionTurbineRunStatusId = CIRList.AfterInspectionTurbineRunStatusId,
                Quantity = CIRList.Quantity,
                AlarmLogNumber = CIRList.AlarmLogNumber,
                Description = CIRList.Description,
                DescriptionConsquential = CIRList.DescriptionConsquential,
                ConductedBy = CIRList.ConductedBy,
                SBUId = CIRList.SBUId,
                CIRTemplateGUID = CIRList.CIRTemplateGUID,
                VestasItemNumber = CIRList.VestasItemNumber,
                NotificationNumber = CIRList.NotificationNumber,
                MountedOnMainComponentBooleanAnswerId = CIRList.MountedOnMainComponentBooleanAnswerId,
                ComponentUpTowerSolutionID = CIRList.ComponentUpTowerSolutionID,
                ComponentInspectionReportName = cirname,
                ComponentInspectionReportVersion = "v7.0",
                AdditionalInfo = CIRList.AdditionalComments,
                InternalComments = CIRList.InternalComments,
                SBURecommendation = CIRList.SBURecomendation,
                FlangDescription = CIRList.FlangDesc,
                FormIOGUID = CIRList.FormIOGUID,
                Brand = string.IsNullOrEmpty(CIRList.Brand) || CIRList.Brand.ToLower() == "vestas_windams" ? "Vestas" : CIRList.Brand,
                OutSideSign = CIRList.OutSideSign,
                ComponentInspectionReportBlade = new List<Cir.Sync.Services.Edmx.ComponentInspectionReportBlade>()
            };
            context.ComponentInspectionReport.Add(objCompo);
            context.SaveChanges();
            level++;
            #endregion [Assign value to CIR Report]

            #region [Insert ImageData]
            long hdnCirId = Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["hdnCirId"]);
            if (CirID < hdnCirId && CIRList.ImageData != null)
            {
                for (int i = 0; i < CIRList.ImageData.Count; i++)
                {
                    string imageURI = "";
                    if (CIRList.ImageData[i].ImageUrl != null && !CIRList.ImageData[i].ImageUrl.Contains("https://servicesprod.inspectools.net"))
                    {
                        imageURI = DABir.GetByImageUrl(CIRList.ImageData[i].ImageDataString, "Img");
                    }
                    else if (CIRList.ImageData[i].ImageDataString != null && CIRList.ImageData[i].ImageDataString.Contains("https://"))
                    {
                        imageURI = CIRList.ImageData[i].ImageDataString;
                    }
                    else
                    {
                        continue;
                    }
                    WebClient client = new WebClient();
                    string dataString = client.DownloadString(imageURI);
                    CIRList.ImageData[i].ImageDataString = "data:image/jpeg;base64," + dataString;
                }
            }

            if (CIRList.ImageData == null)
                CIRList.ImageData = new List<CIR.ImageData>();

            if (CIRList.ImageDataInfo != null)
            {
                if (CIRList.ImageDataInfo.IsPlateTypeNotPossible == false && CIRList.ImageData.Count > 0 && !CIRList.ImageData[0].IsNewImageControl)
                {
                    CIRList.ImageData[0].IsPlateType = true;
                }
                context.ImageDataInfo.Add(new Edmx.ImageDataInfo { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, IsPlateTypeNotPossible = CIRList.ImageDataInfo.IsPlateTypeNotPossible, PlateTypeNotPossibleReason = CIRList.ImageDataInfo.PlateTypeNotPossibleReason });
            }
            else
            {
                if (CIRList.ImageData.Count > 0 && !CIRList.ImageData[0].IsNewImageControl)
                { CIRList.ImageData[0].IsPlateType = true; }
                context.ImageDataInfo.Add(new Edmx.ImageDataInfo { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, IsPlateTypeNotPossible = false, PlateTypeNotPossibleReason = "" });
            }
            foreach (Cir.Sync.Services.CIR.ImageData ID in CIRList.ImageData)
            {
                if (ID.IsPlateType != true)
                {
                    ID.ImageOrder = ID.ImageOrder++;
                }
                context.ImageData.Add(new Edmx.ImageData { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, ImageDataString = ID.ImageDataString, ImageDescription = ID.ImageDescription, ImageOrder = ID.ImageOrder, InspectionDesc = ID.InspectionDesc, IsPlateType = ID.IsPlateType, FlangNo = ID.FlangNo, ImageUrl = ID.ImageUrl, FormIOImageGUID = ID.FormIOImageGUID });

            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CIRList.ImageData = null;
            #endregion  [Insert ImageData]

            #region assign value to CIR REport General
            /* Assign value to CIR Report Blade Entity */
            if (!ReferenceEquals(CIRList.General, null) && CIRList.ComponentInspectionReportTypeId == 3)
            {
                Edmx.ComponentInspectionReportGeneral objCompoGeneral = new Edmx.ComponentInspectionReportGeneral
                {
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    GeneralComponentGroupId = CIRList.General.GeneralComponentGroupId,
                    GeneralComponentType = CIRList.General.GeneralComponentType,
                    VestasUniqueIdentifier = CIRList.General.VestasUniqueIdentifier,
                    GeneralComponentManufacturer = CIRList.General.GeneralComponentManufacturer,
                    GeneralOtherGearboxType = CIRList.General.GeneralOtherGearboxType,
                    GeneralClaimRelevantBooleanAnswerId = CIRList.General.GeneralClaimRelevantBooleanAnswerId,
                    GeneralOtherGearboxManufacturer = CIRList.General.GeneralOtherGearboxManufacturer,
                    GeneralComponentSerialNumber = CIRList.General.GeneralComponentSerialNumber,
                    GeneralGeneratorManufacturerId = CIRList.General.GeneralGeneratorManufacturerId,
                    GeneralTransformerManufacturerId = CIRList.General.GeneralTransformerManufacturerId,
                    GeneralGearboxManufacturerId = CIRList.General.GeneralGearboxManufacturerId,
                    GeneralTowerTypeId = CIRList.General.GeneralTowerTypeId,
                    GeneralTowerHeightId = CIRList.General.GeneralTowerHeightId,
                    GeneralBlade1SerialNumber = CIRList.General.GeneralBlade1SerialNumber,
                    GeneralBlade2SerialNumber = CIRList.General.GeneralBlade2SerialNumber,
                    GeneralBlade3SerialNumber = CIRList.General.GeneralBlade3SerialNumber,
                    GeneralControllerTypeId = CIRList.General.GeneralControllerTypeId,
                    GeneralSoftwareRelease = CIRList.General.GeneralSoftwareRelease,
                    GeneralRamDumpNumber = CIRList.General.GeneralRamDumpNumber,
                    GeneralVDFTrackNumber = CIRList.General.GeneralVDFTrackNumber,
                    GeneralPicturesIncludedBooleanAnswerId = (CIRList.General.GeneralPicturesIncludedBooleanAnswerId == 0) ? 1 : CIRList.General.GeneralPicturesIncludedBooleanAnswerId,
                    GeneralInitiatedBy1 = CIRList.General.GeneralInitiatedBy1,
                    GeneralInitiatedBy2 = CIRList.General.GeneralInitiatedBy2,
                    GeneralInitiatedBy3 = CIRList.General.GeneralInitiatedBy3,
                    GeneralInitiatedBy4 = CIRList.General.GeneralInitiatedBy4,
                    GeneralMeasurementsConducted1 = CIRList.General.GeneralMeasurementsConducted1,
                    GeneralMeasurementsConducted2 = CIRList.General.GeneralMeasurementsConducted2,
                    GeneralMeasurementsConducted3 = CIRList.General.GeneralMeasurementsConducted3,
                    GeneralMeasurementsConducted4 = CIRList.General.GeneralMeasurementsConducted4,
                    GeneralExecutedBy1 = CIRList.General.GeneralExecutedBy1,
                    GeneralExecutedBy2 = CIRList.General.GeneralExecutedBy2,
                    GeneralExecutedBy3 = CIRList.General.GeneralExecutedBy3,
                    GeneralExecutedBy4 = CIRList.General.GeneralExecutedBy4,
                    GeneralPositionOfFailedItem = CIRList.General.GeneralPositionOfFailedItem
                };

                context.ComponentInspectionReportGeneral.Add(objCompoGeneral);
                context.SaveChanges();
            }

            #endregion
            #region assign value to CIR REport Blade
            /* Assign value to CIR Report Blade Entity */
            if (!ReferenceEquals(CIRList.BladeData, null) && !string.IsNullOrEmpty(CIRList.BladeData.BladeSerialNumber))
            {
                Edmx.ComponentInspectionReportBlade objCompoBlade = new Edmx.ComponentInspectionReportBlade
                {
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    ComponentInspectionReportBladeId = CIRList.BladeData.ComponentInspectionReportBladeId,
                    VestasUniqueIdentifier = CIRList.BladeData.VestasUniqueIdentifier,
                    BladeLengthId = CIRList.BladeData.BladeLengthId,
                    BladeColorId = CIRList.BladeData.BladeColorId,
                    BladeSerialNumber = CIRList.BladeData.BladeSerialNumber,
                    BladePicturesIncludedBooleanAnswerId = CIRList.BladeData.BladePicturesIncludedBooleanAnswerId,
                    BladeOtherSerialNumber1 = CIRList.BladeData.BladeOtherSerialNumber1,
                    BladeOtherSerialNumber2 = CIRList.BladeData.BladeOtherSerialNumber2,
                    BladeDamageIdentified = CIRList.BladeData.BladeDamageIdentified,
                    BladeFaultCodeClassificationId = CIRList.BladeData.BladeFaultCodeClassificationId,
                    BladeFaultCodeCauseId = CIRList.BladeData.BladeFaultCodeCauseId,
                    BladeFaultCodeTypeId = CIRList.BladeData.BladeFaultCodeTypeId,
                    BladeFaultCodeAreaId = CIRList.BladeData.BladeFaultCodeAreaId,
                    BladeClaimRelevantBooleanAnswerId = CIRList.BladeData.BladeClaimRelevantBooleanAnswerId,
                    BladeLsVtNumber = CIRList.BladeData.BladeLsVtNumber,
                    BladeLsCalibrationDate = ParseDatetime(CIRList.BladeData.strBladeLsCalibrationDate),
                    BladeLsLeewardSidePreRepairTip = CIRList.BladeData.BladeLsLeewardSidePreRepairTip,
                    BladeLsLeewardSidePostRepairTip = CIRList.BladeData.BladeLsLeewardSidePostRepairTip,
                    BladeLsLeewardSidePreRepair2 = CIRList.BladeData.BladeLsLeewardSidePreRepair2,
                    BladeLsLeewardSidePostRepair2 = CIRList.BladeData.BladeLsLeewardSidePostRepair2,
                    BladeLsLeewardSidePreRepair3 = CIRList.BladeData.BladeLsLeewardSidePreRepair3,
                    BladeLsLeewardSidePostRepair3 = CIRList.BladeData.BladeLsLeewardSidePostRepair3,
                    BladeLsLeewardSidePreRepair4 = CIRList.BladeData.BladeLsLeewardSidePreRepair4,
                    BladeLsLeewardSidePostRepair4 = CIRList.BladeData.BladeLsLeewardSidePostRepair4,
                    BladeLsLeewardSidePreRepair5 = CIRList.BladeData.BladeLsLeewardSidePreRepair5,
                    BladeLsLeewardSidePostRepair5 = CIRList.BladeData.BladeLsLeewardSidePostRepair5,
                    BladeLsLeewardSidePreRepair6 = CIRList.BladeData.BladeLsLeewardSidePreRepair6,
                    BladeLsLeewardSidePostRepair6 = CIRList.BladeData.BladeLsLeewardSidePostRepair6,
                    BladeLsLeewardSidePreRepair7 = CIRList.BladeData.BladeLsLeewardSidePreRepair7,
                    BladeLsLeewardSidePostRepair7 = CIRList.BladeData.BladeLsLeewardSidePostRepair7,
                    BladeLsLeewardSidePreRepair8 = CIRList.BladeData.BladeLsLeewardSidePreRepair8,
                    BladeLsLeewardSidePostRepair8 = CIRList.BladeData.BladeLsLeewardSidePostRepair8,
                    BladeLsWindwardSidePreRepairTip = CIRList.BladeData.BladeLsWindwardSidePreRepairTip,
                    BladeLsWindwardSidePostRepairTip = CIRList.BladeData.BladeLsWindwardSidePostRepairTip,
                    BladeLsWindwardSidePreRepair2 = CIRList.BladeData.BladeLsWindwardSidePreRepair2,
                    BladeLsWindwardSidePostRepair2 = CIRList.BladeData.BladeLsWindwardSidePostRepair2,
                    BladeLsWindwardSidePreRepair3 = CIRList.BladeData.BladeLsWindwardSidePreRepair3,
                    BladeLsWindwardSidePostRepair3 = CIRList.BladeData.BladeLsWindwardSidePostRepair3,
                    BladeLsWindwardSidePreRepair4 = CIRList.BladeData.BladeLsWindwardSidePreRepair4,
                    BladeLsWindwardSidePostRepair4 = CIRList.BladeData.BladeLsWindwardSidePostRepair4,
                    BladeLsWindwardSidePreRepair5 = CIRList.BladeData.BladeLsWindwardSidePreRepair5,
                    BladeLsWindwardSidePostRepair5 = CIRList.BladeData.BladeLsWindwardSidePostRepair5,
                    BladeLsWindwardSidePreRepair6 = CIRList.BladeData.BladeLsWindwardSidePreRepair6,
                    BladeLsWindwardSidePostRepair6 = CIRList.BladeData.BladeLsWindwardSidePostRepair6,
                    BladeLsWindwardSidePreRepair7 = CIRList.BladeData.BladeLsWindwardSidePreRepair7,
                    BladeLsWindwardSidePostRepair7 = CIRList.BladeData.BladeLsWindwardSidePostRepair7,
                    BladeLsWindwardSidePreRepair8 = CIRList.BladeData.BladeLsWindwardSidePreRepair8,
                    BladeLsWindwardSidePostRepair8 = CIRList.BladeData.BladeLsWindwardSidePostRepair8,
                    BladeInspectionReportDescription = CIRList.BladeData.BladeInspectionReportDescription,
                    BladeManufacturerId = CIRList.BladeData.BladeManufacturerId,
                    ComponentInspectionReportBladeDamage = new List<Cir.Sync.Services.Edmx.ComponentInspectionReportBladeDamage>()
                };
                context.ComponentInspectionReportBlade.Add(objCompoBlade);
                context.SaveChanges();

                #region assign value CIR Report Blade Damage
                /* Blade Damage content*/
                if (objCompoBlade.ComponentInspectionReportBladeId > 0)
                {
                    /* Assign value to CIR Report Blade Damage Entity */
                    if (!ReferenceEquals(CIRList.BladeData.DamageData, null) && CIRList.BladeData.DamageData.Count > 0)
                        foreach (CIR.ComponentInspectionReportBladeDamage objBladeDam in CIRList.BladeData.DamageData)
                        {
                            Edmx.ComponentInspectionReportBladeDamage objCompoBladeDam = new Edmx.ComponentInspectionReportBladeDamage
                            {
                                ComponentInspectionReportBladeDamageId = objBladeDam.ComponentInspectionReportBladeDamageId,
                                ComponentInspectionReportBladeId = objCompoBlade.ComponentInspectionReportBladeId,
                                BladeDamagePlacementId = objBladeDam.BladeDamagePlacementId,
                                BladeInspectionDataId = objBladeDam.BladeInspectionDataId,
                                BladeRadius = objBladeDam.BladeRadius,
                                BladeEdgeId = objBladeDam.BladeEdgeId,
                                BladeDescription = objBladeDam.BladeDescription,
                                BladePictureNumber = objBladeDam.BladePictureNumber,
                                PictureOrder = null,
                                DamageSeverity = objBladeDam.DamageSeverity,
                                FormIOImageGUID = objBladeDam.FormIOImageGUID
                            };
                            context.ComponentInspectionReportBladeDamage.Add(objCompoBladeDam);
                        }
                    context.SaveChanges();
                }
                #endregion

                #region CIR Report Blade Repair section

                if (objCompoBlade.ComponentInspectionReportBladeId > 0)
                {
                    if ((CIRList.ReportTypeId == 3 || CIRList.ReportTypeId == 5) && CIRList.BladeData.RepairRecordData != null)
                    {
                        Cir.Sync.Services.CIR.ComponentInspectionReportBladeRepairRecord BladeRepairRecordList = CIRList.BladeData.RepairRecordData;
                        Edmx.ComponentInspectionReportBladeRepairRecord objBladeRepairRecord = new Edmx.ComponentInspectionReportBladeRepairRecord
                        {
                            ComponentInspectionReportBladeRepairRecordId = BladeRepairRecordList.ComponentInspectionReportBladeRepairRecordId,
                            ComponentInspectionReportBladeId = objCompoBlade.ComponentInspectionReportBladeId,
                            BladeAmbientTemp = BladeRepairRecordList.BladeAmbientTemp,
                            BladeHumidity = BladeRepairRecordList.BladeHumidity,
                            BladeAdditionalDocumentReference = BladeRepairRecordList.BladeAdditionalDocumentReference,
                            BladeResinType = BladeRepairRecordList.BladeResinType,
                            BladeResinTypeBatchNumbers = BladeRepairRecordList.BladeResinTypeBatchNumbers,
                            BladeResinTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeResinTypeExpiryDate),
                            BladeHardenerType = BladeRepairRecordList.BladeHardenerType,
                            BladeHardenerTypeBatchNumbers = BladeRepairRecordList.BladeHardenerTypeBatchNumbers,
                            BladeHardenerTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeHardenerTypeExpiryDate),
                            BladeGlassSupplier = BladeRepairRecordList.BladeGlassSupplier,
                            BladeGlassSupplierBatchNumbers = BladeRepairRecordList.BladeGlassSupplierBatchNumbers,
                            BladeSurfaceMaxTemperature = BladeRepairRecordList.BladeSurfaceMaxTemperature,
                            BladeSurfaceMinTemperature = BladeRepairRecordList.BladeSurfaceMinTemperature,
                            BladeResinUsed = BladeRepairRecordList.BladeResinUsed,
                            BladePostCureMaxTemperature = BladeRepairRecordList.BladePostCureMaxTemperature,
                            BladePostCureMinTemperature = BladeRepairRecordList.BladePostCureMinTemperature,
                            BladeTurnOffTime = ParseDatetime(BladeRepairRecordList.strBladeTurnOffTime),
                            BladeTotalCureTime = BladeRepairRecordList.BladeTotalCureTime
                        };

                        context.ComponentInspectionReportBladeRepairRecord.Add(objBladeRepairRecord);
                    }
                }
                context.SaveChanges();

                #endregion

            }
            #endregion
            #region assign value to CIR REport Skiip
            /* Assign value to CIR Report Skiip Entity */
            if (!ReferenceEquals(CIRList.Skiip, null) && !ReferenceEquals(CIRList.Skiip.SkiiPQuantityOfFailedModules, null) && CIRList.Skiip.SkiiPQuantityOfFailedModules > 0)
            {
                Edmx.ComponentInspectionReportSkiiP objCompoSkip = new Edmx.ComponentInspectionReportSkiiP
                {
                    ComponentInspectionReportSkiiPId = CIRList.Skiip.ComponentInspectionReportSkiiPId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    SkiiPOtherDamagedComponentsReplaced = CIRList.Skiip.SkiiPOtherDamagedComponentsReplaced,
                    SkiiPCauseId = (CIRList.Skiip.SkiiPCauseId == 0) ? 1 : CIRList.Skiip.SkiiPCauseId,// CIRList.Skiip.SkiiPCauseId,
                    SkiiPQuantityOfFailedModules = CIRList.Skiip.SkiiPQuantityOfFailedModules,
                    SkiiP2MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV521BooleanAnswerId,
                    SkiiP2MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV522BooleanAnswerId,
                    SkiiP2MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV523BooleanAnswerId,
                    SkiiP2MWV524BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV524BooleanAnswerId,
                    SkiiP2MWV525BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV525BooleanAnswerId,
                    SkiiP2MWV526BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV526BooleanAnswerId,
                    SkiiP3MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV521BooleanAnswerId,
                    SkiiP3MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV522BooleanAnswerId,
                    SkiiP3MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV523BooleanAnswerId,
                    SkiiP3MWV524xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId,
                    SkiiP3MWV524yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId,
                    SkiiP3MWV525xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId,
                    SkiiP3MWV525yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId,
                    SkiiP3MWV526xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId,
                    SkiiP3MWV526yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId,
                    SkiiP850KWV520BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV520BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV520BooleanAnswerId,
                    SkiiP850KWV524BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV524BooleanAnswerId,
                    SkiiP850KWV525BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV525BooleanAnswerId,
                    SkiiP850KWV526BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV526BooleanAnswerId,
                    //Modified by Siddharth Chauhan on 24-06-2016.
                    //To resolve Bug : 75527
                    SkiiPClaimRelevantBooleanAnswerId = (CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId,
                    SkiiPNumberofComponents = CIRList.Skiip.SkiiPNumberofComponents
                };

                context.ComponentInspectionReportSkiiP.Add(objCompoSkip);
                context.SaveChanges();
                #region assign value CIR Report Skiip
                if (objCompoSkip.ComponentInspectionReportSkiiPId > 0)
                {
                    if (!ReferenceEquals(CIRList.Skiip.SkiipFailedComp, null) && CIRList.Skiip.SkiipFailedComp.Count > 0)
                        /* Assign value to CIR Report Skiip Failed Compo Entity */
                        foreach (CIR.ComponentInspectionReportSkiiPFailedComponent objCompSkip in CIRList.Skiip.SkiipFailedComp)
                        {
                            Edmx.ComponentInspectionReportSkiiPFailedComponent objCompoSkiipFailed = new Edmx.ComponentInspectionReportSkiiPFailedComponent
                            {
                                ComponentInspectionReportSkiiPFailedComponentId = objCompSkip.ComponentInspectionReportSkiiPFailedComponentId,
                                ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                SkiiPFailedComponentVestasUniqueIdentifier = objCompSkip.SkiiPFailedComponentVestasUniqueIdentifier,
                                SkiiPFailedComponentVestasItemNumber = objCompSkip.SkiiPFailedComponentVestasItemNumber,
                                SkiiPFailedComponentSerialNumber = objCompSkip.SkiiPFailedComponentSerialNumber

                            };
                            context.ComponentInspectionReportSkiiPFailedComponent.Add(objCompoSkiipFailed);

                        }

                    if (!ReferenceEquals(CIRList.Skiip.SkiipNewComp, null) && CIRList.Skiip.SkiipNewComp.Count > 0)
                        /* Skiip New Comp */
                        foreach (CIR.ComponentInspectionReportSkiiPNewComponent objCompSkipNw in CIRList.Skiip.SkiipNewComp)
                        {
                            /* Assign value to CIR Skiip New Comp Entity */
                            Edmx.ComponentInspectionReportSkiiPNewComponent objCompoSkiipNew = new Edmx.ComponentInspectionReportSkiiPNewComponent
                            {
                                ComponentInspectionReportSkiiPNewComponentId = objCompSkipNw.ComponentInspectionReportSkiiPNewComponentId,
                                ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                SkiiPNewComponentVestasUniqueIdentifier = objCompSkipNw.SkiiPNewComponentVestasUniqueIdentifier,
                                SkiiPNewComponentVestasItemNumber = objCompSkipNw.SkiiPNewComponentVestasItemNumber,
                                SkiiPNewComponentSerialNumber = objCompSkipNw.SkiiPNewComponentSerialNumber

                            };
                            context.ComponentInspectionReportSkiiPNewComponent.Add(objCompoSkiipNew);
                        }
                    context.SaveChanges();
                }
                #endregion

            }
            #endregion
            #region assign value to CIR REport Gear
            /* Assign value to CIR Report Blade Gear */
            if (!ReferenceEquals(CIRList.Gearbox, null) && !string.IsNullOrEmpty(CIRList.Gearbox.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportGearbox objCompoGear = new Edmx.ComponentInspectionReportGearbox
                {
                    ComponentInspectionReportGearboxId = CIRList.Gearbox.ComponentInspectionReportGearboxId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Gearbox.VestasUniqueIdentifier,
                    GearboxTypeId = CIRList.Gearbox.GearboxTypeId,
                    GearboxRevisionId = CIRList.Gearbox.GearboxRevisionId,
                    GearboxManufacturerId = CIRList.Gearbox.GearboxManufacturerId,
                    OtherGearboxType = CIRList.Gearbox.OtherGearboxType,
                    GearboxSerialNumber = CIRList.Gearbox.GearboxSerialNumber,
                    GearboxOtherManufacturer = CIRList.Gearbox.GearboxOtherManufacturer,
                    GearboxLastOilChangeDate = ParseDatetime(CIRList.Gearbox.strGearboxLastOilChangeDate),
                    GearboxOilTypeId = CIRList.Gearbox.GearboxOilTypeId,
                    GearboxMechanicalOilPumpId = CIRList.Gearbox.GearboxMechanicalOilPumpId,
                    GearboxOilLevelId = CIRList.Gearbox.GearboxOilLevelId,
                    GearboxRunHours = CIRList.Gearbox.GearboxRunHours,
                    GearboxOilTemperature = CIRList.Gearbox.GearboxOilTemperature,
                    GearboxProduction = CIRList.Gearbox.GearboxProduction,
                    GearboxGeneratorManufacturerId = CIRList.Gearbox.GearboxGeneratorManufacturerId,
                    GearboxGeneratorManufacturerId2 = CIRList.Gearbox.GearboxGeneratorManufacturerId2,
                    GearboxElectricalPumpId = CIRList.Gearbox.GearboxElectricalPumpId,
                    GearboxShrinkElementId = CIRList.Gearbox.GearboxShrinkElementId,
                    GearboxShrinkElementSerialNumber = CIRList.Gearbox.GearboxShrinkElementSerialNumber,
                    GearboxCouplingId = CIRList.Gearbox.GearboxCouplingId,
                    GearboxFilterBlockTypeId = CIRList.Gearbox.GearboxFilterBlockTypeId,
                    GearboxInLineFilterId = CIRList.Gearbox.GearboxInLineFilterId,
                    GearboxOffLineFilterId = CIRList.Gearbox.GearboxOffLineFilterId,
                    GearboxSoftwareRelease = CIRList.Gearbox.GearboxSoftwareRelease,
                    GearboxShaftsExactLocation1ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation1ShaftTypeId,
                    GearboxShaftsExactLocation2ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation2ShaftTypeId,
                    GearboxShaftsExactLocation3ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation3ShaftTypeId,
                    GearboxShaftsExactLocation4ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation4ShaftTypeId,
                    GearboxShaftsTypeofDamage1ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage1ShaftErrorId,
                    GearboxShaftsTypeofDamage2ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage2ShaftErrorId,
                    GearboxShaftsTypeofDamage3ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage3ShaftErrorId,
                    GearboxShaftsTypeofDamage4ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage4ShaftErrorId,
                    GearboxExactLocation1GearTypeId = CIRList.Gearbox.GearboxExactLocation1GearTypeId,
                    GearboxExactLocation2GearTypeId = CIRList.Gearbox.GearboxExactLocation2GearTypeId,
                    GearboxExactLocation3GearTypeId = CIRList.Gearbox.GearboxExactLocation3GearTypeId,
                    GearboxExactLocation4GearTypeId = CIRList.Gearbox.GearboxExactLocation4GearTypeId,
                    GearboxExactLocation5GearTypeId = CIRList.Gearbox.GearboxExactLocation5GearTypeId,
                    GearboxTypeofDamage1GearErrorId = CIRList.Gearbox.GearboxTypeofDamage1GearErrorId,
                    GearboxTypeofDamage2GearErrorId = CIRList.Gearbox.GearboxTypeofDamage2GearErrorId,
                    GearboxTypeofDamage3GearErrorId = CIRList.Gearbox.GearboxTypeofDamage3GearErrorId,
                    GearboxTypeofDamage4GearErrorId = CIRList.Gearbox.GearboxTypeofDamage4GearErrorId,
                    GearboxTypeofDamage5GearErrorId = CIRList.Gearbox.GearboxTypeofDamage5GearErrorId,
                    GearboxBearingsLocation1BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation1BearingTypeId,
                    GearboxBearingsLocation2BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation2BearingTypeId,
                    GearboxBearingsLocation3BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation3BearingTypeId,
                    GearboxBearingsLocation4BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation4BearingTypeId,
                    GearboxBearingsLocation5BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation5BearingTypeId,
                    GearboxBearingsPosition1BearingPosId = CIRList.Gearbox.GearboxBearingsPosition1BearingPosId,
                    GearboxBearingsPosition2BearingPosId = CIRList.Gearbox.GearboxBearingsPosition2BearingPosId,
                    GearboxBearingsPosition3BearingPosId = CIRList.Gearbox.GearboxBearingsPosition3BearingPosId,
                    GearboxBearingsPosition4BearingPosId = CIRList.Gearbox.GearboxBearingsPosition4BearingPosId,
                    GearboxBearingsPosition5BearingPosId = CIRList.Gearbox.GearboxBearingsPosition5BearingPosId,
                    GearboxBearingsDamage1BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage1BearingErrorId,
                    GearboxBearingsDamage2BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage2BearingErrorId,
                    GearboxBearingsDamage3BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage3BearingErrorId,
                    GearboxBearingsDamage4BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage4BearingErrorId,
                    GearboxBearingsDamage5BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage5BearingErrorId,
                    GearboxPlanetStage1HousingErrorId = CIRList.Gearbox.GearboxPlanetStage1HousingErrorId,
                    GearboxPlanetStage2HousingErrorId = CIRList.Gearbox.GearboxPlanetStage2HousingErrorId,
                    GearboxHelicalStageHousingErrorId = CIRList.Gearbox.GearboxHelicalStageHousingErrorId,
                    GearboxFrontPlateHousingErrorId = CIRList.Gearbox.GearboxFrontPlateHousingErrorId,
                    GearboxAuxStageHousingErrorId = CIRList.Gearbox.GearboxAuxStageHousingErrorId,
                    GearboxHSStageHousingErrorId = CIRList.Gearbox.GearboxHSStageHousingErrorId,
                    GearboxLooseBolts = CIRList.Gearbox.GearboxLooseBolts,
                    GearboxBrokenBolts = CIRList.Gearbox.GearboxBrokenBolts,
                    GearboxDefectDamperElements = CIRList.Gearbox.GearboxDefectDamperElements,
                    GearboxTooMuchClearance = CIRList.Gearbox.GearboxTooMuchClearance,
                    GearboxCrackedTorqueArm = CIRList.Gearbox.GearboxCrackedTorqueArm,
                    GearboxNeedsToBeAligned = CIRList.Gearbox.GearboxNeedsToBeAligned,
                    GearboxPT100Bearing1 = CIRList.Gearbox.GearboxPT100Bearing1,
                    GearboxPT100Bearing2 = CIRList.Gearbox.GearboxPT100Bearing2,
                    GearboxPT100Bearing3 = CIRList.Gearbox.GearboxPT100Bearing3,
                    GearboxOilLevelSensor = CIRList.Gearbox.GearboxOilLevelSensor,
                    GearboxOilPressure = CIRList.Gearbox.GearboxOilPressure,
                    GearboxPT100OilSump = CIRList.Gearbox.GearboxPT100OilSump,
                    GearboxFilterIndicator = CIRList.Gearbox.GearboxFilterIndicator,
                    GearboxImmersionHeater = CIRList.Gearbox.GearboxImmersionHeater,
                    GearboxDrainValve = CIRList.Gearbox.GearboxDrainValve,
                    GearboxAirBreather = CIRList.Gearbox.GearboxAirBreather,
                    GearboxSightGlass = CIRList.Gearbox.GearboxSightGlass,
                    GearboxChipDetector = CIRList.Gearbox.GearboxChipDetector,
                    GearboxVibrationsId = CIRList.Gearbox.GearboxVibrationsId,
                    GearboxNoiseId = CIRList.Gearbox.GearboxNoiseId,
                    GearboxDebrisOnMagnetId = CIRList.Gearbox.GearboxDebrisOnMagnetId,
                    GearboxDebrisStagesMagnetPosId = CIRList.Gearbox.GearboxDebrisStagesMagnetPosId,
                    GearboxDebrisGearBoxId = CIRList.Gearbox.GearboxDebrisGearBoxId,
                    GearboxMaxTempResetDate = ParseDatetime(CIRList.Gearbox.GearboxMaxTempResetDate),
                    GearboxTempBearing1 = CIRList.Gearbox.GearboxTempBearing1,
                    GearboxTempBearing2 = CIRList.Gearbox.GearboxTempBearing2,
                    GearboxTempBearing3 = CIRList.Gearbox.GearboxTempBearing3,
                    GearboxTempOilSump = CIRList.Gearbox.GearboxTempOilSump,
                    GearboxLSSNRend = CIRList.Gearbox.GearboxLSSNRend,
                    GearboxIMSNRend = CIRList.Gearbox.GearboxIMSNRend,
                    GearboxIMSRend = CIRList.Gearbox.GearboxIMSRend,
                    GearboxHSSNRend = CIRList.Gearbox.GearboxHSSNRend,
                    GearboxHSSRend = CIRList.Gearbox.GearboxHSSRend,
                    GearboxPitchTube = CIRList.Gearbox.GearboxPitchTube,
                    GearboxSplitLines = CIRList.Gearbox.GearboxSplitLines,
                    GearboxHoseAndPiping = CIRList.Gearbox.GearboxHoseAndPiping,
                    GearboxInputShaft = CIRList.Gearbox.GearboxInputShaft,
                    GearboxHSSPTO = CIRList.Gearbox.GearboxHSSPTO,
                    GearboxClaimRelevantBooleanAnswerId = CIRList.Gearbox.GearboxClaimRelevantBooleanAnswerId,
                    GearboxOverallGearboxConditionId = CIRList.Gearbox.GearboxOverallGearboxConditionId,
                    GearboxExactLocation6GearTypeId = CIRList.Gearbox.GearboxExactLocation6GearTypeId,
                    GearboxExactLocation7GearTypeId = CIRList.Gearbox.GearboxExactLocation7GearTypeId,
                    GearboxExactLocation8GearTypeId = CIRList.Gearbox.GearboxExactLocation8GearTypeId,
                    GearboxExactLocation9GearTypeId = CIRList.Gearbox.GearboxExactLocation9GearTypeId,
                    GearboxExactLocation10GearTypeId = CIRList.Gearbox.GearboxExactLocation10GearTypeId,
                    GearboxExactLocation11GearTypeId = CIRList.Gearbox.GearboxExactLocation11GearTypeId,
                    GearboxExactLocation12GearTypeId = CIRList.Gearbox.GearboxExactLocation12GearTypeId,
                    GearboxExactLocation13GearTypeId = CIRList.Gearbox.GearboxExactLocation13GearTypeId,
                    GearboxExactLocation14GearTypeId = CIRList.Gearbox.GearboxExactLocation14GearTypeId,
                    GearboxExactLocation15GearTypeId = CIRList.Gearbox.GearboxExactLocation15GearTypeId,
                    GearboxTypeofDamage6GearErrorId = CIRList.Gearbox.GearboxTypeofDamage6GearErrorId,
                    GearboxTypeofDamage7GearErrorId = CIRList.Gearbox.GearboxTypeofDamage7GearErrorId,
                    GearboxTypeofDamage8GearErrorId = CIRList.Gearbox.GearboxTypeofDamage8GearErrorId,
                    GearboxTypeofDamage9GearErrorId = CIRList.Gearbox.GearboxTypeofDamage9GearErrorId,
                    GearboxTypeofDamage10GearErrorId = CIRList.Gearbox.GearboxTypeofDamage10GearErrorId,
                    GearboxTypeofDamage11GearErrorId = CIRList.Gearbox.GearboxTypeofDamage11GearErrorId,
                    GearboxTypeofDamage12GearErrorId = CIRList.Gearbox.GearboxTypeofDamage12GearErrorId,
                    GearboxTypeofDamage13GearErrorId = CIRList.Gearbox.GearboxTypeofDamage13GearErrorId,
                    GearboxTypeofDamage14GearErrorId = CIRList.Gearbox.GearboxTypeofDamage14GearErrorId,
                    GearboxTypeofDamage15GearErrorId = CIRList.Gearbox.GearboxTypeofDamage15GearErrorId,
                    GearboxGearDecision1DamageDecisionId = CIRList.Gearbox.GearboxGearDecision1DamageDecisionId,
                    GearboxGearDecision2DamageDecisionId = CIRList.Gearbox.GearboxGearDecision2DamageDecisionId,
                    GearboxGearDecision3DamageDecisionId = CIRList.Gearbox.GearboxGearDecision3DamageDecisionId,
                    GearboxGearDecision4DamageDecisionId = CIRList.Gearbox.GearboxGearDecision4DamageDecisionId,
                    GearboxGearDecision5DamageDecisionId = CIRList.Gearbox.GearboxGearDecision5DamageDecisionId,
                    GearboxGearDecision6DamageDecisionId = CIRList.Gearbox.GearboxGearDecision6DamageDecisionId,
                    GearboxGearDecision7DamageDecisionId = CIRList.Gearbox.GearboxGearDecision7DamageDecisionId,
                    GearboxGearDecision8DamageDecisionId = CIRList.Gearbox.GearboxGearDecision8DamageDecisionId,
                    GearboxGearDecision9DamageDecisionId = CIRList.Gearbox.GearboxGearDecision9DamageDecisionId,
                    GearboxGearDecision10DamageDecisionId = CIRList.Gearbox.GearboxGearDecision10DamageDecisionId,
                    GearboxGearDecision11DamageDecisionId = CIRList.Gearbox.GearboxGearDecision11DamageDecisionId,
                    GearboxGearDecision12DamageDecisionId = CIRList.Gearbox.GearboxGearDecision12DamageDecisionId,
                    GearboxGearDecision13DamageDecisionId = CIRList.Gearbox.GearboxGearDecision13DamageDecisionId,
                    GearboxGearDecision14DamageDecisionId = CIRList.Gearbox.GearboxGearDecision14DamageDecisionId,
                    GearboxGearDecision15DamageDecisionId = CIRList.Gearbox.GearboxGearDecision15DamageDecisionId,
                    GearboxBearingsLocation6BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation6BearingTypeId,
                    GearboxBearingsPosition6BearingPosId = CIRList.Gearbox.GearboxBearingsPosition6BearingPosId,
                    GearboxBearingsDamage6BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage6BearingErrorId,
                    GearboxBearingDecision1DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision1DamageDecisionId,
                    GearboxBearingDecision2DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision2DamageDecisionId,
                    GearboxBearingDecision3DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision3DamageDecisionId,
                    GearboxBearingDecision4DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision4DamageDecisionId,
                    GearboxBearingDecision5DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision5DamageDecisionId,
                    GearboxBearingDecision6DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision6DamageDecisionId,
                    GearboxGearDamageClass1DamageId = CIRList.Gearbox.GearboxGearDamageClass1DamageId,
                    GearboxGearDamageClass2DamageId = CIRList.Gearbox.GearboxGearDamageClass2DamageId,
                    GearboxGearDamageClass3DamageId = CIRList.Gearbox.GearboxGearDamageClass3DamageId,
                    GearboxGearDamageClass4DamageId = CIRList.Gearbox.GearboxGearDamageClass4DamageId,
                    GearboxGearDamageClass5DamageId = CIRList.Gearbox.GearboxGearDamageClass5DamageId,
                    GearboxGearDamageClass6DamageId = CIRList.Gearbox.GearboxGearDamageClass6DamageId,
                    GearboxGearDamageClass7DamageId = CIRList.Gearbox.GearboxGearDamageClass7DamageId,
                    GearboxGearDamageClass8DamageId = CIRList.Gearbox.GearboxGearDamageClass8DamageId,
                    GearboxGearDamageClass9DamageId = CIRList.Gearbox.GearboxGearDamageClass9DamageId,
                    GearboxGearDamageClass10DamageId = CIRList.Gearbox.GearboxGearDamageClass10DamageId,
                    GearboxGearDamageClass11DamageId = CIRList.Gearbox.GearboxGearDamageClass11DamageId,
                    GearboxGearDamageClass12DamageId = CIRList.Gearbox.GearboxGearDamageClass12DamageId,
                    GearboxGearDamageClass13DamageId = CIRList.Gearbox.GearboxGearDamageClass13DamageId,
                    GearboxGearDamageClass14DamageId = CIRList.Gearbox.GearboxGearDamageClass14DamageId,
                    GearboxGearDamageClass15DamageId = CIRList.Gearbox.GearboxGearDamageClass15DamageId,
                    GearboxAuxEquipmentId = CIRList.Gearbox.GearboxAuxEquipmentId,
                    GearboxActionToBeTakenOnGearboxId = CIRList.Gearbox.GearboxActionToBeTakenOnGearboxId,
                    GearboxDefectCategorizationScore = CIRList.Gearbox.GearboxDefectCategorizationScore
                };
                context.ComponentInspectionReportGearbox.Add(objCompoGear);
                context.SaveChanges();
            }
            #endregion
            #region assign value to CIR REport Generator
            /* Assign value to CIR Report Blade Gen */
            if (!ReferenceEquals(CIRList.Generator, null) && !string.IsNullOrEmpty(CIRList.Generator.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportGenerator objCompoGen = new Edmx.ComponentInspectionReportGenerator
                {
                    ComponentInspectionReportGeneratorId = CIRList.Generator.ComponentInspectionReportGeneratorId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Generator.VestasUniqueIdentifier,
                    GeneratorManufacturerId = CIRList.Generator.GeneratorManufacturerId,
                    GeneratorSerialNumber = CIRList.Generator.GeneratorSerialNumber,
                    OtherManufacturer = CIRList.Generator.OtherManufacturer,
                    GeneratorMaxTemperature = CIRList.Generator.GeneratorMaxTemperature,
                    GeneratorMaxTemperatureResetDate = ParseDatetime(CIRList.Generator.strGeneratorMaxTemperatureResetDate),
                    CouplingId = CIRList.Generator.CouplingId,
                    ActionToBeTakenOnGeneratorId = CIRList.Generator.ActionToBeTakenOnGeneratorId,
                    GeneratorDriveEndId = CIRList.Generator.GeneratorDriveEndId,
                    GeneratorNonDriveEndId = CIRList.Generator.GeneratorNonDriveEndId,
                    GeneratorRotorId = CIRList.Generator.GeneratorRotorId,
                    GeneratorCoverId = CIRList.Generator.GeneratorCoverId,
                    AirToAirCoolerInternalId = CIRList.Generator.AirToAirCoolerInternalId,
                    AirToAirCoolerExternalId = CIRList.Generator.AirToAirCoolerExternalId,
                    GeneratorComments = CIRList.Generator.GeneratorComments,
                    UGround = CIRList.Generator.UGround,
                    VGround = CIRList.Generator.VGround,
                    WGround = CIRList.Generator.WGround,
                    UV = CIRList.Generator.UV,
                    UW = CIRList.Generator.UW,
                    VW = CIRList.Generator.VW,
                    KGround = CIRList.Generator.KGround,
                    LGround = CIRList.Generator.LGround,
                    MGround = CIRList.Generator.MGround,
                    UGroundOhmUnitId = CIRList.Generator.UGroundOhmUnitId,
                    VGroundOhmUnitId = CIRList.Generator.VGroundOhmUnitId,
                    WGroundOhmUnitId = CIRList.Generator.WGroundOhmUnitId,
                    UVOhmUnitId = CIRList.Generator.UVOhmUnitId,
                    UWOhmUnitId = CIRList.Generator.UWOhmUnitId,
                    VWOhmUnitId = CIRList.Generator.VWOhmUnitId,
                    KGroundOhmUnitId = CIRList.Generator.KGroundOhmUnitId,
                    LGroundOhmUnitId = CIRList.Generator.LGroundOhmUnitId,
                    MGroundOhmUnitId = CIRList.Generator.MGroundOhmUnitId,
                    U1U2 = CIRList.Generator.U1U2,
                    V1V2 = CIRList.Generator.V1V2,
                    W1W2 = CIRList.Generator.W1W2,
                    K1L1 = CIRList.Generator.K1L1,
                    L1M1 = CIRList.Generator.L1M1,
                    K1M1 = CIRList.Generator.K1M1,
                    K2L2 = CIRList.Generator.K2L2,
                    L2M2 = CIRList.Generator.L2M2,
                    K2M2 = CIRList.Generator.K2M2,
                    GeneratorRewoundLocally = CIRList.Generator.GeneratorRewoundLocally,
                    GeneratorClaimRelevantBooleanAnswerId = CIRList.Generator.GeneratorClaimRelevantBooleanAnswerId,
                    InsulationComments = CIRList.Generator.InsulationComments,
                    GeneratorInsulationComments = CIRList.Generator.GeneratorInsulationComments,
                };
                context.ComponentInspectionReportGenerator.Add(objCompoGen);
                context.SaveChanges();
            }
            #endregion
            #region assign value to CIR REport Transformer
            /* Assign value to CIR Report Blade Trans */
            if (!ReferenceEquals(CIRList.Transformer, null) && !string.IsNullOrEmpty(CIRList.Transformer.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportTransformer objCompoTrans = new Edmx.ComponentInspectionReportTransformer
                {
                    ComponentInspectionReportTransformerId = CIRList.Transformer.ComponentInspectionReportTransformerId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Transformer.VestasUniqueIdentifier,
                    TransformerManufacturerId = CIRList.Transformer.TransformerManufacturerId,
                    TransformerSerialNumber = CIRList.Transformer.TransformerSerialNumber,
                    MaxTemp = CIRList.Transformer.MaxTemp,
                    MaxTempResetDate = ParseDatetime(CIRList.Transformer.strMaxTempResetDate),
                    ActionOnTransformerId = CIRList.Transformer.ActionOnTransformerId,
                    HVCoilConditionId = CIRList.Transformer.HVCoilConditionId,
                    LVCoilConditionId = CIRList.Transformer.LVCoilConditionId,
                    HVCableConditionId = CIRList.Transformer.HVCableConditionId,
                    LVCableConditionId = CIRList.Transformer.LVCableConditionId,
                    BracketsId = CIRList.Transformer.BracketsId,
                    TransformerArcDetectionId = CIRList.Transformer.TransformerArcDetectionId,
                    ClimateId = CIRList.Transformer.ClimateId,
                    SurgeArrestorId = CIRList.Transformer.SurgeArrestorId,
                    ConnectionBarsId = CIRList.Transformer.ConnectionBarsId,
                    Comments = CIRList.Transformer.Comments,
                    TransformerClaimRelevantBooleanAnswerId = CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId,
                };

                context.ComponentInspectionReportTransformer.Add(objCompoTrans);
                context.SaveChanges();
            }
            #endregion
            #region assign value to CIR REport mainBearing
            /* Assign value to CIR Report Blade Trans */
            if (!ReferenceEquals(CIRList.MainBearing, null) && !string.IsNullOrEmpty(CIRList.MainBearing.MainBearingSerialNumber))
            {
                try
                {
                    long? MainBearingManufacturerId = null;
                    if (CIRList.MainBearing.MainBearingManufacturerId == 0)
                        MainBearingManufacturerId = null;
                    else
                        MainBearingManufacturerId = CIRList.MainBearing.MainBearingManufacturerId;

                    Edmx.ComponentInspectionReportMainBearing objCompoMain = new Edmx.ComponentInspectionReportMainBearing()
                    {
                        ComponentInspectionReportMainBearingId = CIRList.MainBearing.ComponentInspectionReportMainBearingId,
                        ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                        VestasUniqueIdentifier = CIRList.MainBearing.VestasUniqueIdentifier,
                        MainBearingLastLubricationDate = ParseDatetime(CIRList.MainBearing.strMainBearingLastLubricationDate),
                        MainBearingManufacturerId = MainBearingManufacturerId,
                        MainBearingTemperature = CIRList.MainBearing.MainBearingTemperature,
                        MainBearingLubricationOilTypeId = CIRList.MainBearing.MainBearingLubricationOilTypeId,
                        MainBearingGrease = CIRList.MainBearing.MainBearingGrease,
                        MainBearingLubricationRunHours = CIRList.MainBearing.MainBearingLubricationRunHours,
                        MainBearingOilTemperature = CIRList.MainBearing.MainBearingOilTemperature,
                        MainBearingTypeId = CIRList.MainBearing.MainBearingTypeId,
                        MainBearingRevision = CIRList.MainBearing.MainBearingRevision,
                        MainBearingErrorLocationId = (CIRList.MainBearing.MainBearingErrorLocationId == 0 || CIRList.MainBearing.MainBearingErrorLocationId == null) ? 3 : CIRList.MainBearing.MainBearingErrorLocationId,
                        MainBearingSerialNumber = CIRList.MainBearing.MainBearingSerialNumber,
                        MainBearingRunHours = CIRList.MainBearing.MainBearingRunHours,
                        MainBearingMechanicalOilPump = CIRList.MainBearing.MainBearingMechanicalOilPump,
                        MainBearingClaimRelevantBooleanAnswerId = CIRList.MainBearing.MainBearingClaimRelevantBooleanAnswerId,
                    };
                    context.ComponentInspectionReportMainBearing.Add(objCompoMain);
                    context.SaveChanges();
                }
                catch (Exception oException)
                {
                    GlobalErrorHandler oGE = new GlobalErrorHandler();
                    oGE.HandleError(oException);
                }

            }            
            #endregion
            #region Dynamic Table
            if (!ReferenceEquals(CIRList.DynamicTableInputs, null) && !string.IsNullOrEmpty(CIRList.DynamicTableInputs.Row1Col1))
            {
                try
                {
                    if (CIRList.ComponentInspectionReportTypeId != 8)
                    {
                        Edmx.DynamicTableInput objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.ComponentInspectionReportId.ToString(),
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                        };
                        context.DynamicTableInput.Add(objDynamicTableInput);
                        context.SaveChanges();
                    }
                    else
                    {
                        Edmx.DynamicTableInput objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.ComponentInspectionReportId.ToString(),
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row11Col1 = CIRList.DynamicTableInputs.Row11Col1,
                            Row12Col1 = CIRList.DynamicTableInputs.Row12Col1,
                            Row13Col1 = CIRList.DynamicTableInputs.Row13Col1,
                            Row14Col1 = CIRList.DynamicTableInputs.Row14Col1,

                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row11Col2 = CIRList.DynamicTableInputs.Row11Col2,
                            Row12Col2 = CIRList.DynamicTableInputs.Row12Col2,
                            Row13Col2 = CIRList.DynamicTableInputs.Row13Col2,
                            Row14Col2 = CIRList.DynamicTableInputs.Row14Col2,

                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row11Col3 = CIRList.DynamicTableInputs.Row11Col3,
                            Row12Col3 = CIRList.DynamicTableInputs.Row12Col3,
                            Row13Col3 = CIRList.DynamicTableInputs.Row13Col3,
                            Row14Col3 = CIRList.DynamicTableInputs.Row14Col3,

                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row11Col4 = CIRList.DynamicTableInputs.Row11Col4,
                            Row12Col4 = CIRList.DynamicTableInputs.Row12Col4,
                            Row13Col4 = CIRList.DynamicTableInputs.Row13Col4,
                            Row14Col4 = CIRList.DynamicTableInputs.Row14Col4,

                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row11Col5 = CIRList.DynamicTableInputs.Row11Col5,
                            Row12Col5 = CIRList.DynamicTableInputs.Row12Col5,
                            Row13Col5 = CIRList.DynamicTableInputs.Row13Col5,
                            Row14Col5 = CIRList.DynamicTableInputs.Row14Col5,

                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                            Row11Col6 = CIRList.DynamicTableInputs.Row11Col6,
                            Row12Col6 = CIRList.DynamicTableInputs.Row12Col6,
                            Row13Col6 = CIRList.DynamicTableInputs.Row13Col6,
                            Row14Col6 = CIRList.DynamicTableInputs.Row14Col6,
                        };
                        context.DynamicTableInput.Add(objDynamicTableInput);
                        context.SaveChanges();
                        //Add dyanamicdecision data
                        if (CIRList.DyanamicDecisionData != null)
                        {
                            foreach (DyanamicDecision obj in CIRList.DyanamicDecisionData)
                            {
                                context.DynamicDecisionDetails.Add(new Edmx.DynamicDecisionDetails { AffectedBolts = obj.AffectedBolts, CirId = CIRList.ComponentInspectionReportId, Decision = obj.Decision, FlangNo = obj.FlangNo, ImidiateActions = obj.ImidiateActions, IsDeleted = false, RepeatedInspections = obj.RepeatedInspections, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, FlangeDamageIdentified = obj.FlangeDamageIdentified, InspectionDesc = obj.InspectionDesc });
                            }
                            context.SaveChanges();
                        }

                    }
                }
                catch (Exception oException)
                {
                    GlobalErrorHandler oGE = new GlobalErrorHandler();
                    oGE.HandleError(oException);
                }

            }
            #endregion

            DACIRLog.SaveCirLog(objCirData.CirDataId, "Initial Process started", LogType.Information, objCirData.ModifiedBy);
            #region                                                           
            //Send Mail 
            try
            {
                if (CIRList.ComponentInspectionReportId < hdnCirId)
                {
                    DASendCIRUpdateNotification das = new DASendCIRUpdateNotification();
                    das.SendMail(objCompo.ComponentInspectionReportId, cirname, CIRList.CurrentUser, 1);
                    DACIRLog.SaveCirLog(objCirData.CirDataId, "Create CIR Notification sent to the User", LogType.Information, objCirData.ModifiedBy);
                }
            }
            catch (Exception oException)
            {
                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Email after inserting new CIR " + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                //DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send First Notification sent to Manufacturer due to Error ", LogType.Information, objCirData.ModifiedBy);
            }


            //Notification GENERATOR = 4, GEARBOX = 2, BLADE = 1,TRANSFORMER = 5 AND ReportType is of Type = FAILURE
            List<long> NotificationFor = new List<long> { 1, 2, 4, 5 };
            //if ((NotificationFor.Contains(CIRList.ComponentInspectionReportTypeId) && CIRList.ReportTypeId == 2) &&
            //    (CIRList.ComponentInspectionReportTypeId != 2 || CIRList.Gearbox == null) && CIRList.Gearbox.GearboxAuxEquipmentId == 1)
            if (CIRList.ComponentInspectionReportId < hdnCirId && NotificationFor.Contains(CIRList.ComponentInspectionReportTypeId) && CIRList.ReportTypeId == 2 && ((CIRList.ComponentInspectionReportTypeId == 2 && CIRList.Gearbox != null && CIRList.Gearbox.GearboxAuxEquipmentId == 1)
                || (CIRList.ComponentInspectionReportTypeId == 5 && CIRList.Transformer != null && CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId == 1)
            || (CIRList.ComponentInspectionReportTypeId == 4 && CIRList.Generator != null && CIRList.MountedOnMainComponentBooleanAnswerId == 1) ||
            (CIRList.ComponentInspectionReportTypeId == 1 && CIRList.BladeData != null && CIRList.MountedOnMainComponentBooleanAnswerId == 1)))
            {
                try
                {
                    DANotification da = new DANotification();
                    da.SendNotification(DANotification.NotificationType.FirstNotification, CIRList.CirDataID);
                    FirstNotificationData firstNotificationData = da.FirstNotifications(CIRList.CirDataID, CIRList.ComponentInspectionReportId);
                    da.SendNotifications(firstNotificationData);
                    DACIRLog.SaveCirLog(objCirData.CirDataId, "First Notification sent to Manufacturer", LogType.Information, objCirData.ModifiedBy);
                }
                catch (Exception oException)
                {

                    string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                    string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending First Notification after inserting new CIR [CIRID = " + CIRList.ComponentInspectionReportId + "]" + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                    // DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send First Notification sent to Manufacturer due to Error ", LogType.Information, objCirData.ModifiedBy);
                }
            }
            DACIRLog.SaveCirLog(objCirData.CirDataId, "Initial Process Completed", LogType.Information, objCirData.ModifiedBy);
            #endregion
            return CirID;
        }

        /// <summary>
        /// Update CirData
        /// </summary>
        /// <param name="CIRListUp"></param>
        /// <param name="CIRList"></param>
        protected static long UpdateCIRData(Edmx.ComponentInspectionReport CIRListUp, CIR.ComponentInspectionReport CIRList, CIM_CIREntities context, CIR.TurbineProperties objTurboneType, out long CirDataId)
        {
            #region CIR Com Report
            var cirname = getCirName(objTurboneType.Site, CIRList.ComponentInspectionReportTypeId, CIRList.TurbineNumber.ToString(), CIRList.CIMCaseNumber.ToString());

            Edmx.CirData objCirData = context.CirData.Where(x => x.CirId == CIRList.ComponentInspectionReportId && x.Deleted == false).FirstOrDefault();
            string createdBy = objCirData.CreatedBy;
            if (!ReferenceEquals(objCirData, null))
            {
                objCirData.Modified = DateTime.UtcNow;
                objCirData.ModifiedBy = CIRList.CurrentUser;
                objCirData.Locked = null;
                objCirData.LockedBy = string.Empty;
                // objCirData.Filename = objTurboneType.Country + "_" + Enum.GetName(typeof(ComponentType), CIRList.ComponentInspectionReportTypeId) + "_" + objTurboneType.Turbine + "_" + CIRList.strInspectionDate + "_" + CIRList.CIMCaseNumber;
                objCirData.Deleted = true;
            }

            Edmx.CirData objnewCirData = new Edmx.CirData
            {
                TemplateVersion = CIRList.TemplateVersion,
                CirDataId = 0,
                CirId = CIRList.ComponentInspectionReportId,
                Filename = cirname,
                State = (objCirData.State == 1 || objCirData.State == 3) ? (byte)1 : objCirData.State,
                Progress = (objCirData.State == 1 || objCirData.State == 3) ? (byte)1 : objCirData.Progress,
                // Email = CIRList.ServiceEngineer + "@vestas.com",
                Email = CIRList.CurrentUser + "@vestas.com",
                Created = DateTime.UtcNow,
                CreatedBy = createdBy,
                Modified = DateTime.UtcNow,
                ModifiedBy = CIRList.CurrentUser,
                Deleted = false,
                Guid = System.Guid.NewGuid().ToString()
            };
            context.CirData.Add(objnewCirData);
            context.SaveChanges();

            /* Assign value to CIR Report Entity */
            CIRListUp.ComponentInspectionReportId = CIRList.ComponentInspectionReportId;
            CIRListUp.ComponentInspectionReportTypeId = CIRList.ComponentInspectionReportTypeId;
            CIRListUp.ComponentInspectionReportStateId = CIRList.ComponentInspectionReportStateId;
            CIRListUp.ReportTypeId = CIRList.ReportTypeId;
            CIRListUp.ReconstructionBooleanAnswerId = CIRList.ReconstructionBooleanAnswerId;
            CIRListUp.CIMCaseNumber = CIRList.CIMCaseNumber;
            CIRListUp.ReasonForService = CIRList.ReasonForService;
            CIRListUp.TurbineNumber = CIRList.TurbineNumber;
            CIRListUp.CountryISOId = objTurboneType.CountryIsoId;
            CIRListUp.SiteName = objTurboneType.Site;
            CIRListUp.TurbineMatrixId = null;
            CIRListUp.LocationTypeId = CIRList.LocationTypeId;
            CIRListUp.LocalTurbineId = objTurboneType.LocalTurbineId;
            CIRListUp.SecondGeneratorBooleanAnswerId = CIRList.SecondGeneratorBooleanAnswerId;
            CIRListUp.BeforeInspectionTurbineRunStatusId = CIRList.BeforeInspectionTurbineRunStatusId;

            //ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", CIRList.strCommisioningDate + " TT " + CIRList.strInstallationDate + " TT " + CIRList.strFailureDate + "  TT " + CIRList.strInspectionDate, LogType.Information, "");
            CIRListUp.CommisioningDate = ParseDatetime(CIRList.strCommisioningDate);
            CIRListUp.InstallationDate = ParseDatetime(CIRList.strInstallationDate);
            CIRListUp.FailureDate = ParseFailureDatetime(CIRList.strFailureDate, CIRList.ReportTypeId);
            CIRListUp.InspectionDate = ParseDatetime(CIRList.strInspectionDate);

            CIRListUp.ServiceReportNumber = CIRList.ServiceReportNumber;
            CIRListUp.ServiceReportNumberTypeId = CIRList.ServiceReportNumberTypeId;
            CIRListUp.ServiceEngineer = CIRList.ServiceEngineer;
            CIRListUp.RunHours = CIRList.RunHours;
            CIRListUp.Generator1Hrs = CIRList.Generator1Hrs;
            CIRListUp.Generator2Hrs = CIRList.Generator2Hrs;
            CIRListUp.TotalProduction = CIRList.TotalProduction;
            CIRListUp.AfterInspectionTurbineRunStatusId = CIRList.AfterInspectionTurbineRunStatusId;
            CIRListUp.Quantity = CIRList.Quantity;
            CIRListUp.AlarmLogNumber = CIRList.AlarmLogNumber;
            CIRListUp.Description = CIRList.Description;
            CIRListUp.DescriptionConsquential = CIRList.DescriptionConsquential;
            CIRListUp.ConductedBy = CIRList.ConductedBy;
            CIRListUp.SBUId = CIRList.SBUId;
            CIRListUp.CIRTemplateGUID = objnewCirData.Guid;// CIRList.CIRTemplateGUID;
            CIRListUp.VestasItemNumber = CIRList.VestasItemNumber;
            CIRListUp.NotificationNumber = CIRList.NotificationNumber;
            CIRListUp.MountedOnMainComponentBooleanAnswerId = CIRList.MountedOnMainComponentBooleanAnswerId;
            CIRListUp.ComponentUpTowerSolutionID = CIRList.ComponentUpTowerSolutionID;
            CIRListUp.ComponentInspectionReportName = cirname;
            CIRListUp.AdditionalInfo = CIRList.AdditionalComments;
            CIRListUp.InternalComments = CIRList.InternalComments;
            CIRListUp.SBURecommendation = CIRList.SBURecomendation;
            CIRListUp.OutSideSign = CIRList.OutSideSign;
            CIRListUp.FlangDescription = CIRList.FlangDesc;
            CIRListUp.FormIOGUID = CIRList.FormIOGUID;
            CIRListUp.Brand = string.IsNullOrEmpty(CIRList.Brand) || CIRList.Brand.ToLower() == "vestas_windams" ? "Vestas" : CIRList.Brand;
            // CIRListUp.ComponentInspectionReportVersion = CIRList.ComponentInspectionReportVersion;
            context.ComponentInspectionReport.Attach(CIRListUp);
            context.Entry(CIRListUp).State = System.Data.EntityState.Modified;
            #endregion
            context.SaveChanges();
            CIRList.CirDataID = objnewCirData.CirDataId;
            //CirDataId = objCirData.CirDataId;
            CirDataId = objnewCirData.CirDataId;

            Edmx.CirJson objCirXml = new CirJson
            {
                CirDataId = objnewCirData.CirDataId,
                JSON = Newtonsoft.Json.JsonConvert.SerializeObject(CIRList),
                CirJsonId = 0
            };
            context.CirJson.Add(objCirXml);
            context.SaveChanges();

            Edmx.CIRMigrationLog objCirMigrationLog = context.CIRMigrationLog.Where(x => x.CirDataId == objCirData.CirDataId).FirstOrDefault();
            if (!ReferenceEquals(objCirMigrationLog, null))
            {
                objCirMigrationLog.IsCorrected = true;
                context.SaveChanges();
            }

            DACIRLog.SaveCirLog(objCirData.CirDataId, "CIR Updated", LogType.Information, objCirData.ModifiedBy);
            // DACIRLog.SaveCirLog(objCirData.CirDataId, "CIR Created with CID ID " + CIRList.ComponentInspectionReportId.ToString(), LogType.Information, objCirData.ModifiedBy);

            //   SaveCIRPdfWithContext(context,objCirData.Guid, objCirData.State, CIRList.HtmlStr, objCirData.Filename);


            #region ImageData
            long hdnCirId = Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["hdnCirId"]);
            if (CIRList.ComponentInspectionReportId < hdnCirId && CIRList.ImageData != null)
            {
                for (int i = 0; i < CIRList.ImageData.Count; i++)
                {
                    string imageURI = "";
                    if (CIRList.ImageData[i].ImageUrl != null && !CIRList.ImageData[i].ImageUrl.Contains("https://servicesprod.inspectools.net"))
                    {
                        imageURI = DABir.GetByImageUrl(CIRList.ImageData[i].ImageDataString, "Img");
                    }
                    else if (CIRList.ImageData[i].ImageDataString != null && CIRList.ImageData[i].ImageDataString.Contains("https://"))
                    {
                        imageURI = CIRList.ImageData[i].ImageDataString;
                    }
                    else
                    {
                        continue;
                    }
                    WebClient client = new WebClient();
                    string dataString = client.DownloadString(imageURI);
                    CIRList.ImageData[i].ImageDataString = "data:image/jpeg;base64," + dataString;
                }
            }

            if (CIRList.ImageData == null)
                CIRList.ImageData = new List<CIR.ImageData>();

            Edmx.ImageDataInfo idinfo = context.ImageDataInfo.Where(z => z.ComponentInspectionReportId == CIRList.ComponentInspectionReportId).FirstOrDefault();
            if (idinfo != null && CIRList.ImageDataInfo != null)
            {
                idinfo.IsPlateTypeNotPossible = CIRList.ImageDataInfo.IsPlateTypeNotPossible;
                idinfo.PlateTypeNotPossibleReason = CIRList.ImageDataInfo.PlateTypeNotPossibleReason;
            }
            if (CIRList.ImageDataInfo != null)
            {
                if (!CIRList.ImageDataInfo.IsPlateTypeNotPossible)
                {
                    if (CIRList.ImageData.Count > 0 && !CIRList.ImageData[0].IsNewImageControl)
                    {
                        CIRList.ImageData[0].IsPlateType = true;
                    }
                }
                else
                {
                    if (CIRList.ImageData.Count > 0 && !CIRList.ImageData[0].IsNewImageControl)
                    { CIRList.ImageData[0].IsPlateType = false; }

                }
                if (idinfo == null)
                    context.ImageDataInfo.Add(new Edmx.ImageDataInfo { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, IsPlateTypeNotPossible = CIRList.ImageDataInfo.IsPlateTypeNotPossible, PlateTypeNotPossibleReason = CIRList.ImageDataInfo.PlateTypeNotPossibleReason });
            }
            else
            {
                if (CIRList.ImageData.Count > 0 && !CIRList.ImageData[0].IsNewImageControl)
                    //if (CIRList.ImageData.Count > 0)
                    CIRList.ImageData[0].IsPlateType = true;
                if (idinfo == null)
                    context.ImageDataInfo.Add(new Edmx.ImageDataInfo { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, IsPlateTypeNotPossible = false, PlateTypeNotPossibleReason = "" });

            }
            //remove
            var ImageDataList = CIRList.ImageData.Where(i => i.ImageId > 0);
            var imgids = ImageDataList.Select(i => i.ImageId).ToList<Int32>();
            foreach (Edmx.ImageData id in context.ImageData.Where(i => i.ComponentInspectionReportId == CIRList.ComponentInspectionReportId).Where(i => !imgids.Contains(i.ImageId)))
            {
                context.ImageData.Remove(id);
            }
            //update
            foreach (Edmx.ImageData id in context.ImageData.Where(i => i.ComponentInspectionReportId == CIRList.ComponentInspectionReportId).Where(i => imgids.Contains(i.ImageId)))
            {
                var i = ImageDataList.Where(im => im.ImageId == id.ImageId).FirstOrDefault();
                id.ImageDataString = i.ImageDataString;
                id.ImageDescription = i.ImageDescription;
                id.ImageOrder = i.ImageOrder;
                id.InspectionDesc = i.InspectionDesc;
                id.IsPlateType = i.IsPlateType;
                id.FlangNo = i.FlangNo;
                id.ImageUrl = i.ImageUrl;
                id.FormIOImageGUID = i.FormIOImageGUID;
            }
            //add
            foreach (Cir.Sync.Services.CIR.ImageData ID in CIRList.ImageData.Where(im => im.ImageId == 0))
            {
                if (ID.IsPlateType != true)
                {
                    ID.ImageOrder = ID.ImageOrder++;
                }
                context.ImageData.Add(new Edmx.ImageData { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, ImageDataString = ID.ImageDataString, ImageDescription = ID.ImageDescription, ImageOrder = ID.ImageOrder, InspectionDesc = ID.InspectionDesc, IsPlateType = ID.IsPlateType, FlangNo = ID.FlangNo, ImageUrl = ID.ImageUrl, FormIOImageGUID = ID.FormIOImageGUID });
                //context.ImageData.Add(new Edmx.ImageData { ComponentInspectionReportId = CIRList.ComponentInspectionReportId, ImageDataString = ID.ImageDataString, ImageDescription = ID.ImageDescription, ImageOrder = ID.ImageOrder, InspectionDesc = ID.InspectionDesc, IsPlateType = ID.IsPlateType });
            }
            context.SaveChanges();

            CIRList.ImageData = null;
            #endregion

            #region Component Inspection Report General
            /* Assign value to CIR Report Blade Entity */
            if (!ReferenceEquals(CIRList.General, null) && CIRList.ComponentInspectionReportTypeId == 3)
            {
                Edmx.ComponentInspectionReportGeneral objCompGeneral = CIRListUp.ComponentInspectionReportGeneral.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompGeneral, null))
                {
                    objCompGeneral.ComponentInspectionReportId = CIRList.ComponentInspectionReportId;
                    objCompGeneral.GeneralComponentGroupId = CIRList.General.GeneralComponentGroupId;
                    objCompGeneral.GeneralComponentType = CIRList.General.GeneralComponentType;
                    objCompGeneral.VestasUniqueIdentifier = CIRList.General.VestasUniqueIdentifier;
                    objCompGeneral.GeneralComponentManufacturer = CIRList.General.GeneralComponentManufacturer;
                    objCompGeneral.GeneralOtherGearboxType = CIRList.General.GeneralOtherGearboxType;
                    objCompGeneral.GeneralClaimRelevantBooleanAnswerId = CIRList.General.GeneralClaimRelevantBooleanAnswerId;
                    objCompGeneral.GeneralOtherGearboxManufacturer = CIRList.General.GeneralOtherGearboxManufacturer;
                    objCompGeneral.GeneralComponentSerialNumber = CIRList.General.GeneralComponentSerialNumber;
                    objCompGeneral.GeneralGeneratorManufacturerId = CIRList.General.GeneralGeneratorManufacturerId;
                    objCompGeneral.GeneralTransformerManufacturerId = CIRList.General.GeneralTransformerManufacturerId;
                    objCompGeneral.GeneralGearboxManufacturerId = CIRList.General.GeneralGearboxManufacturerId;
                    objCompGeneral.GeneralTowerTypeId = CIRList.General.GeneralTowerTypeId;
                    objCompGeneral.GeneralTowerHeightId = CIRList.General.GeneralTowerHeightId;
                    objCompGeneral.GeneralBlade1SerialNumber = CIRList.General.GeneralBlade1SerialNumber;
                    objCompGeneral.GeneralBlade2SerialNumber = CIRList.General.GeneralBlade2SerialNumber;
                    objCompGeneral.GeneralBlade3SerialNumber = CIRList.General.GeneralBlade3SerialNumber;
                    objCompGeneral.GeneralControllerTypeId = CIRList.General.GeneralControllerTypeId;
                    objCompGeneral.GeneralSoftwareRelease = CIRList.General.GeneralSoftwareRelease;
                    objCompGeneral.GeneralRamDumpNumber = CIRList.General.GeneralRamDumpNumber;
                    objCompGeneral.GeneralVDFTrackNumber = CIRList.General.GeneralVDFTrackNumber;
                    objCompGeneral.GeneralPicturesIncludedBooleanAnswerId = (CIRList.General.GeneralPicturesIncludedBooleanAnswerId == 0) ? 1 : CIRList.General.GeneralPicturesIncludedBooleanAnswerId;
                    objCompGeneral.GeneralInitiatedBy1 = CIRList.General.GeneralInitiatedBy1;
                    objCompGeneral.GeneralInitiatedBy2 = CIRList.General.GeneralInitiatedBy2;
                    objCompGeneral.GeneralInitiatedBy3 = CIRList.General.GeneralInitiatedBy3;
                    objCompGeneral.GeneralInitiatedBy4 = CIRList.General.GeneralInitiatedBy4;
                    objCompGeneral.GeneralMeasurementsConducted1 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted2 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted3 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted4 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralExecutedBy1 = CIRList.General.GeneralExecutedBy1;
                    objCompGeneral.GeneralExecutedBy2 = CIRList.General.GeneralExecutedBy2;
                    objCompGeneral.GeneralExecutedBy3 = CIRList.General.GeneralExecutedBy3;
                    objCompGeneral.GeneralExecutedBy4 = CIRList.General.GeneralExecutedBy4;
                    objCompGeneral.GeneralPositionOfFailedItem = CIRList.General.GeneralPositionOfFailedItem;
                    context.ComponentInspectionReportGeneral.Attach(objCompGeneral);
                    context.Entry(objCompGeneral).State = System.Data.EntityState.Modified;
                }
                context.SaveChanges();
            }

            #endregion
            #region Component Inspection Report Blade
            /* Assign value to CIR Report Blade Entity */
            if (!ReferenceEquals(CIRList.BladeData, null) && !string.IsNullOrEmpty(CIRList.BladeData.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportBlade objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompBlade, null))
                {
                    objCompBlade.VestasUniqueIdentifier = CIRList.BladeData.VestasUniqueIdentifier;
                    objCompBlade.BladeLengthId = CIRList.BladeData.BladeLengthId;
                    objCompBlade.BladeColorId = CIRList.BladeData.BladeColorId;
                    objCompBlade.BladeSerialNumber = CIRList.BladeData.BladeSerialNumber;
                    objCompBlade.BladePicturesIncludedBooleanAnswerId = CIRList.BladeData.BladePicturesIncludedBooleanAnswerId;
                    objCompBlade.BladeOtherSerialNumber1 = CIRList.BladeData.BladeOtherSerialNumber1;
                    objCompBlade.BladeOtherSerialNumber2 = CIRList.BladeData.BladeOtherSerialNumber2;
                    objCompBlade.BladeDamageIdentified = CIRList.BladeData.BladeDamageIdentified;
                    objCompBlade.BladeFaultCodeClassificationId = CIRList.BladeData.BladeFaultCodeClassificationId;
                    objCompBlade.BladeFaultCodeCauseId = CIRList.BladeData.BladeFaultCodeCauseId;
                    objCompBlade.BladeFaultCodeTypeId = CIRList.BladeData.BladeFaultCodeTypeId;
                    objCompBlade.BladeFaultCodeAreaId = CIRList.BladeData.BladeFaultCodeAreaId;
                    objCompBlade.BladeClaimRelevantBooleanAnswerId = CIRList.BladeData.BladeClaimRelevantBooleanAnswerId;
                    objCompBlade.BladeLsVtNumber = CIRList.BladeData.BladeLsVtNumber;
                    objCompBlade.BladeLsCalibrationDate = ParseDatetime(CIRList.BladeData.BladeLsCalibrationDate);
                    objCompBlade.BladeLsLeewardSidePreRepairTip = CIRList.BladeData.BladeLsLeewardSidePreRepairTip;
                    objCompBlade.BladeLsLeewardSidePostRepairTip = CIRList.BladeData.BladeLsLeewardSidePostRepairTip;
                    objCompBlade.BladeLsLeewardSidePreRepair2 = CIRList.BladeData.BladeLsLeewardSidePreRepair2;
                    objCompBlade.BladeLsLeewardSidePostRepair2 = CIRList.BladeData.BladeLsLeewardSidePostRepair2;
                    objCompBlade.BladeLsLeewardSidePreRepair3 = CIRList.BladeData.BladeLsLeewardSidePreRepair3;
                    objCompBlade.BladeLsLeewardSidePostRepair3 = CIRList.BladeData.BladeLsLeewardSidePostRepair3;
                    objCompBlade.BladeLsLeewardSidePreRepair4 = CIRList.BladeData.BladeLsLeewardSidePreRepair4;
                    objCompBlade.BladeLsLeewardSidePostRepair4 = CIRList.BladeData.BladeLsLeewardSidePostRepair4;
                    objCompBlade.BladeLsLeewardSidePreRepair5 = CIRList.BladeData.BladeLsLeewardSidePreRepair5;
                    objCompBlade.BladeLsLeewardSidePostRepair5 = CIRList.BladeData.BladeLsLeewardSidePostRepair5;
                    objCompBlade.BladeLsLeewardSidePreRepair6 = CIRList.BladeData.BladeLsLeewardSidePreRepair6;
                    objCompBlade.BladeLsLeewardSidePostRepair6 = CIRList.BladeData.BladeLsLeewardSidePostRepair6;
                    objCompBlade.BladeLsLeewardSidePreRepair7 = CIRList.BladeData.BladeLsLeewardSidePreRepair7;
                    objCompBlade.BladeLsLeewardSidePostRepair7 = CIRList.BladeData.BladeLsLeewardSidePostRepair7;
                    objCompBlade.BladeLsLeewardSidePreRepair8 = CIRList.BladeData.BladeLsLeewardSidePreRepair8;
                    objCompBlade.BladeLsLeewardSidePostRepair8 = CIRList.BladeData.BladeLsLeewardSidePostRepair8;
                    objCompBlade.BladeLsWindwardSidePreRepairTip = CIRList.BladeData.BladeLsWindwardSidePreRepairTip;
                    objCompBlade.BladeLsWindwardSidePostRepairTip = CIRList.BladeData.BladeLsWindwardSidePostRepairTip;
                    objCompBlade.BladeLsWindwardSidePreRepair2 = CIRList.BladeData.BladeLsWindwardSidePreRepair2;
                    objCompBlade.BladeLsWindwardSidePostRepair2 = CIRList.BladeData.BladeLsWindwardSidePostRepair2;
                    objCompBlade.BladeLsWindwardSidePreRepair3 = CIRList.BladeData.BladeLsWindwardSidePreRepair3;
                    objCompBlade.BladeLsWindwardSidePostRepair3 = CIRList.BladeData.BladeLsWindwardSidePostRepair3;
                    objCompBlade.BladeLsWindwardSidePreRepair4 = CIRList.BladeData.BladeLsWindwardSidePreRepair4;
                    objCompBlade.BladeLsWindwardSidePostRepair4 = CIRList.BladeData.BladeLsWindwardSidePostRepair4;
                    objCompBlade.BladeLsWindwardSidePreRepair5 = CIRList.BladeData.BladeLsWindwardSidePreRepair5;
                    objCompBlade.BladeLsWindwardSidePostRepair5 = CIRList.BladeData.BladeLsWindwardSidePostRepair5;
                    objCompBlade.BladeLsWindwardSidePreRepair6 = CIRList.BladeData.BladeLsWindwardSidePreRepair6;
                    objCompBlade.BladeLsWindwardSidePostRepair6 = CIRList.BladeData.BladeLsWindwardSidePostRepair6;
                    objCompBlade.BladeLsWindwardSidePreRepair7 = CIRList.BladeData.BladeLsWindwardSidePreRepair7;
                    objCompBlade.BladeLsWindwardSidePostRepair7 = CIRList.BladeData.BladeLsWindwardSidePostRepair7;
                    objCompBlade.BladeLsWindwardSidePreRepair8 = CIRList.BladeData.BladeLsWindwardSidePreRepair8;
                    objCompBlade.BladeLsWindwardSidePostRepair8 = CIRList.BladeData.BladeLsWindwardSidePostRepair8;
                    objCompBlade.BladeInspectionReportDescription = CIRList.BladeData.BladeInspectionReportDescription;
                    objCompBlade.BladeManufacturerId = CIRList.BladeData.BladeManufacturerId;
                    context.ComponentInspectionReportBlade.Attach(objCompBlade);
                    context.Entry(objCompBlade).State = System.Data.EntityState.Modified;
                }
                context.SaveChanges();
            }
            #endregion
            #region Component Inspection Report Blade Damage
            /* Assign value to CIR Report Blade Damage Entity */
            if (!ReferenceEquals(CIRList.BladeData, null))
            {
                if (!ReferenceEquals(CIRList.BladeData.DamageData, null) && CIRList.BladeData.DamageData.Count > 0)
                {
                    Edmx.ComponentInspectionReportBlade objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();

                    var BladeDamageData = context.ComponentInspectionReportBladeDamage.Where(x => x.ComponentInspectionReportBladeId == objCompBlade.ComponentInspectionReportBladeId).ToList();
                    foreach (Edmx.ComponentInspectionReportBladeDamage bd in BladeDamageData)
                    {
                        context.ComponentInspectionReportBladeDamage.Remove(bd);
                    }
                    context.SaveChanges();
                    foreach (CIR.ComponentInspectionReportBladeDamage objBladeDam in CIRList.BladeData.DamageData)
                    {

                        Edmx.ComponentInspectionReportBladeDamage objCompoBladeDam = new Edmx.ComponentInspectionReportBladeDamage
                        {
                            // ComponentInspectionReportBladeDamageId = objBladeDam.ComponentInspectionReportBladeDamageId,
                            ComponentInspectionReportBladeId = objCompBlade.ComponentInspectionReportBladeId,
                            BladeDamagePlacementId = objBladeDam.BladeDamagePlacementId,
                            BladeInspectionDataId = objBladeDam.BladeInspectionDataId,
                            BladeRadius = objBladeDam.BladeRadius,
                            BladeEdgeId = objBladeDam.BladeEdgeId,
                            BladeDescription = objBladeDam.BladeDescription,
                            BladePictureNumber = objBladeDam.BladePictureNumber,
                            PictureOrder = null,
                            DamageSeverity = objBladeDam.DamageSeverity,
                            FormIOImageGUID = objBladeDam.FormIOImageGUID
                        };
                        context.ComponentInspectionReportBladeDamage.Add(objCompoBladeDam);
                    }
                    context.SaveChanges();
                }
            }



            #endregion
            #region Blade repair record
            if ((!ReferenceEquals(CIRList.BladeData, null)) && CIRList.BladeData.RepairRecordData != null && (CIRList.ReportTypeId == 3 || CIRList.ReportTypeId == 5))
            {
                Cir.Sync.Services.CIR.ComponentInspectionReportBladeRepairRecord BladeRepairRecordList = CIRList.BladeData.RepairRecordData;
                Edmx.ComponentInspectionReportBlade objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                Edmx.ComponentInspectionReportBladeRepairRecord objCompBladeRepairRecord = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault().ComponentInspectionReportBladeRepairRecord.FirstOrDefault();
                if (!ReferenceEquals(objCompBladeRepairRecord, null))
                {
                    objCompBladeRepairRecord.ComponentInspectionReportBladeId = objCompBlade.ComponentInspectionReportBladeId;
                    objCompBladeRepairRecord.BladeAmbientTemp = BladeRepairRecordList.BladeAmbientTemp;
                    objCompBladeRepairRecord.BladeHumidity = BladeRepairRecordList.BladeHumidity;
                    objCompBladeRepairRecord.BladeAdditionalDocumentReference = BladeRepairRecordList.BladeAdditionalDocumentReference;
                    objCompBladeRepairRecord.BladeResinType = BladeRepairRecordList.BladeResinType;
                    objCompBladeRepairRecord.BladeResinTypeBatchNumbers = BladeRepairRecordList.BladeResinTypeBatchNumbers;
                    objCompBladeRepairRecord.BladeResinTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeResinTypeExpiryDate);
                    objCompBladeRepairRecord.BladeHardenerType = BladeRepairRecordList.BladeHardenerType;
                    objCompBladeRepairRecord.BladeHardenerTypeBatchNumbers = BladeRepairRecordList.BladeHardenerTypeBatchNumbers;
                    objCompBladeRepairRecord.BladeHardenerTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeHardenerTypeExpiryDate);
                    objCompBladeRepairRecord.BladeGlassSupplier = BladeRepairRecordList.BladeGlassSupplier;
                    objCompBladeRepairRecord.BladeGlassSupplierBatchNumbers = BladeRepairRecordList.BladeGlassSupplierBatchNumbers;
                    objCompBladeRepairRecord.BladeSurfaceMaxTemperature = BladeRepairRecordList.BladeSurfaceMaxTemperature;
                    objCompBladeRepairRecord.BladeSurfaceMinTemperature = BladeRepairRecordList.BladeSurfaceMinTemperature;
                    objCompBladeRepairRecord.BladeResinUsed = BladeRepairRecordList.BladeResinUsed;
                    objCompBladeRepairRecord.BladePostCureMaxTemperature = BladeRepairRecordList.BladePostCureMaxTemperature;
                    objCompBladeRepairRecord.BladePostCureMinTemperature = BladeRepairRecordList.BladePostCureMinTemperature;
                    objCompBladeRepairRecord.BladeTurnOffTime = ParseDatetime(BladeRepairRecordList.strBladeTurnOffTime);
                    objCompBladeRepairRecord.BladeTotalCureTime = BladeRepairRecordList.BladeTotalCureTime;
                }
                else
                {

                    Edmx.ComponentInspectionReportBladeRepairRecord objBladeRepairRecord = new Edmx.ComponentInspectionReportBladeRepairRecord
                    {
                        ComponentInspectionReportBladeRepairRecordId = BladeRepairRecordList.ComponentInspectionReportBladeRepairRecordId,
                        ComponentInspectionReportBladeId = objCompBlade.ComponentInspectionReportBladeId,
                        BladeAmbientTemp = BladeRepairRecordList.BladeAmbientTemp,
                        BladeHumidity = BladeRepairRecordList.BladeHumidity,
                        BladeAdditionalDocumentReference = BladeRepairRecordList.BladeAdditionalDocumentReference,
                        BladeResinType = BladeRepairRecordList.BladeResinType,
                        BladeResinTypeBatchNumbers = BladeRepairRecordList.BladeResinTypeBatchNumbers,
                        BladeResinTypeExpiryDate = BladeRepairRecordList.BladeResinTypeExpiryDate,
                        BladeHardenerType = BladeRepairRecordList.BladeHardenerType,
                        BladeHardenerTypeBatchNumbers = BladeRepairRecordList.BladeHardenerTypeBatchNumbers,
                        BladeGlassSupplier = BladeRepairRecordList.BladeGlassSupplier,
                        BladeGlassSupplierBatchNumbers = BladeRepairRecordList.BladeGlassSupplierBatchNumbers,
                        BladeSurfaceMaxTemperature = BladeRepairRecordList.BladeSurfaceMaxTemperature,
                        BladeSurfaceMinTemperature = BladeRepairRecordList.BladeSurfaceMinTemperature,
                        BladeResinUsed = BladeRepairRecordList.BladeResinUsed,
                        BladePostCureMaxTemperature = BladeRepairRecordList.BladePostCureMaxTemperature,
                        BladePostCureMinTemperature = BladeRepairRecordList.BladePostCureMinTemperature,
                        BladeTurnOffTime = BladeRepairRecordList.BladeTurnOffTime,
                        BladeTotalCureTime = BladeRepairRecordList.BladeTotalCureTime

                    };
                    context.ComponentInspectionReportBladeRepairRecord.Add(objBladeRepairRecord);
                }
                context.SaveChanges();

            }


            #endregion
            #region Component Inspection Report Skiip
            /* Assign value to CIR Report Skiip Entity */
            if (!ReferenceEquals(CIRList.Skiip, null) /* && !string.IsNullOrEmpty(CIRList.Skiip.SkiiPOtherDamagedComponentsReplaced)*/)
            {
                Edmx.ComponentInspectionReportSkiiP objCompoSkip = CIRListUp.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoSkip, null))
                {
                    objCompoSkip.SkiiPOtherDamagedComponentsReplaced = CIRList.Skiip.SkiiPOtherDamagedComponentsReplaced;
                    objCompoSkip.SkiiPCauseId = CIRList.Skiip.SkiiPCauseId;
                    objCompoSkip.SkiiPQuantityOfFailedModules = CIRList.Skiip.SkiiPQuantityOfFailedModules;
                    objCompoSkip.SkiiP2MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV521BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV522BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV523BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV524BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV524BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV525BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV525BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV526BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV526BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV521BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV522BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV523BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV524xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV524yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV525xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV525yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV526xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV526yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId;
                    objCompoSkip.SkiiP850KWV520BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV520BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV520BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV524BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV524BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV525BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV525BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV526BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV526BooleanAnswerId;
                    objCompoSkip.SkiiPClaimRelevantBooleanAnswerId = (CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId;
                    objCompoSkip.SkiiPNumberofComponents = CIRList.Skiip.SkiiPNumberofComponents;

                    context.ComponentInspectionReportSkiiP.Attach(objCompoSkip);
                    context.Entry(objCompoSkip).State = System.Data.EntityState.Modified;

                }
                context.SaveChanges();

                #region Component Inspection Report Skiip Failed
                Edmx.ComponentInspectionReportSkiiP objCompoSkip1 = CIRListUp.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                /* Skiip Failed Component */
                if (null != objCompoSkip1)
                {
                    if (objCompoSkip1.ComponentInspectionReportSkiiPId > 0)
                    {
                        var objCompoSkiipFail = objCompoSkip1.ComponentInspectionReportSkiiPFailedComponent
                               .Where(x => x.ComponentInspectionReportSkiiPId == objCompoSkip1.ComponentInspectionReportSkiiPId);
                        if (CIRList.Skiip != null && CIRList.Skiip.SkiipFailedComp != null)
                        {
                            foreach (CIR.ComponentInspectionReportSkiiPFailedComponent objCIRSkiFal in CIRList.Skiip.SkiipFailedComp)
                            {
                                var objSkiipFail = objCompoSkiipFail.Where(x => x.ComponentInspectionReportSkiiPFailedComponentId == objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId).FirstOrDefault();
                                /* Skiip Failed Compo update */
                                if ((null != objSkiipFail) && (objSkiipFail.ComponentInspectionReportSkiiPFailedComponentId > 0))
                                {
                                    objSkiipFail.ComponentInspectionReportSkiiPFailedComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId;
                                    //objSkiipFail.ComponentInspectionReportSkiiPId = objCompoSkip1.ComponentInspectionReportSkiiPId;
                                    objSkiipFail.SkiiPFailedComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPFailedComponentVestasUniqueIdentifier;
                                    objSkiipFail.SkiiPFailedComponentVestasItemNumber = objCIRSkiFal.SkiiPFailedComponentVestasItemNumber;
                                    objSkiipFail.SkiiPFailedComponentSerialNumber = objCIRSkiFal.SkiiPFailedComponentSerialNumber;
                                    context.ComponentInspectionReportSkiiPFailedComponent.Attach(objSkiipFail);
                                    context.Entry(objSkiipFail).State = System.Data.EntityState.Modified;
                                }
                                else
                                {
                                    /* Skiip Failed Compo insert */
                                    Edmx.ComponentInspectionReportSkiiPFailedComponent objCompoSkiipFailed = new Edmx.ComponentInspectionReportSkiiPFailedComponent
                                    {
                                        ComponentInspectionReportSkiiPFailedComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId,
                                        ComponentInspectionReportSkiiPId = objCompoSkip1.ComponentInspectionReportSkiiPId,
                                        SkiiPFailedComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPFailedComponentVestasUniqueIdentifier,
                                        SkiiPFailedComponentVestasItemNumber = objCIRSkiFal.SkiiPFailedComponentVestasItemNumber,
                                        SkiiPFailedComponentSerialNumber = objCIRSkiFal.SkiiPFailedComponentSerialNumber

                                    };
                                    context.ComponentInspectionReportSkiiPFailedComponent.Add(objCompoSkiipFailed);

                                }
                            }
                        }

                        context.SaveChanges();
                        var objCompoSkiipNwCom = objCompoSkip1.ComponentInspectionReportSkiiPNewComponent
                           .Where(x => x.ComponentInspectionReportSkiiPId == objCompoSkip1.ComponentInspectionReportSkiiPId);

                        if (CIRList.Skiip != null && CIRList.Skiip.SkiipNewComp != null)
                        {
                            /* Skiip New Comp */
                            foreach (CIR.ComponentInspectionReportSkiiPNewComponent objCIRSkiFal in CIRList.Skiip.SkiipNewComp)
                            {
                                var objSkiipNwCom = objCompoSkiipNwCom.Where(x => x.ComponentInspectionReportSkiiPNewComponentId == objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId).FirstOrDefault();
                                /* Skiip New Comp Update*/
                                if ((null != objSkiipNwCom) && (objSkiipNwCom.ComponentInspectionReportSkiiPNewComponentId > 0))
                                {
                                    objSkiipNwCom.ComponentInspectionReportSkiiPNewComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId;
                                    //objSkiipNwCom.ComponentInspectionReportSkiiPId = objCompoSkip1.ComponentInspectionReportSkiiPId;
                                    objSkiipNwCom.SkiiPNewComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPNewComponentVestasUniqueIdentifier;
                                    objSkiipNwCom.SkiiPNewComponentVestasItemNumber = objCIRSkiFal.SkiiPNewComponentVestasItemNumber;
                                    objSkiipNwCom.SkiiPNewComponentSerialNumber = objCIRSkiFal.SkiiPNewComponentSerialNumber;
                                    context.ComponentInspectionReportSkiiPNewComponent.Attach(objSkiipNwCom);
                                    context.Entry(objSkiipNwCom).State = System.Data.EntityState.Modified;
                                }
                                else
                                {
                                    /* Skiip New Comp Insert */
                                    Edmx.ComponentInspectionReportSkiiPNewComponent objCompoSkiipNew = new Edmx.ComponentInspectionReportSkiiPNewComponent
                                    {
                                        ComponentInspectionReportSkiiPNewComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId,
                                        ComponentInspectionReportSkiiPId = objCompoSkip1.ComponentInspectionReportSkiiPId,
                                        SkiiPNewComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPNewComponentVestasUniqueIdentifier,
                                        SkiiPNewComponentVestasItemNumber = objCIRSkiFal.SkiiPNewComponentVestasItemNumber,
                                        SkiiPNewComponentSerialNumber = objCIRSkiFal.SkiiPNewComponentSerialNumber

                                    };
                                    context.ComponentInspectionReportSkiiPNewComponent.Add(objCompoSkiipNew);

                                }
                            }
                        }
                        context.SaveChanges();

                    }
                }
                #endregion
            }
            #endregion
            #region Component Inspection Report Gearbox
            /* Assign value to CIR Report Gear Entity */
            if (!ReferenceEquals(CIRList.Gearbox, null) && !string.IsNullOrEmpty(CIRList.Gearbox.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportGearbox objCompoGear = CIRListUp.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoGear, null))
                {
                    objCompoGear.VestasUniqueIdentifier = CIRList.Gearbox.VestasUniqueIdentifier;
                    objCompoGear.GearboxTypeId = CIRList.Gearbox.GearboxTypeId;
                    objCompoGear.GearboxRevisionId = CIRList.Gearbox.GearboxRevisionId;
                    objCompoGear.GearboxManufacturerId = CIRList.Gearbox.GearboxManufacturerId;
                    objCompoGear.OtherGearboxType = CIRList.Gearbox.OtherGearboxType;
                    objCompoGear.GearboxSerialNumber = CIRList.Gearbox.GearboxSerialNumber;
                    objCompoGear.GearboxOtherManufacturer = CIRList.Gearbox.GearboxOtherManufacturer;
                    objCompoGear.GearboxLastOilChangeDate = ParseDatetime(CIRList.Gearbox.strGearboxLastOilChangeDate);
                    objCompoGear.GearboxOilTypeId = CIRList.Gearbox.GearboxOilTypeId;
                    objCompoGear.GearboxMechanicalOilPumpId = CIRList.Gearbox.GearboxMechanicalOilPumpId;
                    objCompoGear.GearboxOilLevelId = CIRList.Gearbox.GearboxOilLevelId;
                    objCompoGear.GearboxRunHours = CIRList.Gearbox.GearboxRunHours;
                    objCompoGear.GearboxOilTemperature = CIRList.Gearbox.GearboxOilTemperature;
                    objCompoGear.GearboxProduction = CIRList.Gearbox.GearboxProduction;
                    objCompoGear.GearboxGeneratorManufacturerId = CIRList.Gearbox.GearboxGeneratorManufacturerId;
                    objCompoGear.GearboxGeneratorManufacturerId2 = CIRList.Gearbox.GearboxGeneratorManufacturerId2;
                    objCompoGear.GearboxElectricalPumpId = CIRList.Gearbox.GearboxElectricalPumpId;
                    objCompoGear.GearboxShrinkElementId = CIRList.Gearbox.GearboxShrinkElementId;
                    objCompoGear.GearboxShrinkElementSerialNumber = CIRList.Gearbox.GearboxShrinkElementSerialNumber;
                    objCompoGear.GearboxCouplingId = CIRList.Gearbox.GearboxCouplingId;
                    objCompoGear.GearboxFilterBlockTypeId = CIRList.Gearbox.GearboxFilterBlockTypeId;
                    objCompoGear.GearboxInLineFilterId = CIRList.Gearbox.GearboxInLineFilterId;
                    objCompoGear.GearboxOffLineFilterId = CIRList.Gearbox.GearboxOffLineFilterId;
                    objCompoGear.GearboxSoftwareRelease = CIRList.Gearbox.GearboxSoftwareRelease;
                    objCompoGear.GearboxShaftsExactLocation1ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation1ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation2ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation2ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation3ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation3ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation4ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation4ShaftTypeId;
                    objCompoGear.GearboxShaftsTypeofDamage1ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage1ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage2ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage2ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage3ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage3ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage4ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage4ShaftErrorId;
                    objCompoGear.GearboxExactLocation1GearTypeId = CIRList.Gearbox.GearboxExactLocation1GearTypeId;
                    objCompoGear.GearboxExactLocation2GearTypeId = CIRList.Gearbox.GearboxExactLocation2GearTypeId;
                    objCompoGear.GearboxExactLocation3GearTypeId = CIRList.Gearbox.GearboxExactLocation3GearTypeId;
                    objCompoGear.GearboxExactLocation4GearTypeId = CIRList.Gearbox.GearboxExactLocation4GearTypeId;
                    objCompoGear.GearboxExactLocation5GearTypeId = CIRList.Gearbox.GearboxExactLocation5GearTypeId;
                    objCompoGear.GearboxTypeofDamage1GearErrorId = CIRList.Gearbox.GearboxTypeofDamage1GearErrorId;
                    objCompoGear.GearboxTypeofDamage2GearErrorId = CIRList.Gearbox.GearboxTypeofDamage2GearErrorId;
                    objCompoGear.GearboxTypeofDamage3GearErrorId = CIRList.Gearbox.GearboxTypeofDamage3GearErrorId;
                    objCompoGear.GearboxTypeofDamage4GearErrorId = CIRList.Gearbox.GearboxTypeofDamage4GearErrorId;
                    objCompoGear.GearboxTypeofDamage5GearErrorId = CIRList.Gearbox.GearboxTypeofDamage5GearErrorId;
                    objCompoGear.GearboxBearingsLocation1BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation1BearingTypeId;
                    objCompoGear.GearboxBearingsLocation2BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation2BearingTypeId;
                    objCompoGear.GearboxBearingsLocation3BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation3BearingTypeId;
                    objCompoGear.GearboxBearingsLocation4BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation4BearingTypeId;
                    objCompoGear.GearboxBearingsLocation5BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation5BearingTypeId;
                    objCompoGear.GearboxBearingsPosition1BearingPosId = CIRList.Gearbox.GearboxBearingsPosition1BearingPosId;
                    objCompoGear.GearboxBearingsPosition2BearingPosId = CIRList.Gearbox.GearboxBearingsPosition2BearingPosId;
                    objCompoGear.GearboxBearingsPosition3BearingPosId = CIRList.Gearbox.GearboxBearingsPosition3BearingPosId;
                    objCompoGear.GearboxBearingsPosition4BearingPosId = CIRList.Gearbox.GearboxBearingsPosition4BearingPosId;
                    objCompoGear.GearboxBearingsPosition5BearingPosId = CIRList.Gearbox.GearboxBearingsPosition5BearingPosId;
                    objCompoGear.GearboxBearingsDamage1BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage1BearingErrorId;
                    objCompoGear.GearboxBearingsDamage2BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage2BearingErrorId;
                    objCompoGear.GearboxBearingsDamage3BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage3BearingErrorId;
                    objCompoGear.GearboxBearingsDamage4BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage4BearingErrorId;
                    objCompoGear.GearboxBearingsDamage5BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage5BearingErrorId;
                    objCompoGear.GearboxPlanetStage1HousingErrorId = CIRList.Gearbox.GearboxPlanetStage1HousingErrorId;
                    objCompoGear.GearboxPlanetStage2HousingErrorId = CIRList.Gearbox.GearboxPlanetStage2HousingErrorId;
                    objCompoGear.GearboxHelicalStageHousingErrorId = CIRList.Gearbox.GearboxHelicalStageHousingErrorId;
                    objCompoGear.GearboxFrontPlateHousingErrorId = CIRList.Gearbox.GearboxFrontPlateHousingErrorId;
                    objCompoGear.GearboxAuxStageHousingErrorId = CIRList.Gearbox.GearboxAuxStageHousingErrorId;
                    objCompoGear.GearboxHSStageHousingErrorId = CIRList.Gearbox.GearboxHSStageHousingErrorId;
                    objCompoGear.GearboxLooseBolts = CIRList.Gearbox.GearboxLooseBolts;
                    objCompoGear.GearboxBrokenBolts = CIRList.Gearbox.GearboxBrokenBolts;
                    objCompoGear.GearboxDefectDamperElements = CIRList.Gearbox.GearboxDefectDamperElements;
                    objCompoGear.GearboxTooMuchClearance = CIRList.Gearbox.GearboxTooMuchClearance;
                    objCompoGear.GearboxCrackedTorqueArm = CIRList.Gearbox.GearboxCrackedTorqueArm;
                    objCompoGear.GearboxNeedsToBeAligned = CIRList.Gearbox.GearboxNeedsToBeAligned;
                    objCompoGear.GearboxPT100Bearing1 = CIRList.Gearbox.GearboxPT100Bearing1;
                    objCompoGear.GearboxPT100Bearing2 = CIRList.Gearbox.GearboxPT100Bearing2;
                    objCompoGear.GearboxPT100Bearing3 = CIRList.Gearbox.GearboxPT100Bearing3;
                    objCompoGear.GearboxOilLevelSensor = CIRList.Gearbox.GearboxOilLevelSensor;
                    objCompoGear.GearboxOilPressure = CIRList.Gearbox.GearboxOilPressure;
                    objCompoGear.GearboxPT100OilSump = CIRList.Gearbox.GearboxPT100OilSump;
                    objCompoGear.GearboxFilterIndicator = CIRList.Gearbox.GearboxFilterIndicator;
                    objCompoGear.GearboxImmersionHeater = CIRList.Gearbox.GearboxImmersionHeater;
                    objCompoGear.GearboxDrainValve = CIRList.Gearbox.GearboxDrainValve;
                    objCompoGear.GearboxAirBreather = CIRList.Gearbox.GearboxAirBreather;
                    objCompoGear.GearboxSightGlass = CIRList.Gearbox.GearboxSightGlass;
                    objCompoGear.GearboxChipDetector = CIRList.Gearbox.GearboxChipDetector;
                    objCompoGear.GearboxVibrationsId = CIRList.Gearbox.GearboxVibrationsId;
                    objCompoGear.GearboxNoiseId = CIRList.Gearbox.GearboxNoiseId;
                    objCompoGear.GearboxDebrisOnMagnetId = CIRList.Gearbox.GearboxDebrisOnMagnetId;
                    objCompoGear.GearboxDebrisStagesMagnetPosId = CIRList.Gearbox.GearboxDebrisStagesMagnetPosId;
                    objCompoGear.GearboxDebrisGearBoxId = CIRList.Gearbox.GearboxDebrisGearBoxId;
                    objCompoGear.GearboxMaxTempResetDate = ParseDatetime(CIRList.Gearbox.GearboxMaxTempResetDate);
                    objCompoGear.GearboxTempBearing1 = CIRList.Gearbox.GearboxTempBearing1;
                    objCompoGear.GearboxTempBearing2 = CIRList.Gearbox.GearboxTempBearing2;
                    objCompoGear.GearboxTempBearing3 = CIRList.Gearbox.GearboxTempBearing3;
                    objCompoGear.GearboxTempOilSump = CIRList.Gearbox.GearboxTempOilSump;
                    objCompoGear.GearboxLSSNRend = CIRList.Gearbox.GearboxLSSNRend;
                    objCompoGear.GearboxIMSNRend = CIRList.Gearbox.GearboxIMSNRend;
                    objCompoGear.GearboxIMSRend = CIRList.Gearbox.GearboxIMSRend;
                    objCompoGear.GearboxHSSNRend = CIRList.Gearbox.GearboxHSSNRend;
                    objCompoGear.GearboxHSSRend = CIRList.Gearbox.GearboxHSSRend;
                    objCompoGear.GearboxPitchTube = CIRList.Gearbox.GearboxPitchTube;
                    objCompoGear.GearboxSplitLines = CIRList.Gearbox.GearboxSplitLines;
                    objCompoGear.GearboxHoseAndPiping = CIRList.Gearbox.GearboxHoseAndPiping;
                    objCompoGear.GearboxInputShaft = CIRList.Gearbox.GearboxInputShaft;
                    objCompoGear.GearboxHSSPTO = CIRList.Gearbox.GearboxHSSPTO;
                    objCompoGear.GearboxClaimRelevantBooleanAnswerId = CIRList.Gearbox.GearboxClaimRelevantBooleanAnswerId;
                    objCompoGear.GearboxOverallGearboxConditionId = CIRList.Gearbox.GearboxOverallGearboxConditionId;
                    objCompoGear.GearboxExactLocation6GearTypeId = CIRList.Gearbox.GearboxExactLocation6GearTypeId;
                    objCompoGear.GearboxExactLocation7GearTypeId = CIRList.Gearbox.GearboxExactLocation7GearTypeId;
                    objCompoGear.GearboxExactLocation8GearTypeId = CIRList.Gearbox.GearboxExactLocation8GearTypeId;
                    objCompoGear.GearboxExactLocation9GearTypeId = CIRList.Gearbox.GearboxExactLocation9GearTypeId;
                    objCompoGear.GearboxExactLocation10GearTypeId = CIRList.Gearbox.GearboxExactLocation10GearTypeId;
                    objCompoGear.GearboxExactLocation11GearTypeId = CIRList.Gearbox.GearboxExactLocation11GearTypeId;
                    objCompoGear.GearboxExactLocation12GearTypeId = CIRList.Gearbox.GearboxExactLocation12GearTypeId;
                    objCompoGear.GearboxExactLocation13GearTypeId = CIRList.Gearbox.GearboxExactLocation13GearTypeId;
                    objCompoGear.GearboxExactLocation14GearTypeId = CIRList.Gearbox.GearboxExactLocation14GearTypeId;
                    objCompoGear.GearboxExactLocation15GearTypeId = CIRList.Gearbox.GearboxExactLocation15GearTypeId;
                    objCompoGear.GearboxTypeofDamage6GearErrorId = CIRList.Gearbox.GearboxTypeofDamage6GearErrorId;
                    objCompoGear.GearboxTypeofDamage7GearErrorId = CIRList.Gearbox.GearboxTypeofDamage7GearErrorId;
                    objCompoGear.GearboxTypeofDamage8GearErrorId = CIRList.Gearbox.GearboxTypeofDamage8GearErrorId;
                    objCompoGear.GearboxTypeofDamage9GearErrorId = CIRList.Gearbox.GearboxTypeofDamage9GearErrorId;
                    objCompoGear.GearboxTypeofDamage10GearErrorId = CIRList.Gearbox.GearboxTypeofDamage10GearErrorId;
                    objCompoGear.GearboxTypeofDamage11GearErrorId = CIRList.Gearbox.GearboxTypeofDamage11GearErrorId;
                    objCompoGear.GearboxTypeofDamage12GearErrorId = CIRList.Gearbox.GearboxTypeofDamage12GearErrorId;
                    objCompoGear.GearboxTypeofDamage13GearErrorId = CIRList.Gearbox.GearboxTypeofDamage13GearErrorId;
                    objCompoGear.GearboxTypeofDamage14GearErrorId = CIRList.Gearbox.GearboxTypeofDamage14GearErrorId;
                    objCompoGear.GearboxTypeofDamage15GearErrorId = CIRList.Gearbox.GearboxTypeofDamage15GearErrorId;
                    objCompoGear.GearboxGearDecision1DamageDecisionId = CIRList.Gearbox.GearboxGearDecision1DamageDecisionId;
                    objCompoGear.GearboxGearDecision2DamageDecisionId = CIRList.Gearbox.GearboxGearDecision2DamageDecisionId;
                    objCompoGear.GearboxGearDecision3DamageDecisionId = CIRList.Gearbox.GearboxGearDecision3DamageDecisionId;
                    objCompoGear.GearboxGearDecision4DamageDecisionId = CIRList.Gearbox.GearboxGearDecision4DamageDecisionId;
                    objCompoGear.GearboxGearDecision5DamageDecisionId = CIRList.Gearbox.GearboxGearDecision5DamageDecisionId;
                    objCompoGear.GearboxGearDecision6DamageDecisionId = CIRList.Gearbox.GearboxGearDecision6DamageDecisionId;
                    objCompoGear.GearboxGearDecision7DamageDecisionId = CIRList.Gearbox.GearboxGearDecision7DamageDecisionId;
                    objCompoGear.GearboxGearDecision8DamageDecisionId = CIRList.Gearbox.GearboxGearDecision8DamageDecisionId;
                    objCompoGear.GearboxGearDecision9DamageDecisionId = CIRList.Gearbox.GearboxGearDecision9DamageDecisionId;
                    objCompoGear.GearboxGearDecision10DamageDecisionId = CIRList.Gearbox.GearboxGearDecision10DamageDecisionId;
                    objCompoGear.GearboxGearDecision11DamageDecisionId = CIRList.Gearbox.GearboxGearDecision11DamageDecisionId;
                    objCompoGear.GearboxGearDecision12DamageDecisionId = CIRList.Gearbox.GearboxGearDecision12DamageDecisionId;
                    objCompoGear.GearboxGearDecision13DamageDecisionId = CIRList.Gearbox.GearboxGearDecision13DamageDecisionId;
                    objCompoGear.GearboxGearDecision14DamageDecisionId = CIRList.Gearbox.GearboxGearDecision14DamageDecisionId;
                    objCompoGear.GearboxGearDecision15DamageDecisionId = CIRList.Gearbox.GearboxGearDecision15DamageDecisionId;
                    objCompoGear.GearboxBearingsLocation6BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation6BearingTypeId;
                    objCompoGear.GearboxBearingsPosition6BearingPosId = CIRList.Gearbox.GearboxBearingsPosition6BearingPosId;
                    objCompoGear.GearboxBearingsDamage6BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage6BearingErrorId;
                    objCompoGear.GearboxBearingDecision1DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision1DamageDecisionId;
                    objCompoGear.GearboxBearingDecision2DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision2DamageDecisionId;
                    objCompoGear.GearboxBearingDecision3DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision3DamageDecisionId;
                    objCompoGear.GearboxBearingDecision4DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision4DamageDecisionId;
                    objCompoGear.GearboxBearingDecision5DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision5DamageDecisionId;
                    objCompoGear.GearboxBearingDecision6DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision6DamageDecisionId;
                    objCompoGear.GearboxGearDamageClass1DamageId = CIRList.Gearbox.GearboxGearDamageClass1DamageId;
                    objCompoGear.GearboxGearDamageClass2DamageId = CIRList.Gearbox.GearboxGearDamageClass2DamageId;
                    objCompoGear.GearboxGearDamageClass3DamageId = CIRList.Gearbox.GearboxGearDamageClass3DamageId;
                    objCompoGear.GearboxGearDamageClass4DamageId = CIRList.Gearbox.GearboxGearDamageClass4DamageId;
                    objCompoGear.GearboxGearDamageClass5DamageId = CIRList.Gearbox.GearboxGearDamageClass5DamageId;
                    objCompoGear.GearboxGearDamageClass6DamageId = CIRList.Gearbox.GearboxGearDamageClass6DamageId;
                    objCompoGear.GearboxGearDamageClass7DamageId = CIRList.Gearbox.GearboxGearDamageClass7DamageId;
                    objCompoGear.GearboxGearDamageClass8DamageId = CIRList.Gearbox.GearboxGearDamageClass8DamageId;
                    objCompoGear.GearboxGearDamageClass9DamageId = CIRList.Gearbox.GearboxGearDamageClass9DamageId;
                    objCompoGear.GearboxGearDamageClass10DamageId = CIRList.Gearbox.GearboxGearDamageClass10DamageId;
                    objCompoGear.GearboxGearDamageClass11DamageId = CIRList.Gearbox.GearboxGearDamageClass11DamageId;
                    objCompoGear.GearboxGearDamageClass12DamageId = CIRList.Gearbox.GearboxGearDamageClass12DamageId;
                    objCompoGear.GearboxGearDamageClass13DamageId = CIRList.Gearbox.GearboxGearDamageClass13DamageId;
                    objCompoGear.GearboxGearDamageClass14DamageId = CIRList.Gearbox.GearboxGearDamageClass14DamageId;
                    objCompoGear.GearboxGearDamageClass15DamageId = CIRList.Gearbox.GearboxGearDamageClass15DamageId;
                    objCompoGear.GearboxAuxEquipmentId = CIRList.Gearbox.GearboxAuxEquipmentId;
                    objCompoGear.GearboxActionToBeTakenOnGearboxId = CIRList.Gearbox.GearboxActionToBeTakenOnGearboxId;
                    objCompoGear.GearboxDefectCategorizationScore = CIRList.Gearbox.GearboxDefectCategorizationScore;

                    context.ComponentInspectionReportGearbox.Attach(objCompoGear);
                    context.Entry(objCompoGear).State = System.Data.EntityState.Modified;
                }
                context.SaveChanges();
            }
            #endregion
            #region Component Inspection Report Generator
            /* Assign value to CIR Report Gen Entity */
            if (!ReferenceEquals(CIRList.Generator, null) && !string.IsNullOrEmpty(CIRList.Generator.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportGenerator objCompoGen = CIRListUp.ComponentInspectionReportGenerator.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoGen, null))
                {
                    objCompoGen.VestasUniqueIdentifier = CIRList.Generator.VestasUniqueIdentifier;
                    objCompoGen.GeneratorManufacturerId = CIRList.Generator.GeneratorManufacturerId;
                    objCompoGen.GeneratorSerialNumber = CIRList.Generator.GeneratorSerialNumber;
                    objCompoGen.OtherManufacturer = CIRList.Generator.OtherManufacturer;
                    objCompoGen.GeneratorMaxTemperature = CIRList.Generator.GeneratorMaxTemperature;
                    objCompoGen.GeneratorMaxTemperatureResetDate = ParseDatetime(CIRList.Generator.strGeneratorMaxTemperatureResetDate);
                    objCompoGen.CouplingId = CIRList.Generator.CouplingId;
                    objCompoGen.ActionToBeTakenOnGeneratorId = CIRList.Generator.ActionToBeTakenOnGeneratorId;
                    objCompoGen.GeneratorDriveEndId = CIRList.Generator.GeneratorDriveEndId;
                    objCompoGen.GeneratorNonDriveEndId = CIRList.Generator.GeneratorNonDriveEndId;
                    objCompoGen.GeneratorRotorId = CIRList.Generator.GeneratorRotorId;
                    objCompoGen.GeneratorCoverId = CIRList.Generator.GeneratorCoverId;
                    objCompoGen.AirToAirCoolerInternalId = CIRList.Generator.AirToAirCoolerInternalId;
                    objCompoGen.AirToAirCoolerExternalId = CIRList.Generator.AirToAirCoolerExternalId;
                    objCompoGen.GeneratorComments = CIRList.Generator.GeneratorComments;
                    objCompoGen.UGround = CIRList.Generator.UGround;
                    objCompoGen.VGround = CIRList.Generator.VGround;
                    objCompoGen.WGround = CIRList.Generator.WGround;
                    objCompoGen.UV = CIRList.Generator.UV;
                    objCompoGen.UW = CIRList.Generator.UW;
                    objCompoGen.VW = CIRList.Generator.VW;
                    objCompoGen.KGround = CIRList.Generator.KGround;
                    objCompoGen.LGround = CIRList.Generator.LGround;
                    objCompoGen.MGround = CIRList.Generator.MGround;
                    objCompoGen.UGroundOhmUnitId = CIRList.Generator.UGroundOhmUnitId;
                    objCompoGen.VGroundOhmUnitId = CIRList.Generator.VGroundOhmUnitId;
                    objCompoGen.WGroundOhmUnitId = CIRList.Generator.WGroundOhmUnitId;
                    objCompoGen.UVOhmUnitId = CIRList.Generator.UVOhmUnitId;
                    objCompoGen.UWOhmUnitId = CIRList.Generator.UWOhmUnitId;
                    objCompoGen.VWOhmUnitId = CIRList.Generator.VWOhmUnitId;
                    objCompoGen.KGroundOhmUnitId = CIRList.Generator.KGroundOhmUnitId;
                    objCompoGen.LGroundOhmUnitId = CIRList.Generator.LGroundOhmUnitId;
                    objCompoGen.MGroundOhmUnitId = CIRList.Generator.MGroundOhmUnitId;
                    objCompoGen.U1U2 = CIRList.Generator.U1U2;
                    objCompoGen.V1V2 = CIRList.Generator.V1V2;
                    objCompoGen.W1W2 = CIRList.Generator.W1W2;
                    objCompoGen.K1L1 = CIRList.Generator.K1L1;
                    objCompoGen.L1M1 = CIRList.Generator.L1M1;
                    objCompoGen.K1M1 = CIRList.Generator.K1M1;
                    objCompoGen.K2L2 = CIRList.Generator.K2L2;
                    objCompoGen.L2M2 = CIRList.Generator.L2M2;
                    objCompoGen.K2M2 = CIRList.Generator.K2M2;
                    objCompoGen.GeneratorRewoundLocally = CIRList.Generator.GeneratorRewoundLocally;
                    objCompoGen.GeneratorClaimRelevantBooleanAnswerId = CIRList.Generator.GeneratorClaimRelevantBooleanAnswerId;
                    objCompoGen.InsulationComments = CIRList.Generator.InsulationComments;
                    objCompoGen.GeneratorInsulationComments = CIRList.Generator.GeneratorInsulationComments;
                    context.ComponentInspectionReportGenerator.Attach(objCompoGen);
                    context.Entry(objCompoGen).State = System.Data.EntityState.Modified;

                }
                context.SaveChanges();
            }
            #endregion
            #region Component Inspection Report Transformer
            if (!ReferenceEquals(CIRList.Transformer, null) && !string.IsNullOrEmpty(CIRList.Transformer.VestasUniqueIdentifier))
            {
                Edmx.ComponentInspectionReportTransformer objCompoTrans = CIRListUp.ComponentInspectionReportTransformer.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objCompoTrans, null))
                {
                    objCompoTrans.VestasUniqueIdentifier = CIRList.Transformer.VestasUniqueIdentifier;
                    objCompoTrans.TransformerManufacturerId = CIRList.Transformer.TransformerManufacturerId;
                    objCompoTrans.TransformerSerialNumber = CIRList.Transformer.TransformerSerialNumber;
                    objCompoTrans.MaxTemp = CIRList.Transformer.MaxTemp;
                    objCompoTrans.MaxTempResetDate = ParseDatetime(CIRList.Transformer.MaxTempResetDate);
                    objCompoTrans.ActionOnTransformerId = CIRList.Transformer.ActionOnTransformerId;
                    objCompoTrans.HVCoilConditionId = CIRList.Transformer.HVCoilConditionId;
                    objCompoTrans.LVCoilConditionId = CIRList.Transformer.LVCoilConditionId;
                    objCompoTrans.HVCableConditionId = CIRList.Transformer.HVCableConditionId;
                    objCompoTrans.LVCableConditionId = CIRList.Transformer.LVCableConditionId;
                    objCompoTrans.BracketsId = CIRList.Transformer.BracketsId;
                    objCompoTrans.TransformerArcDetectionId = CIRList.Transformer.TransformerArcDetectionId;
                    objCompoTrans.ClimateId = CIRList.Transformer.ClimateId;
                    objCompoTrans.SurgeArrestorId = CIRList.Transformer.SurgeArrestorId;
                    objCompoTrans.ConnectionBarsId = CIRList.Transformer.ConnectionBarsId;
                    objCompoTrans.Comments = CIRList.Transformer.Comments;
                    objCompoTrans.TransformerClaimRelevantBooleanAnswerId = CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId;
                    context.ComponentInspectionReportTransformer.Attach(objCompoTrans);
                    context.Entry(objCompoTrans).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
            #endregion
            #region assign value to CIR REport mainBearing
            /* Assign value to CIR Report Blade Trans */
            if (!ReferenceEquals(CIRList.MainBearing, null) && !string.IsNullOrEmpty(CIRList.MainBearing.MainBearingSerialNumber))
            {
                Edmx.ComponentInspectionReportMainBearing objCompoMain = CIRListUp.ComponentInspectionReportMainBearing.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objCompoMain, null))
                {
                    long? MainBearingManufacturerId = null;
                    if (CIRList.MainBearing.MainBearingManufacturerId == 0)
                        MainBearingManufacturerId = null;
                    else
                        MainBearingManufacturerId = CIRList.MainBearing.MainBearingManufacturerId;

                    objCompoMain.VestasUniqueIdentifier = CIRList.MainBearing.VestasUniqueIdentifier;
                    objCompoMain.MainBearingLastLubricationDate = ParseDatetime(CIRList.MainBearing.strMainBearingLastLubricationDate);
                    objCompoMain.MainBearingManufacturerId = MainBearingManufacturerId;
                    objCompoMain.MainBearingTemperature = CIRList.MainBearing.MainBearingTemperature;
                    objCompoMain.MainBearingLubricationOilTypeId = CIRList.MainBearing.MainBearingLubricationOilTypeId;
                    objCompoMain.MainBearingGrease = CIRList.MainBearing.MainBearingGrease;
                    objCompoMain.MainBearingLubricationRunHours = CIRList.MainBearing.MainBearingLubricationRunHours;
                    objCompoMain.MainBearingOilTemperature = CIRList.MainBearing.MainBearingOilTemperature;
                    objCompoMain.MainBearingTypeId = CIRList.MainBearing.MainBearingTypeId;
                    objCompoMain.MainBearingRevision = CIRList.MainBearing.MainBearingRevision;
                    objCompoMain.MainBearingErrorLocationId = (CIRList.MainBearing.MainBearingErrorLocationId == 0 || CIRList.MainBearing.MainBearingErrorLocationId == null) ? 3 : CIRList.MainBearing.MainBearingErrorLocationId;
                    objCompoMain.MainBearingSerialNumber = CIRList.MainBearing.MainBearingSerialNumber;
                    objCompoMain.MainBearingRunHours = CIRList.MainBearing.MainBearingRunHours;
                    objCompoMain.MainBearingMechanicalOilPump = CIRList.MainBearing.MainBearingMechanicalOilPump;
                    objCompoMain.MainBearingClaimRelevantBooleanAnswerId = CIRList.MainBearing.MainBearingClaimRelevantBooleanAnswerId;
                    context.ComponentInspectionReportMainBearing.Attach(objCompoMain);
                    context.Entry(objCompoMain).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }

            }
            #endregion
            #region Dynamic Table
            if (!ReferenceEquals(CIRList.DynamicTableInputs, null) && !string.IsNullOrEmpty(CIRList.DynamicTableInputs.Row1Col1))
            {
                string cirID = CIRList.ComponentInspectionReportId.ToString();
                Edmx.DynamicTableInput objDynamicTableInput = context.DynamicTableInput.Where(x => x.CirId == cirID).FirstOrDefault();

                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objDynamicTableInput, null))
                {
                    if (CIRList.ComponentInspectionReportTypeId != 8)
                    {
                        objDynamicTableInput.Row1Col1 = CIRList.DynamicTableInputs.Row1Col1;
                        objDynamicTableInput.Row1Col2 = CIRList.DynamicTableInputs.Row1Col2;
                        objDynamicTableInput.Row1Col3 = CIRList.DynamicTableInputs.Row1Col3;
                        objDynamicTableInput.Row1Col4 = CIRList.DynamicTableInputs.Row1Col4;
                        objDynamicTableInput.Row2Col1 = CIRList.DynamicTableInputs.Row2Col1;
                        objDynamicTableInput.Row2Col2 = CIRList.DynamicTableInputs.Row2Col2;
                        objDynamicTableInput.Row2Col3 = CIRList.DynamicTableInputs.Row2Col3;
                        objDynamicTableInput.Row2Col4 = CIRList.DynamicTableInputs.Row2Col4;
                        objDynamicTableInput.Row3Col1 = CIRList.DynamicTableInputs.Row3Col1;
                        objDynamicTableInput.Row3Col2 = CIRList.DynamicTableInputs.Row3Col2;
                        objDynamicTableInput.Row3Col3 = CIRList.DynamicTableInputs.Row3Col3;
                        objDynamicTableInput.Row3Col4 = CIRList.DynamicTableInputs.Row3Col4;
                        objDynamicTableInput.Row4Col1 = CIRList.DynamicTableInputs.Row4Col1;
                        objDynamicTableInput.Row4Col2 = CIRList.DynamicTableInputs.Row4Col2;
                        objDynamicTableInput.Row4Col3 = CIRList.DynamicTableInputs.Row4Col3;
                        objDynamicTableInput.Row4Col4 = CIRList.DynamicTableInputs.Row4Col4;
                        objDynamicTableInput.Row5Col1 = CIRList.DynamicTableInputs.Row5Col1;
                        objDynamicTableInput.Row5Col2 = CIRList.DynamicTableInputs.Row5Col2;
                        objDynamicTableInput.Row5Col3 = CIRList.DynamicTableInputs.Row5Col3;
                        objDynamicTableInput.Row5Col4 = CIRList.DynamicTableInputs.Row5Col4;
                        objDynamicTableInput.Row6Col1 = CIRList.DynamicTableInputs.Row6Col1;
                        objDynamicTableInput.Row6Col2 = CIRList.DynamicTableInputs.Row6Col2;
                        objDynamicTableInput.Row6Col3 = CIRList.DynamicTableInputs.Row6Col3;
                        objDynamicTableInput.Row6Col4 = CIRList.DynamicTableInputs.Row6Col4;
                        objDynamicTableInput.Row7Col1 = CIRList.DynamicTableInputs.Row7Col1;
                        objDynamicTableInput.Row7Col2 = CIRList.DynamicTableInputs.Row7Col2;
                        objDynamicTableInput.Row7Col3 = CIRList.DynamicTableInputs.Row7Col3;
                        objDynamicTableInput.Row7Col4 = CIRList.DynamicTableInputs.Row7Col4;
                        objDynamicTableInput.Row8Col1 = CIRList.DynamicTableInputs.Row8Col1;
                        objDynamicTableInput.Row8Col2 = CIRList.DynamicTableInputs.Row8Col2;
                        objDynamicTableInput.Row8Col3 = CIRList.DynamicTableInputs.Row8Col3;
                        objDynamicTableInput.Row8Col4 = CIRList.DynamicTableInputs.Row8Col4;
                        objDynamicTableInput.Row9Col1 = CIRList.DynamicTableInputs.Row9Col1;
                        objDynamicTableInput.Row9Col2 = CIRList.DynamicTableInputs.Row9Col2;
                        objDynamicTableInput.Row9Col3 = CIRList.DynamicTableInputs.Row9Col3;
                        objDynamicTableInput.Row9Col4 = CIRList.DynamicTableInputs.Row9Col4;
                        objDynamicTableInput.Row10Col1 = CIRList.DynamicTableInputs.Row10Col1;
                        objDynamicTableInput.Row10Col2 = CIRList.DynamicTableInputs.Row10Col2;
                        objDynamicTableInput.Row10Col3 = CIRList.DynamicTableInputs.Row10Col3;
                        objDynamicTableInput.Row10Col4 = CIRList.DynamicTableInputs.Row10Col4;
                        objDynamicTableInput.Row1Col5 = CIRList.DynamicTableInputs.Row1Col5;
                        objDynamicTableInput.Row1Col6 = CIRList.DynamicTableInputs.Row1Col6;
                        objDynamicTableInput.Row2Col5 = CIRList.DynamicTableInputs.Row2Col5;
                        objDynamicTableInput.Row2Col6 = CIRList.DynamicTableInputs.Row2Col6;
                        objDynamicTableInput.Row3Col5 = CIRList.DynamicTableInputs.Row3Col5;
                        objDynamicTableInput.Row3Col6 = CIRList.DynamicTableInputs.Row3Col6;
                        objDynamicTableInput.Row4Col5 = CIRList.DynamicTableInputs.Row4Col5;
                        objDynamicTableInput.Row4Col6 = CIRList.DynamicTableInputs.Row4Col6;
                        objDynamicTableInput.Row5Col5 = CIRList.DynamicTableInputs.Row5Col5;
                        objDynamicTableInput.Row5Col6 = CIRList.DynamicTableInputs.Row5Col6;
                        objDynamicTableInput.Row6Col5 = CIRList.DynamicTableInputs.Row6Col5;
                        objDynamicTableInput.Row6Col6 = CIRList.DynamicTableInputs.Row6Col6;
                        objDynamicTableInput.Row7Col5 = CIRList.DynamicTableInputs.Row7Col5;
                        objDynamicTableInput.Row7Col6 = CIRList.DynamicTableInputs.Row7Col6;
                        objDynamicTableInput.Row8Col5 = CIRList.DynamicTableInputs.Row8Col5;
                        objDynamicTableInput.Row8Col6 = CIRList.DynamicTableInputs.Row8Col6;
                        objDynamicTableInput.Row9Col5 = CIRList.DynamicTableInputs.Row9Col5;
                        objDynamicTableInput.Row9Col6 = CIRList.DynamicTableInputs.Row9Col6;
                        objDynamicTableInput.Row10Col5 = CIRList.DynamicTableInputs.Row10Col5;
                        objDynamicTableInput.Row10Col6 = CIRList.DynamicTableInputs.Row10Col6;
                    }
                    else
                    {
                        //code for dynamin flange
                        objDynamicTableInput.Row1Col1 = CIRList.DynamicTableInputs.Row1Col1;
                        objDynamicTableInput.Row2Col1 = CIRList.DynamicTableInputs.Row2Col1;
                        objDynamicTableInput.Row3Col1 = CIRList.DynamicTableInputs.Row3Col1;
                        objDynamicTableInput.Row4Col1 = CIRList.DynamicTableInputs.Row4Col1;
                        objDynamicTableInput.Row5Col1 = CIRList.DynamicTableInputs.Row5Col1;
                        objDynamicTableInput.Row6Col1 = CIRList.DynamicTableInputs.Row6Col1;
                        objDynamicTableInput.Row7Col1 = CIRList.DynamicTableInputs.Row7Col1;
                        objDynamicTableInput.Row8Col1 = CIRList.DynamicTableInputs.Row8Col1;
                        objDynamicTableInput.Row9Col1 = CIRList.DynamicTableInputs.Row9Col1;
                        objDynamicTableInput.Row10Col1 = CIRList.DynamicTableInputs.Row10Col1;
                        objDynamicTableInput.Row11Col1 = CIRList.DynamicTableInputs.Row11Col1;
                        objDynamicTableInput.Row12Col1 = CIRList.DynamicTableInputs.Row12Col1;
                        objDynamicTableInput.Row13Col1 = CIRList.DynamicTableInputs.Row13Col1;
                        objDynamicTableInput.Row14Col1 = CIRList.DynamicTableInputs.Row14Col1;

                        objDynamicTableInput.Row1Col2 = CIRList.DynamicTableInputs.Row1Col2;
                        objDynamicTableInput.Row2Col2 = CIRList.DynamicTableInputs.Row2Col2;
                        objDynamicTableInput.Row3Col2 = CIRList.DynamicTableInputs.Row3Col2;
                        objDynamicTableInput.Row4Col2 = CIRList.DynamicTableInputs.Row4Col2;
                        objDynamicTableInput.Row5Col2 = CIRList.DynamicTableInputs.Row5Col2;
                        objDynamicTableInput.Row6Col2 = CIRList.DynamicTableInputs.Row6Col2;
                        objDynamicTableInput.Row7Col2 = CIRList.DynamicTableInputs.Row7Col2;
                        objDynamicTableInput.Row8Col2 = CIRList.DynamicTableInputs.Row8Col2;
                        objDynamicTableInput.Row9Col2 = CIRList.DynamicTableInputs.Row9Col2;
                        objDynamicTableInput.Row10Col2 = CIRList.DynamicTableInputs.Row10Col2;
                        objDynamicTableInput.Row11Col2 = CIRList.DynamicTableInputs.Row11Col2;
                        objDynamicTableInput.Row12Col2 = CIRList.DynamicTableInputs.Row12Col2;
                        objDynamicTableInput.Row13Col2 = CIRList.DynamicTableInputs.Row13Col2;
                        objDynamicTableInput.Row14Col2 = CIRList.DynamicTableInputs.Row14Col2;

                        objDynamicTableInput.Row1Col3 = CIRList.DynamicTableInputs.Row1Col3;
                        objDynamicTableInput.Row2Col3 = CIRList.DynamicTableInputs.Row2Col3;
                        objDynamicTableInput.Row3Col3 = CIRList.DynamicTableInputs.Row3Col3;
                        objDynamicTableInput.Row4Col3 = CIRList.DynamicTableInputs.Row4Col3;
                        objDynamicTableInput.Row5Col3 = CIRList.DynamicTableInputs.Row5Col3;
                        objDynamicTableInput.Row6Col3 = CIRList.DynamicTableInputs.Row6Col3;
                        objDynamicTableInput.Row7Col3 = CIRList.DynamicTableInputs.Row7Col3;
                        objDynamicTableInput.Row8Col3 = CIRList.DynamicTableInputs.Row8Col3;
                        objDynamicTableInput.Row9Col3 = CIRList.DynamicTableInputs.Row9Col3;
                        objDynamicTableInput.Row10Col3 = CIRList.DynamicTableInputs.Row10Col3;
                        objDynamicTableInput.Row11Col3 = CIRList.DynamicTableInputs.Row11Col3;
                        objDynamicTableInput.Row12Col3 = CIRList.DynamicTableInputs.Row12Col3;
                        objDynamicTableInput.Row13Col3 = CIRList.DynamicTableInputs.Row13Col3;
                        objDynamicTableInput.Row14Col3 = CIRList.DynamicTableInputs.Row14Col3;

                        objDynamicTableInput.Row1Col4 = CIRList.DynamicTableInputs.Row1Col4;
                        objDynamicTableInput.Row2Col4 = CIRList.DynamicTableInputs.Row2Col4;
                        objDynamicTableInput.Row3Col4 = CIRList.DynamicTableInputs.Row3Col4;
                        objDynamicTableInput.Row4Col4 = CIRList.DynamicTableInputs.Row4Col4;
                        objDynamicTableInput.Row5Col4 = CIRList.DynamicTableInputs.Row5Col4;
                        objDynamicTableInput.Row6Col4 = CIRList.DynamicTableInputs.Row6Col4;
                        objDynamicTableInput.Row7Col4 = CIRList.DynamicTableInputs.Row7Col4;
                        objDynamicTableInput.Row8Col4 = CIRList.DynamicTableInputs.Row8Col4;
                        objDynamicTableInput.Row9Col4 = CIRList.DynamicTableInputs.Row9Col4;
                        objDynamicTableInput.Row10Col4 = CIRList.DynamicTableInputs.Row10Col4;
                        objDynamicTableInput.Row11Col4 = CIRList.DynamicTableInputs.Row11Col4;
                        objDynamicTableInput.Row12Col4 = CIRList.DynamicTableInputs.Row12Col4;
                        objDynamicTableInput.Row13Col4 = CIRList.DynamicTableInputs.Row13Col4;
                        objDynamicTableInput.Row14Col4 = CIRList.DynamicTableInputs.Row14Col4;

                        objDynamicTableInput.Row1Col5 = CIRList.DynamicTableInputs.Row1Col5;
                        objDynamicTableInput.Row2Col5 = CIRList.DynamicTableInputs.Row2Col5;
                        objDynamicTableInput.Row3Col5 = CIRList.DynamicTableInputs.Row3Col5;
                        objDynamicTableInput.Row4Col5 = CIRList.DynamicTableInputs.Row4Col5;
                        objDynamicTableInput.Row5Col5 = CIRList.DynamicTableInputs.Row5Col5;
                        objDynamicTableInput.Row6Col5 = CIRList.DynamicTableInputs.Row6Col5;
                        objDynamicTableInput.Row7Col5 = CIRList.DynamicTableInputs.Row7Col5;
                        objDynamicTableInput.Row8Col5 = CIRList.DynamicTableInputs.Row8Col5;
                        objDynamicTableInput.Row9Col5 = CIRList.DynamicTableInputs.Row9Col5;
                        objDynamicTableInput.Row10Col5 = CIRList.DynamicTableInputs.Row10Col5;
                        objDynamicTableInput.Row11Col5 = CIRList.DynamicTableInputs.Row11Col5;
                        objDynamicTableInput.Row12Col5 = CIRList.DynamicTableInputs.Row12Col5;
                        objDynamicTableInput.Row13Col5 = CIRList.DynamicTableInputs.Row13Col5;
                        objDynamicTableInput.Row14Col5 = CIRList.DynamicTableInputs.Row14Col5;

                        objDynamicTableInput.Row1Col6 = CIRList.DynamicTableInputs.Row1Col6;
                        objDynamicTableInput.Row2Col6 = CIRList.DynamicTableInputs.Row2Col6;
                        objDynamicTableInput.Row3Col6 = CIRList.DynamicTableInputs.Row3Col6;
                        objDynamicTableInput.Row4Col6 = CIRList.DynamicTableInputs.Row4Col6;
                        objDynamicTableInput.Row5Col6 = CIRList.DynamicTableInputs.Row5Col6;
                        objDynamicTableInput.Row6Col6 = CIRList.DynamicTableInputs.Row6Col6;
                        objDynamicTableInput.Row7Col6 = CIRList.DynamicTableInputs.Row7Col6;
                        objDynamicTableInput.Row8Col6 = CIRList.DynamicTableInputs.Row8Col6;
                        objDynamicTableInput.Row9Col6 = CIRList.DynamicTableInputs.Row9Col6;
                        objDynamicTableInput.Row10Col6 = CIRList.DynamicTableInputs.Row10Col6;
                        objDynamicTableInput.Row11Col6 = CIRList.DynamicTableInputs.Row11Col6;
                        objDynamicTableInput.Row12Col6 = CIRList.DynamicTableInputs.Row12Col6;
                        objDynamicTableInput.Row13Col6 = CIRList.DynamicTableInputs.Row13Col6;
                        objDynamicTableInput.Row14Col6 = CIRList.DynamicTableInputs.Row14Col6;

                        if (CIRList.DyanamicDecisionData != null)
                        {
                            foreach (DyanamicDecision obj in CIRList.DyanamicDecisionData)
                            {
                                Edmx.DynamicDecisionDetails objDynamicDecision = context.DynamicDecisionDetails.FirstOrDefault(x => x.CirId == CIRList.ComponentInspectionReportId && x.FlangNo == obj.FlangNo);
                                if (objDynamicDecision != null)
                                {
                                    objDynamicDecision.Decision = obj.Decision;
                                    objDynamicDecision.AffectedBolts = obj.AffectedBolts;
                                    objDynamicDecision.ImidiateActions = obj.ImidiateActions;
                                    objDynamicDecision.RepeatedInspections = obj.RepeatedInspections;
                                    objDynamicDecision.UpdatedDate = System.DateTime.UtcNow.Date;
                                    objDynamicDecision.CreatedDate = System.DateTime.UtcNow.Date;
                                    objDynamicDecision.FlangeDamageIdentified = obj.FlangeDamageIdentified;
                                    objDynamicDecision.InspectionDesc = obj.InspectionDesc;
                                    context.SaveChanges();
                                }
                            }
                        }
                    }//end of else 
                    context.SaveChanges();
                }
                else
                {
                    if (CIRList.ComponentInspectionReportTypeId != 8)
                    {
                        objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.DynamicTableInputs.CirId,
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                        };
                        context.DynamicTableInput.Add(objDynamicTableInput);
                    }
                    else
                    {
                        objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.DynamicTableInputs.CirId,
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row11Col1 = CIRList.DynamicTableInputs.Row11Col1,
                            Row12Col1 = CIRList.DynamicTableInputs.Row12Col1,
                            Row13Col1 = CIRList.DynamicTableInputs.Row13Col1,
                            Row14Col1 = CIRList.DynamicTableInputs.Row14Col1,

                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row11Col2 = CIRList.DynamicTableInputs.Row11Col2,
                            Row12Col2 = CIRList.DynamicTableInputs.Row12Col2,
                            Row13Col2 = CIRList.DynamicTableInputs.Row13Col2,
                            Row14Col2 = CIRList.DynamicTableInputs.Row14Col2,

                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row11Col3 = CIRList.DynamicTableInputs.Row11Col3,
                            Row12Col3 = CIRList.DynamicTableInputs.Row12Col3,
                            Row13Col3 = CIRList.DynamicTableInputs.Row13Col3,
                            Row14Col3 = CIRList.DynamicTableInputs.Row14Col3,

                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row11Col4 = CIRList.DynamicTableInputs.Row11Col4,
                            Row12Col4 = CIRList.DynamicTableInputs.Row12Col4,
                            Row13Col4 = CIRList.DynamicTableInputs.Row13Col4,
                            Row14Col4 = CIRList.DynamicTableInputs.Row14Col4,

                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row11Col5 = CIRList.DynamicTableInputs.Row11Col5,
                            Row12Col5 = CIRList.DynamicTableInputs.Row12Col5,
                            Row13Col5 = CIRList.DynamicTableInputs.Row13Col5,
                            Row14Col5 = CIRList.DynamicTableInputs.Row14Col5,

                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                            Row11Col6 = CIRList.DynamicTableInputs.Row11Col6,
                            Row12Col6 = CIRList.DynamicTableInputs.Row12Col6,
                            Row13Col6 = CIRList.DynamicTableInputs.Row13Col6,
                            Row14Col6 = CIRList.DynamicTableInputs.Row14Col6
                        };
                        context.DynamicTableInput.Add(objDynamicTableInput);
                        //Add dyanamicdecision data
                        if (CIRList.DyanamicDecisionData != null)
                        {
                            foreach (DyanamicDecision obj in CIRList.DyanamicDecisionData)
                            {
                                // context.DynamicDecisionDetails.Add(new Edmx.DynamicDecisionDetails { AffectedBolts = obj.AffectedBolts, CirId = CIRList.ComponentInspectionReportId, Decision = obj.Decision, FlangNo = obj.FlangNo, ImidiateActions = obj.ImidiateActions, IsDeleted = false, RepeatedInspections = obj.RepeatedInspections, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow });
                                Edmx.DynamicDecisionDetails objDyanamicDecisionData = new Edmx.DynamicDecisionDetails()
                                {
                                    AffectedBolts = obj.AffectedBolts,
                                    CirId = CIRList.ComponentInspectionReportId,
                                    Decision = obj.Decision,
                                    FlangNo = obj.FlangNo,
                                    ImidiateActions = obj.ImidiateActions,
                                    IsDeleted = false,
                                    RepeatedInspections = obj.RepeatedInspections,
                                    InspectionDesc = obj.InspectionDesc,
                                    UpdatedDate = System.DateTime.UtcNow.Date,
                                    CreatedDate = System.DateTime.UtcNow.Date,
                                    FlangeDamageIdentified = obj.FlangeDamageIdentified
                                };
                                context.DynamicDecisionDetails.Add(objDyanamicDecisionData);
                            }
                        }

                    }
                }
                context.SaveChanges();
            }

            #endregion

            #region Supplier Notification                      

            if (CIRList.ComponentInspectionReportId < hdnCirId && CIRListUp.ReportTypeId != 2 && CIRList.ReportTypeId == 2)
            {
                //Notification GENERATOR = 4, GEARBOX = 2, BLADE = 1,TRANSFORMER = 5 AND ReportType is of Type = FAILURE
                List<long> NotificationFor = new List<long> { 1, 2, 4, 5 };
                //if ((NotificationFor.Contains(CIRList.ComponentInspectionReportTypeId) && CIRList.ReportTypeId == 2) &&
                //    (CIRList.ComponentInspectionReportTypeId != 2 || CIRList.Gearbox == null) && CIRList.Gearbox.GearboxAuxEquipmentId == 1)
                if (NotificationFor.Contains(CIRList.ComponentInspectionReportTypeId) && CIRList.ReportTypeId == 2 && ((CIRList.ComponentInspectionReportTypeId == 2 && CIRList.Gearbox != null && CIRList.Gearbox.GearboxAuxEquipmentId == 1)
                    || (CIRList.ComponentInspectionReportTypeId == 5 && CIRList.Transformer != null && CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId == 1)
                || (CIRList.ComponentInspectionReportTypeId == 4 && CIRList.Generator != null && CIRList.MountedOnMainComponentBooleanAnswerId == 1) ||
                (CIRList.ComponentInspectionReportTypeId == 1 && CIRList.BladeData != null && CIRList.MountedOnMainComponentBooleanAnswerId == 1)))
                {
                    try
                    {
                        DANotification da = new DANotification();
                        da.SendNotification(DANotification.NotificationType.FirstNotification, CIRList.CirDataID);
                        FirstNotificationData firstNotificationData = da.FirstNotifications(CIRList.CirDataID, CIRList.ComponentInspectionReportId);
                        da.SendNotifications(firstNotificationData);
                        DACIRLog.SaveCirLog(objCirData.CirDataId, "First Notification sent to Manufacturer", LogType.Information, objCirData.ModifiedBy);
                    }
                    catch (Exception oException)
                    {

                        string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                        string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending First Notification after inserting new CIR [CIRID = " + CIRList.ComponentInspectionReportId + "]" + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                        // DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send First Notification sent to Manufacturer due to Error ", LogType.Information, objCirData.ModifiedBy);
                    }
                }
            }

            #endregion

            try
            {
                if (CIRList.ComponentInspectionReportId < hdnCirId)
                {
                    DASendCIRUpdateNotification das = new DASendCIRUpdateNotification();
                    das.SendMail(CIRList.ComponentInspectionReportId, cirname, CIRList.CurrentUser, 2);
                    DACIRLog.SaveCirLog(objCirData.CirDataId, "Update CIR Notification sent to the User", LogType.Information, objCirData.ModifiedBy);
                }
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Email to user after updating new CIR " + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send Email to user after updating new CIR ", LogType.Information, objCirData.ModifiedBy);
            }
            return CIRList.ComponentInspectionReportId;
        }
        /// <summary>
        /// Get cir data by ID
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static CIR.ComponentInspectionReport GetCIRDatabyCIRID(Int64 CIRID)
        {
            CIR.ComponentInspectionReport objComp = new CIR.ComponentInspectionReport();
            Edmx.ComponentInspectionReport CIRListUp = null;
            CIR.TurbineProperties objTurbine = new TurbineProperties();
            string responseString = string.Empty;
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    /*Finding the CIR value exist in database or not */
                    CIRListUp = (from s in context.ComponentInspectionReport
                                 where s.ComponentInspectionReportId == CIRID
                                 select s).FirstOrDefault();

                    objTurbine = GetTurbineRecord(CIRListUp.TurbineNumber.ToString(), context);

                    if (!ReferenceEquals(CIRListUp, null) && CIRListUp.ComponentInspectionReportId > 0)
                    {
                        var cirData = context.CirData.Where(x => x.CirId == CIRListUp.ComponentInspectionReportId && x.Deleted == false).OrderByDescending(x => x.CirDataId).FirstOrDefault();
                        var cirname = cirData.Filename;

                        #region CIR Com Report
                        /* Assign value to CIR Report Entity */
                        objComp.CirDataID = cirData.CirDataId;
                        objComp.TemplateVersion = CIRListUp.TemplateVersion;
                        objComp.TurbineData = objTurbine;
                        objComp.ComponentInspectionReportId = CIRListUp.ComponentInspectionReportId;
                        objComp.ComponentInspectionReportName = (CIRListUp.ComponentInspectionReportName == null) ? cirname : CIRListUp.ComponentInspectionReportName;
                        objComp.ComponentInspectionReportTypeId = CIRListUp.ComponentInspectionReportTypeId;
                        objComp.ComponentInspectionReportStateId = cirData.State; //CIRListUp.ComponentInspectionReportStateId;
                        objComp.ReportTypeId = CIRListUp.ReportTypeId;
                        objComp.ReconstructionBooleanAnswerId = CIRListUp.ReconstructionBooleanAnswerId;
                        objComp.CIMCaseNumber = CIRListUp.CIMCaseNumber;
                        objComp.ReasonForService = CIRListUp.ReasonForService;
                        objComp.TurbineNumber = CIRListUp.TurbineNumber;
                        objComp.CountryISOId = CIRListUp.CountryISOId;
                        objComp.SiteName = CIRListUp.SiteName;
                        objComp.TurbineMatrixId = 0;
                        objComp.LocationTypeId = CIRListUp.LocationTypeId;
                        objComp.LocalTurbineId = objTurbine.LocalTurbineId;
                        objComp.Country = objTurbine.Country;
                        objComp.TurbineType = objTurbine.Turbine;
                        objComp.SecondGeneratorBooleanAnswerId = CIRListUp.SecondGeneratorBooleanAnswerId;
                        objComp.BeforeInspectionTurbineRunStatusId = CIRListUp.BeforeInspectionTurbineRunStatusId;
                        objComp.CommisioningDate = CIRListUp.CommisioningDate;
                        objComp.InstallationDate = CIRListUp.InstallationDate;
                        objComp.FailureDate = Convert.ToDateTime(CIRListUp.FailureDate);
                        objComp.InspectionDate = CIRListUp.InspectionDate;
                        objComp.ServiceReportNumber = CIRListUp.ServiceReportNumber;
                        objComp.ServiceReportNumberTypeId = CIRListUp.ServiceReportNumberTypeId;
                        objComp.ServiceEngineer = CIRListUp.ServiceEngineer;
                        objComp.RunHours = CIRListUp.RunHours;
                        objComp.Generator1Hrs = CIRListUp.Generator1Hrs;
                        objComp.Generator2Hrs = CIRListUp.Generator2Hrs;
                        objComp.TotalProduction = CIRListUp.TotalProduction;
                        objComp.AfterInspectionTurbineRunStatusId = CIRListUp.AfterInspectionTurbineRunStatusId;
                        objComp.Quantity = CIRListUp.Quantity;
                        objComp.AlarmLogNumber = CIRListUp.AlarmLogNumber;
                        objComp.Description = CIRListUp.Description;
                        objComp.DescriptionConsquential = CIRListUp.DescriptionConsquential;
                        objComp.ConductedBy = CIRListUp.ConductedBy;
                        objComp.SBUId = CIRListUp.SBUId;
                        objComp.CIRTemplateGUID = CIRListUp.CIRTemplateGUID;
                        objComp.VestasItemNumber = CIRListUp.VestasItemNumber;
                        objComp.NotificationNumber = CIRListUp.NotificationNumber;
                        objComp.MountedOnMainComponentBooleanAnswerId = CIRListUp.MountedOnMainComponentBooleanAnswerId;
                        objComp.ComponentUpTowerSolutionID = CIRListUp.ComponentUpTowerSolutionID;
                        objComp.AdditionalComments = CIRListUp.AdditionalInfo;
                        objComp.InternalComments = CIRListUp.InternalComments;
                        objComp.SBURecomendation = CIRListUp.SBURecommendation;
                        objComp.FlangDesc = CIRListUp.FlangDescription;
                        objComp.FormIOGUID = CIRListUp.FormIOGUID;
                        objComp.Brand = CIRListUp.Brand;
                        objComp.OutSideSign = CIRListUp.OutSideSign == null ? false : CIRListUp.OutSideSign.Value;
                        objComp.CreatedBy = cirData.CreatedBy;
                        objComp.ModifiedBy = cirData.ModifiedBy;
                        objComp.Created = cirData.Created;
                        objComp.Modified = cirData.Modified;
                        //New Code Added for to fix Cir Migration Log Issue
                        List<Edmx.CIRMigrationLog> objMigLog = context.CIRMigrationLog.Where(x => x.CirDataId == cirData.CirDataId && x.IsCorrected == null).ToList();
                        if (objMigLog == null)
                            objComp.HtmlStr = "No Record found in CirMigrationLogTable for this CirId";
                        else
                            objComp.HtmlStr = objMigLog.Select(x => x.ErrorMessage).FirstOrDefault();
                        #endregion
                        #region Component Inspection Report Blade
                        /* Assign value to CIR Report Blade Entity */
                        Edmx.ComponentInspectionReportBlade objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRID).FirstOrDefault();
                        objComp.BladeData = new CIR.ComponentInspectionReportBlade();
                        if (null != objCompBlade)
                        {
                            objComp.BladeData.BladeManufacturerId = objCompBlade.BladeManufacturerId;
                            objComp.BladeData.VestasUniqueIdentifier = objCompBlade.VestasUniqueIdentifier;
                            objComp.BladeData.BladeLengthId = objCompBlade.BladeLengthId;
                            objComp.BladeData.BladeColorId = objCompBlade.BladeColorId;
                            objComp.BladeData.BladeSerialNumber = objCompBlade.BladeSerialNumber;
                            objComp.BladeData.BladePicturesIncludedBooleanAnswerId = objCompBlade.BladePicturesIncludedBooleanAnswerId;
                            objComp.BladeData.BladeOtherSerialNumber1 = objCompBlade.BladeOtherSerialNumber1;
                            objComp.BladeData.BladeOtherSerialNumber2 = objCompBlade.BladeOtherSerialNumber2;
                            objComp.BladeData.BladeDamageIdentified = objCompBlade.BladeDamageIdentified;
                            objComp.BladeData.BladeFaultCodeClassificationId = objCompBlade.BladeFaultCodeClassificationId;
                            objComp.BladeData.BladeFaultCodeCauseId = objCompBlade.BladeFaultCodeCauseId;
                            objComp.BladeData.BladeFaultCodeTypeId = objCompBlade.BladeFaultCodeTypeId;
                            objComp.BladeData.BladeFaultCodeAreaId = objCompBlade.BladeFaultCodeAreaId;
                            objComp.BladeData.BladeClaimRelevantBooleanAnswerId = objCompBlade.BladeClaimRelevantBooleanAnswerId;
                            objComp.BladeData.BladeLsVtNumber = objCompBlade.BladeLsVtNumber;
                            objComp.BladeData.BladeLsCalibrationDate = ParseDatetime(objCompBlade.BladeLsCalibrationDate);
                            objComp.BladeData.BladeLsLeewardSidePreRepairTip = objCompBlade.BladeLsLeewardSidePreRepairTip;
                            objComp.BladeData.BladeLsLeewardSidePostRepairTip = objCompBlade.BladeLsLeewardSidePostRepairTip;
                            objComp.BladeData.BladeLsLeewardSidePreRepair2 = objCompBlade.BladeLsLeewardSidePreRepair2;
                            objComp.BladeData.BladeLsLeewardSidePostRepair2 = objCompBlade.BladeLsLeewardSidePostRepair2;
                            objComp.BladeData.BladeLsLeewardSidePreRepair3 = objCompBlade.BladeLsLeewardSidePreRepair3;
                            objComp.BladeData.BladeLsLeewardSidePostRepair3 = objCompBlade.BladeLsLeewardSidePostRepair3;
                            objComp.BladeData.BladeLsLeewardSidePreRepair4 = objCompBlade.BladeLsLeewardSidePreRepair4;
                            objComp.BladeData.BladeLsLeewardSidePostRepair4 = objCompBlade.BladeLsLeewardSidePostRepair4;
                            objComp.BladeData.BladeLsLeewardSidePreRepair5 = objCompBlade.BladeLsLeewardSidePreRepair5;
                            objComp.BladeData.BladeLsLeewardSidePostRepair5 = objCompBlade.BladeLsLeewardSidePostRepair5;

                            objComp.BladeData.BladeLsLeewardSidePreRepair6 = objCompBlade.BladeLsLeewardSidePreRepair6;
                            objComp.BladeData.BladeLsLeewardSidePostRepair6 = objCompBlade.BladeLsLeewardSidePostRepair6;
                            objComp.BladeData.BladeLsLeewardSidePreRepair7 = objCompBlade.BladeLsLeewardSidePreRepair7;
                            objComp.BladeData.BladeLsLeewardSidePostRepair7 = objCompBlade.BladeLsLeewardSidePostRepair7;
                            objComp.BladeData.BladeLsLeewardSidePreRepair8 = objCompBlade.BladeLsLeewardSidePreRepair8;
                            objComp.BladeData.BladeLsLeewardSidePostRepair8 = objCompBlade.BladeLsLeewardSidePostRepair8;

                            objComp.BladeData.BladeLsWindwardSidePreRepairTip = objCompBlade.BladeLsWindwardSidePreRepairTip;
                            objComp.BladeData.BladeLsWindwardSidePostRepairTip = objCompBlade.BladeLsWindwardSidePostRepairTip;
                            objComp.BladeData.BladeLsWindwardSidePreRepair2 = objCompBlade.BladeLsWindwardSidePreRepair2;
                            objComp.BladeData.BladeLsWindwardSidePostRepair2 = objCompBlade.BladeLsWindwardSidePostRepair2;
                            objComp.BladeData.BladeLsWindwardSidePreRepair3 = objCompBlade.BladeLsWindwardSidePreRepair3;
                            objComp.BladeData.BladeLsWindwardSidePostRepair3 = objCompBlade.BladeLsWindwardSidePostRepair3;
                            objComp.BladeData.BladeLsWindwardSidePreRepair4 = objCompBlade.BladeLsWindwardSidePreRepair4;
                            objComp.BladeData.BladeLsWindwardSidePostRepair4 = objCompBlade.BladeLsWindwardSidePostRepair4;
                            objComp.BladeData.BladeLsWindwardSidePreRepair5 = objCompBlade.BladeLsWindwardSidePreRepair5;
                            objComp.BladeData.BladeLsWindwardSidePostRepair5 = objCompBlade.BladeLsWindwardSidePostRepair5;

                            objComp.BladeData.BladeLsWindwardSidePreRepair6 = objCompBlade.BladeLsWindwardSidePreRepair6;
                            objComp.BladeData.BladeLsWindwardSidePostRepair6 = objCompBlade.BladeLsWindwardSidePostRepair6;
                            objComp.BladeData.BladeLsWindwardSidePreRepair7 = objCompBlade.BladeLsWindwardSidePreRepair7;
                            objComp.BladeData.BladeLsWindwardSidePostRepair7 = objCompBlade.BladeLsWindwardSidePostRepair7;
                            objComp.BladeData.BladeLsWindwardSidePreRepair8 = objCompBlade.BladeLsWindwardSidePreRepair8;
                            objComp.BladeData.BladeLsWindwardSidePostRepair8 = objCompBlade.BladeLsWindwardSidePostRepair8;

                            objComp.BladeData.BladeInspectionReportDescription = objCompBlade.BladeInspectionReportDescription;
                            objComp.BladeData.BladeManufacturerId = objCompBlade.BladeManufacturerId;
                            if (objCompBlade.ComponentInspectionReportBladeRepairRecord != null && objComp.ReportTypeId == 3)
                            {
                                objComp.BladeData.RepairRecordData = new CIR.ComponentInspectionReportBladeRepairRecord();
                                //Edmx.ComponentInspectionReportBladeRepairRecord objCompBladeRepairRecord = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault().ComponentInspectionReportBladeRepairRecord.FirstOrDefault();
                                if (CIRListUp.ComponentInspectionReportBlade != null && CIRListUp.ComponentInspectionReportBlade.Count > 0)
                                {
                                    Edmx.ComponentInspectionReportBladeRepairRecord objCompBladeRepairRecord = CIRListUp.ComponentInspectionReportBlade.First().ComponentInspectionReportBladeRepairRecord.FirstOrDefault();
                                    if (objCompBladeRepairRecord != null)
                                    {
                                        objComp.BladeData.RepairRecordData.BladeAmbientTemp = objCompBladeRepairRecord.BladeAmbientTemp;
                                        objComp.BladeData.RepairRecordData.BladeHumidity = objCompBladeRepairRecord.BladeHumidity;
                                        objComp.BladeData.RepairRecordData.BladeAdditionalDocumentReference = objCompBladeRepairRecord.BladeAdditionalDocumentReference;
                                        objComp.BladeData.RepairRecordData.BladeResinType = objCompBladeRepairRecord.BladeResinType;
                                        objComp.BladeData.RepairRecordData.BladeResinTypeBatchNumbers = objCompBladeRepairRecord.BladeResinTypeBatchNumbers;
                                        objComp.BladeData.RepairRecordData.BladeResinTypeExpiryDate = ParseDatetime(objCompBladeRepairRecord.BladeResinTypeExpiryDate);
                                        objComp.BladeData.RepairRecordData.BladeHardenerType = objCompBladeRepairRecord.BladeHardenerType;
                                        objComp.BladeData.RepairRecordData.BladeHardenerTypeBatchNumbers = objCompBladeRepairRecord.BladeHardenerTypeBatchNumbers;
                                        objComp.BladeData.RepairRecordData.BladeHardenerTypeExpiryDate = ParseDatetime(objCompBladeRepairRecord.BladeHardenerTypeExpiryDate);
                                        objComp.BladeData.RepairRecordData.BladeGlassSupplier = objCompBladeRepairRecord.BladeGlassSupplier;
                                        objComp.BladeData.RepairRecordData.BladeGlassSupplierBatchNumbers = objCompBladeRepairRecord.BladeGlassSupplierBatchNumbers;
                                        objComp.BladeData.RepairRecordData.BladeSurfaceMaxTemperature = objCompBladeRepairRecord.BladeSurfaceMaxTemperature;
                                        objComp.BladeData.RepairRecordData.BladeSurfaceMinTemperature = objCompBladeRepairRecord.BladeSurfaceMinTemperature;
                                        objComp.BladeData.RepairRecordData.BladeResinUsed = objCompBladeRepairRecord.BladeResinUsed;
                                        objComp.BladeData.RepairRecordData.BladePostCureMaxTemperature = objCompBladeRepairRecord.BladePostCureMaxTemperature;
                                        objComp.BladeData.RepairRecordData.BladePostCureMinTemperature = objCompBladeRepairRecord.BladePostCureMinTemperature;
                                        objComp.BladeData.RepairRecordData.BladeTurnOffTime = ParseDatetime(objCompBladeRepairRecord.BladeTurnOffTime);
                                        objComp.BladeData.RepairRecordData.BladeTotalCureTime = objCompBladeRepairRecord.BladeTotalCureTime;
                                    }
                                }
                            }

                        }
                        #endregion
                        #region Component Inspection Report Gearbox
                        /* Assign value to CIR Report Gear Entity */
                        Edmx.ComponentInspectionReportGearbox objCompoGear = CIRListUp.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                        if (null != objCompoGear)
                        {
                            objComp.Gearbox = new CIR.ComponentInspectionReportGearbox();
                            objComp.Gearbox.VestasUniqueIdentifier = objCompoGear.VestasUniqueIdentifier;
                            objComp.Gearbox.GearboxTypeId = objCompoGear.GearboxTypeId;
                            objComp.Gearbox.GearboxRevisionId = objCompoGear.GearboxRevisionId;
                            objComp.Gearbox.GearboxManufacturerId = objCompoGear.GearboxManufacturerId;
                            objComp.Gearbox.OtherGearboxType = objCompoGear.OtherGearboxType;
                            objComp.Gearbox.GearboxSerialNumber = objCompoGear.GearboxSerialNumber;
                            objComp.Gearbox.GearboxOtherManufacturer = objCompoGear.GearboxOtherManufacturer;
                            if (objCompoGear.GearboxLastOilChangeDate != null)
                                objComp.Gearbox.GearboxLastOilChangeDate = Convert.ToDateTime(objCompoGear.GearboxLastOilChangeDate);
                            objComp.Gearbox.GearboxOilTypeId = objCompoGear.GearboxOilTypeId;
                            objComp.Gearbox.GearboxMechanicalOilPumpId = objCompoGear.GearboxMechanicalOilPumpId;
                            objComp.Gearbox.GearboxOilLevelId = objCompoGear.GearboxOilLevelId;
                            objComp.Gearbox.GearboxRunHours = objCompoGear.GearboxRunHours;
                            objComp.Gearbox.GearboxOilTemperature = objCompoGear.GearboxOilTemperature;
                            objComp.Gearbox.GearboxProduction = objCompoGear.GearboxProduction;
                            objComp.Gearbox.GearboxGeneratorManufacturerId = objCompoGear.GearboxGeneratorManufacturerId;
                            objComp.Gearbox.GearboxGeneratorManufacturerId2 = objCompoGear.GearboxGeneratorManufacturerId2;
                            objComp.Gearbox.GearboxElectricalPumpId = objCompoGear.GearboxElectricalPumpId;
                            objComp.Gearbox.GearboxShrinkElementId = objCompoGear.GearboxShrinkElementId;
                            objComp.Gearbox.GearboxShrinkElementSerialNumber = objCompoGear.GearboxShrinkElementSerialNumber;
                            objComp.Gearbox.GearboxCouplingId = objCompoGear.GearboxCouplingId;
                            objComp.Gearbox.GearboxFilterBlockTypeId = objCompoGear.GearboxFilterBlockTypeId;
                            objComp.Gearbox.GearboxInLineFilterId = objCompoGear.GearboxInLineFilterId;
                            objComp.Gearbox.GearboxOffLineFilterId = objCompoGear.GearboxOffLineFilterId;
                            objComp.Gearbox.GearboxSoftwareRelease = objCompoGear.GearboxSoftwareRelease;
                            objComp.Gearbox.GearboxShaftsExactLocation1ShaftTypeId = objCompoGear.GearboxShaftsExactLocation1ShaftTypeId;
                            objComp.Gearbox.GearboxShaftsExactLocation2ShaftTypeId = objCompoGear.GearboxShaftsExactLocation2ShaftTypeId;
                            objComp.Gearbox.GearboxShaftsExactLocation3ShaftTypeId = objCompoGear.GearboxShaftsExactLocation3ShaftTypeId;
                            objComp.Gearbox.GearboxShaftsExactLocation4ShaftTypeId = objCompoGear.GearboxShaftsExactLocation4ShaftTypeId;
                            objComp.Gearbox.GearboxShaftsTypeofDamage1ShaftErrorId = objCompoGear.GearboxShaftsTypeofDamage1ShaftErrorId;
                            objComp.Gearbox.GearboxShaftsTypeofDamage2ShaftErrorId = objCompoGear.GearboxShaftsTypeofDamage2ShaftErrorId;
                            objComp.Gearbox.GearboxShaftsTypeofDamage3ShaftErrorId = objCompoGear.GearboxShaftsTypeofDamage3ShaftErrorId;
                            objComp.Gearbox.GearboxShaftsTypeofDamage4ShaftErrorId = objCompoGear.GearboxShaftsTypeofDamage4ShaftErrorId;
                            objComp.Gearbox.GearboxExactLocation1GearTypeId = objCompoGear.GearboxExactLocation1GearTypeId;
                            objComp.Gearbox.GearboxExactLocation2GearTypeId = objCompoGear.GearboxExactLocation2GearTypeId;
                            objComp.Gearbox.GearboxExactLocation3GearTypeId = objCompoGear.GearboxExactLocation3GearTypeId;
                            objComp.Gearbox.GearboxExactLocation4GearTypeId = objCompoGear.GearboxExactLocation4GearTypeId;
                            objComp.Gearbox.GearboxExactLocation5GearTypeId = objCompoGear.GearboxExactLocation5GearTypeId;
                            objComp.Gearbox.GearboxTypeofDamage1GearErrorId = objCompoGear.GearboxTypeofDamage1GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage2GearErrorId = objCompoGear.GearboxTypeofDamage2GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage3GearErrorId = objCompoGear.GearboxTypeofDamage3GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage4GearErrorId = objCompoGear.GearboxTypeofDamage4GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage5GearErrorId = objCompoGear.GearboxTypeofDamage5GearErrorId;
                            objComp.Gearbox.GearboxBearingsLocation1BearingTypeId = objCompoGear.GearboxBearingsLocation1BearingTypeId;
                            objComp.Gearbox.GearboxBearingsLocation2BearingTypeId = objCompoGear.GearboxBearingsLocation2BearingTypeId;
                            objComp.Gearbox.GearboxBearingsLocation3BearingTypeId = objCompoGear.GearboxBearingsLocation3BearingTypeId;
                            objComp.Gearbox.GearboxBearingsLocation4BearingTypeId = objCompoGear.GearboxBearingsLocation4BearingTypeId;
                            objComp.Gearbox.GearboxBearingsLocation5BearingTypeId = objCompoGear.GearboxBearingsLocation5BearingTypeId;
                            objComp.Gearbox.GearboxBearingsPosition1BearingPosId = objCompoGear.GearboxBearingsPosition1BearingPosId;
                            objComp.Gearbox.GearboxBearingsPosition2BearingPosId = objCompoGear.GearboxBearingsPosition2BearingPosId;
                            objComp.Gearbox.GearboxBearingsPosition3BearingPosId = objCompoGear.GearboxBearingsPosition3BearingPosId;
                            objComp.Gearbox.GearboxBearingsPosition4BearingPosId = objCompoGear.GearboxBearingsPosition4BearingPosId;
                            objComp.Gearbox.GearboxBearingsPosition5BearingPosId = objCompoGear.GearboxBearingsPosition5BearingPosId;
                            objComp.Gearbox.GearboxBearingsDamage1BearingErrorId = objCompoGear.GearboxBearingsDamage1BearingErrorId;
                            objComp.Gearbox.GearboxBearingsDamage2BearingErrorId = objCompoGear.GearboxBearingsDamage2BearingErrorId;
                            objComp.Gearbox.GearboxBearingsDamage3BearingErrorId = objCompoGear.GearboxBearingsDamage3BearingErrorId;
                            objComp.Gearbox.GearboxBearingsDamage4BearingErrorId = objCompoGear.GearboxBearingsDamage4BearingErrorId;
                            objComp.Gearbox.GearboxBearingsDamage5BearingErrorId = objCompoGear.GearboxBearingsDamage5BearingErrorId;
                            objComp.Gearbox.GearboxPlanetStage1HousingErrorId = objCompoGear.GearboxPlanetStage1HousingErrorId;
                            objComp.Gearbox.GearboxPlanetStage2HousingErrorId = objCompoGear.GearboxPlanetStage2HousingErrorId;
                            objComp.Gearbox.GearboxHelicalStageHousingErrorId = objCompoGear.GearboxHelicalStageHousingErrorId;
                            objComp.Gearbox.GearboxFrontPlateHousingErrorId = objCompoGear.GearboxFrontPlateHousingErrorId;
                            objComp.Gearbox.GearboxAuxStageHousingErrorId = objCompoGear.GearboxAuxStageHousingErrorId;
                            objComp.Gearbox.GearboxHSStageHousingErrorId = objCompoGear.GearboxHSStageHousingErrorId;
                            objComp.Gearbox.GearboxLooseBolts = objCompoGear.GearboxLooseBolts;
                            objComp.Gearbox.GearboxBrokenBolts = objCompoGear.GearboxBrokenBolts;
                            objComp.Gearbox.GearboxDefectDamperElements = objCompoGear.GearboxDefectDamperElements;
                            objComp.Gearbox.GearboxTooMuchClearance = objCompoGear.GearboxTooMuchClearance;
                            objComp.Gearbox.GearboxCrackedTorqueArm = objCompoGear.GearboxCrackedTorqueArm;
                            objComp.Gearbox.GearboxNeedsToBeAligned = objCompoGear.GearboxNeedsToBeAligned;
                            objComp.Gearbox.GearboxPT100Bearing1 = objCompoGear.GearboxPT100Bearing1;
                            objComp.Gearbox.GearboxPT100Bearing2 = objCompoGear.GearboxPT100Bearing2;
                            objComp.Gearbox.GearboxPT100Bearing3 = objCompoGear.GearboxPT100Bearing3;
                            objComp.Gearbox.GearboxOilLevelSensor = objCompoGear.GearboxOilLevelSensor;
                            objComp.Gearbox.GearboxOilPressure = objCompoGear.GearboxOilPressure;
                            objComp.Gearbox.GearboxPT100OilSump = objCompoGear.GearboxPT100OilSump;
                            objComp.Gearbox.GearboxFilterIndicator = objCompoGear.GearboxFilterIndicator;
                            objComp.Gearbox.GearboxImmersionHeater = objCompoGear.GearboxImmersionHeater;
                            objComp.Gearbox.GearboxDrainValve = objCompoGear.GearboxDrainValve;
                            objComp.Gearbox.GearboxAirBreather = objCompoGear.GearboxAirBreather;
                            objComp.Gearbox.GearboxSightGlass = objCompoGear.GearboxSightGlass;
                            objComp.Gearbox.GearboxChipDetector = objCompoGear.GearboxChipDetector;
                            objComp.Gearbox.GearboxVibrationsId = objCompoGear.GearboxVibrationsId;
                            objComp.Gearbox.GearboxNoiseId = objCompoGear.GearboxNoiseId;
                            objComp.Gearbox.GearboxDebrisOnMagnetId = objCompoGear.GearboxDebrisOnMagnetId;
                            objComp.Gearbox.GearboxDebrisStagesMagnetPosId = objCompoGear.GearboxDebrisStagesMagnetPosId;
                            objComp.Gearbox.GearboxDebrisGearBoxId = objCompoGear.GearboxDebrisGearBoxId;
                            if (objCompoGear.GearboxMaxTempResetDate != null)
                            {
                                objComp.Gearbox.GearboxMaxTempResetDate = Convert.ToDateTime(objCompoGear.GearboxMaxTempResetDate);
                            }
                            objComp.Gearbox.GearboxTempBearing1 = objCompoGear.GearboxTempBearing1;
                            objComp.Gearbox.GearboxTempBearing2 = objCompoGear.GearboxTempBearing2;
                            objComp.Gearbox.GearboxTempBearing3 = objCompoGear.GearboxTempBearing3;
                            objComp.Gearbox.GearboxTempOilSump = objCompoGear.GearboxTempOilSump;
                            objComp.Gearbox.GearboxLSSNRend = objCompoGear.GearboxLSSNRend;
                            objComp.Gearbox.GearboxIMSNRend = objCompoGear.GearboxIMSNRend;
                            objComp.Gearbox.GearboxIMSRend = objCompoGear.GearboxIMSRend;
                            objComp.Gearbox.GearboxHSSNRend = objCompoGear.GearboxHSSNRend;
                            objComp.Gearbox.GearboxHSSRend = objCompoGear.GearboxHSSRend;
                            objComp.Gearbox.GearboxPitchTube = objCompoGear.GearboxPitchTube;
                            objComp.Gearbox.GearboxSplitLines = objCompoGear.GearboxSplitLines;
                            objComp.Gearbox.GearboxHoseAndPiping = objCompoGear.GearboxHoseAndPiping;
                            objComp.Gearbox.GearboxInputShaft = objCompoGear.GearboxInputShaft;
                            objComp.Gearbox.GearboxHSSPTO = objCompoGear.GearboxHSSPTO;
                            objComp.Gearbox.GearboxClaimRelevantBooleanAnswerId = objCompoGear.GearboxClaimRelevantBooleanAnswerId;
                            objComp.Gearbox.GearboxOverallGearboxConditionId = objCompoGear.GearboxOverallGearboxConditionId;
                            objComp.Gearbox.GearboxExactLocation6GearTypeId = objCompoGear.GearboxExactLocation6GearTypeId;
                            objComp.Gearbox.GearboxExactLocation7GearTypeId = objCompoGear.GearboxExactLocation7GearTypeId;
                            objComp.Gearbox.GearboxExactLocation8GearTypeId = objCompoGear.GearboxExactLocation8GearTypeId;
                            objComp.Gearbox.GearboxExactLocation9GearTypeId = objCompoGear.GearboxExactLocation9GearTypeId;
                            objComp.Gearbox.GearboxExactLocation10GearTypeId = objCompoGear.GearboxExactLocation10GearTypeId;
                            objComp.Gearbox.GearboxExactLocation11GearTypeId = objCompoGear.GearboxExactLocation11GearTypeId;
                            objComp.Gearbox.GearboxExactLocation12GearTypeId = objCompoGear.GearboxExactLocation12GearTypeId;
                            objComp.Gearbox.GearboxExactLocation13GearTypeId = objCompoGear.GearboxExactLocation13GearTypeId;
                            objComp.Gearbox.GearboxExactLocation14GearTypeId = objCompoGear.GearboxExactLocation14GearTypeId;
                            objComp.Gearbox.GearboxExactLocation15GearTypeId = objCompoGear.GearboxExactLocation15GearTypeId;
                            objComp.Gearbox.GearboxTypeofDamage6GearErrorId = objCompoGear.GearboxTypeofDamage6GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage7GearErrorId = objCompoGear.GearboxTypeofDamage7GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage8GearErrorId = objCompoGear.GearboxTypeofDamage8GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage9GearErrorId = objCompoGear.GearboxTypeofDamage9GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage10GearErrorId = objCompoGear.GearboxTypeofDamage10GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage11GearErrorId = objCompoGear.GearboxTypeofDamage11GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage12GearErrorId = objCompoGear.GearboxTypeofDamage12GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage13GearErrorId = objCompoGear.GearboxTypeofDamage13GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage14GearErrorId = objCompoGear.GearboxTypeofDamage14GearErrorId;
                            objComp.Gearbox.GearboxTypeofDamage15GearErrorId = objCompoGear.GearboxTypeofDamage15GearErrorId;
                            objComp.Gearbox.GearboxGearDecision1DamageDecisionId = objCompoGear.GearboxGearDecision1DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision2DamageDecisionId = objCompoGear.GearboxGearDecision2DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision3DamageDecisionId = objCompoGear.GearboxGearDecision3DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision4DamageDecisionId = objCompoGear.GearboxGearDecision4DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision5DamageDecisionId = objCompoGear.GearboxGearDecision5DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision6DamageDecisionId = objCompoGear.GearboxGearDecision6DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision7DamageDecisionId = objCompoGear.GearboxGearDecision7DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision8DamageDecisionId = objCompoGear.GearboxGearDecision8DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision9DamageDecisionId = objCompoGear.GearboxGearDecision9DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision10DamageDecisionId = objCompoGear.GearboxGearDecision10DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision11DamageDecisionId = objCompoGear.GearboxGearDecision11DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision12DamageDecisionId = objCompoGear.GearboxGearDecision12DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision13DamageDecisionId = objCompoGear.GearboxGearDecision13DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision14DamageDecisionId = objCompoGear.GearboxGearDecision14DamageDecisionId;
                            objComp.Gearbox.GearboxGearDecision15DamageDecisionId = objCompoGear.GearboxGearDecision15DamageDecisionId;
                            objComp.Gearbox.GearboxBearingsLocation6BearingTypeId = objCompoGear.GearboxBearingsLocation6BearingTypeId;
                            objComp.Gearbox.GearboxBearingsPosition6BearingPosId = objCompoGear.GearboxBearingsPosition6BearingPosId;
                            objComp.Gearbox.GearboxBearingsDamage6BearingErrorId = objCompoGear.GearboxBearingsDamage6BearingErrorId;
                            objComp.Gearbox.GearboxBearingDecision1DamageDecisionId = objCompoGear.GearboxBearingDecision1DamageDecisionId;
                            objComp.Gearbox.GearboxBearingDecision2DamageDecisionId = objCompoGear.GearboxBearingDecision2DamageDecisionId;
                            objComp.Gearbox.GearboxBearingDecision3DamageDecisionId = objCompoGear.GearboxBearingDecision3DamageDecisionId;
                            objComp.Gearbox.GearboxBearingDecision4DamageDecisionId = objCompoGear.GearboxBearingDecision4DamageDecisionId;
                            objComp.Gearbox.GearboxBearingDecision5DamageDecisionId = objCompoGear.GearboxBearingDecision5DamageDecisionId;
                            objComp.Gearbox.GearboxBearingDecision6DamageDecisionId = objCompoGear.GearboxBearingDecision6DamageDecisionId;

                            objComp.Gearbox.GearboxGearDamageClass1DamageId = objCompoGear.GearboxGearDamageClass1DamageId;
                            objComp.Gearbox.GearboxGearDamageClass2DamageId = objCompoGear.GearboxGearDamageClass2DamageId;
                            objComp.Gearbox.GearboxGearDamageClass3DamageId = objCompoGear.GearboxGearDamageClass3DamageId;
                            objComp.Gearbox.GearboxGearDamageClass4DamageId = objCompoGear.GearboxGearDamageClass4DamageId;
                            objComp.Gearbox.GearboxGearDamageClass5DamageId = objCompoGear.GearboxGearDamageClass5DamageId;
                            objComp.Gearbox.GearboxGearDamageClass6DamageId = objCompoGear.GearboxGearDamageClass6DamageId;
                            objComp.Gearbox.GearboxGearDamageClass7DamageId = objCompoGear.GearboxGearDamageClass7DamageId;
                            objComp.Gearbox.GearboxGearDamageClass8DamageId = objCompoGear.GearboxGearDamageClass8DamageId;
                            objComp.Gearbox.GearboxGearDamageClass9DamageId = objCompoGear.GearboxGearDamageClass9DamageId;
                            objComp.Gearbox.GearboxGearDamageClass10DamageId = objCompoGear.GearboxGearDamageClass10DamageId;
                            objComp.Gearbox.GearboxGearDamageClass11DamageId = objCompoGear.GearboxGearDamageClass11DamageId;
                            objComp.Gearbox.GearboxGearDamageClass12DamageId = objCompoGear.GearboxGearDamageClass12DamageId;
                            objComp.Gearbox.GearboxGearDamageClass13DamageId = objCompoGear.GearboxGearDamageClass13DamageId;
                            objComp.Gearbox.GearboxGearDamageClass14DamageId = objCompoGear.GearboxGearDamageClass14DamageId;
                            objComp.Gearbox.GearboxGearDamageClass15DamageId = objCompoGear.GearboxGearDamageClass15DamageId;
                            objComp.Gearbox.GearboxAuxEquipmentId = objCompoGear.GearboxAuxEquipmentId;
                            objComp.Gearbox.GearboxActionToBeTakenOnGearboxId = objCompoGear.GearboxActionToBeTakenOnGearboxId;
                            objComp.Gearbox.GearboxDefectCategorizationScore = objCompoGear.GearboxDefectCategorizationScore;

                        }
                        #endregion
                        #region Component Inspection Report General
                        /* Assign value to CIR Report Blade Entity */
                        Edmx.ComponentInspectionReportGeneral objCompGeneral = CIRListUp.ComponentInspectionReportGeneral.Where(x => x.ComponentInspectionReportId == CIRID).FirstOrDefault();
                        objComp.General = new CIR.CommonInspectionGeneral();
                        if (null != objCompGeneral)
                        {
                            objComp.General.ComponentInspectionReportId = CIRID;
                            objComp.General.ComponentInspectionReportGeneralId = objCompGeneral.ComponentInspectionReportGeneralId;
                            objComp.General.GeneralComponentGroupId = objCompGeneral.GeneralComponentGroupId;
                            objComp.General.GeneralComponentType = objCompGeneral.GeneralComponentType;
                            objComp.General.VestasUniqueIdentifier = objCompGeneral.VestasUniqueIdentifier;
                            objComp.General.GeneralComponentManufacturer = objCompGeneral.GeneralComponentManufacturer;
                            objComp.General.GeneralOtherGearboxType = objCompGeneral.GeneralOtherGearboxType;
                            objComp.General.GeneralClaimRelevantBooleanAnswerId = objCompGeneral.GeneralClaimRelevantBooleanAnswerId;
                            objComp.General.GeneralOtherGearboxManufacturer = objCompGeneral.GeneralOtherGearboxManufacturer;
                            objComp.General.GeneralComponentSerialNumber = objCompGeneral.GeneralComponentSerialNumber;
                            objComp.General.GeneralGeneratorManufacturerId = objCompGeneral.GeneralGeneratorManufacturerId;
                            objComp.General.GeneralTransformerManufacturerId = objCompGeneral.GeneralTransformerManufacturerId;
                            objComp.General.GeneralGearboxManufacturerId = objCompGeneral.GeneralGearboxManufacturerId;
                            objComp.General.GeneralTowerTypeId = objCompGeneral.GeneralTowerTypeId;
                            objComp.General.GeneralTowerHeightId = objCompGeneral.GeneralTowerHeightId;
                            objComp.General.GeneralBlade1SerialNumber = objCompGeneral.GeneralBlade1SerialNumber;
                            objComp.General.GeneralBlade2SerialNumber = objCompGeneral.GeneralBlade2SerialNumber;
                            objComp.General.GeneralBlade3SerialNumber = objCompGeneral.GeneralBlade3SerialNumber;
                            objComp.General.GeneralControllerTypeId = objCompGeneral.GeneralControllerTypeId;
                            objComp.General.GeneralSoftwareRelease = objCompGeneral.GeneralSoftwareRelease;
                            objComp.General.GeneralRamDumpNumber = objCompGeneral.GeneralRamDumpNumber;
                            objComp.General.GeneralVDFTrackNumber = objCompGeneral.GeneralVDFTrackNumber;
                            objComp.General.GeneralPicturesIncludedBooleanAnswerId = (objCompGeneral.GeneralPicturesIncludedBooleanAnswerId == 0) ? 1 : objCompGeneral.GeneralPicturesIncludedBooleanAnswerId;
                            objComp.General.GeneralInitiatedBy1 = objCompGeneral.GeneralInitiatedBy1;
                            objComp.General.GeneralInitiatedBy2 = objCompGeneral.GeneralInitiatedBy2;
                            objComp.General.GeneralInitiatedBy3 = objCompGeneral.GeneralInitiatedBy3;
                            objComp.General.GeneralInitiatedBy4 = objCompGeneral.GeneralInitiatedBy4;
                            objComp.General.GeneralMeasurementsConducted1 = objCompGeneral.GeneralMeasurementsConducted1;
                            objComp.General.GeneralMeasurementsConducted2 = objCompGeneral.GeneralMeasurementsConducted2;
                            objComp.General.GeneralMeasurementsConducted3 = objCompGeneral.GeneralMeasurementsConducted3;
                            objComp.General.GeneralMeasurementsConducted4 = objCompGeneral.GeneralMeasurementsConducted4;
                            objComp.General.GeneralExecutedBy1 = objCompGeneral.GeneralExecutedBy1;
                            objComp.General.GeneralExecutedBy2 = objCompGeneral.GeneralExecutedBy2;
                            objComp.General.GeneralExecutedBy3 = objCompGeneral.GeneralExecutedBy3;
                            objComp.General.GeneralExecutedBy4 = objCompGeneral.GeneralExecutedBy4;
                            objComp.General.GeneralPositionOfFailedItem = objCompGeneral.GeneralPositionOfFailedItem;
                        }
                        #endregion
                        #region Component Inspection Report Skiip
                        /* Assign value to CIR Report Skiip Entity */
                        Edmx.ComponentInspectionReportSkiiP objCompoSkip = CIRListUp.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                        if (null != objCompoSkip)
                        {
                            objComp.Skiip = new CIR.ComponentInspectionReportSkiiP();
                            objComp.Skiip.SkiiPOtherDamagedComponentsReplaced = objCompoSkip.SkiiPOtherDamagedComponentsReplaced;
                            objComp.Skiip.SkiiPCauseId = objCompoSkip.SkiiPCauseId;
                            objComp.Skiip.SkiiPQuantityOfFailedModules = objCompoSkip.SkiiPQuantityOfFailedModules;
                            objComp.Skiip.SkiiP2MWV521BooleanAnswerId = objCompoSkip.SkiiP2MWV521BooleanAnswerId;
                            objComp.Skiip.SkiiP2MWV522BooleanAnswerId = objCompoSkip.SkiiP2MWV522BooleanAnswerId;
                            objComp.Skiip.SkiiP2MWV523BooleanAnswerId = objCompoSkip.SkiiP2MWV523BooleanAnswerId;
                            objComp.Skiip.SkiiP2MWV524BooleanAnswerId = objCompoSkip.SkiiP2MWV524BooleanAnswerId;
                            objComp.Skiip.SkiiP2MWV525BooleanAnswerId = objCompoSkip.SkiiP2MWV525BooleanAnswerId;
                            objComp.Skiip.SkiiP2MWV526BooleanAnswerId = objCompoSkip.SkiiP2MWV526BooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV521BooleanAnswerId = objCompoSkip.SkiiP3MWV521BooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV522BooleanAnswerId = objCompoSkip.SkiiP3MWV522BooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV523BooleanAnswerId = objCompoSkip.SkiiP3MWV523BooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV524xBooleanAnswerId = objCompoSkip.SkiiP3MWV524xBooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV524yBooleanAnswerId = objCompoSkip.SkiiP3MWV524yBooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV525xBooleanAnswerId = objCompoSkip.SkiiP3MWV525xBooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV525yBooleanAnswerId = objCompoSkip.SkiiP3MWV525yBooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV526xBooleanAnswerId = objCompoSkip.SkiiP3MWV526xBooleanAnswerId;
                            objComp.Skiip.SkiiP3MWV526yBooleanAnswerId = objCompoSkip.SkiiP3MWV526yBooleanAnswerId;
                            objComp.Skiip.SkiiP850KWV520BooleanAnswerId = objCompoSkip.SkiiP850KWV520BooleanAnswerId;
                            objComp.Skiip.SkiiP850KWV524BooleanAnswerId = objCompoSkip.SkiiP850KWV524BooleanAnswerId;
                            objComp.Skiip.SkiiP850KWV525BooleanAnswerId = objCompoSkip.SkiiP850KWV525BooleanAnswerId;
                            objComp.Skiip.SkiiP850KWV526BooleanAnswerId = objCompoSkip.SkiiP850KWV526BooleanAnswerId;
                            objComp.Skiip.SkiiPClaimRelevantBooleanAnswerId = objCompoSkip.SkiiPClaimRelevantBooleanAnswerId;
                            objComp.Skiip.SkiiPNumberofComponents = objCompoSkip.SkiiPNumberofComponents;
                        }
                        #endregion
                        #region Component Inspection Report Generator
                        /* Assign value to CIR Report Gen Entity */
                        Edmx.ComponentInspectionReportGenerator objCompoGen = CIRListUp.ComponentInspectionReportGenerator.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                        if (null != objCompoGen)
                        {
                            objComp.Generator = new CIR.ComponentInspectionReportGenerator();
                            objComp.Generator.VestasUniqueIdentifier = objCompoGen.VestasUniqueIdentifier;
                            objComp.Generator.GeneratorManufacturerId = objCompoGen.GeneratorManufacturerId;
                            objComp.Generator.GeneratorSerialNumber = objCompoGen.GeneratorSerialNumber;
                            objComp.Generator.OtherManufacturer = objCompoGen.OtherManufacturer;
                            objComp.Generator.GeneratorMaxTemperature = objCompoGen.GeneratorMaxTemperature;
                            objComp.Generator.GeneratorMaxTemperatureResetDate = objCompoGen.GeneratorMaxTemperatureResetDate;
                            objComp.Generator.CouplingId = objCompoGen.CouplingId;
                            objComp.Generator.ActionToBeTakenOnGeneratorId = objCompoGen.ActionToBeTakenOnGeneratorId;
                            objComp.Generator.GeneratorDriveEndId = objCompoGen.GeneratorDriveEndId;
                            objComp.Generator.GeneratorNonDriveEndId = objCompoGen.GeneratorNonDriveEndId;
                            objComp.Generator.GeneratorRotorId = objCompoGen.GeneratorRotorId;
                            objComp.Generator.GeneratorCoverId = objCompoGen.GeneratorCoverId;
                            objComp.Generator.AirToAirCoolerInternalId = objCompoGen.AirToAirCoolerInternalId;
                            objComp.Generator.AirToAirCoolerExternalId = objCompoGen.AirToAirCoolerExternalId;
                            objComp.Generator.GeneratorComments = objCompoGen.GeneratorComments;
                            objComp.Generator.UGround = objCompoGen.UGround;
                            objComp.Generator.VGround = objCompoGen.VGround;
                            objComp.Generator.WGround = objCompoGen.WGround;
                            objComp.Generator.UV = objCompoGen.UV;
                            objComp.Generator.UW = objCompoGen.UW;
                            objComp.Generator.VW = objCompoGen.VW;
                            objComp.Generator.KGround = objCompoGen.KGround;
                            objComp.Generator.LGround = objCompoGen.LGround;
                            objComp.Generator.MGround = objCompoGen.MGround;
                            objComp.Generator.UGroundOhmUnitId = objCompoGen.UGroundOhmUnitId;
                            objComp.Generator.VGroundOhmUnitId = objCompoGen.VGroundOhmUnitId;
                            objComp.Generator.WGroundOhmUnitId = objCompoGen.WGroundOhmUnitId;
                            objComp.Generator.UVOhmUnitId = objCompoGen.UVOhmUnitId;
                            objComp.Generator.UWOhmUnitId = objCompoGen.UWOhmUnitId;
                            objComp.Generator.VWOhmUnitId = objCompoGen.VWOhmUnitId;
                            objComp.Generator.KGroundOhmUnitId = objCompoGen.KGroundOhmUnitId;
                            objComp.Generator.LGroundOhmUnitId = objCompoGen.LGroundOhmUnitId;
                            objComp.Generator.MGroundOhmUnitId = objCompoGen.MGroundOhmUnitId;
                            objComp.Generator.U1U2 = objCompoGen.U1U2;
                            objComp.Generator.V1V2 = objCompoGen.V1V2;
                            objComp.Generator.W1W2 = objCompoGen.W1W2;
                            objComp.Generator.K1L1 = objCompoGen.K1L1;
                            objComp.Generator.L1M1 = objCompoGen.L1M1;
                            objComp.Generator.K1M1 = objCompoGen.K1M1;
                            objComp.Generator.K2L2 = objCompoGen.K2L2;
                            objComp.Generator.L2M2 = objCompoGen.L2M2;
                            objComp.Generator.K2M2 = objCompoGen.K2M2;
                            objComp.Generator.GeneratorRewoundLocally = objCompoGen.GeneratorRewoundLocally;
                            objComp.Generator.InsulationComments = objCompoGen.InsulationComments;
                            objComp.Generator.GeneratorInsulationComments = objCompoGen.GeneratorInsulationComments;
                            objComp.Generator.GeneratorClaimRelevantBooleanAnswerId = objCompoGen.GeneratorClaimRelevantBooleanAnswerId;
                        }
                        #endregion
                        #region Component Inspection Report Transformer
                        Edmx.ComponentInspectionReportTransformer objCompoTrans = CIRListUp.ComponentInspectionReportTransformer.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                        /* Assign value to CIR Report Transformer Entity */
                        if (null != objCompoTrans)
                        {
                            objComp.Transformer = new CIR.ComponentInspectionReportTransformer();
                            objComp.Transformer.VestasUniqueIdentifier = objCompoTrans.VestasUniqueIdentifier;
                            objComp.Transformer.TransformerManufacturerId = objCompoTrans.TransformerManufacturerId;
                            objComp.Transformer.TransformerSerialNumber = objCompoTrans.TransformerSerialNumber;
                            objComp.Transformer.MaxTemp = objCompoTrans.MaxTemp;
                            if (objCompoTrans.MaxTempResetDate != null)
                            {
                                objComp.Transformer.MaxTempResetDate = Convert.ToDateTime(objCompoTrans.MaxTempResetDate);
                            }
                            objComp.Transformer.ActionOnTransformerId = objCompoTrans.ActionOnTransformerId;
                            objComp.Transformer.HVCoilConditionId = objCompoTrans.HVCoilConditionId;
                            objComp.Transformer.LVCoilConditionId = objCompoTrans.LVCoilConditionId;
                            objComp.Transformer.HVCableConditionId = objCompoTrans.HVCableConditionId;
                            objComp.Transformer.LVCableConditionId = objCompoTrans.LVCableConditionId;
                            objComp.Transformer.BracketsId = objCompoTrans.BracketsId;
                            objComp.Transformer.TransformerArcDetectionId = objCompoTrans.TransformerArcDetectionId;
                            objComp.Transformer.ClimateId = objCompoTrans.ClimateId;
                            objComp.Transformer.SurgeArrestorId = objCompoTrans.SurgeArrestorId;
                            objComp.Transformer.ConnectionBarsId = objCompoTrans.ConnectionBarsId;
                            objComp.Transformer.Comments = objCompoTrans.Comments;
                            objComp.Transformer.TransformerClaimRelevantBooleanAnswerId = objCompoTrans.TransformerClaimRelevantBooleanAnswerId;
                        }
                        #endregion
                        #region Component Inspection Report Blade Damage
                        if (objCompBlade != null)
                        {
                            if (objCompBlade.ComponentInspectionReportBladeId > 0)
                            {
                                /* Blade Damage Content */
                                var objCompoBladeDam = objCompBlade.ComponentInspectionReportBladeDamage
                                       .Where(x => x.ComponentInspectionReportBladeId == objCompBlade.ComponentInspectionReportBladeId);
                                objComp.BladeData.DamageData = new List<CIR.ComponentInspectionReportBladeDamage>();
                                foreach (Edmx.ComponentInspectionReportBladeDamage objCIRBlDamage in objCompoBladeDam)
                                {
                                    //var objBladeDam = objCompoBladeDam
                                    //   .Where(x => x.ComponentInspectionReportBladeDamageId == objCIRBlDamage.ComponentInspectionReportBladeDamageId).FirstOrDefault();
                                    /*Blade Damge Update */
                                    if ((null != objCIRBlDamage) && (objCIRBlDamage.ComponentInspectionReportBladeDamageId > 0))
                                    {
                                        CIR.ComponentInspectionReportBladeDamage objCompoBladeNDam = new CIR.ComponentInspectionReportBladeDamage
                                        {
                                            ComponentInspectionReportBladeDamageId = objCIRBlDamage.ComponentInspectionReportBladeDamageId,
                                            ComponentInspectionReportBladeId = objCompBlade.ComponentInspectionReportBladeId,
                                            BladeDamagePlacementId = objCIRBlDamage.BladeDamagePlacementId,
                                            BladeInspectionDataId = objCIRBlDamage.BladeInspectionDataId,
                                            BladeRadius = objCIRBlDamage.BladeRadius,
                                            BladeEdgeId = objCIRBlDamage.BladeEdgeId,
                                            BladeDescription = objCIRBlDamage.BladeDescription,
                                            BladePictureNumber = objCIRBlDamage.BladePictureNumber,
                                            PictureOrder = objCIRBlDamage.PictureOrder,
                                            DamageSeverity = objCIRBlDamage.DamageSeverity,
                                            FormIOImageGUID = objCIRBlDamage.FormIOImageGUID
                                        };
                                        objComp.BladeData.DamageData.Add(objCompoBladeNDam);

                                    }
                                }
                            }
                        }
                        #endregion
                        #region Component Inspection Report Skiip Failed
                        /* Skiip Failed Component */
                        if (objCompoSkip != null)
                        {
                            if (objCompoSkip.ComponentInspectionReportSkiiPId > 0)
                            {
                                var objCompoSkiipFail = objCompoSkip.ComponentInspectionReportSkiiPFailedComponent
                                       .Where(x => x.ComponentInspectionReportSkiiPId == objCompoSkip.ComponentInspectionReportSkiiPId);
                                objComp.Skiip.SkiipFailedComp = new List<CIR.ComponentInspectionReportSkiiPFailedComponent>();
                                foreach (Edmx.ComponentInspectionReportSkiiPFailedComponent objCIRSkiFal in objCompoSkiipFail.Where(z => !String.IsNullOrEmpty(z.SkiiPFailedComponentSerialNumber) || !String.IsNullOrEmpty(z.SkiiPFailedComponentVestasItemNumber) || !String.IsNullOrEmpty(z.SkiiPFailedComponentVestasUniqueIdentifier)))
                                {
                                    /* Skiip Failed Compo update */
                                    if ((null != objCIRSkiFal) && (objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId > 0))
                                    {
                                        CIR.ComponentInspectionReportSkiiPFailedComponent objCompoSkiipFailed = new CIR.ComponentInspectionReportSkiiPFailedComponent
                                        {
                                            ComponentInspectionReportSkiiPFailedComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId,
                                            ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                            SkiiPFailedComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPFailedComponentVestasUniqueIdentifier,
                                            SkiiPFailedComponentVestasItemNumber = objCIRSkiFal.SkiiPFailedComponentVestasItemNumber,
                                            SkiiPFailedComponentSerialNumber = objCIRSkiFal.SkiiPFailedComponentSerialNumber

                                        };
                                        objComp.Skiip.SkiipFailedComp.Add(objCompoSkiipFailed);
                                    }
                                }
                                foreach (Edmx.ComponentInspectionReportSkiiPFailedComponent objCIRSkiFal in objCompoSkiipFail.Where(z => String.IsNullOrEmpty(z.SkiiPFailedComponentSerialNumber) && String.IsNullOrEmpty(z.SkiiPFailedComponentVestasItemNumber) && String.IsNullOrEmpty(z.SkiiPFailedComponentVestasUniqueIdentifier)))
                                {
                                    /* Skiip Failed Compo update */
                                    if ((null != objCIRSkiFal) && (objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId > 0))
                                    {
                                        CIR.ComponentInspectionReportSkiiPFailedComponent objCompoSkiipFailed = new CIR.ComponentInspectionReportSkiiPFailedComponent
                                        {
                                            ComponentInspectionReportSkiiPFailedComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPFailedComponentId,
                                            ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                            SkiiPFailedComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPFailedComponentVestasUniqueIdentifier,
                                            SkiiPFailedComponentVestasItemNumber = objCIRSkiFal.SkiiPFailedComponentVestasItemNumber,
                                            SkiiPFailedComponentSerialNumber = objCIRSkiFal.SkiiPFailedComponentSerialNumber

                                        };
                                        objComp.Skiip.SkiipFailedComp.Add(objCompoSkiipFailed);
                                    }
                                }

                                var objCompoSkiipNwCom = objCompoSkip.ComponentInspectionReportSkiiPNewComponent
                                   .Where(x => x.ComponentInspectionReportSkiiPId == objCompoSkip.ComponentInspectionReportSkiiPId);
                                objComp.Skiip.SkiipNewComp = new List<CIR.ComponentInspectionReportSkiiPNewComponent>();
                                /* Skiip New Comp */
                                foreach (Edmx.ComponentInspectionReportSkiiPNewComponent objCIRSkiFal in objCompoSkiipNwCom.Where(z => !String.IsNullOrEmpty(z.SkiiPNewComponentSerialNumber) || !String.IsNullOrEmpty(z.SkiiPNewComponentVestasItemNumber) || !String.IsNullOrEmpty(z.SkiiPNewComponentVestasUniqueIdentifier)))
                                {
                                    /* Skiip New Comp Update*/
                                    if ((null != objCIRSkiFal) && (objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId > 0))
                                    {
                                        CIR.ComponentInspectionReportSkiiPNewComponent objCompoSkiipNew = new CIR.ComponentInspectionReportSkiiPNewComponent
                                        {
                                            ComponentInspectionReportSkiiPNewComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId,
                                            ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                            SkiiPNewComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPNewComponentVestasUniqueIdentifier,
                                            SkiiPNewComponentVestasItemNumber = objCIRSkiFal.SkiiPNewComponentVestasItemNumber,
                                            SkiiPNewComponentSerialNumber = objCIRSkiFal.SkiiPNewComponentSerialNumber

                                        };
                                        objComp.Skiip.SkiipNewComp.Add(objCompoSkiipNew);
                                    }
                                }
                                foreach (Edmx.ComponentInspectionReportSkiiPNewComponent objCIRSkiFal in objCompoSkiipNwCom.Where(z => String.IsNullOrEmpty(z.SkiiPNewComponentSerialNumber) && String.IsNullOrEmpty(z.SkiiPNewComponentVestasItemNumber) && String.IsNullOrEmpty(z.SkiiPNewComponentVestasUniqueIdentifier)))
                                {
                                    /* Skiip New Comp Update*/
                                    if ((null != objCIRSkiFal) && (objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId > 0))
                                    {
                                        CIR.ComponentInspectionReportSkiiPNewComponent objCompoSkiipNew = new CIR.ComponentInspectionReportSkiiPNewComponent
                                        {
                                            ComponentInspectionReportSkiiPNewComponentId = objCIRSkiFal.ComponentInspectionReportSkiiPNewComponentId,
                                            ComponentInspectionReportSkiiPId = objCompoSkip.ComponentInspectionReportSkiiPId,
                                            SkiiPNewComponentVestasUniqueIdentifier = objCIRSkiFal.SkiiPNewComponentVestasUniqueIdentifier,
                                            SkiiPNewComponentVestasItemNumber = objCIRSkiFal.SkiiPNewComponentVestasItemNumber,
                                            SkiiPNewComponentSerialNumber = objCIRSkiFal.SkiiPNewComponentSerialNumber

                                        };
                                        objComp.Skiip.SkiipNewComp.Add(objCompoSkiipNew);
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Component Inspection Report Main Bearning
                        Edmx.ComponentInspectionReportMainBearing objCompoBearing = CIRListUp.ComponentInspectionReportMainBearing.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                        /* Assign value to CIR Report Transformer Entity */
                        if (null != objCompoBearing)
                        {
                            objComp.MainBearing = new CIR.ComponentInspectionReportMainBearing();
                            objComp.MainBearing.VestasUniqueIdentifier = objCompoBearing.VestasUniqueIdentifier;
                            if (objCompoBearing.MainBearingLastLubricationDate != null)
                            {
                                objComp.MainBearing.MainBearingLastLubricationDate = Convert.ToDateTime(objCompoBearing.MainBearingLastLubricationDate);
                            }

                            objComp.MainBearing.MainBearingManufacturerId = objCompoBearing.MainBearingManufacturerId ?? 0;
                            objComp.MainBearing.MainBearingTemperature = objCompoBearing.MainBearingTemperature ?? 0;
                            objComp.MainBearing.MainBearingGrease = objCompoBearing.MainBearingGrease;
                            objComp.MainBearing.MainBearingLubricationRunHours = objCompoBearing.MainBearingLubricationRunHours;
                            objComp.MainBearing.MainBearingOilTemperature = objCompoBearing.MainBearingOilTemperature ?? 0;
                            objComp.MainBearing.MainBearingTypeId = objCompoBearing.MainBearingTypeId ?? 0;
                            objComp.MainBearing.MainBearingRevision = objCompoBearing.MainBearingRevision ?? 0;
                            objComp.MainBearing.MainBearingErrorLocationId = objCompoBearing.MainBearingErrorLocationId ?? 0;
                            objComp.MainBearing.MainBearingSerialNumber = objCompoBearing.MainBearingSerialNumber;
                            objComp.MainBearing.MainBearingRunHours = objCompoBearing.MainBearingRunHours ?? 0;
                            objComp.MainBearing.MainBearingMechanicalOilPump = objCompoBearing.MainBearingMechanicalOilPump;
                            objComp.MainBearing.MainBearingLubricationOilTypeId = objCompoBearing.MainBearingLubricationOilTypeId ?? 0;
                            objComp.MainBearing.MainBearingClaimRelevantBooleanAnswerId = objCompoBearing.MainBearingClaimRelevantBooleanAnswerId ?? 0;



                        }
                        #endregion
                        #region ImageData
                        objComp.ImageData = new List<CIR.ImageData>();

                        if (CIRListUp.ImageData != null)
                            objComp.ImageData.AddRange(from id in CIRListUp.ImageData.OrderBy(i => i.ImageOrder)
                                                       select new CIR.ImageData { ImageDataString = id.ImageDataString, ImageDescription = id.ImageDescription, ImageOrder = id.ImageOrder.Value, ImageId = id.ImageId, InspectionDesc = id.InspectionDesc, IsPlateType = ((id.IsPlateType.HasValue) ? id.IsPlateType.Value : false), FlangNo = ((id.FlangNo.HasValue) ? id.FlangNo.Value : 0), ImageUrl = id.ImageUrl, FormIOImageGUID = id.FormIOImageGUID });

                        if (CIRListUp.ImageDataInfo.FirstOrDefault() != null && CIRListUp.ImageDataInfo.FirstOrDefault().IsPlateTypeNotPossible.HasValue)
                            objComp.ImageDataInfo = new CIR.ImageDataInfo { IsPlateTypeNotPossible = CIRListUp.ImageDataInfo.FirstOrDefault().IsPlateTypeNotPossible.Value, PlateTypeNotPossibleReason = CIRListUp.ImageDataInfo.FirstOrDefault().PlateTypeNotPossibleReason };
                        else
                            objComp.ImageDataInfo = new CIR.ImageDataInfo { IsPlateTypeNotPossible = false, PlateTypeNotPossibleReason = "" };

                        #endregion
                        /* added for Local history cir version */

                        #region objDynamicTableInput
                        string cirid = CIRID.ToString();
                        Edmx.DynamicTableInput objDynamicTableInput = context.DynamicTableInput.Where(x => x.CirId == cirid).FirstOrDefault();

                        if (CIRListUp.ComponentInspectionReportTypeId != 8)
                        {
                            if (objDynamicTableInput != null)
                            {
                                objComp.DynamicTableInputs = new DynamicTable();
                                objComp.DynamicTableInputs.Row1Col1 = objDynamicTableInput.Row1Col1;
                                objComp.DynamicTableInputs.Row1Col2 = objDynamicTableInput.Row1Col2;
                                objComp.DynamicTableInputs.Row1Col3 = objDynamicTableInput.Row1Col3;
                                objComp.DynamicTableInputs.Row1Col4 = objDynamicTableInput.Row1Col4;
                                objComp.DynamicTableInputs.Row2Col1 = objDynamicTableInput.Row2Col1;
                                objComp.DynamicTableInputs.Row2Col2 = objDynamicTableInput.Row2Col2;
                                objComp.DynamicTableInputs.Row2Col3 = objDynamicTableInput.Row2Col3;
                                objComp.DynamicTableInputs.Row2Col4 = objDynamicTableInput.Row2Col4;
                                objComp.DynamicTableInputs.Row3Col1 = objDynamicTableInput.Row3Col1;
                                objComp.DynamicTableInputs.Row3Col2 = objDynamicTableInput.Row3Col2;
                                objComp.DynamicTableInputs.Row3Col3 = objDynamicTableInput.Row3Col3;
                                objComp.DynamicTableInputs.Row3Col4 = objDynamicTableInput.Row3Col4;
                                objComp.DynamicTableInputs.Row4Col1 = objDynamicTableInput.Row4Col1;
                                objComp.DynamicTableInputs.Row4Col2 = objDynamicTableInput.Row4Col2;
                                objComp.DynamicTableInputs.Row4Col3 = objDynamicTableInput.Row4Col3;
                                objComp.DynamicTableInputs.Row4Col4 = objDynamicTableInput.Row4Col4;
                                objComp.DynamicTableInputs.Row5Col1 = objDynamicTableInput.Row5Col1;
                                objComp.DynamicTableInputs.Row5Col2 = objDynamicTableInput.Row5Col2;
                                objComp.DynamicTableInputs.Row5Col3 = objDynamicTableInput.Row5Col3;
                                objComp.DynamicTableInputs.Row5Col4 = objDynamicTableInput.Row5Col4;
                                objComp.DynamicTableInputs.Row6Col1 = objDynamicTableInput.Row6Col1;
                                objComp.DynamicTableInputs.Row6Col2 = objDynamicTableInput.Row6Col2;
                                objComp.DynamicTableInputs.Row6Col3 = objDynamicTableInput.Row6Col3;
                                objComp.DynamicTableInputs.Row6Col4 = objDynamicTableInput.Row6Col4;
                                objComp.DynamicTableInputs.Row7Col1 = objDynamicTableInput.Row7Col1;
                                objComp.DynamicTableInputs.Row7Col2 = objDynamicTableInput.Row7Col2;
                                objComp.DynamicTableInputs.Row7Col3 = objDynamicTableInput.Row7Col3;
                                objComp.DynamicTableInputs.Row7Col4 = objDynamicTableInput.Row7Col4;
                                objComp.DynamicTableInputs.Row8Col1 = objDynamicTableInput.Row8Col1;
                                objComp.DynamicTableInputs.Row8Col2 = objDynamicTableInput.Row8Col2;
                                objComp.DynamicTableInputs.Row8Col3 = objDynamicTableInput.Row8Col3;
                                objComp.DynamicTableInputs.Row8Col4 = objDynamicTableInput.Row8Col4;
                                objComp.DynamicTableInputs.Row9Col1 = objDynamicTableInput.Row9Col1;
                                objComp.DynamicTableInputs.Row9Col2 = objDynamicTableInput.Row9Col2;
                                objComp.DynamicTableInputs.Row9Col3 = objDynamicTableInput.Row9Col3;
                                objComp.DynamicTableInputs.Row9Col4 = objDynamicTableInput.Row9Col4;
                                objComp.DynamicTableInputs.Row10Col1 = objDynamicTableInput.Row10Col1;
                                objComp.DynamicTableInputs.Row10Col2 = objDynamicTableInput.Row10Col2;
                                objComp.DynamicTableInputs.Row10Col3 = objDynamicTableInput.Row10Col3;
                                objComp.DynamicTableInputs.Row10Col4 = objDynamicTableInput.Row10Col4;
                                objComp.DynamicTableInputs.Row1Col5 = objDynamicTableInput.Row1Col5;
                                objComp.DynamicTableInputs.Row1Col6 = objDynamicTableInput.Row1Col6;
                                objComp.DynamicTableInputs.Row2Col5 = objDynamicTableInput.Row2Col5;
                                objComp.DynamicTableInputs.Row2Col6 = objDynamicTableInput.Row2Col6;
                                objComp.DynamicTableInputs.Row3Col5 = objDynamicTableInput.Row3Col5;
                                objComp.DynamicTableInputs.Row3Col6 = objDynamicTableInput.Row3Col6;
                                objComp.DynamicTableInputs.Row4Col5 = objDynamicTableInput.Row4Col5;
                                objComp.DynamicTableInputs.Row4Col6 = objDynamicTableInput.Row4Col6;
                                objComp.DynamicTableInputs.Row5Col5 = objDynamicTableInput.Row5Col5;
                                objComp.DynamicTableInputs.Row5Col6 = objDynamicTableInput.Row5Col6;
                                objComp.DynamicTableInputs.Row6Col5 = objDynamicTableInput.Row6Col5;
                                objComp.DynamicTableInputs.Row6Col6 = objDynamicTableInput.Row6Col6;
                                objComp.DynamicTableInputs.Row7Col5 = objDynamicTableInput.Row7Col5;
                                objComp.DynamicTableInputs.Row7Col6 = objDynamicTableInput.Row7Col6;
                                objComp.DynamicTableInputs.Row8Col5 = objDynamicTableInput.Row8Col5;
                                objComp.DynamicTableInputs.Row8Col6 = objDynamicTableInput.Row8Col6;
                                objComp.DynamicTableInputs.Row9Col5 = objDynamicTableInput.Row9Col5;
                                objComp.DynamicTableInputs.Row9Col6 = objDynamicTableInput.Row9Col6;
                                objComp.DynamicTableInputs.Row10Col5 = objDynamicTableInput.Row10Col5;
                                objComp.DynamicTableInputs.Row10Col6 = objDynamicTableInput.Row10Col6;
                            }
                            #endregion
                        }
                        else
                        {
                            if (objDynamicTableInput != null)
                            {
                                objComp.DynamicTableInputs = new DynamicTable();
                                objComp.DynamicTableInputs.Row1Col1 = objDynamicTableInput.Row1Col1;
                                objComp.DynamicTableInputs.Row2Col1 = objDynamicTableInput.Row2Col1;
                                objComp.DynamicTableInputs.Row3Col1 = objDynamicTableInput.Row3Col1;
                                objComp.DynamicTableInputs.Row4Col1 = objDynamicTableInput.Row4Col1;
                                objComp.DynamicTableInputs.Row5Col1 = objDynamicTableInput.Row5Col1;
                                objComp.DynamicTableInputs.Row6Col1 = objDynamicTableInput.Row6Col1;
                                objComp.DynamicTableInputs.Row7Col1 = objDynamicTableInput.Row7Col1;
                                objComp.DynamicTableInputs.Row8Col1 = objDynamicTableInput.Row8Col1;
                                objComp.DynamicTableInputs.Row9Col1 = objDynamicTableInput.Row9Col1;
                                objComp.DynamicTableInputs.Row10Col1 = objDynamicTableInput.Row10Col1;
                                objComp.DynamicTableInputs.Row11Col1 = objDynamicTableInput.Row11Col1;
                                objComp.DynamicTableInputs.Row12Col1 = objDynamicTableInput.Row12Col1;
                                objComp.DynamicTableInputs.Row13Col1 = objDynamicTableInput.Row13Col1;
                                objComp.DynamicTableInputs.Row14Col1 = objDynamicTableInput.Row14Col1;

                                objComp.DynamicTableInputs.Row1Col2 = objDynamicTableInput.Row1Col2;
                                objComp.DynamicTableInputs.Row2Col2 = objDynamicTableInput.Row2Col2;
                                objComp.DynamicTableInputs.Row3Col2 = objDynamicTableInput.Row3Col2;
                                objComp.DynamicTableInputs.Row4Col2 = objDynamicTableInput.Row4Col2;
                                objComp.DynamicTableInputs.Row5Col2 = objDynamicTableInput.Row5Col2;
                                objComp.DynamicTableInputs.Row6Col2 = objDynamicTableInput.Row6Col2;
                                objComp.DynamicTableInputs.Row7Col2 = objDynamicTableInput.Row7Col2;
                                objComp.DynamicTableInputs.Row8Col2 = objDynamicTableInput.Row8Col2;
                                objComp.DynamicTableInputs.Row9Col2 = objDynamicTableInput.Row9Col2;
                                objComp.DynamicTableInputs.Row10Col2 = objDynamicTableInput.Row10Col2;
                                objComp.DynamicTableInputs.Row11Col2 = objDynamicTableInput.Row11Col2;
                                objComp.DynamicTableInputs.Row12Col2 = objDynamicTableInput.Row12Col2;
                                objComp.DynamicTableInputs.Row13Col2 = objDynamicTableInput.Row13Col2;
                                objComp.DynamicTableInputs.Row14Col2 = objDynamicTableInput.Row14Col2;

                                objComp.DynamicTableInputs.Row1Col3 = objDynamicTableInput.Row1Col3;
                                objComp.DynamicTableInputs.Row2Col3 = objDynamicTableInput.Row2Col3;
                                objComp.DynamicTableInputs.Row3Col3 = objDynamicTableInput.Row3Col3;
                                objComp.DynamicTableInputs.Row4Col3 = objDynamicTableInput.Row4Col3;
                                objComp.DynamicTableInputs.Row5Col3 = objDynamicTableInput.Row5Col3;
                                objComp.DynamicTableInputs.Row6Col3 = objDynamicTableInput.Row6Col3;
                                objComp.DynamicTableInputs.Row7Col3 = objDynamicTableInput.Row7Col3;
                                objComp.DynamicTableInputs.Row9Col3 = objDynamicTableInput.Row9Col3;
                                objComp.DynamicTableInputs.Row8Col3 = objDynamicTableInput.Row8Col3;
                                objComp.DynamicTableInputs.Row10Col3 = objDynamicTableInput.Row10Col3;
                                objComp.DynamicTableInputs.Row11Col3 = objDynamicTableInput.Row11Col3;
                                objComp.DynamicTableInputs.Row12Col3 = objDynamicTableInput.Row12Col3;
                                objComp.DynamicTableInputs.Row13Col3 = objDynamicTableInput.Row13Col3;
                                objComp.DynamicTableInputs.Row14Col3 = objDynamicTableInput.Row14Col3;

                                objComp.DynamicTableInputs.Row1Col4 = objDynamicTableInput.Row1Col4;
                                objComp.DynamicTableInputs.Row2Col4 = objDynamicTableInput.Row2Col4;
                                objComp.DynamicTableInputs.Row3Col4 = objDynamicTableInput.Row3Col4;
                                objComp.DynamicTableInputs.Row4Col4 = objDynamicTableInput.Row4Col4;
                                objComp.DynamicTableInputs.Row5Col4 = objDynamicTableInput.Row5Col4;
                                objComp.DynamicTableInputs.Row6Col4 = objDynamicTableInput.Row6Col4;
                                objComp.DynamicTableInputs.Row7Col4 = objDynamicTableInput.Row7Col4;
                                objComp.DynamicTableInputs.Row8Col4 = objDynamicTableInput.Row8Col4;
                                objComp.DynamicTableInputs.Row9Col4 = objDynamicTableInput.Row9Col4;
                                objComp.DynamicTableInputs.Row10Col4 = objDynamicTableInput.Row10Col4;
                                objComp.DynamicTableInputs.Row11Col4 = objDynamicTableInput.Row11Col4;
                                objComp.DynamicTableInputs.Row12Col4 = objDynamicTableInput.Row12Col4;
                                objComp.DynamicTableInputs.Row13Col4 = objDynamicTableInput.Row13Col4;
                                objComp.DynamicTableInputs.Row14Col4 = objDynamicTableInput.Row14Col4;

                                objComp.DynamicTableInputs.Row1Col5 = objDynamicTableInput.Row1Col5;
                                objComp.DynamicTableInputs.Row2Col5 = objDynamicTableInput.Row2Col5;
                                objComp.DynamicTableInputs.Row3Col5 = objDynamicTableInput.Row3Col5;
                                objComp.DynamicTableInputs.Row4Col5 = objDynamicTableInput.Row4Col5;
                                objComp.DynamicTableInputs.Row5Col5 = objDynamicTableInput.Row5Col5;
                                objComp.DynamicTableInputs.Row6Col5 = objDynamicTableInput.Row6Col5;
                                objComp.DynamicTableInputs.Row7Col5 = objDynamicTableInput.Row7Col5;
                                objComp.DynamicTableInputs.Row8Col5 = objDynamicTableInput.Row8Col5;
                                objComp.DynamicTableInputs.Row9Col5 = objDynamicTableInput.Row9Col5;
                                objComp.DynamicTableInputs.Row10Col5 = objDynamicTableInput.Row10Col5;
                                objComp.DynamicTableInputs.Row11Col5 = objDynamicTableInput.Row11Col5;
                                objComp.DynamicTableInputs.Row12Col5 = objDynamicTableInput.Row12Col5;
                                objComp.DynamicTableInputs.Row13Col5 = objDynamicTableInput.Row13Col5;
                                objComp.DynamicTableInputs.Row14Col5 = objDynamicTableInput.Row14Col5;

                                objComp.DynamicTableInputs.Row1Col6 = objDynamicTableInput.Row1Col6;
                                objComp.DynamicTableInputs.Row2Col6 = objDynamicTableInput.Row2Col6;
                                objComp.DynamicTableInputs.Row3Col6 = objDynamicTableInput.Row3Col6;
                                objComp.DynamicTableInputs.Row4Col6 = objDynamicTableInput.Row4Col6;
                                objComp.DynamicTableInputs.Row5Col6 = objDynamicTableInput.Row5Col6;
                                objComp.DynamicTableInputs.Row6Col6 = objDynamicTableInput.Row6Col6;
                                objComp.DynamicTableInputs.Row7Col6 = objDynamicTableInput.Row7Col6;
                                objComp.DynamicTableInputs.Row8Col6 = objDynamicTableInput.Row8Col6;
                                objComp.DynamicTableInputs.Row9Col6 = objDynamicTableInput.Row9Col6;
                                objComp.DynamicTableInputs.Row10Col6 = objDynamicTableInput.Row10Col6;
                                objComp.DynamicTableInputs.Row11Col6 = objDynamicTableInput.Row11Col6;
                                objComp.DynamicTableInputs.Row12Col6 = objDynamicTableInput.Row12Col6;
                                objComp.DynamicTableInputs.Row13Col6 = objDynamicTableInput.Row13Col6;
                                objComp.DynamicTableInputs.Row14Col6 = objDynamicTableInput.Row14Col6;
                            }
                            // Add reterive code of dynamic decision data
                            objComp.DyanamicDecisionData = new List<CIR.DyanamicDecision>();

                            if (objComp.DyanamicDecisionData != null)
                            {
                                var objDynamicDecision = context.DynamicDecisionDetails.Where(x => x.CirId == CIRListUp.ComponentInspectionReportId).ToList();
                                foreach (Edmx.DynamicDecisionDetails obj in objDynamicDecision)
                                {
                                    if (obj != null)
                                    {
                                        objComp.DyanamicDecisionData.Add(new DyanamicDecision
                                        {
                                            AffectedBolts = obj.AffectedBolts.Value,
                                            CirId = obj.CirId,
                                            CreatedDate = obj.CreatedDate,
                                            Decision = obj.Decision.Value,
                                            DecisionId = obj.DecisionId,
                                            FlangNo = obj.FlangNo,
                                            ImidiateActions = obj.ImidiateActions,
                                            InspectionDesc = obj.InspectionDesc,
                                            IsDeleted = obj.IsDeleted.Value,
                                            RepeatedInspections = obj.RepeatedInspections.Value,
                                            UpdatedDate = obj.UpdatedDate.Value,
                                            FlangeDamageIdentified = obj.FlangeDamageIdentified.Value
                                        });

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        objComp.ErrorMessage = ErrorCode.GetEnumDescription(ErrorCode.ReturnCodeVal.NotFound);
                    }
                }
            }
            catch (Exception oException)
            {
                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";
                innerstr = (oException.InnerException.InnerException != null) ? oException.InnerException.InnerException.Message + "\n Details : " + oException.InnerException.InnerException.StackTrace : innerstr;
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error occured while getting CIR Data by CIRID [CIRID = " + CIRID + "]. Exception : " + exstr + "\n  Inner Exception : " + innerstr, LogType.Error, responseString);
            }

            return objComp;
        }
        /// <summary>
        /// Get all Master data from database
        /// </summary>
        /// <returns></returns>
        public static List<Cir.Sync.Services.CIR.ComponentInspectionReport> CirQuickSearch(CirQuickSearch SearchItems)
        {
            List<Cir.Sync.Services.CIR.ComponentInspectionReport> lstComponentInspectionReport = new List<Cir.Sync.Services.CIR.ComponentInspectionReport>();
            DataSet dsCirData = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Stp_QuickSearch_Cir", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!ReferenceEquals(SearchItems.CirID, null))
                    {
                        cmd.Parameters.Add("@CirID", SqlDbType.BigInt);
                        cmd.Parameters["@CirID"].Value = SearchItems.CirID;
                    }
                    if (!ReferenceEquals(SearchItems.ComponentInspectionReportTypeId, null))
                    {
                        cmd.Parameters.Add("@ComponentInspectionReportTypeId", SqlDbType.BigInt);
                        cmd.Parameters["@ComponentInspectionReportTypeId"].Value = SearchItems.ComponentInspectionReportTypeId;
                    }
                    if (!ReferenceEquals(SearchItems.ReportTypeId, null))
                    {
                        cmd.Parameters.Add("@ReportTypeId", SqlDbType.BigInt);
                        cmd.Parameters["@ReportTypeId"].Value = SearchItems.ReportTypeId;
                    }
                    if (!ReferenceEquals(SearchItems.CIMCaseNumber, null))
                    {
                        cmd.Parameters.Add("@CIMCaseNumber", SqlDbType.BigInt);
                        cmd.Parameters["@CIMCaseNumber"].Value = SearchItems.CIMCaseNumber;
                    }
                    if (!ReferenceEquals(SearchItems.TurbineNumber, null))
                    {
                        cmd.Parameters.Add("@TurbineNumber", SqlDbType.BigInt);
                        cmd.Parameters["@TurbineNumber"].Value = SearchItems.TurbineNumber;
                    }
                    if (!ReferenceEquals(SearchItems.TurbineType, null))
                    {
                        cmd.Parameters.Add("@TurbineType", SqlDbType.NVarChar);
                        cmd.Parameters["@TurbineType"].Value = SearchItems.TurbineType;
                    }
                    if (!ReferenceEquals(SearchItems.RunStatus, null))
                    {
                        cmd.Parameters.Add("@RunStatus", SqlDbType.BigInt);
                        cmd.Parameters["@RunStatus"].Value = SearchItems.RunStatus;
                    }
                    if (!ReferenceEquals(SearchItems.Name, null))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                        cmd.Parameters["@Name"].Value = SearchItems.Name;
                    }
                    if (!ReferenceEquals(SearchItems.Country, null))
                    {
                        cmd.Parameters.Add("@Country", SqlDbType.NVarChar);
                        cmd.Parameters["@Country"].Value = SearchItems.Country;
                    }
                    if (!ReferenceEquals(SearchItems.SiteName, null))
                    {
                        cmd.Parameters.Add("@SiteName", SqlDbType.NVarChar);
                        cmd.Parameters["@SiteName"].Value = SearchItems.SiteName;
                    }
                    //Commented by Siddharth Chauhan on 29-06-2016.
                    //To fix the bug : 82364
                    //if (!ReferenceEquals(SearchItems.SBU, null))
                    //{
                    //    cmd.Parameters.Add("@SBU", SqlDbType.BigInt);
                    //    cmd.Parameters["@SBU"].Value = SearchItems.SBU;
                    //}
                    //Added by Siddharth Chauhan on 29-06-2016.
                    //To fix the bug : 82364
                    if (!ReferenceEquals(SearchItems.SBUName, null))
                    {
                        cmd.Parameters.Add("@SBU", SqlDbType.NVarChar);
                        cmd.Parameters["@SBU"].Value = SearchItems.SBUName;
                    }
                    if (!ReferenceEquals(SearchItems.Search, null))
                    {
                        if (SearchItems.Search.CurrentPageNumber > 0)
                        {
                            cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.Int);
                            cmd.Parameters["@CurrentPageNumber"].Value = SearchItems.Search.CurrentPageNumber;
                        }
                        if (SearchItems.Search.RecordsPerPage > 0)
                        {
                            cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                            cmd.Parameters["@RecordsPerPage"].Value = SearchItems.Search.RecordsPerPage;
                        }
                    }
                    cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                    cmd.Parameters["@TotalRecordCount"].Value = 0;
                    cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                    //Added by Siddharth Chauhan on 08-06-2016.
                    //to filter the records on the basis of State(UnApproved,Accpeted,Rejected).
                    //Task No. : 75297
                    if (!ReferenceEquals(SearchItems.State, null))
                    {
                        cmd.Parameters.Add("@State", SqlDbType.TinyInt);
                        cmd.Parameters["@State"].Value = SearchItems.State;
                    }

                    //Added by Siddharth Chauhan on 08-06-2016.
                    //to get total count of UnApproved.
                    //Task No. : 75297
                    cmd.Parameters.Add("@TotalUnApprovedRecords", SqlDbType.Int);
                    cmd.Parameters["@TotalUnApprovedRecords"].Value = 0;
                    cmd.Parameters["@TotalUnApprovedRecords"].Direction = ParameterDirection.InputOutput;

                    //Added by Siddharth Chauhan on 08-06-2016.
                    //to get total count of Accepted.
                    //Task No. : 75297
                    cmd.Parameters.Add("@TotalAcceptedRecords", SqlDbType.Int);
                    cmd.Parameters["@TotalAcceptedRecords"].Value = 0;
                    cmd.Parameters["@TotalAcceptedRecords"].Direction = ParameterDirection.InputOutput;

                    //Added by Siddharth Chauhan on 08-06-2016.
                    //to get total count of Rejected.
                    //Task No. : 75297
                    cmd.Parameters.Add("@TotalRejectedRecords", SqlDbType.Int);
                    cmd.Parameters["@TotalRejectedRecords"].Value = 0;
                    cmd.Parameters["@TotalRejectedRecords"].Direction = ParameterDirection.InputOutput;

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsCirData);
                            if (dsCirData.Tables.Count > 0)
                            {
                                if (dsCirData.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow drH in dsCirData.Tables[0].Rows)
                                    {
                                        lstComponentInspectionReport.Add(
                                            new Cir.Sync.Services.CIR.ComponentInspectionReport()
                                            {
                                                ComponentInspectionReportId = Convert.ToInt64(drH["ComponentInspectionReportId"]),
                                                ReportTypeId = Convert.ToInt64(drH["ReportTypeId"]),
                                                ComponentInspectionReportTypeId = Convert.ToInt64(drH["ComponentInspectionReportTypeId"]),
                                                CIMCaseNumber = Convert.ToInt64(drH["CIMCaseNumber"]),
                                                TurbineNumber = Convert.ToInt64(drH["TurbineNumber"]),
                                                Country = Convert.ToString(drH["Country"]),
                                                Brand = Convert.ToString(drH["Brand"]),
                                                TurbineType = Convert.ToString(drH["TurbineType"]),
                                                InspectionDate = Convert.ToDateTime(drH["Created"]),
                                                ComponentInspectionReportName = Convert.ToString(drH["Name"]),
                                                TotalRecords = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value),
                                                TotalUnApprovedRecords = Convert.ToInt32(cmd.Parameters["@TotalUnApprovedRecords"].Value),
                                                TotalAcceptedRecords = Convert.ToInt32(cmd.Parameters["@TotalAcceptedRecords"].Value),
                                                TotalRejectedRecords = Convert.ToInt32(cmd.Parameters["@TotalRejectedRecords"].Value),

                                                HideProgress = (drH["Hide_Progress"] != null ? Convert.ToInt32(drH["Hide_Progress"]) : (int?)null),
                                                HideLock = (drH["Hide_Lock"] != null ? Convert.ToString(drH["Hide_Lock"]) : null),
                                                CirDataID = Convert.ToInt64(drH["CirDataId"]),
                                                CIRID = Convert.ToInt64(drH["CirId"]),
                                                HideTemplateVer = (drH["Hide_TemplateVer"] != null ? Convert.ToString(drH["Hide_TemplateVer"]) : null),
                                                ComponentInspectionReportStateId = Convert.ToInt64(drH["CIRState"])
                                            }
                                          );
                                    }
                                }
                                else
                                {
                                    lstComponentInspectionReport.Add(
                                                                      new Cir.Sync.Services.CIR.ComponentInspectionReport()
                                                                      {
                                                                          ComponentInspectionReportId = 0,
                                                                          ReportTypeId = 0,
                                                                          ComponentInspectionReportTypeId = 0,
                                                                          CIMCaseNumber = 0,
                                                                          TurbineNumber = 0,
                                                                          Country = "",
                                                                          TurbineType = "",
                                                                          InspectionDate = DateTime.Now,
                                                                          ComponentInspectionReportName = "",
                                                                          TotalRecords = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value),
                                                                          TotalUnApprovedRecords = Convert.ToInt32(cmd.Parameters["@TotalUnApprovedRecords"].Value),
                                                                          TotalAcceptedRecords = Convert.ToInt32(cmd.Parameters["@TotalAcceptedRecords"].Value),
                                                                          TotalRejectedRecords = Convert.ToInt32(cmd.Parameters["@TotalRejectedRecords"].Value),

                                                                          HideProgress = null,
                                                                          HideLock = null,
                                                                          CirDataID = 0,
                                                                          CIRID = 0,
                                                                          HideTemplateVer = null,
                                                                          ComponentInspectionReportStateId = 0
                                                                      }
                                                                    );
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        DACIRLog.SaveCirLog(0, "CirQuickSearch() is failed" + ex.Message, LogType.Error, "");
                    }
                }
            }

            return lstComponentInspectionReport;
        }
        private static bool SaveCIRPdfWithContext(CIM_CIREntities context, string uid, int state, string pdfdata = "", string name = "")
        {


            PDF pdf = context.PDF.Where(x => x.CIRTemplateGUID == uid).FirstOrDefault();
            if (pdf == null)
            {
                pdf = new PDF();
                pdf.CIRTemplateGUID = uid;
                pdf.CIRState = (int)state;
                pdf.CIRName = name;
                pdf.PDFData = Convert.FromBase64String(pdfdata);
                context.PDF.Add(pdf);
            }
            else
            {
                pdf.CIRState = (int)state;
                pdf.CIRName = name;
                pdf.PDFData = Convert.FromBase64String(pdfdata);
            }
            context.SaveChanges();

            return true;

        }
        //private static byte[] GeneratePDFFromHTML(string html)
        //{
        //    byte[] data = null;

        //    try
        //    {
        //        string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
        //        Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
        //        Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
        //        Spire.License.LicenseProvider.LoadLicense();
        //        //Spire.Pdf.PdfDocument pdf = new PdfDocument();
        //        //PdfHtmlLayoutFormat htmlLayoutFormat = new Spire.Pdf.HtmlConverter.PdfHtmlLayoutFormat();
        //        //htmlLayoutFormat.IsWaiting = false;
        //        //PdfPageSettings seting = new PdfPageSettings();
        //        //seting.Size = PdfPageSize.A4;
        //        //System.Threading.Thread thread = new System.Threading.Thread(() => { pdf.LoadFromHTML(html, false, seting, htmlLayoutFormat); });
        //        //thread.SetApartmentState(System.Threading.ApartmentState.STA);
        //        //thread.Start();
        //        //thread.Join();
        //        html = html.Replace("&quot;", @"""");
        //       // string pdfstring = null;
        //        //string htmlstring = "<!DOCTYPE html><html><body><h1>Header 1</h1><p>First paragraph</p></body></html>";
        //        Spire.Doc.Document doc = new Spire.Doc.Document();
        //        Spire.Doc.Section sec = doc.AddSection();
        //        Paragraph para = sec.AddParagraph();
        //       // document.Sections(0).Paragraphs(3).AppendBreak(BreakType.PageBreak);

        //        para.AppendHTML(html);
        //        using (MemoryStream pdfstream = new MemoryStream())
        //        {
        //            doc.SaveToStream(pdfstream, Spire.Doc.FileFormat.PDF);
        //            data = pdfstream.ToArray();
        //           // pdfstring = System.Convert.ToBase64String(pdfbytes);
        //        }
        //        //pdf.SaveToFile("output.pdf");
        //        //System.Diagnostics.Process.Start("output.pdf");
        //        //using (MemoryStream ms2 = new MemoryStream())
        //        //{
        //        //    pdf.SaveToStream(ms2, Spire.Pdf.FileFormat.PDF);
        //        //    //save to byte array
        //        //    data = ms2.ToArray();

        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Generating CIR PDF : " + ex.Message, LogType.Error, "");

        //    }
        //    return data;
        //}
        protected static void LogMessage(string Message)
        {
            GlobalErrorHandler errorHandler = new GlobalErrorHandler();
            errorHandler.Log(Message: Message);
        }
        public static List<CirDataDetail> GetMigrationCirList()
        {
            DataSet dsCirList = new DataSet();            
            List<CirDataDetail> lstCIRDetails = null;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetMigrationCIRList", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FromDate", SqlDbType.Date);
                    cmd.Parameters["@FromDate"].Value = System.DateTime.Now;

                    cmd.Parameters.Add("@ToDate", SqlDbType.Date);
                    cmd.Parameters["@ToDate"].Value = System.DateTime.Now;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsCirList);
                    }
                    if (dsCirList.Tables[0].Rows.Count > 0)
                    {
                        lstCIRDetails = new List<CirDataDetail>();
                        foreach (DataRow dr in dsCirList.Tables[0].Rows)
                        {
                            lstCIRDetails.Add(
                                new CirDataDetail()
                                {
                                    CirDataId = Convert.ToInt64(dr["CirDataId"].ToString()),
                                    CirId = Convert.ToString(dr["CirId"]),
                                    CirState = Convert.ToInt16(dr["State"]),
                                    ComponentType = Convert.ToString(dr["ComponentInspectionReportTypeId"]),
                                    ReportType = Convert.ToString(dr["ReportTypeId"]),
                                    TemplateVersion = Convert.ToString(dr["TemplateVersion"]),
                                    FormIOGUID = Convert.ToString(dr["FormIOGUID"])
                                }
                           );
                        };
                    }
                }
            }
            return lstCIRDetails;
        }

        /// <summary>
        ///  Return Connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
        private enum ComponentType
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
        /// <summary>
        ///  Unlock Cir Data By CirID
        /// </summary>
        /// <param name="CirID"></param>
        /// <returns>true/false</returns>
        /// 
        public static bool UnlockCirDataByCirID(long CirID)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var result = context.CirData.Where(im => im.CirId == CirID && im.Deleted == false);
                if (result != null)
                {
                    foreach (CirData CirDataRow in result)
                    {
                        CirDataRow.Locked = null;
                        CirDataRow.LockedBy = null;
                    }
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool LockCirDataByCirID(long CirID, string modifiedby)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var result = context.CirData.Where(im => im.CirId == CirID && im.Deleted == false).OrderByDescending(x => x.Created).FirstOrDefault();
                if (result != null)
                {

                    result.Locked = 1;
                    result.LockedBy = modifiedby;
                    context.SaveChanges();
                    return true;

                }

            }
            return false;
        }
        /// <summary>
        ///  Update Cir Status By CirID
        /// </summary>
        /// <param name="CirID"></param>
        /// <returns>true/false</returns>
        /// 
        public static bool UpdateCirStateByCirID(long CirID)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var result = context.CirData.Where(im => im.CirId == CirID && im.Deleted == false);
                if (result != null)
                {
                    foreach (CirData CirDataRow in result)
                    {
                        CirDataRow.State = 0;
                    }
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        ///  Get Cir Status By CirID
        /// </summary>
        /// <param name= List "CirID"></param>
        /// <returns>true/false</returns>
        /// 
        public static List<Cir.Sync.Services.CIR.CirStateResponse> GetCirStateByCirIDs(List<Cir.Sync.Services.CIR.CirStateResponse> CirIDs)
        {
            List<Cir.Sync.Services.CIR.CirStateResponse> CirStateList = new List<Cir.Sync.Services.CIR.CirStateResponse>();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                try
                {


                    foreach (Cir.Sync.Services.CIR.CirStateResponse CirID in CirIDs)
                    {

                        var CirState = context.CirData.Where(x => x.CirId == CirID.CIRId && x.Deleted == false).OrderByDescending(x => x.CirDataId).Select(x => x.State).FirstOrDefault();


                        if (!ReferenceEquals(CirState, null))
                        {
                            CirStateList.Add(new Cir.Sync.Services.CIR.CirStateResponse()
                            {
                                CirDataLocalID = CirID.CirDataLocalID,
                                CIRId = CirID.CIRId,
                                CIRState = Convert.ToInt32(CirState)
                            }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    DACIRLog.SaveCirLog(0, "GetCirStateByCirIDs() is failed" + ex.Message, LogType.Error, "");
                }

                return CirStateList;
            }
        }

        /// <summary>
        /// Common Insert and update functions for General
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportGeneral ComponentInspectionGeneral(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportGeneral objCompGeneral = new ComponentInspectionReportGeneral();
            if (Isupdate == 1)
            {
                objCompGeneral = CIRListUp.ComponentInspectionReportGeneral.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompGeneral, null))
                {
                    objCompGeneral.ComponentInspectionReportId = CIRList.ComponentInspectionReportId;
                    objCompGeneral.GeneralComponentGroupId = CIRList.General.GeneralComponentGroupId;
                    objCompGeneral.GeneralComponentType = CIRList.General.GeneralComponentType;
                    objCompGeneral.VestasUniqueIdentifier = CIRList.General.VestasUniqueIdentifier;
                    objCompGeneral.GeneralComponentManufacturer = CIRList.General.GeneralComponentManufacturer;
                    objCompGeneral.GeneralOtherGearboxType = CIRList.General.GeneralOtherGearboxType;
                    objCompGeneral.GeneralClaimRelevantBooleanAnswerId = CIRList.General.GeneralClaimRelevantBooleanAnswerId;
                    objCompGeneral.GeneralOtherGearboxManufacturer = CIRList.General.GeneralOtherGearboxManufacturer;
                    objCompGeneral.GeneralComponentSerialNumber = CIRList.General.GeneralComponentSerialNumber;
                    objCompGeneral.GeneralGeneratorManufacturerId = CIRList.General.GeneralGeneratorManufacturerId;
                    objCompGeneral.GeneralTransformerManufacturerId = CIRList.General.GeneralTransformerManufacturerId;
                    objCompGeneral.GeneralGearboxManufacturerId = CIRList.General.GeneralGearboxManufacturerId;
                    objCompGeneral.GeneralTowerTypeId = CIRList.General.GeneralTowerTypeId;
                    objCompGeneral.GeneralTowerHeightId = CIRList.General.GeneralTowerHeightId;
                    objCompGeneral.GeneralBlade1SerialNumber = CIRList.General.GeneralBlade1SerialNumber;
                    objCompGeneral.GeneralBlade2SerialNumber = CIRList.General.GeneralBlade2SerialNumber;
                    objCompGeneral.GeneralBlade3SerialNumber = CIRList.General.GeneralBlade3SerialNumber;
                    objCompGeneral.GeneralControllerTypeId = CIRList.General.GeneralControllerTypeId;
                    objCompGeneral.GeneralSoftwareRelease = CIRList.General.GeneralSoftwareRelease;
                    objCompGeneral.GeneralRamDumpNumber = CIRList.General.GeneralRamDumpNumber;
                    objCompGeneral.GeneralVDFTrackNumber = CIRList.General.GeneralVDFTrackNumber;
                    objCompGeneral.GeneralPicturesIncludedBooleanAnswerId = (CIRList.General.GeneralPicturesIncludedBooleanAnswerId == 0) ? 1 : CIRList.General.GeneralPicturesIncludedBooleanAnswerId;
                    objCompGeneral.GeneralInitiatedBy1 = CIRList.General.GeneralInitiatedBy1;
                    objCompGeneral.GeneralInitiatedBy2 = CIRList.General.GeneralInitiatedBy2;
                    objCompGeneral.GeneralInitiatedBy3 = CIRList.General.GeneralInitiatedBy3;
                    objCompGeneral.GeneralInitiatedBy4 = CIRList.General.GeneralInitiatedBy4;
                    objCompGeneral.GeneralMeasurementsConducted1 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted2 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted3 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralMeasurementsConducted4 = CIRList.General.GeneralMeasurementsConducted1;
                    objCompGeneral.GeneralExecutedBy1 = CIRList.General.GeneralExecutedBy1;
                    objCompGeneral.GeneralExecutedBy2 = CIRList.General.GeneralExecutedBy2;
                    objCompGeneral.GeneralExecutedBy3 = CIRList.General.GeneralExecutedBy3;
                    objCompGeneral.GeneralExecutedBy4 = CIRList.General.GeneralExecutedBy4;
                    objCompGeneral.GeneralPositionOfFailedItem = CIRList.General.GeneralPositionOfFailedItem;
                }
            }
            else
            {
                objCompGeneral = new Edmx.ComponentInspectionReportGeneral
                {
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    GeneralComponentGroupId = CIRList.General.GeneralComponentGroupId,
                    GeneralComponentType = CIRList.General.GeneralComponentType,
                    VestasUniqueIdentifier = CIRList.General.VestasUniqueIdentifier,
                    GeneralComponentManufacturer = CIRList.General.GeneralComponentManufacturer,
                    GeneralOtherGearboxType = CIRList.General.GeneralOtherGearboxType,
                    GeneralClaimRelevantBooleanAnswerId = CIRList.General.GeneralClaimRelevantBooleanAnswerId,
                    GeneralOtherGearboxManufacturer = CIRList.General.GeneralOtherGearboxManufacturer,
                    GeneralComponentSerialNumber = CIRList.General.GeneralComponentSerialNumber,
                    GeneralGeneratorManufacturerId = CIRList.General.GeneralGeneratorManufacturerId,
                    GeneralTransformerManufacturerId = CIRList.General.GeneralTransformerManufacturerId,
                    GeneralGearboxManufacturerId = CIRList.General.GeneralGearboxManufacturerId,
                    GeneralTowerTypeId = CIRList.General.GeneralTowerTypeId,
                    GeneralTowerHeightId = CIRList.General.GeneralTowerHeightId,
                    GeneralBlade1SerialNumber = CIRList.General.GeneralBlade1SerialNumber,
                    GeneralBlade2SerialNumber = CIRList.General.GeneralBlade2SerialNumber,
                    GeneralBlade3SerialNumber = CIRList.General.GeneralBlade3SerialNumber,
                    GeneralControllerTypeId = CIRList.General.GeneralControllerTypeId,
                    GeneralSoftwareRelease = CIRList.General.GeneralSoftwareRelease,
                    GeneralRamDumpNumber = CIRList.General.GeneralRamDumpNumber,
                    GeneralVDFTrackNumber = CIRList.General.GeneralVDFTrackNumber,
                    GeneralPicturesIncludedBooleanAnswerId = (CIRList.General.GeneralPicturesIncludedBooleanAnswerId == 0) ? 1 : CIRList.General.GeneralPicturesIncludedBooleanAnswerId,
                    GeneralInitiatedBy1 = CIRList.General.GeneralInitiatedBy1,
                    GeneralInitiatedBy2 = CIRList.General.GeneralInitiatedBy2,
                    GeneralInitiatedBy3 = CIRList.General.GeneralInitiatedBy3,
                    GeneralInitiatedBy4 = CIRList.General.GeneralInitiatedBy4,
                    GeneralMeasurementsConducted1 = CIRList.General.GeneralMeasurementsConducted1,
                    GeneralMeasurementsConducted2 = CIRList.General.GeneralMeasurementsConducted2,
                    GeneralMeasurementsConducted3 = CIRList.General.GeneralMeasurementsConducted3,
                    GeneralMeasurementsConducted4 = CIRList.General.GeneralMeasurementsConducted4,
                    GeneralExecutedBy1 = CIRList.General.GeneralExecutedBy1,
                    GeneralExecutedBy2 = CIRList.General.GeneralExecutedBy2,
                    GeneralExecutedBy3 = CIRList.General.GeneralExecutedBy3,
                    GeneralExecutedBy4 = CIRList.General.GeneralExecutedBy4,
                    GeneralPositionOfFailedItem = CIRList.General.GeneralPositionOfFailedItem
                };
            }
            return objCompGeneral;
        }
        /// <summary>
        /// Common Insert and update functions for Blade
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportBlade ComponentInspectionBlade(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportBlade objCompBlade = new Edmx.ComponentInspectionReportBlade();
            if (Isupdate == 1)
            {
                objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompBlade, null))
                {
                    objCompBlade.VestasUniqueIdentifier = CIRList.BladeData.VestasUniqueIdentifier;
                    objCompBlade.BladeLengthId = CIRList.BladeData.BladeLengthId;
                    objCompBlade.BladeColorId = CIRList.BladeData.BladeColorId;
                    objCompBlade.BladeSerialNumber = CIRList.BladeData.BladeSerialNumber;
                    objCompBlade.BladePicturesIncludedBooleanAnswerId = CIRList.BladeData.BladePicturesIncludedBooleanAnswerId;
                    objCompBlade.BladeOtherSerialNumber1 = CIRList.BladeData.BladeOtherSerialNumber1;
                    objCompBlade.BladeOtherSerialNumber2 = CIRList.BladeData.BladeOtherSerialNumber2;
                    objCompBlade.BladeDamageIdentified = CIRList.BladeData.BladeDamageIdentified;
                    objCompBlade.BladeFaultCodeClassificationId = CIRList.BladeData.BladeFaultCodeClassificationId;
                    objCompBlade.BladeFaultCodeCauseId = CIRList.BladeData.BladeFaultCodeCauseId;
                    objCompBlade.BladeFaultCodeTypeId = CIRList.BladeData.BladeFaultCodeTypeId;
                    objCompBlade.BladeFaultCodeAreaId = CIRList.BladeData.BladeFaultCodeAreaId;
                    objCompBlade.BladeClaimRelevantBooleanAnswerId = CIRList.BladeData.BladeClaimRelevantBooleanAnswerId;
                    objCompBlade.BladeLsVtNumber = CIRList.BladeData.BladeLsVtNumber;
                    objCompBlade.BladeLsCalibrationDate = ParseDatetime(CIRList.BladeData.BladeLsCalibrationDate);
                    objCompBlade.BladeLsLeewardSidePreRepairTip = CIRList.BladeData.BladeLsLeewardSidePreRepairTip;
                    objCompBlade.BladeLsLeewardSidePostRepairTip = CIRList.BladeData.BladeLsLeewardSidePostRepairTip;
                    objCompBlade.BladeLsLeewardSidePreRepair2 = CIRList.BladeData.BladeLsLeewardSidePreRepair2;
                    objCompBlade.BladeLsLeewardSidePostRepair2 = CIRList.BladeData.BladeLsLeewardSidePostRepair2;
                    objCompBlade.BladeLsLeewardSidePreRepair3 = CIRList.BladeData.BladeLsLeewardSidePreRepair3;
                    objCompBlade.BladeLsLeewardSidePostRepair3 = CIRList.BladeData.BladeLsLeewardSidePostRepair3;
                    objCompBlade.BladeLsLeewardSidePreRepair4 = CIRList.BladeData.BladeLsLeewardSidePreRepair4;
                    objCompBlade.BladeLsLeewardSidePostRepair4 = CIRList.BladeData.BladeLsLeewardSidePostRepair4;
                    objCompBlade.BladeLsLeewardSidePreRepair5 = CIRList.BladeData.BladeLsLeewardSidePreRepair5;
                    objCompBlade.BladeLsLeewardSidePostRepair5 = CIRList.BladeData.BladeLsLeewardSidePostRepair5;
                    objCompBlade.BladeLsLeewardSidePreRepair6 = CIRList.BladeData.BladeLsLeewardSidePreRepair6;
                    objCompBlade.BladeLsLeewardSidePostRepair6 = CIRList.BladeData.BladeLsLeewardSidePostRepair6;
                    objCompBlade.BladeLsLeewardSidePreRepair7 = CIRList.BladeData.BladeLsLeewardSidePreRepair7;
                    objCompBlade.BladeLsLeewardSidePostRepair7 = CIRList.BladeData.BladeLsLeewardSidePostRepair7;
                    objCompBlade.BladeLsLeewardSidePreRepair8 = CIRList.BladeData.BladeLsLeewardSidePreRepair8;
                    objCompBlade.BladeLsLeewardSidePostRepair8 = CIRList.BladeData.BladeLsLeewardSidePostRepair8;
                    objCompBlade.BladeLsWindwardSidePreRepairTip = CIRList.BladeData.BladeLsWindwardSidePreRepairTip;
                    objCompBlade.BladeLsWindwardSidePostRepairTip = CIRList.BladeData.BladeLsWindwardSidePostRepairTip;
                    objCompBlade.BladeLsWindwardSidePreRepair2 = CIRList.BladeData.BladeLsWindwardSidePreRepair2;
                    objCompBlade.BladeLsWindwardSidePostRepair2 = CIRList.BladeData.BladeLsWindwardSidePostRepair2;
                    objCompBlade.BladeLsWindwardSidePreRepair3 = CIRList.BladeData.BladeLsWindwardSidePreRepair3;
                    objCompBlade.BladeLsWindwardSidePostRepair3 = CIRList.BladeData.BladeLsWindwardSidePostRepair3;
                    objCompBlade.BladeLsWindwardSidePreRepair4 = CIRList.BladeData.BladeLsWindwardSidePreRepair4;
                    objCompBlade.BladeLsWindwardSidePostRepair4 = CIRList.BladeData.BladeLsWindwardSidePostRepair4;
                    objCompBlade.BladeLsWindwardSidePreRepair5 = CIRList.BladeData.BladeLsWindwardSidePreRepair5;
                    objCompBlade.BladeLsWindwardSidePostRepair5 = CIRList.BladeData.BladeLsWindwardSidePostRepair5;
                    objCompBlade.BladeLsWindwardSidePreRepair6 = CIRList.BladeData.BladeLsWindwardSidePreRepair6;
                    objCompBlade.BladeLsWindwardSidePostRepair6 = CIRList.BladeData.BladeLsWindwardSidePostRepair6;
                    objCompBlade.BladeLsWindwardSidePreRepair7 = CIRList.BladeData.BladeLsWindwardSidePreRepair7;
                    objCompBlade.BladeLsWindwardSidePostRepair7 = CIRList.BladeData.BladeLsWindwardSidePostRepair7;
                    objCompBlade.BladeLsWindwardSidePreRepair8 = CIRList.BladeData.BladeLsWindwardSidePreRepair8;
                    objCompBlade.BladeLsWindwardSidePostRepair8 = CIRList.BladeData.BladeLsWindwardSidePostRepair8;
                    objCompBlade.BladeInspectionReportDescription = CIRList.BladeData.BladeInspectionReportDescription;
                    objCompBlade.BladeManufacturerId = CIRList.BladeData.BladeManufacturerId;
                }
            }
            else
            {
                objCompBlade = new Edmx.ComponentInspectionReportBlade
                {
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    ComponentInspectionReportBladeId = CIRList.BladeData.ComponentInspectionReportBladeId,
                    VestasUniqueIdentifier = CIRList.BladeData.VestasUniqueIdentifier,
                    BladeLengthId = CIRList.BladeData.BladeLengthId,
                    BladeColorId = CIRList.BladeData.BladeColorId,
                    BladeSerialNumber = CIRList.BladeData.BladeSerialNumber,
                    BladePicturesIncludedBooleanAnswerId = CIRList.BladeData.BladePicturesIncludedBooleanAnswerId,
                    BladeOtherSerialNumber1 = CIRList.BladeData.BladeOtherSerialNumber1,
                    BladeOtherSerialNumber2 = CIRList.BladeData.BladeOtherSerialNumber2,
                    BladeDamageIdentified = CIRList.BladeData.BladeDamageIdentified,
                    BladeFaultCodeClassificationId = CIRList.BladeData.BladeFaultCodeClassificationId,
                    BladeFaultCodeCauseId = CIRList.BladeData.BladeFaultCodeCauseId,
                    BladeFaultCodeTypeId = CIRList.BladeData.BladeFaultCodeTypeId,
                    BladeFaultCodeAreaId = CIRList.BladeData.BladeFaultCodeAreaId,
                    BladeClaimRelevantBooleanAnswerId = CIRList.BladeData.BladeClaimRelevantBooleanAnswerId,
                    BladeLsVtNumber = CIRList.BladeData.BladeLsVtNumber,
                    BladeLsCalibrationDate = ParseDatetime(CIRList.BladeData.strBladeLsCalibrationDate),
                    BladeLsLeewardSidePreRepairTip = CIRList.BladeData.BladeLsLeewardSidePreRepairTip,
                    BladeLsLeewardSidePostRepairTip = CIRList.BladeData.BladeLsLeewardSidePostRepairTip,
                    BladeLsLeewardSidePreRepair2 = CIRList.BladeData.BladeLsLeewardSidePreRepair2,
                    BladeLsLeewardSidePostRepair2 = CIRList.BladeData.BladeLsLeewardSidePostRepair2,
                    BladeLsLeewardSidePreRepair3 = CIRList.BladeData.BladeLsLeewardSidePreRepair3,
                    BladeLsLeewardSidePostRepair3 = CIRList.BladeData.BladeLsLeewardSidePostRepair3,
                    BladeLsLeewardSidePreRepair4 = CIRList.BladeData.BladeLsLeewardSidePreRepair4,
                    BladeLsLeewardSidePostRepair4 = CIRList.BladeData.BladeLsLeewardSidePostRepair4,
                    BladeLsLeewardSidePreRepair5 = CIRList.BladeData.BladeLsLeewardSidePreRepair5,
                    BladeLsLeewardSidePostRepair5 = CIRList.BladeData.BladeLsLeewardSidePostRepair5,
                    BladeLsLeewardSidePreRepair6 = CIRList.BladeData.BladeLsLeewardSidePreRepair6,
                    BladeLsLeewardSidePostRepair6 = CIRList.BladeData.BladeLsLeewardSidePostRepair6,
                    BladeLsLeewardSidePreRepair7 = CIRList.BladeData.BladeLsLeewardSidePreRepair7,
                    BladeLsLeewardSidePostRepair7 = CIRList.BladeData.BladeLsLeewardSidePostRepair7,
                    BladeLsLeewardSidePreRepair8 = CIRList.BladeData.BladeLsLeewardSidePreRepair8,
                    BladeLsLeewardSidePostRepair8 = CIRList.BladeData.BladeLsLeewardSidePostRepair8,
                    BladeLsWindwardSidePreRepairTip = CIRList.BladeData.BladeLsWindwardSidePreRepairTip,
                    BladeLsWindwardSidePostRepairTip = CIRList.BladeData.BladeLsWindwardSidePostRepairTip,
                    BladeLsWindwardSidePreRepair2 = CIRList.BladeData.BladeLsWindwardSidePreRepair2,
                    BladeLsWindwardSidePostRepair2 = CIRList.BladeData.BladeLsWindwardSidePostRepair2,
                    BladeLsWindwardSidePreRepair3 = CIRList.BladeData.BladeLsWindwardSidePreRepair3,
                    BladeLsWindwardSidePostRepair3 = CIRList.BladeData.BladeLsWindwardSidePostRepair3,
                    BladeLsWindwardSidePreRepair4 = CIRList.BladeData.BladeLsWindwardSidePreRepair4,
                    BladeLsWindwardSidePostRepair4 = CIRList.BladeData.BladeLsWindwardSidePostRepair4,
                    BladeLsWindwardSidePreRepair5 = CIRList.BladeData.BladeLsWindwardSidePreRepair5,
                    BladeLsWindwardSidePostRepair5 = CIRList.BladeData.BladeLsWindwardSidePostRepair5,
                    BladeLsWindwardSidePreRepair6 = CIRList.BladeData.BladeLsWindwardSidePreRepair6,
                    BladeLsWindwardSidePostRepair6 = CIRList.BladeData.BladeLsWindwardSidePostRepair6,
                    BladeLsWindwardSidePreRepair7 = CIRList.BladeData.BladeLsWindwardSidePreRepair7,
                    BladeLsWindwardSidePostRepair7 = CIRList.BladeData.BladeLsWindwardSidePostRepair7,
                    BladeLsWindwardSidePreRepair8 = CIRList.BladeData.BladeLsWindwardSidePreRepair8,
                    BladeLsWindwardSidePostRepair8 = CIRList.BladeData.BladeLsWindwardSidePostRepair8,
                    BladeInspectionReportDescription = CIRList.BladeData.BladeInspectionReportDescription,
                    BladeManufacturerId = CIRList.BladeData.BladeManufacturerId,
                    ComponentInspectionReportBladeDamage = new List<Cir.Sync.Services.Edmx.ComponentInspectionReportBladeDamage>()
                };
            }
            return objCompBlade;
        }
        /// <summary>
        /// Common Insert and Update function For Blade Repair
        /// </summary>
        /// <param name="BladeRepairRecordList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportBladeRepairRecord ComponentInspectionBladeRepairs(Cir.Sync.Services.CIR.ComponentInspectionReportBladeRepairRecord BladeRepairRecordList, Edmx.ComponentInspectionReportBlade objCompoBlade, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportBladeRepairRecord objBladeRepairRecord = new Edmx.ComponentInspectionReportBladeRepairRecord();
            if (Isupdate == 1)
            {
                Edmx.ComponentInspectionReportBlade objCompBlade = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                objBladeRepairRecord = CIRListUp.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault().ComponentInspectionReportBladeRepairRecord.FirstOrDefault();
                if (!ReferenceEquals(objBladeRepairRecord, null))
                {
                    objBladeRepairRecord.ComponentInspectionReportBladeId = objCompBlade.ComponentInspectionReportBladeId;
                    objBladeRepairRecord.BladeAmbientTemp = BladeRepairRecordList.BladeAmbientTemp;
                    objBladeRepairRecord.BladeHumidity = BladeRepairRecordList.BladeHumidity;
                    objBladeRepairRecord.BladeAdditionalDocumentReference = BladeRepairRecordList.BladeAdditionalDocumentReference;
                    objBladeRepairRecord.BladeResinType = BladeRepairRecordList.BladeResinType;
                    objBladeRepairRecord.BladeResinTypeBatchNumbers = BladeRepairRecordList.BladeResinTypeBatchNumbers;
                    objBladeRepairRecord.BladeResinTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeResinTypeExpiryDate);
                    objBladeRepairRecord.BladeHardenerType = BladeRepairRecordList.BladeHardenerType;
                    objBladeRepairRecord.BladeHardenerTypeBatchNumbers = BladeRepairRecordList.BladeHardenerTypeBatchNumbers;
                    objBladeRepairRecord.BladeHardenerTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeHardenerTypeExpiryDate);
                    objBladeRepairRecord.BladeGlassSupplier = BladeRepairRecordList.BladeGlassSupplier;
                    objBladeRepairRecord.BladeGlassSupplierBatchNumbers = BladeRepairRecordList.BladeGlassSupplierBatchNumbers;
                    objBladeRepairRecord.BladeSurfaceMaxTemperature = BladeRepairRecordList.BladeSurfaceMaxTemperature;
                    objBladeRepairRecord.BladeSurfaceMinTemperature = BladeRepairRecordList.BladeSurfaceMinTemperature;
                    objBladeRepairRecord.BladeResinUsed = BladeRepairRecordList.BladeResinUsed;
                    objBladeRepairRecord.BladePostCureMaxTemperature = BladeRepairRecordList.BladePostCureMaxTemperature;
                    objBladeRepairRecord.BladePostCureMinTemperature = BladeRepairRecordList.BladePostCureMinTemperature;
                    objBladeRepairRecord.BladeTurnOffTime = ParseDatetime(BladeRepairRecordList.strBladeTurnOffTime);
                    objBladeRepairRecord.BladeTotalCureTime = BladeRepairRecordList.BladeTotalCureTime;
                }
            }
            else
            {
                objBladeRepairRecord = new Edmx.ComponentInspectionReportBladeRepairRecord
                {
                    ComponentInspectionReportBladeRepairRecordId = BladeRepairRecordList.ComponentInspectionReportBladeRepairRecordId,
                    ComponentInspectionReportBladeId = objCompoBlade.ComponentInspectionReportBladeId,
                    BladeAmbientTemp = BladeRepairRecordList.BladeAmbientTemp,
                    BladeHumidity = BladeRepairRecordList.BladeHumidity,
                    BladeAdditionalDocumentReference = BladeRepairRecordList.BladeAdditionalDocumentReference,
                    BladeResinType = BladeRepairRecordList.BladeResinType,
                    BladeResinTypeBatchNumbers = BladeRepairRecordList.BladeResinTypeBatchNumbers,
                    BladeResinTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeResinTypeExpiryDate),
                    BladeHardenerType = BladeRepairRecordList.BladeHardenerType,
                    BladeHardenerTypeBatchNumbers = BladeRepairRecordList.BladeHardenerTypeBatchNumbers,
                    BladeHardenerTypeExpiryDate = ParseDatetime(BladeRepairRecordList.strBladeHardenerTypeExpiryDate),
                    BladeGlassSupplier = BladeRepairRecordList.BladeGlassSupplier,
                    BladeGlassSupplierBatchNumbers = BladeRepairRecordList.BladeGlassSupplierBatchNumbers,
                    BladeSurfaceMaxTemperature = BladeRepairRecordList.BladeSurfaceMaxTemperature,
                    BladeSurfaceMinTemperature = BladeRepairRecordList.BladeSurfaceMinTemperature,
                    BladeResinUsed = BladeRepairRecordList.BladeResinUsed,
                    BladePostCureMaxTemperature = BladeRepairRecordList.BladePostCureMaxTemperature,
                    BladePostCureMinTemperature = BladeRepairRecordList.BladePostCureMinTemperature,
                    BladeTurnOffTime = ParseDatetime(BladeRepairRecordList.strBladeTurnOffTime),
                    BladeTotalCureTime = BladeRepairRecordList.BladeTotalCureTime
                };
            }
            return objBladeRepairRecord;
        }
        /// <summary>
        /// Common Insert and Update function For Blade Damage
        /// </summary>
        /// <param name="objBladeDam"></param>
        /// <param name="objCompoBlade"></param>
        /// <returns></returns>
        //public static Edmx.ComponentInspectionReportBladeDamage ComponentInspectionBladeDamages(CIR.ComponentInspectionReportBladeDamage objBladeDam, Edmx.ComponentInspectionReportBlade objCompoBlade, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        //{
        //    Edmx.ComponentInspectionReportBladeDamage objCompoBladeDam = new Edmx.ComponentInspectionReportBladeDamage();
        //    if (Isupdate == 1)
        //    {

        //    }
        //    else
        //    {
        //        objCompoBladeDam = new Edmx.ComponentInspectionReportBladeDamage
        //        {
        //            ComponentInspectionReportBladeDamageId = objBladeDam.ComponentInspectionReportBladeDamageId,
        //            ComponentInspectionReportBladeId = objCompoBlade.ComponentInspectionReportBladeId,
        //            BladeDamagePlacementId = objBladeDam.BladeDamagePlacementId,
        //            BladeInspectionDataId = objBladeDam.BladeInspectionDataId,
        //            BladeRadius = objBladeDam.BladeRadius,
        //            BladeEdgeId = objBladeDam.BladeEdgeId,
        //            BladeDescription = objBladeDam.BladeDescription,
        //            BladePictureNumber = objBladeDam.BladePictureNumber,
        //            PictureOrder = null
        //        };
        //    }

        //    return objCompoBladeDam;
        //}
        /// <summary>
        /// Common Insert and update functions for Skiip
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportSkiiP ComponentInspectionSkiip(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportSkiiP objCompoSkip = new Edmx.ComponentInspectionReportSkiiP();
            if (Isupdate == 1)
            {
                objCompoSkip = CIRListUp.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoSkip, null))
                {
                    objCompoSkip.SkiiPOtherDamagedComponentsReplaced = CIRList.Skiip.SkiiPOtherDamagedComponentsReplaced;
                    objCompoSkip.SkiiPCauseId = CIRList.Skiip.SkiiPCauseId;
                    objCompoSkip.SkiiPQuantityOfFailedModules = CIRList.Skiip.SkiiPQuantityOfFailedModules;
                    objCompoSkip.SkiiP2MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV521BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV522BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV523BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV524BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV524BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV525BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV525BooleanAnswerId;
                    objCompoSkip.SkiiP2MWV526BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV526BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV521BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV522BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV523BooleanAnswerId;
                    objCompoSkip.SkiiP3MWV524xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV524yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV525xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV525yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV526xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId;
                    objCompoSkip.SkiiP3MWV526yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId;
                    objCompoSkip.SkiiP850KWV520BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV520BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV520BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV524BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV524BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV525BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV525BooleanAnswerId;
                    objCompoSkip.SkiiP850KWV526BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV526BooleanAnswerId;
                    objCompoSkip.SkiiPClaimRelevantBooleanAnswerId = (CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId;
                    objCompoSkip.SkiiPNumberofComponents = CIRList.Skiip.SkiiPNumberofComponents;

                }
            }
            else
            {
                objCompoSkip = new Edmx.ComponentInspectionReportSkiiP
                {
                    ComponentInspectionReportSkiiPId = CIRList.Skiip.ComponentInspectionReportSkiiPId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    SkiiPOtherDamagedComponentsReplaced = CIRList.Skiip.SkiiPOtherDamagedComponentsReplaced,
                    SkiiPCauseId = (CIRList.Skiip.SkiiPCauseId == 0) ? 1 : CIRList.Skiip.SkiiPCauseId,// CIRList.Skiip.SkiiPCauseId,
                    SkiiPQuantityOfFailedModules = CIRList.Skiip.SkiiPQuantityOfFailedModules,
                    SkiiP2MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV521BooleanAnswerId,
                    SkiiP2MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV522BooleanAnswerId,
                    SkiiP2MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV523BooleanAnswerId,
                    SkiiP2MWV524BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV524BooleanAnswerId,
                    SkiiP2MWV525BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV525BooleanAnswerId,
                    SkiiP2MWV526BooleanAnswerId = (CIRList.Skiip.SkiiP2MWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP2MWV526BooleanAnswerId,
                    SkiiP3MWV521BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV521BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV521BooleanAnswerId,
                    SkiiP3MWV522BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV522BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV522BooleanAnswerId,
                    SkiiP3MWV523BooleanAnswerId = (CIRList.Skiip.SkiiP3MWV523BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV523BooleanAnswerId,
                    SkiiP3MWV524xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524xBooleanAnswerId,
                    SkiiP3MWV524yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV524yBooleanAnswerId,
                    SkiiP3MWV525xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525xBooleanAnswerId,
                    SkiiP3MWV525yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV525yBooleanAnswerId,
                    SkiiP3MWV526xBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526xBooleanAnswerId,
                    SkiiP3MWV526yBooleanAnswerId = (CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP3MWV526yBooleanAnswerId,
                    SkiiP850KWV520BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV520BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV520BooleanAnswerId,
                    SkiiP850KWV524BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV524BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV524BooleanAnswerId,
                    SkiiP850KWV525BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV525BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV525BooleanAnswerId,
                    SkiiP850KWV526BooleanAnswerId = (CIRList.Skiip.SkiiP850KWV526BooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiP850KWV526BooleanAnswerId,
                    //Modified by Siddharth Chauhan on 24-06-2016.
                    //To resolve Bug : 75527
                    SkiiPClaimRelevantBooleanAnswerId = (CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId == 0) ? null : CIRList.Skiip.SkiiPClaimRelevantBooleanAnswerId,
                    SkiiPNumberofComponents = CIRList.Skiip.SkiiPNumberofComponents
                };
            }

            return objCompoSkip;
        }
        /// <summary>
        /// Common Insert and update functions for GearBox
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportGearbox ComponentInspectionGearBox(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportGearbox objCompoGear = new Edmx.ComponentInspectionReportGearbox();
            if (Isupdate == 1)
            {
                objCompoGear = CIRListUp.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoGear, null))
                {
                    objCompoGear.VestasUniqueIdentifier = CIRList.Gearbox.VestasUniqueIdentifier;
                    objCompoGear.GearboxTypeId = CIRList.Gearbox.GearboxTypeId;
                    objCompoGear.GearboxRevisionId = CIRList.Gearbox.GearboxRevisionId;
                    objCompoGear.GearboxManufacturerId = CIRList.Gearbox.GearboxManufacturerId;
                    objCompoGear.OtherGearboxType = CIRList.Gearbox.OtherGearboxType;
                    objCompoGear.GearboxSerialNumber = CIRList.Gearbox.GearboxSerialNumber;
                    objCompoGear.GearboxOtherManufacturer = CIRList.Gearbox.GearboxOtherManufacturer;
                    objCompoGear.GearboxLastOilChangeDate = ParseDatetime(CIRList.Gearbox.strGearboxLastOilChangeDate);
                    objCompoGear.GearboxOilTypeId = CIRList.Gearbox.GearboxOilTypeId;
                    objCompoGear.GearboxMechanicalOilPumpId = CIRList.Gearbox.GearboxMechanicalOilPumpId;
                    objCompoGear.GearboxOilLevelId = CIRList.Gearbox.GearboxOilLevelId;
                    objCompoGear.GearboxRunHours = CIRList.Gearbox.GearboxRunHours;
                    objCompoGear.GearboxOilTemperature = CIRList.Gearbox.GearboxOilTemperature;
                    objCompoGear.GearboxProduction = CIRList.Gearbox.GearboxProduction;
                    objCompoGear.GearboxGeneratorManufacturerId = CIRList.Gearbox.GearboxGeneratorManufacturerId;
                    objCompoGear.GearboxGeneratorManufacturerId2 = CIRList.Gearbox.GearboxGeneratorManufacturerId2;
                    objCompoGear.GearboxElectricalPumpId = CIRList.Gearbox.GearboxElectricalPumpId;
                    objCompoGear.GearboxShrinkElementId = CIRList.Gearbox.GearboxShrinkElementId;
                    objCompoGear.GearboxShrinkElementSerialNumber = CIRList.Gearbox.GearboxShrinkElementSerialNumber;
                    objCompoGear.GearboxCouplingId = CIRList.Gearbox.GearboxCouplingId;
                    objCompoGear.GearboxFilterBlockTypeId = CIRList.Gearbox.GearboxFilterBlockTypeId;
                    objCompoGear.GearboxInLineFilterId = CIRList.Gearbox.GearboxInLineFilterId;
                    objCompoGear.GearboxOffLineFilterId = CIRList.Gearbox.GearboxOffLineFilterId;
                    objCompoGear.GearboxSoftwareRelease = CIRList.Gearbox.GearboxSoftwareRelease;
                    objCompoGear.GearboxShaftsExactLocation1ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation1ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation2ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation2ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation3ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation3ShaftTypeId;
                    objCompoGear.GearboxShaftsExactLocation4ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation4ShaftTypeId;
                    objCompoGear.GearboxShaftsTypeofDamage1ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage1ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage2ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage2ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage3ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage3ShaftErrorId;
                    objCompoGear.GearboxShaftsTypeofDamage4ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage4ShaftErrorId;
                    objCompoGear.GearboxExactLocation1GearTypeId = CIRList.Gearbox.GearboxExactLocation1GearTypeId;
                    objCompoGear.GearboxExactLocation2GearTypeId = CIRList.Gearbox.GearboxExactLocation2GearTypeId;
                    objCompoGear.GearboxExactLocation3GearTypeId = CIRList.Gearbox.GearboxExactLocation3GearTypeId;
                    objCompoGear.GearboxExactLocation4GearTypeId = CIRList.Gearbox.GearboxExactLocation4GearTypeId;
                    objCompoGear.GearboxExactLocation5GearTypeId = CIRList.Gearbox.GearboxExactLocation5GearTypeId;
                    objCompoGear.GearboxTypeofDamage1GearErrorId = CIRList.Gearbox.GearboxTypeofDamage1GearErrorId;
                    objCompoGear.GearboxTypeofDamage2GearErrorId = CIRList.Gearbox.GearboxTypeofDamage2GearErrorId;
                    objCompoGear.GearboxTypeofDamage3GearErrorId = CIRList.Gearbox.GearboxTypeofDamage3GearErrorId;
                    objCompoGear.GearboxTypeofDamage4GearErrorId = CIRList.Gearbox.GearboxTypeofDamage4GearErrorId;
                    objCompoGear.GearboxTypeofDamage5GearErrorId = CIRList.Gearbox.GearboxTypeofDamage5GearErrorId;
                    objCompoGear.GearboxBearingsLocation1BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation1BearingTypeId;
                    objCompoGear.GearboxBearingsLocation2BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation2BearingTypeId;
                    objCompoGear.GearboxBearingsLocation3BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation3BearingTypeId;
                    objCompoGear.GearboxBearingsLocation4BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation4BearingTypeId;
                    objCompoGear.GearboxBearingsLocation5BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation5BearingTypeId;
                    objCompoGear.GearboxBearingsPosition1BearingPosId = CIRList.Gearbox.GearboxBearingsPosition1BearingPosId;
                    objCompoGear.GearboxBearingsPosition2BearingPosId = CIRList.Gearbox.GearboxBearingsPosition2BearingPosId;
                    objCompoGear.GearboxBearingsPosition3BearingPosId = CIRList.Gearbox.GearboxBearingsPosition3BearingPosId;
                    objCompoGear.GearboxBearingsPosition4BearingPosId = CIRList.Gearbox.GearboxBearingsPosition4BearingPosId;
                    objCompoGear.GearboxBearingsPosition5BearingPosId = CIRList.Gearbox.GearboxBearingsPosition5BearingPosId;
                    objCompoGear.GearboxBearingsDamage1BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage1BearingErrorId;
                    objCompoGear.GearboxBearingsDamage2BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage2BearingErrorId;
                    objCompoGear.GearboxBearingsDamage3BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage3BearingErrorId;
                    objCompoGear.GearboxBearingsDamage4BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage4BearingErrorId;
                    objCompoGear.GearboxBearingsDamage5BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage5BearingErrorId;
                    objCompoGear.GearboxPlanetStage1HousingErrorId = CIRList.Gearbox.GearboxPlanetStage1HousingErrorId;
                    objCompoGear.GearboxPlanetStage2HousingErrorId = CIRList.Gearbox.GearboxPlanetStage2HousingErrorId;
                    objCompoGear.GearboxHelicalStageHousingErrorId = CIRList.Gearbox.GearboxHelicalStageHousingErrorId;
                    objCompoGear.GearboxFrontPlateHousingErrorId = CIRList.Gearbox.GearboxFrontPlateHousingErrorId;
                    objCompoGear.GearboxAuxStageHousingErrorId = CIRList.Gearbox.GearboxAuxStageHousingErrorId;
                    objCompoGear.GearboxHSStageHousingErrorId = CIRList.Gearbox.GearboxHSStageHousingErrorId;
                    objCompoGear.GearboxLooseBolts = CIRList.Gearbox.GearboxLooseBolts;
                    objCompoGear.GearboxBrokenBolts = CIRList.Gearbox.GearboxBrokenBolts;
                    objCompoGear.GearboxDefectDamperElements = CIRList.Gearbox.GearboxDefectDamperElements;
                    objCompoGear.GearboxTooMuchClearance = CIRList.Gearbox.GearboxTooMuchClearance;
                    objCompoGear.GearboxCrackedTorqueArm = CIRList.Gearbox.GearboxCrackedTorqueArm;
                    objCompoGear.GearboxNeedsToBeAligned = CIRList.Gearbox.GearboxNeedsToBeAligned;
                    objCompoGear.GearboxPT100Bearing1 = CIRList.Gearbox.GearboxPT100Bearing1;
                    objCompoGear.GearboxPT100Bearing2 = CIRList.Gearbox.GearboxPT100Bearing2;
                    objCompoGear.GearboxPT100Bearing3 = CIRList.Gearbox.GearboxPT100Bearing3;
                    objCompoGear.GearboxOilLevelSensor = CIRList.Gearbox.GearboxOilLevelSensor;
                    objCompoGear.GearboxOilPressure = CIRList.Gearbox.GearboxOilPressure;
                    objCompoGear.GearboxPT100OilSump = CIRList.Gearbox.GearboxPT100OilSump;
                    objCompoGear.GearboxFilterIndicator = CIRList.Gearbox.GearboxFilterIndicator;
                    objCompoGear.GearboxImmersionHeater = CIRList.Gearbox.GearboxImmersionHeater;
                    objCompoGear.GearboxDrainValve = CIRList.Gearbox.GearboxDrainValve;
                    objCompoGear.GearboxAirBreather = CIRList.Gearbox.GearboxAirBreather;
                    objCompoGear.GearboxSightGlass = CIRList.Gearbox.GearboxSightGlass;
                    objCompoGear.GearboxChipDetector = CIRList.Gearbox.GearboxChipDetector;
                    objCompoGear.GearboxVibrationsId = CIRList.Gearbox.GearboxVibrationsId;
                    objCompoGear.GearboxNoiseId = CIRList.Gearbox.GearboxNoiseId;
                    objCompoGear.GearboxDebrisOnMagnetId = CIRList.Gearbox.GearboxDebrisOnMagnetId;
                    objCompoGear.GearboxDebrisStagesMagnetPosId = CIRList.Gearbox.GearboxDebrisStagesMagnetPosId;
                    objCompoGear.GearboxDebrisGearBoxId = CIRList.Gearbox.GearboxDebrisGearBoxId;
                    objCompoGear.GearboxMaxTempResetDate = ParseDatetime(CIRList.Gearbox.GearboxMaxTempResetDate);
                    objCompoGear.GearboxTempBearing1 = CIRList.Gearbox.GearboxTempBearing1;
                    objCompoGear.GearboxTempBearing2 = CIRList.Gearbox.GearboxTempBearing2;
                    objCompoGear.GearboxTempBearing3 = CIRList.Gearbox.GearboxTempBearing3;
                    objCompoGear.GearboxTempOilSump = CIRList.Gearbox.GearboxTempOilSump;
                    objCompoGear.GearboxLSSNRend = CIRList.Gearbox.GearboxLSSNRend;
                    objCompoGear.GearboxIMSNRend = CIRList.Gearbox.GearboxIMSNRend;
                    objCompoGear.GearboxIMSRend = CIRList.Gearbox.GearboxIMSRend;
                    objCompoGear.GearboxHSSNRend = CIRList.Gearbox.GearboxHSSNRend;
                    objCompoGear.GearboxHSSRend = CIRList.Gearbox.GearboxHSSRend;
                    objCompoGear.GearboxPitchTube = CIRList.Gearbox.GearboxPitchTube;
                    objCompoGear.GearboxSplitLines = CIRList.Gearbox.GearboxSplitLines;
                    objCompoGear.GearboxHoseAndPiping = CIRList.Gearbox.GearboxHoseAndPiping;
                    objCompoGear.GearboxInputShaft = CIRList.Gearbox.GearboxInputShaft;
                    objCompoGear.GearboxHSSPTO = CIRList.Gearbox.GearboxHSSPTO;
                    objCompoGear.GearboxClaimRelevantBooleanAnswerId = CIRList.Gearbox.GearboxClaimRelevantBooleanAnswerId;
                    objCompoGear.GearboxOverallGearboxConditionId = CIRList.Gearbox.GearboxOverallGearboxConditionId;
                    objCompoGear.GearboxExactLocation6GearTypeId = CIRList.Gearbox.GearboxExactLocation6GearTypeId;
                    objCompoGear.GearboxExactLocation7GearTypeId = CIRList.Gearbox.GearboxExactLocation7GearTypeId;
                    objCompoGear.GearboxExactLocation8GearTypeId = CIRList.Gearbox.GearboxExactLocation8GearTypeId;
                    objCompoGear.GearboxExactLocation9GearTypeId = CIRList.Gearbox.GearboxExactLocation9GearTypeId;
                    objCompoGear.GearboxExactLocation10GearTypeId = CIRList.Gearbox.GearboxExactLocation10GearTypeId;
                    objCompoGear.GearboxExactLocation11GearTypeId = CIRList.Gearbox.GearboxExactLocation11GearTypeId;
                    objCompoGear.GearboxExactLocation12GearTypeId = CIRList.Gearbox.GearboxExactLocation12GearTypeId;
                    objCompoGear.GearboxExactLocation13GearTypeId = CIRList.Gearbox.GearboxExactLocation13GearTypeId;
                    objCompoGear.GearboxExactLocation14GearTypeId = CIRList.Gearbox.GearboxExactLocation14GearTypeId;
                    objCompoGear.GearboxExactLocation15GearTypeId = CIRList.Gearbox.GearboxExactLocation15GearTypeId;
                    objCompoGear.GearboxTypeofDamage6GearErrorId = CIRList.Gearbox.GearboxTypeofDamage6GearErrorId;
                    objCompoGear.GearboxTypeofDamage7GearErrorId = CIRList.Gearbox.GearboxTypeofDamage7GearErrorId;
                    objCompoGear.GearboxTypeofDamage8GearErrorId = CIRList.Gearbox.GearboxTypeofDamage8GearErrorId;
                    objCompoGear.GearboxTypeofDamage9GearErrorId = CIRList.Gearbox.GearboxTypeofDamage9GearErrorId;
                    objCompoGear.GearboxTypeofDamage10GearErrorId = CIRList.Gearbox.GearboxTypeofDamage10GearErrorId;
                    objCompoGear.GearboxTypeofDamage11GearErrorId = CIRList.Gearbox.GearboxTypeofDamage11GearErrorId;
                    objCompoGear.GearboxTypeofDamage12GearErrorId = CIRList.Gearbox.GearboxTypeofDamage12GearErrorId;
                    objCompoGear.GearboxTypeofDamage13GearErrorId = CIRList.Gearbox.GearboxTypeofDamage13GearErrorId;
                    objCompoGear.GearboxTypeofDamage14GearErrorId = CIRList.Gearbox.GearboxTypeofDamage14GearErrorId;
                    objCompoGear.GearboxTypeofDamage15GearErrorId = CIRList.Gearbox.GearboxTypeofDamage15GearErrorId;
                    objCompoGear.GearboxGearDecision1DamageDecisionId = CIRList.Gearbox.GearboxGearDecision1DamageDecisionId;
                    objCompoGear.GearboxGearDecision2DamageDecisionId = CIRList.Gearbox.GearboxGearDecision2DamageDecisionId;
                    objCompoGear.GearboxGearDecision3DamageDecisionId = CIRList.Gearbox.GearboxGearDecision3DamageDecisionId;
                    objCompoGear.GearboxGearDecision4DamageDecisionId = CIRList.Gearbox.GearboxGearDecision4DamageDecisionId;
                    objCompoGear.GearboxGearDecision5DamageDecisionId = CIRList.Gearbox.GearboxGearDecision5DamageDecisionId;
                    objCompoGear.GearboxGearDecision6DamageDecisionId = CIRList.Gearbox.GearboxGearDecision6DamageDecisionId;
                    objCompoGear.GearboxGearDecision7DamageDecisionId = CIRList.Gearbox.GearboxGearDecision7DamageDecisionId;
                    objCompoGear.GearboxGearDecision8DamageDecisionId = CIRList.Gearbox.GearboxGearDecision8DamageDecisionId;
                    objCompoGear.GearboxGearDecision9DamageDecisionId = CIRList.Gearbox.GearboxGearDecision9DamageDecisionId;
                    objCompoGear.GearboxGearDecision10DamageDecisionId = CIRList.Gearbox.GearboxGearDecision10DamageDecisionId;
                    objCompoGear.GearboxGearDecision11DamageDecisionId = CIRList.Gearbox.GearboxGearDecision11DamageDecisionId;
                    objCompoGear.GearboxGearDecision12DamageDecisionId = CIRList.Gearbox.GearboxGearDecision12DamageDecisionId;
                    objCompoGear.GearboxGearDecision13DamageDecisionId = CIRList.Gearbox.GearboxGearDecision13DamageDecisionId;
                    objCompoGear.GearboxGearDecision14DamageDecisionId = CIRList.Gearbox.GearboxGearDecision14DamageDecisionId;
                    objCompoGear.GearboxGearDecision15DamageDecisionId = CIRList.Gearbox.GearboxGearDecision15DamageDecisionId;
                    objCompoGear.GearboxBearingsLocation6BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation6BearingTypeId;
                    objCompoGear.GearboxBearingsPosition6BearingPosId = CIRList.Gearbox.GearboxBearingsPosition6BearingPosId;
                    objCompoGear.GearboxBearingsDamage6BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage6BearingErrorId;
                    objCompoGear.GearboxBearingDecision1DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision1DamageDecisionId;
                    objCompoGear.GearboxBearingDecision2DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision2DamageDecisionId;
                    objCompoGear.GearboxBearingDecision3DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision3DamageDecisionId;
                    objCompoGear.GearboxBearingDecision4DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision4DamageDecisionId;
                    objCompoGear.GearboxBearingDecision5DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision5DamageDecisionId;
                    objCompoGear.GearboxBearingDecision6DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision6DamageDecisionId;
                    objCompoGear.GearboxGearDamageClass1DamageId = CIRList.Gearbox.GearboxGearDamageClass1DamageId;
                    objCompoGear.GearboxGearDamageClass2DamageId = CIRList.Gearbox.GearboxGearDamageClass2DamageId;
                    objCompoGear.GearboxGearDamageClass3DamageId = CIRList.Gearbox.GearboxGearDamageClass3DamageId;
                    objCompoGear.GearboxGearDamageClass4DamageId = CIRList.Gearbox.GearboxGearDamageClass4DamageId;
                    objCompoGear.GearboxGearDamageClass5DamageId = CIRList.Gearbox.GearboxGearDamageClass5DamageId;
                    objCompoGear.GearboxGearDamageClass6DamageId = CIRList.Gearbox.GearboxGearDamageClass6DamageId;
                    objCompoGear.GearboxGearDamageClass7DamageId = CIRList.Gearbox.GearboxGearDamageClass7DamageId;
                    objCompoGear.GearboxGearDamageClass8DamageId = CIRList.Gearbox.GearboxGearDamageClass8DamageId;
                    objCompoGear.GearboxGearDamageClass9DamageId = CIRList.Gearbox.GearboxGearDamageClass9DamageId;
                    objCompoGear.GearboxGearDamageClass10DamageId = CIRList.Gearbox.GearboxGearDamageClass10DamageId;
                    objCompoGear.GearboxGearDamageClass11DamageId = CIRList.Gearbox.GearboxGearDamageClass11DamageId;
                    objCompoGear.GearboxGearDamageClass12DamageId = CIRList.Gearbox.GearboxGearDamageClass12DamageId;
                    objCompoGear.GearboxGearDamageClass13DamageId = CIRList.Gearbox.GearboxGearDamageClass13DamageId;
                    objCompoGear.GearboxGearDamageClass14DamageId = CIRList.Gearbox.GearboxGearDamageClass14DamageId;
                    objCompoGear.GearboxGearDamageClass15DamageId = CIRList.Gearbox.GearboxGearDamageClass15DamageId;
                    objCompoGear.GearboxAuxEquipmentId = CIRList.Gearbox.GearboxAuxEquipmentId;
                    objCompoGear.GearboxActionToBeTakenOnGearboxId = CIRList.Gearbox.GearboxActionToBeTakenOnGearboxId;
                    objCompoGear.GearboxDefectCategorizationScore = CIRList.Gearbox.GearboxDefectCategorizationScore;

                    //context.ComponentInspectionReportGearbox.Attach(objCompoGear);
                    //context.Entry(objCompoGear).State = System.Data.EntityState.Modified;
                }
            }
            else
            {
                objCompoGear = new Edmx.ComponentInspectionReportGearbox
                {
                    ComponentInspectionReportGearboxId = CIRList.Gearbox.ComponentInspectionReportGearboxId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Gearbox.VestasUniqueIdentifier,
                    GearboxTypeId = CIRList.Gearbox.GearboxTypeId,
                    GearboxRevisionId = CIRList.Gearbox.GearboxRevisionId,
                    GearboxManufacturerId = CIRList.Gearbox.GearboxManufacturerId,
                    OtherGearboxType = CIRList.Gearbox.OtherGearboxType,
                    GearboxSerialNumber = CIRList.Gearbox.GearboxSerialNumber,
                    GearboxOtherManufacturer = CIRList.Gearbox.GearboxOtherManufacturer,
                    GearboxLastOilChangeDate = ParseDatetime(CIRList.Gearbox.strGearboxLastOilChangeDate),
                    GearboxOilTypeId = CIRList.Gearbox.GearboxOilTypeId,
                    GearboxMechanicalOilPumpId = CIRList.Gearbox.GearboxMechanicalOilPumpId,
                    GearboxOilLevelId = CIRList.Gearbox.GearboxOilLevelId,
                    GearboxRunHours = CIRList.Gearbox.GearboxRunHours,
                    GearboxOilTemperature = CIRList.Gearbox.GearboxOilTemperature,
                    GearboxProduction = CIRList.Gearbox.GearboxProduction,
                    GearboxGeneratorManufacturerId = CIRList.Gearbox.GearboxGeneratorManufacturerId,
                    GearboxGeneratorManufacturerId2 = CIRList.Gearbox.GearboxGeneratorManufacturerId2,
                    GearboxElectricalPumpId = CIRList.Gearbox.GearboxElectricalPumpId,
                    GearboxShrinkElementId = CIRList.Gearbox.GearboxShrinkElementId,
                    GearboxShrinkElementSerialNumber = CIRList.Gearbox.GearboxShrinkElementSerialNumber,
                    GearboxCouplingId = CIRList.Gearbox.GearboxCouplingId,
                    GearboxFilterBlockTypeId = CIRList.Gearbox.GearboxFilterBlockTypeId,
                    GearboxInLineFilterId = CIRList.Gearbox.GearboxInLineFilterId,
                    GearboxOffLineFilterId = CIRList.Gearbox.GearboxOffLineFilterId,
                    GearboxSoftwareRelease = CIRList.Gearbox.GearboxSoftwareRelease,
                    GearboxShaftsExactLocation1ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation1ShaftTypeId,
                    GearboxShaftsExactLocation2ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation2ShaftTypeId,
                    GearboxShaftsExactLocation3ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation3ShaftTypeId,
                    GearboxShaftsExactLocation4ShaftTypeId = CIRList.Gearbox.GearboxShaftsExactLocation4ShaftTypeId,
                    GearboxShaftsTypeofDamage1ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage1ShaftErrorId,
                    GearboxShaftsTypeofDamage2ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage2ShaftErrorId,
                    GearboxShaftsTypeofDamage3ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage3ShaftErrorId,
                    GearboxShaftsTypeofDamage4ShaftErrorId = CIRList.Gearbox.GearboxShaftsTypeofDamage4ShaftErrorId,
                    GearboxExactLocation1GearTypeId = CIRList.Gearbox.GearboxExactLocation1GearTypeId,
                    GearboxExactLocation2GearTypeId = CIRList.Gearbox.GearboxExactLocation2GearTypeId,
                    GearboxExactLocation3GearTypeId = CIRList.Gearbox.GearboxExactLocation3GearTypeId,
                    GearboxExactLocation4GearTypeId = CIRList.Gearbox.GearboxExactLocation4GearTypeId,
                    GearboxExactLocation5GearTypeId = CIRList.Gearbox.GearboxExactLocation5GearTypeId,
                    GearboxTypeofDamage1GearErrorId = CIRList.Gearbox.GearboxTypeofDamage1GearErrorId,
                    GearboxTypeofDamage2GearErrorId = CIRList.Gearbox.GearboxTypeofDamage2GearErrorId,
                    GearboxTypeofDamage3GearErrorId = CIRList.Gearbox.GearboxTypeofDamage3GearErrorId,
                    GearboxTypeofDamage4GearErrorId = CIRList.Gearbox.GearboxTypeofDamage4GearErrorId,
                    GearboxTypeofDamage5GearErrorId = CIRList.Gearbox.GearboxTypeofDamage5GearErrorId,
                    GearboxBearingsLocation1BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation1BearingTypeId,
                    GearboxBearingsLocation2BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation2BearingTypeId,
                    GearboxBearingsLocation3BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation3BearingTypeId,
                    GearboxBearingsLocation4BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation4BearingTypeId,
                    GearboxBearingsLocation5BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation5BearingTypeId,
                    GearboxBearingsPosition1BearingPosId = CIRList.Gearbox.GearboxBearingsPosition1BearingPosId,
                    GearboxBearingsPosition2BearingPosId = CIRList.Gearbox.GearboxBearingsPosition2BearingPosId,
                    GearboxBearingsPosition3BearingPosId = CIRList.Gearbox.GearboxBearingsPosition3BearingPosId,
                    GearboxBearingsPosition4BearingPosId = CIRList.Gearbox.GearboxBearingsPosition4BearingPosId,
                    GearboxBearingsPosition5BearingPosId = CIRList.Gearbox.GearboxBearingsPosition5BearingPosId,
                    GearboxBearingsDamage1BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage1BearingErrorId,
                    GearboxBearingsDamage2BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage2BearingErrorId,
                    GearboxBearingsDamage3BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage3BearingErrorId,
                    GearboxBearingsDamage4BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage4BearingErrorId,
                    GearboxBearingsDamage5BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage5BearingErrorId,
                    GearboxPlanetStage1HousingErrorId = CIRList.Gearbox.GearboxPlanetStage1HousingErrorId,
                    GearboxPlanetStage2HousingErrorId = CIRList.Gearbox.GearboxPlanetStage2HousingErrorId,
                    GearboxHelicalStageHousingErrorId = CIRList.Gearbox.GearboxHelicalStageHousingErrorId,
                    GearboxFrontPlateHousingErrorId = CIRList.Gearbox.GearboxFrontPlateHousingErrorId,
                    GearboxAuxStageHousingErrorId = CIRList.Gearbox.GearboxAuxStageHousingErrorId,
                    GearboxHSStageHousingErrorId = CIRList.Gearbox.GearboxHSStageHousingErrorId,
                    GearboxLooseBolts = CIRList.Gearbox.GearboxLooseBolts,
                    GearboxBrokenBolts = CIRList.Gearbox.GearboxBrokenBolts,
                    GearboxDefectDamperElements = CIRList.Gearbox.GearboxDefectDamperElements,
                    GearboxTooMuchClearance = CIRList.Gearbox.GearboxTooMuchClearance,
                    GearboxCrackedTorqueArm = CIRList.Gearbox.GearboxCrackedTorqueArm,
                    GearboxNeedsToBeAligned = CIRList.Gearbox.GearboxNeedsToBeAligned,
                    GearboxPT100Bearing1 = CIRList.Gearbox.GearboxPT100Bearing1,
                    GearboxPT100Bearing2 = CIRList.Gearbox.GearboxPT100Bearing2,
                    GearboxPT100Bearing3 = CIRList.Gearbox.GearboxPT100Bearing3,
                    GearboxOilLevelSensor = CIRList.Gearbox.GearboxOilLevelSensor,
                    GearboxOilPressure = CIRList.Gearbox.GearboxOilPressure,
                    GearboxPT100OilSump = CIRList.Gearbox.GearboxPT100OilSump,
                    GearboxFilterIndicator = CIRList.Gearbox.GearboxFilterIndicator,
                    GearboxImmersionHeater = CIRList.Gearbox.GearboxImmersionHeater,
                    GearboxDrainValve = CIRList.Gearbox.GearboxDrainValve,
                    GearboxAirBreather = CIRList.Gearbox.GearboxAirBreather,
                    GearboxSightGlass = CIRList.Gearbox.GearboxSightGlass,
                    GearboxChipDetector = CIRList.Gearbox.GearboxChipDetector,
                    GearboxVibrationsId = CIRList.Gearbox.GearboxVibrationsId,
                    GearboxNoiseId = CIRList.Gearbox.GearboxNoiseId,
                    GearboxDebrisOnMagnetId = CIRList.Gearbox.GearboxDebrisOnMagnetId,
                    GearboxDebrisStagesMagnetPosId = CIRList.Gearbox.GearboxDebrisStagesMagnetPosId,
                    GearboxDebrisGearBoxId = CIRList.Gearbox.GearboxDebrisGearBoxId,
                    GearboxMaxTempResetDate = ParseDatetime(CIRList.Gearbox.GearboxMaxTempResetDate),
                    GearboxTempBearing1 = CIRList.Gearbox.GearboxTempBearing1,
                    GearboxTempBearing2 = CIRList.Gearbox.GearboxTempBearing2,
                    GearboxTempBearing3 = CIRList.Gearbox.GearboxTempBearing3,
                    GearboxTempOilSump = CIRList.Gearbox.GearboxTempOilSump,
                    GearboxLSSNRend = CIRList.Gearbox.GearboxLSSNRend,
                    GearboxIMSNRend = CIRList.Gearbox.GearboxIMSNRend,
                    GearboxIMSRend = CIRList.Gearbox.GearboxIMSRend,
                    GearboxHSSNRend = CIRList.Gearbox.GearboxHSSNRend,
                    GearboxHSSRend = CIRList.Gearbox.GearboxHSSRend,
                    GearboxPitchTube = CIRList.Gearbox.GearboxPitchTube,
                    GearboxSplitLines = CIRList.Gearbox.GearboxSplitLines,
                    GearboxHoseAndPiping = CIRList.Gearbox.GearboxHoseAndPiping,
                    GearboxInputShaft = CIRList.Gearbox.GearboxInputShaft,
                    GearboxHSSPTO = CIRList.Gearbox.GearboxHSSPTO,
                    GearboxClaimRelevantBooleanAnswerId = CIRList.Gearbox.GearboxClaimRelevantBooleanAnswerId,
                    GearboxOverallGearboxConditionId = CIRList.Gearbox.GearboxOverallGearboxConditionId,
                    GearboxExactLocation6GearTypeId = CIRList.Gearbox.GearboxExactLocation6GearTypeId,
                    GearboxExactLocation7GearTypeId = CIRList.Gearbox.GearboxExactLocation7GearTypeId,
                    GearboxExactLocation8GearTypeId = CIRList.Gearbox.GearboxExactLocation8GearTypeId,
                    GearboxExactLocation9GearTypeId = CIRList.Gearbox.GearboxExactLocation9GearTypeId,
                    GearboxExactLocation10GearTypeId = CIRList.Gearbox.GearboxExactLocation10GearTypeId,
                    GearboxExactLocation11GearTypeId = CIRList.Gearbox.GearboxExactLocation11GearTypeId,
                    GearboxExactLocation12GearTypeId = CIRList.Gearbox.GearboxExactLocation12GearTypeId,
                    GearboxExactLocation13GearTypeId = CIRList.Gearbox.GearboxExactLocation13GearTypeId,
                    GearboxExactLocation14GearTypeId = CIRList.Gearbox.GearboxExactLocation14GearTypeId,
                    GearboxExactLocation15GearTypeId = CIRList.Gearbox.GearboxExactLocation15GearTypeId,
                    GearboxTypeofDamage6GearErrorId = CIRList.Gearbox.GearboxTypeofDamage6GearErrorId,
                    GearboxTypeofDamage7GearErrorId = CIRList.Gearbox.GearboxTypeofDamage7GearErrorId,
                    GearboxTypeofDamage8GearErrorId = CIRList.Gearbox.GearboxTypeofDamage8GearErrorId,
                    GearboxTypeofDamage9GearErrorId = CIRList.Gearbox.GearboxTypeofDamage9GearErrorId,
                    GearboxTypeofDamage10GearErrorId = CIRList.Gearbox.GearboxTypeofDamage10GearErrorId,
                    GearboxTypeofDamage11GearErrorId = CIRList.Gearbox.GearboxTypeofDamage11GearErrorId,
                    GearboxTypeofDamage12GearErrorId = CIRList.Gearbox.GearboxTypeofDamage12GearErrorId,
                    GearboxTypeofDamage13GearErrorId = CIRList.Gearbox.GearboxTypeofDamage13GearErrorId,
                    GearboxTypeofDamage14GearErrorId = CIRList.Gearbox.GearboxTypeofDamage14GearErrorId,
                    GearboxTypeofDamage15GearErrorId = CIRList.Gearbox.GearboxTypeofDamage15GearErrorId,
                    GearboxGearDecision1DamageDecisionId = CIRList.Gearbox.GearboxGearDecision1DamageDecisionId,
                    GearboxGearDecision2DamageDecisionId = CIRList.Gearbox.GearboxGearDecision2DamageDecisionId,
                    GearboxGearDecision3DamageDecisionId = CIRList.Gearbox.GearboxGearDecision3DamageDecisionId,
                    GearboxGearDecision4DamageDecisionId = CIRList.Gearbox.GearboxGearDecision4DamageDecisionId,
                    GearboxGearDecision5DamageDecisionId = CIRList.Gearbox.GearboxGearDecision5DamageDecisionId,
                    GearboxGearDecision6DamageDecisionId = CIRList.Gearbox.GearboxGearDecision6DamageDecisionId,
                    GearboxGearDecision7DamageDecisionId = CIRList.Gearbox.GearboxGearDecision7DamageDecisionId,
                    GearboxGearDecision8DamageDecisionId = CIRList.Gearbox.GearboxGearDecision8DamageDecisionId,
                    GearboxGearDecision9DamageDecisionId = CIRList.Gearbox.GearboxGearDecision9DamageDecisionId,
                    GearboxGearDecision10DamageDecisionId = CIRList.Gearbox.GearboxGearDecision10DamageDecisionId,
                    GearboxGearDecision11DamageDecisionId = CIRList.Gearbox.GearboxGearDecision11DamageDecisionId,
                    GearboxGearDecision12DamageDecisionId = CIRList.Gearbox.GearboxGearDecision12DamageDecisionId,
                    GearboxGearDecision13DamageDecisionId = CIRList.Gearbox.GearboxGearDecision13DamageDecisionId,
                    GearboxGearDecision14DamageDecisionId = CIRList.Gearbox.GearboxGearDecision14DamageDecisionId,
                    GearboxGearDecision15DamageDecisionId = CIRList.Gearbox.GearboxGearDecision15DamageDecisionId,
                    GearboxBearingsLocation6BearingTypeId = CIRList.Gearbox.GearboxBearingsLocation6BearingTypeId,
                    GearboxBearingsPosition6BearingPosId = CIRList.Gearbox.GearboxBearingsPosition6BearingPosId,
                    GearboxBearingsDamage6BearingErrorId = CIRList.Gearbox.GearboxBearingsDamage6BearingErrorId,
                    GearboxBearingDecision1DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision1DamageDecisionId,
                    GearboxBearingDecision2DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision2DamageDecisionId,
                    GearboxBearingDecision3DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision3DamageDecisionId,
                    GearboxBearingDecision4DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision4DamageDecisionId,
                    GearboxBearingDecision5DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision5DamageDecisionId,
                    GearboxBearingDecision6DamageDecisionId = CIRList.Gearbox.GearboxBearingDecision6DamageDecisionId,
                    GearboxGearDamageClass1DamageId = CIRList.Gearbox.GearboxGearDamageClass1DamageId,
                    GearboxGearDamageClass2DamageId = CIRList.Gearbox.GearboxGearDamageClass2DamageId,
                    GearboxGearDamageClass3DamageId = CIRList.Gearbox.GearboxGearDamageClass3DamageId,
                    GearboxGearDamageClass4DamageId = CIRList.Gearbox.GearboxGearDamageClass4DamageId,
                    GearboxGearDamageClass5DamageId = CIRList.Gearbox.GearboxGearDamageClass5DamageId,
                    GearboxGearDamageClass6DamageId = CIRList.Gearbox.GearboxGearDamageClass6DamageId,
                    GearboxGearDamageClass7DamageId = CIRList.Gearbox.GearboxGearDamageClass7DamageId,
                    GearboxGearDamageClass8DamageId = CIRList.Gearbox.GearboxGearDamageClass8DamageId,
                    GearboxGearDamageClass9DamageId = CIRList.Gearbox.GearboxGearDamageClass9DamageId,
                    GearboxGearDamageClass10DamageId = CIRList.Gearbox.GearboxGearDamageClass10DamageId,
                    GearboxGearDamageClass11DamageId = CIRList.Gearbox.GearboxGearDamageClass11DamageId,
                    GearboxGearDamageClass12DamageId = CIRList.Gearbox.GearboxGearDamageClass12DamageId,
                    GearboxGearDamageClass13DamageId = CIRList.Gearbox.GearboxGearDamageClass13DamageId,
                    GearboxGearDamageClass14DamageId = CIRList.Gearbox.GearboxGearDamageClass14DamageId,
                    GearboxGearDamageClass15DamageId = CIRList.Gearbox.GearboxGearDamageClass15DamageId,
                    GearboxAuxEquipmentId = CIRList.Gearbox.GearboxAuxEquipmentId,
                    GearboxActionToBeTakenOnGearboxId = CIRList.Gearbox.GearboxActionToBeTakenOnGearboxId,
                    GearboxDefectCategorizationScore = CIRList.Gearbox.GearboxDefectCategorizationScore
                };
            }

            return objCompoGear;
        }
        /// <summary>
        /// Common Insert and update functions for Generator
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportGenerator ComponentInspectionGenerator(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportGenerator objCompoGenerator = new Edmx.ComponentInspectionReportGenerator();
            if (Isupdate == 1)
            {
                Edmx.ComponentInspectionReportGenerator objCompoGen = CIRListUp.ComponentInspectionReportGenerator.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                if (!ReferenceEquals(objCompoGen, null))
                {
                    objCompoGen.VestasUniqueIdentifier = CIRList.Generator.VestasUniqueIdentifier;
                    objCompoGen.GeneratorManufacturerId = CIRList.Generator.GeneratorManufacturerId;
                    objCompoGen.GeneratorSerialNumber = CIRList.Generator.GeneratorSerialNumber;
                    objCompoGen.OtherManufacturer = CIRList.Generator.OtherManufacturer;
                    objCompoGen.GeneratorMaxTemperature = CIRList.Generator.GeneratorMaxTemperature;
                    objCompoGen.GeneratorMaxTemperatureResetDate = ParseDatetime(CIRList.Generator.strGeneratorMaxTemperatureResetDate);
                    objCompoGen.CouplingId = CIRList.Generator.CouplingId;
                    objCompoGen.ActionToBeTakenOnGeneratorId = CIRList.Generator.ActionToBeTakenOnGeneratorId;
                    objCompoGen.GeneratorDriveEndId = CIRList.Generator.GeneratorDriveEndId;
                    objCompoGen.GeneratorNonDriveEndId = CIRList.Generator.GeneratorNonDriveEndId;
                    objCompoGen.GeneratorRotorId = CIRList.Generator.GeneratorRotorId;
                    objCompoGen.GeneratorCoverId = CIRList.Generator.GeneratorCoverId;
                    objCompoGen.AirToAirCoolerInternalId = CIRList.Generator.AirToAirCoolerInternalId;
                    objCompoGen.AirToAirCoolerExternalId = CIRList.Generator.AirToAirCoolerExternalId;
                    objCompoGen.GeneratorComments = CIRList.Generator.GeneratorComments;
                    objCompoGen.UGround = CIRList.Generator.UGround;
                    objCompoGen.VGround = CIRList.Generator.VGround;
                    objCompoGen.WGround = CIRList.Generator.WGround;
                    objCompoGen.UV = CIRList.Generator.UV;
                    objCompoGen.UW = CIRList.Generator.UW;
                    objCompoGen.VW = CIRList.Generator.VW;
                    objCompoGen.KGround = CIRList.Generator.KGround;
                    objCompoGen.LGround = CIRList.Generator.LGround;
                    objCompoGen.MGround = CIRList.Generator.MGround;
                    objCompoGen.UGroundOhmUnitId = CIRList.Generator.UGroundOhmUnitId;
                    objCompoGen.VGroundOhmUnitId = CIRList.Generator.VGroundOhmUnitId;
                    objCompoGen.WGroundOhmUnitId = CIRList.Generator.WGroundOhmUnitId;
                    objCompoGen.UVOhmUnitId = CIRList.Generator.UVOhmUnitId;
                    objCompoGen.UWOhmUnitId = CIRList.Generator.UWOhmUnitId;
                    objCompoGen.VWOhmUnitId = CIRList.Generator.VWOhmUnitId;
                    objCompoGen.KGroundOhmUnitId = CIRList.Generator.KGroundOhmUnitId;
                    objCompoGen.LGroundOhmUnitId = CIRList.Generator.LGroundOhmUnitId;
                    objCompoGen.MGroundOhmUnitId = CIRList.Generator.MGroundOhmUnitId;
                    objCompoGen.U1U2 = CIRList.Generator.U1U2;
                    objCompoGen.V1V2 = CIRList.Generator.V1V2;
                    objCompoGen.W1W2 = CIRList.Generator.W1W2;
                    objCompoGen.K1L1 = CIRList.Generator.K1L1;
                    objCompoGen.L1M1 = CIRList.Generator.L1M1;
                    objCompoGen.K1M1 = CIRList.Generator.K1M1;
                    objCompoGen.K2L2 = CIRList.Generator.K2L2;
                    objCompoGen.L2M2 = CIRList.Generator.L2M2;
                    objCompoGen.K2M2 = CIRList.Generator.K2M2;
                    objCompoGen.GeneratorRewoundLocally = CIRList.Generator.GeneratorRewoundLocally;
                    objCompoGen.GeneratorClaimRelevantBooleanAnswerId = CIRList.Generator.GeneratorClaimRelevantBooleanAnswerId;
                    objCompoGen.InsulationComments = CIRList.Generator.InsulationComments;
                    objCompoGen.GeneratorInsulationComments = CIRList.Generator.GeneratorInsulationComments;
                    //context.ComponentInspectionReportGenerator.Attach(objCompoGen);
                    //context.Entry(objCompoGen).State = System.Data.EntityState.Modified;
                }
            }
            else
            {
                objCompoGenerator = new Edmx.ComponentInspectionReportGenerator
                {
                    ComponentInspectionReportGeneratorId = CIRList.Generator.ComponentInspectionReportGeneratorId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Generator.VestasUniqueIdentifier,
                    GeneratorManufacturerId = CIRList.Generator.GeneratorManufacturerId,
                    GeneratorSerialNumber = CIRList.Generator.GeneratorSerialNumber,
                    OtherManufacturer = CIRList.Generator.OtherManufacturer,
                    GeneratorMaxTemperature = CIRList.Generator.GeneratorMaxTemperature,
                    GeneratorMaxTemperatureResetDate = ParseDatetime(CIRList.Generator.strGeneratorMaxTemperatureResetDate),
                    CouplingId = CIRList.Generator.CouplingId,
                    ActionToBeTakenOnGeneratorId = CIRList.Generator.ActionToBeTakenOnGeneratorId,
                    GeneratorDriveEndId = CIRList.Generator.GeneratorDriveEndId,
                    GeneratorNonDriveEndId = CIRList.Generator.GeneratorNonDriveEndId,
                    GeneratorRotorId = CIRList.Generator.GeneratorRotorId,
                    GeneratorCoverId = CIRList.Generator.GeneratorCoverId,
                    AirToAirCoolerInternalId = CIRList.Generator.AirToAirCoolerInternalId,
                    AirToAirCoolerExternalId = CIRList.Generator.AirToAirCoolerExternalId,
                    GeneratorComments = CIRList.Generator.GeneratorComments,
                    UGround = CIRList.Generator.UGround,
                    VGround = CIRList.Generator.VGround,
                    WGround = CIRList.Generator.WGround,
                    UV = CIRList.Generator.UV,
                    UW = CIRList.Generator.UW,
                    VW = CIRList.Generator.VW,
                    KGround = CIRList.Generator.KGround,
                    LGround = CIRList.Generator.LGround,
                    MGround = CIRList.Generator.MGround,
                    UGroundOhmUnitId = CIRList.Generator.UGroundOhmUnitId,
                    VGroundOhmUnitId = CIRList.Generator.VGroundOhmUnitId,
                    WGroundOhmUnitId = CIRList.Generator.WGroundOhmUnitId,
                    UVOhmUnitId = CIRList.Generator.UVOhmUnitId,
                    UWOhmUnitId = CIRList.Generator.UWOhmUnitId,
                    VWOhmUnitId = CIRList.Generator.VWOhmUnitId,
                    KGroundOhmUnitId = CIRList.Generator.KGroundOhmUnitId,
                    LGroundOhmUnitId = CIRList.Generator.LGroundOhmUnitId,
                    MGroundOhmUnitId = CIRList.Generator.MGroundOhmUnitId,
                    U1U2 = CIRList.Generator.U1U2,
                    V1V2 = CIRList.Generator.V1V2,
                    W1W2 = CIRList.Generator.W1W2,
                    K1L1 = CIRList.Generator.K1L1,
                    L1M1 = CIRList.Generator.L1M1,
                    K1M1 = CIRList.Generator.K1M1,
                    K2L2 = CIRList.Generator.K2L2,
                    L2M2 = CIRList.Generator.L2M2,
                    K2M2 = CIRList.Generator.K2M2,
                    GeneratorRewoundLocally = CIRList.Generator.GeneratorRewoundLocally,
                    GeneratorClaimRelevantBooleanAnswerId = CIRList.Generator.GeneratorClaimRelevantBooleanAnswerId,
                    InsulationComments = CIRList.Generator.InsulationComments,
                    GeneratorInsulationComments = CIRList.Generator.GeneratorInsulationComments,
                };
            }

            return objCompoGenerator;
        }
        /// <summary>
        /// Common Insert and update functions for Transformer
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportTransformer ComponentInspectionTransformer(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportTransformer objCompoTransformer = new Edmx.ComponentInspectionReportTransformer();
            if (Isupdate == 1)
            {
                Edmx.ComponentInspectionReportTransformer objCompoTrans = CIRListUp.ComponentInspectionReportTransformer.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objCompoTrans, null))
                {
                    objCompoTrans.VestasUniqueIdentifier = CIRList.Transformer.VestasUniqueIdentifier;
                    objCompoTrans.TransformerManufacturerId = CIRList.Transformer.TransformerManufacturerId;
                    objCompoTrans.TransformerSerialNumber = CIRList.Transformer.TransformerSerialNumber;
                    objCompoTrans.MaxTemp = CIRList.Transformer.MaxTemp;
                    objCompoTrans.MaxTempResetDate = ParseDatetime(CIRList.Transformer.MaxTempResetDate);
                    objCompoTrans.ActionOnTransformerId = CIRList.Transformer.ActionOnTransformerId;
                    objCompoTrans.HVCoilConditionId = CIRList.Transformer.HVCoilConditionId;
                    objCompoTrans.LVCoilConditionId = CIRList.Transformer.LVCoilConditionId;
                    objCompoTrans.HVCableConditionId = CIRList.Transformer.HVCableConditionId;
                    objCompoTrans.LVCableConditionId = CIRList.Transformer.LVCableConditionId;
                    objCompoTrans.BracketsId = CIRList.Transformer.BracketsId;
                    objCompoTrans.TransformerArcDetectionId = CIRList.Transformer.TransformerArcDetectionId;
                    objCompoTrans.ClimateId = CIRList.Transformer.ClimateId;
                    objCompoTrans.SurgeArrestorId = CIRList.Transformer.SurgeArrestorId;
                    objCompoTrans.ConnectionBarsId = CIRList.Transformer.ConnectionBarsId;
                    objCompoTrans.Comments = CIRList.Transformer.Comments;
                    objCompoTrans.TransformerClaimRelevantBooleanAnswerId = CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId;
                    //context.ComponentInspectionReportTransformer.Attach(objCompoTrans);
                    //context.Entry(objCompoTrans).State = System.Data.EntityState.Modified;
                    //context.SaveChanges();
                }
            }
            else
            {
                objCompoTransformer = new Edmx.ComponentInspectionReportTransformer
                {
                    ComponentInspectionReportTransformerId = CIRList.Transformer.ComponentInspectionReportTransformerId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.Transformer.VestasUniqueIdentifier,
                    TransformerManufacturerId = CIRList.Transformer.TransformerManufacturerId,
                    TransformerSerialNumber = CIRList.Transformer.TransformerSerialNumber,
                    MaxTemp = CIRList.Transformer.MaxTemp,
                    MaxTempResetDate = ParseDatetime(CIRList.Transformer.strMaxTempResetDate),
                    ActionOnTransformerId = CIRList.Transformer.ActionOnTransformerId,
                    HVCoilConditionId = CIRList.Transformer.HVCoilConditionId,
                    LVCoilConditionId = CIRList.Transformer.LVCoilConditionId,
                    HVCableConditionId = CIRList.Transformer.HVCableConditionId,
                    LVCableConditionId = CIRList.Transformer.LVCableConditionId,
                    BracketsId = CIRList.Transformer.BracketsId,
                    TransformerArcDetectionId = CIRList.Transformer.TransformerArcDetectionId,
                    ClimateId = CIRList.Transformer.ClimateId,
                    SurgeArrestorId = CIRList.Transformer.SurgeArrestorId,
                    ConnectionBarsId = CIRList.Transformer.ConnectionBarsId,
                    Comments = CIRList.Transformer.Comments,
                    TransformerClaimRelevantBooleanAnswerId = CIRList.Transformer.TransformerClaimRelevantBooleanAnswerId,
                };
            }
            return objCompoTransformer;
        }
        /// <summary>
        /// Common Insert and update functions for ComponentInspectionMainBearing
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportMainBearing ComponentInspectionMainBearing(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportMainBearing objCompoMainBearing = new Edmx.ComponentInspectionReportMainBearing();
            if (Isupdate == 1)
            {
                Edmx.ComponentInspectionReportMainBearing objCompoMain = CIRListUp.ComponentInspectionReportMainBearing.Where(x => x.ComponentInspectionReportId == CIRListUp.ComponentInspectionReportId).FirstOrDefault();
                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objCompoMain, null))
                {
                    long? MainBearingManufacturerId = null;
                    if (CIRList.MainBearing.MainBearingManufacturerId == 0)
                        MainBearingManufacturerId = null;
                    else
                        MainBearingManufacturerId = CIRList.MainBearing.MainBearingManufacturerId;

                    objCompoMain.VestasUniqueIdentifier = CIRList.MainBearing.VestasUniqueIdentifier;
                    objCompoMain.MainBearingLastLubricationDate = ParseDatetime(CIRList.MainBearing.strMainBearingLastLubricationDate);
                    objCompoMain.MainBearingManufacturerId = MainBearingManufacturerId;
                    objCompoMain.MainBearingTemperature = CIRList.MainBearing.MainBearingTemperature;
                    objCompoMain.MainBearingLubricationOilTypeId = CIRList.MainBearing.MainBearingLubricationOilTypeId;
                    objCompoMain.MainBearingGrease = CIRList.MainBearing.MainBearingGrease;
                    objCompoMain.MainBearingLubricationRunHours = CIRList.MainBearing.MainBearingLubricationRunHours;
                    objCompoMain.MainBearingOilTemperature = CIRList.MainBearing.MainBearingOilTemperature;
                    objCompoMain.MainBearingTypeId = CIRList.MainBearing.MainBearingTypeId;
                    objCompoMain.MainBearingRevision = CIRList.MainBearing.MainBearingRevision;
                    objCompoMain.MainBearingErrorLocationId = (CIRList.MainBearing.MainBearingErrorLocationId == 0 || CIRList.MainBearing.MainBearingErrorLocationId == null) ? 3 : CIRList.MainBearing.MainBearingErrorLocationId;
                    objCompoMain.MainBearingSerialNumber = CIRList.MainBearing.MainBearingSerialNumber;
                    objCompoMain.MainBearingRunHours = CIRList.MainBearing.MainBearingRunHours;
                    objCompoMain.MainBearingMechanicalOilPump = CIRList.MainBearing.MainBearingMechanicalOilPump;
                    objCompoMain.MainBearingClaimRelevantBooleanAnswerId = CIRList.MainBearing.MainBearingClaimRelevantBooleanAnswerId;
                    //context.ComponentInspectionReportMainBearing.Attach(objCompoMain);
                    //context.Entry(objCompoMain).State = System.Data.EntityState.Modified;
                    //context.SaveChanges();
                }
            }
            else
            {
                long? MainBearingManufacturerId = null;
                if (CIRList.MainBearing.MainBearingManufacturerId == 0)
                    MainBearingManufacturerId = null;
                else
                    MainBearingManufacturerId = CIRList.MainBearing.MainBearingManufacturerId;
                objCompoMainBearing = new Edmx.ComponentInspectionReportMainBearing
                {
                    ComponentInspectionReportMainBearingId = CIRList.MainBearing.ComponentInspectionReportMainBearingId,
                    ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
                    VestasUniqueIdentifier = CIRList.MainBearing.VestasUniqueIdentifier,
                    MainBearingLastLubricationDate = ParseDatetime(CIRList.MainBearing.strMainBearingLastLubricationDate),
                    MainBearingManufacturerId = MainBearingManufacturerId,
                    MainBearingTemperature = CIRList.MainBearing.MainBearingTemperature,
                    MainBearingLubricationOilTypeId = CIRList.MainBearing.MainBearingLubricationOilTypeId,
                    MainBearingGrease = CIRList.MainBearing.MainBearingGrease,
                    MainBearingLubricationRunHours = CIRList.MainBearing.MainBearingLubricationRunHours,
                    MainBearingOilTemperature = CIRList.MainBearing.MainBearingOilTemperature,
                    MainBearingTypeId = CIRList.MainBearing.MainBearingTypeId,
                    MainBearingRevision = CIRList.MainBearing.MainBearingRevision,
                    MainBearingErrorLocationId = (CIRList.MainBearing.MainBearingErrorLocationId == 0 || CIRList.MainBearing.MainBearingErrorLocationId == null) ? 3 : CIRList.MainBearing.MainBearingErrorLocationId,
                    MainBearingSerialNumber = CIRList.MainBearing.MainBearingSerialNumber,
                    MainBearingRunHours = CIRList.MainBearing.MainBearingRunHours,
                    MainBearingMechanicalOilPump = CIRList.MainBearing.MainBearingMechanicalOilPump,
                    MainBearingClaimRelevantBooleanAnswerId = CIRList.MainBearing.MainBearingClaimRelevantBooleanAnswerId,
                };
            }
            return objCompoMainBearing;
        }
        /// <summary>
        /// Common Insert and update functions for DynamicTableInput
        /// </summary>
        /// <param name="CIRList"></param>
        /// <returns></returns>
        public static Edmx.DynamicTableInput DynamicTableInput(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, int Isupdate, Edmx.ComponentInspectionReport CIRListUp, CIM_CIREntities context)
        {
            Edmx.DynamicTableInput objDynamicTableInput = new Edmx.DynamicTableInput();
            if (Isupdate == 1)
            {
                string cirID = CIRList.ComponentInspectionReportId.ToString();
                objDynamicTableInput = context.DynamicTableInput.Where(x => x.CirId == cirID).FirstOrDefault();

                /* Assign value to CIR Report Transformer Entity */
                if (!ReferenceEquals(objDynamicTableInput, null))
                {
                    if (CIRList.ComponentInspectionReportTypeId != 8)
                    {
                        objDynamicTableInput.Row1Col1 = CIRList.DynamicTableInputs.Row1Col1;
                        objDynamicTableInput.Row1Col2 = CIRList.DynamicTableInputs.Row1Col2;
                        objDynamicTableInput.Row1Col3 = CIRList.DynamicTableInputs.Row1Col3;
                        objDynamicTableInput.Row1Col4 = CIRList.DynamicTableInputs.Row1Col4;
                        objDynamicTableInput.Row2Col1 = CIRList.DynamicTableInputs.Row2Col1;
                        objDynamicTableInput.Row2Col2 = CIRList.DynamicTableInputs.Row2Col2;
                        objDynamicTableInput.Row2Col3 = CIRList.DynamicTableInputs.Row2Col3;
                        objDynamicTableInput.Row2Col4 = CIRList.DynamicTableInputs.Row2Col4;
                        objDynamicTableInput.Row3Col1 = CIRList.DynamicTableInputs.Row3Col1;
                        objDynamicTableInput.Row3Col2 = CIRList.DynamicTableInputs.Row3Col2;
                        objDynamicTableInput.Row3Col3 = CIRList.DynamicTableInputs.Row3Col3;
                        objDynamicTableInput.Row3Col4 = CIRList.DynamicTableInputs.Row3Col4;
                        objDynamicTableInput.Row4Col1 = CIRList.DynamicTableInputs.Row4Col1;
                        objDynamicTableInput.Row4Col2 = CIRList.DynamicTableInputs.Row4Col2;
                        objDynamicTableInput.Row4Col3 = CIRList.DynamicTableInputs.Row4Col3;
                        objDynamicTableInput.Row4Col4 = CIRList.DynamicTableInputs.Row4Col4;
                        objDynamicTableInput.Row5Col1 = CIRList.DynamicTableInputs.Row5Col1;
                        objDynamicTableInput.Row5Col2 = CIRList.DynamicTableInputs.Row5Col2;
                        objDynamicTableInput.Row5Col3 = CIRList.DynamicTableInputs.Row5Col3;
                        objDynamicTableInput.Row5Col4 = CIRList.DynamicTableInputs.Row5Col4;
                        objDynamicTableInput.Row6Col1 = CIRList.DynamicTableInputs.Row6Col1;
                        objDynamicTableInput.Row6Col2 = CIRList.DynamicTableInputs.Row6Col2;
                        objDynamicTableInput.Row6Col3 = CIRList.DynamicTableInputs.Row6Col3;
                        objDynamicTableInput.Row6Col4 = CIRList.DynamicTableInputs.Row6Col4;
                        objDynamicTableInput.Row7Col1 = CIRList.DynamicTableInputs.Row7Col1;
                        objDynamicTableInput.Row7Col2 = CIRList.DynamicTableInputs.Row7Col2;
                        objDynamicTableInput.Row7Col3 = CIRList.DynamicTableInputs.Row7Col3;
                        objDynamicTableInput.Row7Col4 = CIRList.DynamicTableInputs.Row7Col4;
                        objDynamicTableInput.Row8Col1 = CIRList.DynamicTableInputs.Row8Col1;
                        objDynamicTableInput.Row8Col2 = CIRList.DynamicTableInputs.Row8Col2;
                        objDynamicTableInput.Row8Col3 = CIRList.DynamicTableInputs.Row8Col3;
                        objDynamicTableInput.Row8Col4 = CIRList.DynamicTableInputs.Row8Col4;
                        objDynamicTableInput.Row9Col1 = CIRList.DynamicTableInputs.Row9Col1;
                        objDynamicTableInput.Row9Col2 = CIRList.DynamicTableInputs.Row9Col2;
                        objDynamicTableInput.Row9Col3 = CIRList.DynamicTableInputs.Row9Col3;
                        objDynamicTableInput.Row9Col4 = CIRList.DynamicTableInputs.Row9Col4;
                        objDynamicTableInput.Row10Col1 = CIRList.DynamicTableInputs.Row10Col1;
                        objDynamicTableInput.Row10Col2 = CIRList.DynamicTableInputs.Row10Col2;
                        objDynamicTableInput.Row10Col3 = CIRList.DynamicTableInputs.Row10Col3;
                        objDynamicTableInput.Row10Col4 = CIRList.DynamicTableInputs.Row10Col4;
                        objDynamicTableInput.Row1Col5 = CIRList.DynamicTableInputs.Row1Col5;
                        objDynamicTableInput.Row1Col6 = CIRList.DynamicTableInputs.Row1Col6;
                        objDynamicTableInput.Row2Col5 = CIRList.DynamicTableInputs.Row2Col5;
                        objDynamicTableInput.Row2Col6 = CIRList.DynamicTableInputs.Row2Col6;
                        objDynamicTableInput.Row3Col5 = CIRList.DynamicTableInputs.Row3Col5;
                        objDynamicTableInput.Row3Col6 = CIRList.DynamicTableInputs.Row3Col6;
                        objDynamicTableInput.Row4Col5 = CIRList.DynamicTableInputs.Row4Col5;
                        objDynamicTableInput.Row4Col6 = CIRList.DynamicTableInputs.Row4Col6;
                        objDynamicTableInput.Row5Col5 = CIRList.DynamicTableInputs.Row5Col5;
                        objDynamicTableInput.Row5Col6 = CIRList.DynamicTableInputs.Row5Col6;
                        objDynamicTableInput.Row6Col5 = CIRList.DynamicTableInputs.Row6Col5;
                        objDynamicTableInput.Row6Col6 = CIRList.DynamicTableInputs.Row6Col6;
                        objDynamicTableInput.Row7Col5 = CIRList.DynamicTableInputs.Row7Col5;
                        objDynamicTableInput.Row7Col6 = CIRList.DynamicTableInputs.Row7Col6;
                        objDynamicTableInput.Row8Col5 = CIRList.DynamicTableInputs.Row8Col5;
                        objDynamicTableInput.Row8Col6 = CIRList.DynamicTableInputs.Row8Col6;
                        objDynamicTableInput.Row9Col5 = CIRList.DynamicTableInputs.Row9Col5;
                        objDynamicTableInput.Row9Col6 = CIRList.DynamicTableInputs.Row9Col6;
                        objDynamicTableInput.Row10Col5 = CIRList.DynamicTableInputs.Row10Col5;
                        objDynamicTableInput.Row10Col6 = CIRList.DynamicTableInputs.Row10Col6;
                    }
                    else
                    {
                        //code for dynamin flange
                        objDynamicTableInput.Row1Col1 = CIRList.DynamicTableInputs.Row1Col1;
                        objDynamicTableInput.Row2Col1 = CIRList.DynamicTableInputs.Row2Col1;
                        objDynamicTableInput.Row3Col1 = CIRList.DynamicTableInputs.Row3Col1;
                        objDynamicTableInput.Row4Col1 = CIRList.DynamicTableInputs.Row4Col1;
                        objDynamicTableInput.Row5Col1 = CIRList.DynamicTableInputs.Row5Col1;
                        objDynamicTableInput.Row6Col1 = CIRList.DynamicTableInputs.Row6Col1;
                        objDynamicTableInput.Row7Col1 = CIRList.DynamicTableInputs.Row7Col1;
                        objDynamicTableInput.Row8Col1 = CIRList.DynamicTableInputs.Row8Col1;
                        objDynamicTableInput.Row9Col1 = CIRList.DynamicTableInputs.Row9Col1;
                        objDynamicTableInput.Row10Col1 = CIRList.DynamicTableInputs.Row10Col1;
                        objDynamicTableInput.Row11Col1 = CIRList.DynamicTableInputs.Row11Col1;
                        objDynamicTableInput.Row12Col1 = CIRList.DynamicTableInputs.Row12Col1;
                        objDynamicTableInput.Row13Col1 = CIRList.DynamicTableInputs.Row13Col1;
                        objDynamicTableInput.Row14Col1 = CIRList.DynamicTableInputs.Row14Col1;

                        objDynamicTableInput.Row1Col2 = CIRList.DynamicTableInputs.Row1Col2;
                        objDynamicTableInput.Row2Col2 = CIRList.DynamicTableInputs.Row2Col2;
                        objDynamicTableInput.Row3Col2 = CIRList.DynamicTableInputs.Row3Col2;
                        objDynamicTableInput.Row4Col2 = CIRList.DynamicTableInputs.Row4Col2;
                        objDynamicTableInput.Row5Col2 = CIRList.DynamicTableInputs.Row5Col2;
                        objDynamicTableInput.Row6Col2 = CIRList.DynamicTableInputs.Row6Col2;
                        objDynamicTableInput.Row7Col2 = CIRList.DynamicTableInputs.Row7Col2;
                        objDynamicTableInput.Row8Col2 = CIRList.DynamicTableInputs.Row8Col2;
                        objDynamicTableInput.Row9Col2 = CIRList.DynamicTableInputs.Row9Col2;
                        objDynamicTableInput.Row10Col2 = CIRList.DynamicTableInputs.Row10Col2;
                        objDynamicTableInput.Row11Col2 = CIRList.DynamicTableInputs.Row11Col2;
                        objDynamicTableInput.Row12Col2 = CIRList.DynamicTableInputs.Row12Col2;
                        objDynamicTableInput.Row13Col2 = CIRList.DynamicTableInputs.Row13Col2;
                        objDynamicTableInput.Row14Col2 = CIRList.DynamicTableInputs.Row14Col2;

                        objDynamicTableInput.Row1Col3 = CIRList.DynamicTableInputs.Row1Col3;
                        objDynamicTableInput.Row2Col3 = CIRList.DynamicTableInputs.Row2Col3;
                        objDynamicTableInput.Row3Col3 = CIRList.DynamicTableInputs.Row3Col3;
                        objDynamicTableInput.Row4Col3 = CIRList.DynamicTableInputs.Row4Col3;
                        objDynamicTableInput.Row5Col3 = CIRList.DynamicTableInputs.Row5Col3;
                        objDynamicTableInput.Row6Col3 = CIRList.DynamicTableInputs.Row6Col3;
                        objDynamicTableInput.Row7Col3 = CIRList.DynamicTableInputs.Row7Col3;
                        objDynamicTableInput.Row8Col3 = CIRList.DynamicTableInputs.Row8Col3;
                        objDynamicTableInput.Row9Col3 = CIRList.DynamicTableInputs.Row9Col3;
                        objDynamicTableInput.Row10Col3 = CIRList.DynamicTableInputs.Row10Col3;
                        objDynamicTableInput.Row11Col3 = CIRList.DynamicTableInputs.Row11Col3;
                        objDynamicTableInput.Row12Col3 = CIRList.DynamicTableInputs.Row12Col3;
                        objDynamicTableInput.Row13Col3 = CIRList.DynamicTableInputs.Row13Col3;
                        objDynamicTableInput.Row14Col3 = CIRList.DynamicTableInputs.Row14Col3;

                        objDynamicTableInput.Row1Col4 = CIRList.DynamicTableInputs.Row1Col4;
                        objDynamicTableInput.Row2Col4 = CIRList.DynamicTableInputs.Row2Col4;
                        objDynamicTableInput.Row3Col4 = CIRList.DynamicTableInputs.Row3Col4;
                        objDynamicTableInput.Row4Col4 = CIRList.DynamicTableInputs.Row4Col4;
                        objDynamicTableInput.Row5Col4 = CIRList.DynamicTableInputs.Row5Col4;
                        objDynamicTableInput.Row6Col4 = CIRList.DynamicTableInputs.Row6Col4;
                        objDynamicTableInput.Row7Col4 = CIRList.DynamicTableInputs.Row7Col4;
                        objDynamicTableInput.Row8Col4 = CIRList.DynamicTableInputs.Row8Col4;
                        objDynamicTableInput.Row9Col4 = CIRList.DynamicTableInputs.Row9Col4;
                        objDynamicTableInput.Row10Col4 = CIRList.DynamicTableInputs.Row10Col4;
                        objDynamicTableInput.Row11Col4 = CIRList.DynamicTableInputs.Row11Col4;
                        objDynamicTableInput.Row12Col4 = CIRList.DynamicTableInputs.Row12Col4;
                        objDynamicTableInput.Row13Col4 = CIRList.DynamicTableInputs.Row13Col4;
                        objDynamicTableInput.Row14Col4 = CIRList.DynamicTableInputs.Row14Col4;

                        objDynamicTableInput.Row1Col5 = CIRList.DynamicTableInputs.Row1Col5;
                        objDynamicTableInput.Row2Col5 = CIRList.DynamicTableInputs.Row2Col5;
                        objDynamicTableInput.Row3Col5 = CIRList.DynamicTableInputs.Row3Col5;
                        objDynamicTableInput.Row4Col5 = CIRList.DynamicTableInputs.Row4Col5;
                        objDynamicTableInput.Row5Col5 = CIRList.DynamicTableInputs.Row5Col5;
                        objDynamicTableInput.Row6Col5 = CIRList.DynamicTableInputs.Row6Col5;
                        objDynamicTableInput.Row7Col5 = CIRList.DynamicTableInputs.Row7Col5;
                        objDynamicTableInput.Row8Col5 = CIRList.DynamicTableInputs.Row8Col5;
                        objDynamicTableInput.Row9Col5 = CIRList.DynamicTableInputs.Row9Col5;
                        objDynamicTableInput.Row10Col5 = CIRList.DynamicTableInputs.Row10Col5;
                        objDynamicTableInput.Row11Col5 = CIRList.DynamicTableInputs.Row11Col5;
                        objDynamicTableInput.Row12Col5 = CIRList.DynamicTableInputs.Row12Col5;
                        objDynamicTableInput.Row13Col5 = CIRList.DynamicTableInputs.Row13Col5;
                        objDynamicTableInput.Row14Col5 = CIRList.DynamicTableInputs.Row14Col5;

                        objDynamicTableInput.Row1Col6 = CIRList.DynamicTableInputs.Row1Col6;
                        objDynamicTableInput.Row2Col6 = CIRList.DynamicTableInputs.Row2Col6;
                        objDynamicTableInput.Row3Col6 = CIRList.DynamicTableInputs.Row3Col6;
                        objDynamicTableInput.Row4Col6 = CIRList.DynamicTableInputs.Row4Col6;
                        objDynamicTableInput.Row5Col6 = CIRList.DynamicTableInputs.Row5Col6;
                        objDynamicTableInput.Row6Col6 = CIRList.DynamicTableInputs.Row6Col6;
                        objDynamicTableInput.Row7Col6 = CIRList.DynamicTableInputs.Row7Col6;
                        objDynamicTableInput.Row8Col6 = CIRList.DynamicTableInputs.Row8Col6;
                        objDynamicTableInput.Row9Col6 = CIRList.DynamicTableInputs.Row9Col6;
                        objDynamicTableInput.Row10Col6 = CIRList.DynamicTableInputs.Row10Col6;
                        objDynamicTableInput.Row11Col6 = CIRList.DynamicTableInputs.Row11Col6;
                        objDynamicTableInput.Row12Col6 = CIRList.DynamicTableInputs.Row12Col6;
                        objDynamicTableInput.Row13Col6 = CIRList.DynamicTableInputs.Row13Col6;
                        objDynamicTableInput.Row14Col6 = CIRList.DynamicTableInputs.Row14Col6;

                        if (CIRList.DyanamicDecisionData != null)
                        {
                            foreach (DyanamicDecision obj in CIRList.DyanamicDecisionData)
                            {
                                Edmx.DynamicDecisionDetails objDynamicDecision = context.DynamicDecisionDetails.FirstOrDefault(x => x.CirId == CIRList.ComponentInspectionReportId && x.FlangNo == obj.FlangNo);
                                if (objDynamicDecision != null)
                                {
                                    objDynamicDecision.Decision = obj.Decision;
                                    objDynamicDecision.AffectedBolts = obj.AffectedBolts;
                                    objDynamicDecision.ImidiateActions = obj.ImidiateActions;
                                    objDynamicDecision.RepeatedInspections = obj.RepeatedInspections;
                                    objDynamicDecision.UpdatedDate = System.DateTime.UtcNow.Date;
                                    objDynamicDecision.CreatedDate = System.DateTime.UtcNow.Date;
                                    objDynamicDecision.FlangeDamageIdentified = obj.FlangeDamageIdentified;
                                    objDynamicDecision.InspectionDesc = obj.InspectionDesc;
                                    //context.SaveChanges();
                                }
                            }
                        }
                    }//end of else 
                    //context.SaveChanges();
                }
                else
                {
                    if (CIRList.ComponentInspectionReportTypeId != 8)
                    {
                        objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.DynamicTableInputs.CirId,
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                        };
                        //context.DynamicTableInput.Add(objDynamicTableInput);
                    }
                    else
                    {
                        objDynamicTableInput = new Edmx.DynamicTableInput()
                        {
                            Id = CIRList.DynamicTableInputs.Id,
                            CirId = CIRList.DynamicTableInputs.CirId,
                            Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                            Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                            Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                            Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                            Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                            Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                            Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                            Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                            Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                            Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                            Row11Col1 = CIRList.DynamicTableInputs.Row11Col1,
                            Row12Col1 = CIRList.DynamicTableInputs.Row12Col1,
                            Row13Col1 = CIRList.DynamicTableInputs.Row13Col1,
                            Row14Col1 = CIRList.DynamicTableInputs.Row14Col1,

                            Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                            Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                            Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                            Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                            Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                            Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                            Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                            Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                            Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                            Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                            Row11Col2 = CIRList.DynamicTableInputs.Row11Col2,
                            Row12Col2 = CIRList.DynamicTableInputs.Row12Col2,
                            Row13Col2 = CIRList.DynamicTableInputs.Row13Col2,
                            Row14Col2 = CIRList.DynamicTableInputs.Row14Col2,

                            Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                            Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                            Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                            Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                            Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                            Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                            Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                            Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                            Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                            Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                            Row11Col3 = CIRList.DynamicTableInputs.Row11Col3,
                            Row12Col3 = CIRList.DynamicTableInputs.Row12Col3,
                            Row13Col3 = CIRList.DynamicTableInputs.Row13Col3,
                            Row14Col3 = CIRList.DynamicTableInputs.Row14Col3,

                            Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                            Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                            Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                            Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                            Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                            Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                            Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                            Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                            Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                            Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                            Row11Col4 = CIRList.DynamicTableInputs.Row11Col4,
                            Row12Col4 = CIRList.DynamicTableInputs.Row12Col4,
                            Row13Col4 = CIRList.DynamicTableInputs.Row13Col4,
                            Row14Col4 = CIRList.DynamicTableInputs.Row14Col4,

                            Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                            Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                            Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                            Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                            Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                            Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                            Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                            Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                            Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                            Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                            Row11Col5 = CIRList.DynamicTableInputs.Row11Col5,
                            Row12Col5 = CIRList.DynamicTableInputs.Row12Col5,
                            Row13Col5 = CIRList.DynamicTableInputs.Row13Col5,
                            Row14Col5 = CIRList.DynamicTableInputs.Row14Col5,

                            Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                            Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                            Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                            Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                            Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                            Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                            Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                            Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                            Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                            Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                            Row11Col6 = CIRList.DynamicTableInputs.Row11Col6,
                            Row12Col6 = CIRList.DynamicTableInputs.Row12Col6,
                            Row13Col6 = CIRList.DynamicTableInputs.Row13Col6,
                            Row14Col6 = CIRList.DynamicTableInputs.Row14Col6
                        };
                        //context.DynamicTableInput.Add(objDynamicTableInput);
                        //Add dyanamicdecision data
                        if (CIRList.DyanamicDecisionData != null)
                        {
                            foreach (DyanamicDecision obj in CIRList.DyanamicDecisionData)
                            {
                                // context.DynamicDecisionDetails.Add(new Edmx.DynamicDecisionDetails { AffectedBolts = obj.AffectedBolts, CirId = CIRList.ComponentInspectionReportId, Decision = obj.Decision, FlangNo = obj.FlangNo, ImidiateActions = obj.ImidiateActions, IsDeleted = false, RepeatedInspections = obj.RepeatedInspections, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow });
                                Edmx.DynamicDecisionDetails objDyanamicDecisionData = new Edmx.DynamicDecisionDetails()
                                {
                                    AffectedBolts = obj.AffectedBolts,
                                    CirId = CIRList.ComponentInspectionReportId,
                                    Decision = obj.Decision,
                                    FlangNo = obj.FlangNo,
                                    ImidiateActions = obj.ImidiateActions,
                                    IsDeleted = false,
                                    RepeatedInspections = obj.RepeatedInspections,
                                    InspectionDesc = obj.InspectionDesc,
                                    UpdatedDate = System.DateTime.UtcNow.Date,
                                    CreatedDate = System.DateTime.UtcNow.Date,
                                    FlangeDamageIdentified = obj.FlangeDamageIdentified
                                };
                                //context.DynamicDecisionDetails.Add(objDyanamicDecisionData);
                            }
                        }

                    }
                }
                //context.SaveChanges();
            }
            else
            {
                if (CIRList.ComponentInspectionReportTypeId != 8)
                {
                    objDynamicTableInput = new Edmx.DynamicTableInput
                    {
                        Id = CIRList.DynamicTableInputs.Id,
                        CirId = CIRList.ComponentInspectionReportId.ToString(),
                        Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                        Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                        Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                        Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                        Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                        Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                        Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                        Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                        Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                        Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                        Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                        Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                        Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                        Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                        Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                        Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                        Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                        Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                        Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                        Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                        Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                        Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                        Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                        Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                        Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                        Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                        Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                        Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                        Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                        Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                        Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                        Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                        Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                        Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                        Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                        Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                        Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                        Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                        Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                        Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                        Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                        Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                        Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                        Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                        Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                        Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                        Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                        Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                        Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                        Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                        Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                        Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                        Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                        Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                        Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                        Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                        Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                        Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                        Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                        Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                    };
                }
                else
                {
                    objDynamicTableInput = new Edmx.DynamicTableInput()
                    {
                        Id = CIRList.DynamicTableInputs.Id,
                        CirId = CIRList.ComponentInspectionReportId.ToString(),
                        Row1Col1 = CIRList.DynamicTableInputs.Row1Col1,
                        Row2Col1 = CIRList.DynamicTableInputs.Row2Col1,
                        Row3Col1 = CIRList.DynamicTableInputs.Row3Col1,
                        Row4Col1 = CIRList.DynamicTableInputs.Row4Col1,
                        Row5Col1 = CIRList.DynamicTableInputs.Row5Col1,
                        Row6Col1 = CIRList.DynamicTableInputs.Row6Col1,
                        Row7Col1 = CIRList.DynamicTableInputs.Row7Col1,
                        Row8Col1 = CIRList.DynamicTableInputs.Row8Col1,
                        Row9Col1 = CIRList.DynamicTableInputs.Row9Col1,
                        Row10Col1 = CIRList.DynamicTableInputs.Row10Col1,
                        Row11Col1 = CIRList.DynamicTableInputs.Row11Col1,
                        Row12Col1 = CIRList.DynamicTableInputs.Row12Col1,
                        Row13Col1 = CIRList.DynamicTableInputs.Row13Col1,
                        Row14Col1 = CIRList.DynamicTableInputs.Row14Col1,

                        Row1Col2 = CIRList.DynamicTableInputs.Row1Col2,
                        Row2Col2 = CIRList.DynamicTableInputs.Row2Col2,
                        Row3Col2 = CIRList.DynamicTableInputs.Row3Col2,
                        Row4Col2 = CIRList.DynamicTableInputs.Row4Col2,
                        Row5Col2 = CIRList.DynamicTableInputs.Row5Col2,
                        Row6Col2 = CIRList.DynamicTableInputs.Row6Col2,
                        Row7Col2 = CIRList.DynamicTableInputs.Row7Col2,
                        Row8Col2 = CIRList.DynamicTableInputs.Row8Col2,
                        Row9Col2 = CIRList.DynamicTableInputs.Row9Col2,
                        Row10Col2 = CIRList.DynamicTableInputs.Row10Col2,
                        Row11Col2 = CIRList.DynamicTableInputs.Row11Col2,
                        Row12Col2 = CIRList.DynamicTableInputs.Row12Col2,
                        Row13Col2 = CIRList.DynamicTableInputs.Row13Col2,
                        Row14Col2 = CIRList.DynamicTableInputs.Row14Col2,

                        Row1Col3 = CIRList.DynamicTableInputs.Row1Col3,
                        Row2Col3 = CIRList.DynamicTableInputs.Row2Col3,
                        Row3Col3 = CIRList.DynamicTableInputs.Row3Col3,
                        Row4Col3 = CIRList.DynamicTableInputs.Row4Col3,
                        Row5Col3 = CIRList.DynamicTableInputs.Row5Col3,
                        Row6Col3 = CIRList.DynamicTableInputs.Row6Col3,
                        Row7Col3 = CIRList.DynamicTableInputs.Row7Col3,
                        Row8Col3 = CIRList.DynamicTableInputs.Row8Col3,
                        Row9Col3 = CIRList.DynamicTableInputs.Row9Col3,
                        Row10Col3 = CIRList.DynamicTableInputs.Row10Col3,
                        Row11Col3 = CIRList.DynamicTableInputs.Row11Col3,
                        Row12Col3 = CIRList.DynamicTableInputs.Row12Col3,
                        Row13Col3 = CIRList.DynamicTableInputs.Row13Col3,
                        Row14Col3 = CIRList.DynamicTableInputs.Row14Col3,

                        Row1Col4 = CIRList.DynamicTableInputs.Row1Col4,
                        Row2Col4 = CIRList.DynamicTableInputs.Row2Col4,
                        Row3Col4 = CIRList.DynamicTableInputs.Row3Col4,
                        Row4Col4 = CIRList.DynamicTableInputs.Row4Col4,
                        Row5Col4 = CIRList.DynamicTableInputs.Row5Col4,
                        Row6Col4 = CIRList.DynamicTableInputs.Row6Col4,
                        Row7Col4 = CIRList.DynamicTableInputs.Row7Col4,
                        Row8Col4 = CIRList.DynamicTableInputs.Row8Col4,
                        Row9Col4 = CIRList.DynamicTableInputs.Row9Col4,
                        Row10Col4 = CIRList.DynamicTableInputs.Row10Col4,
                        Row11Col4 = CIRList.DynamicTableInputs.Row11Col4,
                        Row12Col4 = CIRList.DynamicTableInputs.Row12Col4,
                        Row13Col4 = CIRList.DynamicTableInputs.Row13Col4,
                        Row14Col4 = CIRList.DynamicTableInputs.Row14Col4,

                        Row1Col5 = CIRList.DynamicTableInputs.Row1Col5,
                        Row2Col5 = CIRList.DynamicTableInputs.Row2Col5,
                        Row3Col5 = CIRList.DynamicTableInputs.Row3Col5,
                        Row4Col5 = CIRList.DynamicTableInputs.Row4Col5,
                        Row5Col5 = CIRList.DynamicTableInputs.Row5Col5,
                        Row6Col5 = CIRList.DynamicTableInputs.Row6Col5,
                        Row7Col5 = CIRList.DynamicTableInputs.Row7Col5,
                        Row8Col5 = CIRList.DynamicTableInputs.Row8Col5,
                        Row9Col5 = CIRList.DynamicTableInputs.Row9Col5,
                        Row10Col5 = CIRList.DynamicTableInputs.Row10Col5,
                        Row11Col5 = CIRList.DynamicTableInputs.Row11Col5,
                        Row12Col5 = CIRList.DynamicTableInputs.Row12Col5,
                        Row13Col5 = CIRList.DynamicTableInputs.Row13Col5,
                        Row14Col5 = CIRList.DynamicTableInputs.Row14Col5,

                        Row1Col6 = CIRList.DynamicTableInputs.Row1Col6,
                        Row2Col6 = CIRList.DynamicTableInputs.Row2Col6,
                        Row3Col6 = CIRList.DynamicTableInputs.Row3Col6,
                        Row4Col6 = CIRList.DynamicTableInputs.Row4Col6,
                        Row5Col6 = CIRList.DynamicTableInputs.Row5Col6,
                        Row6Col6 = CIRList.DynamicTableInputs.Row6Col6,
                        Row7Col6 = CIRList.DynamicTableInputs.Row7Col6,
                        Row8Col6 = CIRList.DynamicTableInputs.Row8Col6,
                        Row9Col6 = CIRList.DynamicTableInputs.Row9Col6,
                        Row10Col6 = CIRList.DynamicTableInputs.Row10Col6,
                        Row11Col6 = CIRList.DynamicTableInputs.Row11Col6,
                        Row12Col6 = CIRList.DynamicTableInputs.Row12Col6,
                        Row13Col6 = CIRList.DynamicTableInputs.Row13Col6,
                        Row14Col6 = CIRList.DynamicTableInputs.Row14Col6,
                    };
                }
            }
            return objDynamicTableInput;
        }
        /// <summary>
        /// Common Insert Update Function for ComponentInspection Report
        /// </summary>
        /// <param name = "CIRList" ></ param >
        /// < param name="objTurbine"></param>
        /// <returns></returns>
        //public static Edmx.ComponentInspectionReport ComponentInspectionReports(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, CIR.TurbineProperties objTurbine, int Isupdate, Edmx.ComponentInspectionReport CIRListUp, Edmx.CirData objnewCirData)
        //{
        //    Edmx.ComponentInspectionReport objCompoInspectionReport = new Edmx.ComponentInspectionReport();
        //    if (Isupdate == 1)
        //    {
        //        objCompoInspectionReport = new Edmx.ComponentInspectionReport
        //        {
        //            /* Assign value to CIR Report Entity */
        //            CIRListUp.ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
        //            CIRListUp.ComponentInspectionReportTypeId = CIRList.ComponentInspectionReportTypeId,
        //            CIRListUp.ComponentInspectionReportStateId = CIRList.ComponentInspectionReportStateId,
        //            CIRListUp.ReportTypeId = CIRList.ReportTypeId,
        //            CIRListUp.ReconstructionBooleanAnswerId = CIRList.ReconstructionBooleanAnswerId,
        //            CIRListUp.CIMCaseNumber = CIRList.CIMCaseNumber,
        //            CIRListUp.ReasonForService = CIRList.ReasonForService,
        //            CIRListUp.TurbineNumber = CIRList.TurbineNumber,
        //            CIRListUp.CountryISOId = objTurbine.CountryIsoId,
        //            CIRListUp.SiteName = objTurbine.Site,
        //            CIRListUp.TurbineMatrixId = null,
        //            CIRListUp.LocationTypeId = CIRList.LocationTypeId,
        //            CIRListUp.LocalTurbineId = objTurbine.LocalTurbineId,
        //            CIRListUp.SecondGeneratorBooleanAnswerId = CIRList.SecondGeneratorBooleanAnswerId,
        //            CIRListUp.BeforeInspectionTurbineRunStatusId = CIRList.BeforeInspectionTurbineRunStatusId,
        //            //ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", CIRList.strCommisioningDate + " TT " + CIRList.strInstallationDate + " TT " + CIRList.strFailureDate + "  TT " + CIRList.strInspectionDate, LogType.Information, ""),
        //            CIRListUp.CommisioningDate = ParseDatetime(CIRList.strCommisioningDate),
        //            CIRListUp.InstallationDate = ParseDatetime(CIRList.strInstallationDate),
        //            CIRListUp.FailureDate = ParseDatetime(CIRList.strFailureDate),
        //            CIRListUp.InspectionDate = ParseDatetime(CIRList.strInspectionDate),
        //            CIRListUp.ServiceReportNumber = CIRList.ServiceReportNumber,
        //            CIRListUp.ServiceReportNumberTypeId = CIRList.ServiceReportNumberTypeId,
        //            CIRListUp.ServiceEngineer = CIRList.ServiceEngineer,
        //            CIRListUp.RunHours = CIRList.RunHours,
        //            CIRListUp.Generator1Hrs = CIRList.Generator1Hrs,
        //            CIRListUp.Generator2Hrs = CIRList.Generator2Hrs,
        //            CIRListUp.TotalProduction = CIRList.TotalProduction,
        //            CIRListUp.AfterInspectionTurbineRunStatusId = CIRList.AfterInspectionTurbineRunStatusId,
        //            CIRListUp.Quantity = CIRList.Quantity,
        //            CIRListUp.AlarmLogNumber = CIRList.AlarmLogNumber,
        //            CIRListUp.Description = CIRList.Description,
        //            CIRListUp.DescriptionConsquential = CIRList.DescriptionConsquential,
        //            CIRListUp.ConductedBy = CIRList.ConductedBy,
        //            CIRListUp.SBUId = CIRList.SBUId,
        //            CIRListUp.CIRTemplateGUID = objnewCirData.Guid,// CIRList.CIRTemplateGUID;
        //            CIRListUp.VestasItemNumber = CIRList.VestasItemNumber,
        //            CIRListUp.NotificationNumber = CIRList.NotificationNumber,
        //            CIRListUp.MountedOnMainComponentBooleanAnswerId = CIRList.MountedOnMainComponentBooleanAnswerId,
        //            CIRListUp.ComponentUpTowerSolutionID = CIRList.ComponentUpTowerSolutionID,
        //            CIRListUp.ComponentInspectionReportName = cirname,
        //            CIRListUp.AdditionalInfo = CIRList.AdditionalComments,
        //            CIRListUp.InternalComments = CIRList.InternalComments,
        //            CIRListUp.SBURecommendation = CIRList.SBURecomendation,
        //            CIRListUp.OutSideSign = CIRList.OutSideSign,
        //            CIRListUp.FlangDescription = CIRList.FlangDesc,
        //        };
        //    }
        //    else
        //    {
        //        objCompoInspectionReport = new Edmx.ComponentInspectionReport
        //        {
        //            TemplateVersion = CIRList.TemplateVersion,
        //            ComponentInspectionReportId = CIRList.ComponentInspectionReportId,
        //            ComponentInspectionReportTypeId = CIRList.ComponentInspectionReportTypeId,
        //            ComponentInspectionReportStateId = CIRList.ComponentInspectionReportStateId,
        //            ReportTypeId = CIRList.ReportTypeId,
        //            ReconstructionBooleanAnswerId = CIRList.ReconstructionBooleanAnswerId,
        //            CIMCaseNumber = CIRList.CIMCaseNumber,
        //            ReasonForService = CIRList.ReasonForService,
        //            TurbineNumber = CIRList.TurbineNumber,
        //            CountryISOId = objTurbine.CountryIsoId,
        //            SiteName = objTurbine.Site,
        //            TurbineMatrixId = null,
        //            LocationTypeId = CIRList.LocationTypeId,
        //            LocalTurbineId = objTurbine.LocalTurbineId,
        //            SecondGeneratorBooleanAnswerId = CIRList.SecondGeneratorBooleanAnswerId,
        //            BeforeInspectionTurbineRunStatusId = CIRList.BeforeInspectionTurbineRunStatusId,
        //            CommisioningDate = ParseDatetime(CIRList.strCommisioningDate),
        //            InstallationDate = ParseDatetime(CIRList.strInstallationDate),
        //            FailureDate = ParseDatetime(CIRList.strFailureDate),
        //            InspectionDate = ParseDatetime(CIRList.strInspectionDate),
        //            ServiceReportNumber = CIRList.ServiceReportNumber,
        //            ServiceReportNumberTypeId = CIRList.ServiceReportNumberTypeId,
        //            ServiceEngineer = CIRList.ServiceEngineer,
        //            RunHours = CIRList.RunHours,
        //            Generator1Hrs = CIRList.Generator1Hrs,
        //            Generator2Hrs = CIRList.Generator2Hrs,
        //            TotalProduction = CIRList.TotalProduction,
        //            AfterInspectionTurbineRunStatusId = CIRList.AfterInspectionTurbineRunStatusId,
        //            Quantity = CIRList.Quantity,
        //            AlarmLogNumber = CIRList.AlarmLogNumber,
        //            Description = CIRList.Description,
        //            DescriptionConsquential = CIRList.DescriptionConsquential,
        //            ConductedBy = CIRList.ConductedBy,
        //            SBUId = CIRList.SBUId,
        //            CIRTemplateGUID = CIRList.CIRTemplateGUID,
        //            VestasItemNumber = CIRList.VestasItemNumber,
        //            NotificationNumber = CIRList.NotificationNumber,
        //            MountedOnMainComponentBooleanAnswerId = CIRList.MountedOnMainComponentBooleanAnswerId,
        //            ComponentUpTowerSolutionID = CIRList.ComponentUpTowerSolutionID,
        //            ComponentInspectionReportName = cirname,
        //            ComponentInspectionReportVersion = "v7.0",
        //            AdditionalInfo = CIRList.AdditionalComments,
        //            InternalComments = CIRList.InternalComments,
        //            SBURecommendation = CIRList.SBURecomendation,
        //            FlangDescription = CIRList.FlangDesc,
        //            OutSideSign = CIRList.OutSideSign,
        //            ComponentInspectionReportBlade = new List<Cir.Sync.Services.Edmx.ComponentInspectionReportBlade>()
        //        };
        //    }
        //    return objCompoInspectionReport;
        //}
        /// <summary>
        /// Common Insert Update Function for CIRData
        /// </summary>
        /// <param name = "CIRList" ></ param >
        /// < returns ></ returns >
        public static Edmx.CirData CirData(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList)
        {
            Edmx.CirData objCirData = new Edmx.CirData
            {
                TemplateVersion = CIRList.TemplateVersion,
                CirDataId = 0,
                CirId = CIRList.ComponentInspectionReportId,
                Filename = cirname,
                State = 1,
                Progress = 1,
                Email = CIRList.ServiceEngineer + "@vestas.com",
                Created = DateTime.UtcNow,
                CreatedBy = CIRList.CurrentUser,
                Modified = DateTime.UtcNow,
                ModifiedBy = CIRList.CurrentUser,
                Deleted = false,
                Guid = System.Guid.NewGuid().ToString()
            };
            return objCirData;
        }
        /// <summary>
        /// Send Notification Mail Code
        /// </summary>
        /// <param name="CIRList"></param>
        /// <param name="objCirData"></param>
        public static void SendMail(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, Edmx.CirData objCirData)
        {
            DACIRLog.SaveCirLog(objCirData.CirDataId, "Initial Process started", LogType.Information, objCirData.ModifiedBy);
            //Send Mail 
            try
            {
                DASendCIRUpdateNotification das = new DASendCIRUpdateNotification();
                das.SendMail(CIRList.ComponentInspectionReportId, cirname, CIRList.CurrentUser, 1);
                DACIRLog.SaveCirLog(objCirData.CirDataId, "Create CIR Notification sent to the User", LogType.Information, objCirData.ModifiedBy);

            }
            catch (Exception oException)
            {
                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Email after inserting new CIR " + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                //DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send First Notification sent to Manufacturer due to Error ", LogType.Information, objCirData.ModifiedBy);
            }
            //Notification GENERATOR = 4, GEARBOX = 2, BLADE = 1,TRANSFORMER = 5 AND ReportType is of Type = FAILURE
            List<long> NotificationFor = new List<long> { 1, 2, 4, 5 };
            if ((NotificationFor.Contains(CIRList.ComponentInspectionReportTypeId) && CIRList.ReportTypeId == 2) &&
                (CIRList.ComponentInspectionReportTypeId != 2 || CIRList.Gearbox == null || CIRList.Gearbox.GearboxAuxEquipmentId == 1))
            {
                try
                {
                    DANotification da = new DANotification();
                    da.SendNotification(DANotification.NotificationType.FirstNotification, CIRList.CirDataID);
                    FirstNotificationData firstNotificationData = da.FirstNotifications(CIRList.CirDataID, CIRList.ComponentInspectionReportId);
                    da.SendNotifications(firstNotificationData);
                    DACIRLog.SaveCirLog(objCirData.CirDataId, "First Notification sent to Manufacturer", LogType.Information, objCirData.ModifiedBy);
                }
                catch (Exception oException)
                {
                    string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                    string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : "";

                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending First Notification after inserting new CIR [CIRID = " + CIRList.ComponentInspectionReportId + "]" + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                    // DACIRLog.SaveCirLog(objCirData.CirDataId, "Unable to send First Notification sent to Manufacturer due to Error ", LogType.Information, objCirData.ModifiedBy);
                }
            }
            DACIRLog.SaveCirLog(objCirData.CirDataId, "Initial Process Completed", LogType.Information, objCirData.ModifiedBy);
        }
        /// <summary>
        /// Return CIR Json
        /// </summary>
        /// <param name="CIRList"></param>
        /// <param name="ObjCirData"></param>
        /// <returns></returns>
        public static Edmx.CirJson CirJson(Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, Edmx.CirData ObjCirData)
        {
            Edmx.CirJson objCirXml = new CirJson
            {
                CirDataId = ObjCirData.CirDataId,
                JSON = Newtonsoft.Json.JsonConvert.SerializeObject(CIRList),
                CirJsonId = 0
            };
            return objCirXml;
        }
        /// <summary>
        /// Common Function for Component Inspection Skiip New
        /// </summary>
        /// <param name="objCompSkipNw"></param>
        /// <param name="objCompoSkiip"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportSkiiPNewComponent ComponentInspectionReportSkiiPNew(CIR.ComponentInspectionReportSkiiPNewComponent objCompSkipNw, Edmx.ComponentInspectionReportSkiiP objCompoSkiip, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportSkiiPNewComponent objCompoSkiipNew = new Edmx.ComponentInspectionReportSkiiPNewComponent
            {
                ComponentInspectionReportSkiiPNewComponentId = objCompSkipNw.ComponentInspectionReportSkiiPNewComponentId,
                ComponentInspectionReportSkiiPId = objCompoSkiip.ComponentInspectionReportSkiiPId,
                SkiiPNewComponentVestasUniqueIdentifier = objCompSkipNw.SkiiPNewComponentVestasUniqueIdentifier,
                SkiiPNewComponentVestasItemNumber = objCompSkipNw.SkiiPNewComponentVestasItemNumber,
                SkiiPNewComponentSerialNumber = objCompSkipNw.SkiiPNewComponentSerialNumber
            };
            return objCompoSkiipNew;
        }
        /// <summary>
        /// Common function for ComponentInspectionReportSkiiPFaileds
        /// </summary>
        /// <param name="objCompSkip"></param>
        /// <param name="objCompoSkiip"></param>
        /// <returns></returns>
        public static Edmx.ComponentInspectionReportSkiiPFailedComponent ComponentInspectionReportSkiiPFaileds(CIR.ComponentInspectionReportSkiiPFailedComponent objCompSkip, Edmx.ComponentInspectionReportSkiiP objCompoSkiip, int Isupdate, Edmx.ComponentInspectionReport CIRListUp)
        {
            Edmx.ComponentInspectionReportSkiiPFailedComponent objCompoSkiipFailed = new Edmx.ComponentInspectionReportSkiiPFailedComponent
            {
                ComponentInspectionReportSkiiPFailedComponentId = objCompSkip.ComponentInspectionReportSkiiPFailedComponentId,
                ComponentInspectionReportSkiiPId = objCompoSkiip.ComponentInspectionReportSkiiPId,
                SkiiPFailedComponentVestasUniqueIdentifier = objCompSkip.SkiiPFailedComponentVestasUniqueIdentifier,
                SkiiPFailedComponentVestasItemNumber = objCompSkip.SkiiPFailedComponentVestasItemNumber,
                SkiiPFailedComponentSerialNumber = objCompSkip.SkiiPFailedComponentSerialNumber

            };
            return objCompoSkiipFailed;
        }
        protected static long InsertUpdateCIRDataNew(bool IsUpdate, Cir.Sync.Services.CIR.ComponentInspectionReport CIRList, Edmx.ComponentInspectionReport CIRListUp, CIM_CIREntities context, CIR.TurbineProperties objTurbineType, out long CirDataId)
        {
            long CirID;

            if (IsUpdate)
            {
                CirID = UpdateCIRData(CIRListUp, CIRList, context, objTurbineType, out CirDataId);
            }
            else
            {
                CirID = InsertCIRData(CIRList, context, objTurbineType, out CirDataId);
            }
            return CirID;
        }

        public static CirResponse UpdatePDFData()
        {
            bool isError = false;
            Int64 Total = 0;
            Int64 Success = 0;
            Int64 Fail = 0;
            CirResponse oCirResponse = new CirResponse();
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())// .OrderByDescending(x => x.CirDataId)
                {
                    string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
                    string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                    DateTime date1 = Convert.ToDateTime("2017-12-01");
                    DateTime date2 = Convert.ToDateTime("2017-12-10");
                    var cirData = from Cir in context.CirData
                                  where ((Cir.Created >= date1 && Cir.Created <= date2) && Cir.Deleted == false)
                                  select Cir.CirId;
                    Total = cirData.Count();
                    DACIRLog.SaveCirLog(Total, "Total CIR for PDF Updation count= " + Total, LogType.Information, "");
                    foreach (var CIRIDs in cirData)
                    {
                        try
                        {
                            if (isError == true)
                                isError = false;
                            GeneratePDFDelegate d = null;
                            d = new GeneratePDFDelegate(DACIRReport.RenderCirReport);
                            IAsyncResult R = null;
                            R = d.BeginInvoke(CIRIDs, DocumentPath, SpireLicensePath, null, null); //invoking the method
                            bool returnVal = d.EndInvoke(R);
                            oCirResponse.CirID = CIRIDs;
                            oCirResponse.StatusMessage = "Updated CIR Id" + CIRIDs;
                            DACIRLog.SaveCirLog(CIRIDs, "PDF Updated Successfully Data with ID: " + CIRIDs, LogType.Information, "");
                            Success++;
                        }
                        catch (Exception ex)
                        {
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error in generating PDF.! " + ex.Message, LogType.Error, "");
                            oCirResponse.StatusMessage = "Error in generating PDF";
                            oCirResponse.StatusDetailMessage = ex.Message;
                            DACIRLog.SaveCirLog(CIRIDs, "Error in this ID: " + CIRIDs, LogType.Information, "");
                            isError = true;
                            Fail++;
                        }
                        if (isError) continue;
                    }
                    DACIRLog.SaveCirLog(Total, "Total Success CIR for PDF Updation count= " + Success, LogType.Information, "");
                    DACIRLog.SaveCirLog(Total, "Total Fail CIR for PDF Updation count= " + Fail, LogType.Information, "");

                    return oCirResponse;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Update PDF Mixmatch Data Error in fetching data..! " + ex.Message, LogType.Error, "");
                oCirResponse.StatusMessage = "Update PDF Mixmatch Data Error in fetching data..";
                oCirResponse.StatusDetailMessage = ex.Message;
                return oCirResponse;
            }
        }
    }
}