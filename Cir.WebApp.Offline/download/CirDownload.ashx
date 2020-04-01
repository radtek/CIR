<%@ WebHandler Language="C#" Class="CirDownload" %>

using System;
using System.Web;
using CirController = Cir.Business.Cir.Controller;
using CirContext = Cir.Business.Context;
using CirEnvironment = Cir.Business.Environment;

public class CirDownload : FileDownloadBase {

  protected override string IdParameterName {
    get {
      return "id";
    }
  }

  protected override void ProcessRequest(long idParameter) {
    var cirController = new CirController(CirContext.Environment);
    var cirData = cirController.GetCir(idParameter, true, true);
    if (cirData == null) {
      ErrorResponse(1);
      return;
    }
    if (cirData.Xml == null) {
      ErrorResponse(2);
      return;
    }
    WriteFile(cirData.Filename, @"application/ms-infopath.xml", cirData.Xml.OuterXml);
  }
}