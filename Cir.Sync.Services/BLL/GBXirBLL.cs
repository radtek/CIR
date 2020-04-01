using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services.BLL
{
    public static class GBXirBLL
    {
        public static List<Gbx> Search(Gbx gbx)
        {
            return DAL.DAGbx.Search(
                gbx: gbx
                );
        }

        public static bool DeleteGBXir(long GBXirID)
        {
            return DAL.DAGbx.DeleteGbx(
                GbxID: GBXirID
                );
        }

        public static Gbx GBXirFileBytes(long GBXirID)
        {
            return DAL.DAGbx.GbxFileBytes(
                GbxID: GBXirID
                );
        }


        public static Gbx GetGBXirDataByCirID(string CirIDs)
        {
            return DAL.DAGbx.GetGbxDataByCirID(CirIDs);
        }


        public static Gbx SaveGBXirData(Gbx GBXirData)
        {

            return DAL.DAGbx.SaveGbxData(GBXirData);
        }

        public static List<Gbx> GetGBXirMigrationData()
        {
            return DAL.DAGbx.GetGBXirMigrationData();
        }
        public static bool SaveGBXirDataDetailstoCosmosDb(GBXirDataDetails objGbrDataDetails, string strGbxDataDocumentId)
        {
            return DAL.DAGbx.SaveGBXirDataDetailstoCosmosDb(objGbrDataDetails, strGbxDataDocumentId);
        }

    }
}
