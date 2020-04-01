using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Cir.WebApp.Offline.Controllers.Cir
{
    public partial class CirController : CirBaseController
    {
        public class JsonErrorModel
        {
            public string ErrorCode { get; set; }
            public int StatusCode { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class AuthenticationResultLocal
        {

            public string AccessToken { get; set; }

            public string AccessTokenType { get; set; }

            public DateTime ExpiresOn { get; set; }

            public DateTime RefreshTokenCreationTime { get; set; }

            public string RefreshToken { get; set; }

            public string TenantId { get; set; }

        }
        public class UserAuthCode
        {
            public AuthenticationResultLocal AuthData { get; set; }
            public MobileUser MobileUserData { get; set; }
        }

        public class MobileUser
        {
            public string mobileServiceAuthenticationToken { get; set; }
            public string userId { get; set; }
        }
        [ActionName("Sign-In")]
        public ActionResult SignIn(string userid, string code, string session_state, string returnUrl)
        {
            try
            {
                string tenantdomain = System.Configuration.ConfigurationManager.AppSettings["AADTenantDomain"];
                string clientid = System.Configuration.ConfigurationManager.AppSettings["AADclientId"];
                string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];

                string ResourceURL = System.Configuration.ConfigurationManager.AppSettings["MobileAppID"];               
                string AADclientKey = System.Configuration.ConfigurationManager.AppSettings["AADclientKey"];

                if (Session["returnUrl"] == null)
                    Session["returnUrl"] = returnUrl;
                else
                {
                    returnUrl = "&returnUrl=";
                    returnUrl += HttpUtility.HtmlDecode(Session["returnUrl"].ToString().Replace('%', '#'));
                    Session.Remove("returnUrl");
                }
                if (string.IsNullOrEmpty(code))
                {
                    ViewBag.ReturnUrl = returnUrl;
                    return new RedirectResult("https://login.microsoftonline.com/" + tenantdomain + "/oauth2/authorize?response_type=code&client_id=" + clientid + "&redirect_uri=" + HostName + "/cir/Sign-In");
                }
                Session["AuthCode"] = code;
                return new RedirectResult(HostName + "/cir?code=yes&session_state=" + session_state + returnUrl);
            }
            catch (AdalException ex)
            {
                var error = new JsonErrorModel
                {
                    ErrorCode = ex.ErrorCode,
                    ErrorMessage = ex.Message,
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }

        [ActionName("Sign-Out")]
        public ActionResult SignOut(string session_state)
        {
            string tenantdomain = System.Configuration.ConfigurationManager.AppSettings["AADTenantDomain"];
            string clientid = System.Configuration.ConfigurationManager.AppSettings["AADclientId"];
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
            if (Session["AuthCode"] != null)
                Session.Remove("AuthCode");

            //Session.Abandon();
            return new RedirectResult("https://login.microsoftonline.com/" + tenantdomain + "/oauth2/logout?post_logout_redirect_uri=" + HostName + "/cir/Sign-In");

        }
        [ActionName("referesh-user")]
        public async Task<JsonResult> refToken(string userid, string refToken, string silent, string refTokenCreationTime)
        {
            string ResourceURL = System.Configuration.ConfigurationManager.AppSettings["MobileAppID"];// +"/login/aad";
            string AadInstance = "https://login.windows.net/{0}";

            string tenantdomain = System.Configuration.ConfigurationManager.AppSettings["AADTenantDomain"];
            string clientid = System.Configuration.ConfigurationManager.AppSettings["AADclientId"];
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];
            string AADclientKey = System.Configuration.ConfigurationManager.AppSettings["AADclientKey"];

            string authority = String.Format(CultureInfo.InvariantCulture, AadInstance, tenantdomain);
            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(clientid, AADclientKey);
            AuthenticationResult authResult = null;
            AuthenticationResultLocal arl = null;

            if (!string.IsNullOrEmpty(refToken) && refToken.Trim().ToLower() != "undefined")
            {
                try
                {
                    Int64 ts = Convert.ToInt64(refTokenCreationTime);
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(ts / 1000d));

                    DateTime startTime = DateTime.UtcNow;
                    DateTime endTime = dt;
                    TimeSpan span = startTime.Subtract(endTime);
                    int minutes = span.Minutes;
                    int hours = span.Hours;
                    int TotalMinutes = (hours * 60) + minutes;
                    if (TotalMinutes < 60)
                    {
                        string UserID = string.Empty;
                        if (userid.Contains("#EXT"))
                        {
                            UserID = userid.Split('#')[0];
                            arl = this.HttpContext.Cache.Get(UserID) as AuthenticationResultLocal;

                            if (arl == null)
                            {
                                UserID = UserID.Replace("_", "@");
                                arl = this.HttpContext.Cache.Get(UserID) as AuthenticationResultLocal;

                                if (arl == null)
                                {
                                    UserID = userid + "_MobileUser";
                                    var CacheData = this.HttpContext.Cache.Get(UserID);
                                    if (CacheData != null)
                                    {
                                        try
                                        {
                                            var data = Newtonsoft.Json.JsonConvert.SerializeObject(CacheData);
                                            var result = JsonConvert.DeserializeObject<UserAuthCode>(data);
                                            arl = result.AuthData;
                                        }
                                        catch (AdalException ex)
                                        {
                                            var error = new JsonErrorModel
                                            {
                                                ErrorCode = ex.ErrorCode,
                                                ErrorMessage = ex.Message,
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        arl = null;
                    }

                    if (arl == null)
                    {                        
                        try
                        {
                            authResult = authContext.AcquireTokenByRefreshToken(refToken, clientCred, ResourceURL);
                            if (authResult == null)
                            {
                                throw new AdalException();
                            }
                            arl = new AuthenticationResultLocal();
                            arl.AccessTokenType = authResult.AccessTokenType;
                            arl.ExpiresOn = DateTime.UtcNow.AddMinutes(59);
                            arl.AccessToken = authResult.AccessToken;
                            arl.RefreshToken = authResult.RefreshToken;
                            arl.RefreshTokenCreationTime = DateTime.UtcNow;

                            this.HttpContext.Cache.Remove(userid + "_MobileUser");
                            this.HttpContext.Cache.Insert(userid, arl, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                        }
                        catch (AdalException ex)
                        {
                            var error = new JsonErrorModel
                            {
                                ErrorCode = ex.ErrorCode,
                                ErrorMessage = ex.Message,
                            };
                            return Json(error, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                catch (AdalException ex)
                {
                    var a = ex;
                    var error = new JsonErrorModel
                    {
                        ErrorCode = ex.ErrorCode,
                        ErrorMessage = ex.Message,
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
            }

            if ((arl == null) && string.IsNullOrEmpty(refToken) || refToken.Trim().ToLower() == "undefined" && (Session["AuthCode"] != null))
            {
                string code = Session["AuthCode"].ToString();
                if (!string.IsNullOrEmpty(code))
                {
                    try
                    {
                        authResult = authContext.AcquireTokenByAuthorizationCode(code, new Uri(HostName + "/cir/Sign-In"), clientCred, ResourceURL);

                        this.HttpContext.Cache.Remove("authResult");
                        // Session["authResult"] = authResult;
                        this.HttpContext.Cache.Insert("authResult", authResult);
                        this.HttpContext.Cache.Remove(authResult.UserInfo.DisplayableId);
                        this.HttpContext.Cache.Remove(authResult.UserInfo.DisplayableId + "_MobileUser");
                        userid = authResult.UserInfo.DisplayableId;
                        arl = new AuthenticationResultLocal();
                        arl.AccessTokenType = authResult.AccessTokenType;
                        arl.ExpiresOn = DateTime.UtcNow.AddMinutes(59);
                        arl.AccessToken = authResult.AccessToken;
                        arl.RefreshToken = authResult.RefreshToken;
                        arl.RefreshTokenCreationTime = DateTime.UtcNow;

                        this.HttpContext.Cache.Insert(userid, arl, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                    catch (AdalServiceException ex)
                    {
                        var a = ex;
                        var error = new JsonErrorModel
                        {
                            ErrorCode = ex.ErrorCode,
                            ErrorMessage = ex.Message,
                        };
                        return Json(error, JsonRequestBehavior.AllowGet);
                    }
                    catch (AdalException ex)
                    {
                        var error = new JsonErrorModel
                        {
                            ErrorCode = ex.ErrorCode,
                            ErrorMessage = ex.Message,
                        };
                        return Json(error, JsonRequestBehavior.AllowGet);
                    }
                }
            }


            object MobileUser = null;
            MobileUser = this.HttpContext.Cache.Get(userid + "_MobileUser") as object;
            if (MobileUser == null)
            {
                JObject payload = new JObject();
                payload["access_token"] = arl.AccessToken;
                Microsoft.WindowsAzure.MobileServices.MobileServiceClient client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(System.Configuration.ConfigurationManager.AppSettings["MobileAppID"]);
                try
                {
                    MobileServiceUser user = await client.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload);

                    MobileUser = new { AuthData = arl, MobileUser = new { mobileServiceAuthenticationToken = user.MobileServiceAuthenticationToken, userId = user.UserId } };
                    this.HttpContext.Cache.Insert("Mobile_username", userid, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                    this.HttpContext.Cache.Insert(userid + "_MobileUser", MobileUser, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
                }
                catch (AdalException ex)
                {
                    var error = new JsonErrorModel
                    {
                        ErrorCode = "-1",
                        ErrorMessage = ex.Message
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(MobileUser, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("refresh-user-formio")]
        public async Task<JsonResult> RefTokenFormio(string userid, string refToken, string silent, string refTokenCreationTime)
        {
            var resourceId = ConfigurationManager.AppSettings.Get("FormIOMobileAppId");
            const string aadInstance = "https://login.windows.net/{0}";

            var tenantdomain = ConfigurationManager.AppSettings["AADTenantDomain"];
            var clientid = ConfigurationManager.AppSettings["AADclientId"];
            var hostName = ConfigurationManager.AppSettings["HostName"];
            var aaDclientKey = ConfigurationManager.AppSettings["AADclientKey"];

            var authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenantdomain);
            var authContext = new AuthenticationContext(authority);
            var clientCred = new ClientCredential(clientid, aaDclientKey);
            AuthenticationResult authResult;
            AuthenticationResultLocal arl = null;

            if (!string.IsNullOrEmpty(refToken) && refToken.Trim().ToLower() != "undefined")
            {
                try
                {
                    Int64 ts = Convert.ToInt64(refTokenCreationTime);
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(ts / 1000d));

                    DateTime startTime = DateTime.UtcNow;
                    DateTime endTime = dt;
                    TimeSpan span = startTime.Subtract(endTime);
                    int minutes = span.Minutes;
                    int hours = span.Hours;
                    int TotalMinutes = (hours * 60) + minutes;
                    if (TotalMinutes < 60)
                    {
                        string UserID = string.Empty;
                        if (userid.Contains("#EXT"))
                        {
                            UserID = userid.Split('#')[0];
                            arl = this.HttpContext.Cache.Get(UserID + "_Formio") as AuthenticationResultLocal;

                            if (arl == null)
                            {
                                UserID = UserID.Replace("_", "@");
                                arl = this.HttpContext.Cache.Get(UserID + "_Formio") as AuthenticationResultLocal;

                                if (arl == null)
                                {
                                    UserID = userid + "_MobileUser";
                                    var CacheData = this.HttpContext.Cache.Get(UserID + "_Formio");
                                    if (CacheData != null)
                                    {
                                        try
                                        {
                                            var data = JsonConvert.SerializeObject(CacheData);
                                            var result = JsonConvert.DeserializeObject<UserAuthCode>(data);
                                            arl = result.AuthData;
                                        }
                                        catch (AdalException ex)
                                        {
                                            var error = new JsonErrorModel
                                            {
                                                ErrorCode = ex.ErrorCode,
                                                ErrorMessage = ex.Message,
                                            };

                                            return Json(error, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (arl == null)
                    {
                        try
                        {
                            authResult = authContext.AcquireTokenByRefreshToken(refToken, clientCred, resourceId);
                            if (authResult == null)
                            {
                                throw new AdalException();
                            }
                            arl = new AuthenticationResultLocal
                            {
                                AccessTokenType = authResult.AccessTokenType,
                                ExpiresOn = DateTime.UtcNow.AddMinutes(59),
                                AccessToken = authResult.AccessToken,
                                RefreshToken = authResult.RefreshToken,
                                RefreshTokenCreationTime = DateTime.UtcNow
                            };

                            HttpContext.Cache.Remove(userid + "_MobileUser_Formio");
                            HttpContext.Cache.Insert(userid + "_Formio", arl, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                        }
                        catch (AdalException ex)
                        {
                            var error = new JsonErrorModel
                            {
                                ErrorCode = ex.ErrorCode,
                                ErrorMessage = ex.Message,
                            };

                            return Json(error, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                catch (AdalException ex)
                {
                    var error = new JsonErrorModel
                    {
                        ErrorCode = ex.ErrorCode,
                        ErrorMessage = ex.Message,
                    };

                    return Json(error, JsonRequestBehavior.AllowGet);
                }
            }

            //updated the code flow as per the recent changes of microsoft
            if ((arl == null) && string.IsNullOrEmpty(refToken) || refToken.Trim().ToLower() == "undefined")
            {
                try
                {
                    //fetch refresh token and user info
                    var authRes = ((AuthenticationResult)this.HttpContext.Cache.Get("authResult"));
                    var refreshToken = authRes.RefreshToken;
                    var userInfo = authRes.UserInfo;
                    authResult = authContext.AcquireTokenByRefreshToken(refreshToken, clientCred);

                    HttpContext.Cache.Remove(userInfo.DisplayableId + "_Formio");
                    HttpContext.Cache.Remove(userInfo.DisplayableId + "_MobileUser_Formio");

                    userid = userInfo.DisplayableId;

                    arl = new AuthenticationResultLocal
                    {
                        AccessTokenType = authResult.AccessTokenType,
                        ExpiresOn = DateTime.UtcNow.AddMinutes(59),
                        AccessToken = authResult.AccessToken,
                        RefreshToken = authResult.RefreshToken,
                        RefreshTokenCreationTime = DateTime.UtcNow
                    };

                    HttpContext.Cache.Insert(userid + "_Formio", arl, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                }
                catch (AdalServiceException ex)
                {
                    var error = new JsonErrorModel
                    {
                        ErrorCode = ex.ErrorCode,
                        ErrorMessage = ex.Message,
                    };

                    return Json(error, JsonRequestBehavior.AllowGet);
                }
                catch (AdalException ex)
                {
                    var error = new JsonErrorModel
                    {
                        ErrorCode = ex.ErrorCode,
                        ErrorMessage = ex.Message,
                    };

                    return Json(error, JsonRequestBehavior.AllowGet);
                }
                //}
            }


            var mobileUser = HttpContext.Cache.Get(userid + "_MobileUser_Formio");

            if (mobileUser == null)
            {
                var payload = new JObject();
                payload["access_token"] = arl.AccessToken;

                MobileServiceClient client;

                if (Request.IsLocal)
                {
                    client = new MobileServiceClient(ConfigurationManager.AppSettings.Get("FormIOMobileAppUrl"))
                    {
                        AlternateLoginHost = new Uri(resourceId)
                    };
                }
                else
                {
                    client = new MobileServiceClient(resourceId);
                }

                try
                {
                    var user = await client.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload);

                    mobileUser = new { AuthData = arl, MobileUser = new { mobileServiceAuthenticationToken = user.MobileServiceAuthenticationToken, userId = user.UserId } };
                    HttpContext.Cache.Insert("Mobile_username_Formio", userid, null, arl.ExpiresOn.AddMinutes(-5), System.Web.Caching.Cache.NoSlidingExpiration);
                    HttpContext.Cache.Insert(userid + "_MobileUser_Formio", mobileUser, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
                }
                catch (AdalException ex)
                {
                    var error = new JsonErrorModel
                    {
                        ErrorCode = "-1",
                        ErrorMessage = ex.Message
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(mobileUser, JsonRequestBehavior.AllowGet);
        }
    }
}