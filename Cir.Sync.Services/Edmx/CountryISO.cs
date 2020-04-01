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
    
    public partial class CountryISO
    {
        public CountryISO()
        {
            this.CountryISO1 = new HashSet<CountryISO>();
            this.SBUNotification = new HashSet<SBUNotification>();
            this.FirstNotification = new HashSet<FirstNotification>();
            this.ComponentInspectionReport = new HashSet<ComponentInspectionReport>();
        }
    
        public long CountryISOId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentCountryISOId { get; set; }
        public long Sort { get; set; }
        public Nullable<long> SBUId { get; set; }
    
        public virtual ICollection<CountryISO> CountryISO1 { get; set; }
        public virtual CountryISO CountryISO2 { get; set; }
        public virtual ICollection<SBUNotification> SBUNotification { get; set; }
        public virtual ICollection<FirstNotification> FirstNotification { get; set; }
        public virtual ICollection<ComponentInspectionReport> ComponentInspectionReport { get; set; }
    }
}