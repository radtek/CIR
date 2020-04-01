using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile.Server.Config;
using Cir.Data.Access.Services;
using Cir.Data.Access.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cir.Data.Api.Controllers
{
    [MobileAppController]
    public class BlobStorageController : ApiController
    {
        private ICirBlobStorageService _cirBlobStorageService;
        public BlobStorageController(ICirBlobStorageService cirBlobStorageService)
        {
            _cirBlobStorageService = cirBlobStorageService;
        }

        /// <summary> 
        /// Task<ActionResult> GetBlobAsync(string containerName) 
        /// </summary>
        [Route(Name = "Get")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBlobAsync(string fileName)
        {
            try
            {
                return Ok(await _cirBlobStorageService.Get(fileName));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary> 
        /// Task<ActionResult> GetAllBlobAsync(string containerName) 
        /// </summary>
        [Route(Name = "GetAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBlobAsync(string cirId)
        {
            try
            {
                return Ok(await _cirBlobStorageService.GetAll(cirId));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary> 
        /// Task<ActionResult> UploadAsync() 
        /// </summary> 
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]ImageDataList imgData)
        {
            try
            {
                return Ok(await _cirBlobStorageService.Add(imgData));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary> 
        /// Task<ActionResult> DeleteBlobAsync(string name) 
        /// </summary> 
        [Route(Name = "Delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBlob(string imageId)
        {
            try
            {
                await _cirBlobStorageService.DeleteBlob(imageId);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary> 
        /// Task<ActionResult> DeleteAllAsync(string name) 
        /// </summary> 
        [Route(Name = "DeleteAll")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAllAsync(string cirID)
        {
            try
            {
                await _cirBlobStorageService.DeleteAllBlob(cirID);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}