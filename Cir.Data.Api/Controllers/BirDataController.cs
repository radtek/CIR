using Cir.Data.Access.CirSyncService;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using System;
using System.Web.Http;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// BirDataController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class BirDataController : ApiController
    {
        private IBirDataService _birDataService;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// Bir data service
        /// </summary>
        /// <param name="birDataService"></param>
        /// <param name="log"></param>
        public BirDataController(IBirDataService birDataService, ILogger log)
        {
            _birDataService = birDataService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_birDataService.GetAll());
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirDataController/Get for" + User);
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
        public IHttpActionResult Get(string reportId)
        {
            try
            {
                return Ok(_birDataService.Get(reportId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirData/Get for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Insert Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Create([FromBody]BirDetailsData report)
        {
            try
            {
                return Ok(_birDataService.Add(report));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirData/Create for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>        
        public IHttpActionResult Put([FromBody]BirDetailsData report)
        {
            try
            {
                return Ok(_birDataService.Update(report));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirData/Put for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete Cir Report
        /// </summary>
        /// <param name="reportId">Id (GUID) by which search for a Report object will be performed.</param>
        /// <returns></returns>        
        public IHttpActionResult Delete(string reportId)
        {
            try
            {
                _birDataService.Delete(reportId);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirData/Delete for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Save Bir Data
        /// </summary>
        /// <param name="bir">BIR collection</param>
        /// <returns></returns> 

        [HttpPost]
        public IHttpActionResult SaveBirData([FromBody]Bir bir)
        {
            try
            {
                _birDataService.SaveBirData(bir);
                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BirData/SaveBirData for " + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

    }
}