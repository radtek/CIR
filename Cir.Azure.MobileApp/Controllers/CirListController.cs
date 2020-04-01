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
    public class CirListController : ApiController
    {


        public Cir.Azure.MobileApp.CirSyncService.CIRList Post(Cir.Azure.MobileApp.CirSyncService.CIRList cirList)
        {
          
            this.Configuration.Services.GetTraceWriter().Info("Entered CIR List custom controller!");
            try
            {

                return (new SyncServiceUtilities(this)).GetCirList(cirList);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
      
       
    }
}
