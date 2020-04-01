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
    public class UserLoginDetails : EntityData
    {
        public string UserPricipleName { get; set; }
        public DateTime? LastOnlineTime { get; set; }
        public DateTime? LastMasterDataSyncTime { get; set; }
    }
}