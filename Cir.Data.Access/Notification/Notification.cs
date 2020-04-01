using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;

namespace Cir.Data.Access.Notification
{
    public abstract class Notification
    {
        //protected DateTime? _SendOn = new DateTime();
        //protected List<string> _ToEmails = new List<string>();
        //protected List<string> _CCEmails = new List<string>();
        //protected long _CirDataId = 0;

        //public string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        //public string InboxUrl = System.Configuration.ConfigurationManager.AppSettings["InboxUrl"];
        //public string InboxEmail = System.Configuration.ConfigurationManager.AppSettings["InboxEmail"];
        //public string NotificationEmail = System.Configuration.ConfigurationManager.AppSettings["NotificationEmail"];
        //public string MailBox1537Email = System.Configuration.ConfigurationManager.AppSettings["MailBox1537Email"];
        //public string HotlistEmail = System.Configuration.ConfigurationManager.AppSettings["HotlistEmail"];
        //public string FirstNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["FirstNotificationCcEmail"];
        //public string SecondNotificationCcEmail = System.Configuration.ConfigurationManager.AppSettings["SecondNotificationCcEmail"];
        //public string AbbMwEmail = System.Configuration.ConfigurationManager.AppSettings["AbbMwEmail"];
        //public string LeroySomerMwEmail = System.Configuration.ConfigurationManager.AppSettings["LeroySomerMwEmail"];


        //public long CirDataId
        //{
        //    get { return _CirDataId; }
        //    set { _CirDataId = value; }
        //}
        //public virtual string MessageId
        //{
        //    get { return Guid.NewGuid().ToString(); }
        //}
        //public virtual DeliveryNotificationOptions DeliveryNotification
        //{
        //    get { return DeliveryNotificationOptions.None; }
        //}
        //public DateTime? SentOn
        //{
        //    get { return _SendOn; }
        //}

        //public List<string> ToEmails
        //{
        //    get { return _ToEmails; }
        //    set { _ToEmails = value; }
        //}
        //public List<string> CCEmails
        //{
        //    get { return _CCEmails; }
        //    set { _CCEmails = value; }
        //}

        ////public string ToEmailString()
        ////{
        //// string email = "";
        ////    if(_ToEmails.Count > 0)
        ////    {
        ////           foreach (var adr in _ToEmails)
        ////        {
        ////            email = email + adr.Address + ";";
        ////        }
        ////    }
        ////    return email;
        ////}

        ////public string CCEmailString()
        ////{
        ////    string email = "";
        ////    if (_CCEmails.Count > 0)
        ////    {
        ////        foreach (var adr in _CCEmails)
        ////        {
        ////            email = email + adr.Address + ";";
        ////        }
        ////    }
        ////    return email;
        ////}
      
        ////public MailAddressCollection ToEMail
        ////{
        ////    get
        ////    {
        ////        MailAddressCollection col = new MailAddressCollection();
        ////        foreach (var adr in _ToEmails)
        ////        {
        ////            col.Add(adr);
        ////        }
        ////        return col;
        ////    }
        ////}

        ////public MailAddressCollection CCEMail
        ////{
        ////    get
        ////    {
        ////        MailAddressCollection col = new MailAddressCollection();
        ////        foreach (var adr in _CCEmails)
        ////        {
        ////            col.Add(adr);
        ////        }
        ////        return col;
        ////    }
        ////}

        //public abstract string Body();
        //public abstract string Subject();

        ////public static bool Is3MWGearBox(long CIMCase)
        ////{
        ////    List<long> caseNumbers = new List<long>();
        ////    using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
        ////    {
        ////        using (SqlCommand cmd = new SqlCommand("SELECT Casenumber FROM [3MWGearboxes]", objCon))
        ////        {
        ////            objCon.Open();
        ////            SqlDataReader reader = cmd.ExecuteReader();
        ////            while (reader.Read())
        ////            {
        ////                caseNumbers.Add(reader.GetInt64(reader.GetOrdinal("Casenumber")));
        ////            }
        ////            reader.Close();
        ////        }
        ////    }

        ////    return caseNumbers.Contains(CIMCase);
        ////}

        ////private static string GetConnectionString()
        ////{
        ////    return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        ////}
    }

    //public enum ComponentType
    //{
    //    BladeInspection = 1,
    //    Gearbox = 2,
    //    General = 3,
    //    Generator = 4,
    //    Transformer = 5,
    //    MainBearing = 6,
    //    Skiipack = 7,
    //    SimplifiedCIR = 8,
    //    BladeRepair = 9
    //}

    //public enum State
    //{
    //    New,
    //    Updated
    //}

}


