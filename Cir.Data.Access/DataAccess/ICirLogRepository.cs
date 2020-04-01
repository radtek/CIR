using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cir.Data.Access.Enumerations.Enumeration;

namespace Cir.Data.Access.DataAccess
{
    public interface ICirLogRepository
    {
        void AddLogs(string id , string turbineNumber, string logText, DateTime date, LogType logType);
    }
}
