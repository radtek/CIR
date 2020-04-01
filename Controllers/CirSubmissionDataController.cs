using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Services;
using Cir.Data.Access.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;

namespace Cir.Data.Api.Controllers
{
    [MobileAppController]
    public class CirSubmissionDataController : ApiController
    {
        private ICirSubmissionService _cirSubmissionService;

        public CirSubmissionDataController(ICirSubmissionService cirSubmissionService)
        {
            _cirSubmissionService = cirSubmissionService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_cirSubmissionService.GetAll());
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
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
        public IHttpActionResult Get(string reportId)
        {
            try
            {
                return Ok(_cirSubmissionService.Get(reportId));
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }

        /// <summary>
        /// First Sync call. Determines for each send Report the type of update to be performed.
        /// </summary>
        /// <param name="reportsToSync">List of short version of Reports. Consists only data needed to determine sync operation type.</param>
        /// <param name="userId">Id of user making this request.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides Sync functionality between User's data in Browser and Azure CosmosDB." })]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<CirSubmissionData>), Description = "List of reports. Each report can be in one of two possible data states. If a Report consists of a regular, completed data it is intended to be saved in browser. If a Report's schema and data properties are empty, this means that these reports are to be send again, using 2nd Sync Call to be saved in Azure CosmosDB.")]
        [HttpPost]
        public IHttpActionResult SyncRequest(string userId, [FromBody]IEnumerable<CirSubmissionSyncData> reportsToSync)
        {
            try
            {
                return Ok(_cirSubmissionService.SyncRequest(userId, reportsToSync));
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }

        /// <summary>
        /// Second Sync call. This method is used to pass the list of reports to be saved or updated in Azure.
        /// </summary>
        /// <param name="reportToUpdate">Report with complete data.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides Sync functionality between User's data in Browser and Azure CosmosDB." })]
        [HttpPost]
        public IHttpActionResult SyncUpdate([FromBody]CirSubmissionData reportToUpdate)
        {
            try
            {
                _cirSubmissionService.SyncUpdate(reportToUpdate);

                return Ok();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }

        /// <summary>
        /// Insert Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        [HttpPost]
        public IHttpActionResult Send([FromBody]CirSubmissionData report)
        {
            try
            {
                return Ok(_cirSubmissionService.Add(report));
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }

        /// <summary>
        /// Update Cir Report
        /// </summary>
        /// <param name="report">Report object in JSON format. Contains Schema, Data, Id (GUID) and Partition(provided by default).</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        public IHttpActionResult Put([FromBody]CirSubmissionData report)
        {
            try
            {
                return Ok(_cirSubmissionService.Update(report));
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }

        /// <summary>
        /// Delete Cir Report
        /// </summary>
        /// <param name="reportId">Id (GUID) by which search for a Report object will be performed.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "CirSubmissionData - provides CRUD operations for Cir Report object on Azure CosmosDB." })]
        public IHttpActionResult Delete(string reportId)
        {
            try
            {
                _cirSubmissionService.Delete(reportId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }
    }
}
