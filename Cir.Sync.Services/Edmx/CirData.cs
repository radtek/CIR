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
    
    public partial class CirData
    {
        public CirData()
        {
            this.CirCommentHistory = new HashSet<CirCommentHistory>();
            this.SecondNotification = new HashSet<SecondNotification>();
            this.FirstNotification = new HashSet<FirstNotification>();
        }
    
        public long CirDataId { get; set; }
        public long CirId { get; set; }
        public string Guid { get; set; }
        public byte State { get; set; }
        public byte Progress { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string Filename { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Nullable<byte> Locked { get; set; }
        public string LockedBy { get; set; }
        public string TemplateVersion { get; set; }
    
        public virtual ICollection<CirCommentHistory> CirCommentHistory { get; set; }
        public virtual ICollection<SecondNotification> SecondNotification { get; set; }
        public virtual ICollection<FirstNotification> FirstNotification { get; set; }
    }
}