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
    
    public partial class BladeInspectionData
    {
        public BladeInspectionData()
        {
            this.BladeInspectionData1 = new HashSet<BladeInspectionData>();
            this.ComponentInspectionReportBladeDamage = new HashSet<ComponentInspectionReportBladeDamage>();
        }
    
        public long BladeInspectionDataId { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentBladeInspectionDataId { get; set; }
        public long Sort { get; set; }
    
        public virtual ICollection<BladeInspectionData> BladeInspectionData1 { get; set; }
        public virtual BladeInspectionData BladeInspectionData2 { get; set; }
        public virtual ICollection<ComponentInspectionReportBladeDamage> ComponentInspectionReportBladeDamage { get; set; }
    }
}
