using System;
using System.Web.Http.Filters;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Filters
{
    /// <summary>
    /// Exception log filter 
    /// </summary>
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
                    _telemetryClient.TrackEvent("Error Description: " + filterContext.Exception.Message);
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