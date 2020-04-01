using Cir.Common.MailArchive;
using Cir.Sync.Services.Models;
using Cir.Sync.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Cir.Sync.Services.DAL
{
    public static class DACirNotifications
    {
        public static void SendNotificationMails(List<string> ToEmails, List<string> CCEmails, SendData data)
        {
            DANotification da = new DANotification();
            MailMessage mail = da.SendMail(ToEmails , CCEmails ,data);
            if (mail != null)
            {
                MailType mailtype = (MailType)Enum.Parse(typeof(MailType), data.NotificationType);
                DAL.DANotification.Archive("Sent To : [" + GetEmailString(ToEmails) + "] CC : [" + GetEmailString(CCEmails) + "] Send On : [" + DateTime.Now.ToShortDateString() + "] Body : [" + mail.Body + "]", mailtype, DateTime.Now, data.CirId);
            }
           
        }

        public static void SendMail(string cirName, long cirId, string CurrentUser,int type)
        {
            DASendCIRUpdateNotification das = new DASendCIRUpdateNotification();
            das.SendMail(cirId, cirName, CurrentUser, type);
        }

        private static string GetEmailString(List<string> emails)
        {
            string email = "";
            if (emails.Count > 0)
            {
                foreach (var adr in emails)
                {
                    email = email + adr + ";";
                }
            }
            return email;
        }
    }

    public class SendData

    {       
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MessageId { get; set; }
        public long CirId { get; set; }
        public string NotificationType { get; set; }
        public string AttachmentName { get; set; }
        public string Attachment { get; set; }
        public bool Updated { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
        public string RejectedBy { get; set; }
    }
}