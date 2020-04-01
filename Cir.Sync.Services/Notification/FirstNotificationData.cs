using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using System.Text;

namespace Cir.Sync.Services.Notification
{
    public class FirstNotificationData : NotificationData
    {
        private System.Nullable<System.DateTime> _FailureDate;
        private System.Nullable<System.DateTime> _CommisioningDate;
        private string _Manufacturer;
        private string _SerialNo;

        private string _FailedItemDescription;
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstNotification" /> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public FirstNotificationData(FirstNotification entity)
            : base()
        {

            if ((entity != null))
            {
                if (entity.CirDataId.HasValue)
                {
                    _CirDataId = entity.CirDataId.Value;
                }

                _SendOn = entity.SendOn;
                _ComponentInspectionReportId = entity.ComponentInspectionReportId;
                _EditDate = entity.EditDate;
                _EditInitials = entity.EditInitials;
                _SiteName = entity.Sitename;
                _ComponentType = CastComponentType(entity.ComponentType);

                _SerialNo = entity.SerialNo;
                _CommisioningDate = entity.CommisioningDate;
                _FailureDate = entity.FailureDate;
                if ((entity.SBU != null))
                {
                    _SBU = entity.SBU.Name;
                }
                if ((entity.CountryISO != null))
                {
                    _Country = entity.CountryISO.Name;
                }
            }
        }

        /// <summary>
        /// Gets or sets the failure date.
        /// </summary>
        /// <value>The failure date.</value>
        public System.Nullable<System.DateTime> FailureDate
        {
            get { return _FailureDate; }
            set { _FailureDate = value; }
        }

        /// <summary>
        /// Gets or sets the commisioning date.
        /// </summary>
        /// <value>The commisioning date.</value>
        public System.Nullable<System.DateTime> CommisioningDate
        {
            get { return _CommisioningDate; }
            set { _CommisioningDate = value; }
        }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer
        {
            get
            {
                if (string.IsNullOrEmpty(_Manufacturer))
                {
                    return "-";
                }
                return _Manufacturer;
            }
            set { _Manufacturer = value; }
        }

        /// <summary>
        /// Gets or sets the serial no.
        /// </summary>
        /// <value>The serial no.</value>
        public string SerialNo
        {
            get
            {
                if (string.IsNullOrEmpty(_SerialNo))
                {
                    return "-";
                }
                return _SerialNo;
            }
            set { _SerialNo = value; }
        }

        public string FailedItemDescription
        {
            get { return _FailedItemDescription; }
            set { _FailedItemDescription = value; }
        }

        /// <summary>
        /// Generate Subject
        /// </summary>
        /// <returns></returns>
        public override string Subject()
        {
            return "Letter of notification";
        }

        /// <summary>
        /// Generate  Body
        /// </summary>
        /// <returns></returns>
        public override string Body()
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
            build.AppendLine("Vestas has received information about a defect on our " + Turbine.ToString() + " wind turbine placed at " + SiteName + " in " + Country + ". The preliminary investigations indicate that the defect is caused by the " + ComponentType.ToString() + " delivered by " + Manufacturer + ".");
            build.AppendLine("");
            build.AppendLine("We can inform you that, at present Vestas are in the process of (replacing or remedying) the component/components affected by the defect in order to mitigate the defect’s economical impact for our costumer.");
            build.AppendLine("");
            build.AppendLine("As soon as we have more information about the defect you will receive a Component Inspection Report referring to this notification.");
            build.AppendLine("");
            build.AppendLine("Component information:");
            build.AppendLine("  1. Main Component:     " + ComponentType.ToString());
            build.AppendLine("  2. Serial no.          " + SerialNo);
            if (CommisioningDate.HasValue)
            {
                build.AppendLine("  3. Commissioning date: " + CommisioningDate.Value.ToString("d"));
            }
            else
            {
                build.AppendLine("  3. Commissioning date: ");
            }
            if (FailureDate.HasValue)
            {
                build.AppendLine("  4. Failure date:       " + FailureDate.Value.ToString("d"));
            }
            else
            {
                build.AppendLine("  4. Failure date:       ");
            }
            build.AppendLine("  5. CIR ID:             " + ComponentInspectionReportId.ToString());
            if (!string.IsNullOrEmpty(FailedItemDescription))
            {
                build.AppendLine("  6. Item desciption: " + FailedItemDescription);
            }
            build.AppendLine("");
            build.AppendLine("");
            build.AppendLine("Yours sincerely");
            build.AppendLine("Vestas Wind Systems A/S");

            return build.ToString();
        }

        public override string MessageId
        {
            get { return "Vestas:CIR:" + CirDataId.ToString() + ":First"; }
        }

        public override System.Net.Mail.DeliveryNotificationOptions DeliveryNotification
        {
            get { return System.Net.Mail.DeliveryNotificationOptions.OnFailure | System.Net.Mail.DeliveryNotificationOptions.OnSuccess; }
        }

    }
}