using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLBIRReport
    {
        public static bool GenerateBIRReport(long BirDataID)
        {
            
           return DAL.DABIRReport.RenderBirReport(BirDataID);

        }

        public static BirFile  GenerateNewBIRReport(long BirDataID,int languageId)
        {
            return DAL.DABIRReport.RenderBirReport(BirDataID, languageId);

        }
        public static Bir GetBirPDF(long BirDataID)
        {
            return DAL.DABIRReport.GetBirPDF(BirDataID);

        }

        public static bool SaveCIRPdf(string uid, int state, string html = "", string name = "")
        {
            return DAL.DABIRReport.SaveCIRPdf(uid,state, html,name);

        }
        public static Bir GetCIRPdf(long CirDataId, long CirId = 0)
        {
            return DAL.DABIRReport.GetCIRPdf(CirDataId, CirId);

        }

        public static CirPDFResponse GetCIRPdfForSQL(long CirId)
        {
            return DAL.DABIRReport.GetCIRPdfForSQL(CirId);
        }
        public static Bir GetCIRPdfZip(string CirDataIds)
        {
            return DAL.DABIRReport.GetCIRPdfZip(CirDataIds);

        }
    }
}