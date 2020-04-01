using System;
using Cir.Data.Access.Models;
using Cir.SapIntegrator.Validation;

namespace Cir.Data.Access.Validation
{
    internal class ServiceNotificationNumberValidation : IValidation
    {
        public const string MethodKey = "ServiceNotificationNumber";
        public static string DisplayKey => MethodKey;
        public string Name => "Service Notification Number";
        private readonly SapValidationConfig _validationConfig;

        public ServiceNotificationNumberValidation(SapValidationConfig validationConfig)
        {
            _validationConfig = validationConfig;
        }
        
        [Validation(Key = MethodKey, 
            DisplayName = "Service Notification Number",
            DataKeys = new string[] { "turbineNumberControlId", "serviceNotificationNumberControlId" },
            DataNames = new string[] { "Turbine Number", "Service Notification Number" })]
        public bool IsValid(dynamic cirSubmission, dynamic rule)
        {
            if (!String.IsNullOrEmpty(_validationConfig.SapServiceReportNumberWebServiceUrl))
            {
                if (_validationConfig.UseSapWebService.ToUpper() == "TRUE")
                {
                    var turbineNumber = cirSubmission.Data[rule.turbineNumberControlId.Value];
                    var notificationNumber = cirSubmission.Data[rule.serviceNotificationNumberControlId.Value];

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
