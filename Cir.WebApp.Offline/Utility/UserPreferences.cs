using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cir.WebApp.Offline.Utility
{
    public static class UserPreferences
    {
        private static int ViewId = -1;
        public static int UserPreference
        {
            get
            {
                var context = new HttpContextWrapper(HttpContext.Current);
                var cookie = context.Request.Cookies["CirViewId"];
                if (cookie != null)
                {
                    return int.Parse(cookie.Value);
                }
                else
                {
                    return -1;
                }


            }
            set
            {
                ViewId = value;
                var context = new HttpContextWrapper(HttpContext.Current);
                var cookie = new HttpCookie("CirViewId", ViewId.ToString());
                context.Response.SetCookie(cookie);

            }
        }

    }
}