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
    /// Create cir controller
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CreateCirController : ApiController
    {
        private ICirSubmissionService _cirSubmissionService;
        private readonly ILogger _log;
        TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// Create cir controller
        /// </summary>
        /// <param name="cirSubmissionService"></param>
        /// <param name="log"></param>
        public CreateCirController(ICirSubmissionService cirSubmissionService, ILogger log)
        {
            _cirSubmissionService = cirSubmissionService;
            _log = log;
        }

        /// <summary>
        /// Create empty cir method.
        /// </summary>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult CreateEmptyCir()
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken); //Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                var pickUserInitials = user.DisplayName.Contains("_") ? user.DisplayName.Split('_')[0] : user.DisplayName;
                return Content(HttpStatusCode.Created, _cirSubmissionService.CreateEmptyBladeInspection(pickUserInitials));
            
                // var user = UserInformation.getstaticuser(); //Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                // return Content(HttpStatusCode.Created, _cirSubmissionService.CreateEmptyBladeInspection(user.DisplayName));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken); //Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                _telemetryClient.TrackEvent("Unexpected error occured for CreateCir/CreateEmptyCir for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);

                //_log.Error(e, "Unexpected error occured for {@path} for user {@user}", "CreateCir/CreateEmptyCir", User);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e));
            }
        }
    }
}