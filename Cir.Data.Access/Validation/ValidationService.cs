using System;
namespace Cir.Data.Access.Validation
{
    internal class ValidationService : IValidationService
    {
        public bool Validate<T>(params string[] parameters) where T : class
        {
            return ValidationFactory<T>.GetInstance().IsValid(parameters);
        }
    }
}
