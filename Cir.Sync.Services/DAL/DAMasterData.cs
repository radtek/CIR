using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;


namespace Cir.Sync.Services.DAL
{
    /// <summary>
    /// Data layer of cir master data
    /// </summary>
    public static class DAMasterData
    {
        /// <summary>
        /// Get all Master data from database
        /// </summary>
        /// <returns></returns>
        public static List<CirMasterData> GetMasterData()
        {
            List<CirMasterData> lstMsDataCollection = new List<CirMasterData>();
            DataSet dsMasterDate = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spCIRMasterDataAll", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsMasterDate);
                        lstMsDataCollection = (from row in dsMasterDate.Tables[0].AsEnumerable()
                                               group row by row.Field<string>("KeyType") into g
                                               select new CirMasterData { Key = g.Key, MasterKeyValue = (from master in g select new MasterKeyValue { keyType = master.Field<string>("KeyType"), Key = master.Field<Int64?>("KeyID").ToString(), Value = master.Field<string>("KeyValue") }).ToList() }).ToList();
                    }
                }
            }

            return lstMsDataCollection;
        }


        /// <summary>
        /// Get Master data by tbale name from database
        /// </summary>
        /// <returns></returns>
        public static List<CirMasterTable> GetMasterDataByName(string TableName, string UserId)
        {
            List<CirMasterTable> lstMsDataCollection = new List<CirMasterTable>();
            DataSet dsMasterDate = new DataSet();

            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spCIRMasterByName", objCon))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TableName", TableName));
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsMasterDate);
                        lstMsDataCollection = (from row in dsMasterDate.Tables[0].AsEnumerable()
                                               select new CirMasterTable { Key = row.Field<string>("KeyType"), Text = row.Field<string>("KeyText"), Value = row.Field<Int64?>("KeyID").ToString() }).ToList();
                    }
                }
            }

            return lstMsDataCollection;
        }

        //CIMCase
        public static List<CirCIMCaseTable> GetCIMCaseData()
        {
            List<CirCIMCaseTable> lstCIMCaseCollection = new List<CirCIMCaseTable>();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                lstCIMCaseCollection = (from c in context.CIMCase.AsEnumerable()
                                        select new CirCIMCaseTable { value = c.CaseNo, label = c.CaseNo.ToString(), desc = c.CaseNo.ToString() + " - " + c.Description }).ToList();
                
            }

            return lstCIMCaseCollection;
        }
        //CIMCase
        /// <summary>
        ///  Return Connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
    }
}