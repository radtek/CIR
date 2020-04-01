using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using System.Net.Mail;
using System.Text;
namespace Cir.Sync.Services.Notification
{
    public class SBURejectNotificationData : NotificationData
    {
     
        //private Controller _Controller;
        private long _Id;
        private long _CIRId;
        private string _FileName;
        private string _RejectedBy;

        private string _Comment;
        /// <summary>
        /// Initializes a new instance of the RejectNotification class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public SBURejectNotificationData(SBURejectNotification entity)
        {
          
           // _Controller = new Controller(_Environment);
            _Id = entity.SBURejectNotificationId;
            _CIRId = entity.ComponentInspectionReportId;
            _FileName = entity.InfoPathFilename;

            _SendOn = entity.SendOn;
            _Comment = entity.Comment;
            _RejectedBy = entity.RejectedBy;

            if (entity.CIMCaseNo.HasValue && Is3MWGearBox(entity.CIMCaseNo.Value))
            {
                // send to 3MW gearbox (ignore country SBU)
                ToEmails.Add(new MailAddress(MailBox1537Email));
            }
            else if ((entity.SBU != null))
            {
                _SBU = entity.SBU.Name;
                if (!string.IsNullOrEmpty(entity.SBU.Email))
                {
                    ToEmails.Add(new MailAddress(entity.SBU.Email));
                }
            }

        }

        public long Id
        {
            get { return _Id; }
        }

        /// <summary>
        /// Subjects this instance.
        /// </summary>
        /// <returns></returns>
        public override string Subject()
        {
            return "CIR has been rejected from acceptlist";
        }

        /// <summary>
        /// Bodies this instance.
        /// </summary>
        /// <returns></returns>
        public override string Body()
        {
            StringBuilder build = new StringBuilder();

            build.AppendLine("CIR ID: " + _CIRId);
            build.AppendLine("Filename: " + _FileName);
            build.AppendLine("Rejected by: " + _RejectedBy);
            build.AppendLine("");
            build.AppendLine("This mail is generated to notify you that a Component Inspection Report has been rejected from the accept list, and is now located as \"pending\" in the Submitted Section.");
            build.AppendLine("");
            if ((_Comment.Length > 0))
            {
                build.AppendLine("The Component Inspection Report has been rejected with the following comment: ");
                build.AppendLine("");
                build.AppendLine(_Comment);
                build.AppendLine("");
            }
            build.AppendLine("Yours sincerely");
            build.AppendLine("");
            build.AppendLine("");
            build.AppendLine("Operations, R&D");
            build.AppendLine("Vestas Wind Systems A/S");

            return build.ToString();
        }
    }

}