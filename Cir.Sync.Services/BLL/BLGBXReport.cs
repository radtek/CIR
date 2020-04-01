using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLGBXReport
    {
        public static bool GenerateGBXIRReport(long GbxirDataID)
        {
            return DAL.DAGBXReport.RenderGbxReport(GbxirDataID);

        }
        public static Gbx GetGbxPDF(long GbxirDataID)
        {
            return DAL.DAGBXReport.GetGbxPDF(GbxirDataID);

        }

        public static bool SaveCIRPdf(string uid, int state, string html = "", string name = "")
        {
            return DAL.DAGBXReport.SaveCIRPdf(uid, state, html, name);

        }
        public static Gbx GetCIRPdf(long CirDataId, long CirId = 0)
        {
            return DAL.DAGBXReport.GetCIRPdf(CirDataId, CirId);

        }

        public static Gbx GetCIRPdfZip(string CirDataIds)
        {
            return DAL.DAGBXReport.GetCIRPdfZip(CirDataIds);

        }
        public static GbxFile RenderGBXirReport(long GirDataID, int languageId)
        {
            return DAL.DAGBXReport.RenderGBXirReport(GirDataID, languageId);

        }
    }
}