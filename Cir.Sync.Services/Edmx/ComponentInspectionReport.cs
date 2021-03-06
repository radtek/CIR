//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cir.Sync.Services.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComponentInspectionReport
    {
        public ComponentInspectionReport()
        {
            this.ComponentInspectionReportBlade = new HashSet<ComponentInspectionReportBlade>();
            this.ComponentInspectionReportGearbox = new HashSet<ComponentInspectionReportGearbox>();
            this.ComponentInspectionReportGeneral = new HashSet<ComponentInspectionReportGeneral>();
            this.ComponentInspectionReportGenerator = new HashSet<ComponentInspectionReportGenerator>();
            this.ComponentInspectionReportMainBearing = new HashSet<ComponentInspectionReportMainBearing>();
            this.ComponentInspectionReportSkiiP = new HashSet<ComponentInspectionReportSkiiP>();
            this.ComponentInspectionReportTransformer = new HashSet<ComponentInspectionReportTransformer>();
            this.DynamicDecisionDetails = new HashSet<DynamicDecisionDetails>();
            this.ImageData = new HashSet<ImageData>();
            this.ImageDataInfo = new HashSet<ImageDataInfo>();
        }
    
        public long ComponentInspectionReportId { get; set; }
        public long ComponentInspectionReportTypeId { get; set; }
        public long ComponentInspectionReportStateId { get; set; }
        public byte[] CIRTemplate { get; set; }
        public long ReportTypeId { get; set; }
        public long ReconstructionBooleanAnswerId { get; set; }
        public long CIMCaseNumber { get; set; }
        public string ReasonForService { get; set; }
        public long TurbineNumber { get; set; }
        public long CountryISOId { get; set; }
        public string SiteName { get; set; }
        public Nullable<long> TurbineMatrixId { get; set; }
        public long LocationTypeId { get; set; }
        public string LocalTurbineId { get; set; }
        public Nullable<long> SecondGeneratorBooleanAnswerId { get; set; }
        public long BeforeInspectionTurbineRunStatusId { get; set; }
        public System.DateTime CommisioningDate { get; set; }
        public Nullable<System.DateTime> InstallationDate { get; set; }
        public Nullable<System.DateTime> FailureDate { get; set; }
        public System.DateTime InspectionDate { get; set; }
        public string ServiceReportNumber { get; set; }
        public long ServiceReportNumberTypeId { get; set; }
        public string ServiceEngineer { get; set; }
        public long RunHours { get; set; }
        public long Generator1Hrs { get; set; }
        public Nullable<long> Generator2Hrs { get; set; }
        public long TotalProduction { get; set; }
        public long AfterInspectionTurbineRunStatusId { get; set; }
        public long Quantity { get; set; }
        public string AlarmLogNumber { get; set; }
        public string Description { get; set; }
        public string DescriptionConsquential { get; set; }
        public string ConductedBy { get; set; }
        public long SBUId { get; set; }
        public string CIRTemplateGUID { get; set; }
        public string VestasItemNumber { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
        public string NotificationNumber { get; set; }
        public Nullable<long> MountedOnMainComponentBooleanAnswerId { get; set; }
        public Nullable<int> ComponentUpTowerSolutionID { get; set; }
        public string ComponentInspectionReportName { get; set; }
        public string ComponentInspectionReportVersion { get; set; }
        public string TemplateVersion { get; set; }
        public string SBURecommendation { get; set; }
        public string InternalComments { get; set; }
        public string AdditionalInfo { get; set; }
        public Nullable<bool> OutSideSign { get; set; }
        public string FlangDescription { get; set; }
        public Nullable<decimal> Latitude_ { get; set; }
        public Nullable<decimal> Longitude_ { get; set; }
        public Nullable<int> RecordType { get; set; }
        public string Brand { get; set; }
        public string FormIOGUID { get; set; }
    
        public virtual ComponentInspectionReportType ComponentInspectionReportType { get; set; }
        public virtual CountryISO CountryISO { get; set; }
        public virtual ReportType ReportType { get; set; }
        public virtual SBU SBU { get; set; }
        public virtual ServiceReportNumberType ServiceReportNumberType { get; set; }
        public virtual ICollection<ComponentInspectionReportBlade> ComponentInspectionReportBlade { get; set; }
        public virtual ICollection<ComponentInspectionReportGearbox> ComponentInspectionReportGearbox { get; set; }
        public virtual ICollection<ComponentInspectionReportGeneral> ComponentInspectionReportGeneral { get; set; }
        public virtual ICollection<ComponentInspectionReportGenerator> ComponentInspectionReportGenerator { get; set; }
        public virtual ICollection<ComponentInspectionReportMainBearing> ComponentInspectionReportMainBearing { get; set; }
        public virtual ICollection<ComponentInspectionReportSkiiP> ComponentInspectionReportSkiiP { get; set; }
        public virtual ICollection<ComponentInspectionReportTransformer> ComponentInspectionReportTransformer { get; set; }
        public virtual ICollection<DynamicDecisionDetails> DynamicDecisionDetails { get; set; }
        public virtual ICollection<ImageData> ImageData { get; set; }
        public virtual ICollection<ImageDataInfo> ImageDataInfo { get; set; }
    }
}
