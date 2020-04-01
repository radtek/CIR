using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCirCommentHistory
    {
       
        /// <summary>
        /// Get Cir Comment Historys
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static List<CirCommentHistorys> GetCirCommentHistory(long CirDataId)
        {
            return DAL.DACirCommentHistory.GetCirCommentHistory(CirDataId);

        }

        /// <summary>
        /// Get Cir Comment Historys
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        public static List<CirCommentHistorys> GetCirCommentHistoryByCirId(long CirId)
        {
            return DAL.DACirCommentHistory.GetCirCommentHistoryByCirId(CirId);

        }


        /// <summary>
        /// save Cir Comment Historys
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        /// 
        public static CirCommentHistorys SaveCirCommentHistory(CirCommentHistorys CirCommentHistory)
        {

            return DAL.DACirCommentHistory.SaveCirCommentHistory(CirCommentHistory);
        }
        
    }
}