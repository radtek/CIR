using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cir.WebApp.Offline.Controllers.Cir;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Cir.WebApp.Offline.Filters
{
    public class CustomFilters : ActionFilterAttribute
    {
        //public class AuthenticationResultLocal
        //{
        //    public string AccessToken { get; set; }
        //    public string AccessTokenType { get; set; }
        //    public DateTime ExpiresOn { get; set; }            
        //    public string UserId { get; set; }            
        //    public string RefreshToken { get; set; }
        //    public string TenantId { get; set; }
        //}
        public override async void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName != "Sign-In")
            {
                try
                {
                    //string userid = filterContext.HttpContext.Cache.Get("username") as string;
                    //string Mobileuser = filterContext.HttpContext.Cache.Get("Mobile_username") as string;

                    string ResourceURL = System.Configuration.ConfigurationManager.AppSettings["MobileAppID"];// +"/ 
                    string AadInstance = "https://login.windows.net/{0}";
                    //CirController.AuthenticationResultLocal arl = null;
                    string tenantdomain = System.Configuration.ConfigurationManager.AppSettings["AADTenantDomain"];
                    //string tenantdomain = "VestasDev";
                    string clientId = System.Configuration.ConfigurationManager.AppSettings["AADclientId"];
                    string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
                    string AADclientKey = System.Configuration.ConfigurationManager.AppSettings["AADclientKey"];                    

                    //arl = this.HttpContext.Cache.Get(userid) as AuthenticationResultLocal;
                    //if (arl == null)
                    //{
                    string authority = String.Format(CultureInfo.InvariantCulture, AadInstance, tenantdomain);
                    AuthenticationContext authContext = new AuthenticationContext(authority);
                    ClientCredential clientCred = new ClientCredential(clientId, AADclientKey);

                    //string token;
                    //Task<AuthenticationResult> authenticationResult = authContext.AcquireTokenAsync(resource, clientCred);
                    //token = authenticationResult.Result.AccessToken;


                    var _Token = await authContext.AcquireTokenAsync(ResourceURL, clientCred);                    

                    //string url = "https://login.microsoftonline.com/" + tenantdomain + "/oauth2/token";
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    // Use the Graph REST API to Refresh the token

                    //request.Method = "POST";
                    //request.ContentType = "application/x-www-form-urlencoded";
                    ////request.Host = "https://login.microsoftonline.com";
                    ////request.Headers.Add("Host", "https://login.microsoftonline.com");
                    //using (var sw = new StreamWriter(request.GetRequestStream()))
                    //{
                    //    // Request body must have the group id and a member id to check for membership
                    //    string data = "client_id=" + clientId + "&grant_type=refresh_token&resource=" + ResourceURL + "&client_secret=" + AADclientKey;
                    //    sw.Write(data);
                    //}

                    //WebResponse response = request.GetResponse();
                    //StreamReader sr = new StreamReader(response.GetResponseStream());
                    //string ARjsonstr = sr.ReadToEnd();
                    //JObject ARjson = JObject.Parse(ARjsonstr);
                    //CirController.AuthenticationResultLocal arl = new CirController.AuthenticationResultLocal();
                    //arl.AccessTokenType = ARjson["token_type"].ToString();
                    ////arl.ExpiresOn = new DateTime(Convert.ToInt64(ARjson["expires_on"].ToString()), DateTimeKind.Utc);
                    //arl.ExpiresOn = DateTime.Now.AddMinutes(59);
                    //arl.AccessToken = ARjson["access_token"].ToString();
                    //arl.RefreshToken = ARjson["refresh_token"].ToString();

                    //this.HttpContext.Cache.Remove(userid + "_MobileUser");
                    //this.HttpContext.Cache.Insert(userid, arl, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                    //}
                }
                catch (Exception ex)
                {
                    var a = ex;
                    filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary { { "controller", "Cir" }, { "action", "Sign-In" } });
                }
            }
            return;
        }
       

        public async Task<string> GetAccessTokenByAdDomainAsync(string addomain, string clientId, string clientSecret)
        {
            //Console.WriteLine("Aquiring Access Token from Azure AD");
            var authContext = new AuthenticationContext
            ("https://login.windows.net/" /* AAD URI */
             + $"{addomain}.onmicrosoft.com" /* Tenant ID or AAD domain */);

            var credential = new ClientCredential(clientId, clientSecret);
            string token;
            try
            {
                var result =
                    await authContext.AcquireTokenAsync("https://management.azure.com/", credential);

                token = result.AccessToken;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.Message}");
                throw;
            }

            //Console.WriteLine($"Token: {result.AccessToken}");
            return token;
        }
    }

}
