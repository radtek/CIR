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
    public class ServiceInformationsController : ApiController
    {
        // GET api/ServiceInformationList
        /// <summary>
        /// GET to read All record except deleted
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        [Route("api/ServiceInformationList/")]
        //[AuthorizeAadRole(Roles = "Administrator")]
        public List<Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations> GetAll()
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered  custom controller! -Post");
            try
            {
                return (new SyncServiceUtilities(this)).GetServiceInformations(true);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message + " " + ((ex.InnerException != null) ? "Inner: " + ex.InnerException.Message : "") + "\n Detailed Error: " + ex.StackTrace + " " + ((ex.InnerException != null) ? " Inner: " + ex.InnerException.StackTrace : "")));
            }
        }

        // GET api/ServiceInformationList
        /// <summary>
        /// GET to read All record  for user notification
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        
        [Route("api/MyServiceInformationList/")]
       // [AuthorizeAadRole(Roles = "*")]
        public List<Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations> GetMyServiceInformation()
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered  custom controller! -Post");
            try
            {
                return (new SyncServiceUtilities(this)).GetServiceInformations(false);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message + " " + ((ex.InnerException != null) ? "Inner: " + ex.InnerException.Message : "") + "\n Detailed Error: " + ex.StackTrace + " " + ((ex.InnerException != null) ? " Inner: " + ex.InnerException.StackTrace : "")));
            }
        }

        // GET api/ServiceInformations
        /// <summary>
        /// GET to read a record
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        // [AuthorizeAadRole(Roles = "Administrator")]
        public Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations Get(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered ServiceInformations custom controller! -PUT");
            try
            {
                return (new SyncServiceUtilities(this)).GetServiceInformationsbyID(Id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message + " " + ((ex.InnerException != null) ? "Inner: " + ex.InnerException.Message : "") + "\n Detailed Error: " + ex.StackTrace + " " + ((ex.InnerException != null) ? " Inner: " + ex.InnerException.StackTrace : "")));
            }
        }

        

        // PUT api/ServiceInformations
        /// <summary>
        /// PUT to Create or Update record
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        // [AuthorizeAadRole(Roles = "Administrator")]
        public Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations Put(Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations oServiceInformations)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered ServiceInformations custom controller! -PUT");
            try
            {
                if (oServiceInformations.Id == 0)
                {
                    UserInformation userInfo = GetUserInfo();
                    oServiceInformations.CreatedBy = UserPermission.UserName(userInfo);
                    oServiceInformations.Created = DateTime.Now;
                }
                else
                {
                    UserInformation userInfo = GetUserInfo();
                    oServiceInformations.ModifiedBy = UserPermission.UserName(userInfo);
                    oServiceInformations.Modified = DateTime.Now;
                }

                return (new SyncServiceUtilities(this)).SaveServiceInformations(oServiceInformations);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message + " " + ((ex.InnerException != null) ? "Inner: " + ex.InnerException.Message : "") + "\n Detailed Error: " + ex.StackTrace + " " + ((ex.InnerException != null) ? " Inner: " + ex.InnerException.StackTrace : "")));
            }
        }

        // Delete api/ServiceInformations
        /// <summary>
        /// DELETE to delete a record
        /// </summary>
        /// <param name="ServiceInformations"></param>
        /// <returns></returns>
        /// <CreatedBy>Mukul Keshari</CreatedBy>
        // [AuthorizeAadRole(Roles = "Administrator")]
        public bool Delete(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered ServiceInformations custom controller! -Delete");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.ServiceInformations oServiceInformations = new CirSyncService.ServiceInformations();
                oServiceInformations.Id = Id;
                oServiceInformations.Deleted = true;
                UserInformation userInfo = GetUserInfo();
                oServiceInformations.ModifiedBy = UserPermission.UserName(userInfo);
                oServiceInformations.Modified = DateTime.Now;

                (new SyncServiceUtilities(this)).SaveServiceInformations(oServiceInformations);

                return true;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message + " " + ((ex.InnerException != null) ? "Inner: " + ex.InnerException.Message : "") + "\n Detailed Error: " + ex.StackTrace + " " + ((ex.InnerException != null) ? " Inner: " + ex.InnerException.StackTrace : "")));
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
    }
}
