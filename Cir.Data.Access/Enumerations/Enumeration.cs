using System;
using System.ComponentModel;
using System.Reflection;

namespace Cir.Data.Access.Enumerations
{
    public class Enumeration
    {

        public enum ErrorCodes
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
            InvalidTurbine = 104,
            [Description("The Turbine number and Notification number could not be matched in SAP")]
            MisMatchNotificationNumber = 105,
            [Description("The Turbine number and Service Report number could not be matched in SAP")]
            MisMatchServiceReportNumber = 106,
            [Description("The CIM Case number you have provided is invalid and does not exist in the system")]
            CIMCaseInvalid = 107,
            [Description("Validation Exception : Turbine Number")]
            ValidationFailedTurbineNumber = 108,
            [Description("Validation Exception : CIM Case Number ")]
            ValidationFailedCIMCaseNumber = 109,
            [Description("Validation Exception : SAP Notification/Service Report number")]
            ValidationFailedNotificationNumber = 110
        }

        public enum CirTemplate
        {
            BladeInspection = 1,
            Generator = 2,
            Gearbox = 3,
            Transformer = 4,
            General = 5,
            MainBearing = 6,
            Skiipack = 7,
            SimplifiedCIR = 8,
            BladeRepair = 9
        }
        public enum ReportType
        {
            Inspection = 1,
            Failure = 2,
            Repair = 3,
            Replacement = 4,
            Retrofit = 5,
            CMSInspection = 6
        }

        public enum CirMode
        {
            New = 1,
            Edit = 2,
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

        public enum MailType
        {
            None = 1,
            FirstNotification = 2,
            SecondNotification = 3,
            FirstNotificationReceipt = 4,
            SecondNotificationReceipt = 5
        }

        public enum LogType
        {
            All = 0,
            Information = 1,
            Error = 2,
            Warning = 3,
            Success = 4
        }
    }
}
