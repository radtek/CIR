using Cir.Common.MailArchive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Cir.Common.Utilities;
using System.IO;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services.Notification
{
    public class MailArchive
    {
        public void Archive(MailMessage mail, Notification notification)
        {
            // sanity check parameters
            if (mail == null || notification == null)
            {
                return;
            }

            var type = MailType.None;
            if (notification is FirstNotificationData)
            {
                type = MailType.FirstNotification;
            }
            else if (notification is SecondNotificationData)
            {
                type = MailType.SecondNotification;
            }

            if (type == MailType.None)
            {
                return;
            }
           // var eml = Mail.GenerateEml(mail);
            //var emlReader = new StreamReader(eml);
            //var emlContent = emlReader.ReadToEnd();
            //emlReader.Close();
            //eml.Close();

            Archive("Sent To : [" + notification.ToEmailString() + "] CC : [" + notification.CCEmailString() + "] Send On : [" + DateTime.Now.ToShortDateString() + "] Body : [" + mail.Body + "]", type, notification.CirDataId);
        }

        public void Archive(string mail, MailType type, long cirDataId)
        {            
                DAL.DANotification.Archive(mail, type, DateTime.Now, cirDataId);
        }
    }
}