using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Notification
{
    public static class FirstNotificationData
    { 
      

        /// <summary>
        /// Generate Subject
        /// </summary>
        /// <returns></returns>
        public static string Subject()
        {
            return "Letter of notification";
        }

        /// <summary>
        /// Generate  Body
        /// </summary>
        /// <returns></returns>
        public static string Body(NotificationData notificationData)
        {
            StringBuilder build = new StringBuilder();
            //if (EditDate.HasValue)
            //{
            //    build.AppendLine(EditDate.Value.ToString("d") + " / " + EditInitials.Trim(' ') + " / " + SBU);
            //}
            //else
            //{
            //    build.AppendLine(EditInitials.Trim(' ') + " / " + SBU);
            //}
            build.AppendLine("");
            build.AppendLine("Letter of notification");
            build.AppendLine("");
            build.AppendLine("Formal notification of defect component according to trade agreement.");
            build.AppendLine("");
            build.AppendLine("Vestas has received information about a defect on our " + notificationData.Turbine.ToString() + " wind turbine placed at " + notificationData.SiteName + " in " + notificationData.Country + ". The preliminary investigations indicate that the defect is caused by the " + notificationData.ComponentType.ToString() + " delivered by " + notificationData.Manufacturer + ".");
            build.AppendLine("");
            build.AppendLine("We can inform you that, at present Vestas are in the process of (replacing or remedying) the component/components affected by the defect in order to mitigate the defect’s economical impact for our costumer.");
            build.AppendLine("");
            build.AppendLine("As soon as we have more information about the defect you will receive a Component Inspection Report referring to this notification.");
            build.AppendLine("");
            build.AppendLine("Component information:");
            build.AppendLine("  1. Main Component:     " + notificationData.ComponentType.ToString());
            build.AppendLine("  2. Serial no.          " + notificationData.SerialNo);
            if (notificationData.CommisioningDate.HasValue)
            {
                build.AppendLine("  3. Commissioning date: " + notificationData.CommisioningDate.Value.ToString("d"));
            }
            else
            {
                build.AppendLine("  3. Commissioning date: ");
            }
            if (notificationData.FailureDate.HasValue)
            {
                build.AppendLine("  4. Failure date:       " + notificationData.FailureDate.Value.ToString("d"));
            }
            else
            {
                build.AppendLine("  4. Failure date:       ");
            }
            build.AppendLine("  5. CIR ID:             " + notificationData.CirId.ToString());
            if (!string.IsNullOrEmpty(notificationData.FailedItemDescription))
            {
                build.AppendLine("  6. Item desciption: " + notificationData.FailedItemDescription);
            }
            build.AppendLine("");
            build.AppendLine("");
            build.AppendLine("Yours sincerely");
            build.AppendLine("Vestas Wind Systems A/S");

            return build.ToString();
        }

        public static string MessageId (long cirId)
        {
           return "Vestas:CIR:" + cirId.ToString() + ":First"; 
        }

        public static System.Net.Mail.DeliveryNotificationOptions DeliveryNotification()
        {
             return System.Net.Mail.DeliveryNotificationOptions.OnFailure | System.Net.Mail.DeliveryNotificationOptions.OnSuccess;
        }

    }
}