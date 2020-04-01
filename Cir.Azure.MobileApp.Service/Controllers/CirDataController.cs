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
    //[AuthorizeAadRole(Roles="*")]
    public class CirDataController : ApiController
    {
        
        // Get api/CirData
        /// <summary>
        /// Get the Cir Cir from the Cir Sync Wcf Service
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport from Cir Sync Wcf Service</returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        public Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport Get(Int64 Id)
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

        // POST api/CirData
        /// <summary>
        /// Post the Cir Json String to the Cir Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  Cir Sync Wcf Service</returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        public Cir.Azure.MobileApp.Service.CirSyncService.CirResponse Post(Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport Cir)
        {
            Cir.Azure.MobileApp.Service.CirSyncService.CirResponse oResponse;
            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                UserInformation userInfo = GetUserInfo();
                Cir.CurrentUser = UserPermission.UserName(userInfo);    

                oResponse = (new SyncServiceUtilities(this)).SaveCir(Cir);
            }
            catch (Exception ex)
            {
                /* HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                 {
                     Content = new StringContent(ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message),
                     ReasonPhrase = ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message
                 };
                 //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
                // this.ResponseMessage(response);
                 throw new HttpResponseException(response);*/
                oResponse = new CirSyncService.CirResponse() { Status = false, StatusMessage = ex.Message + "\n Detailed Error: " + ex.StackTrace };
            }
            return oResponse;
        }

        public UserInformation GetUserInfo()
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
            getUserInfo.Wait();
            return userInfo;

        }

        [HttpPost]
        [Route("api/GetCirStateByCirIDs")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirStateResponse[] GetCirStateByCirIDs(Cir.Azure.MobileApp.Service.CirSyncService.CirStateResponse[] CirIDs)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Get Cir State By CirIDs custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).GetCirStateByCirIDs(CirIDs);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

    }
}
