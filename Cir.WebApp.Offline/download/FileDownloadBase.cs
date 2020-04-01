using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FileDownloadBase
/// </summary>
public abstract class FileDownloadBase : IHttpHandler {
    private HttpContext _context = null;
    //private Cir.Business.Context _cirContext = null;

    //protected abstract string IdParameterName { get; }

    public FileDownloadBase()
    {
    }

    //#region IHttpHandler Members

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public virtual void ProcessRequest(HttpContext context) {
    //    _context = context;
    //    _cirContext = new Cir.Business.Context(context.User.Identity.Name);

    //    long idParameter = -1;
    //    if (long.TryParse(context.Request.QueryString[IdParameterName], out idParameter)) {
    //        ProcessRequest(idParameter);
    //    }
    //    else {
    //        ErrorResponse(0);
    //    }
   }

    //protected Cir.Business.Context CirContext {
    //    get {
    //        return _cirContext;
    //    }
    //}

    protected HttpContext HttpContext
    {
        get
        {
            if (_context == null)
            {
                throw new ApplicationException("Context was not initialized");
            }
            return _context;
        }
    }

    //#endregion

    //protected abstract void ProcessRequest(long idParameter);

    //protected void ErrorResponse(int errorCode) {
    //    HttpContext.Response.Write(string.Format(@"<html><head><title>Error</title></head><body>No file was found (error code: {0})</body></html>", errorCode));
    //}

    //protected void WriteFile(string filename, string contentType, string fileContents) {
    //    try {
    //        WriteFileHeader(filename, contentType);
    //        HttpContext.Response.BufferOutput = true;
    //        HttpContext.Response.Write(fileContents);
    //        HttpContext.Response.Flush();
    //    }
    //    catch {
			
    //    }
    //    finally {
    //        HttpContext.Response.End();			
    //    }
    //}
    //protected void WriteFile(string filename,  string contentType, byte[] fileContents) {
    //    try {
    //        WriteFileHeader(filename, contentType);
    //        HttpContext.Response.BufferOutput = true;
    //        HttpContext.Response.BinaryWrite(fileContents);
    //        HttpContext.Response.Flush();
    //    }
    //    catch {

    //    }
    //    finally {
    //        HttpContext.Response.End();
    //    }
    //}
    //private void WriteFileHeader(string filename, string contentType) {
    //    HttpContext.Response.Clear();
    //    // force filename
    //    HttpContext.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlPathEncode(filename));
    //    //HttpContext.Response.Buffer = true;
    //    if (!string.IsNullOrEmpty(contentType)) {
    //        HttpContext.Response.ContentType = contentType;
    //    }
    //}
}
