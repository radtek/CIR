using Cir.Azure.Functions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class AIDamagesForCirConverter : IAIDamagesForCirConverter
    {
        public AIDamagesForCir Convert(AIDamages aiDamages)
        {
            if (aiDamages == null)
            {
                throw new ArgumentNullException("aIDamages");
            }
            try
            {
                return new AIDamagesForCir
                {
                    Images = aiImagesToImages(aiDamages.OutputBody.Images).ToList()
                };
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(aiDamages),
                    e);
            }
        }

        public IEnumerable<AiDamagesForCirImage> aiImagesToImages(IList<AiDamagesImage> aiImages)
        {
            foreach (var aiImage in aiImages)
            {
                if (aiImage.Defects != null)
                {
                    yield return new AiDamagesForCirImage
                    {
                        Path = aiImage.Path,
                        DamageSeverity = aiImage.Defects?.FirstOrDefault()?.Qualification?.FirstOrDefault()?.DamageLevel,
                        DamagePlacement = aiImage.Defects?.FirstOrDefault()?.Qualification?.FirstOrDefault()?.DamageCategory,
                        Radius = aiImage.Defects?.FirstOrDefault()?.HubDistanceCm * 100,
                        BoundingBox = aiImage.Defects?.FirstOrDefault()?.Geometry?.BoundingBox,
                        Side = aiImage.Metadata?.Side,
                        Confidence = aiImage.Defects?.FirstOrDefault()?.Confidence
                    };
                }
            }
        }
    }
}
