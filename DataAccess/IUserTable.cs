using System.Collections.Generic;

namespace Cir.Data.Access.DataAccess
{
    internal interface IUserTable
    {
        string TableName { get; }

        IList<object> GetTableData(string userId);
    }
}
