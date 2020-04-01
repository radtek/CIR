using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Azure.MobileApp.Service.DataObjects
{
    public class UserInformation
    {
        public String displayName { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String userName { get; set; }
        public String streetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String postalCode { get; set; }
        public String mail { get; set; }
        public String userPrincipalName { get; set; }
        public String[] otherMails { get; set; }
        public String[] AppRoles { get; set; }
        public object obj { get; set; }
        public override string ToString()
        {

            return "displayName : " + displayName + "\n" +
                   "firstName : " + firstName + "\n" +
                   "lastName : " + lastName + "\n" +
                   "userName : " + userName + "\n" +
                   "streetAddress : " + streetAddress + "\n" +
                   "city : " + city + "\n" +
                   "state : " + state + "\n" +
                   "postalCode : " + postalCode + "\n" +
                   "mail : " + mail + "\n" +
                   "userPrincipalName : " + userPrincipalName + "\n" +
                   ((otherMails != null) ? "otherMails : " + string.Join(", ", otherMails) : "otherMails : ");
        }
    }
    public class UserRoleMap
    {
        public string UserId { get; set; }
        public Guid AppRoleId { get; set; }
    }
    public class ExtUserMap
    {
        public string objectId { get; set; }
        public string extName { get; set; }
        public string internalUPN { get; set; }
    }
}