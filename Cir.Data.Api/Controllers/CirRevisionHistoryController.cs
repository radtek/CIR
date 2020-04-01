using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// Cir revision history controller
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class CirRevisionHistoryController : ApiController
    {
        private readonly ICirSubmissionService _cirSubmissionService;
        private TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// CirRevisionHistoryController
        /// </summary>
        /// <param name="cirSubmissionService"></param>
        /// <param name="log"></param>
        public CirRevisionHistoryController(ICirSubmissionService cirSubmissionService, ILogger log)
        {
            _cirSubmissionService = cirSubmissionService;
        }

        /// <summary>
        /// Gets all revisions of CIR for a given user facing CirId and schema's templateId.
        /// </summary>
        /// <param name="turbineNumber">Turbine Number of Cir - long</param>
        /// <param name="cirGUID">Cosmos Guid id of the CIR - string</param>
        /// <returns>
        /// List of revisions for a given CIR, containing guid id of CIR in CosmosDB, revision number, modification date and user issuing modification.
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetRevisionHistory(long turbineNumber, string cirGUID)
        {
            try
            {
                return Ok(_cirSubmissionService.GetRevisionHistory(turbineNumber, cirGUID));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in CirRevisionHistoryController/GetRevisionHistory for" + User + "CIR Guid: " + cirGUID);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets latest revisions of each CIR for a given turbine Number.
        /// </summary>
        /// <param name="turbineNumber">User facing Turbine Number - long value</param>
        /// <returns>
        /// List of latest revisions for each CIR created for a turbine, containing user filled data, guid id of CIR in CosmosDB, revision number and template details.
        /// </returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CirRevisionDetails), Description = "JSON representing Report object or collection of Report objects.")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRevHistByTurbineNo(long turbineNumber)
        {
            try
            {
                return Ok(await _cirSubmissionService.GetRevHistByTurbineNo(turbineNumber));
            }
            catch (Exception e)
            {

                _telemetryClient.TrackEvent("Unexpected error occured in CirRevisionHistoryController/GetRevHistoryByTurbineNo for" + User + "Turbine Number: " + turbineNumber);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets historical CIR for revision Id.
        /// </summary>
        /// <param name="cirId">Revision Guid Id</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        public IHttpActionResult GetHistoryCir(string cirId)
        {
            try
            {
                return Ok(_cirSubmissionService.GetHistoryCir(cirId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in CirRevisionHistoryController/GetHistoryCir for" + User + "CIR Id: " + cirId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}