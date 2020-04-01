using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Api.Authorization;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// CirLockController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CirLockController : ApiController
    {
        private readonly ICirLockService _cirLockService;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// CirLockController
        /// </summary>
        /// <param name="cirLockService"></param>
        /// <param name="log"></param>
        public CirLockController(ICirLockService cirLockService, ILogger log)
        {
            _cirLockService = cirLockService;
        }
        /// <summary>
        /// Lock
        /// </summary>
        /// <param name="cirId"></param>
        /// <param name="templateId"></param>
        /// <param name="currentUser"></param>
        /// /// <returns></returns>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult Lock(long cirId, string templateId, string currentUser)
        {
            try
            {
                //var user = Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                return Ok(_cirLockService.LockCir(cirId, templateId, currentUser));
            }
            catch (ArgumentException e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirLock/Lock for user " + User + "cirId: " + cirId + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirLock/Lock for user " + User + "cirId: " + cirId + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Unlock
        /// </summary>
        /// <param name="reportsToSync"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult Unlock(CirSubmissionSyncData reportsToSync, string templateId)
        {
            try
            {
                _cirLockService.UnlockCir(reportsToSync, templateId);
                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirLock/Unlock for user " + User + "reportsToSync: " + reportsToSync + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}