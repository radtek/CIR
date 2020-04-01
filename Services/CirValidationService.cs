using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Validation;

namespace Cir.Data.Access.Services
{
    internal class CirValidationService : ICirValidationService
    {
        private SapValidationConfig _validationConfig;
        private Dictionary<string, IValidation> _validationClasses;

        public CirValidationService(SapValidationConfig validationConfig)
        {
            _validationConfig = validationConfig;

            _validationClasses = new Dictionary<string, IValidation>();
            _validationClasses.Add(ServiceReportNumberValidation.DisplayKey, new ServiceReportNumberValidation(_validationConfig));
            _validationClasses.Add(ServiceNotificationNumberValidation.DisplayKey, new ServiceNotificationNumberValidation(_validationConfig));
            _validationClasses.Add(TurbineNumberValidation.DisplayKey, new TurbineNumberValidation());
        }

        public bool IsDataValid(CirSubmissionData cirSubmissionData)
        {
            bool isValid = true;
            foreach(var dataPart in cirSubmissionData.Data)
            {
                var dataName = dataPart.Name;
                if((dataName as string).ToLower().Contains("advancedvalidation"))
                {
                    var errorsList = new List<string>();

                    foreach(var rule in cirSubmissionData.Data[dataName].rules)
                    {
                        var ruleKey = rule.rule.key.Value as string;
                        if(!_validationClasses[ruleKey].IsValid(cirSubmissionData, rule))
                        {
                            errorsList.Add($"{_validationClasses[ruleKey].Name} is invalid.");
                            isValid = false;
                        }
                    }
                    cirSubmissionData.Data[dataName].errors = JArray.FromObject(errorsList);
                    break;
                }
            }

            return isValid;
        }
    }
}