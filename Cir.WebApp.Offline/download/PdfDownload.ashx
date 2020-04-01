<%@ WebHandler Language="C#" Class="PdfDownload" %>

using System;
using System.Web;
using PdfController = Cir.Business.Pdf.Controller;
using CirController = Cir.Business.Cir.Controller;
using CirContext = Cir.Business.Context;
using CirEnvironment = Cir.Business.Environment;

public class PdfDownload : FileDownloadBase {
  protected override string IdParameterName {
    get { return "id"; }
  }

  protected override void ProcessRequest(long idParameter) {
    var cirController = new CirController(CirContext.Environment);
    var cirData = cirController.GetCir(idParameter, false);
    if (cirData == null) {
      ErrorResponse(1);
      return;
    }
    
    var pdfController = new PdfController(CirContext.Environment);
    var pdfFile = pdfController.GetPdf(cirData.UniqueId, cirData.State);
    if (pdfFile == null) {
      ErrorResponse(2);
      return;
    }

    WriteFile(cirData.Filename.Replace(".xml", ".pdf"), @"application/pdf", pdfFile);
  }
}
/*
public class PdfDownloadX : IHttpHandler {
  private const string CirDataIdVariableName = "id";

  public void ProcessRequest(HttpContext context) {
    if (context.Request.QueryString[CirDataIdVariableName] != null) {
      byte[] pdfFile = null;
      try {
        long cirDataId = -1;
        if (long.TryParse(context.Request.QueryString[CirDataIdVariableName], out cirDataId)) {
          var cirContext = new CirContext(context.User.Identity.Name);
          var cirController = new CirController(cirContext.Environment);

          var cirData = cirController.GetCir(cirDataId, false);
          if (cirData == null) {
            context.Response.Write(ErrorResponse(1));
            return;
          }
          
          var pdfController = new PdfController(cirContext.Environment);

          pdfFile = pdfController.GetPdf(cirData.UniqueId, cirData.State);
          if (pdfFile != null) {
            // response the binary PDF
            context.Response.Clear();
            // force filename
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + cirData.Filename.Replace(".xml", ".pdf"));
            context.Response.Buffer = true;
            context.Response.ContentType = @"application/pdf";
            context.Response.BinaryWrite(pdfFile);
            context.Response.Flush();
            context.Response.End();
          }
          else {
            context.Response.Write(ErrorResponse(2));
          }
        }
        else {
          context.Response.Write(ErrorResponse(3));
        }
      }
      catch {
        context.Response.Write(ErrorResponse(4));
      }
    }
    else {
      context.Response.Write(ErrorResponse(5));
    }
  }

  private string ErrorResponse(int errorCode) {
    return string.Format(@"<html><head><title>Error</title></head><body>No PDF was found (error code: {0})</body></html>", errorCode);
  }

  public bool IsReusable {
    get {
      return false;
    }
  }

}*/