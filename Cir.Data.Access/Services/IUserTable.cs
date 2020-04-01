using Cir.Data.Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    public interface IUserTable
    {
        string TableName { get; }

        Task<IList<object>> GetTableData(IList<CirSubmissionData> cirSubmissionData);
    }
}
