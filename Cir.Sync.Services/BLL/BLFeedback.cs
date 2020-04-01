using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLFeedback
    {
        /// <summary>
        /// get FeedbackType 
        /// </summary>
        /// <param name="CommonInspectionReportID"></param>
        /// <returns></returns>
        /// 
        public static List<FeedbackType> GetFeedbackType()
        {
            return DAL.DAFeedback.GetFeedbackType();

        }

        /// <summary>
        /// save Feedback 
        /// </summary>
        /// <param name="Feedback"></param>
        /// <returns></returns>
        /// 
        public static Feedback SaveFeedback(Feedback FeedbackDetais)
        {

            return DAL.DAFeedback.SaveFeedback(FeedbackDetais);
        }

        public static List<Feedback> GetAllFeedbacks()
        {
            return DAL.DAFeedback.GetAllFeedbacks();
        }

        public static bool DeleteFeedback(long id)
        {
            return DAL.DAFeedback.DeleteFeedback(id);
        }
    }
}