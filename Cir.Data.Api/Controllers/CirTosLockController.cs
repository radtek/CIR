using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services;
using Cir.Data.Api.Authorization;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// CirTosLockController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CirTosLockController : ApiController
    {
        private readonly ICirTosLockService _cirLockService;
        private TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// CirTosLockController
        /// </summary>
        /// <param name="cirLockService"></param>
        /// <param name="log"></param>
        public CirTosLockController(ICirTosLockService cirLockService, ILogger log)
        {
            _cirLockService = cirLockService;
        }

        /// <summary>
        /// Locks CIR after TOS specialist opened CIR in the system. Posts the lock to InspecTools.
        /// </summary>
        /// <param name="id">Guid of CIR</param>
        /// <param name="templateId">Guid of template of a given CIR</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult LockByTos(string id, string templateId)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                var lockedCir = _cirLockService.LockCirByTos(id, templateId, user.DisplayName);
                return Ok(lockedCir);
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirTosLock/LockByTos for user " + User + "id: " + id + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Unlocks CIR after TOS specialist opened CIR in the system. Posts the unlock to InspecTools.
        /// </summary>
        /// <param name="id">Guid of CIR</param>
        /// <param name="templateId">Guid of template of a given CIR</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult UnlockByTos(string id, string templateId)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _cirLockService.UnlockCirByTos(id, templateId, user.DisplayName);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirTosLock/UnlockByTos for user " + User + "id: " + id + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}