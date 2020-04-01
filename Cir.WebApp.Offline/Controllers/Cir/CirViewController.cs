using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cir.WebApp.Offline.Utility;

namespace Cir.WebApp.Offline.Controllers.Cir
{
    public class CirViewController : CirBaseController
    {
        //
        // GET: /CirView/

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("manage-cirviewlist")]
        public ActionResult ManageCirViewList()
        {
            Response.Cache.SetCacheability(
            System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            int viewId = UserPreferences.UserPreference;
            ViewBag.ViewId = viewId;

            return View("~/Views/Cir/Cir/ManageCirViewList.aspx");
        }

        [ActionName("manage-cirview")]
        [HttpPost]
        public ActionResult ManageCirView(int ddlCirViews = -1)
        {
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache); // Offline cacheing enabled
            ViewBag.ViewId = ddlCirViews;
            UserPreferences.UserPreference = ddlCirViews;
            return View("~/Views/Cir/Cir/ManageCirView.aspx");
        }

        [ActionName("save-cirviewid")]
        [HttpPost]
        public void ManageCirViewId(int viewId)
        {
            UserPreferences.UserPreference = viewId;
            ViewBag.ViewId = viewId;
         
        }
    }
}
