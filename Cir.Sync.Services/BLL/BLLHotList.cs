using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLLHotList
    {
        public static DataContracts.Hotlist GetHotlist(int id)
        {
            return DAL.DAHotlist.GetHotlist(id);
        }

        public static List<DataContracts.Hotlist> GetAllHotlist()
        {
            return DAL.DAHotlist.GetAllHotlist();
        }

        public static bool SaveHotList(Hotlist hotlist)
        {
               return DAL.DAHotlist.SaveHotList(hotlist);
        }

        public static bool DeleteHotList(int  id)
        {
            return DAL.DAHotlist.DeleteHotList(id);
        }
    }
}