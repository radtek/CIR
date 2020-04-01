using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Data.Access.Models
{
    public class UserData
    {
        public string TableName { get; set; }

        public IList<object> DataList { get; set; }
    }
}
