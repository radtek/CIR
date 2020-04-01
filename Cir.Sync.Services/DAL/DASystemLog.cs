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
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System.Globalization;
using System.Data.SqlTypes;
using System.Data.Objects;
using System.Web.Hosting;
using System.IO;
using Cir.Common.Utilities;
using System.Collections;
using System.Xml.Serialization;
using Cir.Common.Notification;
using Cir.Sync.Services.Notification;

namespace Cir.Sync.Services.DAL
{
    public static class DASystemLog
    {
        /// <summary>
        /// Cir log in CirSystemLog table
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <param name="type"></param>
        public static void Log(string message, string details, LogType type)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.CirSystemLog oLog = new CirSystemLog();
                oLog.Message = message;
                oLog.Details = details;
                oLog.Timestamp = DateTime.Now;
                oLog.Type = (short)type;
                context.CirSystemLog.Add(oLog);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Cir Sync log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <param name="type"></param>
        /// <param name="CirJson"></param>
        public static void Log(string message, string details, LogType type, string CirJson)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                Edmx.CirSyncLog oLog = new CirSyncLog();
                oLog.Message = message;
                oLog.Details = details;
                oLog.Timestamp = DateTime.Now;
                oLog.Type = (short)type;
                oLog.CirJson = CirJson;
                context.CirSyncLog.Add(oLog);
                context.SaveChanges();
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }
        /// <summary>
        /// Get logs
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <param name="type"></param>
        /// <param name="CirJson"></param>
        public static LogList GetLog(LogList log)
        {
            using (SqlConnection objCon = new SqlConnection(GetConnectionString()))
            {
                DataSet dsLog = new DataSet();
                LogList _logList = new LogList();
                //List<DataContracts.Log> dLogs = new List<DataContracts.Log>();

                using (SqlCommand cmd = new SqlCommand("SP_Get_CirSyncLogs", objCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Type", SqlDbType.Int);
                    cmd.Parameters["@Type"].Value = log.Type;

                    cmd.Parameters.Add("@SortColumnIndex", SqlDbType.Int);
                    cmd.Parameters["@SortColumnIndex"].Value = log.SortColumnIndex;

                    cmd.Parameters.Add("@SortDirection", SqlDbType.Int);
                    cmd.Parameters["@SortDirection"].Value = log.SortDirection;

                    cmd.Parameters.Add("@CurrentPageNumber", SqlDbType.Int);
                    cmd.Parameters["@CurrentPageNumber"].Value = log.CurrentPageNumber;

                    cmd.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                    cmd.Parameters["@RecordsPerPage"].Value = log.RecordsPerPage;
                    cmd.Parameters["@RecordsPerPage"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@TotalRecordCount", SqlDbType.Int);
                    cmd.Parameters["@TotalRecordCount"].Value = 0;
                    cmd.Parameters["@TotalRecordCount"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@LogFromDate", SqlDbType.VarChar);
                    cmd.Parameters["@LogFromDate"].Value = log.LogFromDate;

                    cmd.Parameters.Add("@LogToDate", SqlDbType.VarChar);
                    cmd.Parameters["@LogToDate"].Value = log.LogToDate;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsLog);
                    }
                    var LogTable = dsLog.Tables[0];

                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in LogTable.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in LogTable.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }

                    _logList = new LogList { CurrentPageNumber = log.CurrentPageNumber, RecordsPerPage = Convert.ToInt32(cmd.Parameters["@RecordsPerPage"].Value), TotalRecordCount = Convert.ToInt32(cmd.Parameters["@TotalRecordCount"].Value), Data = serializer.Serialize(rows), SortColumnIndex = log.SortColumnIndex, SortDirection = log.SortDirection, Type = log.Type };

                }

                return _logList;
            }
        }

        #region SQL Migration Logs
        /// <summary>
        /// This is used to step(s)\exception logging into sql server
        /// </summary>
        /// <param name="objMigrationLogging"></param>
        /// <returns></returns>
        public static bool MigrationLog(MigrationStepLogging objMigrationLogging)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GetConnectionString()))
                {
                    sqlConn.Open();
                    int noOfAffected = 0; bool flag;
                    using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SPSQLMigrationLogs]", sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@LogType", (short)objMigrationLogging.LogType);
                        sqlCmd.Parameters.AddWithValue("@CirId", objMigrationLogging.CirId);
                        sqlCmd.Parameters.AddWithValue("@CirType", objMigrationLogging.CirType);
                        sqlCmd.Parameters.AddWithValue("@CirDataId", objMigrationLogging.CirDataId);
                        sqlCmd.Parameters.AddWithValue("@Message", objMigrationLogging.Message);
                        sqlCmd.Parameters.AddWithValue("@Details", objMigrationLogging.Details);
                        sqlCmd.Parameters.AddWithValue("@Timestamp", objMigrationLogging.Timestamp);

                        noOfAffected = sqlCmd.ExecuteNonQuery();// for taking single value

                        if (noOfAffected > 0) flag = true;
                        else
                        {
                            sqlConn.Close();
                            flag = false;
                        }
                    }
                    return flag;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

    }
}
