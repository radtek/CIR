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
    
    public partial class CirFeedback
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Nullable<long> FeedbackTypeId { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Enviroment { get; set; }
    
        public virtual FeedbackType FeedbackType { get; set; }
        public virtual FeedbackType FeedbackType1 { get; set; }
    }
}
