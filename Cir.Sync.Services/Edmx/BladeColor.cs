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
    
    public partial class BladeColor
    {
        public BladeColor()
        {
            this.BladeColor1 = new HashSet<BladeColor>();
            this.ComponentInspectionReportBlade = new HashSet<ComponentInspectionReportBlade>();
        }
    
        public long BladeColorId { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentBladeColorId { get; set; }
        public long Sort { get; set; }
        public string Brand { get; set; }
    
        public virtual ICollection<BladeColor> BladeColor1 { get; set; }
        public virtual BladeColor BladeColor2 { get; set; }
        public virtual ICollection<ComponentInspectionReportBlade> ComponentInspectionReportBlade { get; set; }
    }
}
