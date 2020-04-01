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
    
    public partial class ComponentInspectionReportBladeDamage
    {
        public long ComponentInspectionReportBladeDamageId { get; set; }
        public long ComponentInspectionReportBladeId { get; set; }
        public long BladeDamagePlacementId { get; set; }
        public long BladeInspectionDataId { get; set; }
        public double BladeRadius { get; set; }
        public long BladeEdgeId { get; set; }
        public string BladeDescription { get; set; }
        public string BladePictureNumber { get; set; }
        public Nullable<int> PictureOrder { get; set; }
        public Nullable<int> DamageSeverity { get; set; }
        public Nullable<System.Guid> FormIOImageGUID { get; set; }
    
        public virtual BladeDamagePlacement BladeDamagePlacement { get; set; }
        public virtual BladeEdge BladeEdge { get; set; }
        public virtual BladeInspectionData BladeInspectionData { get; set; }
        public virtual ComponentInspectionReportBlade ComponentInspectionReportBlade { get; set; }
    }
}