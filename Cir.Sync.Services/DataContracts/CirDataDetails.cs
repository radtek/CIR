using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class CirDataDetails
    {
        public long CirDataId { get; set; }
        public long CirId { get; set; }
        public byte CIRstate { get; set; }
        public string Filename { get; set; }
        public string ComponentType { get; set; }
        public long CIMCaseNumber { get; set; }
        public string ReportType { get; set; }
        public string TurbineType { get; set; }
        public string TurbineNumber { get; set; }

        
    }
}
