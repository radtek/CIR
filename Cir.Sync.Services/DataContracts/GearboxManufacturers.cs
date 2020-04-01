using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class GearboxManufacturers
    {    
        public long GearboxManufacturerId { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public Nullable<long> ParentGearboxManufacturerId { get; set; }
        public long Sort { get; set; }
        public string Email { get; set; }
        public string Cc { get; set; }
        public string EmailContactName { get; set; }
    
    }
}