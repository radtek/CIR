using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cir.WebApp.Offline.Controllers.Cir
{
    public partial class CirController : CirBaseController
    {
        //
        // GET: /test/
        [ActionName("Manage-test")]
        public ActionResult testView()
        {
            return View("~/Views/Cir/BIR/TestView.aspx");
        }
        [OutputCache(Duration =0)]
        [ActionName("CheckStatus")]
        public bool CheckOnlineStatus()
        {
            return true;
        }
    }
}
