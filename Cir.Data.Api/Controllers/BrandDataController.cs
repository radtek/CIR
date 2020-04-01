using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Services;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using Cir.Data.Access.Models;
using Cir.Data.Api.DataManipulation;
using System.Threading.Tasks;
using Serilog;
using Microsoft.ApplicationInsights;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// BrandDataController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class BrandDataController : ApiController
    {
        ICirBrandService _cirBrandService;
        private TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// BrandDataController
        /// </summary>
        /// <param name="cirBrandService"></param>
        /// <param name="log"></param>
        public BrandDataController(ICirBrandService cirBrandService, ILogger log)
        {
            _cirBrandService = cirBrandService;
        }

        /// <summary>
        /// Get all brands.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<BrandDataModel>), Description = "List of brands.")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_cirBrandService.GetAll());
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/Get for" + User );
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get all brands related to given user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<BrandDataModel>), Description = "List of brands.")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByUserId(string userId)
        {
            try
            {
                return Ok(await _cirBrandService.GetAllByUserId(UserIdParameterManipulator.ConvertUserIdFromPrincipalNameToInitials(userId)));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/GetByUserId for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get all brands related to a brand with a given name.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<BrandDataModel>), Description = "List of brands.")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByGroupName(string groupName)
        {
            try
            {
                return Ok(await _cirBrandService.GetAllByGroupName(groupName));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/GetByGroupName for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Assigns given Brand to given User or Group. 
        /// </summary>
        /// <param name="userGroupId"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GroupUserBrand), Description = "Updated User or Group")]
        [HttpGet]
        public IHttpActionResult AssignBrandToUserGroup(string userGroupId, string brandId)
        {
            try
            {
                return Ok(_cirBrandService.AssignBrandToUserGroup(UserIdParameterManipulator.ConvertUserIdFromPrincipalNameToInitials(userGroupId), brandId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/AssignBrandToUserGroup for" + User);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Assigns given Brand to given Group. 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GroupUserBrand), Description = "Updated Group")]
        [HttpGet]
        public IHttpActionResult AssignBrandToGroup(string groupId, string brandId)
        {
            try
            {
                return Ok(_cirBrandService.AssignBrandToGroup(groupId, brandId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/AssignBrandToGroup for" + User + "GroupId: " + groupId + "BrandId: " + brandId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Unassigns given Brand from given User or Group. 
        /// </summary>
        /// <param name="userGroupId"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GroupUserBrand), Description = "Updated User or Group")]
        [HttpGet]
        public IHttpActionResult UnassignBrandFromUserGroup(string userGroupId, string brandId)
        {
            try
            {
                return Ok(_cirBrandService.UnassignBrandFromUserGroup(UserIdParameterManipulator.ConvertUserIdFromPrincipalNameToInitials(userGroupId), brandId));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BrandDataController/UnassignBrandFromUserGroup for" + User + "userGroupId: " + userGroupId + "brandId: " + brandId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}