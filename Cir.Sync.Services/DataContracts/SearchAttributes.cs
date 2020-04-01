using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class SearchAttributes
    {
        public int SortColumnIndex { get; set; }
        public int SortDirection { get; set; }
        public int CurrentPageNumber { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
