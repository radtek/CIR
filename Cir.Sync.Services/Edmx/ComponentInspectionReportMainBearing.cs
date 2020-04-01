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
    
    public partial class ComponentInspectionReportMainBearing
    {
        public long ComponentInspectionReportMainBearingId { get; set; }
        public long ComponentInspectionReportId { get; set; }
        public string VestasUniqueIdentifier { get; set; }
        public System.DateTime MainBearingLastLubricationDate { get; set; }
        public Nullable<long> MainBearingManufacturerId { get; set; }
        public Nullable<long> MainBearingTemperature { get; set; }
        public Nullable<long> MainBearingLubricationOilTypeId { get; set; }
        public bool MainBearingGrease { get; set; }
        public long MainBearingLubricationRunHours { get; set; }
        public Nullable<long> MainBearingOilTemperature { get; set; }
        public Nullable<long> MainBearingTypeId { get; set; }
        public Nullable<long> MainBearingRevision { get; set; }
        public Nullable<long> MainBearingErrorLocationId { get; set; }
        public string MainBearingSerialNumber { get; set; }
        public Nullable<long> MainBearingRunHours { get; set; }
        public string MainBearingMechanicalOilPump { get; set; }
        public Nullable<long> MainBearingClaimRelevantBooleanAnswerId { get; set; }
    
        public virtual MainBearingManufacturer MainBearingManufacturer { get; set; }
        public virtual MainBearingManufacturer MainBearingManufacturer1 { get; set; }
        public virtual ComponentInspectionReport ComponentInspectionReport { get; set; }
    }
}