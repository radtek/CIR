using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLStandardText
    {
        /// <summary>
        /// get CommonInspectionReportType 
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        /// 
        public static List<ComponentInspectionReportType> GetCommonInspectionReportType()
        {
            return DAL.DAManageStandardText.GetComponentInspectionReportType();

        }

        /// <summary>
        /// Get Standard Text
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static List<StandardTexts> GetStandardText(Int32 CommonInspectionReportID)
        {
           return DAL.DAManageStandardText.GetStandardText(CommonInspectionReportID);

        }

        /// <summary>
        /// Get Standard Text by ID
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static StandardTexts GetStandardTextbyID(Int64 SID)
        {         
            return DAL.DAManageStandardText.GetStandardTextbyID(SID);
        }

        /// <summary>
        /// save CommonInspectionReportType 
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        /// 
        public static StandardTexts SaveStandardText(StandardTexts StandardText)
        {

            return DAL.DAManageStandardText.SaveStandardTextData(StandardText);
        }
        
    }
}