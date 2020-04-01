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
    /// MessageDataController
    /// </summary>
    //[AuthorizeRoles]
    [MobileAppController]
    public class MessageDataController : ApiController
    {
        private IMessageService _messageService;
        private TelemetryClient _telemetryClient = new TelemetryClient();

        /// <summary>
        /// MessageDataController
        /// </summary>
        /// <param name="messageService"></param>
        /// <param name="log"></param>
        public MessageDataController(IMessageService messageService, ILogger log)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// GetAllNotReceived
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllNotReceived(string receiver)
        {
            try
            {
                return Ok(_messageService.GetAllNotReceived(receiver));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CreateCir/GetAllNotReceived for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Send([FromBody]MessageData message)
        {
            try
            {
                return Ok(_messageService.Send(message));
            }
            catch (Exception e)
            {
                _telemetryClient.TrackEvent("Unexpected error occured for CreateCir/Send for user " + User + " Exception Message: " + e.Message);
                _telemetryClient.TrackException(e);
                return BadRequest(e.Message);
            }
        }
    }
}