using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cir.Azure.MobileApp.Service.Utilities.GraphApi
{
    public class Helper
    {

        /// <summary>
        ///     Returns a random string of upto 32 characters.
        /// </summary>
        /// <returns>String of upto 32 characters.</returns>
        public static string GetRandomString(int length = 32)
        {
            //because GUID can't be longer than 32
            return Guid.NewGuid().ToString("N").Substring(0, length > 32 ? 32 : length);
        }
    }

    //public class PortalSettings
    //{
    //    public string TenantId { get; set; }
    //    public string ClientId { get; set; }
    //    public string ClientSecret { get; set; }
    //    public string ClientIdForUserAuthn { get; set; }
    //}
}