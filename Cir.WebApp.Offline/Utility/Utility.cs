using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Cir.WebApp.Offline.Utility
{
    public static class Utility
    {
        /// <summary>
        /// Connection string from web.config
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString();
            }
        }
    }
}
