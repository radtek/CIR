using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCirRevision
    {

        /// <summary>
        /// Added By : Siddharth Chauhan
        /// Date : 26-05-2016
        /// Description : To show and get data of Cir Revision.
        /// Task No. : 72518, 72519, 72520
        /// </summary>
        //Task No. : 72518, 72519 & 72520, 
        public static List<CirRevision> GetCirRevision(long CirDataId)
        {
            return DAL.DACirRevision.GetCirRevision(CirDataId);

        }

        public static CIR.ComponentInspectionReport GetCirRevisionData(long CirDataId)
        {
            return DAL.DACirRevision.GetCirRevisionData(CirDataId);

        }

    }
}