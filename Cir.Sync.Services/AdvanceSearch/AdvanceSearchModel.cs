using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cir.Sync.Services.AdvanceSearch
{
    [DataContract]
    public class AdvanceSearchModel
    {
        [DataMember]
        public long ProfileID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ProfileName { get; set; }
        [DataMember]
        public bool isPublic { get; set; }
        [DataMember]
        public List<InputFields> InputFields { get; set; }
        [DataMember]
        public string ResponseString { get; set; }
        [DataMember]
        public string Result { get; set; }
    }
    [DataContract]
    public class InputFields
    {
        [DataMember]
        public string InputId { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string InputType { get; set; }
    }
}