using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using System.Configuration;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
    //[AuthorizeAadRole(Roles = "Administrator, GIRCreator")]
    public class GirDataController : ApiController
    {

        public SyncServiceUtilities GetSyncUtility()
        {
            return new SyncServiceUtilities(this);
        }
        
        public Cir.Azure.MobileApp.Service.CirSyncService.Gir Post(Cir.Azure.MobileApp.Service.CirSyncService.Gir GirData)
        {
            Cir.Azure.MobileApp.Service.CirSyncService.Gir oResponse;
            

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                if (GirData.TurbineID == 0)
                    oResponse = (new SyncServiceUtilities(this)).GetGirDataByCirID(GirData.CirIDs);
                else
                    oResponse = (new SyncServiceUtilities(this)).SaveGirData(GirData);
                    
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
