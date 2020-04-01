using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using System.Text;
using Microsoft.Azure.Mobile.Server.Tables;
using Newtonsoft.Json;
using Cir.Azure.MobileApp.Utilities.Helper;

namespace Cir.Azure.MobileApp.DataObjects
{
    public class UserCirData : EntityData
    {

        public long CirDataLocalID { get; set; }

        public string UpdateBy { get; set; }

        public string CreatedDate { get; set; }

        public int Status { set; get; }

        public string StatusMessage { get; set; }

        public string StatusDetailMessage { get; set; }

        public string CirData { get; set; }

        public string UserInitial { get; set; }

        public int CirStatus { get; set; }

        //[JsonConverter(typeof(LongToStringConverter))]
        public long RowVersion { get; set; }

        public string RelatedUserCirDataID { get; set; }

        public string Remarks { get; set; }

    }
}