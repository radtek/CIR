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
    
    public partial class GBXirWordDocument
    {
        public long GBXirWordDocumentID { get; set; }
        public Nullable<long> GBXirDataID { get; set; }
        public byte[] WordDocBytes { get; set; }
        public string GBXirCode { get; set; }
    
        public virtual GBXirData GBXirData { get; set; }
    }
}
