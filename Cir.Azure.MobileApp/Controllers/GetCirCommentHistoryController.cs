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
    [AuthorizeAadRole(Roles="*")]
    public class GetCirCommentHistoryController : ApiController
    {        
        // POST api/StandardTextData
        /// <summary>
        /// Post the StandardText Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  StandardText Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public List<Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys> POST(Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys CirCommentHistory)
        {
            List<Cir.Azure.MobileApp.CirSyncService.CirCommentHistorys> oResponse;


            this.Configuration.Services.GetTraceWriter().Info("CirCommentHistory custom controller! -Post");
            try
            {
                oResponse = (new SyncServiceUtilities(this)).GetCirCommentHistorys(CirCommentHistory.CirDataId);                
                    
            }
            catch (Exception ex)
            {
                oResponse = new List<CirSyncService.CirCommentHistorys>();
            }
            return oResponse;
        }
    }
}
