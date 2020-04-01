using System;
using System.Web.Mvc;
//using Microsoft.ApplicationInsights;
using System.Web.Http.Filters;
//using PLMWebService.VestasServiceNow;
//using Microsoft.ApplicationInsights;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;

namespace Cir.WebApp.Offline.Filters
{
    /// <summary>
    /// Service now request parameters
    /// </summary>
    public class clsParameters
    {
        /// <summary>
        /// caller id
        /// </summary>
        public string caller_id { get; set; }
        /// <summary>
        /// content type
        /// </summary>
        public string content_type { get; set; }
        /// <summary>
        /// sub category
        /// </summary>
        public string subcategory { get; set; }
        /// <summary>
        /// comments
        /// </summary>
        public string comments { get; set; }
        /// <summary>
        /// short description
        /// </summary>
        public string short_description { get; set; }
        /// <summary>
        /// description
        /// </summary>
        public string description { get; set; }
    }
    /// <summary>
    /// Exception filter is used to log all the exceptions in application insights and raise a ticket for the same in service now.
    /// </summary>
    public class AiHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
        }
        //public override void OnException(HttpActionExecutedContext filterContext)
        //{
        //    if (filterContext != null && filterContext.Exception != null)
        //    {
        //        try
        //        {
        //            //Service now integration to create incidents automatically in service now
        //            //var vestasServiceNow = "https://vestasdev.service-now.com/api/now/table/incident?sysparm_limit=1";
        //            var vestasServiceNow = ConfigurationManager.AppSettings["VestasServiceNowUrl"];
        //            var serviceNowUser = ConfigurationManager.AppSettings["ServiceNowUser"];
        //            var serviceNowPwd = ConfigurationManager.AppSettings["ServiceNowPwd"];
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(vestasServiceNow);
        //                client.DefaultRequestHeaders.Accept.Clear();
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        //       "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(serviceNowUser + ":" + serviceNowPwd)));
        //                // "webservice_msmon:webservice_msmon")));//Service Now Production Password: M$M0n1t0r1ng_V3$t@$2016
        //                clsParameters param = new clsParameters();
        //                param.caller_id = "webservice_msmon";
        //                param.content_type = "webservice";
        //                param.subcategory = "monitoring event";
        //                param.short_description = "PLMWebService Exception";
        //                param.description = filterContext.Exception.Message;
        //                param.comments = filterContext.Exception.Message;
        //                HttpResponseMessage response = client.PostAsJsonAsync(new Uri(vestasServiceNow), param).Result;
        //                var jsonString = response.Content.ReadAsStringAsync().Result;
        //                dynamic results = JsonConvert.DeserializeObject<dynamic>(jsonString);
        //                var number = results.result.number.Value;
        //                //Application insights exception logging
        //                var ai = new TelemetryClient();
        //                ai.Context.InstrumentationKey = ConfigurationManager.AppSettings["instrumentationKey"];
        //                ai.TrackEvent("Created a new service now incident with ticket number:" + number + " Description: PLMWebService Exception - " + filterContext.Exception.Message);
        //                ai.TrackException(filterContext.Exception);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    base.OnException(filterContext);
        //}
    }
}