using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Notification
{
   
    public static class RejectNotificationData
    {
        public static string InboxUrl = System.Configuration.ConfigurationManager.AppSettings["InboxUrl"];
        /// <summary>
        /// Subjects this instance.
        /// </summary>
        /// <returns></returns>
        public static string Subject()
        {
            return "Message regarding rejected CIR";
        }

        /// <summary>
        /// Bodies this instance.
        /// </summary>
        /// <returns></returns>
        public static string Body(NotificationData notificationData)
        {

            StringBuilder build = new StringBuilder();
            build.Append("<html><body>");
            build.AppendLine("<p>");
            build.AppendLine("This message is generated to notify you that your Component Inspection Report has been rejected.");
            build.AppendLine("</p>");
            //build.AppendLine("");
            build.AppendLine(string.Format("CIR ID: {0}", "<a target='_blank' href ='" + InboxUrl + "/cir-search#CirID=" + notificationData.CirId + "'>" + notificationData.CirId + "</a>"));

            build.Append("<br>");
            // "<a href='/CirView/manage-cirviewlist?cirid=" + entity.ComponentInspectionReportId
            build.AppendLine(string.Format("Rejected by: {0}, Technical Support", notificationData.RejectedBy));
            build.Append("<br>");
            build.AppendLine(string.Format("Date of CIR Rejection: {0}", System.DateTime.Now.ToShortDateString()));
            build.Append("<br>");
            //  build.AppendLine(string.Format("Reject list: {0}Reject.aspx?cirid={1}", _Environment.WebsiteBaseUrl, CIRId));
            if (!string.IsNullOrEmpty(notificationData.Comment))
            {

                build.AppendLine(string.Format("Comment: {0}", notificationData.Comment));
                build.Append("<br>");
            }

            build.AppendLine("<p>");
            build.AppendLine("To correct the CIR:");
            build.AppendLine("<br>");
            build.AppendLine("Please use the link above, download, edit and resubmit.");
            build.AppendLine("</p>");
            build.AppendLine("<p>");
            build.AppendLine("Yours sincerely");
            build.AppendLine("</p>");
            build.AppendLine("Operations, R&D");
            build.Append("<br>");
            build.AppendLine("Vestas Wind Systems A/S");
            build.Append("</html></body>");
            return build.ToString();
        }

        public static string MessageId(long cirId)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
