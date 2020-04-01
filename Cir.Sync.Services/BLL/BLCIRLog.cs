using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCIRLog
    {
       

        /// <summary>
        /// Get CIRLog
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static List<CirLogs> GetCIRLog(long CirDataId)
        {
            return DAL.DACIRLog.GetCirLog(CirDataId);

        }

        
    }
}