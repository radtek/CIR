using Cir.Common.MailArchive;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.Models;
using Cir.Sync.Services.Notification;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace Cir.Sync.Services.DAL
{
    public class DANotification
    {
        public enum SendNotificationResult
        {
            Sent,
            NotSent,
            Ignored
        }
        public enum NotificationType
        {
            FirstNotification = 0,
            SecondNotification = 1,
        }

        public enum SbuNotificationType
        {
            Notification = 0,
            Warning = 1,
        }

        public string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public string InboxUrl = System.Configuration.ConfigurationManager.AppSettings["InboxUrl"];
        public string InboxEmail = System.Configuration.ConfigurationManager.AppSettings["InboxEmail"];
        public string FeedbackToEmail = System.Configuration.ConfigurationManager.AppSettings["FeedbackToEmail"];
        public string NotificationEmail = System.Configuration.ConfigurationManager.AppSettings["NotificationEmail"];
        public string MailBox1537Email = System.Configuration.ConfigurationManager.AppSettings["MailBox1537Email"];
        public string HotlistEmail = System.Configuration.ConfigurationManager.AppSettings["HotlistEmail"];
        public string FirstNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["FirstNotificationCcEmail"];
        public string SecondNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["SecondNotificationCcEmail"];
        public string AbbMwEmail = System.Configuration.ConfigurationManager.AppSettings["AbbMwEmail"];
        public string LeroySomerMwEmail = System.Configuration.ConfigurationManager.AppSettings["LeroySomerMwEmail"];
        public string SentActualMails = System.Configuration.ConfigurationManager.AppSettings["SentActualMails"];
        public static DateTime FromDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["SendOnDate"]);
        public static DateTime ToDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["ToDate"]);
        public static Int32 YEAR = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["YEAR"]);

        public static string databaseId = ConfigurationManager.AppSettings["Database"];
        public static string endPointURI = ConfigurationManager.AppSettings["EndPointUrl"];
        public static string primaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
        public static string collectionName = ConfigurationManager.AppSettings["CirNotificationCollectionName"];

        public DANotification()
        {

        }



        public bool SendFirstNotification(long CirDataId)
        {
            var sent = SendNotification(NotificationType.FirstNotification, CirDataId);
            return sent == SendNotificationResult.Sent;
        }

        public long SendSbuRejectNotification(CirData cir, string comment)
        {
            long id = 0;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                ComponentInspectionReport c = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cir.CirId).FirstOrDefault();
                var sbuId = c.SBUId;
                var countryIsoId = c.CountryISOId;
                var cimCaseNo = c.CIMCaseNumber;
                id = AddSbuRejectNotification(cir.CirId, sbuId, cir.Filename, cimCaseNo, cir.ModifiedBy, comment);
            }

            return id;


        }

        public long SendRejectNotification(CirData cir, string comment)
        {
            long id = 0;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                ComponentInspectionReport c = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cir.CirId).FirstOrDefault();
                long? sbuId = c.SBUId;
                long? cimCaseNo = c.CIMCaseNumber;
                if (!cimCaseNo.HasValue)
                {
                    cimCaseNo = 0;
                }

                try
                {
                    MailAddress m = new MailAddress(cir.Email);
                }
                catch (Exception ex)
                {
                    cir.Email = cir.CreatedBy + "@vestas.com";
                }
                id = AddRejectNotification(cir.CirId, sbuId, cir.Filename, cir.Email, cir.ModifiedBy, comment, cimCaseNo.Value);
            }
            return id;
        }

        public SendNotificationResult SendNotification(NotificationType notificationType, long CirDataId)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirData cirData = new CirData();
                cirData = context.CirData.Where(x => x.CirDataId == CirDataId).FirstOrDefault();
                Cir.Sync.Services.Edmx.ComponentInspectionReport componentInspectionReport = new Cir.Sync.Services.Edmx.ComponentInspectionReport();
                componentInspectionReport = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                EditHistory editHistory = context.EditHistory.Where(x => x.ComponentInspectionReportId == componentInspectionReport.ComponentInspectionReportId).OrderByDescending(z => z.EditVersion).FirstOrDefault();


                var serialNumber = "";
                var cirDataId = cirData.CirDataId;
                var cirId = cirData.CirId;

                var sbuId = componentInspectionReport.SBUId;
                var siteName = componentInspectionReport.SiteName;
                var reportType = componentInspectionReport.ReportType.Name;
                var caseNumber = componentInspectionReport.CIMCaseNumber;
                var failureDate = componentInspectionReport.FailureDate;
                var countryIsoId = componentInspectionReport.CountryISOId;
                var componentType = componentInspectionReport.ComponentInspectionReportType.Name;

                var commisioningDate = componentInspectionReport.CommisioningDate;
                var mountedOnMainComponent = componentInspectionReport.MountedOnMainComponentBooleanAnswerId;
                var VestasItemNumber = componentInspectionReport.VestasItemNumber;

                DateTime? editDate = null;
                string editInitials = null;
                if (editHistory != null)
                {
                    editDate = editHistory.EditDate;
                    editInitials = editHistory.EditInitials;
                }
                else
                {
                    editDate = null;
                    editInitials = null;
                }

                // var hotItemChoice =  Utility.Fields.HotItemChoice(cir.Xml);
                var templateVersion = 8;
                //var templateVersion = 7;
                long manufacturerId = 0;

                //mandatory field value check
                if (string.IsNullOrEmpty(sbuId.ToString()) || string.IsNullOrEmpty(caseNumber.ToString())
                    || string.IsNullOrEmpty(countryIsoId.ToString())
                    || string.IsNullOrEmpty(cirId.ToString())
                    || string.IsNullOrEmpty(reportType.ToString())
                    || string.IsNullOrEmpty(componentType.ToString())
                    )
                {
                    return SendNotificationResult.NotSent;
                }
                //if mounted on main component, no notification is sent
                //if (mountedOnMainComponent == 1)
                //  {
                //      return SendNotificationResult.NotSent;
                //  }
                //only proceed if report type is failure
                // if (reportType.ToUpper() != "FAILURE")
                // {
                //     return SendNotificationResult.NotSent;
                //  }

                //reads component specific data, based on component type
                switch (componentType.ToUpper())
                {
                    case "GENERAL":
                        //if (string.IsNullOrEmpty(hotItemChoice) || !long.TryParse(hotItemChoice, out hotItemId)) {
                        //    return SendNotificationResult.NotSent;
                        //}
                        if (string.IsNullOrEmpty(VestasItemNumber))
                        {
                            return SendNotificationResult.NotSent;
                        }
                        HotItem hotItem = context.HotItem.Where(x => x.VestasItemNumber == VestasItemNumber).FirstOrDefault();
                        if (hotItem == null)
                        {
                            return SendNotificationResult.NotSent;
                        }

                        // general notification on hotlist item
                        // HACK: set manufacturer ID = hot item ID for general reports on hotlist items
                        manufacturerId = hotItem.HotItemId;
                        break;
                    case "MAIN BEARING":
                        ComponentInspectionReportMainBearing bearing = context.ComponentInspectionReportMainBearing.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                        serialNumber = bearing.MainBearingSerialNumber;
                        var mainBearingManufacturer = bearing.MainBearingManufacturerId;

                        if (!string.IsNullOrEmpty(VestasItemNumber))
                        {
                            HotItem hotItemMainBearing = context.HotItem.Where(x => x.VestasItemNumber == VestasItemNumber).FirstOrDefault();

                            if (hotItemMainBearing == null)
                            {
                                if (string.IsNullOrEmpty(mainBearingManufacturer.ToString()))
                                {
                                    return SendNotificationResult.NotSent;
                                }
                                manufacturerId = mainBearingManufacturer.Value;
                            }
                            else
                            {
                                manufacturerId = hotItemMainBearing.HotItemId;
                            }
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(mainBearingManufacturer.ToString()))
                            {
                                return SendNotificationResult.NotSent;
                            }
                            manufacturerId = mainBearingManufacturer.Value;
                        }
                        break;
                    case "SKIIPACK":
                        ComponentInspectionReportSkiiP skiip = context.ComponentInspectionReportSkiiP.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                        ComponentInspectionReportSkiiPNewComponent skiipnew = context.ComponentInspectionReportSkiiPNewComponent.Where(x => x.ComponentInspectionReportSkiiPId == skiip.ComponentInspectionReportSkiiPId).FirstOrDefault();
                        if (skiipnew != null)
                        {
                            serialNumber = skiipnew.SkiiPNewComponentSerialNumber;
                        }

                        if (!string.IsNullOrEmpty(VestasItemNumber))
                        {
                            HotItem hotItemSkiiPack = context.HotItem.Where(x => x.VestasItemNumber == VestasItemNumber).FirstOrDefault();

                            if (hotItemSkiiPack != null)
                            {
                                manufacturerId = hotItemSkiiPack.HotItemId;
                            }
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(serialNumber))
                            {
                                // serial is empty, use dummy serial
                                serialNumber = "[UNKNOWN]";
                            }
                            // we have no Skiipack manufacturer - the notification is sent to the hotlist email with a dummy manufacturer name
                            manufacturerId = -1;
                        }
                        break;
                    case "BLADE":
                        ComponentInspectionReportBlade componentInspectionReportBlade = context.ComponentInspectionReportBlade.Where(x => x.ComponentInspectionReportId == componentInspectionReport.ComponentInspectionReportId).FirstOrDefault();
                        var bladeLength = componentInspectionReportBlade.BladeLength.Name;
                        serialNumber = componentInspectionReportBlade.BladeSerialNumber;
                        if (templateVersion >= 4)
                        {
                            if (string.IsNullOrEmpty(bladeLength))
                            {
                                // TODO: change this - this is how the system apparently has always worked for V1 CIR!
                                manufacturerId = 3;
                            }
                            else
                            {
                                manufacturerId = bladeLength.ToUpper().StartsWith("LM") ? 1 : 2;
                            }
                        }
                        //This hack is used to handle templates beneath V4
                        else
                        {
                            if (string.IsNullOrEmpty(bladeLength))
                            {
                                // TODO: change this - this is how the system apparently has always worked for V1 CIR!
                                manufacturerId = 2;
                            }
                            else
                            {
                                manufacturerId = bladeLength.ToUpper().StartsWith("LM") ? 1 : 2;
                            }
                        }
                        break;
                    case "GEARBOX":
                        ComponentInspectionReportGearbox gear = context.ComponentInspectionReportGearbox.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                        serialNumber = gear.GearboxSerialNumber;
                        long gearboxManufacturer = gear.GearboxManufacturerId;
                        if (gear.GearboxManufacturerId > 0)
                        {
                            if (reportType.ToUpper() == "FAILURE" && gear.GearboxAuxEquipmentId == 2)
                            {
                                return SendNotificationResult.NotSent;
                            }
                            manufacturerId = gearboxManufacturer;
                        }
                        else
                        {
                            return SendNotificationResult.NotSent;
                        }


                        break;
                    case "GENERATOR":
                        ComponentInspectionReportGenerator gen = context.ComponentInspectionReportGenerator.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                        serialNumber = gen.GeneratorSerialNumber;
                        long genManufacturer = gen.GeneratorManufacturerId;
                        if (genManufacturer > 0)
                        {
                            manufacturerId = genManufacturer;
                        }
                        else
                        {
                            return SendNotificationResult.NotSent;
                        }

                        break;
                    case "TRANSFORMER":
                        ComponentInspectionReportTransformer trans = context.ComponentInspectionReportTransformer.Where(x => x.ComponentInspectionReportId == cirData.CirId).FirstOrDefault();
                        serialNumber = trans.TransformerSerialNumber;
                        var transformerManufacturer = trans.TransformerManufacturerId;
                        if (transformerManufacturer > 0)
                        {
                            manufacturerId = transformerManufacturer;
                        }
                        else
                        {
                            return SendNotificationResult.NotSent;
                        }
                        manufacturerId = transformerManufacturer;
                        break;
                    default:
                        throw new ApplicationException("CIR ComponentType in template doesn't exists!");
                }

                // only add first notifications if a similar notification has not been sent before
                // if (notificationType == NotificationType.FirstNotification)
                // {
                //   if (da.FirstNotificationExists(cirId, countryIsoId, commisioningDate, failureDate, componentType, turbineMatrixId, manufacturerId, siteName, serialNumber))
                // {
                //   return SendNotificationResult.Ignored;
                //     }
                // }

                var sent = SendNotificationResult.NotSent;

                //SendNotification is called with with the type 'FirstNotification' 
                if (notificationType == NotificationType.FirstNotification)
                {
                    AddFirstNotification(cirDataId, cirId, sbuId, countryIsoId, commisioningDate, failureDate, editDate,
                                            componentType, 0, manufacturerId, editInitials, siteName, serialNumber);
                    sent = SendNotificationResult.Sent;
                }
                //SendNotification is called with with the type 'SecondNotification'
                else if (notificationType == NotificationType.SecondNotification)
                {
                    AddSecondNotification(cirDataId, cirId, caseNumber, sbuId, componentType, 0, manufacturerId);
                    sent = SendNotificationResult.Sent;
                }
                return sent;
            }
        }

        public void AddFirstNotification(long cirDataId, long cirId, long sbuId, long countryIsoId, DateTime? commisioningDate, DateTime? failureDate, DateTime? editDate, string componentType, long turbineMatrixId, long manufacturerId, string editInitials, string siteName, string serialNumber)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                FirstNotification ec = new FirstNotification();
                ec.ComponentInspectionReportId = cirId;
                ec.SBUId = sbuId;
                ec.TurbineMatrixId = null;
                ec.CountryISOId = countryIsoId;
                ec.ComponentType = componentType;
                ec.CommisioningDate = commisioningDate;
                ec.FailureDate = failureDate;
                ec.EditDate = editDate;
                ec.QueuedOn = DateTime.Now;
                ec.SendOn = null;
                ec.ManufacturerID = manufacturerId;
                ec.SerialNo = serialNumber;
                ec.Sitename = siteName;
                ec.EditInitials = editInitials;
                ec.CirDataId = cirDataId;
                ec.SerialNo = serialNumber;
                ec.SendOn = DateTime.Now;
                context.FirstNotification.Add(ec);
                context.SaveChanges();
            }
        }

        public void AddSecondNotification(long cirDataId, long cirId, long cimCaseNumber, long sbuId, string componentType, long turbineMatrixId, long manufacturerId)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                SecondNotification ec = new SecondNotification();
                ec.CirDataId = cirDataId;
                ec.ComponentInspectionReportId = cirId;
                ec.SBUId = sbuId;
                ec.TurbineMatrixId = null;
                ec.ComponentType = componentType;
                ec.CIMCaseNumber = cimCaseNumber;
                ec.ManufacturerID = manufacturerId;
                ec.SendOn = DateTime.Now;
                context.SecondNotification.Add(ec);
                context.SaveChanges();
            }
        }

        public long AddRejectNotification(long cirId, long? sbuId, string filename, string email, string rejectedBy, string comment, long cimCaseNo)
        {
            long id = 0;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                RejectNotification ec = new RejectNotification();
                ec.InfoPathFilename = filename;
                ec.ComponentInspectionReportId = cirId;
                ec.SendOn = DateTime.Now;
                ec.SendTo = email;
                ec.RejectedBy = rejectedBy;
                ec.Comment = comment;
                ec.Received = System.DateTime.Now;
                ec.SBUId = sbuId;
                ec.CIMCaseNo = cimCaseNo;
                context.RejectNotification.Add(ec);
                context.SaveChanges();
                id = ec.RejectNotificationId;
            }
            return id;
        }

        public long AddSbuRejectNotification(long cirId, long? sbuId, string filename, long? cimCaseNo, string rejectedBy, string comment)
        {
            long id = 0;
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                SBURejectNotification ec = new SBURejectNotification();
                ec.InfoPathFilename = filename;
                ec.ComponentInspectionReportId = cirId;
                ec.SendOn = null;
                ec.SBUId = sbuId;
                ec.RejectedBy = rejectedBy;
                ec.Comment = comment;
                ec.CIMCaseNo = cimCaseNo;
                context.SBURejectNotification.Add(ec);
                context.SaveChanges();
                id = ec.SBURejectNotificationId;
            }
            return id;
        }

        public static void Archive(string mail, MailType type, DateTime date, long cirDataId)
        {

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                CirMailArchive entity = new CirMailArchive();
                entity = context.CirMailArchive.Where(x => x.CirDataId == cirDataId && x.Type == (short)type).FirstOrDefault();
                if (entity != null)
                {
                    entity.Deleted = true;
                    context.SaveChanges();

                }
                entity = new CirMailArchive();
                entity.Mail = mail;
                entity.Type = (short)type;
                entity.CirDataId = cirDataId;
                entity.Date = date;
                context.CirMailArchive.Add(entity);
                context.SaveChanges();

            }



        }

        public void SendNotifications(Notification.Notification notification)
        {

            if (notification == null)
            {
                return;
            }
            var mailArchiveController = new MailArchive();
            try
            {
                var mail = SendMail(notification);
                if (mail != null)
                {
                    mailArchiveController.Archive(mail, notification);
                }
            }
            catch (SmtpException smtpEx)
            {
                if (smtpEx.Message.Contains("4.7.0 Timeout"))
                {
                    string msg = string.Format("Could not send mail ({0}) to: {1} Error {2}", notification.GetType().Name, notification.ToEmailString(), smtpEx.Message);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", msg, LogType.Error, "");
                }
                else
                {
                    string msg = string.Format("Could not send mail ({0}) to: {1} Error {2}", notification.GetType().Name, notification.ToEmailString(), smtpEx.Message);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", msg, LogType.Error, "");
                    //EventLog _appLog = new EventLog(string.Format("Could not send mail ({0}) to: {1}", notification.GetType().Name, notification.ToEmailString()));
                    // _appLog.Source = "Notification Process";
                    // _appLog.WriteEntry(string.Format("Could not send mail ({0}) to: {1}", notification.GetType().Name, notification.ToEmailString()), EventLogEntryType.Error);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("Could not send mail ({0}) to: {1} Error {2}", notification.GetType().Name, notification.ToEmailString(), ex.Message);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", msg, LogType.Error, "");

            }

        }

        public MailMessage SendMail(Notification.Notification notification)
        {

            //Componenttype general doesn't send Firstnotifications

            MailMessage mm = new MailMessage();

            //Add From and reply-to email
            mm.From = new MailAddress(InboxEmail);
            mm.ReplyTo = new MailAddress(NotificationEmail);

            //Add to recipients
            if (notification.ToEMail.Count > 0)
            {
                foreach (MailAddress adr in notification.ToEMail)
                {
                    mm.To.Add(adr);
                }
            }

            //Add cc recipients
            if (notification.CCEMail.Count > 0)
            {
                foreach (MailAddress adr in notification.CCEMail)
                {
                    mm.CC.Add(adr);
                }
            }
            if (SentActualMails == "true")
            {

            }
            else//Ignore all Email Address in Dev and Test
            {
                mm.To.Clear();
                mm.To.Add(new MailAddress(InboxEmail));
                mm.CC.Clear();
                mm.CC.Add(new MailAddress(InboxEmail));

            }

            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", (SentActualMails == "true" ? " Mail Notification Setting : To: " + mm.To.ToString() + "  CC: " + mm.CC.ToString() : "DEV/TEST Enviroment: Mail Notification Setting : To: " + mm.To.ToString() + "  CC: " + mm.CC.ToString() + ""), LogType.Information, "");

            //Attachments on SecondNotification
            try
            {
                if (notification is SecondNotificationData && ((SecondNotificationData)notification).Attachment != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(((SecondNotificationData)notification).Attachment);
                    mm.Attachments.Add(new Attachment(stream, ((SecondNotificationData)notification).AttachmentName));
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Second Notification attachment is Found.!", LogType.Information, "");
                }
                else
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "No Attachment Found.!", LogType.Information, "");
                }

                //Add subject
                mm.Subject = notification.Subject();
                //Add environment type to subject for DEV and TEST           

                //Add Body
                mm.Body = notification.Body();

                //add html format on rejection mail 
                if (notification is RejectNotificationData && ((RejectNotificationData)notification).RejectedBy != " ")
                {
                    mm.IsBodyHtml = true;

                }


                // add message ID and delivery notification options (for tracking)
                mm.Headers.Add("Message-ID", notification.MessageId);
                mm.DeliveryNotificationOptions = notification.DeliveryNotification;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                // UseDefaultCredentials tells the mail client to use the 
                // Windows credentials of the account (i.e. user account) 
                // being used to run the application
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mm);
            }
            catch (Exception ex)
            {
                string msg = string.Format("Could not send mail ({0}) to: {1} Error {2}", notification.GetType().Name, notification.ToEmailString(), ex.Message);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Attachment Second Notifications" + msg, LogType.Error, "");

            }


            return mm;

        }

        public MailMessage SendMail(List<string> ToEmails, List<string> CCEmails, SendData data)
        {
            MailMessage mailmsg = new MailMessage();

            //Add From and reply-to email
            mailmsg.From = new MailAddress(InboxEmail);
            mailmsg.ReplyTo = new MailAddress(NotificationEmail);

            //Add to recipients
            if (ToEmails.Count > 0)
            {
                foreach (string adr in ToEmails)
                {
                    mailmsg.To.Add(adr);
                }
            }

            //Add cc recipients
            if (CCEmails.Count > 0)
            {
                foreach (string adr in CCEmails)
                {
                    mailmsg.CC.Add(adr);
                }
            }
            if (SentActualMails == "true")
            {

            }
            else//Ignore all Email Address in Dev and Test
            {
                mailmsg.To.Clear();
                mailmsg.To.Add(new MailAddress(InboxEmail));
                mailmsg.CC.Clear();
                mailmsg.CC.Add(new MailAddress(InboxEmail));

            }

            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", (SentActualMails == "true" ? " Mail Notification Setting : To: " + mailmsg.To.ToString() + "  CC: " + mailmsg.CC.ToString() : "DEV/TEST Enviroment: Mail Notification Setting : To: " + mailmsg.To.ToString() + "  CC: " + mailmsg.CC.ToString() + ""), LogType.Information, "");

            //Attachments on SecondNotification
            try
            {
                if (data.NotificationType == "SecondNotification" && data.Attachment.Length > 0)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Convert.FromBase64String(data.Attachment));
                    mailmsg.Attachments.Add(new Attachment(stream, data.AttachmentName));
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Second Notification attachment is Found.!", LogType.Information, "");
                }
                else
                {
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "No Attachment Found.!", LogType.Information, "");
                }

                //Add subject
                mailmsg.Subject = data.Subject;

                //Add Body
                mailmsg.Body = data.Body;

               // add html format on rejection mail
                if (data.NotificationType == "RejectNotification" && data.RejectedBy != "")
                {
                    mailmsg.IsBodyHtml = true;

                }


                // add message ID and delivery notification options (for tracking)
                mailmsg.Headers.Add("Message-ID", data.MessageId);
                mailmsg.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mailmsg);
            }
            catch (Exception ex)
            {
                string msg = string.Format("Could not send mail ({0}) to: {1} Error {2}", data.MessageId, ToEmails.ToString(), ex.Message);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Attachment Second Notifications" + msg, LogType.Error, "");

            }

            return mailmsg;

        }

        public SecondNotificationData SecondNotifications(long cirDataId, long cirID)
        {
            SecondNotificationData second = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                SecondNotification nEntity = context.SecondNotification.Where(x => x.CirDataId == cirDataId && x.ComponentInspectionReportId == cirID).FirstOrDefault();
                if (nEntity != null)
                {
                    try
                    {
                        CirData eCirData = context.CirData.Where(z => z.CirDataId == cirDataId).FirstOrDefault();
                        ComponentInspectionReport cirEntity = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cirID).FirstOrDefault();
                        PDF pdfEntity = null;
                        if (eCirData != null)
                            pdfEntity = context.PDF.Where(x => x.CIRTemplateGUID == eCirData.Guid && x.CIRState == (int)State.Approved).FirstOrDefault();
                        second = new SecondNotificationData(ref nEntity, ref pdfEntity);
                        second.Updated = true;
                        second.Turbine = cirEntity.TurbineNumber.ToString();
                        if (nEntity.ManufacturerID.HasValue)
                        {
                            switch (second.ComponentType)
                            {
                                case ComponentType.Blade:
                                    BladeManufacturer manu = context.BladeManufacturer.Where(x => x.BladeManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(manu.Email) && manu != null)
                                    {
                                        second = (SecondNotificationData)AddEmailAddresses(second, manu.Email, manu.Cc);
                                        second.Manufacturer = manu.Name;
                                        second.ManufacturerContactName = manu.EmailContactName;
                                    }


                                    break;
                                case ComponentType.Gearbox:
                                    GearboxManufacturer gear = context.GearboxManufacturer.Where(x => x.GearboxManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(gear.Email) && gear != null)
                                    {
                                        second = (SecondNotificationData)AddEmailAddresses(second, gear.Email, gear.Cc);
                                        second.Manufacturer = gear.Name;
                                        second.ManufacturerContactName = gear.EmailContactName;
                                    }

                                    break;
                                // HMM: Har slået disse 3 sammen, da det er samme code som anvendes for dem alle!
                                case ComponentType.General:
                                    //TODO: Implement
                                    // 3 stk samlet i HotItem: General, Skiipack, og mainBearing.
                                    HotItem hotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();

                                    if (!string.IsNullOrEmpty(hotItem.Email) && hotItem != null)
                                    {
                                        string hotlistEmail = hotItem.Email;


                                        if (!string.IsNullOrEmpty(hotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + hotItem.Cc;
                                        }
                                        // always send notification directly to the hotlist email
                                        second = (SecondNotificationData)AddEmailAddresses(second, hotlistEmail, string.Empty);
                                        second.Manufacturer = hotItem.ManufacturerName;
                                    }



                                    //  manu.ve 'manu.Name
                                    break;
                                // HMMNB: dette er en draft. se resultat og tilpas dernæst email (atributter som sættes)
                                case ComponentType.MainBearing:
                                    MainBearingManufacturer mainbear = context.MainBearingManufacturer.Where(x => x.MainBearingManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    HotItem mainbearhotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();

                                    if (mainbearhotItem == null)
                                    {
                                        //Try to fetch it as a main bearing hotitem

                                        if (mainbear != null)
                                        {
                                            second = (SecondNotificationData)AddEmailAddresses(second, HotlistEmail, String.Empty);
                                            second.Manufacturer = mainbear.Name;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(mainbearhotItem.Email) && mainbearhotItem != null)
                                    {
                                        string hotlistEmail = mainbearhotItem.Email;


                                        if (!string.IsNullOrEmpty(mainbearhotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + mainbearhotItem.Cc;
                                        }

                                        // always send notification directly to the hotlist email
                                        second = (SecondNotificationData)AddEmailAddresses(second, hotlistEmail, string.Empty);
                                        second.Manufacturer = mainbearhotItem.ManufacturerName;


                                    }

                                    break;
                                case ComponentType.Skiipack:
                                    HotItem skiihotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(skiihotItem.Email) && skiihotItem != null)
                                    {
                                        string hotlistEmail = skiihotItem.Email;


                                        if (!string.IsNullOrEmpty(skiihotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + skiihotItem.Cc;
                                        }

                                        // always send notification directly to the hotlist email
                                        second = (SecondNotificationData)AddEmailAddresses(second, hotlistEmail, string.Empty);
                                        second.Manufacturer = skiihotItem.ManufacturerName;

                                    }
                                    else
                                    {
                                        // as we have no Skiipack manufacturer we send the notification to the hotlist email with a dummy manufacturer name
                                        second = (SecondNotificationData)AddEmailAddresses(second, HotlistEmail, string.Empty);
                                        second.Manufacturer = "[INSERT MANUFACTURER HERE]";
                                    }
                                    break;
                                case ComponentType.Generator:
                                    GeneratorManufacturer gen = context.GeneratorManufacturer.Where(x => x.GeneratorManufacturerId == nEntity.ManufacturerID).FirstOrDefault();



                                    if (!string.IsNullOrEmpty(gen.Email) && gen != null)
                                    {
                                        //Turbine td = context.Turbine.Where(x => x.Turbine1 == second.Turbine).FirstOrDefault();
                                        TurbineData ttd = context.TurbineData.Where(x => x.TurbineId == second.Turbine).FirstOrDefault();
                                        if (ttd != null)
                                        {
                                            //TurbineData ttd = context.TurbineData.Where(x => x.TurbineId == td.TurbineId.ToString()).FirstOrDefault();

                                            if ((!(gen.Name.ToUpper() == "ABB") && !(gen.Name.ToUpper() == "LEROY SOMER")) || (Convert.ToInt64(ttd.NominalPower) < 1000 && gen.Name.ToUpper() == "ABB") || ((Convert.ToInt64(ttd.NominalPower) < 3000 && gen.Name.ToUpper() == "LEROY SOMER")))
                                            {

                                                second = (SecondNotificationData)AddEmailAddresses(second, gen.Email, gen.Cc);
                                                second.Manufacturer = gen.Name;
                                                second.ManufacturerContactName = gen.EmailContactName;
                                            }
                                            else if ((Convert.ToInt64(ttd.NominalPower) >= 1000 && gen.Name.ToUpper() == "ABB"))
                                            {
                                                //HACK: Notice! Hardcoded based on NominelPower and manufacturer ABB. If >= 1 MW Turbine then hardcoded email
                                                second.ToEmails.Add(new MailAddress(AbbMwEmail));
                                                second.Manufacturer = gen.Name;
                                                second.ManufacturerContactName = gen.EmailContactName;

                                            }
                                            else if ((Convert.ToInt64(ttd.NominalPower) == 3000 && gen.Name.ToUpper() == "LEROY SOMER"))
                                            {
                                                //HACK: Notice! Hardcoded based on NominelPower and manufacturer LEROY SOMER. If = 3 MW Turbine then hardcoded email
                                                second.ToEmails.Add(new MailAddress(LeroySomerMwEmail));
                                                second.Manufacturer = gen.Name;
                                                second.ManufacturerContactName = gen.EmailContactName;
                                            }

                                            DACIRLog.SaveCirLog(second.CirDataId, "Second Notification emailIDs added for GeneratorManufacturer=" + ttd.NominalPower, LogType.Information, "System");
                                        }

                                    }
                                    break;


                                case ComponentType.Transformer:
                                    TransformerManufacturer trans = context.TransformerManufacturer.Where(x => x.TransformerManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(trans.Email) && trans != null)
                                    {
                                        second = (SecondNotificationData)AddEmailAddresses(second, trans.Email, trans.Cc);
                                        second.Manufacturer = trans.Name;
                                        second.ManufacturerContactName = trans.EmailContactName;
                                    }

                                    break;
                                default:
                                    throw new ApplicationException("CIR ComponentType in template doesn't exists!");
                            }
                            second.CCEmails.Add(new MailAddress(SecondNotificationCcEmail));

                        }

                        DACIRLog.SaveCirLog(second.CirDataId, "Second Notification emailIDs" + second.CCEMail.Count + "  added for Manufacturer=" + second.ComponentType, LogType.Information, "System");

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("A database operation failed. Please try again.");
                    }





                }
            }

            return second;

        }

        public FirstNotificationData FirstNotifications(long cirDataId, long cirID)
        {
            FirstNotificationData first = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                FirstNotification nEntity = context.FirstNotification.Where(x => x.CirDataId == cirDataId && x.ComponentInspectionReportId == cirID).FirstOrDefault();
                if (nEntity != null)
                {
                    try
                    {

                        ComponentInspectionReport cirEntity = context.ComponentInspectionReport.Where(x => x.ComponentInspectionReportId == cirID).FirstOrDefault();
                        first = new FirstNotificationData(nEntity);
                        first.Turbine = cirEntity.TurbineNumber.ToString();
                        if (nEntity.ManufacturerID.HasValue)
                        {
                            switch (first.ComponentType)
                            {
                                case ComponentType.Blade:
                                    BladeManufacturer manu = context.BladeManufacturer.Where(x => x.BladeManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(manu.Email) && manu != null)
                                    {
                                        first = (FirstNotificationData)AddEmailAddresses(first, manu.Email, manu.Cc);
                                        first.Manufacturer = manu.Name;

                                    }
                                    break;
                                case ComponentType.Gearbox:
                                    GearboxManufacturer gear = context.GearboxManufacturer.Where(x => x.GearboxManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(gear.Email) && gear != null)
                                    {
                                        first = (FirstNotificationData)AddEmailAddresses(first, gear.Email, gear.Cc);
                                        first.Manufacturer = gear.Name;
                                    }

                                    break;
                                // HMM: Har slået disse 3 sammen, da det er samme code som anvendes for dem alle!
                                case ComponentType.General:
                                    //TODO: Implement
                                    // 3 stk samlet i HotItem: General, Skiipack, og mainBearing.
                                    HotItem hotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();

                                    if (!string.IsNullOrEmpty(hotItem.Email) && hotItem != null)
                                    {
                                        string hotlistEmail = hotItem.Email;
                                        if (!string.IsNullOrEmpty(hotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + hotItem.Cc;
                                        }
                                        // always send notification directly to the hotlist email
                                        first = (FirstNotificationData)AddEmailAddresses(first, hotlistEmail, string.Empty);
                                        first.Manufacturer = hotItem.ManufacturerName;
                                    }

                                    break;
                                // HMMNB: dette er en draft. se resultat og tilpas dernæst email (atributter som sættes)
                                case ComponentType.MainBearing:
                                    MainBearingManufacturer mainbear = context.MainBearingManufacturer.Where(x => x.MainBearingManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    HotItem mainbearhotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();

                                    if (mainbearhotItem == null)
                                    {
                                        if (mainbear != null)
                                        {
                                            first = (FirstNotificationData)AddEmailAddresses(first, HotlistEmail, String.Empty);
                                            first.Manufacturer = mainbear.Name;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(mainbearhotItem.Email) && mainbearhotItem != null)
                                    {
                                        string hotlistEmail = mainbearhotItem.Email;
                                        if (!string.IsNullOrEmpty(mainbearhotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + mainbearhotItem.Cc;
                                        }

                                        // always send notification directly to the hotlist email
                                        first = (FirstNotificationData)AddEmailAddresses(first, hotlistEmail, string.Empty);
                                        first.Manufacturer = mainbearhotItem.ManufacturerName;

                                    }

                                    break;
                                case ComponentType.Skiipack:
                                    HotItem skiihotItem = context.HotItem.Where(x => x.HotItemId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(skiihotItem.Email) && skiihotItem != null)
                                    {
                                        string hotlistEmail = skiihotItem.Email;
                                        if (!string.IsNullOrEmpty(skiihotItem.Cc))
                                        {
                                            hotlistEmail = hotlistEmail + ";" + skiihotItem.Cc;
                                        }

                                        // always send notification directly to the hotlist email
                                        first = (FirstNotificationData)AddEmailAddresses(first, hotlistEmail, string.Empty);
                                        first.Manufacturer = skiihotItem.ManufacturerName;
                                    }
                                    else
                                    {
                                        // as we have no Skiipack manufacturer we send the notification to the hotlist email with a dummy manufacturer name
                                        first = (FirstNotificationData)AddEmailAddresses(first, HotlistEmail, string.Empty);
                                        first.Manufacturer = "[INSERT MANUFACTURER HERE]";
                                    }
                                    break;
                                case ComponentType.Generator:
                                    GeneratorManufacturer gen = context.GeneratorManufacturer.Where(x => x.GeneratorManufacturerId == nEntity.ManufacturerID).FirstOrDefault();

                                    if (!string.IsNullOrEmpty(gen.Email) && gen != null)
                                    {
                                        Turbine td = context.Turbine.Where(x => x.Turbine1 == first.Turbine).FirstOrDefault();

                                        if (td != null)
                                        {
                                            TurbineData ttd = context.TurbineData.Where(x => x.TurbineId == td.TurbineId.ToString()).FirstOrDefault();

                                            if ((!(gen.Name.ToUpper() == "ABB") && !(gen.Name.ToUpper() == "LEROY SOMER")) || (Convert.ToInt64(ttd.NominalPower) < 1000 & gen.Name.ToUpper() == "ABB") || ((Convert.ToInt64(ttd.NominalPower) < 3000 && gen.Name.ToUpper() == "LEROY SOMER")))
                                            {

                                                first = (FirstNotificationData)AddEmailAddresses(first, gen.Email, gen.Cc);
                                                first.Manufacturer = gen.Name;

                                            }
                                            else if ((Convert.ToInt64(ttd.NominalPower) >= 1000 && gen.Name.ToUpper() == "ABB"))
                                            {
                                                //HACK: Notice! Hardcoded based on NominelPower and manufacturer ABB. If >= 1 MW Turbine then hardcoded email
                                                first.ToEmails.Add(new MailAddress(AbbMwEmail));
                                                first.Manufacturer = gen.Name;

                                            }
                                            else if ((Convert.ToInt64(ttd.NominalPower) == 3000 && gen.Name.ToUpper() == "LEROY SOMER"))
                                            {
                                                //HACK: Notice! Hardcoded based on NominelPower and manufacturer LEROY SOMER. If = 3 MW Turbine then hardcoded email
                                                first.ToEmails.Add(new MailAddress(LeroySomerMwEmail));
                                                first.Manufacturer = gen.Name;
                                            }
                                        }
                                    }



                                    break;


                                case ComponentType.Transformer:
                                    TransformerManufacturer trans = context.TransformerManufacturer.Where(x => x.TransformerManufacturerId == nEntity.ManufacturerID).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(trans.Email) && trans != null)
                                    {
                                        first = (FirstNotificationData)AddEmailAddresses(first, trans.Email, trans.Cc);
                                        first.Manufacturer = trans.Name;

                                    }

                                    break;
                                default:
                                    throw new ApplicationException("CIR ComponentType in template doesn't exists!");
                            }
                            first.CCEmails.Add(new MailAddress(FirstNotificationCcEmail));

                        }

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("A database operation failed. Please try again.");
                    }





                }
            }
            return first;

        }

        public RejectNotificationData RejectNotifications(long RejectNotificationID)
        {
            RejectNotificationData reject = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                RejectNotification nEntity = context.RejectNotification.Where(x => x.RejectNotificationId == RejectNotificationID).FirstOrDefault();
                reject = new RejectNotificationData(nEntity);
                return reject;
            }

        }

        public SBURejectNotificationData SBURejectNotifications(long SBURejectNotificationID)
        {
            SBURejectNotificationData sbureject = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                SBURejectNotification nEntity = context.SBURejectNotification.Where(x => x.SBURejectNotificationId == SBURejectNotificationID).FirstOrDefault();
                sbureject = new SBURejectNotificationData(nEntity);
                return sbureject;
            }

        }

        private Notification.Notification AddEmailAddresses(Notification.Notification notification, string toEmail, string ccEmail)
        {
            foreach (MailAddress address in SplitEmailAddresses(toEmail))
            {
                notification.ToEmails.Add(address);
            }
            foreach (MailAddress address in SplitEmailAddresses(ccEmail))
            {
                notification.CCEmails.Add(address);
            }
            return notification;
        }

        private List<MailAddress> SplitEmailAddresses(string emailAddresses)
        {
            List<MailAddress> addresses = new List<MailAddress>();
            if (!string.IsNullOrEmpty(emailAddresses))
            {
                foreach (string address in emailAddresses.Split(';'))
                {
                    if (!string.IsNullOrEmpty(address))
                    {
                        addresses.Add(new MailAddress(address));
                    }
                }
            }
            return addresses;
        }


        public String SendFeedbackMail(String Subject, String MailBody)
        {
            try
            {
                //Componenttype general doesn't send Firstnotifications

                MailMessage mm = new MailMessage();

                //Add From and reply-to email
                mm.From = new MailAddress(InboxEmail);

                mm.To.Add(FeedbackToEmail);

                //Add cc recipients
                //mm.CC.Add(InboxEmail);


                //Attachments on SecondNotification

                //System.IO.MemoryStream stream = new System.IO.MemoryStream(((SecondNotificationData)notification).Attachment);
                //mm.Attachments.Add(new Attachment(stream, ((SecondNotificationData)notification).AttachmentName));


                //Add subject
                mm.Subject = Subject;
                //Add environment type to subject for DEV and TEST           

                //Add Body
                mm.Body = MailBody;
                mm.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                // UseDefaultCredentials tells the mail client to use the 
                // Windows credentials of the account (i.e. user account) 
                // being used to run the application
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mm);
                return ("Mail Sent Successfully");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }



        }

        #region Notification Migration Code
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public static List<FirstNotificationDetails> GetNotifications()
        {
            List<FirstNotificationDetails> lstfirst = new List<FirstNotificationDetails>();
            SqlDataReader reader = null;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                objCon.Open();
                using (SqlCommand cmd = new SqlCommand("GetFirstNotificationList", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Year", YEAR));

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FirstNotificationDetails objFN = new FirstNotificationDetails();
                            CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                            objFN.FirstNotificationId = Convert.ToInt64(reader["FirstNotificationId"]);
                            objFN.ComponentInspectionReportId = Convert.ToInt64(reader["ComponentInspectionReportId"]);
                            if (reader["SendOn"] != DBNull.Value) objFN.SendOn = Convert.ToDateTime(reader["SendOn"]);
                            if (reader["SBUId"] != DBNull.Value) objFN.SBUId = Convert.ToInt64(reader["SBUId"]);
                            if (reader["EditDate"] != DBNull.Value) objFN.EditDate = Convert.ToDateTime(reader["EditDate"]);
                            if (reader["EditInitials"] != DBNull.Value) objFN.EditInitials = Convert.ToString(reader["EditInitials"]);
                            if (reader["TurbineMatrixId"] != DBNull.Value) objFN.TurbineMatrixId = Convert.ToInt64(reader["TurbineMatrixId"]);
                            if (reader["CirDataId"] != DBNull.Value) objFN.CirDataId = Convert.ToInt64(reader["CirDataId"]);
                            if (reader["Sitename"] != DBNull.Value) objFN.Sitename = Convert.ToString(reader["Sitename"]);
                            if (reader["CountryISOId"] != DBNull.Value) objFN.CountryISOId = Convert.ToInt64(reader["CountryISOId"]);
                            if (reader["ComponentType"] != DBNull.Value) objFN.ComponentType = Convert.ToString(reader["ComponentType"]);
                            if (reader["CommisioningDate"] != DBNull.Value) objFN.CommisioningDate = Convert.ToDateTime(reader["CommisioningDate"]);
                            if (reader["FailureDate"] != DBNull.Value) objFN.FailureDate = Convert.ToDateTime(reader["FailureDate"]);
                            if (reader["QueuedOn"] != DBNull.Value) objFN.QueuedOn = Convert.ToDateTime(reader["QueuedOn"]);
                            if (reader["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(reader["CirAttachmentId"]);
                            if (reader["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(reader["Filename"]);
                            if (reader["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])reader["BinaryData"];
                            objFN.cirAttachments = objAt;
                            lstfirst.Add(objFN);
                        }
                        reader.Close();
                        return lstfirst;
                    }


                }
            }


        }


        /// <summary>
        /// Save FN data details in cosmos db
        /// </summary>
        /// <param name="objFN"></param>
        /// <param name="fnDataDocumentId"></param>
        public static bool SaveFirstNotificationDataDetailstoCosmosDb(Cir.Sync.Services.Models.FirstNotificationDetails objFNDetails, string fnDataDocumentId)
        {
            bool flag = false;

            DataTable dtFN = new DataTable();
            int count = 0;
            int i = 0;
            FirstNotificationDetails objFN = null;

            try
            {
                using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
                {
                    objCon.Open();
                    using (SqlCommand cmd = new SqlCommand("GetFirstNotificationList", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Year", YEAR));
                        cmd.CommandTimeout = 180000;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtFN);
                            for (i = 0; i < dtFN.Rows.Count; i++)
                            {
                                objFN = new FirstNotificationDetails();
                                CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                                objFN.FirstNotificationId = Convert.ToInt64(dtFN.Rows[i]["FirstNotificationId"]);
                                objFN.ComponentInspectionReportId = Convert.ToInt64(dtFN.Rows[i]["ComponentInspectionReportId"]);
                                if (dtFN.Rows[i]["SendOn"] != DBNull.Value) objFN.SendOn = Convert.ToDateTime(dtFN.Rows[i]["SendOn"]);
                                if (dtFN.Rows[i]["SBUId"] != DBNull.Value) objFN.SBUId = Convert.ToInt64(dtFN.Rows[i]["SBUId"]);
                                if (dtFN.Rows[i]["EditDate"] != DBNull.Value) objFN.EditDate = Convert.ToDateTime(dtFN.Rows[i]["EditDate"]);
                                if (dtFN.Rows[i]["EditInitials"] != DBNull.Value) objFN.EditInitials = Convert.ToString(dtFN.Rows[i]["EditInitials"]);
                                if (dtFN.Rows[i]["TurbineMatrixId"] != DBNull.Value) objFN.TurbineMatrixId = Convert.ToInt64(dtFN.Rows[i]["TurbineMatrixId"]);
                                if (dtFN.Rows[i]["CirDataId"] != DBNull.Value) objFN.CirDataId = Convert.ToInt64(dtFN.Rows[i]["CirDataId"]);
                                if (dtFN.Rows[i]["Sitename"] != DBNull.Value) objFN.Sitename = Convert.ToString(dtFN.Rows[i]["Sitename"]);
                                if (dtFN.Rows[i]["CountryISOId"] != DBNull.Value) objFN.CountryISOId = Convert.ToInt64(dtFN.Rows[i]["CountryISOId"]);
                                if (dtFN.Rows[i]["ComponentType"] != DBNull.Value) objFN.ComponentType = Convert.ToString(dtFN.Rows[i]["ComponentType"]);
                                if (dtFN.Rows[i]["CommisioningDate"] != DBNull.Value) objFN.CommisioningDate = Convert.ToDateTime(dtFN.Rows[i]["CommisioningDate"]);
                                if (dtFN.Rows[i]["FailureDate"] != DBNull.Value) objFN.FailureDate = Convert.ToDateTime(dtFN.Rows[i]["FailureDate"]);
                                if (dtFN.Rows[i]["QueuedOn"] != DBNull.Value) objFN.QueuedOn = Convert.ToDateTime(dtFN.Rows[i]["QueuedOn"]);
                                if (dtFN.Rows[i]["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(dtFN.Rows[i]["CirAttachmentId"]);
                                if (dtFN.Rows[i]["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(dtFN.Rows[i]["Filename"]);
                                if (dtFN.Rows[i]["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])dtFN.Rows[i]["BinaryData"];
                                if (dtFN.Rows[i]["TurbineNumber"] != DBNull.Value) objFN.TurbineNumber = Convert.ToInt64(dtFN.Rows[i]["TurbineNumber"]);
                                objFN.cirAttachments = objAt;


                                //DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);

                                //var retObjFNDataDetails = _documentClient.CreateDocumentQuery<FirstNotificationDetails>(
                                //          UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                //           new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                //          .Where(x => x.FirstNotificationId == objFN.FirstNotificationId)
                                //          .AsEnumerable().FirstOrDefault();










                                string FNDataUri = string.Empty;
                                Uri urlWordByteUrl = null;
                                //if (retObjFNDataDetails != null)
                                //{
                                //    fnDataDocumentId = Convert.ToString(retObjFNDataDetails.FirstNotificationId);
                                //    urlWordByteUrl = retObjFNDataDetails.WordBytesUrl;
                                //    if (urlWordByteUrl != null)
                                //        FNDataUri = Convert.ToString(urlWordByteUrl.AbsoluteUri) ?? default(string);
                                //}

                                // if (objFN.cirAttachments.BinaryData != null && urlWordByteUrl == null)
                                //string string1 = "My Secret Data!";
                                //byte[] byteArr = System.Text.Encoding.ASCII.GetBytes(string1);
                                //objFN.cirAttachments.BinaryData = byteArr;
                                // objFN.WordBytesUrl = SaveWordBytestoBlob(objFN.cirAttachments.BinaryData, FNDataUri, Convert.ToString(objFN.TurbineNumber), objFN.cirAttachments.Filename, "FN");
                                objFN.WordBytesUrl = SaveWordBytestoBlobforFirstNotification(objFN.cirAttachments.BinaryData, FNDataUri, "FN", objFN);
                                //objFN.cirAttachments.BinaryData = null;
                                //if (string.IsNullOrEmpty(fnDataDocumentId))                                   
                                //    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), objFN).ConfigureAwait(false);
                                //else
                                //    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, fnDataDocumentId), objFN).ConfigureAwait(false);

                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveFirstNotificationDataDetailstoCosmosDb for  FirstNotification Id: " + objFN.FirstNotificationId, LogType.Information, "");
                            }

                            flag = true;
                        }
                    }

                }

            }
            catch (Exception Ex)
            {
                var aa = count;
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveFirstNotificationDataDetailstoCosmosDb for  FirstNotification Id: " + objFN.FirstNotificationId + "    " + Ex.Message, LogType.Information, "");
                return flag = false;
            }
            finally
            {

            }
            return flag;
        }


        /// <summary>
        /// save word bytes to blob
        /// </summary>
        /// <param name="wordBytes"></param>
        /// <param name="FNDataUri"></param>
        /// <param name="turbineNumber"></param>
        /// <returns></returns>
        public static Uri SaveWordBytestoBlobforFirstNotification(byte[] wordBytes, string FNDataUri, string dataType, FirstNotificationDetails objFN)
        {

            CloudBlobClient blobClient;
            CloudBlobContainer container;
            CloudBlockBlob binaryDataBlockBlob = null;
            try
            {
                string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
                var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(containerName);
                //container.CreateIfNotExists();
                string blobId = string.Empty;
                string directoryName = string.Empty;
                string blobType = "FirstNotification", contentType = "json";

                blobId = GetKey(container);
                directoryName = $"{Convert.ToString(objFN.TurbineNumber)}/{dataType}/{blobId}";

                var binaryDataFileName = $"{Convert.ToString(objFN.TurbineNumber)}/{dataType}/{blobId}.{contentType}";

                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(binaryDataFileName, "CreateBlob"));

                if (!binaryDataBlockBlob.Exists())
                {
                    //  For Json Code 
                    objFN.Id = blobId;
                    binaryDataBlockBlob.Properties.ContentType = "";
                    using (var ms = new MemoryStream())
                    {
                        var json = JsonConvert.SerializeObject(objFN);
                        StreamWriter writer = new StreamWriter(ms);
                        writer.Write(json);
                        writer.Flush();
                        ms.Position = 0;
                        binaryDataBlockBlob.UploadFromStream(ms);
                    }
                }
                //End Of Json
                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(directoryName, "CreateBlob"));
                if (!binaryDataBlockBlob.Exists())
                {
                    binaryDataBlockBlob.Properties.ContentType = "application/pdf";
                    if (wordBytes != null)
                        binaryDataBlockBlob.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
                }
            }
            catch (Exception Ex)
            {
                //   return binaryDataBlockBlob.Uri;
            }
            return binaryDataBlockBlob.Uri;
        }

        public void LoadStreamWithJsonforFirstNotification(Stream ms, FirstNotificationDetails objFN)
        {
            var json = JsonConvert.SerializeObject(objFN);
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
        }

        public static Uri SaveWordBytestoBlobforSecondNotification(byte[] wordBytes, string NDataUri, string dataType, SecondNotificationDetails objSN)
        {

            CloudBlobClient blobClient;
            CloudBlobContainer container;
            CloudBlockBlob binaryDataBlockBlob = null;
            try
            {
                string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
                var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(containerName);
                //container.CreateIfNotExists();
                string blobId = string.Empty;
                string directoryName = string.Empty;
                string contentType = "json";

                blobId = GetKey(container);
                directoryName = $"{Convert.ToString(objSN.TurbineNumber)}/{dataType}/{blobId}";


                var binaryDataFileName = $"{Convert.ToString(objSN.TurbineNumber)}/{dataType}/{blobId}.{contentType}";

                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(binaryDataFileName, "CreateBlob"));

                if (!binaryDataBlockBlob.Exists())
                {
                    //  For Json Code 
                    objSN.Id = blobId;
                    binaryDataBlockBlob.Properties.ContentType = "";
                    using (var ms = new MemoryStream())
                    {
                        var json = JsonConvert.SerializeObject(objSN);
                        StreamWriter writer = new StreamWriter(ms);
                        writer.Write(json);
                        writer.Flush();
                        ms.Position = 0;
                        binaryDataBlockBlob.UploadFromStream(ms);
                    }
                }
                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(directoryName, "CreateBlob"));
                if (!binaryDataBlockBlob.Exists())
                {
                    binaryDataBlockBlob.Properties.ContentType = "application/pdf";
                    if (wordBytes != null)
                        binaryDataBlockBlob.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
                }
            }
            catch (Exception Ex)
            {
                //   return binaryDataBlockBlob.Uri;
            }
            return binaryDataBlockBlob.Uri;
        }

        public static Uri SaveWordBytestoBlobforRejectNotification(byte[] wordBytes, string NDataUri, string dataType, Cir.Sync.Services.Models.RejectNotificationDetails objRN)
        {

            CloudBlobClient blobClient;
            CloudBlobContainer container;
            CloudBlockBlob binaryDataBlockBlob = null;
            try
            {
                string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
                var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(containerName);
                //container.CreateIfNotExists();
                string blobId = string.Empty;
                string directoryName = string.Empty, contentType="json";

                blobId = GetKey(container);
                directoryName = $"{Convert.ToString(objRN.TurbineNumber)}/{dataType}/{blobId}";

                var binaryDataFileName = $"{Convert.ToString(objRN.TurbineNumber)}/{dataType}/{blobId}.{contentType}";

                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(binaryDataFileName, "CreateBlob"));

                if (!binaryDataBlockBlob.Exists())
                {
                    //  For Json Code 
                    objRN.Id = blobId;
                    binaryDataBlockBlob.Properties.ContentType = "";
                    using (var ms = new MemoryStream())
                    {
                        var json = JsonConvert.SerializeObject(objRN);
                        StreamWriter writer = new StreamWriter(ms);
                        writer.Write(json);
                        writer.Flush();
                        ms.Position = 0;
                        binaryDataBlockBlob.UploadFromStream(ms);
                    }
                }




                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(directoryName, "CreateBlob"));
                if (!binaryDataBlockBlob.Exists())
                {
                    binaryDataBlockBlob.Properties.ContentType = "application/pdf";

                    if (wordBytes != null)
                        binaryDataBlockBlob.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
                }
            }
            catch (Exception Ex)
            {
                //   return binaryDataBlockBlob.Uri;
            }
            return binaryDataBlockBlob.Uri;
        }

        public static Uri SaveWordBytestoBlob(byte[] wordBytes, string FNDataUri, string turbineNumber, string fileName, string dataType)
        {

            CloudBlobClient blobClient;
            CloudBlobContainer container;
            CloudBlockBlob binaryDataBlockBlob = null;
            try
            {
                string containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
                var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference(containerName);
                //container.CreateIfNotExists();
                string blobId = string.Empty;
                string directoryName = string.Empty;
                if (string.IsNullOrEmpty(FNDataUri))
                {
                    blobId = GetKey(container);
                    directoryName = $"{turbineNumber}/{dataType}/{blobId}";
                }
                else
                {
                    CloudBlockBlob Blob = new CloudBlockBlob(new Uri(FNDataUri));
                    //  blobId = Blob.Name;
                    directoryName = Blob.Name;

                }

                binaryDataBlockBlob = new CloudBlockBlob(GetBlobSASUri(directoryName, "CreateBlob"));
                if (!binaryDataBlockBlob.Exists())
                {
                    binaryDataBlockBlob.Properties.ContentType = "application/pdf";
                    // binaryDataBlockBlob.Metadata.Add("fileName", fileName);
                    binaryDataBlockBlob.UploadFromByteArray(wordBytes, 0, wordBytes.Length);
                }
            }
            catch (Exception Ex)
            {
                //   return binaryDataBlockBlob.Uri;
            }
            return binaryDataBlockBlob.Uri;
        }

        public static List<SecondNotificationDetails> GetSecondNotificationList()
        {
            List<SecondNotificationDetails> lstSecond = new List<SecondNotificationDetails>();

            SqlDataReader reader = null;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                objCon.Open();
                using (SqlCommand cmd = new SqlCommand("GetSecondNotificationList", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Year", YEAR));

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SecondNotificationDetails objSN = new SecondNotificationDetails();
                            CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                            objSN.SecondNotificationId = Convert.ToInt64(reader["SecondNotificationId"]);
                            objSN.ComponentInspectionReportId = Convert.ToInt64(reader["ComponentInspectionReportId"]);
                            if (reader["SendOn"] != DBNull.Value) objSN.SendOn = Convert.ToDateTime(reader["SendOn"]);
                            if (reader["ManufacturerID"] != DBNull.Value) objSN.ManufacturerId = Convert.ToInt64(reader["ManufacturerID"]);
                            if (reader["SBUId"] != DBNull.Value) objSN.SBUId = Convert.ToInt64(reader["SBUId"]);
                            if (reader["ComponentType"] != DBNull.Value) objSN.ComponentType = Convert.ToString(reader["ComponentType"]);
                            if (reader["CIRTemplate"] != DBNull.Value) objSN.CIRTemplate = (byte[])reader["CIRTemplate"];
                            if (reader["CIMCaseNumber"] != DBNull.Value) objSN.CIMCaseNumber = Convert.ToInt64(reader["CIMCaseNumber"]);
                            if (reader["TurbineMatrixId"] != DBNull.Value) objSN.TurbineNumber = Convert.ToInt64(reader["TurbineMatrixId"]);
                            if (reader["CirDataId"] != DBNull.Value) objSN.CirDataId = Convert.ToInt64(reader["CirDataId"]);
                            if (reader["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(reader["CirAttachmentId"]);
                            if (reader["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(reader["Filename"]);
                            if (reader["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])reader["BinaryData"];

                            objSN.cirAttachments = objAt;
                            lstSecond.Add(objSN);
                        }
                        reader.Close();
                        return lstSecond;
                    }


                }
            }



        }


        /// <summary>
        /// Save SN data details in cosmos db
        /// </summary>
        /// <param name="objFN"></param>
        /// <param name="fnDataDocumentId"></param>
        public static bool SaveSecondNotificationDataDetailstoCosmosDb(SecondNotificationDetails objSNDetails, string fnDataDocumentId)
        {
            bool flag = false;
            SecondNotificationDetails objSN = null;
            // objSNDetails = null; Set to Null
            try
            {
                //if (objSNDetails == null)
                //{
                SqlDataReader reader = null;
                using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
                {
                    objCon.Open();
                    using (SqlCommand cmd = new SqlCommand("GetSecondNotificationList", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Year", YEAR));

                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objSN = new SecondNotificationDetails();
                                CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                                objSN.SecondNotificationId = Convert.ToInt64(reader["SecondNotificationId"]);
                                objSN.ComponentInspectionReportId = Convert.ToInt64(reader["ComponentInspectionReportId"]);
                                if (reader["SendOn"] != DBNull.Value) objSN.SendOn = Convert.ToDateTime(reader["SendOn"]);
                                if (reader["ManufacturerID"] != DBNull.Value) objSN.ManufacturerId = Convert.ToInt64(reader["ManufacturerID"]);
                                if (reader["SBUId"] != DBNull.Value) objSN.SBUId = Convert.ToInt64(reader["SBUId"]);
                                if (reader["ComponentType"] != DBNull.Value) objSN.ComponentType = Convert.ToString(reader["ComponentType"]);
                                if (reader["CIRTemplate"] != DBNull.Value) objSN.CIRTemplate = (byte[])reader["CIRTemplate"];
                                if (reader["CIMCaseNumber"] != DBNull.Value) objSN.CIMCaseNumber = Convert.ToInt64(reader["CIMCaseNumber"]);
                                if (reader["TurbineMatrixId"] != DBNull.Value) objSN.TurbineMatrixId = Convert.ToInt64(reader["TurbineMatrixId"]);
                                if (reader["TurbineNumber"] != DBNull.Value) objSN.TurbineNumber = Convert.ToInt64(reader["TurbineNumber"]);
                                if (reader["CirDataId"] != DBNull.Value) objSN.CirDataId = Convert.ToInt64(reader["CirDataId"]);
                                if (reader["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(reader["CirAttachmentId"]);
                                if (reader["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(reader["Filename"]);
                                if (reader["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])reader["BinaryData"];

                                objSN.cirAttachments = objAt;

                                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);

                                var retObjSNDataDetails = _documentClient.CreateDocumentQuery<SecondNotificationDetails>(
                                          UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                           new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                          .Where(x => x.SecondNotificationId == objSN.SecondNotificationId)
                                          .AsEnumerable().FirstOrDefault();

                                string SNDataUri = string.Empty;
                                Uri urlWordByteUrl = null;
                                if (retObjSNDataDetails != null)
                                {
                                    fnDataDocumentId = Convert.ToString(retObjSNDataDetails.SecondNotificationId);
                                    urlWordByteUrl = retObjSNDataDetails.WordBytesUrl;
                                    if (urlWordByteUrl != null)
                                        SNDataUri = Convert.ToString(urlWordByteUrl.AbsoluteUri) ?? default(string);
                                }

                                if (objSN.cirAttachments.BinaryData != null && urlWordByteUrl == null)
                                    objSN.WordBytesUrl = SaveWordBytestoBlobforSecondNotification(objSN.cirAttachments.BinaryData, SNDataUri, "SN", objSN);

                                if (string.IsNullOrEmpty(fnDataDocumentId))
                                    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), objSN).ConfigureAwait(false);
                                else
                                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, fnDataDocumentId), objSN).ConfigureAwait(false);
                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveFirstNotificationDataDetailstoCosmosDb for  FirstNotification Id: " + objSN.SecondNotificationId, LogType.Information, "");
                            }
                            reader.Close();
                            flag = true;
                        }


                    }
                }


                // }
            }
            catch (Exception Ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveFirstNotificationDataDetailstoCosmosDb for  FirstNotification Id: " + objSN.SecondNotificationId + "    " + Ex.Message, LogType.Information, "");
                return flag = false;
            }
            return flag;

        }


        public static List<RejectNotificationDetails> GetRejectNotificationList()
        {
            List<RejectNotificationDetails> lstReject = new List<RejectNotificationDetails>();

            SqlDataReader reader = null;
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                objCon.Open();
                using (SqlCommand cmd = new SqlCommand("GetRejectNotificationList", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Year", YEAR));

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RejectNotificationDetails objRN = new RejectNotificationDetails();
                            CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                            objRN.RejectNotificationId = Convert.ToInt64(reader["RejectNotificationId"]);
                            objRN.ComponentInspectionReportId = Convert.ToInt64(reader["ComponentInspectionReportId"]);
                            if (reader["SendOn"] != DBNull.Value) objRN.SendOn = Convert.ToDateTime(reader["SendOn"]);
                            if (reader["InfoPathFilename"] != DBNull.Value) objRN.InfoPathFilename = Convert.ToString(reader["InfoPathFilename"]);
                            if (reader["SendTo"] != DBNull.Value) objRN.SendTo = Convert.ToString(reader["SendTo"]);
                            if (reader["RejectedBy"] != DBNull.Value) objRN.RejectedBy = Convert.ToString(reader["RejectedBy"]);
                            if (reader["Comment"] != DBNull.Value) objRN.Comment = Convert.ToString(reader["Comment"]);
                            if (reader["Received"] != DBNull.Value) objRN.Received = Convert.ToDateTime(reader["Received"]);
                            if (reader["SBUId"] != DBNull.Value) objRN.SBUId = Convert.ToInt64(reader["SBUId"]);
                            if (reader["CIMCaseNo"] != DBNull.Value) objRN.CIMCaseNo = Convert.ToInt64(reader["CIMCaseNo"]);
                            if (reader["TurbineNumber"] != DBNull.Value) objRN.TurbineNumber = Convert.ToInt64(reader["TurbineNumber"]);
                            if (reader["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(reader["CirAttachmentId"]);
                            if (reader["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(reader["Filename"]);
                            if (reader["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])reader["BinaryData"];
                            objRN.cirAttachments = objAt;
                            lstReject.Add(objRN);
                        }
                        reader.Close();
                        return lstReject;
                    }


                }
            }
        }


        /// <summary>
        /// Save SN data details in cosmos db
        /// </summary>
        /// <param name="objFN"></param>
        /// <param name="fnDataDocumentId"></param>
        public static bool SaveRejectNotificationDataDetailstoCosmosDb(RejectNotificationDetails objRNDetails, string fnDataDocumentId)
        {

            bool retFlag = false;
            string message = "rejectNotificationMigration.SaveRejectNotificationDataDetailstoCosmosDb()";
            MigrationStepLogging objMigrationStepLogging = null;
            RejectNotificationDetails objRN = null;
            try
            {
                //if (objRNDetails == null)
                //{
                SqlDataReader reader = null;


                using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
                {
                    objCon.Open();
                    using (SqlCommand cmd = new SqlCommand("GetRejectNotificationList", objCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Year", YEAR));

                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objRN = new RejectNotificationDetails();
                                CirAttachmentsDetails objAt = new CirAttachmentsDetails();
                                objRN.RejectNotificationId = Convert.ToInt64(reader["RejectNotificationId"]);
                                objRN.ComponentInspectionReportId = Convert.ToInt64(reader["ComponentInspectionReportId"]);
                                if (reader["SendOn"] != DBNull.Value) objRN.SendOn = Convert.ToDateTime(reader["SendOn"]);
                                if (reader["InfoPathFilename"] != DBNull.Value) objRN.InfoPathFilename = Convert.ToString(reader["InfoPathFilename"]);
                                if (reader["SendTo"] != DBNull.Value) objRN.SendTo = Convert.ToString(reader["SendTo"]);
                                if (reader["RejectedBy"] != DBNull.Value) objRN.RejectedBy = Convert.ToString(reader["RejectedBy"]);
                                if (reader["Comment"] != DBNull.Value) objRN.Comment = Convert.ToString(reader["Comment"]);
                                if (reader["Received"] != DBNull.Value) objRN.Received = Convert.ToDateTime(reader["Received"]);
                                if (reader["SBUId"] != DBNull.Value) objRN.SBUId = Convert.ToInt64(reader["SBUId"]);
                                if (reader["CIMCaseNo"] != DBNull.Value) objRN.CIMCaseNo = Convert.ToInt64(reader["CIMCaseNo"]);
                                if (reader["TurbineNumber"] != DBNull.Value) objRN.TurbineNumber = Convert.ToInt64(reader["TurbineNumber"]);
                                if (reader["CirAttachmentId"] != DBNull.Value) objAt.CirAttachmentId = Convert.ToInt64(reader["CirAttachmentId"]);
                                if (reader["Filename"] != DBNull.Value) objAt.Filename = Convert.ToString(reader["Filename"]);
                                if (reader["BinaryData"] != DBNull.Value) objAt.BinaryData = (byte[])reader["BinaryData"];
                                objRN.cirAttachments = objAt;

                                DocumentClient _documentClient = new DocumentClient(new Uri(endPointURI), primaryKey);

                                var retObjRNDataDetails = _documentClient.CreateDocumentQuery<RejectNotificationDetails>(
                                          UriFactory.CreateDocumentCollectionUri(databaseId, collectionName),
                                           new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                                          .Where(x => x.RejectNotificationId == objRN.RejectNotificationId)
                                          .AsEnumerable().FirstOrDefault();

                                string RNDataUri = string.Empty;
                                Uri urlWordByteUrl = null;
                                if (retObjRNDataDetails != null)
                                {
                                    fnDataDocumentId = Convert.ToString(retObjRNDataDetails.RejectNotificationId);
                                    urlWordByteUrl = retObjRNDataDetails.WordBytesUrl;
                                    if (urlWordByteUrl != null)
                                        RNDataUri = Convert.ToString(urlWordByteUrl.AbsoluteUri) ?? default(string);
                                }

                                if (objRN.cirAttachments.BinaryData != null && urlWordByteUrl == null)
                                    objRN.WordBytesUrl = SaveWordBytestoBlobforRejectNotification(objRN.cirAttachments.BinaryData, RNDataUri, "RN", objRN);

                                if (string.IsNullOrEmpty(fnDataDocumentId))
                                    _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionName), objRN).ConfigureAwait(false);
                                else
                                    _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionName, fnDataDocumentId), objRN).ConfigureAwait(false);

                                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveRejectNotificationDataDetailstoCosmosDb for  RejectNotification Id: " + objRN.RejectNotificationId, LogType.Information, "");


                            }
                            reader.Close();
                            retFlag = true;
                        }


                    }
                }


                //  }


            }
            catch (Exception ex)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "SaveRejectNotificationDataDetailstoCosmosDb for  RejectNotification Id: " + objRN.RejectNotificationId + "  " + ex.Message, LogType.Information, "");
                return retFlag = false;
            }
            return retFlag;
        }











        /// <summary>
        /// Get key
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static string GetKey(CloudBlobContainer container)
        {
            string key = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = new CloudBlockBlob(GetBlobSASUri(key, "CreateBlob"));
            return (!blockBlob.Exists()) ? key : GetKey(container);
        }

        /// <summary>
        /// get blob as uri
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static Uri GetBlobSASUri(string blobName, string policyName)
        {
            CloudBlobClient blobClient;
            CloudBlobContainer container;

            string containerName = string.Empty;
            containerName = System.Configuration.ConfigurationManager.AppSettings["AzureStorageImgContainerName"];
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
            //container.CreateIfNotExists();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            var storedPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Delete
            };
            var permissions = container.GetPermissions();
            permissions.SharedAccessPolicies.Clear();
            permissions.SharedAccessPolicies.Add(policyName, storedPolicy);
            container.SetPermissions(permissions);
            var sasBlobToken = blockBlob.GetSharedAccessSignature(null, policyName);
            Uri blobUri = new Uri(blockBlob.Uri + sasBlobToken);
            return blobUri;

        }






        #endregion

    }
}