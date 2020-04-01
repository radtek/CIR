using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    public interface ICimCaseService
    {
        string TableName { get; }
        IList<object> GetTableData();
    }
}
