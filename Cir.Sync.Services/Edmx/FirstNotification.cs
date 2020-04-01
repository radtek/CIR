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
    
    public partial class FirstNotification
    {
        public long FirstNotificationId { get; set; }
        public long ComponentInspectionReportId { get; set; }
        public Nullable<System.DateTime> SendOn { get; set; }
        public long SBUId { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string EditInitials { get; set; }
        public Nullable<long> TurbineMatrixId { get; set; }
        public string Sitename { get; set; }
        public long CountryISOId { get; set; }
        public string ComponentType { get; set; }
        public Nullable<long> ManufacturerID { get; set; }
        public string SerialNo { get; set; }
        public Nullable<System.DateTime> CommisioningDate { get; set; }
        public Nullable<System.DateTime> FailureDate { get; set; }
        public Nullable<System.DateTime> QueuedOn { get; set; }
        public Nullable<long> CirDataId { get; set; }
    
        public virtual CirData CirData { get; set; }
        public virtual CountryISO CountryISO { get; set; }
        public virtual SBU SBU { get; set; }
    }
}
