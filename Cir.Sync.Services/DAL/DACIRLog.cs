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
    public static class DACIRLog
    {

        public static List<DataContracts.CirLogs> GetCirLog(long CirDataId)
        {
            List<DataContracts.CirLogs> lstCirLog = null;

            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                var CirId = context.CirData.Where(x => x.CirDataId == CirDataId).Select(x => x.CirId).FirstOrDefault();
                var CirDataIdList = context.CirData.Where(x => x.CirId == CirId).Select(x => x.CirDataId).ToList();
                List<Edmx.CirLog> lstEdCirLog = (from s in context.CirLog
                                                 where CirDataIdList.Contains(s.CirDataId)
                                                 select s).ToList();

                if (!ReferenceEquals(lstEdCirLog, null))
                {
                    lstCirLog = new List<DataContracts.CirLogs>();
                    lstCirLog.AddRange(lstEdCirLog.Select(oCirLog => new DataContracts.CirLogs() { CirLogId = oCirLog.CirLogId, CirDataId = oCirLog.CirDataId, Timestamp = oCirLog.Timestamp, Text = oCirLog.Text, Type = oCirLog.Type, Initials = oCirLog.Initials }).OrderBy(x => x.Timestamp).ToList());
                }
            }

            return lstCirLog;

        }

        public static void SaveCirLog(long CirDataId,string text,LogType type,string initials)
        {
           

            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                Edmx.CirLog cirLog = new CirLog();
                cirLog.Text = text;
                cirLog.CirDataId = CirDataId;
                cirLog.Timestamp = DateTime.UtcNow;
                cirLog.Type = (short)type;
                cirLog.Initials = initials;
                context.CirLog.Add(cirLog);
                context.SaveChanges();
              
            }

          

        }

    }
    
}