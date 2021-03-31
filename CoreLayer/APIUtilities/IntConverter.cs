using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AttendingLeaving.Erp.Core.APIUtilities
{
    //public class NullableIntConverter : JsonConverter<int?>
    //{
    //    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (string.IsNullOrEmpty(reader.GetString()))
    //            {
    //                return null;
    //            }
    //            return int.Parse(reader.GetString());
    //        }
    //        else if (reader.TokenType == JsonTokenType.Null)
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            return reader.GetInt32();
    //        }
    //    }

    //    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    //    {
    //        writer.WriteNumberValue(value == null ? 0 : (int)value);
    //    }
    //}
    //public class IntConverter : JsonConverter<int>
    //{
    //    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (string.IsNullOrEmpty(reader.GetString()))
    //            {
    //                return 0;
    //            }
    //            return int.Parse(reader.GetString());
    //        }
    //        else if (reader.TokenType == JsonTokenType.Null)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            return reader.GetInt32();
    //        }
    //    }

    //    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    //    {
    //        writer.WriteNumberValue(value);
    //    }
    //}
}
