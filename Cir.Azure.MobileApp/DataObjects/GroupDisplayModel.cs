using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Azure.MobileApp.DataObjects
{
    public class GroupDisplayModel
    {
        public string objectID { get; set; }
        public string groupName { get; set; }
        public string emailAddress { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public List<AppRole> roleList { get; set; }
        public List<AppRole> availableRoleList { get; set; }
    }
}