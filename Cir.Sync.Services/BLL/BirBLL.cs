using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.DAL;
using Newtonsoft.Json.Linq;

namespace Cir.Sync.Services.BLL
{
    public static class BirBLL
    {
        public static List<Bir> Search(Bir bir)
        {
            return DAL.DABir.Search(
                bir: bir
                );
        }

        public static bool DeleteBir(long BirID)
        {
            return DAL.DABir.DeleteBir(
                BirID: BirID
                );
        }

        public static Bir BirFileBytes(long BirID)
        {
            return DAL.DABir.BirFileBytes(
                BirID: BirID
                );
        }

        /// <summary>
        /// Get BiData by ID
        /// </summary>
        /// <param name="CirIDs"></param>
        /// <returns></returns>
        public static Bir GetBirDataByCirID(string CirIDs)
        {
            return DAL.DABir.GetBirDataByCirID(CirIDs);
        }

        /// <summary>
        /// Get related cirs by cir Id
        /// </summary>
        /// <param name="CirIDs"></param>
        /// <returns></returns>
        public static string GeRelatedCirsByCirId(string cirId)
        {
            return DAL.DABir.GetRelatedCirsIdByCirId(cirId);
        }

        /// <summary>
        /// save BiData 
        /// </summary>
        /// <param name="BiData"></param>
        /// <returns></returns>
        /// 
        public static Bir SaveBirData(Bir BirDate)
        {

            return DAL.DABir.SaveBirData(BirDate);
        }

        public static List<Bir> GetBirMigrationData()
        {

            return DAL.DABir.GetBirMigrationData();
        }

        public static Dictionary<string, string> GetCirDataIdByCirID(string CirIDs)
        {
            return DAL.DABir.GetCirDataIdByCirID(CirIDs);
        }
        public static void SaveBirDataDetailstoCosmosDb(BirDataDetails oBirDetails, string birDataDocumentId)
        {
            DAL.DABir.SaveBirDataDetailstoCosmosDb(oBirDetails, birDataDocumentId);
        }
    }
}
