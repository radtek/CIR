using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.CirSyncJob
{
    class CirJsonDateTimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
           JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value.ToString()))
            {
                return new DateTime();
            }
            else
            {
                DateTime dt;
                string[] dtformat = new string[4];
                dtformat[0] = "dd-MM-yyyy";
                dtformat[1] = "yyyy-MM-dd";
                dtformat[2] = "dd/MM/yyyy";
                dtformat[3] = "yyyy/MM/dd";
                if (DateTime.TryParseExact(reader.Value.ToString(), dtformat, base.Culture, DateTimeStyles.None, out dt))
                {
                    return dt;
                }
                else
                    return new DateTime();
                //base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime && (DateTime)value == DateTime.MinValue)
            {
                value = "";
                serializer.Serialize(writer, value);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}
