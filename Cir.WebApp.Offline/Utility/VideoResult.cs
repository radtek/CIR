using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Cir.WebApp.Offline.Utility
{
    public class VideoResult : ActionResult 
    {
        private readonly string _filePath;

        public VideoResult(string filePath)
        {
            _filePath = filePath;
        }
        /// <summary> 
        /// The below method will respond with the Video file 
        /// </summary> 
        /// <param name="context"></param> 
        public override void ExecuteResult(ControllerContext context) 
        { 
            var videoFilePath = HostingEnvironment.MapPath(_filePath);
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=vestas.mp4"); 
             
            var file = new FileInfo(videoFilePath); 
            if (file.Exists) 
            { 
                var stream = file.OpenRead(); 
                var bytesinfile = new byte[stream.Length]; 
                stream.Read(bytesinfile, 0, (int)file.Length); 
                context.HttpContext.Response.BinaryWrite(bytesinfile); 
            } 
        } 
    }
}