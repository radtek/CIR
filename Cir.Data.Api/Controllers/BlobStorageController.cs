using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services;
using Cir.Data.Api.Authorization;
using Cir.Data.Api.DataManipulation;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cir.Data.Api.Controllers
{
    /// <summary>
    /// BlobStorageController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class BlobStorageController : ApiController
    {
        private ICirBlobImageService _cirBlobStorageService;
        private readonly TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// BlobStorageController
        /// </summary>
        /// <param name="cirBlobStorageService"></param>
        /// <param name="log"></param>
        public BlobStorageController(ICirBlobImageService cirBlobStorageService, ILogger log)
        {
            _cirBlobStorageService = cirBlobStorageService;
        }

        /// <summary>
        /// GetBlob
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [GzipCompression]
        public IHttpActionResult GetBlob(string imageUrl)
        {
            try
            {
                return Ok(_cirBlobStorageService.Get(imageUrl));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/GetBlob for" + User + "imageUrl: " + imageUrl);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Blob Data
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [GzipCompression]
        public IHttpActionResult GetBlobData(string imageUrl)
        {
            try
            {
                return Ok(_cirBlobStorageService.GetBlobContentByUrl(imageUrl));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/GetBlobData for" + User + "imageUrl: " + imageUrl);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get base 64 image data from AWS storage
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [GzipCompression]
        public HttpResponseMessage GetWindAMSBlobData(string imageUrl)
        {
            try
            {
                return new HttpResponseMessage { Content = new StringContent(("\"" + _cirBlobStorageService.GetBlobContentByUrl(imageUrl) + "\"").Replace("\\n", "")) };
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/GetWindAMSBlobData for" + User + "imageUrl: " + imageUrl);
                _telemetryClient.TrackException(e);
                return new HttpResponseMessage { Content= new StringContent(e.Message)}; 
            }
        }

        /// <summary>
        /// GetAllBlobAsync
        /// </summary>
        /// <param name="cirID"></param>
        /// <returns></returns>
        [HttpGet]
        [GzipCompression]
        public async Task<IHttpActionResult> GetAllBlobAsync(string cirID)
        {
            try
            {
                return Ok(await _cirBlobStorageService.GetAll(cirID));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/GetAllBlobAsync for" + User + "cirID: " + cirID);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// UploadBlob
        /// </summary>
        /// <param name="imgData"></param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpPost]
        [GzipCompression]
        public IHttpActionResult UploadBlob([FromBody]ImageDataModel imgData)
        {
            try
            {
                if (imgData == null)
                {
                    return Ok("NullData");
                }
                return Ok(_cirBlobStorageService.Add(imgData));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/UploadBlob for" + imgData.CirId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// DeleteBlobAsync
        /// </summary>
        /// <param name="imageReference"></param>
        /// <returns></returns>
        //[AuthorizeRoles]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBlobAsync([FromBody]ImageDataModel imageReference)
        {
            try
            {               
                await _cirBlobStorageService.DeleteBlob(imageReference);
                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/DeleteBlobAsync for" + imageReference.CirId);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// DeleteAllBlobAsync
        /// </summary>
        /// <param name="cirID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAllBlobAsync(string cirID)
        {
            try
            {
                await _cirBlobStorageService.DeleteAllBlob(cirID);
                return Ok();
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured in BlobStorageController/DeleteBlobAsync for" + User + "cirID: " + cirID);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}