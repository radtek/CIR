using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cir.WebApp.Offline.Utility;
using Cir.WebApp.Offline.Models.Cir.StandardText;

namespace Cir.WebApp.Offline.Controllers.Cir
{
    public partial class CirController : CirBaseController
    {
        //
        // GET: /User/

        [ActionName("Manage-StandardText")]
        public ActionResult StandardTexts()
        {
            return View("~/Views/Cir/StandardText/StandardTextList.aspx");
        }




        [ActionName("save-StandText")]
        public ActionResult SaveStandardText()
        {
            return View("~/Views/Cir/StandardText/SaveStandardText.aspx");
        }

        [ActionName("save-StandText")]
        [HttpPost]
        public ActionResult SaveStandardText(StandTextModel Model)
        {
            return View("~/Views/Cir/StandardText/SaveStandardText.aspx");
        }


    }
}
