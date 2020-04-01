using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using Cir.Azure.MobileApp.Service.DataObjects;
using Cir.Azure.MobileApp.Service.Utilities;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.Tracing;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.ApplicationInsights;   

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    public class GetUserInfoController : ApiController
    {
        TelemetryClient _telemetryClient = new TelemetryClient();
        private AuthenticationUtilities AuthUtil { get; set; }
        // GET api/GetUserInfo
        /// <summary>
        /// Get the User Information for the current authenticated mobile app user
        /// </summary>
        /// <returns>UserInformation object</returns>
        /// <CreateBy>Mukul Keshari</CreateBy>
        //[Authorize]
        public async Task<UserInformation> Get()
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered GetUserInfo custom controller!");
                AuthUtil = new AuthenticationUtilities(this);
                var u = await AuthUtil.GetAADUser(this);
                return u;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return new UserInformation { displayName = ex.Message };
            }
        }


    }
}
