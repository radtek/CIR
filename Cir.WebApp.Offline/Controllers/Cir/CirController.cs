using Cir.WebApp.Offline.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Cir.WebApp.Offline.Controllers.Cir
{
    public partial class CirController : CirBaseController
    {
        
        /// <summary>
        /// Cir Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(
               System.Web.HttpCacheability.NoCache);
            return View("Default");
        }
        /// <summary>
        /// Manages the dash board.
        /// </summary>
        /// <returns></returns>
        [ActionName("Manage-Dashboard")]
        public ActionResult ManageDashBoard()
        {
            return View("Default.aspx");
        }

        /// <summary>
        /// Create Cir
        /// </summary>
        /// <returns></returns>
        [ActionName("manage-cir")]
        public ActionResult ManageCir()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/ManageCir.aspx");
        }

        /// <summary>
        /// Create Form.IO Cir
        /// </summary>
        /// <returns></returns>
        [ActionName("formio-cir")]
        public ActionResult FormioCir()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/FormioCir.aspx");
        }

        [ActionName("local-history")]
        public ActionResult LocalHistory()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/LocalHistory.aspx");
        }
        [ActionName("non-drone-inspection")]
        public ActionResult NonDroneInspection()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            return View("~/Views/Cir/Cir/NonDroneInspection.aspx");
        }
        [ActionName("drone-inspection-main-page")]
        public ActionResult DroneInspectionMainPage()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            return View("~/Views/Cir/Cir/BladeInspectionMainPage.aspx");
        }
        

        [ActionName("cir-search")]
        public ActionResult CirSearch()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/CirSearch.aspx");
        }

        [ActionName("cir-pdf")]
        public ActionResult CirPdfDownload()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/PdfDownload.aspx");
        }

        [ActionName("MobileUnlockPage")]
        public ActionResult MobileUnlockPage()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/MobileUnlockPage.aspx");
        }

        [ActionName("manage-cirview")]
        public ActionResult ManageCirView()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/ManageCirView.aspx");
        }

        public ActionResult Manifest()
        {
            Response.ContentType = "text/cache-manifest";
            Response.ContentEncoding =
                System.Text.Encoding.UTF8;
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache);
            return View();
        }

        [ActionName("Log-Viewer")]
        public ActionResult LogViewer()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/LogViewer.aspx");
        }

        [ActionName("Cir-Details")]
        public ActionResult CirDetails(int ID,int ViewId = 0)
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            if (ViewId != 0)
            {
                ViewBag.ViewId = ViewId;
                UserPreferences.UserPreference = ViewId;
            }
            return View("~/Views/Cir/Cir/_CIRDetails.aspx");
        }

        /// <summary>
        /// Create Cir
        /// </summary>
        /// <returns></returns>
        [ActionName("test-image")]
        public ActionResult testimage()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/testimage.cshtml");
        }

        [ActionName("Manage-Feedback")]
        public ActionResult ManageFeedback()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Feedback/SaveFeedback.aspx");
        }

        [ActionName("Feedback-list")]
        public ActionResult FeedbackList()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Feedback/FeedbackList.aspx");
        }

        [ActionName("manufacturer")]
        public ActionResult ManufacturerList()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/ManageManufacturer/ManufacturerList.aspx");
        }

        [ActionName("manage-user")]
        public ActionResult ManageUser()
        {
            Response.Cache.SetCacheability(
               System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            return View("~/Views/Cir/User/ManageUser.aspx");
        }

        [ActionName("manage-group")]
        public ActionResult ManageGroup()
        {
            Response.Cache.SetCacheability(
               System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            return View("~/Views/Cir/User/ManageGroup.aspx");
        }


        [ActionName("hotlist")]
        public ActionResult Hotlist()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/ManageHotlist/Hotlist.aspx");
        }
        [ActionName("System-Log")]
        public ActionResult SystemLog()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/SystemLog.aspx");
        }

        [ActionName("Manage-Draft")]
        public ActionResult ResolveError()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/Cir/ManageDraftCIR.aspx");
        }


        [ActionName("Service-Information")]
        public ActionResult ManageServiceInformation()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled ServiceInformationList

            return View("~/Views/Cir/ServiceInformation/ServiceInformationList.aspx");
        }

        [ActionName("advanced-search")]
        public ActionResult AdvancedSearch()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled

            return View("~/Views/Cir/AdvancedSearch/CirAdvancedSearch.aspx");
        }

        [ActionName("create-template")]
        public ActionResult CreateTemplate()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled ServiceInformationList

            return View("~/Views/Cir/Template/CreateTemplate.aspx");
        }

        [ActionName("my-service-information")]
        public ActionResult MyServiceInformation()
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled ServiceInformationList

            return View("~/Views/Cir/ServiceInformation/MyServiceInformation.aspx");
        }

        [ActionName("Show-pdf")]
        public ActionResult ShowPdf()
        {
            if (System.IO.File.Exists(Server.MapPath("~/Views/Cir/Help.pdf")))
            {
                string pathSource = Server.MapPath("~/Views/Cir/Technician_User_Guide1.2.pdf");
                FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fsSource, "application/pdf");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        [ActionName("Show-pdf2")]
        public ActionResult ShowPdf2()
        {
            if (System.IO.File.Exists(Server.MapPath("~/Views/Cir/Help.pdf")))
            {
                string pathSource = Server.MapPath("~/Views/Cir/Tech_Support_User_Guide1.2.pdf");
                FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fsSource, "application/pdf");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        [ActionName("show-video")]
        public ActionResult ShowVideo()
        {
            var filePath = "~/Video/UBI_CIR_upload_tool.mp4";
            if (System.IO.File.Exists(Server.MapPath(filePath)))
            {
                return new VideoResult(filePath);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [ActionName("Show-pdf3")]
        public ActionResult ShowPdf3()
        {
            if (System.IO.File.Exists(Server.MapPath("~/Views/Cir/Help.pdf")))
            {
                string pathSource = Server.MapPath("~/Views/Cir/DEUTech_Support_UserGuide_1.2.pdf");
                FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fsSource, "application/pdf");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [ActionName("Show-pdf4")]
        public ActionResult ShowPdf4()
        {
            if (System.IO.File.Exists(Server.MapPath("~/Views/Cir/Help.pdf")))
            {
                string pathSource = Server.MapPath("~/Views/Cir/ESTechnician_UserGuide_1.2.pdf");
                FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fsSource, "application/pdf");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }


        [ActionName("GetBlobUrl")]
        public ActionResult GetBlobUrl(string cirGuid)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(cirGuid);
            //Compute hash based on source data.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            Console.WriteLine(ByteArrayToString(tmpHash));
            //compute integer values from hash 
            int intVal = Math.Abs(BitConverter.ToInt32(tmpHash, 0));
            Console.WriteLine("Interger val " + intVal);
            //calculate storage partitions 0-15
            int strgPart = intVal % 15;
            string BlobUrl = System.Configuration.ConfigurationManager.AppSettings["BlobStorage" + strgPart];
            return Content(BlobUrl);
        }
        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }






    }
}
