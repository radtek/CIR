using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Notification
{
    public static class SecondNotificationData
    {
        public static string Subject()
        {
            return "Updated Notification of defect including CIR report";
        }

        /// <summary>
        /// Generate  Body
        /// </summary>
        /// <returns></returns>
        public static string Body(NotificationData notificationData)
        {
            StringBuilder build = new StringBuilder();
            build.AppendLine("Date:         " + System.DateTime.Now.ToString("d"));
            build.AppendLine("Manufacturer: " + notificationData.Manufacturer);
            build.AppendLine("Email:        " + String.Join(",", notificationData.ToEmails));
            build.AppendLine("Attn:         " + notificationData.ManufacturerContactName);
            build.AppendLine("");
            build.AppendLine(string.Format("With reference to our previously submitted notification (CIR ID: {0}) of defect, Vestas has {1} Component Inspection Report concerning the failed component.", notificationData.CirId.ToString(), notificationData.Updated ? "updated the" : "now made a"));
            build.AppendLine("");
            build.AppendLine("So far, our investigations indicate that the failure is due to a defective component delivered by " + notificationData.Manufacturer + ".");
            build.AppendLine("");
            build.AppendLine("Vestas has initiated a CIM (Continuous Improvement Management) process in respect of known as well as future occurrences of the defect in question. Through the CIM process, Vestas will keep record of such reported occurrences as well as clarify the potential impact and extent of the defects. Finally, the CIM process will clarify which corrective actions should be taken.");
            build.AppendLine("");
            build.AppendLine("The defect in question is dealt with under the following CIM case number: CIM case No. " + notificationData.CimCaseNo.ToString());
            build.AppendLine("");
            build.AppendLine("Since the process concerns " + notificationData.Manufacturer + "’s products we ask you to ensure that the organisation of " + notificationData.Manufacturer + " is informed about the CIM case and is willing to take an active part in the process.");
            build.AppendLine("");
            build.AppendLine("For the sake of good order and due to the unclarified character of the defects Vestas must at this stage reserve all its contractual rights under the Trade Agreement/Purchase Agreement including the right to have a recourse of all expenses associated with this case.");
            build.AppendLine("");
            build.AppendLine("In case you have any questions or comments please do not hesitate to contact us.");
            build.AppendLine("");
            build.AppendLine("");
            build.AppendLine("Yours sincerely");
            build.AppendLine("Vestas Wind Systems A/S");
            return build.ToString();
        }

        public static string MessageId(long cirId)
        {
         return "Vestas:CIR:" + cirId.ToString() + ":Second"; 
        }

        public static System.Net.Mail.DeliveryNotificationOptions DeliveryNotification()
        {
            return System.Net.Mail.DeliveryNotificationOptions.OnFailure | System.Net.Mail.DeliveryNotificationOptions.OnSuccess;
        }
       
    }
}