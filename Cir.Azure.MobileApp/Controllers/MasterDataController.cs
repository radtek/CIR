using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;
using Cir.Azure.MobileApp.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "*")]
    public class MasterDataController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the Cir MasterData
        /// </summary>
        /// <returns>CirMasterData</returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        public System.Collections.Generic.List<Cir.Azure.MobileApp.CirSyncService.CirMasterData> Get()
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller!");
                return (new SyncServiceUtilities(this)).GetMasterData();
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " +ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }


        [Route("api/MasterDataByTable/{TableName}")]
        public System.Collections.Generic.List<Cir.Azure.MobileApp.CirSyncService.CirMasterTable> GetMasterDataByTable(string TableName)
         {
            try
            {
                AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
                UserInformation userInfo = null;
                var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser((MobileAppUser)this.User); });
                getUserInfo.Wait();
                var UserId = UserPermission.UserName(userInfo);

                this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller!");
                return (new SyncServiceUtilities(this)).GetMasterDataByTable(TableName, UserId);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " +ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/CIMCaseTable")]
        public System.Collections.Generic.List<Cir.Azure.MobileApp.CirSyncService.CirCIMCaseTable> GetCIMCaseTable()
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller!");
                return (new SyncServiceUtilities(this)).GetCIMCaseData();
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
