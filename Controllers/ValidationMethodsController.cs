using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Swashbuckle.Swagger.Annotations;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;

namespace Cir.Data.Api.Controllers
{
    [MobileAppController]
    public class ValidationMethodsController : ApiController
    {
        private readonly IValidationMethodsService _validationMethodsService;

        public ValidationMethodsController(IValidationMethodsService validationMethodsService)
        {
            _validationMethodsService = validationMethodsService;
        }

        /// <summary>
        /// Returns the list of validation rules.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ValidationMethodsModel), Description = "JSON representing collection of existing validation rules.")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_validationMethodsService.GetValidationMethods());
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e));
            }
        }
    }
}
