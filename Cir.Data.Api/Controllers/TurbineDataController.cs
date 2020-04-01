using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.CirSyncService;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// Turbine data controller
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class TurbineDataController : ApiController
    {
        private TelemetryClient _telemetryClient = new TelemetryClient();
        private readonly SyncServiceClient _serviceClient;

        /// <summary>
        /// Turbine data controller
        /// </summary>
        /// <param name="log"></param>
        public TurbineDataController(ILogger log)
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        /// <summary>
        /// Get turbine details
        /// </summary>
        /// <param name="turbineId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetTurbineDetails(string turbineId)
        {
            try
            {
                var turbineDetails = _serviceClient.ValidateGetTurbineData(turbineId);
                
                return Ok(turbineDetails);
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in TurbineDataController/GetTurbineDetails for" + User + "Turbine Id: " + turbineId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}