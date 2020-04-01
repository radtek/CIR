using System.Web.Http;
using Cir.Data.Access.Services;
using Microsoft.Azure.Mobile.Server.Config;

namespace Cir.Data.Api.Controllers
{
    [MobileAppController]
    public class UserDataController : ApiController
    {
        private readonly IUserDataService _userDataService;

        public UserDataController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        // GET api/UserData
        public IHttpActionResult Get(string userId)
        {
            return Ok(_userDataService.GetData(userId));
        }
    }
}
