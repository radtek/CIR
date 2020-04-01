using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.ErrorHandling;
using Cir.Sync.Services.DAL;
using Cir.Sync.Services.DataContracts;


namespace Cir.Sync.Services.BLL
{
    public static class BLSystemLog
    {
        public static void Log(string message, string details, LogType type)
        {
            DAL.DASystemLog.Log(message, details, type);
        }
        public static void Log(string message, string details, LogType type,string CirJson)
        {
            DAL.DASystemLog.Log(message, details, type, CirJson);
        }
        public static LogList GetLog(LogList log)
        {
            return DAL.DASystemLog.GetLog(log);
        }
        public static bool MigrationLog(MigrationStepLogging objMigrationLogging)
        {
            return DAL.DASystemLog.MigrationLog(objMigrationLogging);
        }
    }
}
