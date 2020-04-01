using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.DataManipulation;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// User data controller
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class UserDataController : ApiController
    {
        private readonly IUserDataService _userDataService;
        private TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// User data controller
        /// </summary>
        /// <param name="userDataService"></param>
        /// <param name="log"></param>
        public UserDataController(IUserDataService userDataService, ILogger log)
        {
            _userDataService = userDataService;
        }

        /// <summary>
        ///  GET api/UserData
        /// </summary>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpGet]
        [GzipCompression]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                //UserInformation user = Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                UserInformation user = UserInformation.getstaticuser(authToken);//new UserInformation();
                return Ok(await _userDataService.GetData(user));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in UserData/Get for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get user info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUserInfo()
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                UserInformation user = UserInformation.getstaticuser(authToken);//new UserInformation();
                return Ok(user);
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in UserData/GetUserInfo for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get master sync
        /// </summary>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpGet]
        [GzipCompression]
        public async Task<IHttpActionResult> GetMasterSync()
        {
            try
                {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("UserData/GetMasterSync for " + user.UserName);// Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey]);
                //UserInformation user = Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                _telemetryClient.TrackEvent("UserData/GetMasterSync for "  +user.AppRoles + ", " + user.UserName);
                return Ok(await _userDataService.GetMasterSyncData(user));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in UserData/GetMasterSync for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}
