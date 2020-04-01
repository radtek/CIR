using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Cir.Azure.MobileService.Utilities
{
    public enum AadRoles
    {
        CirCreators
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAadRole : AuthorizationFilterAttribute
    {
        private bool isInitialized;
        private bool isHosted;
        private ApiServices services = null;
        private AuthenticationUtilities AuthUtil { get; set; }


        private Dictionary<int, string> groupIds = new Dictionary<int, string>();


        public AuthorizeAadRole(AadRoles role)
        {
            this.Role = role;
        }

        public AadRoles Role { get; private set; }

        // Generate a local dictionary for the role group ids configured as 
        // Mobile Service app settings
        private void InitGroupIds()
        {
            string groupId;

            if (services == null)
                return;

            if (!groupIds.ContainsKey((int)AadRoles.CirCreators))
            {
                if (services.Settings.TryGetValue("AAD_CIRCREATOR_GROUP_ID", out groupId))
                {
                    groupIds.Add((int)AadRoles.CirCreators, groupId);
                }
                else
                    services.Log.Error("AAD_CIRCREATOR_GROUP_ID app setting not found.");
            }
        }



        // Called when the user is attempting authorization
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            services = new ApiServices(actionContext.ControllerContext.Configuration);

            // Check whether we are running in a mode where local host access is allowed 
            // through without authentication.
            if (!this.isInitialized)
            {
                HttpConfiguration config = actionContext.ControllerContext.Configuration;
                this.isHosted = config.GetIsHosted();
                this.isInitialized = true;
            }

            // No security when hosted locally
            if (!this.isHosted && actionContext.RequestContext.IsLocal)
            {
                services.Log.Warn("AuthorizeAadRole: Local Hosting.");
                return;
            }

            ApiController controller = actionContext.ControllerContext.Controller as ApiController;
            if (controller == null)
            {
                services.Log.Error("AuthorizeAadRole: No ApiController.");
            }

            bool isAuthorized = false;
            try
            {
                // Initialize a mapping for the group id to our enumerated type
                InitGroupIds();

                // Retrieve a AAD token from ADAL
                AuthUtil = new AuthenticationUtilities(services);

                // Check group membership to see if the user is part of the group that corresponds to the role
                if (!string.IsNullOrEmpty(groupIds[(int)Role]))
                {
                    ServiceUser serviceUser = controller.User as ServiceUser;
                    if (serviceUser != null && serviceUser.Level == AuthorizationLevel.User)
                    {
                        var idents = serviceUser.GetIdentitiesAsync().Result;
                        AzureActiveDirectoryCredentials clientAadCredentials =
                            idents.OfType<AzureActiveDirectoryCredentials>().FirstOrDefault();
                        if (clientAadCredentials != null)
                        {
                            isAuthorized = AuthUtil.CheckMembership(clientAadCredentials.ObjectId, groupIds[(int)Role]).Result;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                services.Log.Error(e.Message);
            }
            finally
            {
                if (isAuthorized == false)
                {
                    services.Log.Error("Denying access");

                    actionContext.Response = actionContext.Request
                        .CreateErrorResponse(HttpStatusCode.Forbidden,
                            "User is not logged in or not a member of the required group");
                }
            }
        }
    }
}