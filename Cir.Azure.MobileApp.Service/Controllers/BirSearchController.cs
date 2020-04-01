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
using Cir.Azure.MobileApp.Service.Filters;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    [LoggingFilters]
    public class BirSearchController : ApiController
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
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Bir> Post(Cir.Azure.MobileApp.Service.CirSyncService.Bir bir)
        {
            //Cir.Azure.MobileApp.Service.CirSyncService.CirQuickSearch SearchItems = new CirSyncService.CirQuickSearch();
            //SearchItems.CIMCaseNumber = 0;
            //SearchItems.TurbineNumber = 42444;
            //SearchItems.ReportTypeId = 0;
            //SearchItems.ComponentInspectionReportTypeId = 0;

            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).BirSearch(
                        bir: bir
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Delete Bir by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("api/BirDelete/{Id}")]
        public bool BirDelete(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).DeleteBir(
                    BirID: Id
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Download bir word doc
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/BirWordFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile BirWordFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Bir oBir = (new SyncServiceUtilities(this)).BirFile(
                    BirID: Id
                    );
                if (oBir.File != null)
                {
                    oFileInfo.DownloadUrl = oBir.File.FileBytes != null ? Convert.ToBase64String(oBir.File.FileBytes) : null;
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileStatus = oBir.File.FileStatus;
                    oFileInfo.FileName = oBir.File.FileName != null ? oBir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".docx" : null;
                }

                //string DocumentPath = HttpContext.Current.Server.MapPath("~/api/BirPdfDownload/BirFiles");
                //string UniqueID = oBir.File.FileName.Replace(@"\", "_").Replace("/", "_");
                //string DestinationFolderPath = Path.Combine(DocumentPath, UniqueID);
                //try
                //{
                //    if (!Directory.Exists(DestinationFolderPath))
                //    {
                //        Directory.CreateDirectory(DestinationFolderPath);
                //    }
                //}
                //catch { return null; }

                //#region Converting bytes to Word
                //FileStream fs = new FileStream(Path.Combine(DestinationFolderPath, UniqueID + ".docx"), FileMode.Create, FileAccess.ReadWrite);
                //BinaryWriter bw = new BinaryWriter(fs);
                //bw.Write(oBir.File.FileBytes);
                //bw.Flush();
                //bw.Close();
                //#endregion

                //oFileInfo.DownloadUrl = ConfigurationManager.AppSettings["DownloadUrl"].ToString() + UniqueID + "/" + UniqueID + ".docx";
                //oFileInfo.FileName = UniqueID + ".docx";
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.Message, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        /// <summary>
        /// Download bir pdf
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/BirPdfFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile BirPdfFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Bir oBir = (new SyncServiceUtilities(this)).GetBirPDF(
                    BirDataID: Id
                    );

                if (oBir.File != null)
                {
                    oFileInfo.DownloadUrl = oBir.File.FileBytes != null ? Convert.ToBase64String(oBir.File.FileBytes) : null;
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileStatus = oBir.File.FileStatus;
                    oFileInfo.FileName = oBir.File.FileName != null ? oBir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf" : null;
                }
                //string DocumentPath = DocumentPath = HttpContext.Current.Server.MapPath("~/api/BirPdfDownload/BirFiles"); //HttpContext.Current.Server.MapPath("BirFiles");
                //string UniqueID = oBir.File.FileName.Replace(@"\", "_").Replace("/", "_");
                //string DestinationFolderPath = Path.Combine(DocumentPath, UniqueID);
                //try
                //{
                //    if (!Directory.Exists(DestinationFolderPath))
                //    {
                //        Directory.CreateDirectory(DestinationFolderPath);
                //    }
                //}
                //catch { return null; }

                //#region Converting bytes to Word
                //FileStream fs = new FileStream(Path.Combine(DestinationFolderPath, UniqueID + ".docx"), FileMode.Create, FileAccess.ReadWrite);
                //BinaryWriter bw = new BinaryWriter(fs);
                //bw.Write(oBir.File.FileBytes);
                // bw.Flush();
                //bw.Close();
                //fs.Close();
                //#endregion

                //#region Applying spire license
                //string SpireLicensePath = HttpContext.Current.Server.MapPath("~/SpireLicense");
                //Spire.License.LicenseProvider.SetLicenseFileName("license.lic");
                //Spire.License.LicenseProvider.SetLicenseFileFullPath(Path.Combine(SpireLicensePath, "license.lic"));
                //Spire.License.LicenseProvider.LoadLicense();
                //#endregion


                //Document doc = new Document(Path.Combine(DestinationFolderPath, UniqueID + ".docx"));
                //doc.SaveToFile(DestinationFolderPath + @"\" + UniqueID + ".pdf", FileFormat.PDF);
                //doc.Close();
                //oFileInfo.DownloadUrl = ConfigurationManager.AppSettings["DownloadUrl"].ToString() + UniqueID + "/" + UniqueID + ".pdf";
                //oFileInfo.FileName = UniqueID + ".pdf";
                return oFileInfo;

            }
            catch (Exception ex)
            {
                GetSyncUtility().Log("Cir.Azure.MobileApp", ex.StackTrace, CirSyncService.LogType.Error);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.StackTrace.ToString() + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }

        [HttpPost]
        [Route("api/CirPdfFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile CirPdfFile(long Id, long cirid = 0)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Bir oBir = (new SyncServiceUtilities(this)).GetCirPDF(
                    CirDataID: Id, CirID: cirid
                    );
                if (oBir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oBir.File.FileBytes);
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileName = oBir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
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
        [Route("api/CirPdfFileByCIRId/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile CirPdfFileByCIRId(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            return CirPdfFile(0, Id);
        }

        [HttpPost]
        [Route("api/CirPdfFileZip/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.BirFile CirPdfFileZip(string Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Bir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.BirFile oFileInfo = new CirSyncService.BirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Bir oBir = (new SyncServiceUtilities(this)).GetCIRPdfZip(
                    CirDataIDs: Id
                    );
                if (oBir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oBir.File.FileBytes);
                    // oFileInfo.FileBytes = oBir.File.FileBytes;
                    oFileInfo.FileName = oBir.File.FileName;
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
        [Route("api/UnlockCirDataByCirID/{Id}")]
        public bool UnlockCirDataByCirID(long CirID)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Unlock CirData By CirID custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).UnlockCirDataByCirID(CirID: CirID);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
    }
}
