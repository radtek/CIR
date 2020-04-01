using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Validation;
using Serilog;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// ValidationController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class ValidationController : ApiController
    {
        private readonly IValidationService _validationService;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// ValidationController
        /// </summary>
        /// <param name="validationService"></param>
        /// <param name="log"></param>
        public ValidationController(IValidationService validationService, ILogger log)
        {
            _validationService = validationService;
        }

        /// <summary>
        /// Returns whether given Turbine Number if valid.
        /// </summary>
        /// <returns>true / false</returns>
        [HttpGet]
        public IHttpActionResult ValidateTurbineNumber(string turbineNumber)
        {
            try
            {
                return Ok(_validationService.Validate<TurbineNumberValidation>(turbineNumber));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in ValidationController/ValidateTurbineNumber for" + User + "turbineNumber:" + turbineNumber);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns whether given Service Report Number if valid.
        /// </summary>
        /// <returns>true / false</returns>
        [HttpGet]
        public IHttpActionResult ValidateServiceReportNumber(string turbineNumber, string serviceReportNumber)
        {
            try
            {
                return Ok(_validationService.Validate<ServiceReportNumberValidation>(turbineNumber, serviceReportNumber));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in ValidationController/ValidateServiceReportNumber for" + User + "turbineNumber:" + turbineNumber + "serviceReportNumber: " + serviceReportNumber);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns whether given Service Notification Number if valid.
        /// </summary>
        /// <returns>true / false</returns>
        [HttpGet]
        public IHttpActionResult ValidateServiceNotificationNumber(string turbineNumber, string serviceNotificationNumber)
        {
            try
            {
                return Ok(_validationService.Validate<ServiceNotificationNumberValidation>(turbineNumber, serviceNotificationNumber));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in ValidationController/ValidateServiceNotificationNumber for" + User + "turbineNumber: " + turbineNumber + "serviceNotificationNumber: " + serviceNotificationNumber);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}
