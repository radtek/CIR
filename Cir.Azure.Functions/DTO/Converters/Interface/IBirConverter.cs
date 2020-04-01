using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    interface IBirConverter
    {
        JObject Convert(IList<Repository.Bir> birs);
        JObject Convert(Repository.Bir bir);
    }
}
