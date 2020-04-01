using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "Administrator")]
    public class ManufacturerController : ApiController
    {
        
        
        [AuthorizeAadRole(Roles = "Administrator")]
        [HttpGet]
        [Route("api/Manufacturer/{type}/{id}")]
        public Cir.Azure.MobileApp.CirSyncService.Manufacturer Get(int type, int id)
        {
            try
            {

                return (new SyncServiceUtilities(this)).GetManufacturer(type, id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [AuthorizeAadRole(Roles = "Administrator")]
        [HttpGet]
        [Route("api/ManufacturerList/{type}")]
        public Cir.Azure.MobileApp.CirSyncService.ManufacturerList Get(int type)
        {
            try
            {

                return (new SyncServiceUtilities(this)).GetManufacturerList(type);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [AuthorizeAadRole(Roles = "Administrator")]
        [HttpPost]    
        public bool Post(Cir.Azure.MobileApp.CirSyncService.Manufacturer m)
        {
            try
            {
       
                return (new SyncServiceUtilities(this)).SaveManufacturer(m);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [AuthorizeAadRole(Roles = "Administrator")]
        [HttpDelete]
        public bool Delete(int type, int id)
        {
            try
            {

                return (new SyncServiceUtilities(this)).DeleteManufacturer(type, id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
    }
}
