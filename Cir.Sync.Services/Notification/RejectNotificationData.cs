using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.Edmx;
using System.Text;
using System.Net.Mail;


namespace Cir.Sync.Services.Notification
{
    public class RejectNotificationData : Notification
    {
        //New CIR.Business.Environment(Environment.Platforms.Sharepoint)
         

        private long _Id;
        private long _CIRId;
        private string _FileName;
        private string _SendTo;
        private string _RejectedBy;
        private string _Comment;
        private System.DateTime? _Received;
        private long _SBUId;

        private bool _Is3MwMailBox = false;
        /// <summary>
        /// Initializes a new instance of the RejectNotification class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public RejectNotificationData(RejectNotification entity)
        {
            // _Environment = environment;
            //  _Controller = new Controller(_Environment);
            _Id = entity.RejectNotificationId;
            _CIRId = entity.ComponentInspectionReportId;
            _FileName = entity.InfoPathFilename;
          
            if (entity.CIMCaseNo.HasValue)
            {
                if (Is3MWGearBox(entity.CIMCaseNo.Value))
                {
                    _Is3MwMailBox = true;
                }
            }

            _SendTo = entity.SendTo;
            _SendOn = entity.SendOn;
            _Comment = entity.Comment;
            _RejectedBy = entity.RejectedBy;

            if (entity.Received.HasValue)
            {
                _Received = entity.Received.Value;
            }
            else
            {
                _Received = null;
            }

            
             _SBUId = entity.SBUId.Value;
          

            
             _ToEmails.Add(new MailAddress(_SendTo));
           
        }

        public long Id
        {
            get { return _Id; }
        }

        public System.DateTime? Received
        {
            get { return _Received; }
            set { _Received = value; }
        }

        public long SBUId
        {
            get { return _SBUId; }
            set { _SBUId = value; }
        }

        public long CIRId
        {
            get { return _CIRId; }
            set { _CIRId = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public string SendTo
        {
            get { return _SendTo; }
            set { _SendTo = value; }
        }

        public string RejectedBy
        {
            get { return _RejectedBy; }
            set { _RejectedBy = value; }
        }

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        /// <summary>
        /// Subjects this instance.
        /// </summary>
        /// <returns></returns>
        public override string Subject()
        {
            return "Message regarding rejected CIR";
        }

        /// <summary>
        /// Bodies this instance.
        /// </summary>
        /// <returns></returns>
        public override string Body()
        {
          
             StringBuilder build = new StringBuilder();
            build.Append("<html><body>");
            build.AppendLine("<p>");
            build.AppendLine("This message is generated to notify you that your Component Inspection Report has been rejected.");
            build.AppendLine("</p>");
            //build.AppendLine("");
            build.AppendLine(string.Format("CIR ID: {0}", "<a target='_blank' href ='"+ InboxUrl + "/cir-search#CirID=" + CIRId + "'>"+CIRId+"</a>"));

            build.Append("<br>");
           // "<a href='/CirView/manage-cirviewlist?cirid=" + entity.ComponentInspectionReportId
            build.AppendLine(string.Format("Rejected by: {0}, Technical Support", RejectedBy));
            build.Append("<br>");
            build.AppendLine(string.Format("Date of CIR Rejection: {0}", System.DateTime.Now.ToShortDateString()));
            build.Append("<br>");
            //  build.AppendLine(string.Format("Reject list: {0}Reject.aspx?cirid={1}", _Environment.WebsiteBaseUrl, CIRId));
            if (!string.IsNullOrEmpty(Comment))
            {

                build.AppendLine(string.Format("Comment: {0}", Comment));
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

       
    }
}