using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class Bir
    {
        public long BirDataID { get; set; }
        public string BirCode { get; set; }
        public int RevisionNumber { get; set; }
        public string RepairingSolutions { get; set; }
        public string RawMaterials { get; set; }
        public string ConclusionsAndRecommendations { get; set; }
        public string CirIDs { get; set; }
        public DateTime Created { get; set; }
        public String strCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string BladeSerialNos { get; set; }
        public long TurbineID { get; set; }
        public SearchAttributes Search { get; set; }
        public CIR.ComponentInspectionReport ComponentInspectionReport { get; set; }
        public List<CIR.ComponentInspectionReport> ComponentInspectionReportDetails { get; set; }
        public BirFile File { get; set; }
    }

    public class CirPDFResponse
    {
        public string DownloadUrl { get; set; }
        public string FileName { get; set; }
    }
}
