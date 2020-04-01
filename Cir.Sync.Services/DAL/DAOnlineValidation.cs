using System.Linq;
using System.Configuration;
using System.Data;
using Cir.Sync.Services.Edmx;

namespace Cir.Sync.Services.DAL
{
    public class DAOnlineValidation
    {

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public static bool ValidateTurbineNumber(string TurbineNumber)
        {
            bool IsTurbineExist = false;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var oTurbine = (from s in context.TurbineData
                                where s.TurbineId == TurbineNumber.Trim()
                                select s).FirstOrDefault();
                if (oTurbine != null)
                {
                    var objTurbine = DACIRData.GetTurbineRecord(TurbineNumber, context);
                    if (objTurbine != null)
                    {
                        //if (objTurbine.TurbineMatrixId > 0)
                        {
                            IsTurbineExist = true;
                        }
                    }
                }
              
             
            }

            return IsTurbineExist;
        }

        public static CIR.TurbineProperties ValidateGetTurbineData(string TurbineNumber)
        {
            //bool IsTurbineExist = false;
            CIR.TurbineProperties objTurbine = new CIR.TurbineProperties();

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var oTurbine = (from s in context.TurbineData
                                where s.TurbineId == TurbineNumber.Trim()
                                select s).FirstOrDefault();
                if (oTurbine != null)
                {
                    objTurbine = DACIRData.GetTurbineRecord(TurbineNumber, context);
                }
            }
            return objTurbine;
        }

        public static bool ValidateCIMCaseNumber(string CIMCaseNumber)
        {
            bool IsSIMCaseExist = false;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var intCIMCaseNumber = int.Parse(CIMCaseNumber);
                var c = context.CIMCase.Where(t => t.CaseNo == intCIMCaseNumber).Count();
                if (c > 0)
                    IsSIMCaseExist = true;
            }

            return IsSIMCaseExist;
        }

        public static bool ValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber)
        {
            bool IsServiceOrder = false;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                //ServiceReportNumberType.Name.ToUpper() == "MAM/SAP"
                if (DACirValidator.IsValidServiceReportNumber(ServiceReportNumber, TurbineNumber))
                {
                    IsServiceOrder = true;
                }
            }
            return IsServiceOrder;
        }

        public static bool ValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber)
        {
            bool IsServiceNotification = false;
            if (!string.IsNullOrWhiteSpace(ServiceNotificationNumber) && ServiceNotificationNumber != "null")
            {
                //ServiceReportNumberType.Name.ToUpper() == "MAM/SAP"
                if (DACirValidator.IsValidNotificationNumber(ServiceNotificationNumber, TurbineNumber))
                {
                    IsServiceNotification = true;
                }
            }
            else
            {
                IsServiceNotification = true;
            }
            return IsServiceNotification;
        }
    }
}