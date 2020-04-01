using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public class BLOnlineValidation
    {
        public static bool ValidateTurbineNumber(string TurbineNumber)
        {
            return DAL.DAOnlineValidation.ValidateTurbineNumber(TurbineNumber);
        }

        public static CIR.TurbineProperties ValidateGetTurbineData(string TurbineNumber)
        {
            return DAL.DAOnlineValidation.ValidateGetTurbineData(TurbineNumber);
        }


        public static bool ValidateCIMCaseNumber(string CIMCaseNumber)
        {
            return DAL.DAOnlineValidation.ValidateCIMCaseNumber(CIMCaseNumber);
        }

        public static bool ValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber)
        {
            return DAL.DAOnlineValidation.ValidateServiceReportNumber(ServiceReportNumber, TurbineNumber);
        }

        public static bool ValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber)
        {
            return DAL.DAOnlineValidation.ValidateServiceNotificationNumber(ServiceNotificationNumber, TurbineNumber);
        }
    }
}