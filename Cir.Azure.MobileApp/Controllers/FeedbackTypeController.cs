using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "Administrator")]
    public class FeedbackTypeController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the FeedbackType MasterData
        /// </summary>
        /// <returns>FeedbackType</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public System.Collections.Generic.List<Cir.Azure.MobileApp.CirSyncService.FeedbackType> Get()
        {

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Get");
            try
            {
                return (new SyncServiceUtilities(this)).GetFeedbackType();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }            
        }
    }
}
