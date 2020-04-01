using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirIdConverter : IConverter
    {
        public string Format => "ids";

        public JObject Convert(IList<JObject> cirs)
        {
            if (cirs == null)
                throw new ArgumentNullException("cirs");

            try
            {
                var result = new CirIdListDto
                {
                    Data = ConvertData(cirs).ToList()
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(cirs),
                    e);
            }
        }

        public JObject Convert(JObject cir)
        {
            if (cir == null)
                throw new ArgumentNullException("cir");

            try
            {
                var data = ConvertData(cir);
                if (data == null)
                {
                    return null;
                }
                var result = new CirIdSingleDto
                {
                    Data = data
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(cir),
                    e);
            }
        }



        private IEnumerable<CirIdData> ConvertData(IList<JObject> cirs)
        {
            foreach (var cir in cirs)
            {
                var result = ConvertData(cir);
                if (result != null)
                {
                    yield return result;
                }
            }
        }

        private CirIdData ConvertData(JObject cir)
        {
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Removed")
            {
                return null;
            }
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Rejected")
            {
                return null;
            }

            return new CirIdData
            {
                CirId = cir["cirSubmissionData"]?["cirId"]?.ValueOrDefault<int?>(),
                CirGuid = cir["cirSubmissionData"]?["id"]?.ValueOrDefault<string>(),
                TurbineId = cir["cirSubmissionData"]?["data"]?["txtTurbineNumber"]?.ValueOrDefault<int?>()
            };
        }

    }
}
