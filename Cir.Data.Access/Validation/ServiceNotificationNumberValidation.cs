using System;
using Cir.Data.Access.Models;
using Cir.SapIntegrator.Validation;

namespace Cir.Data.Access.Validation
{
    public class ServiceNotificationNumberValidation : IValidation
    {
        private readonly SapValidationConfig _validationConfig;

        public ServiceNotificationNumberValidation(SapValidationConfig validationConfig)
        {
            _validationConfig = validationConfig;
        }
        
        public bool IsValid(params string[] parameters)
        {
            if (!String.IsNullOrEmpty(_validationConfig.SapServiceReportNumberWebServiceUrl))
            {
                if (_validationConfig.UseSapWebService.ToUpper() == "TRUE")
                {
                    var turbineNumber = parameters[0];
                    var notificationNumber = parameters[1];

                    var notificationNumberValidator = new NotificationNumberValidator(_validationConfig.SapNotificationNumberWebServiceUrl,
                        _validationConfig.SapWebServiceUserName,
                        _validationConfig.SapWebServicePassword);

                    return notificationNumberValidator.Validate(Convert.ToString(turbineNumber), Convert.ToString(notificationNumber));
                }
            }
            return true;
        }
    }
}
