using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Azure.Functions
{
    class DefectDetectionRequestConverter: IDefectDetectionRequestConverter
    {
        public CornisDefectDetectionRequest Convert(DefectDetectionRequest request)
        {
            if (request == null)
                throw new NullReferenceException("request");

            try
            {
                return new CornisDefectDetectionRequest()
                {
                    TurbineId = request.TurbineId.ToString(),
                    CirId = request.CirGuid,
                    Images = ConvertImages(request.Images).ToList(),
                    SpecVersion = "vestas_0.0.3",
                    Options = new CDDOptions
                    {
                        Dev = new CDDDev
                        {
                            Name = "bco-tests"
                        }
                    }
                };
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(request),
                    e);
            }
        }

        private IEnumerable<CDDImage> ConvertImages(List<DDImage> images)
        {
            foreach (var image in images)
            {
                yield return new CDDImage
                {
                    Path = image.Path
                };
            }
        }
    }
}
