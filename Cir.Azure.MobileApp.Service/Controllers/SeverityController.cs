using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class SeverityController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the Severity MasterData
        /// </summary>
        /// <returns>Severity</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public System.Collections.Generic.List<Cir.Azure.MobileApp.Service.CirSyncService.Severity> Get()
        {

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Get");
            try
            {
                return (new SyncServiceUtilities(this)).GetSeverity();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }            
        }
    }
}
