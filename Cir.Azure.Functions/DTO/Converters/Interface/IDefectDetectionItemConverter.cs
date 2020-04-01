using Cir.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    interface IDefectDetectionItemConverter
    {
        DefectDetectionItem Convert(CornisDefectDetectionRequest request, CornisDefectDetectionResponse response);
    }
}
