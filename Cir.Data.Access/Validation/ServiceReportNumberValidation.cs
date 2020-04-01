using System;
using Cir.Data.Access.Models;
using Cir.SapIntegrator.Validation;

namespace Cir.Data.Access.Validation
{
    public class ServiceReportNumberValidation : IValidation
    {
        private readonly SapValidationConfig _validationConfig;

        public ServiceReportNumberValidation(SapValidationConfig validationConfig)
        {
            _validationConfig = validationConfig;
        }
        
        public bool IsValid(params string[] parameters)
        {
            if (!String.IsNullOrEmpty(_validationConfig.SapNotificationNumberWebServiceUrl))
            {
                if (_validationConfig.UseSapWebService.ToUpper() == "TRUE")
                {
                    var turbineNumber = parameters[0];
                    var serviceReportNumber = parameters[1];

                    var notificationNumberValidator = new ServiceReportNumberValidator(_validationConfig.SapServiceReportNumberWebServiceUrl,
                        _validationConfig.SapWebServiceUserName,
                        _validationConfig.SapWebServicePassword);

                    return notificationNumberValidator.Validate(Convert.ToString(turbineNumber), Convert.ToString(serviceReportNumber));
                }
            }
            return true;
        }
    }
}
