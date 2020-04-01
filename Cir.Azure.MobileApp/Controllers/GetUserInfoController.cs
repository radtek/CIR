using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using Cir.Azure.MobileApp.DataObjects;
using Cir.Azure.MobileApp.Utilities;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.Tracing;
using System.Web.Http.Cors;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;


namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    public class GetUserInfoController : ApiController
    {
        private AuthenticationUtilities AuthUtil { get; set; }
        // GET api/GetUserInfo
        /// <summary>
        /// Get the User Information for the current authenticated mobile app user
        /// </summary>
        /// <returns>UserInformation object</returns>
        /// <CreateBy>Mukul Keshari</CreateBy>
        [Authorize]
        public async Task<UserInformation> Get()
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GetUserInfo custom controller!");
            AuthUtil = new AuthenticationUtilities(this);
            return await AuthUtil.GetAADUser((MobileAppUser)this.User);
        }

        
    }
}
