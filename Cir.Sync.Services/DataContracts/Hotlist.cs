using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class Hotlist
    {
        public long? ReportTypeId { get; set; }
        public string VestasItemNumber { get; set; }
        public string VestasItemName { get; set; }
        public string ManufacturerName { get; set; }
        public string Email { get; set; }
        public string Cc { get; set; }
        public string HotItemDisplay { get; set; }
        public long HotItemId { get; set; }
        public string ReportType { get; set; }
      

        

    }
}