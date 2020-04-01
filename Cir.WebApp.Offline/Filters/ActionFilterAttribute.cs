using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Web.Caching;
using Newtonsoft.Json.Linq;
 
using Microsoft.WindowsAzure.MobileServices;

namespace Cir.WebApp.Offline.Filters
{
    public class SkipMyGlobalActionFilterAttribute : Attribute
    {
    }
    public class CustomFilterAttribute: FilterAttribute, IActionFilter
    {       

        public class AuthenticationResultLocal
        {

            public string AccessToken { get; set; }

            public string AccessTokenType { get; set; }

            public DateTime ExpiresOn { get; set; }

            //public string IdToken { get;  set; }

            //public bool IsMultipleResourceRefreshToken { get;  set; }

            public string RefreshToken { get; set; }

            public string TenantId { get; set; }

        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.OnActionExecuted = "IActionFilter.OnActionExecuted filter called";
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipMyGlobalActionFilterAttribute), false).Any())
            {
                return;
            }
            //CheckValidUserToken(System.Web.HttpContext.Current.User.ToString());
            filterContext.Controller.ViewBag.OnActionExecuting = "IActionFilter.OnActionExecuting filter called";
        }

        //public ActionResult CheckValidUserToken(string userid)//, string refToken, string silent
        //{

        //    string ResourceURL = System.Configuration.ConfigurationManager.AppSettings["MobileAppID"];// +"/login/aad";
        //    string AadInstance = "https://login.windows.net/{0}";

        //    string tenantdomain = System.Configuration.ConfigurationManager.AppSettings["AADTenantDomain"];
        //    string clientid = System.Configuration.ConfigurationManager.AppSettings["AADclientId"];
        //    string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
        //    string AADclientKey = System.Configuration.ConfigurationManager.AppSettings["AADclientKey"];

        //    string authority = String.Format(CultureInfo.InvariantCulture, AadInstance, tenantdomain);
        //    AuthenticationContext authContext = new AuthenticationContext(authority);
        //    ClientCredential clientCred = new ClientCredential(clientid, AADclientKey);
        //    AuthenticationResult ar = null;
        //    AuthenticationResultLocal arl = null;

        //    try
        //    {
        //        arl = System.Web.HttpContext.Current.Cache.Get(userid) as AuthenticationResultLocal;
        //        ar = authContext.AcquireTokenByAuthorizationCode(arl.AccessToken, new Uri(HostName + "/cir/Sign-In"), clientCred, ResourceURL);                
        //    }
        //    catch (AdalServiceException ex)
        //    {
        //        var a = ex;
        //        if (ex.StatusCode == 400 && ex.ErrorCode == "invalid_grant")
        //        {
        //            return new RedirectResult("https://login.microsoftonline.com/" + tenantdomain + "/oauth2/authorize?response_type=code&client_id=" + clientid + "&redirect_uri=" + HostName + "/cir/Sign-In");                                      
        //            // throw new HttpException(401, "invalid_grant");
        //        }
        //        throw ex;
        //    }
        //    return null;
        //}       
    }
}