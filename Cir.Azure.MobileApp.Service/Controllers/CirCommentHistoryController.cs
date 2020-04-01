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
    //[AuthorizeAadRole(Roles="*")]
    public class CirCommentHistoryController : ApiController
    {
        // POST api/CirCommentHistory
        /// <summary>
        /// Post the CirCommentHistory Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  CirCommentHistory Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys POST(Cir.Azure.MobileApp.Service.CirSyncService.CirCommentHistorys CirCommentHistory)
        {
            
            this.Configuration.Services.GetTraceWriter().Info("CirCommentHistory custom controller! -Post");
            try
            {
                return (new SyncServiceUtilities(this)).SaveCirCommentHistorys(CirCommentHistory);                
                    
            }
            catch (Exception ex)
            {
                return new CirSyncService.CirCommentHistorys() { Comment = ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message };
            }            
        }
    }
}
