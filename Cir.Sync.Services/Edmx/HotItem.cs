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
    
    public partial class HotItem
    {
        public long HotItemId { get; set; }
        public Nullable<long> ComponentInspectionReportTypeId { get; set; }
        public string VestasItemNumber { get; set; }
        public string VestasItemName { get; set; }
        public string ManufacturerName { get; set; }
        public Nullable<long> LanguageId { get; set; }
        public Nullable<long> Sort { get; set; }
        public string Email { get; set; }
        public string Cc { get; set; }
        public string HotItemDisplay { get; set; }
    
        public virtual ComponentInspectionReportType ComponentInspectionReportType { get; set; }
    }
}
