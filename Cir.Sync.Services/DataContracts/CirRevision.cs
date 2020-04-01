using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class CirRevision
    {
        [DataMember]
        public long CirDataId { get; set; }
        [DataMember]
        public long CirId { get; set; }
        [DataMember]
        public string TemplatedRevisionId { get; set; }
        [DataMember]
        public System.DateTime EditedOn { get; set; }
        [DataMember]
        public string EditedBy { get; set; }

        [DataMember]
        public int Progress { get; set; }
        [DataMember]
        public int CirState { get; set; }
        [DataMember]
        public byte? Locked { get; set; }
        [DataMember]
        public string LockedBy { get; set; }
    }
}
