using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class BirConverter : IBirConverter
    {
        public JObject Convert(IList<Repository.Bir> birs)
        {
            if (birs == null)
                throw new ArgumentNullException("birs");

            try
            {
                var result = new BirListDto
                {
                    Data = ConvertData(birs).ToList()
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(birs),
                    e);
            }
        }

        public JObject Convert(Repository.Bir bir)
        {
            if (bir == null)
                throw new ArgumentNullException("bir");

            try
            {
                var result = new BirSingleDto
                {
                    Data = ConvertData(bir)
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(bir),
                    e);
            }
        }

        private IEnumerable<Bir> ConvertData(IList<Repository.Bir> birs)
        {
            foreach (var bir in birs)
            {
                yield return ConvertData(bir);
            }
        }

        private Bir ConvertData(Repository.Bir bir)
        {
            return new Bir
            {
                BirDataString = bir.Content,
                Filename = bir.Filename,
                IsAnnual = bir.IsAnnual,
                LastModified = bir.LastModified,
                TurbineId = bir.TurbineId,
                BirGuid = bir.BirGuid,
                RelatedCirs = bir.RelatedCirs?.ToList()
            };
        }
    }
}
