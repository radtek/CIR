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

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class CirAdvancedSearchController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the Cir Advanced Search
        /// </summary>
        /// <returns>CirAdvancedSearch</returns>
        /// <CreatedBy>Jayanta Nath</CreatedBy>
       
        [Route("api/AdvancedSearch")]
        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel PostSearch(Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel Model)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered AdvancedSearch custom controller!");
                return (new SyncServiceUtilities(this)).DoAdvanceSearch(Model);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }


        [Route("api/LoadProfile/{ProfileId}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel GetLoadProfile(long ProfileId)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered AdvancedSearch custom controller!");
                return (new SyncServiceUtilities(this)).LoadProfile(ProfileId);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/SaveProfile")]
        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel PostSaveProfile(Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel Model)
        {
            try
            {
                AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
                UserInformation userInfo = null;
                var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
                getUserInfo.Wait();
                Model.UserName = UserPermission.UserName(userInfo);

                this.Configuration.Services.GetTraceWriter().Info("Entered AdvancedSearch custom controller!");
                return (new SyncServiceUtilities(this)).SaveProfile(Model);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [HttpDelete]
        public Cir.Azure.MobileApp.Service.CirSyncService.AdvanceSearchModel Delete(long ProfileId)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered Delete Profile custom controller!");
                return (new SyncServiceUtilities(this)).DeleteProfile(ProfileId);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }
        [HttpGet]
        [Route("api/GetBrandTypes")]
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Brand> GetBrandList()
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered Delete Profile custom controller!");
                return (new SyncServiceUtilities(this)).GetBrandList();
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }
    }
}
