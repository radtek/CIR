
using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using Cir.Azure.MobileApp.Service.Filters;
namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    //[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    [LoggingFilters]
    public class CirSearchController : ApiController
    {
        /// <summary>
        /// Cir quick search
        /// </summary>
        /// <param name="SearchItems"></param>
        /// <returns></returns>        
        public List<Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport> Post(Cir.Azure.MobileApp.Service.CirSyncService.CirQuickSearch SearchItems)
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
