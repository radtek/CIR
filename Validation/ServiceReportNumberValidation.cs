using System;
using Cir.Data.Access.Models;
using Cir.SapIntegrator.Validation;

namespace Cir.Data.Access.Validation
{
    internal class ServiceReportNumberValidation : IValidation
    {
        public const string MethodKey = "ServiceReportNumber";
        public static string DisplayKey => MethodKey;
        public string Name => "Service Report Number";
        private readonly SapValidationConfig _validationConfig;

        public ServiceReportNumberValidation(SapValidationConfig validationConfig)
        {
            _validationConfig = validationConfig;
        }

        [Validation(Key = MethodKey, 
            DisplayName = "Service Report Number", 
            DataKeys = new string[] { "turbineNumberControlId", "serviceReportNumberControlId" },
            DataNames = new string[] { "Turbine Number", "Service Report Number" })]
        public bool IsValid(dynamic cirSubmission, dynamic rule)
        {
            if (!String.IsNullOrEmpty(_validationConfig.SapNotificationNumberWebServiceUrl))
            {
                if (_validationConfig.UseSapWebService.ToUpper() == "TRUE")
                {
                    var turbineNumber = cirSubmission.Data[rule.turbineNumberControlId.Value];
                    var serviceReportNumber = cirSubmission.Data[rule.serviceReportNumberControlId.Value];

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
