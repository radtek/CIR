using Cir.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Azure.Functions
{
    class DefectDetectionItemConverter: IDefectDetectionItemConverter
    {
        public DefectDetectionItem Convert(CornisDefectDetectionRequest request, CornisDefectDetectionResponse response)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            if (response == null)
                throw new ArgumentNullException("response");
            if (request.CirId != response.CirId)
                throw new ArgumentException($"Cir id from request ('{request.CirId}')and response ('{response.CirId}') does not match.");
            if (request.TurbineId != response.TurbineId)
                throw new ArgumentException($"Turbine id from request ('{request.TurbineId}')and response ('{response.TurbineId}') does not match.");

            var result = new DefectDetectionItem
            {
                Id = response.Id,
                CirId = response.CirId,
                TurbineId = response.TurbineId,
                EstimatedDeliveryDate = response.EstimatedDeliveryDate,
                WorkflowId = response.WorkflowId,
                Images = request.Images.Select(i => new Repository.Image { Path = i.Path }).ToList(),
                SpecVersion = request.SpecVersion,
            };

            if (request.Options != null)
            {
                result.Options = new Options();
                if (request.Options.Dev != null)
                {
                    result.Options.Dev = new Dev
                    {
                        Name = request.Options.Dev.Name
                    };
                    
                }
            }

            return result;
        }
    }
}
