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
    public class GirSearchController : ApiController
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
        public List<Cir.Azure.MobileApp.Service.CirSyncService.Gir> Post(Cir.Azure.MobileApp.Service.CirSyncService.Gir gir)
        {
            //Cir.Azure.MobileApp.Service.CirSyncService.CirQuickSearch SearchItems = new CirSyncService.CirQuickSearch();
            //SearchItems.CIMCaseNumber = 0;
            //SearchItems.TurbineNumber = 42444;
            //SearchItems.ReportTypeId = 0;
            //SearchItems.ComponentInspectionReportTypeId = 0;

            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).GirSearch(
                        gir: gir
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Delete Gir by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/GirDelete/{Id}")]
        public bool GirDelete(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).DeleteGir(
                    GirID: Id
                    );
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.GetBaseException().InnerException.Message));
            }
        }
        /// <summary>
        /// Download gir word doc
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GirWordFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GirFile GirWordFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GirFile oFileInfo = new CirSyncService.GirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gir oGir = (new SyncServiceUtilities(this)).GirFile(
                    GirID: Id
                    );
                if (oGir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGir.File.FileBytes);
                    // oFileInfo.FileBytes = oGir.File.FileBytes;
                    oFileInfo.FileName = oGir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".docx";
                }

                //string DocumentPath = HttpContext.Current.Server.MapPath("~/api/GirPdfDownload/GirFiles");
                //string UniqueID = oGir.File.FileName.Replace(@"\", "_").Replace("/", "_");
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
                //bw.Write(oGir.File.FileBytes);
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
        /// Download gir pdf
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/GirPdfFile/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GirFile GirPdfFile(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GirFile oFileInfo = new CirSyncService.GirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gir oGir = (new SyncServiceUtilities(this)).GetGirPDF(
                    GirDataID: Id
                    );

                if (oGir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGir.File.FileBytes);
                    // oFileInfo.FileBytes = oGir.File.FileBytes;
                    oFileInfo.FileName = oGir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
                }
                //string DocumentPath = DocumentPath = HttpContext.Current.Server.MapPath("~/api/GirPdfDownload/GirFiles"); //HttpContext.Current.Server.MapPath("GirFiles");
                //string UniqueID = oGir.File.FileName.Replace(@"\", "_").Replace("/", "_");
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
                //bw.Write(oGir.File.FileBytes);
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
        [Route("api/CirPdfFileGIR/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GirFile CirPdfFileGIR(long Id, long cirid = 0)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GirFile oFileInfo = new CirSyncService.GirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gir oGir = (new SyncServiceUtilities(this)).GetCIRPdfGIR(
                    CirDataID: Id, CirID: cirid
                    );
                if (oGir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGir.File.FileBytes);
                    // oFileInfo.FileBytes = oGir.File.FileBytes;
                    oFileInfo.FileName = oGir.File.FileName.Replace(@"\", "_").Replace("/", "_") + ".pdf";
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
        [Route("api/CirPdfFileByCIRIdGIR/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GirFile CirPdfFileByCIRId(long Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            return CirPdfFileGIR(0, Id);
        }

        [HttpPost]
        [Route("api/CirPdfFileZipGIR/{Id}")]
        public Cir.Azure.MobileApp.Service.CirSyncService.GirFile CirPdfFileZip(string Id)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Gir sesarch custom controller!");
            try
            {
                Cir.Azure.MobileApp.Service.CirSyncService.GirFile oFileInfo = new CirSyncService.GirFile();

                Cir.Azure.MobileApp.Service.CirSyncService.Gir oGir = (new SyncServiceUtilities(this)).GetCIRPdfZipGIR(
                    CirDataIDs: Id
                    );
                if (oGir.File != null)
                {
                    oFileInfo.DownloadUrl = Convert.ToBase64String(oGir.File.FileBytes);
                    // oFileInfo.FileBytes = oGir.File.FileBytes;
                    oFileInfo.FileName = oGir.File.FileName;
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
