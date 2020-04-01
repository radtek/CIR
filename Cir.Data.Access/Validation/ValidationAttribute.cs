using System;

namespace Cir.Data.Access.Validation
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class ValidationAttribute : Attribute
    {
        public string Key;
        public string DisplayName;
        public string[] DataKeys;
        public string[] DataNames;
    }
}
