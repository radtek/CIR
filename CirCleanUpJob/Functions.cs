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

namespace CirCleanUpJob
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
                throw ex;
            }
        }

        private static void fetchCosmosData()
        {
            int count = 1;
            List<string> lstCollectionName = new List<string>(new string[] { _cirSyncLogCollectionName });
            string updatedCirs = string.Empty, log = string.Empty;
            List<ImageDataModel> lstReference = new List<ImageDataModel>();
            foreach (var collectionName in lstCollectionName)
            {
                // string stQry = "SELECT * FROM " + ComponentInspectionReport + " c where c.cirId in(504168)";
                //string stQry = "SELECT * FROM " + collectionName + " c where c.state in ('Submitted','Approved','Rejected') and c.cirId != 0 and((contains(c.sqlProcessStatus, 'ErrorState#') and contains(c.createdOn, '" + DateTime.Now.ToString("yyyy-MM-dd") + "')) or (contains(c.createdOn, '" + DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd") + "') and(contains(c.imageProcessStatus, 'NotSynced') or contains(c.imageProcessStatus, 'Syncing'))))";
                string stQry = string.Empty;
                if (count == 1)
                    stQry = "SELECT * FROM " + collectionName + " c where c.state in ('Submitted', 'Approved', 'Rejected') and c.cirId != 0 and contains(c.sqlProcessStatus, 'ErrorState#') and c.modifiedOn >='" + DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss.ff") + "' ";
                else
                    stQry = "SELECT * FROM " + collectionName + " c where c.state in ('Submitted', 'Approved', 'Rejected') and c.cirId != 0 and (contains(c.imageProcessStatus, 'NotSynced') or contains(c.imageProcessStatus, 'Syncing')) and not (contains(c.modifiedOn, '" + DateTime.Now.ToString("yyyy-MM-dd") + "') or contains(c.modifiedOn, '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'))";

                List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionName),
                        stQry, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();
                foreach (var report in reports)
                {
                    bool isImageSyncIssue = false;
                    if (report.Data != null)
                    {
                        try
                        {
                            var masterReport = (collectionName == _cirSyncLogCollectionName) ? _documentClient.CreateDocumentQuery<CirSubmissionData>(
                               UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                               new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                             .Where(f => f.CirId == Convert.ToInt64(report.CirId)).ToList<CirSubmissionData>().FirstOrDefault() : null;

                            //if (masterReport != null && masterReport.Revision > report.Revision && masterReport.SqlProcessStatus.Contains("Transferred"))
                            if (masterReport != null && masterReport.SqlProcessStatus.Contains("Transferred") && masterReport.Revision >= report.Revision)
                            {
                                _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, _cirSyncLogCollectionName, report.Id),
                                          new RequestOptions { PartitionKey = new PartitionKey(keyValue: getPartition(report.CirId)) }
                                           ).ConfigureAwait(false);
                                //masterReport.ModifiedOn = DateTime.UtcNow;
                                //_documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, masterReport.Id), masterReport);
                                //if (CheckCirExistsInMainColection(report.CirId))
                                //{
                                //    _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, _cirSyncLogCollectionName, report.Id),
                                //           new RequestOptions { PartitionKey = new PartitionKey(keyValue: getPartition(report.CirId)) }
                                //           ).ConfigureAwait(false);
                                //}
                            }
                            else
                            {
                                var imageComponentKey = report.Data["imagecomponentKey"];
                                var page3UploadImages = report.Data["page3UploadImages"];
                                lstReference = report.ImageReferences != null ? report.ImageReferences.ToList() : new List<ImageDataModel>();
                                if (imageComponentKey != null)
                                {
                                    ImagecomponentKey lstImagecomponentKey = JsonConvert.DeserializeObject<ImagecomponentKey>(Convert.ToString(imageComponentKey));
                                    if (lstReference == null || lstReference.Count == 0)
                                    {
                                        if (string.IsNullOrEmpty(log))
                                            log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        else
                                            log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;

                                        isImageSyncIssue = true;
                                        lstImagecomponentKey.sections = null;
                                        if (lstImagecomponentKey.uploadedImagesCache != null)
                                            lstImagecomponentKey.uploadedImagesCache.Clear();
                                        lstImagecomponentKey.withPlatePicture = false;
                                        lstImagecomponentKey.plate = null;
                                        lstImagecomponentKey.reason = "Data corrected by scheduler";
                                        report.Data["imagecomponentKey"] = JToken.Parse(JsonConvert.SerializeObject(lstImagecomponentKey));
                                    }
                                    else if (lstImagecomponentKey.uploadedImagesCache != null && lstImagecomponentKey.uploadedImagesCache.Count > lstReference.Count)
                                    {
                                        var result = lstReference.Where(p => lstImagecomponentKey.uploadedImagesCache.Any(x => x.imageId == p.ImageId)).ToList();

                                        // new logic 

                                        var lstcomponentImages = ComponentInspectionImageData(report.CirId, lstReference, uploadedImagesCache: lstImagecomponentKey.uploadedImagesCache);
                                        if (lstcomponentImages != null && lstcomponentImages.Count > 0)
                                            result.AddRange(lstcomponentImages);

                                        if (lstImagecomponentKey.uploadedImagesCache.Count != result.Count)
                                        {
                                            lstImagecomponentKey.uploadedImagesCache.RemoveAll(x => !result.Any(y => y.ImageId == x.imageId));

                                            if (lstImagecomponentKey.sections != null)
                                            {
                                                PropertyInfo[] properties = lstImagecomponentKey.sections.GetType().GetProperties();
                                                foreach (PropertyInfo property in properties)
                                                {

                                                    dynamic section = null;
                                                    switch (property.Name)
                                                    {
                                                        case "section1":
                                                            {
                                                                section = (Section1)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section1.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section2":
                                                            {
                                                                section = (Section2)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section2.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section3":
                                                            {
                                                                section = (Section3)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section3.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section4":
                                                            {
                                                                section = (Section4)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section4.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section5":
                                                            {
                                                                section = (Section5)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section5.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section6":
                                                            {
                                                                section = (Section6)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section6.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section7":
                                                            {
                                                                section = (Section7)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section7.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section8":
                                                            {
                                                                section = (Section8)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section8.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section9":
                                                            {
                                                                section = (Section9)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section9.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section10":
                                                            {
                                                                section = (Section10)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section10.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section11":
                                                            {
                                                                section = (Section11)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section11.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                        case "section12":
                                                            {
                                                                section = (Section12)property.GetValue(lstImagecomponentKey.sections, null);
                                                                if (section != null)
                                                                {
                                                                    var images = (List<Images>)section.images;
                                                                    lstImagecomponentKey.sections.section12.images = images.Where(p => result.Any(x => x.ImageId == p.imageId)).ToList();
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                            report.Data["imagecomponentKey"] = JToken.Parse(JsonConvert.SerializeObject(lstImagecomponentKey));
                                        }

                                        report.ImageReferences = result;
                                        if (string.IsNullOrEmpty(log))
                                            log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        else
                                            log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;

                                        isImageSyncIssue = true;
                                        if (result.Count == 0)
                                        {
                                            lstImagecomponentKey.sections = null;
                                            lstImagecomponentKey.uploadedImagesCache.Clear();
                                            lstImagecomponentKey.withPlatePicture = false;
                                            lstImagecomponentKey.plate = null;
                                            lstImagecomponentKey.reason = "Data corrected by scheduler";
                                            report.Data["imagecomponentKey"] = JToken.Parse(JsonConvert.SerializeObject(lstImagecomponentKey));
                                        }
                                    }
                                    else if (lstImagecomponentKey.uploadedImagesCache != null && lstImagecomponentKey.uploadedImagesCache.Count < lstReference.Count)
                                    {
                                        int initialUploadImagesCacheCount = lstImagecomponentKey.uploadedImagesCache.Count;
                                        var result = lstImagecomponentKey.uploadedImagesCache.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();

                                        var lstcomponentImages = ComponentInspectionImageInfo(report.CirId, lstReference, uploadedImagesCache: lstImagecomponentKey.uploadedImagesCache);
                                        if (lstcomponentImages != null && lstcomponentImages.Count > 0)
                                            result.AddRange(lstcomponentImages);


                                        if (lstImagecomponentKey.uploadedImagesCache.Count != result.Count)
                                        {
                                            //report.ImageReferences.ToList().RemoveAll(x => !result.Any(y => y.imageId == x.ImageId));
                                            var list = report.ImageReferences.ToList();
                                            list.RemoveAll(x => !result.Any(y => y.imageId == x.ImageId));
                                            report.ImageReferences = list;
                                        }

                                        lstImagecomponentKey.uploadedImagesCache = result;
                                        if (initialUploadImagesCacheCount != lstImagecomponentKey.uploadedImagesCache.Count)
                                        {
                                            isImageSyncIssue = true;
                                            if (string.IsNullOrEmpty(log))
                                                log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                            else
                                                log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        }
                                        if (lstImagecomponentKey.sections != null)
                                        {
                                            PropertyInfo[] properties = lstImagecomponentKey.sections.GetType().GetProperties();
                                            foreach (PropertyInfo property in properties)
                                            {

                                                dynamic section = null;
                                                switch (property.Name)
                                                {
                                                    case "section1":
                                                        {
                                                            section = (Section1)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section1.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section2":
                                                        {
                                                            section = (Section2)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section2.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section3":
                                                        {
                                                            section = (Section3)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section3.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section4":
                                                        {
                                                            section = (Section4)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section4.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section5":
                                                        {
                                                            section = (Section5)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section5.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section6":
                                                        {
                                                            section = (Section6)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section6.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section7":
                                                        {
                                                            section = (Section7)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section7.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section8":
                                                        {
                                                            section = (Section8)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section8.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section9":
                                                        {
                                                            section = (Section9)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section9.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section10":
                                                        {
                                                            section = (Section10)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section10.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section11":
                                                        {
                                                            section = (Section11)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section11.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                    case "section12":
                                                        {
                                                            section = (Section12)property.GetValue(lstImagecomponentKey.sections, null);
                                                            if (section != null)
                                                            {
                                                                var images = (List<Images>)section.images;
                                                                lstImagecomponentKey.sections.section12.images = images.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();
                                                            }
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        report.Data["imagecomponentKey"] = JToken.Parse(JsonConvert.SerializeObject(lstImagecomponentKey));
                                        if (result.Count == 0)
                                        {
                                            isImageSyncIssue = true;
                                            report.ImageReferences = null;
                                            lstImagecomponentKey.sections = null;
                                            lstImagecomponentKey.withPlatePicture = false;
                                            lstImagecomponentKey.plate = null;
                                            lstImagecomponentKey.reason = "Data corrected by scheduler";
                                            report.Data["imagecomponentKey"] = JToken.Parse(JsonConvert.SerializeObject(lstImagecomponentKey));
                                        }
                                    }
                                }
                                else if (page3UploadImages != null)
                                {
                                    List<ImageInfo> lstpage3UploadImages = JsonConvert.DeserializeObject<List<ImageInfo>>(page3UploadImages.ToString());
                                    if (lstReference == null || lstReference.Count == 0)
                                    {
                                        if (string.IsNullOrEmpty(log))
                                            log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        else
                                            log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;

                                        isImageSyncIssue = true;
                                        report.Data["page3UploadImages"] = null;
                                        report.Data["cbPlateTypePictureNotPossible"] = true;
                                        report.Data["tbPlateTypePictureNotPossibleReason"] = "Data corrected by scheduler";
                                    }
                                    else if (lstpage3UploadImages.Count > lstReference.Count)
                                    {
                                        var result = lstReference.Where(p => lstpage3UploadImages.Any(x => x.imageId == p.ImageId)).ToList();

                                        // new logic 

                                        var lstcomponentImages = ComponentInspectionImageData(report.CirId, lstReference, lstpage3UploadImages);
                                        if (lstcomponentImages != null && lstcomponentImages.Count > 0)
                                            result.AddRange(lstcomponentImages);

                                        if (result.Count != lstpage3UploadImages.Count)
                                        {
                                            lstpage3UploadImages.RemoveAll(x => !result.Any(y => y.ImageId == x.imageId));
                                            report.Data["page3UploadImages"] = JToken.Parse(JsonConvert.SerializeObject(lstpage3UploadImages));
                                        }

                                        report.ImageReferences = result;

                                        if (string.IsNullOrEmpty(log))
                                            log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        else
                                            log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;

                                        isImageSyncIssue = true;
                                        if (result.Count == 0)
                                        {
                                            report.Data["page3UploadImages"] = null;
                                            report.Data["cbPlateTypePictureNotPossible"] = true;
                                            report.Data["tbPlateTypePictureNotPossibleReason"] = "Data corrected by scheduler";
                                        }
                                    }
                                    else if (lstpage3UploadImages.Count < lstReference.Count)
                                    {
                                        int initialPage3UploadImagesCount = lstpage3UploadImages.Count;
                                        var result = lstpage3UploadImages.Where(p => lstReference.Any(x => x.ImageId == p.imageId)).ToList();

                                        // new logic 
                                        var lstcomponentImages = ComponentInspectionImageInfo(report.CirId, lstReference, lstpage3UploadImages);
                                        if (lstcomponentImages != null && lstcomponentImages.Count > 0)
                                            result.AddRange(lstcomponentImages);

                                        if (lstReference.Count != result.Count)
                                        {
                                            //report.ImageReferences.ToList().RemoveAll(x => !result.Any(y => y.imageId == x.ImageId));
                                            var list = report.ImageReferences.ToList();
                                            list.RemoveAll(x => !result.Any(y => y.imageId == x.ImageId));
                                            report.ImageReferences = list;
                                        }

                                        report.Data["page3UploadImages"] = JToken.Parse(JsonConvert.SerializeObject(result));


                                        isImageSyncIssue = true;
                                        if (string.IsNullOrEmpty(log))
                                            log = "CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;
                                        else
                                            log = log + " # CirId : " + report.CirId + " , Created By : " + report.CreatedBy + " , Modified By : " + report.ModifiedBy + " , Modified On : " + report.ModifiedOn;

                                        if (result.Count == 0)
                                        {
                                            isImageSyncIssue = true;
                                            report.ImageReferences = null;
                                            report.Data["cbPlateTypePictureNotPossible"] = true;
                                            report.Data["tbPlateTypePictureNotPossibleReason"] = "Data corrected by scheduler";
                                        }
                                    }
                                }

                                if (isImageSyncIssue)
                                {
                                    report.ImageProcessStatus = ImageProcessStatus.Synced;
                                    report.SqlProcessStatus = "NotTransferred";
                                    report.LockedBy = "";
                                    report.ModifiedOn = DateTime.UtcNow;
                                    updatedCirs = updatedCirs + " , Success: " + report.CirId;
                                    if (!CheckCirExistsInMainColection(report.CirId))
                                    {
                                        report.Schema = string.Empty;
                                        report.LockedBy = string.Empty;
                                        _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport), report).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        report.Schema = string.Empty;
                                        report.LockedBy = string.Empty;
                                        _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ComponentInspectionReport, report.Id), report).ConfigureAwait(false);
                                    }

                                    _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, collectionName, report.Id));
                                    SendMail(report.ModifiedBy, report.CirId);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            updatedCirs = updatedCirs + " , Failed: " + report.CirId;
                            throw ex;
                        }

                    }
                }

            }
            if (!string.IsNullOrEmpty(log))
            {

                try
                {
                    var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorageLogContainerName"]);   
                    string binaryDataFileName = "CirCleanUp" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt";
                    CloudBlockBlob binaryDataBlockBlob = container.GetBlockBlobReference(binaryDataFileName);
                    if (binaryDataBlockBlob.Exists())
                    {
                        string downloadedLog = binaryDataBlockBlob.DownloadText();
                        log = downloadedLog + " # " + log;
                    }
                    binaryDataBlockBlob.UploadText(log);
                }

                catch(Exception e)

                {

                    throw e;
                }
            }
        }

        private static void SendMail(string modifiedBy, long cirId)
        {
            string emailBody = @"We have found image issues in the CIR you have submitted and it got stuck in error mode within the back end of our application
                                                    We have now released it, but it might be that images are missing now due to the error during image upload
                                        CIR ID: " + cirId + " Please evaluate if all images are applied, if not please re-apply them and re - submit the CIR.  ";

            SyncServiceClient _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
            _serviceClient.SendMails(modifiedBy, "", emailBody, "CIR Issue with ID: " + cirId);
           
            //Cir.Sync.Services.SyncService service = new Cir.Sync.Services.SyncService();
            //service.SendMails("angpa", "", emailBody, "CIR Issue with ID: " + cirId);
        }

        private static dynamic ComponentInspectionImageInfo(long cirId, IList<ImageDataModel> lstRefrences, List<ImageInfo> lstpage3UploadImages = null, List<UploadedImagesCache> uploadedImagesCache = null)
        {           

            string stQry1 = "SELECT * FROM " + ComponentInspectionReport + " c where   c.cirId =" + cirId;

            List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                          UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                    stQry1, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();

            List<string> lstimageId;
            if (lstpage3UploadImages != null)

                lstimageId = lstRefrences.Where(x => !lstpage3UploadImages.Any(y => y.imageId == x.ImageId)).Select(a => a.ImageId).ToList();

            else
                lstimageId = lstRefrences.Where(x => !uploadedImagesCache.Any(y => y.imageId == x.ImageId)).Select(a => a.ImageId).ToList();


            if (reports.Count > 0 && lstimageId.Count > 0)
            {
                //dynamic lstimageupload;
                if (lstpage3UploadImages != null)
                {                    
                    var page3UploadImages = reports[0].Data["page3UploadImages"];
                    List<ImageInfo> uploadPageImages3 = JsonConvert.DeserializeObject<List<ImageInfo>>(page3UploadImages.ToString());
                    return  uploadPageImages3.Where(p => lstimageId.Any(x => x == p.imageId)).ToList();
                }
                else
                {                  
                    var imageComponentKey = reports[0].Data["imagecomponentKey"];
                    ImagecomponentKey lstImagecomponentKey = JsonConvert.DeserializeObject<ImagecomponentKey>(imageComponentKey.ToString());
                    return lstImagecomponentKey.uploadedImagesCache.Where(p => lstimageId.Any(x => x == p.imageId)).ToList();                  
                }
            }
            return null;             
        }

        private static List<ImageDataModel> ComponentInspectionImageData(long cirId, IList<ImageDataModel> lstRefrences, List<ImageInfo> lstpage3UploadImages = null, List<UploadedImagesCache> uploadedImagesCache = null)
        {
            var imageList = new List<ImageDataModel>();

            string stQry1 = "SELECT * FROM " + ComponentInspectionReport + " c where   c.cirId =" + cirId;

            List<CirSubmissionData> reports = _documentClient.CreateDocumentQuery<CirSubmissionData>(
                          UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                    stQry1, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true }).ToList<CirSubmissionData>();

            List<string> lstimageId;
            if (lstpage3UploadImages !=null)
                
             lstimageId = lstpage3UploadImages.Where(x => !lstRefrences.Any(y => y.ImageId == x.imageId)).Select(a => a.imageId).ToList();

            else
                lstimageId = uploadedImagesCache.Where(x => !lstRefrences.Any(y => y.ImageId == x.imageId)).Select(a => a.imageId).ToList();


            if (reports.Count > 0 && lstimageId.Count > 0)
                imageList = reports[0].ImageReferences.Where(p => lstimageId.Any(x => x == p.ImageId)).ToList();

            return imageList;
        }

        public static bool CheckCirExistsInMainColection(long cirId)
        {
            try
            {
                return _documentClient.CreateDocumentQuery<CirSubmissionData>(
                              UriFactory.CreateDocumentCollectionUri(DatabaseId, ComponentInspectionReport),
                              new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                          .Where(f => f.CirId == Convert.ToInt64(cirId)).AsEnumerable().Any();
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}
