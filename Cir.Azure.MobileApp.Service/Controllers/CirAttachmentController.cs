using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;
using System.Threading.Tasks;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class CirAttachmentController : ApiController
    {

        [HttpGet]
        [Route("api/GetAttachment/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments Get(Int64 Id)
        {

            try
            {
                return (new SyncServiceUtilities(this)).GetAttachment(Id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpGet]
        [Route("api/GetAttachments/{Id}")]
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments> GetAttachments(long Id)
        {

            try
            {
                return (new SyncServiceUtilities(this)).GetAttachments(Id).ToList();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpPost]
        public bool Post(Cir.Azure.MobileApp.Service.CirSyncService.CirAttachments attachment)
        {

            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            try
            {
                UserInformation userInfo = GetUserInfo();
                attachment.CreatedBy = UserPermission.UserName(userInfo);

                return (new SyncServiceUtilities(this)).SaveAttachment(attachment);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));

            }

        }


        [HttpDelete]
        public bool Delete(long cirAttachmentId)
        {
            try
            {

                return (new SyncServiceUtilities(this)).DeleteAttachment(cirAttachmentId);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ((ex.InnerException != null) ? ex.InnerException.Message : "")));
            }
        }

        [HttpPost]
        [Route("api/UploadDefectCategotization")]
        public Cir.Azure.MobileApp.Service.CirSyncService.CirDefectCategorization UploadDefectCategotization(Cir.Azure.MobileApp.Service.CirSyncService.CirDefectCategorization dc)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Get Cir State By CirIDs custom controller!");
            try
            {
                UserInformation userInfo = GetUserInfo();
                dc.initials = UserPermission.UserName(userInfo);
                return (new SyncServiceUtilities(this)).UploadDefectCategotization(dc);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpPost, Route("api/upload")]
        public async Task<IHttpActionResult> Upload()
        {
            try
            {

                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();
                    //Do whatever you want with filename and its binaray data.
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        public UserInformation GetUserInfo()
        {
            AuthenticationUtilities AuthUtil = new AuthenticationUtilities(this);
            UserInformation userInfo = null;
            var getUserInfo = System.Threading.Tasks.Task.Run(async () => { userInfo = await AuthUtil.GetAADUser(this); });
            getUserInfo.Wait();
            return userInfo;

        }



    }
}
