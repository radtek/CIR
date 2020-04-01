using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services;
using Cir.Sync.Services.Edmx;

using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DataContracts;
using System.Data.Objects;


namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data access for Standard text
    /// </summary>
    public static class DACirCommentHistory
    {

        public static List<DataContracts.CirCommentHistorys> GetCirCommentHistory(long CirDataId)
        {
            List<DataContracts.CirCommentHistorys> lstCirCommentHistory = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                List<Edmx.CirCommentHistory> lstEdCirCommentHistory = (from s in context.CirCommentHistory
                                                                       where s.CirDataId == CirDataId
                                                                  select s).ToList();


                if (!ReferenceEquals(lstEdCirCommentHistory, null))
                {
                    lstCirCommentHistory = new List<DataContracts.CirCommentHistorys>();
                    foreach (Edmx.CirCommentHistory e in lstEdCirCommentHistory)
                    {
                        lstCirCommentHistory.Add(new DataContracts.CirCommentHistorys()
                        {     
                            CirCommentHistoryId = e.CirCommentHistoryId,
                            CirDataId= e.CirDataId,
                            Comment = e.Comment,
                            Date= e.Date,
                            Initials = e.Initials,
                            Type = e.Type });
                    }
                }               
            }

            return lstCirCommentHistory;

        }
                                   


        public static List<DataContracts.CirCommentHistorys> GetCirCommentHistoryByCirId(long CirId)
        {
            List<DataContracts.CirCommentHistorys> lstCirCommentHistory = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var lstEdCirCommentHistory = (from x in context.CirData
                                              join c in context.CirCommentHistory on x.CirDataId equals c.CirDataId into cm
                                              from c in cm.DefaultIfEmpty()
                                              where x.CirId == CirId
                                              orderby x.Created
                                              select new { CirCommentHistoryId = (c == null ? 0 : c.CirCommentHistoryId), Type = (c == null ? new byte() : c.Type), x.CirDataId, x.Created, x.CreatedBy, c.Initials, Comment = ((c == null) ? "" : c.Comment) }).ToArray();

                if (!ReferenceEquals(lstEdCirCommentHistory, null))
                {
                    lstCirCommentHistory = new List<DataContracts.CirCommentHistorys>();
                    foreach (var e in lstEdCirCommentHistory)
                    {
                        lstCirCommentHistory.Add(new DataContracts.CirCommentHistorys()
                        {
                            CirCommentHistoryId = e.CirCommentHistoryId,
                            CirDataId = e.CirDataId,
                            Comment = e.Comment,
                            Date = e.Created,
                            Initials = e.Initials ?? e.CreatedBy,
                            Type = e.Type
                        });
                    }
                }

            }

            return lstCirCommentHistory;

        }


        /// <summary>
        /// Save and update for CirCommentHistorys text
        /// </summary>
        /// <param name="StandardText">Object of standard text</param>
        /// <returns></returns>
        public static DataContracts.CirCommentHistorys SaveCirCommentHistory(DataContracts.CirCommentHistorys CirCommentHistorys)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.CirCommentHistory objCirCommentHistorys = (from s in context.CirCommentHistory
                                                          where s.CirDataId == CirCommentHistorys.CirDataId
                                                          select s).FirstOrDefault();


                objCirCommentHistorys = new Edmx.CirCommentHistory();
                objCirCommentHistorys.CirCommentHistoryId = CirCommentHistorys.CirCommentHistoryId;
                objCirCommentHistorys.CirDataId = CirCommentHistorys.CirDataId;
                objCirCommentHistorys.Comment = CirCommentHistorys.Comment;
                objCirCommentHistorys.Date = DateTime.Now;
                objCirCommentHistorys.Initials = CirCommentHistorys.Initials;
                objCirCommentHistorys.Type = CirCommentHistorys.Type;
                context.CirCommentHistory.Add(objCirCommentHistorys);
               

                context.SaveChanges();

                if (CirCommentHistorys.CirCommentHistoryId == 0)
                    CirCommentHistorys.CirCommentHistoryId = objCirCommentHistorys.CirCommentHistoryId;
            }

            return CirCommentHistorys;
        }

    }
}