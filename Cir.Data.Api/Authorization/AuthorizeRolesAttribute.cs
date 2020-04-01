using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Cir.Data.Access.Models.Authorization;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Authentication;

namespace Cir.Data.Api.Authorization
{
    /// <summary>
    /// Authorize user role 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Graph api user key
        /// </summary>
        public const string GraphApiUserKey = "GraphApiUser";
        /// <summary>
        /// Graph api user roles key
        /// </summary>
        public const string GraphApiUserRolesKey = "GraphApiUserRoles";
        private readonly string[] _roles;
        /// <summary>
        /// Graph api service interface
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public IGraphApiService GraphApiService { get; set; }

        /// <summary>
        /// Authorize users based on roles from GraphApi.
        /// </summary>
        /// <param name="roles"></param>
        public AuthorizeRolesAttribute(params string[] roles)
        {
            _roles = roles;
        }

        /// <summary>
        /// On authorize event
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            OnAuthorizationAsync(actionContext, CancellationToken.None).Wait();
        }
        /// <summary>
        /// Authorize the user
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateUnauthorizedResponse();
                return;
            }

            var controller = actionContext.ControllerContext.Controller as ApiController;

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(actionContext));
            }

            var userIdentity =
                await controller.User
                    .GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(controller.Request);

            #region [UBI1.0 Fix]
            //Reading user object id header sent from windams viewer.
            try
            {
                IEnumerable<string> userDetails;
                //if (userIdentity.ObjectId == "4f3e087f-e1c7-4e3f-8b2a-ee5187554a19" && !actionContext.Request.Headers.TryGetValues("x-ubi-user", out userDetails))
                //   userIdentity.ObjectId = "503191e0-1f61-4b71-9745-3eefe1a38c9e";
                //else if (userIdentity.ObjectId == "4f3e087f-e1c7-4e3f-8b2a-ee5187554a19" && actionContext.Request.Headers.TryGetValues("x-ubi-user", out userDetails))
                //   userIdentity.ObjectId = userDetails.First();

                if (actionContext.Request.Headers.TryGetValues("x-ubi-user", out userDetails))
                    userIdentity.ObjectId = userDetails.First();
            }
            catch (Exception ex)
            {
                //add exception log 
                TelemetryClient tc = new TelemetryClient();
                tc.TrackEvent("Exception occurred in method OnAuthorizationAsync of Cir.Data.Api when trying to read header value x-ubi-user. Error Message: " + ex.Message);
                tc.TrackException(ex);
            }
            #endregion [UBI1.0 Fix]

            var user = new UserInformation();

            user = await RequestPropertiesSetUser(userIdentity.ObjectId, controller);

            if (_roles.Length == 0 || IsUserInRole(user))
            {
                return;
            }

            actionContext.Response = actionContext.Request.CreateUnauthorizedResponse();
        }

        private async Task<UserInformation> RequestPropertiesSetUser(string userObjectId, ApiController controller)
        {
            var user = await GraphApiService.GetUserAsync(userObjectId);
            user.DisplayName = user.DisplayName.Contains("_") ? user.DisplayName.Split('_')[0] : user.DisplayName;
            controller.Request.Properties.Add(GraphApiUserKey, user);

            return user;
        }

        private bool IsUserInRole(UserInformation user)
        {
            return user.AppRoles.Any(userRole => _roles.Contains(userRole));
        }
    }
}