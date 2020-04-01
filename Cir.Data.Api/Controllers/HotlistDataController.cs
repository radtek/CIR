using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Data.Access.Services;
using Cir.Data.Access.Models;
using Swashbuckle.Swagger.Annotations;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// HotlistDataController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class HotlistDataController : ApiController
    {
        IHotlistService _hotlistService;
        private TelemetryClient _telemetryClient = new TelemetryClient();
        /// <summary>
        /// HotlistDataController
        /// </summary>
        /// <param name="hotlistService"></param>
        /// <param name="log"></param>
        public HotlistDataController(IHotlistService hotlistService, ILogger log)
        {
            _hotlistService = hotlistService;
        }

        /// <summary>
        /// Get Hotlist by Id
        /// </summary>
        /// <param name="hotlistId"></param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpGet]
        public IHttpActionResult GetById(string hotlistId)
        {
            try
            {
                return Ok(_hotlistService.Get(hotlistId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/GetById for" + User + "hotlistId: " + hotlistId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Hotlist by HotItem Id
        /// </summary>
        /// <param name="hotItemId"></param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpGet]
        public IHttpActionResult GetByHotItemId(long hotItemId)
        {
            try
            {
                return Ok(_hotlistService.GetByHotItemId(hotItemId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/GetByHotItemId for" + User + "hotItemId: " + hotItemId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get all Reports
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_hotlistService.GetAll());
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/GetAll for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Insert new Hotlist
        /// </summary>
        /// <param name="hotlistData">Hotlist object in JSON format.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpPost]
        public IHttpActionResult Send([FromBody]HotlistDataModel hotlistData)
        {
            try
            {
                _hotlistService.Add(hotlistData);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/Send for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update Hotlist
        /// </summary>
        /// <param name="hotlistData">Hotlist object in JSON format.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpPost]
        public IHttpActionResult Update([FromBody]HotlistDataModel hotlistData)
        {
            try
            {
                _hotlistService.Update(hotlistData);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/Update for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete Hotlist by id
        /// </summary>
        /// <param name="hotlistId"></param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpDelete]
        public IHttpActionResult Delete(string hotlistId)
        {
            try
            {
                _hotlistService.Delete(hotlistId);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/Delete for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete Hotlist by id
        /// </summary>
        /// <param name="hotItemId"></param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "HotlistData - provides CRUD operations for Hotlist object on Azure CosmosDB." })]
        [HttpDelete]
        public IHttpActionResult DeleteByHotItemId(long hotItemId)
        {
            try
            {
                _hotlistService.DeleteByHotItemId(hotItemId);

                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in HotlistDataController/DeleteByHotItemId for" + User + "DeleteByHotItemId: " + hotItemId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}