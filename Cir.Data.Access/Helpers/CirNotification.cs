using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Notification;
using Cir.Data.Access.Services;
using Microsoft.ApplicationInsights;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Cir.Data.Access.Enumerations.Enumeration;
using static Cir.Data.Access.Enumerations.NotificationEnumerations;
using LogType = Cir.Data.Access.Enumerations.Enumeration.LogType;

namespace Cir.Data.Access.Helpers
{
    internal class CirNotification : ICirNotification
    {
        private readonly SyncServiceClient _serviceClient;
        private readonly ICirPDFStorageRepository _cirPdfStorageRepository;
        private readonly ICirLogRepository _cirLogRepository;
        TelemetryClient _telemetryClient = new TelemetryClient();
        IHotlistService _hotlistService;
        public string FirstNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["FirstNotificationCcEmail"];
        public string SecondNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["SecondNotificationCcEmail"];
        public string AbbMwEmail = System.Configuration.ConfigurationManager.AppSettings["AbbMwEmail"];
        public string LeroySomerMwEmail = System.Configuration.ConfigurationManager.AppSettings["LeroySomerMwEmail"];
        public string MailBox1537Email = System.Configuration.ConfigurationManager.AppSettings["MailBox1537Email"];

        public CirNotification(IHotlistService hotlistService, ICirPDFStorageRepository cirPdfStorageRepository , ICirLogRepository cirLogRepository)
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
            _hotlistService = hotlistService;
            _cirPdfStorageRepository = cirPdfStorageRepository;
            _cirLogRepository = cirLogRepository;


        }

        public void SendNotificationMail(CirSubmissionData submissionData, NotificationType notificationType, string currentUser = null, string comment = null)
        {
            try
            {
                var cirId = submissionData.CirId;
                var ReportTypeId = submissionData.Data["rbReportType"] == null ? Convert.ToInt32(submissionData.Data["ddlReportType"]?.Value)
                                    : Convert.ToInt32(submissionData.Data["rbReportType"]?.Value);
                int templateTypeId = (int)Enum.Parse(typeof(CirTemplate), submissionData.CirTemplateName);
                List<long> NotificationFor = new List<long> { 1, 2, 3, 4 };
                var gearboxAux = Convert.ToInt32(submissionData.Data["ddlAuxEquipment"]?.Value);
                var bladeAux = submissionData.Data["ctbAuxEquipment"]?.Value == false ? 1 : 2;
                var generatorAux = Convert.ToInt32(submissionData.Data["ddlGeneratorAuxEquipment"]?.Value);
                var transformerAux = Convert.ToInt32(submissionData.Data["ddlTransformerAuxEquipment"]?.Value);

                if (NotificationFor.Contains(templateTypeId) && ReportTypeId == 2 && (gearboxAux == 1 || bladeAux == 1 || generatorAux == 1 || transformerAux == 1))
                {
                    SendNotificationData(submissionData, notificationType, currentUser, comment);
                }
            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error sending First Notification after inserting new CIR [CIRID = " + submissionData.CirId + "]" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);

            }

        }

        private void SendNotificationData(CirSubmissionData submissionData, NotificationType notificationType, string currentUser, string comment)
        {
            NotificationData notificationData = new NotificationData();
            notificationData.CirId = submissionData.CirId;


            switch (notificationType)
            {
                case NotificationType.FirstNotification:
                    {
                        notificationData = Notifications(submissionData, notificationType);

                        if (FirstNotificationCcEmail != null)
                            notificationData.CCEmails.Add(FirstNotificationCcEmail);

                        string json = "{ \"Body\": \"" + FirstNotificationData.Body(notificationData) +
                            "\", \"Subject\":  \"" + FirstNotificationData.Subject() +
                            "\", \"CirId\":  \"" + notificationData.CirId +
                            "\", \"NotificationType\":  \"" + notificationType.ToString() +
                               "\", \"MessageId\":  \"" + FirstNotificationData.MessageId(notificationData.CirId) + "\"}";

                        _serviceClient.SendCirNotificationMails(notificationData.ToEmails.ToArray(), notificationData.CCEmails.ToArray(), json);
                        _cirLogRepository.AddLogs(submissionData.Id,Convert.ToString(submissionData.Data["txtTurbineNumber"]?.Value), "First Notification sent to Manufacturer", submissionData.ModifiedOn, LogType.Information);
                        
                    }
                    break;
                case NotificationType.SecondNotification:
                    {
                        notificationData = Notifications(submissionData, notificationType);

                        if (SecondNotificationCcEmail != null)
                            notificationData.CCEmails.Add(SecondNotificationCcEmail);

                        // TODO : get pdf bytes from blob

                        notificationData.Updated = true;
                        notificationData.Attachment = Convert.ToBase64String(_cirPdfStorageRepository.GetPDF(Convert.ToInt64(notificationData.Turbine), submissionData.Id, submissionData.Revision, notificationData.CirId));
                        notificationData.AttachmentName = GetCirName(notificationData.SiteName, submissionData.CirTemplateName, notificationData.Turbine, notificationData.CimCaseNo.ToString()) + ".pdf";

                        string json = "{ \"Body\": \"" + SecondNotificationData.Body(notificationData) +
                           "\", \"Subject\":  \"" + SecondNotificationData.Subject() +
                           "\", \"CirId\":  \"" + notificationData.CirId +
                           "\", \"NotificationType\":  \"" + notificationType.ToString() +
                           "\", \"Updated\":  \"" + notificationData.Updated +
                           "\", \"Attachment\":  \"" + notificationData.Attachment +
                           "\", \"AttachmentName\":  \"" + notificationData.AttachmentName +
                              "\", \"MessageId\":  \"" + SecondNotificationData.MessageId(notificationData.CirId) + "\"}";
                        _serviceClient.SendCirNotificationMails(notificationData.ToEmails.ToArray(), notificationData.CCEmails.ToArray(), json);
                        _cirLogRepository.AddLogs(submissionData.Id,Convert.ToString( submissionData.Data["txtTurbineNumber"]?.Value), "Second Notification sent to manufacturer", submissionData.ModifiedOn, LogType.Information);
                    }
                    break;
                case NotificationType.RejectNotification:
                    {
                        notificationData = Notifications(submissionData, notificationType);

                        notificationData.RejectedBy = currentUser;
                        notificationData.Comment = comment;
                        notificationData.ToEmails = notificationData.ToEmails == null ? new List<string>() : notificationData.ToEmails;
                        notificationData.CCEmails = notificationData.CCEmails == null ? new List<string>() : notificationData.CCEmails;
                        notificationData.ToEmails.Add(submissionData.CreatedBy + "@vestas.com");

                        string json = "{ \"Body\": \"" + RejectNotificationData.Body(notificationData) +
                          "\", \"Subject\":  \"" + RejectNotificationData.Subject() +
                          "\", \"CirId\":  \"" + notificationData.CirId +
                          "\", \"NotificationType\":  \"" + notificationType.ToString() +
                          "\", \"RejectedBy\":  \"" + notificationData.RejectedBy +
                          "\", \"Comment\":  \"" + notificationData.Comment +
                             "\", \"MessageId\":  \"" + RejectNotificationData.MessageId(notificationData.CirId) + "\"}";
                        _serviceClient.SendCirNotificationMails(notificationData.ToEmails.ToArray(), notificationData.CCEmails.ToArray(), json);
                        _cirLogRepository.AddLogs(submissionData.Id, submissionData.Data["txtTurbineNumber"]?.Value, "Rejection Notification sent to manufacturer", submissionData.ModifiedOn, LogType.Information);
                    }
                    break;
                case NotificationType.SBUNotification:
                    {
                        notificationData = Notifications(submissionData, notificationType);
                        notificationData.ToEmails = notificationData.ToEmails == null ? new List<string>() : notificationData.ToEmails;
                        notificationData.CCEmails = notificationData.CCEmails == null ? new List<string>() : notificationData.CCEmails;
                        if (notificationData.CimCaseNo != 0 && Is3MWGearBox(notificationData.CimCaseNo))
                        {
                            // send to 3MW gearbox (ignore country SBU)
                            notificationData.ToEmails.Add(MailBox1537Email);
                        }

                        notificationData.RejectedBy = currentUser;
                        notificationData.Comment = comment;
                        notificationData.FileName = GetCirName(notificationData.SiteName, submissionData.CirTemplateName, notificationData.Turbine, notificationData.CimCaseNo.ToString());
                        string json = "{ \"Body\": \"" + SBURejectNotificationData.Body(notificationData).ToString() +
                           "\", \"Subject\":  \"" + SBURejectNotificationData.Subject() +
                           "\", \"CirId\":  \"" + notificationData.CirId +
                           "\", \"NotificationType\":  \"" + notificationType.ToString() +
                           "\", \"RejectedBy\":  \"" + notificationData.RejectedBy +
                           "\", \"Comment\":  \"" + notificationData.Comment +
                            "\", \"FileName\":  \"" + notificationData.FileName +
                              "\", \"MessageId\":  \"" + SBURejectNotificationData.MessageId(notificationData.CirId) + "\"}";
                        _serviceClient.SendCirNotificationMails(notificationData.ToEmails.ToArray(), notificationData.CCEmails.ToArray(), json);
                        _cirLogRepository.AddLogs(submissionData.Id, submissionData.Data["txtTurbineNumber"]?.Value, "Notification sent to SBU", submissionData.ModifiedOn, LogType.Information);

                    }
                    break;


            }
        }


        public void SendMail(CirSubmissionData submissionData, string userName, CirMode type)
        {
            try
            {
                var templateName = submissionData.CirTemplateName;
                var siteName = submissionData.Data["txtSiteName"]?.Value.ToString();
                var turbineNumber = submissionData.Data["txtTurbineNumber"]?.Value.ToString();
                var CIMCaseNumber = submissionData.Data["ddlCimCaseNumber"] == null ? submissionData.Data["txtCimCaseNumber"]?.Value.ToString()
                                    : submissionData.Data["ddlCimCaseNumber"]?.Value.ToString();

                string cirName = GetCirName(siteName, templateName, turbineNumber, CIMCaseNumber);
                var cirId = submissionData.CirId;
                _serviceClient.SendMail(cirName, cirId, userName, (int)type);
                string logText = type == CirMode.New ? "CIR Creation Notification sent to the User" : "CIR Update Notification sent to the User";
                _cirLogRepository.AddLogs(submissionData.Id , submissionData.Data["txtTurbineNumber"]?.Value.ToString(), logText, submissionData.ModifiedOn, LogType.Information);

            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error sending Email after inserting new CIR " + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }
        }


        public static string GetCirName(string site, string template, string turbineno, string CIMCaseNumber)
        {
            var cirname = "";
            var d = DateTime.Today;
            cirname = ((site == null) ? " " : site);
            cirname = cirname.Length > 17 ? cirname.Substring(0, 17) : cirname;
            cirname = cirname + "_" + template + "_" + turbineno + "_" + d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" + d.Day.ToString().PadLeft(2, '0') + "_" + CIMCaseNumber;
            return cirname;

        }

        public static bool Is3MWGearBox(long CIMCase)
        {
            List<long> caseNumbers = new List<long>();
            var databaseAccount = System.Configuration.ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString; ;
            using (SqlConnection objCon = new SqlConnection(databaseAccount))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Casenumber FROM [3MWGearboxes]", objCon))
                {
                    objCon.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        caseNumbers.Add(reader.GetInt64(reader.GetOrdinal("Casenumber")));
                    }
                    reader.Close();
                }
            }

            return caseNumbers.Contains(CIMCase);
        }

        public NotificationData Notifications(CirSubmissionData cirSubmissionData , NotificationType notificationType)
        {
            NotificationData notificationData = SetNotificationData(cirSubmissionData);
            try
            {
                notificationData.Turbine = cirSubmissionData.Data["txtTurbineNumber"]?.Value.ToString();
                var hotlist = _hotlistService.GetAll().Where(x => x.HotItemId == notificationData.ManufactureId).FirstOrDefault();
                if (notificationData.ManufactureId != 0 && (notificationType == NotificationType.FirstNotification || notificationType == NotificationType.SecondNotification))
                {
                    SetManufacturereData(ref notificationData, ref hotlist);

                }

            }
            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error in first notifications" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }
            return notificationData;

        }

        private void SetManufacturereData(ref NotificationData notificationData, ref HotlistDataModel hotlist)
        {
            try
            {
                notificationData.ToEmails = new List<string>();
                notificationData.CCEmails = new List<string>();
                var manufactureId = notificationData.ManufactureId;
                switch (notificationData.ComponentType)
                {
                    case CirTemplate.BladeInspection:
                        var bladeManufacturer = _serviceClient.GetManufacturerList((int)CirTemplate.BladeInspection).Manufacturers.Where(x => x.Id == manufactureId).FirstOrDefault();
                        if (bladeManufacturer != null && !string.IsNullOrEmpty(bladeManufacturer.To))
                        {
                            notificationData = AddEmailAddresses(notificationData, bladeManufacturer.To, bladeManufacturer.Cc);
                            notificationData.Manufacturer = bladeManufacturer.Name;
                            notificationData.ManufacturerContactName = bladeManufacturer.Contact;
                        }
                        break;
                    case CirTemplate.Gearbox:
                        var gearboxManufacturer = _serviceClient.GetManufacturerList((int)CirTemplate.Gearbox).Manufacturers.Where(x => x.Id == manufactureId).FirstOrDefault();
                        if (gearboxManufacturer != null && !string.IsNullOrEmpty(gearboxManufacturer.To))
                        {
                            notificationData = AddEmailAddresses(notificationData, gearboxManufacturer.To, gearboxManufacturer.Cc);
                            notificationData.Manufacturer = gearboxManufacturer.Name;
                            notificationData.ManufacturerContactName = gearboxManufacturer.Contact;
                        }
                        break;
                    case CirTemplate.General:
                        hotlist = _hotlistService.GetAll().Where(x => x.HotItemId == manufactureId).FirstOrDefault();
                        if (hotlist != null && !string.IsNullOrEmpty(hotlist.Email))
                        {
                            string hotlistEmail = hotlist.Email;
                            if (!string.IsNullOrEmpty(hotlist.Cc))
                            {
                                hotlistEmail = hotlistEmail + ";" + hotlist.Cc;
                            }
                            notificationData = AddEmailAddresses(notificationData, hotlistEmail, string.Empty);
                            notificationData.Manufacturer = hotlist.ManufacturerName;

                        }
                        break;
                    case CirTemplate.MainBearing:
                        var mainBearingManufacturer = _serviceClient.GetManufacturerList((int)CirTemplate.MainBearing).Manufacturers.Where(x => x.Id == manufactureId).FirstOrDefault();
                        if (hotlist == null)
                        {
                            if (mainBearingManufacturer != null)
                            {
                                notificationData = AddEmailAddresses(notificationData, hotlist.Email, String.Empty);
                                notificationData.Manufacturer = mainBearingManufacturer.Name;
                            }
                        }

                        if (hotlist != null && !string.IsNullOrEmpty(hotlist.Email))
                        {
                            string hotlistEmail = hotlist.Email;
                            if (!string.IsNullOrEmpty(hotlist.Cc))
                            {
                                hotlistEmail = hotlistEmail + ";" + hotlist.Cc;
                            }
                            notificationData = AddEmailAddresses(notificationData, hotlistEmail, string.Empty);
                            notificationData.Manufacturer = hotlist.ManufacturerName;
                        }

                        break;
                    case CirTemplate.Skiipack:

                        if (hotlist != null && !string.IsNullOrEmpty(hotlist.Email))
                        {
                            string hotlistEmail = hotlist.Email;
                            if (!string.IsNullOrEmpty(hotlist.Cc))
                            {
                                hotlistEmail = hotlistEmail + ";" + hotlist.Cc;
                            }
                            notificationData = AddEmailAddresses(notificationData, hotlistEmail, string.Empty);
                            notificationData.Manufacturer = hotlist.ManufacturerName;
                        }
                        else
                        {
                            notificationData = AddEmailAddresses(notificationData, hotlist.Email, string.Empty);
                            notificationData.Manufacturer = "[INSERT MANUFACTURER HERE]";
                        }
                        break;
                    case CirTemplate.Generator:
                        var generatorManufacturer = _serviceClient.GetManufacturerList((int)CirTemplate.Generator).Manufacturers.Where(x => x.Id == manufactureId).FirstOrDefault();
                        if (generatorManufacturer != null && !string.IsNullOrEmpty(generatorManufacturer.To))
                        {
                            var turbineData = _serviceClient.ValidateGetTurbineData(notificationData.Turbine);

                            if (turbineData != null)
                            {
                                if ((!(generatorManufacturer.Name.ToUpper() == "ABB") && !(generatorManufacturer.Name.ToUpper() == "LEROY SOMER")) || (Convert.ToInt64(turbineData.NominelPower) < 1000 & generatorManufacturer.Name.ToUpper() == "ABB") || ((Convert.ToInt64(turbineData.NominelPower) < 3000 && generatorManufacturer.Name.ToUpper() == "LEROY SOMER")))
                                {
                                    notificationData = AddEmailAddresses(notificationData, generatorManufacturer.To, generatorManufacturer.Cc);
                                    notificationData.Manufacturer = generatorManufacturer.Name;
                                    notificationData.ManufacturerContactName = generatorManufacturer.Contact;

                                }
                                else if ((Convert.ToInt64(turbineData.NominelPower) >= 1000 && generatorManufacturer.Name.ToUpper() == "ABB"))
                                {
                                    notificationData.ToEmails.Add(AbbMwEmail);
                                    notificationData.Manufacturer = generatorManufacturer.Name;
                                    notificationData.ManufacturerContactName = generatorManufacturer.Contact;

                                }
                                else if ((Convert.ToInt64(turbineData.NominelPower) == 3000 && generatorManufacturer.Name.ToUpper() == "LEROY SOMER"))
                                {
                                    notificationData.ToEmails.Add(LeroySomerMwEmail);
                                    notificationData.Manufacturer = generatorManufacturer.Name;
                                    notificationData.ManufacturerContactName = generatorManufacturer.Contact;
                                }
                            }
                        }

                        break;
                    case CirTemplate.Transformer:
                        var transformerManufacturer = _serviceClient.GetManufacturerList((int)CirTemplate.Transformer).Manufacturers.Where(x => x.Id == manufactureId).FirstOrDefault();
                        if (transformerManufacturer != null && !string.IsNullOrEmpty(transformerManufacturer.To))
                        {
                            notificationData = AddEmailAddresses(notificationData, transformerManufacturer.To, transformerManufacturer.Cc);
                            notificationData.Manufacturer = transformerManufacturer.Name;
                            notificationData.ManufacturerContactName = transformerManufacturer.Contact;
                        }
                        break;
                    default:
                        throw new ApplicationException("CIR ComponentType in template doesn't exists!");
                }
            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error in set Manufacturer data" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }        

        }

        private NotificationData SetNotificationData(CirSubmissionData cirSubmissionData)
        {
            NotificationData notification = new NotificationData();
            long manufacturerId = 0;
            var serialNumber = "";
            try
            {
                notification.CirId = cirSubmissionData.CirId;

                notification.SBU = "1";
                notification.SiteName = cirSubmissionData.Data["txtSiteName"]?.Value.ToString();
                notification.CimCaseNo = cirSubmissionData.Data["ddlCimCaseNumber"] == null ? cirSubmissionData.Data["txtCimCaseNumber"]?.Value
                                  : cirSubmissionData.Data["ddlCimCaseNumber"]?.Value;
                notification.FailureDate = Convert.ToDateTime(cirSubmissionData.Data["dtFailuredate"]?.Value);
                notification.Country = cirSubmissionData.Data["txtCountry"]?.Value.ToString();
                notification.ComponentType = (CirTemplate)Enum.Parse(typeof(CirTemplate), cirSubmissionData.CirTemplateName);
                notification.CommisioningDate = Convert.ToDateTime(cirSubmissionData.Data["dtCommissioningdate"]?.Value);
                notification.EditDate = cirSubmissionData.ModifiedOn;
                notification.EditInitials = cirSubmissionData.ModifiedBy;

                var reportType = cirSubmissionData.Data["ddlReportType"]?.Value.ToString();
                var VestasItemNumber = cirSubmissionData.Data["txtVestasItemNumber"]?.Value.ToString();

                var hotlist = VestasItemNumber != null ? _hotlistService.GetAll().Where(x => x.VestasItemNumber == VestasItemNumber).FirstOrDefault() : null;


                switch (notification.ComponentType.ToString().ToUpper())
                {
                    case "GENERAL":
                        manufacturerId = hotlist == null ? 0 : hotlist.HotItemId;
                        break;
                    case "MAIN BEARING":
                        serialNumber = cirSubmissionData.Data["txtMainBearingSerialNumber"]?.Value.ToString();
                        var mainBearingManufacturer = cirSubmissionData.Data["ddlMainBearingManufacturer"]?.Value;
                        manufacturerId = hotlist == null ? mainBearingManufacturer : hotlist.HotItemId;
                        break;
                    case "SKIIPACK":
                        int numberOfComponent = Convert.ToInt32(cirSubmissionData.Data["ddlNumberOfComponents"]?.Value);
                        if (numberOfComponent > 0)
                            serialNumber = cirSubmissionData.Data["ComponentId1SerialNumber"]?.Value;

                        manufacturerId = hotlist == null ? 0 : hotlist.HotItemId;
                        serialNumber = serialNumber == null ? "[UNKNOWN]" : serialNumber;

                        break;
                    case "BLADEINSPECTION":
                        var bladeLength = cirSubmissionData.Data["ddlBladeLength"]?.Value;
                        serialNumber = cirSubmissionData.Data["txtBladeSerialNumber"]?.Value;

                        if (string.IsNullOrEmpty(bladeLength))
                            manufacturerId = 3;
                        else
                            manufacturerId = bladeLength.ToUpper().StartsWith("LM") ? 1 : 2;


                        break;
                    case "GEARBOX":

                        serialNumber = cirSubmissionData.Data["txtGearboxSerialNumber"]?.Value.ToString();
                        long gearboxManufacturer = Convert.ToInt32(cirSubmissionData.Data["ddlGearboxManufacturer"]?.Value);
                        if (gearboxManufacturer > 0)
                        {
                            //if (reportType.ToUpper() == "FAILURE" && cirSubmissionData.Data["ddlAuxEquipment"]?.Value.ToString() == 2)
                            //    manufacturerId = 0;
                            //else
                            manufacturerId = gearboxManufacturer;
                        }

                        break;
                    case "GENERATOR":

                        serialNumber = cirSubmissionData.Data["txtGeneratorSearialNo"]?.Value.ToString();
                        long genManufacturer = Convert.ToInt32(cirSubmissionData.Data["ddlGeneratorManufacturer"]?.Value);
                        if (genManufacturer > 0)
                            manufacturerId = genManufacturer;

                        break;
                    case "TRANSFORMER":
                        serialNumber = cirSubmissionData.Data["txtGeneratorSearialNo"]?.Value.ToString();
                        long transformerManufacturer = Convert.ToInt32(cirSubmissionData.Data["ddlTransformerManufacturer"]?.Value);
                        if (transformerManufacturer > 0)
                            manufacturerId = transformerManufacturer;

                        break;
                    default:
                        throw new ApplicationException("CIR ComponentType in template doesn't exists!");


                }
            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error in set first notifications data" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
            }
            notification.ManufactureId = manufacturerId;
            notification.SerialNo = serialNumber;

            return notification;
        }

        private Notification.NotificationData AddEmailAddresses(Notification.NotificationData notification, string toEmail, string ccEmail)
        {
            foreach (string address in SplitEmailAddresses(toEmail))
            {
                notification.ToEmails.Add(address);
            }
            foreach (string address in SplitEmailAddresses(ccEmail))
            {
                notification.CCEmails.Add(address);
            }
            return notification;
        }

        private List<string> SplitEmailAddresses(string emailAddresses)
        {
            List<string> addresses = new List<string>();
            if (!string.IsNullOrEmpty(emailAddresses))
            {
                foreach (string address in emailAddresses.Split(';'))
                {
                    if (!string.IsNullOrEmpty(address))
                    {
                        addresses.Add(address);
                    }
                }
            }
            return addresses;
        }




    }
}
