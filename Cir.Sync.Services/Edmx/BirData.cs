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
    
    public partial class BirData
    {
        public BirData()
        {
            this.BirWordDocument = new HashSet<BirWordDocument>();
        }
    
        public long BirDataID { get; set; }
        public string BirCode { get; set; }
        public int RevisionNumber { get; set; }
        public string RepairingSolutions { get; set; }
        public string RawMaterials { get; set; }
        public string ConclusionsAndRecommendations { get; set; }
        public string CirIDs { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string BladeSerialNos { get; set; }
    
        public virtual ICollection<BirWordDocument> BirWordDocument { get; set; }
    }
}
