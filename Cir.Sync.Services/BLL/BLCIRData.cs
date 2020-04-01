using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.CIR;

namespace Cir.Sync.Services.BLL
{
    /// <summary>
    /// Business layer of CIR Data
    /// </summary>
    public static class BLCIRData
    {
        /// <summary>
        /// Save cir data
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static CirResponse SaveCIRData(ComponentInspectionReport CIRList)
        {
            return DAL.DACIRData.SaveCIRData(CIRList);
        }
        /// <summary>
        /// Save cir data
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static CirResponse UpdatePDFData()
        {
            return DAL.DACIRData.UpdatePDFData();
        }
        /// <summary>
        /// Save cir data
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static ComponentInspectionReport GetCIRDatabyCIRID(Int64 CIRID)
        {
            return DAL.DACIRData.GetCIRDatabyCIRID(CIRID);
        }

        /// <summary>
        /// Cir quick search
        /// </summary>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static List<ComponentInspectionReport> CirQuickSearch(CirQuickSearch Search)
        {
            return DAL.DACIRData.CirQuickSearch(
                SearchItems: Search
                );
        }

        public static bool SendFirstNotification(long CirDataId, long CirID)
        {
            return DAL.DACIRView.SendFirstNotification(CirDataId, CirID);
        }

        /// <summary>
        ///  Unlock Cir Data By CirID
        /// </summary>
        /// <param name="CirID"></param>
        /// <returns>true/false</returns>
        /// 
        public static bool UnlockCirDataByCirID(long CirID)
        {
            return DAL.DACIRData.UnlockCirDataByCirID(CirID);
        }
        public static bool LockCirDataByCirID(long CirID, string modifiedby)
        {
            return DAL.DACIRData.LockCirDataByCirID(CirID, modifiedby);
        }
        /// <summary>
        ///  Get Cir Status By CirID
        /// </summary>
        /// <param name= List "CirIDs"></param>
        /// <returns>true/false</returns>
        /// 
        public static List<Cir.Sync.Services.CIR.CirStateResponse> GetCirStateByCirIDs(List<Cir.Sync.Services.CIR.CirStateResponse> CirIDs)
        {
             return DAL.DACIRData.GetCirStateByCirIDs(CirIDs);
            
        }
    }
}