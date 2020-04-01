using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReport
    {
        public bool isSimplifiedCir { get; set; }
        public string TemplateVersion { get; set; }

        public long ComponentInspectionReportId
        {
            get;
            set;
        }
        public long ComponentInspectionReportTypeId
        {
            get;
            set;
        }
        public long ComponentInspectionReportStateId
        {
            get;
            set;
        }
        //public long CIRTemplate
        //{
        //    get;
        //    set;
        //}
        public long ReportTypeId
        {
            get;
            set;
        }
        public long ReconstructionBooleanAnswerId
        {
            get;
            set;
        }
        public long CIMCaseNumber
        {
            get;
            set;
        }
        public string ReasonForService
        {
            get;
            set;
        }
        public long TurbineNumber
        {
            get;
            set;
        }
        public long CountryISOId
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string TurbineType
        {
            get;
            set;
        }
        public string SiteName
        {
            get;
            set;
        }
        public long? TurbineMatrixId
        {
            get;
            set;
        }
        public long LocationTypeId
        {
            get;
            set;
        }
        public string LocalTurbineId
        {
            get;
            set;
        }
        public long? SecondGeneratorBooleanAnswerId
        {
            get;
            set;
        }
        public long BeforeInspectionTurbineRunStatusId
        {
            get;
            set;
        }
        public DateTime CommisioningDate
        {
            get;
            set;
        }
        public string strCommisioningDate
        {
            get;
            set;
        }
        public DateTime? InstallationDate
        {
            get;
            set;
        }
        public string strInstallationDate
        {
            get;
            set;
        }
        public DateTime FailureDate
        {
            get;
            set;
        }
        public string strFailureDate
        {
            get;
            set;
        }
        public DateTime InspectionDate
        {
            get;
            set;
        }
        public string strInspectionDate
        {
            get;
            set;
        }
        public string ServiceReportNumber
        {
            get;
            set;
        }
        public long ServiceReportNumberTypeId
        {
            get;
            set;
        }
        public string ServiceEngineer
        {
            get;
            set;
        }
        public long RunHours
        {
            get;
            set;
        }
        public long Generator1Hrs
        {
            get;
            set;
        }
        public long? Generator2Hrs
        {
            get;
            set;
        }
        public long TotalProduction
        {
            get;
            set;
        }
        public long AfterInspectionTurbineRunStatusId
        {
            get;
            set;
        }
        public long Quantity
        {
            get;
            set;
        }
        public string AlarmLogNumber
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string DescriptionConsquential
        {
            get;
            set;
        }
        public string ConductedBy
        {
            get;
            set;
        }
        public long SBUId
        {
            get;
            set;
        }
        public string CIRTemplateGUID
        {
            get;
            set;
        }
        public string VestasItemNumber
        {
            get;
            set;
        }
        public DateTime Deleted
        {
            get;
            set;
        }
        public string DeletedBy
        {
            get;
            set;
        }
        public string NotificationNumber
        {
            get;
            set;
        }
        public string ErrorMessage
        {
            get;
            set;
        }
        public long? MountedOnMainComponentBooleanAnswerId
        {
            get;
            set;
        }
        public int? ComponentUpTowerSolutionID
        {
            get;
            set;
        }
        public string CurrentUser
        {
            get;
            set;
        }
        public string SBURecomendation { get; set; }
        public string AdditionalComments { get; set; }
        public string InternalComments { get; set; }
        public string ComponentInspectionReportVersion { get; set; }
        public string ComponentInspectionReportName { get; set; }
        public string SBUName { get; set; }
        public long CirDataID { get; set; }
        public string CirName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int TotalRecords { get; set; }

        //Added by Siddharth Chauhan on 08-06-2016.
        //to get total count of UnApproved,Accepted,Rejected.
        //Task No. : 75297
        public int TotalUnApprovedRecords { get; set; }
        public int TotalAcceptedRecords { get; set; }
        public int TotalRejectedRecords { get; set; }

        //Added by Siddharth Chauhan on 08-06-2016.
        //to Show Action items in Remote CIR Search list.
        //Task No. : 75299
        public Nullable<int> HideProgress { get; set; }
        public string HideLock { get; set; }
        public long CIRID { get; set; }
        public string HideTemplateVer { get; set; }

        public ComponentInspectionReportBlade BladeData
        {
            get;
            set;
        }
        public ComponentInspectionReportSkiiP Skiip
        {
            get;
            set;
        }
        public ComponentInspectionReportGearbox Gearbox
        {
            get;
            set;
        }
        public ComponentInspectionReportGenerator Generator
        {
            get;
            set;
        }
        public ComponentInspectionReportTransformer Transformer
        {
            get;
            set;
        }
        public CommonInspectionGeneral General
        {
            get;
            set;
        }
        public ComponentInspectionReportMainBearing MainBearing
        {
            get;
            set;
        }
        public DynamicTable DynamicTableInputs { get; set; }
        public List<DyanamicDecision> DyanamicDecisionData { get; set; }
        public List<ImageData> ImageData { get; set; }

        public ImageDataInfo ImageDataInfo { get; set; }

        public TurbineProperties TurbineData { get; set; }

        public String HtmlStr { get; set; }
        public bool OutSideSign { get; set; }

        public string FlangDesc { get; set; }
        //public List<DyanamicDecision> DyanamicDecisionData { get; set; }

        public string FormIOGUID { get; set; }

        public string Brand { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class TurbineProperties
    {
        public long? TurbineMatrixId = 0;
        public string Turbine = string.Empty;
        public byte Frequency = 0;
        public string Manufacturer = string.Empty;
        public string MarkVersion = string.Empty;
        public int NominelPower = 0;
        public long NominelPowerId = 0;
        public string Placement = string.Empty;
        public string PowerRegulation = string.Empty;
        public decimal RotorDiameter = 0;
        public int SmallGenerator = 0;
        public string TemperatureVariant = string.Empty;
        public int Voltage = 0;
        public long CountryIsoId = 0;
        public string Country = string.Empty;
        public string Site = string.Empty;
        public string LocalTurbineId = string.Empty;
    }

    public class CirStateResponse
    {
        public string CirDataLocalID = string.Empty;
        public long CIRId = 0;
        public int CIRState = 0;
    }
}