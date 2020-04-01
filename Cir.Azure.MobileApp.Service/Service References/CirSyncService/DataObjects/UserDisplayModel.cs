using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Azure.MobileApp.Service.DataObjects
{
    public class UserDisplayModel
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public string emailAddress { get; set; }
        public string lastLogin { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public List<AppRole> roleList { get; set; }
        public List<AppRole> availableRoleList { get; set; }
    }

}