using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Tracing;
using System.Web.Http;
//using WebApi.Helpers;
using System.IO;
//using Microsoft.ApplicationInsights;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
 
namespace Cir.WebApp.Offline.Filters
{
    public class LoggingFilterAttribute : ExceptionFilterAttribute,IExceptionFilter
    {
        TelemetryClient _telemetryClient = new TelemetryClient();

        //public bool AllowMultiple { get { return true; } }
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loggin the Erros in application insight OfflineApp Dev
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            if (filterContext != null && filterContext.Exception != null)
            {
                try
                {
                    _telemetryClient.TrackEvent("Description: Offline App Exception - " + filterContext.Exception.Message);
                }
                catch (Exception ex)
                {
                    _telemetryClient.TrackException(filterContext.Exception);
                    _telemetryClient.TrackException(ex);
                    throw ex;
                }
            }
        }

        //TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// Loggin the events in application insight
        /// </summary>
        /// <param name="filterContext"></param>
        //public override void OnActionExecuting(HttpActionContext filterContext)
        //{
        //    _telemetryClient.Context.InstrumentationKey = ConfigurationManager.AppSettings["instrumentationKey"];
        //    try
        //   {
        //        _telemetryClient.TrackEvent("Controller : " + filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.ActionName);
        //    }
        //    catch (Exception ex)
        //    {
        //        _telemetryClient.TrackException(ex);
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Log the api calls in csv format to analyze api call history.
        /// </summary>
        /// <param name="filterContext"></param>
        //private static void APILogInCSV(HttpActionContext filterContext)


        //{
        //    string csvHeader = "Controller, Action, ExecutionDate";
        //    string csvFilename = HttpContext.Current.Server.MapPath("~/APILog/APILog.csv");

        //    string csv = string.Format("{0},{1},{2}", filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName, filterContext.ActionDescriptor.ActionName, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        //    if (!File.Exists(csvFilename))
        //        File.Create(csvFilename).Close();  
        //    string existingContents;
        //    using (StreamReader sr = new StreamReader(csvFilename))
        //    {
        //        existingContents = sr.ReadToEnd();
        //    }

        //    using (StreamWriter writetext = File.AppendText(csvFilename))
        //    {
        //        if (!existingContents.Contains(csvHeader))
        //        {
        //            writetext.WriteLine(csvHeader);
        //        }
        //        writetext.WriteLine(csv);
        //    }
        //}       
    }
}