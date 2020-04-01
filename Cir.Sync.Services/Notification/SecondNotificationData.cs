using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using System.Text;
using System.Net.Mail;

namespace Cir.Sync.Services.Notification
{

    public class SecondNotificationData : NotificationData
    {
        private string _Manufacturer;
        private string _ManufacturerContactName;
        private long _CimCaseNo;
        private byte[] _Attachment;
        private string _AttachmentName;

        private bool _Updated;

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstNotification" /> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public SecondNotificationData(ref SecondNotification entity, ref PDF pdf)
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
                _ComponentType = CastComponentType(entity.ComponentType);

                if ((entity.SBU != null))
                {
                    _SBU = entity.SBU.Name;
                }
                _CimCaseNo = entity.CIMCaseNumber;

                // any PDF attachment found?
                if ((pdf != null))
                {
                    _Attachment = pdf.PDFData;
                    _AttachmentName = pdf.CIRName + ".pdf";
                    // no PDF attachment, attempt to fall back on the MHT file attachment. for backwards compatibility we'll leave this property for another release
                }


            }
        }

        /// <summary>
        /// Gets or sets the cim case no.
        /// </summary>
        /// <value>The cim case no.</value>
        public long CimCaseNo
        {
            get { return _CimCaseNo; }
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
        /// Gets or sets the name of the manufacturer contact.
        /// </summary>
        /// <value>The name of the manufacturer contact.</value>
        public string ManufacturerContactName
        {
            get
            {
                if (string.IsNullOrEmpty(_ManufacturerContactName))
                {
                    return "-";
                }
                return _ManufacturerContactName;
            }
            set { _ManufacturerContactName = value; }
        }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string AttachmentName
        {
            get { return _AttachmentName; }
        }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        /// <value>The attachment.</value>
        public byte[] Attachment
        {
            get { return _Attachment; }
        }

        /// <summary>
        /// Generate Subject
        /// </summary>
        /// <returns></returns>
        public override string Subject()
        {
            if ((Updated))
            {
                return "Updated notification of defect including CIR report";
            }
            else
            {
                return "Notification of defect including CIR report";
            }
        }

        /// <summary>
        /// Generate  Body
        /// </summary>
        /// <returns></returns>
        public override string Body()
        {
            StringBuilder build = new StringBuilder();
            build.AppendLine("Date:         " + System.DateTime.Now.ToString("d"));
            build.AppendLine("Manufacturer: " + Manufacturer);
            build.AppendLine("Email:        " + ((ToEmailString().Length > 0) ? ToEmailString().Remove(ToEmailString().Length - 1, 1) : ToEmailString()));
            build.AppendLine("Attn:         " + ManufacturerContactName);
            build.AppendLine("");
            build.AppendLine(string.Format("With reference to our previously submitted notification (CIR ID: {0}) of defect, Vestas has {1} Component Inspection Report concerning the failed component.", ComponentInspectionReportId.ToString(), Updated ? "updated the" : "now made a"));
            build.AppendLine("");
            build.AppendLine("So far, our investigations indicate that the failure is due to a defective component delivered by " + Manufacturer + ".");
            build.AppendLine("");
            build.AppendLine("Vestas has initiated a CIM (Continuous Improvement Management) process in respect of known as well as future occurrences of the defect in question. Through the CIM process, Vestas will keep record of such reported occurrences as well as clarify the potential impact and extent of the defects. Finally, the CIM process will clarify which corrective actions should be taken.");
            build.AppendLine("");
            build.AppendLine("The defect in question is dealt with under the following CIM case number: CIM case No. " + CimCaseNo.ToString());
            build.AppendLine("");
            build.AppendLine("Since the process concerns " + Manufacturer + "’s products we ask you to ensure that the organisation of " + Manufacturer + " is informed about the CIM case and is willing to take an active part in the process.");
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

        public override string MessageId
        {
            get { return "Vestas:CIR:" + CirDataId.ToString() + ":Second"; }
        }

        public override System.Net.Mail.DeliveryNotificationOptions DeliveryNotification
        {
            get { return DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess; }
        }

        public bool Updated
        {
            get { return _Updated; }
            set { _Updated = value; }
        }
    }

}