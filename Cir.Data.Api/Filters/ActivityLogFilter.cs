using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace Cir.Data.Api.Filters
{
    /// <summary>
    /// Activity log filter
    /// </summary>
    public class ActivityLogFilter : ActionFilterAttribute
    {
        TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// On action executing
        /// </summary>
        /// <param name="filterContext"></param>
        /// 
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (filterContext != null && filterContext.ActionDescriptor != null)
            {
                try
                {
                    if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "CreateCir" || filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "CirSubmissionData")
                    {
                        _telemetryClient.TrackEvent("Action Name: " + filterContext.ActionDescriptor.ActionName + " Controller Name:  " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + " Request Uri: " + filterContext.ControllerContext.Request.RequestUri);
                    }
                }
                catch (Exception ex)
                {
                    _telemetryClient.TrackException(ex);
                    throw ex;
                }
            }
        }
    }
}