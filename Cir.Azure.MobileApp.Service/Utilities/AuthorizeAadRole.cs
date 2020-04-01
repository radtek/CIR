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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using Cir.Azure.MobileApp.Service.Utilities;

namespace Cir.Azure.MobileApp.Service.Utilities
{
    public enum AadRoles
    {
        CirCreators
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAadRole : AuthorizationFilterAttribute
    {
        private ITraceWriter TraceWriter { get; set; }
        private AuthenticationUtilities AuthUtil { get; set; }

        // Summary:
        //     Gets or sets the authorized roles.
        //
        // Returns:
        //     The roles string.
        public string Roles { get; set; }
        ////
        //// Summary:
        ////     Gets or sets the authorized users.
        ////
        //// Returns:
        ////     The users string.
        //public string Users { get; set; }


        public AuthorizeAadRole()
        {
        }


        // Called when the user is attempting authorization
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            string error = string.Empty;
            // Check whether we are running in a mode where local host access is allowed 
            // through without authentication.

            // No security when hosted locally
            if (actionContext.RequestContext.IsLocal)
            {
                TraceWriter.Warn("AuthorizeAadRole: Local Hosting.");
                return;
            }

            ApiController controller = actionContext.ControllerContext.Controller as ApiController;
            if (controller == null)
            {
                TraceWriter.Error("AuthorizeAadRole: No ApiController.");
            }

            bool isAuthorized = false;
            try
            {

                // Retrieve a AAD token from ADAL
                AuthUtil = new AuthenticationUtilities(controller);

                // Check group membership to see if the user is part of the group that corresponds to the role
                if (!string.IsNullOrEmpty(Roles))
                {
                    // MobileAppUser mobileAppUser = controller.User as MobileAppUser;
                    AzureActiveDirectoryCredentials aadCreds = null;
                    var arTask = System.Threading.Tasks.Task.Run(async () =>
                    {
                        aadCreds = await controller.User.GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(controller.Request);
                    });
                    arTask.Wait();

                    if (aadCreds != null)
                    {

                        isAuthorized = AuthUtil.CheckAppRoles(aadCreds, Roles.Split(',').ToList());
                    }
                }

            }
            catch (Exception e)
            {
                error = e.Message + " \n " + e.InnerException + " \n " + e.StackTrace;
                TraceWriter.Error(e.Message);
            }
            finally
            {
                if (isAuthorized == false)
                {
                    TraceWriter.Error("Denying access");

                    actionContext.Response = actionContext.Request
                        .CreateErrorResponse(HttpStatusCode.Forbidden,
                            "User is not logged in or not have required AppRole \n \n Detailed Error" + error);
                }
            }
        }
    }
}