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
    [AuthorizeAadRole(Roles = "Administrator")]
    public class StandardTextDataController : ApiController
    {
        // POST api/StandardTextData
        /// <summary>
        /// Post the StandardText Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  StandardText Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public Cir.Azure.MobileApp.CirSyncService.StandardTexts Post(Cir.Azure.MobileApp.CirSyncService.StandardTexts StandardText)
        {
            Cir.Azure.MobileApp.CirSyncService.StandardTexts oResponse;
            

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                if (StandardText.CallFunction == "GetByID")
                    oResponse = (new SyncServiceUtilities(this)).GetStandardTextbyID(StandardText.Id);
                else
                    oResponse = (new SyncServiceUtilities(this)).SaveStandardTextData(StandardText);
                    
            }
            catch (Exception ex)
            {
                oResponse = new CirSyncService.StandardTexts() { Status = false, StatusMessage = ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message };
            }
            return oResponse;
        }
    }
}
