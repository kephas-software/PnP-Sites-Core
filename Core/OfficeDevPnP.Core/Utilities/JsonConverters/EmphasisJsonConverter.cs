﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.Core.Utilities.JsonConverters
{
    public class EmphasisJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (true);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object initialValue = reader.Value;
            Int32 result = 0;
            
            if (initialValue != null)
            {
                var stringValue = initialValue.ToString();
                if (!String.IsNullOrEmpty(stringValue) &&
                    stringValue.Equals("undefined", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = 0;
                }
                else if (!Int32.TryParse(stringValue, out result))
                {
                    result = 0;
                }
            }

            return (result);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
