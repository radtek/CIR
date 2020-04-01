using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Cir.Azure.MobileService.Utilities;

namespace Cir.Azure.MobileService.Controllers
{
    [Authorize]
    [AuthorizeAadRole(AadRoles.CirCreators)]
    public class MasterDataController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Get
        public System.Collections.Generic.List<Cir.Azure.MobileService.CirSyncService.CirMasterData> Get()
        {
            Services.Log.Info("Entered MasterData custom controller!");

            return (new SyncServiceUtilities(Services)).GetMasterData();
        }

    }
}
