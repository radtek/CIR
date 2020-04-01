using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Cir.Sync.Services.ErrorHandling
{
    class ErrorCode
    {

        public enum ReturnCodeVal
        {
            [Description("Json is null")]
            Null = -1,
            [Description("Success")]
            Success = 1,
            [Description("No ID")]
            Blank = 0,
            [Description("ID does not exists")]
            NotFound = 101,
            [Description("Validation Failed")]
            ValidationFailed = 102,
            [Description("Turbine Number does not exist")]
            TurbineNotExists = 103,
            [Description("Invalid Turbine Number")]
            InvalidTurbine = 104
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

}