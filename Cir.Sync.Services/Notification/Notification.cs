using Cir.Sync.Services.DAL;
using Cir.Sync.Services.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Cir.Sync.Services.Notification
{
    public abstract class Notification
    {
        protected DateTime? _SendOn = new DateTime();
        protected List<MailAddress> _ToEmails = new List<MailAddress>();
        protected List<MailAddress> _CCEmails = new List<MailAddress>();
        protected long _CirDataId = 0;

        public string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public string InboxUrl = System.Configuration.ConfigurationManager.AppSettings["InboxUrl"];
        public string InboxEmail = System.Configuration.ConfigurationManager.AppSettings["InboxEmail"];
        public string NotificationEmail = System.Configuration.ConfigurationManager.AppSettings["NotificationEmail"];
        public string MailBox1537Email = System.Configuration.ConfigurationManager.AppSettings["MailBox1537Email"];
        public string HotlistEmail = System.Configuration.ConfigurationManager.AppSettings["HotlistEmail"];
        public string FirstNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["FirstNotificationCcEmail"];
        public string SecondNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["SecondNotificationCcEmail"];
        public string AbbMwEmail = System.Configuration.ConfigurationManager.AppSettings["AbbMwEmail"];
        public string LeroySomerMwEmail = System.Configuration.ConfigurationManager.AppSettings["LeroySomerMwEmail"];


        public long CirDataId
        {
            get { return _CirDataId; }
        }
        public virtual string MessageId
        {
            get { return Guid.NewGuid().ToString(); }
        }
        public virtual DeliveryNotificationOptions DeliveryNotification
        {
            get { return DeliveryNotificationOptions.None; }
        }
        public DateTime? SentOn
        {
            get { return _SendOn; }
        }

        public List<MailAddress> ToEmails
        {
            get { return _ToEmails; }
            set { _ToEmails = value; }
        }
        public List<MailAddress> CCEmails
        {
            get { return _CCEmails; }
            set { _CCEmails = value; }
        }

        public string ToEmailString()
        {
         string email = "";
            if(_ToEmails.Count > 0)
            {
                   foreach (var adr in _ToEmails)
                {
                    email = email + adr.Address + ";";
                }
            }
            return email;
        }

        public string CCEmailString()
        {
            string email = "";
            if (_CCEmails.Count > 0)
            {
                foreach (var adr in _CCEmails)
                {
                    email = email + adr.Address + ";";
                }
            }
            return email;
        }
      
        public MailAddressCollection ToEMail
        {
            get
            {
                MailAddressCollection col = new MailAddressCollection();
                foreach (var adr in _ToEmails)
                {
                    col.Add(adr);
                }
                return col;
            }
        }

        public MailAddressCollection CCEMail
        {
            get
            {
                MailAddressCollection col = new MailAddressCollection();
                foreach (var adr in _CCEmails)
                {
                    col.Add(adr);
                }
                return col;
            }
        }

        public abstract string Body();
        public abstract string Subject();

        public static bool Is3MWGearBox(long CIMCase)
        {
            List<long> caseNumbers = new List<long>();
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Casenumber FROM [3MWGearboxes]", objCon))
                {
                    objCon.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        caseNumbers.Add(reader.GetInt64(reader.GetOrdinal("Casenumber")));
                    }
                    reader.Close();
                }
            }

            return caseNumbers.Contains(CIMCase);
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
    }

    public enum ComponentType
    {
        Blade,
        Gearbox,
        General,
        Generator,
        Transformer,
        MainBearing,
        Skiipack
    }

    public enum State
    {
        New,
        Updated
    }

}


