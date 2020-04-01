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
    public class CirResponse
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public string StatusDetailMessage { get; set; }
        public TurbineItem Turbine { get; set; }
        public long CirID { get; set; }
        public string CirName { get; set; }
        public long CirDataId { get; set; }
        public string CIMCaseNumber { get; set; }
        public string InnerExceptionMessage { get; set; }
    }

    public class TurbineItem
    {
        public string TurbineID { get; set; }
        public string TurbineType { get; set; }
        public string Country { get; set; }
        public string NominelPower { get; set; }
        public string RotorDiameter { get; set; }
        public string Voltage { get; set; }
        public string PowerRegulation { get; set; }
        public string Frequency { get; set; }
        public string SmallGenerator { get; set; }
        public string TemperatureVariant { get; set; }
        public string MarkVersion { get; set; }
        public string Site { get; set; }
        public string Manufacturer { get; set; }
    }
}
