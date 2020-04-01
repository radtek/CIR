using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLGIRReport
    {
        public static bool GenerateGIRReport(long GirDataID)
        {
            return DAL.DAGIRReport.RenderGirReport(GirDataID);

        }
        public static Gir GetGirPDF(long GirDataID)
        {
            return DAL.DAGIRReport.GetGirPDF(GirDataID);

        }

        public static bool SaveCIRPdf(string uid, int state, string html = "", string name = "")
        {
            return DAL.DAGIRReport.SaveCIRPdf(uid, state, html, name);

        }
        public static Gir GetCIRPdf(long CirDataId, long CirId = 0)
        {
            return DAL.DAGIRReport.GetCIRPdf(CirDataId, CirId);

        }

        public static Gir GetCIRPdfZip(string CirDataIds)
        {
            return DAL.DAGIRReport.GetCIRPdfZip(CirDataIds);

        }
        public static GirFile GenerateNewGIRReport(long GirDataID, int languageId)
        {
            return DAL.DAGIRReport.RenderGirReport(GirDataID, languageId);

        }
    }
}