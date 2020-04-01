using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class CirCommentHistorys
    {
        public long CirCommentHistoryId { get; set; }
        public long CirDataId { get; set; }
        public string Comment { get; set; }
        public System.DateTime Date { get; set; }
        public string Initials { get; set; }
        public byte Type { get; set; }

    }
}
