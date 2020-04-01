using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.BLL;

namespace Cir.Sync.Services.ErrorHandling
{
    public enum LogType
    {
        All = 0,
        Information = 1,
        Error = 2,
        Warning = 3
    }
    public static class SystemLog
    {
        public static void Log(string message, string details, LogType type)
        {
            BLL.BLSystemLog.Log(message, details, type);
        }
        public static void CirServiceLog(string message, string details, LogType type,string CirJson)
        {
            BLL.BLSystemLog.Log(message, details, type, CirJson);
        }
    }
}
