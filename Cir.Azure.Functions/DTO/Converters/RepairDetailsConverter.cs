using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class RepairDetailsConverter : IRepairDetailsConverter
    {
        public RepairDetailsDto Convert(JObject repair)
        {
            if (repair == null)
                throw new ArgumentNullException("repair");

            try
            {
                IEnumerable<IRepairStep> steps = ConvertSteps((IList<JObject>)repair["cirSubmissionData"]["data"]["imagecomponentKey"]["repairSteps"]);
                return new RepairDetailsDto
                {
                    Repair = new RepairDetails
                    {
                        BladeId =    repair["cirSubmissionData"]?["data"]?["txtBladeSerialNumber"]?.ValueOrDefault<string>(),
                        DamageGuid = repair["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["damageGuid"]?.ValueOrDefault<string>(),
                        DamageId =   repair["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["damageId"]?.ValueOrDefault<string>(),
                        Date =       repair["cirSubmissionData"]?["data"]?["dtInspectionDate"]?.ValueOrDefault<string>(),
                        TurbineId =  repair["cirSubmissionData"]?["data"]?["txtTurbineNumber"]?.ValueOrDefault<int?>()?.ToString(),
                        RepairId =   repair["cirSubmissionData"]?["id"]?.ValueOrDefault<string>(),
                        Steps = steps.ToList()
                    }
                };
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(repair),
                    e);
            }

        }

        private IEnumerable<IRepairStep> ConvertSteps(IList<JObject> steps)
        {
            foreach (var step in steps)
            {
                switch (step["type"].ValueOrDefault<string>())
                {
                    default:
                    break;
                }
            }
            yield break;
        }

     
    }
}
