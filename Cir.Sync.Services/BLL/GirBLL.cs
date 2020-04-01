using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services.BLL
{
    public static class GirBLL
    {
        public static List<Gir> Search(Gir gir)
        {
            return DAL.DAGir.Search(
                gir: gir
                );
        }

        public static bool DeleteGir(long GirID)
        {
            return DAL.DAGir.DeleteGir(
                GirID: GirID
                );
        }

        public static Gir GirFileBytes(long GirID)
        {
            return DAL.DAGir.GirFileBytes(
                GirID: GirID
                );
        }

        /// <summary>
        /// Get BiData by ID
        /// </summary>
        /// <param name="CirIDs"></param>
        /// <returns></returns>
        public static Gir GetGirDataByCirID(string CirIDs)
        {
            return DAL.DAGir.GetGirDataByCirID(CirIDs);
        }

        /// <summary>
        /// save BiData 
        /// </summary>
        /// <param name="BiData"></param>
        /// <returns></returns>
        /// 
        public static Gir SaveGirData(Gir GirDate)
        {

            return DAL.DAGir.SaveGirData(GirDate);
        }


        public static List<Gir> GetGirMigrationData()
        {

            return DAL.DAGir.GetGirMigrationData();
        }
        public static bool SaveGirDataDetailstoCosmosDb(GirDataDetails objGirDataDetails, string strGirDataDocumentId)
        {
            return DAL.DAGir.SaveGirDataDetailstoCosmosDb(objGirDataDetails, strGirDataDocumentId);

        }

    }
}
