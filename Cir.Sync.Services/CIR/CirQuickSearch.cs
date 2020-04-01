using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.CIR
{
    /// <summary>
    /// Cir quick search entity
    /// </summary>
    public class CirQuickSearch
    {
        public long ReportTypeId { get; set; }
        public long ComponentInspectionReportTypeId { get; set; }
        public long CIMCaseNumber { get; set; }
        public long TurbineNumber { get; set; }
        public long CirID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string TurbineType { get; set; }
        public string RunStatus { get; set; }
        public long SBU { get; set; }
        //Added by Siddharth Chauhan on 29-06-2016.
        //To fix the bug : 82364
        public string SBUName { get; set; }
        //Added by Siddharth Chauhan on 08-06-2016.
        //to filter the records on the basis of State(UnApproved,Accpeted,Rejected).
        //Task No. : 75297
        public byte State { get; set; }
        public DataContracts.SearchAttributes Search { get; set; }
        public string SiteName { get; set; }

    }
}
