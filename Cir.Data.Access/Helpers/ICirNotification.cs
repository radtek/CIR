using Cir.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cir.Data.Access.Enumerations.Enumeration;
using static Cir.Data.Access.Enumerations.NotificationEnumerations;

namespace Cir.Data.Access.Helpers
{
    public interface ICirNotification
    {
        void SendNotificationMail(CirSubmissionData submissionData, NotificationType notificationType, string currentUser = null, string comment = null);
         void SendMail(CirSubmissionData submissionData, string userName, CirMode type);
    }
}
