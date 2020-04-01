using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Notification
{
    public static class SBURejectNotificationData
    {
        public static string Subject()
        {
            return "CIR has been rejected from acceptlist";
        }

        /// <summary>
        /// Bodies this instance.
        /// </summary>
        /// <returns></returns>
        public static string Body(NotificationData notificationData)
        {
            StringBuilder build = new StringBuilder();

            build.AppendLine("CIR ID: " + notificationData.CirId);
            build.AppendLine("Filename: " + notificationData.FileName);
            build.AppendLine("Rejected by: " + notificationData.RejectedBy);
            build.AppendLine("");
            build.AppendLine("This mail is generated to notify you that a Component Inspection Report has been rejected from the accept list, and is now located as pending in the Submitted Section.");
            build.AppendLine("");
            if ((notificationData.Comment.Length > 0))
            {
                build.AppendLine("The Component Inspection Report has been rejected with the following comment: ");
                build.AppendLine("");
                build.AppendLine(notificationData.Comment);
                build.AppendLine("");
            }
            build.AppendLine("Yours sincerely");
            build.AppendLine("");
            build.AppendLine("");
            build.AppendLine("Operations, R&D");
            build.AppendLine("Vestas Wind Systems A/S");

            return build.ToString();
        }

        public static string MessageId(long cirId)
        {
            return Guid.NewGuid().ToString(); 
        }
    }
}
