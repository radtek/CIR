using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cir.Azure.MobileApp.Utilities;
using Cir.Azure.MobileApp.DataObjects;
using Microsoft.Azure.Mobile.Server.Authentication;

namespace Cir.Azure.MobileApp.Controllers
{
    [MobileAppController]
    [Authorize]
    [AuthorizeAadRole(Roles = "*")]
    public class CirOnlineValidationController : ApiController
    {
        // GET api/Get
        /// <summary>
        /// Get the Cir Advanced Search
        /// </summary>
        /// <returns>CirAdvancedSearch</returns>
        /// <CreatedBy>Jayanta Nath</CreatedBy>

        [Route("api/ValidateTurbineNumber/{TurbineNumber}")]
        public bool GetValidateTurbineNumber(string TurbineNumber)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered ValidateTurbineNumber custom controller!");
                return (new SyncServiceUtilities(this)).ValidateTurbineNumber(TurbineNumber);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/ValidateGetTurbineData/{TurbineNumber}")]
        public Cir.Azure.MobileApp.CirSyncService.TurbineProperties GetValidateGetTurbineData(string TurbineNumber)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered GetValidateGetTurbineData custom controller!");
                return (new SyncServiceUtilities(this)).ValidateGetTurbineData(TurbineNumber);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/ValidateCIMCaseNumber/{CIMCaseNumber}")]
        public bool GetValidateSIMCaseNumber(string CIMCaseNumber)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered ValidateSIMCaseNumber custom controller!");
                return (new SyncServiceUtilities(this)).ValidateCIMCaseNumber(CIMCaseNumber);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/ValidateServiceReportNumber/{ServiceReportNumber}/{TurbineNumber}")]
        public bool GetValidateServiceReportNumber(string ServiceReportNumber, string TurbineNumber)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered ValidateServiceReportNumber custom controller!");
                return (new SyncServiceUtilities(this)).ValidateServiceReportNumber(ServiceReportNumber, TurbineNumber);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }

        [Route("api/ValidateServiceNotificationNumber/{ServiceNotificationNumber}/{TurbineNumber}")]
        public bool GetValidateServiceNotificationNumber(string ServiceNotificationNumber, string TurbineNumber)
        {
            try
            {
                this.Configuration.Services.GetTraceWriter().Info("Entered ValidateServiceNotificationNumber custom controller!");
                return (new SyncServiceUtilities(this)).ValidateServiceNotificationNumber(ServiceNotificationNumber, TurbineNumber);
            }
            catch (Exception ex)
            {
                var inr = ex.InnerException;
                var ininr = (inr != null) ? inr.InnerException : null;
                var basee = ex.GetBaseException();
                var binr = (basee != null) ? basee.InnerException : null;
                string str = (inr != null) ? " \n Ex: " + ex.Message + "\n Detailed Error: " + ex.StackTrace : "";
                str += (inr != null) ? " \n Inner: " + inr.Message + "\n Detailed Error: " + inr.StackTrace : "";
                str += (ininr != null) ? "  \n In Inner: " + ininr.Message + "\n Detailed Error: " + ininr.StackTrace : "";
                str += (basee != null) ? "\n Base: " + basee.Message + "\n Detailed Error: " + basee.StackTrace : "";
                str += (binr != null) ? " \n Base Inner: " + binr.Message + "\n Detailed Error: " + binr.StackTrace : "";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, str));
            }
        }
    }
}
