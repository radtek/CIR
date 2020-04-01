using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cir.Azure.Functions
{
    class GetRepairListHandlerMock : IHttpHandler
    {
        public Task<HttpResponseMessage> HandleAsync(HttpRequest req, ILogger log, string id = null)
        {
            var response = new RepairListDto
            {
                Repairs = new List<Repair>()
                    {
                        new Repair { RepairId = "10", DamageGuid = "bbbbbbbb-950e-4be4-9ac2-ff670fdf0a99", BladeId = "21", DamageId = "12", Date = "2019-02-15", TurbineId = "3"},
                        new Repair { RepairId = "9", DamageGuid = "aaaaaaaa-950e-4be4-9ac2-ff670fdf0a99", BladeId = "2", DamageId = "1", Date = "2019-02-10", TurbineId = "5"}
                    }
            };

            return Task.FromResult(
                                new HttpResponseMessage(HttpStatusCode.OK)
                                {
                                    Content = new ObjectContent<RepairListDto>(response, new JsonMediaTypeFormatter())
                                });
        }
    }
}
