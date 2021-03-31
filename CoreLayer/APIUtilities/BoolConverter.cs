using System;

namespace AttendingLeaving.Erp.Core.APIUtilities
{
    //public class BoolConverter : JsonConverter<bool>
    //{
    //    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (string.IsNullOrEmpty(reader.GetString()))
    //            {
    //                return false;
    //            }
    //            return bool.Parse(reader.GetString());
    //        }
    //        else if (reader.TokenType == JsonTokenType.Null)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return reader.GetBoolean();
    //        }
    //    }

    //    public override void Write(Utf8JsonWriter writer, bool boolValue, JsonSerializerOptions options)
    //    {
    //        writer.WriteBooleanValue(boolValue);
    //    }

    //}

    //public class NullableBoolConverter : JsonConverter<bool?>
    //{
    //    public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (string.IsNullOrEmpty(reader.GetString()))
    //            {
    //                return null;
    //            }
    //            return bool.Parse(reader.GetString());
    //        }
    //        else if (reader.TokenType == JsonTokenType.Null)
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            return reader.GetBoolean();
    //        }
    //    }

    //    public override void Write(Utf8JsonWriter writer, bool? dateTimeValue, JsonSerializerOptions options)
    //    {
    //        writer.WriteBooleanValue(dateTimeValue ?? false);
    //    }
    //}
}
