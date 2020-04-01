using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLLManufacturer
    {
        public static  Manufacturer GetManufacturer(int type,int id)
        {
            return DAL.DAManufacturer.GetManufacturer(type, id);
        }

        public static ManufacturerList GetManufacturerList(int type)
        {
            return DAL.DAManufacturer.GetManufacturerList(type);
        }

        public static bool DeleteManufacturer(int type, int id)
        {
            return DAL.DAManufacturer.DeleteManufacturer(type, id);
        }

        public static bool SaveManufacturer(Manufacturer m)
        {
            return DAL.DAManufacturer.SaveManufacturer(m);
        }
    }
}