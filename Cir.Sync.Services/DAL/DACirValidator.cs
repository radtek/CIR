using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.SapIntegrator;
using Cir.SapIntegrator.Validation;
using System.Configuration;
using Cir.Sync.Services.ErrorHandling;

namespace Cir.Sync.Services.DAL
    {
    public class DACirValidator
        {
        public static string UseSapWebService = System.Configuration.ConfigurationManager.AppSettings["UseSapWebService"];
        public static string SapWebServiceUserName = System.Configuration.ConfigurationManager.AppSettings["SapWebServiceUserName"];
        public static string SapWebServicePassword = System.Configuration.ConfigurationManager.AppSettings["SapWebServicePassword"];
        public static string SapNotificationNumberWebServiceUrl = System.Configuration.ConfigurationManager.AppSettings["SapNotificationNumberWebServiceUrl"];
        public static string SapServiceReportNumberWebServiceUrl = System.Configuration.ConfigurationManager.AppSettings["SapServiceReportNumberWebServiceUrl"];

        public static bool IsDevelopment()
            {
            bool isDevEnv = false;
            try
                {
                isDevEnv = (ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString.ToString().IndexOf("cim-dev-db") > 0) ? true : false;
                }
            catch (Exception e)
                {
                isDevEnv = false;
                }
            return isDevEnv;
            }

        public static bool IsValidNotificationNumber(string notificationNumber, string turbineNumber)
            {
            try { 
            if (!String.IsNullOrEmpty(SapNotificationNumberWebServiceUrl))
                {
                if (UseSapWebService.ToUpper() == "TRUE")
                    {
                     var notificationNumberValidator = new NotificationNumberValidator(SapNotificationNumberWebServiceUrl, SapWebServiceUserName, SapWebServicePassword);
                    return notificationNumberValidator.Validate(turbineNumber, notificationNumber);
                    }

                if (IsDevelopment() == true)
                    {
                    if (notificationNumber == "12345" && turbineNumber == "12345")
                        {
                        return false;
                        }
                    if (notificationNumber == "54321" && turbineNumber == "54321")
                        {
                        return false;
                        }
                    }
                }
            return true;
                }
            catch
                {
                return false;
                }
            }

        public static bool IsValidServiceReportNumber(string serviceReportNumber, string turbineNumber)
            {
            try
                {
                if (!String.IsNullOrEmpty(SapServiceReportNumberWebServiceUrl))
                    {
                    if (UseSapWebService.ToUpper() == "TRUE")
                        {
                        var serviceReportValidator = new ServiceReportNumberValidator(SapServiceReportNumberWebServiceUrl, SapWebServiceUserName, SapWebServicePassword);
                        return serviceReportValidator.Validate(turbineNumber, serviceReportNumber);
                        }
                    }
                return true;
                }
            catch
                {
                return false;
                }
            }
        }
    }