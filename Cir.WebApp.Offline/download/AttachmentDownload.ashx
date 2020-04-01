<%@ WebHandler Language="C#" Class="AttachmentDownload" %>

using System;
using System.Web;
using CirContext = Cir.Business.Context;
using AttachmentsController = Cir.Business.Attachments.Controller;

public class AttachmentDownload : FileDownloadBase {
  protected override string IdParameterName {
    get { return "fileid"; }
  }

  protected override void ProcessRequest(long idParameter) {
    var controller = new AttachmentsController(CirContext.Environment);

    var attachment = controller.GetAttachment(idParameter);

    if (attachment == null) {
      ErrorResponse(1);
      return;
    }
    if (attachment.BinaryData == null) {
      ErrorResponse(2);
      return;
    }

    WriteFile(attachment.Filename, null, attachment.BinaryData);
  }
}
