using Cir.Sync.Services.DAL;
using Cir.Sync.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCirNotifications
    {
        public static void SendMail(string cirName, long cirId, string CurrentUser,int type)
        {
            DAL.DACirNotifications.SendMail(cirName, cirId, CurrentUser, type);
        }

        public static void SendNotificationMails(List<string> ToEmails, List<string> CCEmails, SendData data)
        {
            DAL.DACirNotifications.SendNotificationMails(ToEmails, CCEmails, data);
        }

        public static void SendMail(string ToEmail, string CcEmail, string body, string subject)
        {
            DASendCIRUpdateNotification das = new DASendCIRUpdateNotification();
            das.SendMail(ToEmail, CcEmail, body, subject);
        }

    }
}