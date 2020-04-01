using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class CirLogs
    {
        public long _CirLogId;
        public long _CirDataId;
        public System.DateTime _Timestamp;
        public string _Text;
        public short _Type;
        public string _Initials;        

        [DataMember]
        public long CirLogId
        {
            get { return _CirLogId; }
            set { _CirLogId = value; }
        }
        [DataMember]
        public long CirDataId
        {
            get { return _CirDataId; }
            set { _CirDataId = value; }
        }

        [DataMember]
        public System.DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }
        [DataMember]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        [DataMember]
        public short Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        [DataMember]
        public string Initials
        {
            get { return _Initials; }
            set { _Initials = value; }
        }
        
    }

    
}
