using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
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
                return ConfigurationManager.ConnectionStrings["ApplicationConnection"].ConnectionString;
            }
        }
    }
}