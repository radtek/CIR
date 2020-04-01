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
    public class CirDataController : ApiController
    {
        public ApiServices Services { get; set; }

        // POST api/CirData
        public string Post(string CirJsonData)
        {
            Services.Log.Info("Entered MasterData custom controller! -Post");
            return (new SyncServiceUtilities(Services)).SaveCir(CirJsonData);
        }

    }
}
