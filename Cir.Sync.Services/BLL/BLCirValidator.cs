using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public class BLCirValidator
    {

        public static bool IsValidNotificationNumber(string notificationNumber,string TurbineNumber)
        {
                return DACirValidator.IsValidNotificationNumber(notificationNumber, TurbineNumber);
        }

         public static bool IsValidServiceReportNumber(string serviceReportNumber,string TurbineNumber)
        {
                return DACirValidator.IsValidServiceReportNumber(serviceReportNumber, TurbineNumber);
        }
    }
}