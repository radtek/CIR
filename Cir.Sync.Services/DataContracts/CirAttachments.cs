using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class CirAttachments
    {
        [DataMember]
        public long CirAttachmentId { get; set; }
        [DataMember]
        public long CirId { get; set; }
        [DataMember]
        public string Filename { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string Created { get; set; }
        [DataMember]
        public string StringData { get; set; }

        public CirAttachments(long cirAttachmentId, long cirId, string fileName, string createdBy, string created, string stringData)
        {
            CirAttachmentId = cirAttachmentId;
            CirId = cirId;
            Filename = fileName;
            CreatedBy = createdBy;
            Created = created;
            StringData = stringData;
        }

        public CirAttachments()
        { }
    }
}
