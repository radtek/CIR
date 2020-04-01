<%@ WebHandler Language="C#" Class="MailArchiveDownload" %>

using System;
using System.Web;
using Cir.Common.MailArchive;
using CirController = Cir.Business.Cir.Controller;
using CirContext = Cir.Business.Context;
using CirEnvironment = Cir.Business.Environment;

public class MailArchiveDownload : FileDownloadBase {

  protected override string IdParameterName {
    get {
      return "id";
    }
  }

  protected override void ProcessRequest(long idParameter) {
  	var controller = new Cir.Business.MailArchive.Controller(CirContext.Environment);
  	var mail = controller.GetArchivedMail(idParameter);
  	if(mail == null) {
  		ErrorResponse(1);
  		return;
  	}
  	if(string.IsNullOrEmpty(mail.Mail)) {
  		ErrorResponse(2);
  		return;
  	}
  	string fileName = "message";
  	switch(mail.Type) {
  		case MailType.FirstNotification:
  			fileName = "First notification";
  			break;
  		case MailType.SecondNotification:
  			fileName = "Second notification";
  			break;
  		case MailType.FirstNotificationReceipt:
  			fileName = "First notification reciept";
  			break;
  		case MailType.SecondNotificationReceipt:
  			fileName = "Second notification reciept";
  			break;
  		default:
  			ErrorResponse(3);
  			return;
  	}
  	WriteFile(fileName + ".eml", null, mail.Mail);
  }
}