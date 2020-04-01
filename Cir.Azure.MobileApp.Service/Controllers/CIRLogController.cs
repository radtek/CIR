﻿using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.DataObjects;

namespace Cir.Azure.MobileApp.Service.Controllers
{
    [MobileAppController]
    ////[Authorize]
   // [AuthorizeAadRole(Roles = "*")]
    public class CIRLogController : ApiController
    {
        // POST api/StandardTextData
        /// <summary>
        /// Post the StandardText Json String to the StandardText Sync Wcf Service
        /// </summary>
        /// <param name="Cir"></param>
        /// <returns>Output string from  StandardText Sync Wcf Service</returns>
        /// <CreatedBy>Souvik Neogi</CreatedBy>
        public List<Cir.Azure.MobileApp.Service.CirSyncService.CirLogs> Post(Cir.Azure.MobileApp.Service.CirSyncService.CirLogs oCirLogs)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered MasterData custom controller! -Post");
            if (!ReferenceEquals(oCirLogs, null))
                return (new SyncServiceUtilities(this)).GetCirLog(oCirLogs.CirDataId);
            else
                return (new SyncServiceUtilities(this)).GetCirLog(1);
        }

        
       // [AuthorizeAadRole(Roles = "Administrator")]
        [HttpPost]
        [Route("api/GetCirSyncLog")]
        public Cir.Azure.MobileApp.Service.CirSyncService.LogList GetCirSyncLog([FromBody]Cir.Azure.MobileApp.Service.CirSyncService.LogList Log)
        {
            this.Configuration.Services.GetTraceWriter().Info("Entered Get Cir Sync Logs custom controller!");
            try
            {
                return (new SyncServiceUtilities(this)).GetCirSyncLog(Log);
               //return (new SyncServiceUtilities(this)).GetCirSyncLogs((Cir.Azure.MobileApp.Service.CirSyncService.LogType)Enum.Parse(typeof(Cir.Azure.MobileApp.Service.CirSyncService.LogType), Type));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message + "\n Detailed Error: " + ex.Message));
            }
        }
    }
}
