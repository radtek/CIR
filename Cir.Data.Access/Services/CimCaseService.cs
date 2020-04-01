using Cir.Data.Access.CirSyncService;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Services
{
    internal class CimCaseService : ICimCaseService
    {
        public string TableName => "CimCase";
        private readonly SyncServiceClient _serviceClient;

        public CimCaseService()
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public IList<object> GetTableData()
        {
            return _serviceClient.GetCIMCaseData().ToList<object>();
        }
    }
}
