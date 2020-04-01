using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Cir.Azure.MobileApp.Service.DataObjects;
using Cir.Azure.MobileApp.Service.Models;
using System.Collections.Generic;
using System;
using Cir.Azure.MobileApp.Service.Utilities;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using System.Net;
using System.Net.Http;
using Cir.Azure.MobileApp.Service.Filters;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    [LoggingFilters]
    public class UserLoginDetailsController : TableController<UserLoginDetails>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            vestascirmobileappContext context = new vestascirmobileappContext();
            DomainManager = new EntityDomainManager<UserLoginDetails>(context, Request);
        }

        #region [Added HybridConnectionTest to check and trigger availability alert]
        [AllowAnonymous]
        [Route("api/HybridConnectionTest")]
        [HttpGet]
        public Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport HybridConnectionTest(Int64 Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Get");
            try
            {
                return (new SyncServiceUtilities(this)).GetCir(Id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        #endregion [Added HybridConnectionTest to check and trigger availability alert]

        // GET tables/UserLoginDetails
        public IQueryable<UserLoginDetails> GetAllUserLoginDetails()
        {
            return Query();
        }

        // GET tables/UserLoginDetails/48D68C86-6EA6-4C25-AA33-223FC9A27959
        ////[Authorize]
       // [AuthorizeAadRole(Roles = "*")]
        public SingleResult<UserLoginDetails> GetUserLoginDetailsItem(string id)
        {
            return Lookup(id);
        }

        // GET tables/UserLoginDetails/mukes@vestas.com
        ////[Authorize]
       // [AuthorizeAadRole(Roles = "*")]
        [Route("api/UserLoginDetailsFor/{UserId}")]
        public UserLoginDetails GetUserLoginDetailsItemByUserId(string UserId)
        {
            var item = Query().Where(z => z.UserPricipleName.ToLower().Trim() == UserId.ToLower().Trim()).OrderByDescending(z => z.LastOnlineTime).SingleOrDefault();
            return item;
        }

        // PATCH tables/UserLoginDetails/mukes@vestas.com
        ////[Authorize]
       // [AuthorizeAadRole(Roles = "*")]
        public async Task<UserLoginDetails> PatchUserLoginDetailsItem(string id, Delta<UserLoginDetails> patch)
        {
            var UserId = id;
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
            getUserInfo.Wait();
            if (UserId.ToLower().Trim() != userInfo.userPrincipalName.ToLower().Trim())
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You need permission to access data for other user"));
            }
            var q = Query().Where(z => z.UserPricipleName.ToLower().Trim() == userInfo.userPrincipalName.ToLower().Trim()).FirstOrDefault();
            if (q == null)
            {
                q = await InsertAsync(new UserLoginDetails { Id = Guid.NewGuid().ToString(), UserPricipleName = userInfo.userPrincipalName.ToLower().Trim(), LastOnlineTime = DateTime.UtcNow });
            }
            if (patch == null)
                patch = new Delta<UserLoginDetails>();
            patch.TrySetPropertyValue("UserPricipleName", userInfo.userPrincipalName);
            patch.TrySetPropertyValue("LastOnlineTime", DateTime.UtcNow);
            return await UpdateAsync(q.Id, patch);

        }

        [HttpPost]
        ////[Authorize]
       // [AuthorizeAadRole(Roles = "*")]
        [Route("api/UserMasterSyncItem/{UserId}")]
        public async Task<UserLoginDetails> PostUserMasterSyncItem(string UserId)
        {
            Delta<UserLoginDetails> patch = new Delta<UserLoginDetails>();

            patch.TrySetPropertyValue("LastMasterDataSyncTime", DateTime.UtcNow);
            return await PatchUserLoginDetailsItem(UserId, patch);

        }
        [HttpPost]
        ////[Authorize]
       // [AuthorizeAadRole(Roles = "*")]
        [Route("api/UserLastLogin/{UserId}")]
        public async Task<UserLoginDetails> PostUserLastLogin(string UserId)
        {
            Delta<UserLoginDetails> patch = new Delta<UserLoginDetails>();

            patch.TrySetPropertyValue("LastOnlineTime", DateTime.UtcNow);
            return await PatchUserLoginDetailsItem(UserId, patch);

        }
    }
}