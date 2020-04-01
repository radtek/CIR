using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.Services;
using Cir.Data.Api.DataManipulation;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// CirTemplateController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CirTemplateController : ApiController
    {
        
        private readonly ICirTemplateService _cirTemplateService;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// CirTemplateController
        /// </summary>
        /// <param name="cirTemplateService"></param>
        /// <param name="log"></param>
        public CirTemplateController(ICirTemplateService cirTemplateService, ILogger log)
        {
            _cirTemplateService = cirTemplateService;
        }

        /// <summary>
        /// GetLatestVersion
        /// </summary>
        /// <param name="cirBrandCollectionName"></param>
        /// <returns></returns>
        [GzipCompression]
        [HttpGet]
        public IHttpActionResult GetLatestVersion(string cirBrandCollectionName)
        {
            try
            {
                return Ok(_cirTemplateService.GetHighestRevisionByBrandCollectionName(cirBrandCollectionName));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirTemplate/GetLatestVersion for user " + User + "cirBrandCollectionName: " + cirBrandCollectionName + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// GetOldVersion
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        [GzipCompression]
        [HttpGet]
        public IHttpActionResult GetOldVersion(string templateId)
        {
            try
            {
                return Ok(_cirTemplateService.GetOldVersionByBrandCollectionName(templateId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CirTemplate/GetOldVersion for user " + User + "templateId: " + templateId + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}