<%@ WebHandler Language="C#" Class="BirDownload" %>

using System;
using System.Web;
using BirPdfController = Cir.Business.BirPdf.Controller;
using CirEnvironment = Cir.Business.Environment;
using MetadataController = Cir.Business.Metadata.Controller;
namespace Cir.WebApp.Offline.Views.Cir.download
{
    public class BirDownload : FileDownloadBase
    {
        protected override string IdParameterName
        {
            get { return "id"; }
        }

        protected override void ProcessRequest(long idParameter)
        {
            var birPdfController = new BirPdfController(CirContext.Environment);
            var metadataController = new MetadataController(CirContext.Environment);

            string RelatedCIR = string.Empty;

            System.Byte[] birData = birPdfController.GetPdf(idParameter);

            var birView = metadataController.GetBirDataByID
                                    (
                                        BirID: idParameter,
                                        RelatedCIR: out RelatedCIR
                                    );

            if (birData == null)
            {
                ErrorResponse(1);
                return;
            }

            string pdfPath = Cir.WebApp.Old_App_Code.BIRPdfReport.GetPdf(wordBytes: birData, PdfName: birView.BirCode);
            System.IO.FileInfo file = new System.IO.FileInfo(pdfPath);
            if ((file.Exists))
            {
                HttpContext.Response.Clear();
                HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                HttpContext.Response.AddHeader("Content-Length", file.Length.ToString());
                HttpContext.Response.ContentType = "application/octet-stream";
                HttpContext.Response.WriteFile(file.FullName);
                HttpContext.Response.End();
                HttpContext.Response.Close();
                file = null;
            }
        }


    }
}