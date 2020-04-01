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
    
    public partial class ComponentInspectionReportType
    {
        public ComponentInspectionReportType()
        {
            this.CirStandardTexts = new HashSet<CirStandardTexts>();
            this.ComponentInspectionReportType1 = new HashSet<ComponentInspectionReportType>();
            this.HotItem = new HashSet<HotItem>();
            this.ComponentInspectionReport = new HashSet<ComponentInspectionReport>();
        }
    
        public long ComponentInspectionReportTypeId { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentComponentInspectionReportTypeId { get; set; }
        public long Sort { get; set; }
    
        public virtual ICollection<CirStandardTexts> CirStandardTexts { get; set; }
        public virtual ICollection<ComponentInspectionReportType> ComponentInspectionReportType1 { get; set; }
        public virtual ComponentInspectionReportType ComponentInspectionReportType2 { get; set; }
        public virtual ICollection<HotItem> HotItem { get; set; }
        public virtual ICollection<ComponentInspectionReport> ComponentInspectionReport { get; set; }
    }
}