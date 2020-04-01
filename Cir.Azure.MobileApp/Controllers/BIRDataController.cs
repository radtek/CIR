using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;
using Cir.Azure.MobileApp.DataObjects;
using System.Configuration;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "Administrator, BIRCreator")]
    public class BirDataController : ApiController
    {

        public SyncServiceUtilities GetSyncUtility()
        {
            return new SyncServiceUtilities(this);
        }
        // POST api/BirData
        /// <summary>
        /// Post the BirData Json String to the BirData Sync Wcf Service
        /// </summary>
        /// <param name="Bir"></param>
        /// <returns>Output string from  BirData Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public Cir.Azure.MobileApp.CirSyncService.Bir Post(Cir.Azure.MobileApp.CirSyncService.Bir BirData)
        {
            Cir.Azure.MobileApp.CirSyncService.Bir oResponse;
            

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                if (BirData.TurbineID == 0)
                    oResponse = (new SyncServiceUtilities(this)).GetBirDataByCirID(BirData.CirIDs);
                else
                    oResponse = (new SyncServiceUtilities(this)).SaveBirData(BirData);
                    
            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.Message, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
            return oResponse;
        }
    }
}
