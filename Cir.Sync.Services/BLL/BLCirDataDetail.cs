using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCirDataDetail
    {
       

        /// <summary>
        /// Get CirDataDetail
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static CirDataDetails GetCirDataDetail(long CirDataId)
        {
            return DAL.DACirDataDetail.GetCirDataDetail(CirDataId);

        }

        
    }
}