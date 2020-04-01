
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
    public class CirSearchController : ApiController
    {
        /// <summary>
        /// Cir quick search
        /// </summary>
        /// <param name="SearchItems"></param>
        /// <returns></returns>        
        public List<Cir.Azure.MobileApp.CirSyncService.ComponentInspectionReport> Post(Cir.Azure.MobileApp.CirSyncService.CirQuickSearch SearchItems)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Cir quick sesarch custom controller!");
            try
            {

                return (new SyncServiceUtilities(this)).CirQuickSearch(
                        SearchItems: SearchItems
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
    }
}
