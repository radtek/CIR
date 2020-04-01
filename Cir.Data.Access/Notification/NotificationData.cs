using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using static Cir.Data.Access.Enumerations.Enumeration;

namespace Cir.Data.Access.Notification
{
    public class NotificationData
    {   
        
        public NotificationData()
        {

        }
       
        public long CirId { get; set; }

        public long CimCaseNo { get; set; }

        public System.Nullable<System.DateTime> EditDate { get; set; }      

        public string EditInitials { get; set; }

       public string State { get; set; }         

        public string Country { get; set; }        
        
        public string SBU { get; set; } 
        
        public string Turbine { get; set; }

        public string SiteName { get; set; }
       
        public CirTemplate ComponentType { get; set; }  

        public DateTime? SentOn { get; set; }      

        public List<string> ToEmails { get; set; }
        
        public List<string> CCEmails { get; set; }


        public long ManufactureId { get; set; }
        public System.Nullable<System.DateTime> FailureDate { get; set; }
        public System.Nullable<System.DateTime> CommisioningDate { get; set; }
        public string Manufacturer { get; set; }

        public string ManufacturerContactName { get; set; }
        public string SerialNo { get; set; }
        public string FailedItemDescription { get; set; }


        public string AttachmentName { get; set; }

        public string Attachment { get; set; }

        public bool Updated { get; set; }



        public string RejectedBy { get; set; }


        public string Comment { get; set; }
        public System.DateTime? Received { get; set; }      

        public string SendTo { get; set; }
       

        public string FileName { get; set; }
      

    }
}