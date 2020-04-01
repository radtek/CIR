using Cir.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Validation
{
    internal static class ValidationFactory<T> where T : class
    {
        public static IValidation GetInstance()
        {
            if(typeof(T) == typeof(TurbineNumberValidation))
            {
                return new TurbineNumberValidation();
            }
            if (typeof(T) == typeof(ServiceNotificationNumberValidation))
            {
                var validationConfig = new SapValidationConfig(
                                                                ConfigurationManager.AppSettings["UseSapWebService"],
                                                                ConfigurationManager.AppSettings["SapWebServiceUserName"],
                                                                ConfigurationManager.AppSettings["SapWebServicePassword"],
                                                                ConfigurationManager.AppSettings["SapNotificationNumberWebServiceUrl"],
                                                                ConfigurationManager.AppSettings["SapServiceReportNumberWebServiceUrl"]);
                return new ServiceNotificationNumberValidation(validationConfig);
            }
            if (typeof(T) == typeof(ServiceReportNumberValidation))
            {
                var validationConfig = new SapValidationConfig(
                                                                ConfigurationManager.AppSettings["UseSapWebService"],
                                                                ConfigurationManager.AppSettings["SapWebServiceUserName"],
                                                                ConfigurationManager.AppSettings["SapWebServicePassword"],
                                                                ConfigurationManager.AppSettings["SapNotificationNumberWebServiceUrl"],
                                                                ConfigurationManager.AppSettings["SapServiceReportNumberWebServiceUrl"]);
                return new ServiceReportNumberValidation(validationConfig);
            }
            if (typeof(T) == typeof(CIMCaseValidation))
            {
                return new CIMCaseValidation();
            }
            throw new NotSupportedException($" {typeof(T).Name} is not supported");
        }

    }
}
