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
   // [AuthorizeAadRole(Roles = "Administrator")]
    public class StandardTextController : ApiController
    {
        // POST api/StandardTextData
        /// <summary>
        /// Post the StandardText Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  StandardText Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public List<Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts> Post(Cir.Azure.MobileApp.Service.CirSyncService.StandardTexts oStandardTexts)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            if (!ReferenceEquals(oStandardTexts, null))
                return (new SyncServiceUtilities(this)).GetStandardText(Convert.ToInt32(oStandardTexts.ComponentInspectionReportTypeId));
            else
                return (new SyncServiceUtilities(this)).GetStandardText(1);
        }
    }
}
