using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class CirDefectCategorization
    {
        public bool status { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public int componenttype { get; set; }
        [DataMember]
        public long cirid { get; set; }
        [DataMember]
        public long cirdataid { get; set; }
        [DataMember]
        public string filedata { get; set; }
        [DataMember]
        public string filename { get; set; }
        [DataMember]
        public string path { get; set; }
        [DataMember]
        public string initials { get; set; }

    }


}