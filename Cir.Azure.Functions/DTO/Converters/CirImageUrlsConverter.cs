using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirImageUrlsConverter: IConverter
    {
        public string Format => "images";

        public JObject Convert(IList<JObject> cirs)
        {
            if (cirs == null)
                throw new ArgumentNullException("cirs");

            try
            {
                var convertedCirs = ConvertData(cirs);
                var result = new CirImageUrlsListDto
                {
                    Data = convertedCirs.ToList()
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
                var convertedCir = ConvertData(cir);
                if (convertedCir == null)
                {
                    return null;
                }
                var result = new CirImageUrlsSingleDto
                {
                    Data = convertedCir
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

        private IEnumerable<CirImageUrlsData> ConvertData(IList<JObject> cirs)
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

        private CirImageUrlsData ConvertData(JObject cir)
        {
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Removed")
            {
                return null;
            }
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Rejected")
            {
                return null;
            }

            var images = ConvertImages((JArray)cir["cirSubmissionData"]?["imageReferences"]);
            return new CirImageUrlsData
            {
                CirId = cir["cirSubmissionData"]?["cirId"]?.ValueOrDefault<int?>(),
                CirGuid = cir["cirSubmissionData"]?["id"]?.ValueOrDefault<string>(),
                TurbineId = cir["cirSubmissionData"]?["data"]?["txtTurbineNumber"]?.ValueOrDefault<int?>(),
                ImageUrls = images.ToList()
            };
        }

        private IEnumerable<CirImageUrl> ConvertImages(JArray images)
        {
            if (images == null)
            {
                yield break;
            }
            foreach (var image in images)
            {
                yield return new CirImageUrl
                {
                    Id = image["imageId"]?.ValueOrDefault<string>(),
                    Url = image["url"]?.ValueOrDefault<string>()
                };
            }
        }
    }
}
