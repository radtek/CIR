using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using System.Net.Mail;
using Cir.Sync.Services.Notification;
using Cir.Common.MailArchive;
using Cir.Sync.Services.ErrorHandling;
using System.Configuration;

namespace Cir.Sync.Services.DAL
{
    public class DASendCIRUpdateNotification
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
        public string SentActualMails = System.Configuration.ConfigurationManager.AppSettings["SentActualMails"];
        public string NotificationEmail = System.Configuration.ConfigurationManager.AppSettings["NotificationEmail"];

        public MailMessage SendMail(long CirId, string CirName, string ToEmail, int Type)
        {
            MailMessage mm = new MailMessage();
            try
            {
                
                string ToEmail1 = string.Empty;
                mm.From = new MailAddress("CIR@partnernet.vestas.com");
                if (ToEmail.Contains('@'))
                {
                    mm.To.Add(ToEmail);
                }

                else
                {
                    ToEmail1 = ToEmail + "@vestas.com";
                    mm.To.Add(ToEmail1);
                }

                //Add subject
                mm.Subject = (Type == 1 ? "CIR Creation Notification" : "CIR Update Notification");


                //Add Body
                // CIR with CIR ID: <CirId> and Name : <CirName> has beed created or updated.
                string b = "";
                if(Type == 1)
                {
                 b = @"CIR with CIR ID: " + (CirId) + " - Name :" + CirName +  " <br>" + 
                     "This message is generated to notify you that a new Component Inspection Report has been registered in your name and submitted successfully." +  " <br>" +  " <br>" + 
                     "Yours sincerely" +  " <br>" + 
                     "Vestas Wind System A/S";
                }
                else
                {
                    b = @"CIR with CIR ID: " + (CirId) + " - Name :" + CirName +  " <br>" + 
                     "This message is generated to notify you that an existing Component Inspection Report has been registered in your name and submitted successfully." +  " <br>" +  " <br>" + 
                     "Yours sincerely" +  " <br>" + 
                     "Vestas Wind System A/S";
                }
                mm.Body = b;
               
                mm.IsBodyHtml = true;
                mm.Headers.Add("Message-ID", System.Guid.NewGuid().ToString());


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                // UseDefaultCredentials tells the mail client to use the 
                // Windows credentials of the account (i.e. user account) 
                // being used to run the application
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mm);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "CIR Creation/Updatation Notification sent to " + ToEmail + " [CIR ID = " + (CirId) + " ]", LogType.Information, "");
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : exstr;

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Email to user after updating new CIR " + "\n  Inner Exception : " + innerstr, LogType.Error, "");
                DACIRLog.SaveCirLog(CirId, "Unable to send Email to user after updating new CIR ", LogType.Information, ToEmail);
            }


            return mm;
        }


        public void SendMail(string ToEmail, string CcEmail, string body, string subject)
        {
            MailMessage mm = new MailMessage();
            try
            {

                string ToEmail1 = string.Empty;
                mm.From = new MailAddress("CIR@partnernet.vestas.com");
                if (ToEmail.Contains('@'))
                {
                    mm.To.Add(ToEmail);
                }

                else
                {
                    ToEmail1 = ToEmail + "@vestas.com";
                    mm.To.Add(ToEmail1);
                }

                //Add subject
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                mm.Headers.Add("Message-ID", System.Guid.NewGuid().ToString());

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                // UseDefaultCredentials tells the mail client to use the 
                // Windows credentials of the account (i.e. user account) 
                // being used to run the application
                smtp.UseDefaultCredentials = true;
                smtp.Host = SMTPHost;
                //Send mail
                smtp.Send(mm);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Mail sent to " + ToEmail, LogType.Information, "");
            }
            catch (Exception oException)
            {

                string exstr = (oException != null) ? oException.Message + "\n Details : " + oException.StackTrace : "";
                string innerstr = (oException.InnerException != null) ? oException.InnerException.Message + "\n Details : " + oException.InnerException.StackTrace : exstr;

                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error sending Email to user " + "\n  Inner Exception : " + innerstr, LogType.Error, "");

            }           
        }
    }
}