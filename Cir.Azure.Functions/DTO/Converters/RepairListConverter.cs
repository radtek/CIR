using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class RepairListConverter: IRepairListConverter
    {
        public RepairListDto Convert(IList<JObject> repairs)
        {
            if (repairs == null)
                throw new ArgumentNullException("repairs");

            try
            {
                return new RepairListDto
                {
                    Repairs = ConvertRepairs(repairs).ToList()
                };
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(repairs),
                    e);
            }
        }

        private IEnumerable<Repair> ConvertRepairs(IList<JObject> repairs)
        {
            foreach (var repair in repairs)
            {
                yield return new Repair
                {
                    BladeId = repair["cirSubmissionData"]?["data"]?["txtBladeSerialNumber"]?.ValueOrDefault<string>(),
                    DamageGuid = repair["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["damageGuid"]?.ValueOrDefault<string>(),
                    DamageId =   repair["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["damageId"]?.ValueOrDefault<string>(),
                    Date =       repair["cirSubmissionData"]?["data"]?["dtInspectionDate"]?.ValueOrDefault<string>(),
                    RepairId =   repair["cirSubmissionData"]?["id"]?.ValueOrDefault<string>(),
                    TurbineId =  repair["cirSubmissionData"]?["data"]?["txtTurbineNumber"]?.ValueOrDefault<string>()
                };
            }
        }
        
    }
}
