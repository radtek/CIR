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
    //[AuthorizeAadRole(Roles = "Administrator, GBXIRCreator")]
    public class GBXIRDataController : ApiController
    {

        public SyncServiceUtilities GetSyncUtility()
        {
            return new SyncServiceUtilities(this);
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.Gbx Post(Cir.Azure.MobileApp.Service.CirSyncService.Gbx GirData)
        {
            Cir.Azure.MobileApp.Service.CirSyncService.Gbx oResponse;
            

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                if (GirData.TurbineID == 0)
                    oResponse = (new SyncServiceUtilities(this)).GetGBXirDataByCirID(GirData.CirIDs);
                else
                    oResponse = (new SyncServiceUtilities(this)).SaveGBXirData(GirData);
                    
            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.Message, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.InnerException.Message));
            }
            return oResponse;
        }
    }
}
