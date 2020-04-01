using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Services;
using Cir.Data.Access.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.DataManipulation;
using System.Threading.Tasks;
using Serilog;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// Cir submission data controller.
    /// </summary>
    [MobileAppController]
    public class CirSubmissionDataController : ApiController
    {
        private ICirSubmissionService _cirSubmissionService;
        TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// Constructor of cir submission data controller
        /// </summary>
        /// <param name="cirSubmissionService"></param>
        /// <param name="log"></param>
        public CirSubmissionDataController(ICirSubmissionService cirSubmissionService, ILogger log)
        {
            _cirSubmissionService = cirSubmissionService;
        }

        //There are two GET methods avaliable. Description provided on the other one.
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get(string templateId)
        {
            try
            {
                return Ok(_cirSubmissionService.GetAll(templateId));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Get for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Cir Report by Id, Get all Reports
        /// </summary>
        /// <remarks>
        /// There are two GET methods avaliable. 
        /// The first is for selecting one Report object, by parameter. 
        /// The second is for selecting every Report object in the database, 
        /// hence no additional parameters are required. 
        /// This combined description is provided as for a single header
        /// because default Swagger behaviour does not support 
        /// custom multiple API headers descriptions in an Mobile App project type. 
        /// There is also an issue with parameters optional/required description.
        /// For now the correct one is in Description column, not Value column.
        /// The solution may exist, this functionality is to be improved.
        /// </remarks>
        /// <param name="reportId">(optional) Id (GUID) by which search for a Report object will be performed.</param>
        /// <returns></returns>
        //This attribute provides custom description for controller 
        //but the avaliable headers are beeing aggregated by it so it has to be provided for every header.
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CirSubmissionData), Description = "JSON representing Report object or collection of Report objects.")]
        public IHttpActionResult Get(string reportId, string templateId)
        {
            try
            {
                return Ok(_cirSubmissionService.Get(reportId, templateId));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Get for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Cir Report by numberic Id
        /// </summary>
        /// <param name="reportId">Numeric Cir Id</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CirSubmissionData), Description = "JSON representing Report object or collection of Report objects.")]
        [HttpGet]
        public IHttpActionResult GetById(long reportId)
        {
            try
            {
                return Ok(_cirSubmissionService.GetByCirId(reportId));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/GetById for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// SyncRequest synchronous call
        /// </summary>
        /// <param name="reportsToSync"></param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides Sync functionality between User's data in Browser and Azure CosmosDB." })]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<CirSubmissionData>), Description = "List of reports. Each report can be in one of two possible data states. If a Report consists of a regular, completed data it is intended to be saved in browser. If a Report's schema and data properties are empty, this means that these reports are to be send again, using 2nd Sync Call to be saved in Azure CosmosDB.")]
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult SyncRequest([FromBody]IEnumerable<CirSubmissionData> reportsToSync)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                return Ok(_cirSubmissionService.SyncRequest(user, reportsToSync));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken); //Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/SyncRequest for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Second Sync call. This method is used to pass the list of reports to be saved or updated in Azure.
        /// </summary>
        /// <param name="reportToUpdate">Report with complete data.</param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides Sync functionality between User's data in Browser and Azure CosmosDB." })]
        [HttpPost]
        [GzipCompression]
        public IHttpActionResult SyncUpdate([FromBody]CirSubmissionData reportToUpdate)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                // var user = Request.Properties[AuthorizeRolesAttribute.GraphApiUserKey] as UserInformation;                
                return Ok(_cirSubmissionService.SyncUpdate(reportToUpdate, user.DisplayName));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/SyncUpdate for user " + user1.DisplayName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Insert Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        [HttpPost]
        [GzipCompression]
        public IHttpActionResult Send([FromBody]CirSubmissionData report)
        {
            try
            {
                return Ok(_cirSubmissionService.Add(report));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Send for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        public IHttpActionResult Put([FromBody]CirSubmissionData report)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                return Ok(_cirSubmissionService.Update(report, user.DisplayName));
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Put for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Submit the CIR report from Approved status
        /// </summary>
        /// <param name="reportId">Numeric cirId</param>
        /// <param name="comment">comment</param>
        /// <returns>OK 200</returns>
        [HttpPut]
        //[AuthorizeRoles]
        public IHttpActionResult BackToSubmit(long reportId, string comment)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _cirSubmissionService.SubmitFromApprove(reportId, user.DisplayName, comment);
                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/BackToSubmit for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Approve the CIR report
        /// </summary>
        /// <param name="reportId">Numeric cirId</param>
        /// <param name="comment">Ncomment</param>
        /// <returns>OK 200</returns>
        [HttpPut]
        //[AuthorizeRoles]
        public IHttpActionResult Approve(long reportId, string comment)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _cirSubmissionService.Approve(reportId, user.DisplayName, comment);
                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Approve for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Reject the CIR report
        /// </summary>
        /// <param name="reportId">Numeric cirId</param>
        /// <param name="comment">comment</param>
        /// <returns>OK 200</returns>
        [HttpPut]
       //[AuthorizeRoles]
        public IHttpActionResult Reject(long reportId, string comment)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _cirSubmissionService.Reject(reportId, user.DisplayName, comment);
                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Reject for user " + user1.UserName + "reportId:" + reportId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Delete Cir Report
        /// </summary>
        /// <param name="reportId">Numeric cirId</param>
        /// <returns>OK 200</returns>
        [HttpDelete]
        //[AuthorizeRoles]
        public IHttpActionResult Delete(string reportId)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                _cirSubmissionService.Delete(Convert.ToInt64(reportId.ToString().Substring(0, reportId.ToString().IndexOf('.') < 0 ? reportId.ToString().Length : reportId.ToString().IndexOf('.'))), user.DisplayName, reportId);
                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Delete for user " + user1.UserName + "reportId:" + reportId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Approve and submit the CIR report
        /// </summary>
        /// <param name="reportToSubmit">Report with data to submit</param>
        /// <returns>OK 200</returns>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult SubmitAndApprove([FromBody]CirSubmissionData reportToSubmit)
        {
            try
            {
                string authToken = string.Empty;
                try
                {
                    #region [Adding UploadedImagesCache Attribute]
                    JObject obj = reportToSubmit.Data as JObject;
                    try
                    {
                        obj["txtTurbineNumber"] = Convert.ToInt32(obj["txtTurbineNumber"]);
                        obj["txtAlarmLogNumber"] = Convert.ToInt32(obj["txtAlarmLogNumber"]);
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackException(e);
                        _telemetryClient.TrackEvent("Failed to convert txtTurbineNumber, txtAlarmLogNumber into string. Exception Message: " + e.Message);
                    }
                    try
                    {
                        obj["ddlInstallationDateType"] = "2";
                        obj["dtInstallationDate"] = obj["dtCommissioningdate"];
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackException(e);
                        _telemetryClient.TrackEvent("Failed to assign values in ddlInstallationDateType and dtInstallationDate fields. Exception Message: " + e.Message);
                    }
                    try
                    {
                        obj.SelectToken("txtTurbineNumber").Parent.AddAfterSelf(new JProperty("ctbUpTowerSolutionAvailable", false));
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                    }
                    var Sections = ((Newtonsoft.Json.Linq.JContainer)obj["imagecomponentKey"])["sections"];//((Newtonsoft.Json.Linq.JContainer)reportToSubmit.Data["imagecomponentKey"])["sections"];
                    string strUploadedImageCache = "[";
                    foreach (var section in Sections)
                    {
                        foreach (var img in section.First["images"])
                        {
                            //if (!string.IsNullOrEmpty(Convert.ToString(img["observations"][0]["findingType"])))
                            //    img["observations"][0]["findingType"] = Convert.ToString(img["observations"][0]["damageType"]);
                            var imgObservation = string.Empty;
                            try
                            {
                                var ds = Convert.ToInt32(img["damageSeverity"]);

                                var color = (ds == 0 ? SeverityColors.Severity0 : (ds == 1 ? SeverityColors.Severity1 : (ds == 2 ? SeverityColors.Severity2 : (ds == 3 ? SeverityColors.Severity3 : (ds == 4 ? SeverityColors.Severity4 : (ds == 5 ? SeverityColors.Severity5 : SeverityColors.UnassignedColor))))));

                                imgObservation += "[{\"damageType\": null,\"observationType\": null, \"surfaceType\": null, \"location\": null, \"size\": {\"width\": \"1024\", \"height\": 768, \"depth\": null}, \"severity\": " + ds + ", \"date\": null, \"name\": \"" + Convert.ToString(img["fileInfo"]["name"]) + "\",\"findingType\": \"\", \"comment\": null, \"polygons\": [{\"text\": \"\", \"center\": {\"z\": null, \"x\": 512, \"y\": 384 }, \"severity\": -1, \"geometry\": [{ \"z\": null, \"x\": 0, \"y\": 0}, { \"z\": null, \"x\": \"1024\", \"y\": 0 }, { \"z\": null, \"x\": \"1024\", \"y\": 768}, { \"z\": null, \"x\": 0, \"y\": 768 }]}]}]";
                                JToken objImageObservation = JToken.Parse(imgObservation);
                                JObject objData = img as JObject;
                                #region [Adding missing fields in windams sections]
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("observations", objImageObservation));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("radius", Convert.ToInt32(Math.Abs(Convert.ToDecimal(img["fileInfo"]["radius"])))));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("damageDescription", Convert.ToString(img["observations"][0]["comment"])));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("observations")[0].First.AddAfterSelf(new JProperty("severity", ds));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }

                                try
                                {
                                    ((Newtonsoft.Json.Linq.JValue)objData.SelectToken("observations")[0].SelectToken("findingType")).Value = Convert.ToString(img["observations"][0]["damageType"]);
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                #endregion [Adding missing fields in windams sections]                               
                                strUploadedImageCache += "{\"width\": \"1024\",\"height\": 768,\"checked\": false, \"color\": \"" + color + "\", \"region\": -1, \"imageName\": \"" + Convert.ToString(img["fileInfo"]["name"]) + "\", \"imageNumber\": " + Convert.ToInt32(img["number"]) + ", \"uploadedAt\": \"" + DateTime.UtcNow + "\", \"damagePlacement\": \"" + Convert.ToString(img["damagePlacement"]) + "\", \"damageType\": \"" + Convert.ToString(img["observations"][0]["damageType"]) + "\", \"radius\": " + Convert.ToInt32(Math.Abs(Convert.ToDecimal(img["fileInfo"]["radius"]))) + ", \"damageDescription\": \"" + Convert.ToString(img["observations"][0]["comment"]) + "\", \"damageDescriptionText\": \"" + Convert.ToString(img["observations"][0]["comment"]) + "\", \"side\": \"" + Convert.ToString(img["side"]) + "\", \"saved\": false, \"observations\": [{\"observationType\": null, \"surfaceType\": null, \"location\": null, \"size\": {\"width\": \"1024\", \"height\": 768, \"depth\": null}, \"severity\": " + Convert.ToInt32(img["observations"][0]["damageSeverity"]) + ", \"date\": null, \"name\": null,\"findingType\": \"" + Convert.ToString(img["observations"][0]["damageType"]) + "\", \"comment\": null, \"polygons\": [{\"text\": \"\", \"center\": {\"z\": null, \"x\": 512, \"y\": 384 }, \"severity\": " + Convert.ToInt32(img["observations"][0]["damageSeverity"]) + ", \"geometry\": [{ \"z\": null, \"x\": 0, \"y\": 0}, { \"z\": null, \"x\": \"1024\", \"y\": 0 }, { \"z\": null, \"x\": \"1024\", \"y\": 768}, { \"z\": null, \"x\": 0, \"y\": 768 }]}]}], \"damageIdentified\": " + img["damageIdentified"].ToString().ToLower() + ", \"groupId\": -1, \"damageSeverity\": " + Convert.ToInt32(img["damageSeverity"]) + ",\"damageDetails\": [],\"damageId\": null,\"damageGuid\": null,\"allDamageIds\": [], \"imageId\": \"" + Convert.ToString(img["imageId"]) + "\"},";

                            }
                            catch (Exception e)
                            {
                                _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                            }
                        }
                    }
                    strUploadedImageCache += "]";
                    strUploadedImageCache = strUploadedImageCache.Remove(strUploadedImageCache.Length - 2, 1);
                    JToken objUIC = JToken.Parse(strUploadedImageCache);
                    obj.SelectToken("imagecomponentKey.withPlatePicture").Parent.AddAfterSelf(new JProperty("uploadedImagesCache", objUIC));
                    #endregion [Adding UploadedImagesCache Attribute]
                }
                catch (Exception e)
                {
                    if (Request.Headers.Contains("Authorization"))
                    { authToken = Request.Headers.Authorization.Parameter; }
                    var user1 = UserInformation.getstaticuser(authToken);
                    _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/SubmitAndApprove for user " + user1.UserName + " Exception Message: " + e.Message);
                    _telemetryClient.TrackException(e);
                }

                
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);

                var alreadyStoredData = _cirSubmissionService.GetByCirId(reportToSubmit.CirId);
                if (alreadyStoredData != null && alreadyStoredData.State == CirState.Approved)
                    throw new InvalidOperationException("Submit&Approve operation is not allowed. CIR already approved.");
                //All the inspection images submitted from windams would be already synced to the amazon cloud storage 
                reportToSubmit.ImageProcessStatus = ImageProcessStatus.Synced;
                reportToSubmit.ModifiedBy = reportToSubmit.ModifiedBy.Contains("_") ? reportToSubmit.ModifiedBy.Split('_')[0] : reportToSubmit.ModifiedBy;
                var data = _cirSubmissionService.Update(reportToSubmit, user.DisplayName);

                if (data.State == CirState.Error) return BadRequest();

                _cirSubmissionService.Approve(reportToSubmit.CirId, user.DisplayName, CirState.Approved.ToString());

                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/SubmitAndApprove for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get CIR PDF report
        /// </summary>
        /// <param name="cirId">cirId</param>
        /// <returns>Json response</returns>
        [HttpPut]
        //[AuthorizeRoles]
        public IHttpActionResult CirPdfFile(long cirId)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                CirPDFResponse result = _cirSubmissionService.GetCirPdf(cirId, user.DisplayName);
                return Ok(result);
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/GetCirPdf for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Get CIR PDF report zip
        /// </summary>
        /// <param name="cirIds">cirIds</param>
        /// <returns>Json response</returns>
        [HttpPut]
        //[AuthorizeRoles]
        public IHttpActionResult CirPdfFileZip(string cirIds)
        {
            try
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);
                CirPDFResponse result = _cirSubmissionService.GetCirPdfZip(cirIds, user.DisplayName);
                return Ok(result);
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/CirPdfFileZip for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Describing SeverityColors
        /// </summary>
        public static class SeverityColors
        {
            /// <summary>
            /// AssignedColor
            /// </summary>
            public static readonly string AssignedColor = "#0094FF";
            /// <summary>
            /// UnassignedColor
            /// </summary>
            public static readonly string UnassignedColor = "#C7C7C7";
            /// <summary>
            /// Severity0
            /// </summary>
            public static readonly string Severity0 = "#808080";
            /// <summary>
            /// Severity1
            /// </summary>
            public static readonly string Severity1 = "#00963D";
            /// <summary>
            /// Severity2
            /// </summary>
            public static readonly string Severity2 = "#8BC34A";
            /// <summary>
            /// UnassignedColor
            /// </summary>
            public static readonly string Severity3 = "#FFDF25";
            /// <summary>
            /// Severity4
            /// </summary>
            public static readonly string Severity4 = "#FFB700";
            /// <summary>
            /// Severity5
            /// </summary>
            public static readonly string Severity5 = "#CC0000";
        }

        /// <summary>
        /// Submits CIR report and sets state to Submitted.
        /// </summary>
        /// <param name="reportToSubmit">Report with data to submit</param>
        /// <returns>200 OK</returns>
        //[AuthorizeRoles]
        [HttpPost]
        public IHttpActionResult Submit([FromBody] CirSubmissionData reportToSubmit)
        {
            try
            {
                string authToken = string.Empty;
                try
                {
                    #region [Adding UploadedImagesCache Attribute]
                    JObject obj = reportToSubmit.Data as JObject;
                    try
                    {
                        obj["txtTurbineNumber"] = Convert.ToInt32(obj["txtTurbineNumber"]);
                        obj["txtAlarmLogNumber"] = Convert.ToInt32(obj["txtAlarmLogNumber"]);
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackException(e);
                        _telemetryClient.TrackEvent("Failed to convert txtTurbineNumber, txtAlarmLogNumber into string. Exception Message: " + e.Message);
                    }
                    try
                    {
                        obj["ddlInstallationDateType"] = "2";
                        obj["dtInstallationDate"] = obj["dtCommissioningdate"];
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackException(e);
                        _telemetryClient.TrackEvent("Failed to assign values in ddlInstallationDateType and dtInstallationDate fields. Exception Message: " + e.Message);
                    }
                    try
                    {
                        obj.SelectToken("txtTurbineNumber").Parent.AddAfterSelf(new JProperty("ctbUpTowerSolutionAvailable", false));
                    }
                    catch (Exception e)
                    {
                        _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                    }
                    var Sections = ((Newtonsoft.Json.Linq.JContainer)obj["imagecomponentKey"])["sections"];
                    string strUploadedImageCache = "[";
                    foreach (var section in Sections)
                    {
                        foreach (var img in section.First["images"])
                        {
                            var imgObservation = string.Empty;
                            try
                            {
                                var ds = Convert.ToInt32(img["damageSeverity"]);

                                var color = (ds == 0 ? SeverityColors.Severity0 : (ds == 1 ? SeverityColors.Severity1 : (ds == 2 ? SeverityColors.Severity2 : (ds == 3 ? SeverityColors.Severity3 : (ds == 4 ? SeverityColors.Severity4 : (ds == 5 ? SeverityColors.Severity5 : SeverityColors.UnassignedColor))))));

                                imgObservation += "[{\"damageType\": null,\"observationType\": null, \"surfaceType\": null, \"location\": null, \"size\": {\"width\": \"1024\", \"height\": 768, \"depth\": null}, \"severity\": " + ds + ", \"date\": null, \"name\": \"" + Convert.ToString(img["fileInfo"]["name"]) + "\",\"findingType\": \"\", \"comment\": null, \"polygons\": [{\"text\": \"\", \"center\": {\"z\": null, \"x\": 512, \"y\": 384 }, \"severity\": -1, \"geometry\": [{ \"z\": null, \"x\": 0, \"y\": 0}, { \"z\": null, \"x\": \"1024\", \"y\": 0 }, { \"z\": null, \"x\": \"1024\", \"y\": 768}, { \"z\": null, \"x\": 0, \"y\": 768 }]}]}]";
                                JToken objImageObservation = JToken.Parse(imgObservation);
                                JObject objData = img as JObject;
                                #region [Adding missing fields in windams sections]
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("observations", objImageObservation));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("radius", Convert.ToInt32(Math.Abs(Convert.ToDecimal(img["fileInfo"]["radius"])))));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("damagePlacement").Parent.AddAfterSelf(new JProperty("damageDescription", Convert.ToString(img["observations"][0]["comment"])));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                try
                                {
                                    objData.SelectToken("observations")[0].First.AddAfterSelf(new JProperty("severity", ds));
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }

                                try
                                {
                                    ((Newtonsoft.Json.Linq.JValue)objData.SelectToken("observations")[0].SelectToken("findingType")).Value = Convert.ToString(img["observations"][0]["damageType"]);
                                }
                                catch (Exception e)
                                {
                                    _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                                }
                                #endregion [Adding missing fields in windams sections]                               
                                strUploadedImageCache += "{\"width\": \"1024\",\"height\": 768,\"checked\": false, \"color\": \"" + color + "\", \"region\": -1, \"imageName\": \"" + Convert.ToString(img["fileInfo"]["name"]) + "\", \"imageNumber\": " + Convert.ToInt32(img["number"]) + ", \"uploadedAt\": \"" + DateTime.UtcNow + "\", \"damagePlacement\": \"" + Convert.ToString(img["damagePlacement"]) + "\", \"damageType\": \"" + Convert.ToString(img["observations"][0]["damageType"]) + "\", \"radius\": " + Convert.ToInt32(Math.Abs(Convert.ToDecimal(img["fileInfo"]["radius"]))) + ", \"damageDescription\": \"" + Convert.ToString(img["observations"][0]["comment"]) + "\", \"damageDescriptionText\": \"" + Convert.ToString(img["observations"][0]["comment"]) + "\", \"side\": \"" + Convert.ToString(img["side"]) + "\", \"saved\": false, \"observations\": [{\"observationType\": null, \"surfaceType\": null, \"location\": null, \"size\": {\"width\": \"1024\", \"height\": 768, \"depth\": null}, \"severity\": " + Convert.ToInt32(img["observations"][0]["damageSeverity"]) + ", \"date\": null, \"name\": null,\"findingType\": \"" + Convert.ToString(img["observations"][0]["damageType"]) + "\", \"comment\": null, \"polygons\": [{\"text\": \"\", \"center\": {\"z\": null, \"x\": 512, \"y\": 384 }, \"severity\": " + Convert.ToInt32(img["observations"][0]["damageSeverity"]) + ", \"geometry\": [{ \"z\": null, \"x\": 0, \"y\": 0}, { \"z\": null, \"x\": \"1024\", \"y\": 0 }, { \"z\": null, \"x\": \"1024\", \"y\": 768}, { \"z\": null, \"x\": 0, \"y\": 768 }]}]}], \"damageIdentified\": " + img["damageIdentified"].ToString().ToLower() + ", \"groupId\": -1, \"damageSeverity\": " + Convert.ToInt32(img["damageSeverity"]) + ",\"damageDetails\": [],\"damageId\": null,\"damageGuid\": null,\"allDamageIds\": [], \"imageId\": \"" + Convert.ToString(img["imageId"]) + "\"},";

                            }
                            catch (Exception e)
                            {
                                _telemetryClient.TrackEvent("Adding missing field in windams inspection. " + e.Message);
                            }
                        }
                    }
                    strUploadedImageCache += "]";
                    strUploadedImageCache = strUploadedImageCache.Remove(strUploadedImageCache.Length - 2, 1);
                    JToken objUIC = JToken.Parse(strUploadedImageCache);
                    obj.SelectToken("imagecomponentKey.withPlatePicture").Parent.AddAfterSelf(new JProperty("uploadedImagesCache", objUIC));
                    #endregion [Adding UploadedImagesCache Attribute]
                }
                catch (Exception ex)
                {
                    
                    if (Request.Headers.Contains("Authorization"))
                    { authToken = Request.Headers.Authorization.Parameter; }
                    var user1 = UserInformation.getstaticuser(authToken);
                    _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Submit for user " + user1.UserName + " Exception Message: " + ex.Message);
                    _telemetryClient.TrackException(ex);
                }
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user = UserInformation.getstaticuser(authToken);


                var alreadyStoredData = _cirSubmissionService.GetByCirId(reportToSubmit.CirId);
                if (alreadyStoredData != null && alreadyStoredData.State == CirState.Approved)
                    throw new InvalidOperationException("Submit operation is not allowed. CIR already approved.");
                //All the inspection images submitted from windams would be already synced to the amazon cloud storage 
                reportToSubmit.ImageProcessStatus = ImageProcessStatus.Synced;
                reportToSubmit.ModifiedBy = reportToSubmit.ModifiedBy.Contains("_") ? reportToSubmit.ModifiedBy.Split('_')[0] : reportToSubmit.ModifiedBy;

                //Need to add the missing attribute here
                //AddCachedUploadedImages();
                var data = _cirSubmissionService.Update(reportToSubmit, user.DisplayName);

                if (data.State == CirState.Error) return BadRequest();

                _cirSubmissionService.Submit(reportToSubmit.CirId, user.DisplayName);

                return Ok();
            }
            catch (Exception e)
            {
                string authToken = string.Empty;
                if (Request.Headers.Contains("Authorization"))
                { authToken = Request.Headers.Authorization.Parameter; }
                var user1 = UserInformation.getstaticuser(authToken);
                _telemetryClient.TrackEvent("Unexpected error occured for CirSubmissionData/Submit for user " + user1.UserName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        
    }

}
