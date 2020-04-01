using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class ManufacturerList
    {
        public int ManufacturerType { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
    public class Manufacturer
    {
        public int ManufacturerType { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }


    }
}