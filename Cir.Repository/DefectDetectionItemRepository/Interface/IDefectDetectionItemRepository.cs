using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public interface IDefectDetectionItemRepository
    {
        Task SetAsync(DefectDetectionItem item);
        DefectDetectionItem Get(string id);

        Task DeleteAsync(string id);
    }
}
