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
   // [AuthorizeAadRole(Roles = "Administrator, BIRCreator")]
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
        public Cir.Azure.MobileApp.Service.CirSyncService.Bir Post(Cir.Azure.MobileApp.Service.CirSyncService.Bir BirData)
        {
            Cir.Azure.MobileApp.Service.CirSyncService.Bir oResponse;
            

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

        [HttpPost]
        [Route("api/GenerateBIRPdfReport/{Id}/{languageId}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile GenerateBIRPdfReport(long Id, int languageId = 0)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                oFileInfo = (new SyncServiceUtilities(this)).GenerateBIRReport(
                    BirId:Id,languageId:languageId
                    );
                if (oFileInfo != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oFileInfo.FileBytes);
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileName = oFileInfo.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
                }
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.StackTrace, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.StackTrace.ToString() + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpPost]
        [Route("api/GenerateBIRWordReport/{Id}/{languageId}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile GenerateBIRWordReport(long Id, int languageId = 0)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                oFileInfo = (new SyncServiceUtilities(this)).GenerateBIRReport(
                    BirId: Id, languageId: languageId
                    );
                if (oFileInfo != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oFileInfo.FileBytes);
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileName = oFileInfo.FileName.Replace(@"\", "_").Replace("/", "_") + ".docx";
                }
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.StackTrace, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.StackTrace.ToString() + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

    }
}
