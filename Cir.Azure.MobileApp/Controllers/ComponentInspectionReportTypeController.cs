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
    [AuthorizeAadRole(Roles = "*")]
    public class ComponentInspectionReportTypeController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the ComponentInspectionReportType MasterData
        /// </summary>
        /// <returns>ComponentInspectionReportTypeMasterData</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public System.Collections.Generic.List<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReportType> Get()
        {

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Get");
            try
            {
                return (new SyncServiceUtilities(this)).GetComponentInspectionReportType();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }            
        }
    }
}
