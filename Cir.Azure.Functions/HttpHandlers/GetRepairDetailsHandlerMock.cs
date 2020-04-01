using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Cir.Azure.Functions
{
    class GetRepairDetailsHandlerMock : IHttpHandler
    {
        public Task<HttpResponseMessage> HandleAsync(HttpRequest req, ILogger log, string id = null)
        {
            var response = new RepairDetailsDto
            {
                Repair = new RepairDetails
                {
                    RepairId = "10",
                    BladeId = "21",
                    DamageId = "12",
                    DamageGuid = "bbbbbbbb-950e-4be4-9ac2-ff670fdf0a99",
                    Date = "2019-02-15",
                    TurbineId = "3",
                    Steps = new List<IRepairStep>
                    {
                        new LaminationRepairStep
                        {
                            HeatersInsulationCoverAndVacuumOff = new DateTime(2019, 2, 15, 18, 0, 0, DateTimeKind.Utc),
                            Images = new List<string>
                            {
                                "https://cirblobstoragedev.blob.core.windows.net/cirdevcontainer/12345/0b15787b-4d26-4682-ab31-5b2d17f48c1b/Images/3cb69964-535e-4877-95b0-a5fd1ba41e7f.jpeg",
                                "https://cirblobstoragedev.blob.core.windows.net/cirdevcontainer/12345/0b15787b-4d26-4682-ab31-5b2d17f48c1b/Images/65b09123-d8e0-4774-88dd-4dfc8bed41f6.jpeg",
                                "https://cirblobstoragedev.blob.core.windows.net/cirdevcontainer/12345/0b15787b-4d26-4682-ab31-5b2d17f48c1b/Images/dc372911-b067-4f8f-b0f9-2a29261644c2.jpeg"
                            },
                            LaminatType = "Biax",
                            MaxPostcureSurfaceTemperature = 25,
                            MinPostcureSurfaceTemperature = 5,
                            TotalCureTime = "5H",
                            Type = "Lamination"
                        }
                    }
                }
            };

            return Task.FromResult(
                                new HttpResponseMessage(HttpStatusCode.OK)
                                {
                                    Content = new ObjectContent<RepairDetailsDto>(response, new JsonMediaTypeFormatter())
                                });
        }
    }
}
