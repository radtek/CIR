using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;
using Cir.Azure.MobileApp.DataObjects;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "*")]
    public class FeedbackController : ApiController
    {
        // POST api/Feedback
        /// <summary>
        /// Post the Feedback Json String to the Feedback Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  Feedback Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        ///  [AuthorizeAadRole(Roles = "*")]
        public Cir.Azure.MobileApp.CirSyncService.Feedback Post(Cir.Azure.MobileApp.CirSyncService.Feedback lstFeedback)
        {
            Cir.Azure.MobileApp.CirSyncService.Feedback oResponse;

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                oResponse = (new SyncServiceUtilities(this)).SaveFeedback(lstFeedback);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
            return oResponse;
        }

        //[AuthorizeAadRole(Roles = "Administrator")]
        public List<Cir.Azure.MobileApp.CirSyncService.Feedback> Get()
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Feedback custom controller! -Get");
            try
            {
                return (new SyncServiceUtilities(this)).GetAllFeedbacks();

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "\n Detailed Error: " + ex.InnerException.StackTrace));
            }
        }
        //[AuthorizeAadRole(Roles = "Administrator")]
        public bool Delete(long id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Feedback custom controller! -Delete");
            try
            {
                return (new SyncServiceUtilities(this)).DeleteFeedback(id);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "\n Detailed Error: " + ex.InnerException.StackTrace));
            }
        }
    }
}
