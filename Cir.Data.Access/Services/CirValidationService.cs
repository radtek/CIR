using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Validation;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Web;
using System.Net;
using Cir.Data.Access.Enumerations;
using Microsoft.ApplicationInsights;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.Services
{
    internal class CirValidationService : ICirValidationService
    {
        private ICirTemplateRepository _cirTemplateRepository;
        private IValidationService _validationService;
        internal const string INVALID_TEMPLATE_MESSAGE = "Schema description in this Report does not match with the Template.";
        TelemetryClient _telemetryClient = new TelemetryClient();
        private readonly SyncServiceClient _serviceClient;

        public CirValidationService(ICirTemplateRepository cirTemplateRepository , IValidationService cirValidationService)
        {
            _cirTemplateRepository = cirTemplateRepository;
            _validationService = cirValidationService;
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public IList<string> ValidateData(CirSubmissionData cirSubmissionData)
        {
            var errorsList = new List<string>();
            errorsList = CirValidationCheck(cirSubmissionData);
            return errorsList;
        }

        private List<string> CirValidationCheck(CirSubmissionData cirSubmissionData)
        {
            var errorsList = new List<string>();
            var turbineNumber = cirSubmissionData.Data["txtTurbineNumber"]?.Value.ToString();
            CIMCaseValidation(cirSubmissionData, ref errorsList);
            TurbineNumberValidation(turbineNumber, cirSubmissionData, ref errorsList);           
            NotificationValidation(cirSubmissionData, turbineNumber, ref errorsList);
            return errorsList;
        }

        private void TurbineNumberValidation(string turbineNumber , CirSubmissionData cirSubmissionData , ref List<string> errorsList)
        {
            try
            {
                bool isValidTurbineNumber = _validationService.Validate<TurbineNumberValidation>(turbineNumber);
                if (isValidTurbineNumber)
                {
                    var turbineProperties = _serviceClient.ValidateGetTurbineData(turbineNumber);
                    cirSubmissionData.Data["txtCountry"] = turbineProperties.Country;
                    cirSubmissionData.Data["txtSiteName"] = turbineProperties.Site;
                    cirSubmissionData.Data["txtTurbineType"] = turbineProperties.Turbine;
                    cirSubmissionData.Data["txtRotorDiameter"] = turbineProperties.RotorDiameter;
                    cirSubmissionData.Data["txtNominelPower"] = turbineProperties.NominelPower;
                    cirSubmissionData.Data["txtVoltage"] = turbineProperties.Voltage;
                    cirSubmissionData.Data["txtPowerRegulation"] = turbineProperties.PowerRegulation;
                    cirSubmissionData.Data["txtFrequency"] = turbineProperties.Frequency;
                    cirSubmissionData.Data["txtSmallGenerator"] = turbineProperties.SmallGenerator;
                    cirSubmissionData.Data["txtTemperatureVariant"] = turbineProperties.TemperatureVariant;
                    cirSubmissionData.Data["txtMKversion"] = turbineProperties.MarkVersion;
                    cirSubmissionData.Data["txtOnshoreOffshore"] = turbineProperties.Placement;
                    cirSubmissionData.Data["txtManufacturer"] = turbineProperties.Manufacturer;
                    cirSubmissionData.Data["txtLocalturbineId"] = turbineProperties.LocalTurbineId;
                }
                else
                {
                    errorsList.Add(Enumeration.GetEnumDescription(Enumeration.ErrorCodes.TurbineNotExists));
                }
            
                
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error occurred while validating Turbine number" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
                errorsList.Add(Enumeration.GetEnumDescription(Enumeration.ErrorCodes.ValidationFailedTurbineNumber));

            }           
        }

        private void CIMCaseValidation(CirSubmissionData cirSubmissionData, ref List<string> errorsList)
        {

            try
            {
                var CIMCaseNumber = cirSubmissionData.Data["ddlCimCaseNumber"] == null ? cirSubmissionData.Data["txtCimCaseNumber"]?.Value.ToString()
                                    : cirSubmissionData.Data["ddlCimCaseNumber"]?.Value.ToString();
                bool isValidCIMCaseNumber = _validationService.Validate<CIMCaseValidation>(CIMCaseNumber);
                if (!isValidCIMCaseNumber)
                    errorsList.Add(Enumeration.GetEnumDescription(Enumeration.ErrorCodes.CIMCaseInvalid));

            }

            catch (Exception ex)
            {
                _telemetryClient.TrackEvent("Error occurred while validating CIM Case number" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
                errorsList.Add(Enumeration.GetEnumDescription(Enumeration.ErrorCodes.ValidationFailedCIMCaseNumber));

            }
        }

        private void NotificationValidation(CirSubmissionData cirSubmissionData, string turbineNumber, ref List<string> errorsList)
        {
            try
            {
                var serviceReportNumberType =cirSubmissionData.Data["ddlServiceReportNumberType"]?.Value.ToString();
                if (serviceReportNumberType == "4") //"MAM/SAP" Notification and Service number validation
                {    
                        var serviceOrder = cirSubmissionData.Data["txtServicereportnumber"] == null ? cirSubmissionData.Data["txtServiceordernumber"]?.Value.ToString()
                                   : cirSubmissionData.Data["txtServicereportnumber"]?.Value.ToString();
                        bool IsValidServiceReportNumber = _serviceClient.ValidateServiceReportNumber(serviceOrder, turbineNumber);
                        if (!IsValidServiceReportNumber)
                            errorsList.Add(Enumeration.GetEnumDescription(Enumeration.ErrorCodes.MisMatchServiceReportNumber));                
                }              
            }

            catch(Exception ex)
            {
                _telemetryClient.TrackEvent("Error occurred while validating Turbine number/ Service Report number" + " Exception Message: " + ex.Message);
                _telemetryClient.TrackException(ex);
                errorsList.Add( Enumeration.GetEnumDescription(Enumeration.ErrorCodes.ValidationFailedNotificationNumber));

            }
        }           
    }
}