using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "Administrator")]
    public class HotlistController : ApiController
    {
        //[AuthorizeAadRole(Roles = "Administrator")]
        [HttpGet]
        [Route("api/GetHotlistbyId/{id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.Hotlist Get(int id)
        {
            try
            {

                return (new SyncServiceUtilities(this)).GetHotlist(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

       // [AuthorizeAadRole(Roles = "Administrator")]
        [HttpGet]
        [Route("api/GetHotlist")]
        public Cir.Azure.MobileApp.Service.CirSyncService.Hotlist[] GetHotlist()
        {
            try
            {

                return (new SyncServiceUtilities(this)).GetAllHotlist();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

       // [AuthorizeAadRole(Roles = "Administrator")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {

                return (new SyncServiceUtilities(this)).DeleteHotList(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

       // [AuthorizeAadRole(Roles = "Administrator")]
        [HttpPost]
        public bool Post(Cir.Azure.MobileApp.Service.CirSyncService.Hotlist m)
        {
            try
            {

                return (new SyncServiceUtilities(this)).SaveHotList(m);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

    }
}