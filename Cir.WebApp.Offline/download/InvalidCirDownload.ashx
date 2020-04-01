<%@ WebHandler Language="C#" Class="InvalidCirDownload" %>

using System;
using System.Web;
using CirController = Cir.Business.Cir.Controller;
using CirContext = Cir.Business.Context;
using CirEnvironment = Cir.Business.Environment;

public class InvalidCirDownload : FileDownloadBase {
  protected override string IdParameterName {
    get { return "id"; }
  }

  protected override void ProcessRequest(long idParameter) {
    var cirController = new CirController(CirContext.Environment);
    var cir = cirController.GetInvalidCir(idParameter);
    if (cir == null) {
      ErrorResponse(1);
      return;
    }
    if (cir.Xml == null) {
      ErrorResponse(2);
      return;
    }

    WriteFile(cir.Filename, null, cir.Xml.OuterXml);
  }
}
