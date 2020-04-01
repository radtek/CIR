using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Enumerations
{
    public class NotificationEnumerations
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
            RejectNotification =2,
            SBUNotification = 3,
        }

        public enum SbuNotificationType
        {
            Notification = 0,
            Warning = 1,
        }
    }
}
