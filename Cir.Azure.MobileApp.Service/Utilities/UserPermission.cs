using Cir.Azure.MobileApp.Service.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Azure.MobileApp.Service.Utilities
{
    public static class UserPermission
    {
        //Visitor = -1,
        //Viewer = 0, (CreateView)
        //Editor = 1, (EditPublicView,EditCir,Add Attachement,DownloadOldCirVersions)
        //Member = 2 (ApproveCir,RejectCir,DeleteCir,RejectApproveCir,AdministerHotItems),
        //Owner = 3,
        //BIRCreator = 4,
        //Administrator = 5  (CreateUser,EditUser,EditSystemView,AdministerManufacturers,DownloadEmailsFromArchive)
        public static string UserName(UserInformation UserInfo)
        {
            var uname = "";
            if (UserInfo.userPrincipalName.ToLower().Contains("ext"))
            {
                if (UserInfo.otherMails != null && UserInfo.otherMails.Length > 0 && UserInfo.otherMails[0] != null)
                {
                    uname = UserInfo.otherMails[0];
                }
            }
            else
            {
                uname = UserInfo.userPrincipalName;
            }
            return uname.Split('@')[0];
        }
        public static bool isAdministrator(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator");
            return permission;

        }
        public static bool isBIRCreator(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("BIRCreator");
            return permission;

        }

        public static bool isGIRCreator(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("GIRCreator");
            return permission;

        }
        public static bool isGBXIRCreator(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("GBXIRCreator");
            return permission;

        }
        public static bool CreateView(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                      roles.Contains("GIRCreator") ||
                                      roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") || roles.Contains("Viewer") || roles.Contains("Editor") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool LockCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                      roles.Contains("GIRCreator") ||
                                      roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Editor") ||
                                      roles.Contains("Owner") ||
                                      roles.Contains("Technicians") || roles.Contains("Turnine Technicians") || roles.Contains("Contractor Turnine Technicians") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool RejectApproveCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                      roles.Contains("GIRCreator") ||
                                      roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool DeleteCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                       roles.Contains("GIRCreator") ||
                                       roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool RejectCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                       roles.Contains("GIRCreator") ||
                                       roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool ApproveCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                       roles.Contains("GIRCreator") ||
                                       roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool EditCir(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                       roles.Contains("GIRCreator") ||
                                       roles.Contains("GBXIRCreator") ||
                                       roles.Contains("CIR Evaluator")||
                                      roles.Contains("Owner") || roles.Contains("Editor") ||
                                      roles.Contains("Technicians") || roles.Contains("Turbine Technicians") || roles.Contains("Contractor Turbine Technicians") ||
                                      roles.Contains("Member");
            return permission;

        }
        public static bool EditPublicView(string[] roles)
        {
            bool permission = false;
            permission = roles.Contains("Administrator") ||
                                      roles.Contains("BIRCreator") ||
                                       roles.Contains("GIRCreator") ||
                                        roles.Contains("GBXIRCreator") ||
                                      roles.Contains("Owner") || roles.Contains("Editor") ||
                                      roles.Contains("Member");
            return permission;

        }


    }
}