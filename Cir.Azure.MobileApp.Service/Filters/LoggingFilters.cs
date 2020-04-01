using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Microsoft.ApplicationInsights.Web;
using Microsoft.ApplicationInsights;
using System.Configuration;

namespace Cir.Azure.MobileApp.Service.Filters
{
    public class LoggingFilters : ExceptionFilterAttribute
    {
        TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// Loggin the Erros in application insight MobileApp Dev
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            if (filterContext != null && filterContext.Exception != null)
            {                
                try
                {
                    _telemetryClient.TrackEvent("Description: Graph Api Exception - " + filterContext.Exception.Message);
                    _telemetryClient.TrackException(filterContext.Exception); 
                }
                catch (Exception ex)
                {
                    _telemetryClient.TrackException(filterContext.Exception);
                    _telemetryClient.TrackException(ex);
                    throw ex;
                }
            }             
        }
    }
}