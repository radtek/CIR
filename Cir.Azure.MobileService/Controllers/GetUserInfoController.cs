using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Cir.Azure.MobileService.Utilities;
using Cir.Azure.MobileService.DataObjects;

namespace Cir.Azure.MobileService.Controllers
{
    public class GetUserInfoController : ApiController
    {
        public ApiServices Services { get; set; }
        private AuthenticationUtilities AuthUtil { get; set; }
        
        // GET api/GetUserInfo
        [Authorize]
        public async Task<UserInformation> Get()
        {
            AuthUtil = new AuthenticationUtilities(Services);
            Services.Log.Info("Entered GetUserInfo custom controller!");
            return await AuthUtil.GetAADUser((ServiceUser)this.User);
        }

    }
}
