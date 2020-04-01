using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;
using System.Web;
using System.IO;
using System.Configuration;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class GBXirSearchController : ApiController
    {
        public SyncServiceUtilities GetSyncUtility()
        {
            return new SyncServiceUtilities(this);
        }
        /// <summary>
        /// Cir quick search
        /// </summary>
        /// <param name="SearchItems"></param>
        /// <returns></returns>        
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gbx> Post(Cir.Azure.MobileApp.Service.CirSyncService.Gbx gbx)
        {
            //Cir.Azure.MobileApp.Service.CirSyncService.CirQuickSearch SearchItems = new CirSyncService.CirQuickSearch();
            //SearchItems.CIMCaseNumber = 0;
            //SearchItems.TurbineNumber = 42444;
            //SearchItems.ReportTypeId = 0;
            //SearchItems.ComponentInspectionReportTypeId = 0;

            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).GBXirSearch(
                        gbx
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Delete GBXir by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/GBXirDelete/{Id}")]
        public bool GBXirDelete(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).DeleteGBXir(
                    Id
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Download gbxir word doc
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GBXirWordFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GbxFile GBXirWordFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GbxFile oFileInfo = new CirSyncService.GbxFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gbx oGBXir = (new SyncServiceUtilities(this)).GBXirFile(
                   Id
                    );
                if (oGBXir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGBXir.File.FileBytes);
                    // oFileInfo.FileBytes = oGBXir.File.FileBytes;
                    oFileInfo.FileName = oGBXir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".docx";
                }
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.Message, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        /// <summary>
        /// Download gbxir pdf
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GBXirPdfFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GbxFile GBXirPdfFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GbxFile oFileInfo = new CirSyncService.GbxFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gbx oGBXir = (new SyncServiceUtilities(this)).GetGBXirPDF(
                    GBXirDataID: Id
                    );

                if (oGBXir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGBXir.File.FileBytes);
                    // oFileInfo.FileBytes = oGBXir.File.FileBytes;
                    oFileInfo.FileName = oGBXir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
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
        [Route("api/CirPdfFileGBXIR/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GbxFile CirPdfFileGBXIR(long Id, long cirid = 0)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GbxFile oFileInfo = new CirSyncService.GbxFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gbx oGBXir = (new SyncServiceUtilities(this)).GetCIRPdfGBXIR(
                    CirDataID: Id, CirID: cirid
                    );
                if (oGBXir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGBXir.File.FileBytes);
                    // oFileInfo.FileBytes = oGBXir.File.FileBytes;
                    oFileInfo.FileName = oGBXir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
                }
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.StackTrace, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.StackTrace.ToString() + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpGet]
        [Route("api/CirPdfFileByCIRIdGBX/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GbxFile CirPdfFileByCIRId(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            return CirPdfFileGBXIR(0, Id);
        }

        [HttpPost]
        [Route("api/CirPdfFileZipGBX/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GbxFile CirPdfFileZip(string Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered GBXir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GbxFile oFileInfo = new CirSyncService.GbxFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gbx oGBXir = (new SyncServiceUtilities(this)).GetCIRPdfZipGBXIR(
                    CirDataIDs: Id
                    );
                if (oGBXir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGBXir.File.FileBytes);
                    // oFileInfo.FileBytes = oGBXir.File.FileBytes;
                    oFileInfo.FileName = oGBXir.File.FileName;
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
