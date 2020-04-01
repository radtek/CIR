using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Repository;
using Newtonsoft.Json.Linq;

namespace Cir.Azure.Functions
{
    class BrrConverter : IBrrConverter
    {
        public RepairBrrDto Convert(IList<JObject> brrs)
        {
            if (brrs == null)
                throw new ArgumentNullException("brrs");

            try
            {
                return new RepairBrrDto
                {
                    Brrs = ConvertBrrs(brrs).ToList()
                };
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(brrs),
                    e);
            }
        }

        private IEnumerable<RepairBrr> ConvertBrrs(IList<JObject> brrs)
        {
            foreach (var brr in brrs)
            {
                yield return new RepairBrr
                {
                    RepairId = brr["repairId"]?.ValueOrDefault<string>(),
                    Filename = brr["filename"]?.ValueOrDefault<string>(),
                    BrrDataString = brr["brrDataString"]?.ValueOrDefault<string>()
                };
            }
        }
    }
}
