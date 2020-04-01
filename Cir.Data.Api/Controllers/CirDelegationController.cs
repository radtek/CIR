using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.DataManipulation;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// CirDelegationController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CirDelegationController : ApiController
    {
        private TelemetryClient _telemetryClient = new TelemetryClient();
        private readonly ICirDelegationService _cirDelegationService;

        /// <summary>
        /// CirDelegationController
        /// </summary>
        /// <param name="log"></param>
        /// <param name="cirDelegationService"></param>
        public CirDelegationController(ILogger log, ICirDelegationService cirDelegationService)
        {
            _cirDelegationService = cirDelegationService;
        }

        /// <summary>
        /// DelegateTo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delegateTo"></param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpPost]
        [GzipCompression]
        public IHttpActionResult DelegateTo(string id, string delegateTo)
        {
            try
            {
                //var user =  UserInformation.getstaticuser(); //Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                UserInformation user = UserInformation.getstaticuser(authToken);
                return Ok(_cirDelegationService.DelegateCirTo(id, delegateTo, user.DisplayName));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirDelegation/RevokeDelegate for user " + User + "id: " + id+ " delegateTo: " + delegateTo);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// RevokeDelegate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [GzipCompression]
        public IHttpActionResult RevokeDelegate(string id)
        {
            try
            {
                return Ok(_cirDelegationService.RevokeDelegate(id));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirDelegation/RevokeDelegate for user " + User + "id: " + id);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}