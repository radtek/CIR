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
    /// <summary>
    /// Added By : Siddharth Chauhan
    /// Date : 26-05-2016
    /// Description : To show and get data of Cir Revision.
    /// Task No. : 72518, 72519, 72520
    /// </summary>
    //Task No. : 72518, 72519 & 72520, 
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class GetCirRevisionController : ApiController
    {
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirRevision> POST(Cir.Azure.MobileApp.Service.CirSyncService.CirRevision cirRevision)
        {

            List<Cir.Azure.MobileApp.Service.CirSyncService.CirRevision> oResponse;


            this.Configuration.Services.GetTraceWriter().Info("Cir Revision custom controller! -Post");
            try
            {

                oResponse = (new SyncServiceUtilities(this)).GetCirRevision(cirRevision.CirDataId);

            }
            catch (Exception ex)
            {
                oResponse = new List<CirSyncService.CirRevision>();
                
            }
            return oResponse;
        }

        public Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReport Get(Int64 Id)
        {

          this.Configuration.Services.GetTraceWriter().Info("Cir Revision custom controller! -Get");
            try
            {

                return (new SyncServiceUtilities(this)).GetCirRevisionData(Id);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.Message));
            }
        }
    }
}
