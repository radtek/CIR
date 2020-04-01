using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    interface IConverter
    {
        JObject Convert(IList<JObject> input);
        JObject Convert(JObject input);
        string Format { get; }
    }
}
