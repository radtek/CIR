using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLCIRReport
    {
        public delegate bool GeneratePDFDelegate(long cirid, string path,string licpath);
        public static bool RenderCirReport(long CirID)
        {
            string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
            string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
            //return DAL.DACIRReport.RenderCirReport(CirID, DocumentPath);
            GeneratePDFDelegate d = null;
            d = new GeneratePDFDelegate(DAL.DACIRReport.RenderCirReport);
            IAsyncResult R = null;
            R = d.BeginInvoke(CirID, DocumentPath,SpireLicensePath, null, null); //invoking the method
            return true;
        }
      
    }
}