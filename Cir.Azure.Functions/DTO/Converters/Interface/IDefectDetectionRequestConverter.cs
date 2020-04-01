using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    interface IDefectDetectionRequestConverter
    {
        CornisDefectDetectionRequest Convert(DefectDetectionRequest request);
    }
}
