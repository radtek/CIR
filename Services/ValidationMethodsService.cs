using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cir.Data.Access.Models;
using Cir.Data.Access.Validation;

namespace Cir.Data.Access.Services
{
    internal class ValidationMethodsService : IValidationMethodsService
    {
        public IList<ValidationMethodsModel> GetValidationMethods()
        {
            var validationMethodsList = new List<ValidationMethodsModel>();
            var type = typeof(IValidation);
            var types = Assembly.GetAssembly(type).GetTypes().Where(p => type.IsAssignableFrom(p));

            foreach(var nestedType in types)
            {
                var validationMethod = nestedType.GetMethod("IsValid");
                var validationAttrObject = validationMethod.GetCustomAttributes(typeof(ValidationAttribute), true).FirstOrDefault();

                if (validationAttrObject != null)
                {
                    var validationAttr = validationAttrObject as ValidationAttribute;
                    if(validationAttr != null)
                    {
                        var inputs = new List<ValidationInput>();

                        for(int i = 0; i < validationAttr.DataKeys.Length; i++)
                        {
                            inputs.Add(new ValidationInput { ControlKey = validationAttr.DataKeys[i], ControlName = validationAttr.DataNames[i]});
                        }

                        validationMethodsList.Add(new ValidationMethodsModel {
                            Key = validationAttr.Key,
                            Name = validationAttr.DisplayName,
                            ValidationInputs = inputs
                        });
                    }
                }
            }
            return validationMethodsList;
        }
    }
}
