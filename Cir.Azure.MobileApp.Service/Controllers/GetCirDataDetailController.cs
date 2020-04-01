using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class GetCirDataDetailController : ApiController
    {
        // POST api/StandardTextData
        /// <summary>
        /// Post the StandardText Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  StandardText Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetails Post(Cir.Azure.MobileApp.Service.CirSyncService.CirDataDetails oCirDataDetails)
        {
            this.Configuration.Services.GetTraceWriter().Info("Get CirDataDetails custom controller! -Post");
            if (!ReferenceEquals(oCirDataDetails, null))
                return (new SyncServiceUtilities(this)).GetCirDataDetails(oCirDataDetails.CirDataId);
            else
                return (new SyncServiceUtilities(this)).GetCirDataDetails(1);
        }
    }
}
