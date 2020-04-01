using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cir.WebApp.Offline.Utility;
using Cir.WebApp.Offline.Models.Cir.BIR;

namespace Cir.WebApp.Offline.Controllers.Cir
{

    public partial class CirController : CirBaseController
    {
        //
        // GET: /BIR/

        [ActionName("Manage-BIR")]
        public ActionResult PopulateBIR()
        {
           return View("~/Views/Cir/BIR/BIRView.aspx");
        }

        [ActionName("Manage-GIR")]
        public ActionResult PopulateGeneratorReport()
        {
            return View("~/Views/Cir/BIR/GIRView.aspx");
        }

        [ActionName("Manage-GBXIR")]
        public ActionResult PopulateGearBoxReport()
        {
            return View("~/Views/Cir/BIR/GBXIRView.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        [ActionName("BIRCirdetail")]
        public ActionResult BIRCirdetail(long? BirDataID)
        {
            return View("~/Views/Cir/BIR/CirDetail.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        [ActionName("Create-BIR")]
        public ActionResult CreateBIR()
        {
            return View("~/Views/Cir/BIR/CreateBIR.aspx");
        }

        [ActionName("DownloadBir")]
        public void BirDownlaod()
        {
            //string pdfPath = string.Empty; ;// Cir.WebApp.Offline.Controllers.Old_App_code.BIRPdfReport.GetWord(wordBytes: birData, DocumentName: birView.BirCode);
            //System.IO.FileInfo file = new System.IO.FileInfo(pdfPath);
            //if ((file.Exists))
            //{
                HttpContext.Response.Clear();
                HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=na");
                HttpContext.Response.AddHeader("Content-Length", "100");
                HttpContext.Response.ContentType = "application/octet-stream";
                //HttpContext.Response.WriteFile("na");
                HttpContext.Response.End();
                HttpContext.Response.Close();
                //file = null;
            //}
        }


    }
}
