using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
    //[AuthorizeAadRole(Roles = "*")]
    public class CirViewController : ApiController
    {

        [Route("api/GetAllView/{Id}")]
        public System.Collections.Generic.List<Cir.Azure.MobileApp.Service.CirSyncService.CirViewData> GetAllView(int Id = 0)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered CirViewData Get custom controller!");

                return (new SyncServiceUtilities(this)).GetAllView();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }

        }

        [Route("api/GetAllViewList/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirViewData GetAllViewList(int Id = 0)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered CirViewData GetgetList custom controller!");
                UserInformation userInfo = GetUserInfo();
                string initials = UserPermission.UserName(userInfo);
                return (new SyncServiceUtilities(this)).GetAllViewList(initials);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }

        }
        [Route("api/GetView/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirViewData GetView(int Id)
        {

            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered CirViewData Get custom controller!");

                return (new SyncServiceUtilities(this)).GetView(Id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }

        }
        //public Cir.Azure.MobileApp.Service.CirSyncService.CirViewData Get(int ViewId)
        //{
        //    this.Configuration.Services.GetTraceWriter().Info("Entered CirViewData Get ViewId custom controller!");

        //    return (new SyncServiceUtilities(this)).GetView(ViewId);

        //}

        public int Post(Cir.Azure.MobileApp.Service.CirSyncService.CirViewData cirViewData)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered CirViewData CreateView custom controller!");
            UserInformation userInfo = GetUserInfo();
            cirViewData.CreatedBy = UserPermission.UserName(userInfo);
            bool hasaccess = UserPermission.isAdministrator(userInfo.AppRoles);
            if (hasaccess == false && (int)cirViewData.Type == 3 && cirViewData.ViewId > 0)
            {
                return -1;
            }
            else
            {
                return (new SyncServiceUtilities(this)).CreateView(cirViewData);
            }

        }

        public bool Delete(Cir.Azure.MobileApp.Service.CirSyncService.CirViewData cirViewData)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered DeleteView custom controller!");
            UserInformation userInfo = GetUserInfo();
            cirViewData.CreatedBy = UserPermission.UserName(userInfo);
            bool hasaccess = UserPermission.isAdministrator(userInfo.AppRoles);
            if (hasaccess == false && (int)cirViewData.Type == 3)
            {
                return false;
            }
            else
            {
                return (new SyncServiceUtilities(this)).DeleteView(cirViewData.ViewId);
            }


        }

        public UserInformation GetUserInfo()
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
            getUserInfo.Wait();
            return userInfo;

        }

        [Route("api/GetBIRViewId")]
        public int GetBIRViewId()
        {
            try
            {
                return (new SyncServiceUtilities(this)).GetBIRViewId();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        [Route("api/GetGIRViewId")]
        public int GetGIRViewId()
        {
            try
            {
                return (new SyncServiceUtilities(this)).GetGIRViewId();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        [Route("api/GetGBXIRViewId")]
        public int GetGBXIRViewId()
        {
            try
            {
                return (new SyncServiceUtilities(this)).GetGBXIRViewId();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
    }
}
