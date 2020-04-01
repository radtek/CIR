using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.DAL;
using System.Runtime.Serialization;



namespace Cir.Sync.Services.DataContracts
{
    [DataContract]
    public class LogList
    {

        [DataMember]
        public int SortColumnIndex { get; set; }
        [DataMember]
        public int SortDirection { get; set; }
        [DataMember]
        public int CurrentPageNumber { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public string Data { get; set; }

        [DataMember]
        public int TotalRecordCount { get; set; }
        [DataMember]
        public int RecordsPerPage { get; set; }

        [DataMember]
        public string LogFromDate { get; set; }
        [DataMember]
        public string LogToDate { get; set; }
    }

    //public class Log
    //{
    //    public long Id { get; set; }
    //    public string message { get; set; }
    //    public string details { get; set; }
    //    public System.DateTime timestamp { get; set; }
    //    public ErrorHandling.LogType type { get; set; }
    //}

    [DataContract]
    public class MigrationStepLogging
    {
        [DataMember]
        public string LogId { get; set; }
        [DataMember]
        public short LogType { get; set; }
        [DataMember]
        public long CirId { get; set; }
        [DataMember]
        public string CirType { get; set; }
        [DataMember]
        public long CirDataId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public DateTime? Timestamp { get; set; }
    }
}
