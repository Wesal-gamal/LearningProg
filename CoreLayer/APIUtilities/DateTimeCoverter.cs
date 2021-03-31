using System;
using System.Globalization;


namespace AttendingLeaving.Erp.Core.APIUtilities
{
    //public class DateTimeConverter : JsonConverter<DateTime>
    //{
    //    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        return DateTime.Parse(reader.GetString());
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(dateTimeValue.ToString(@"yyyy'-'MM'-'dd", CultureInfo.InvariantCulture));
    //    }
    //}

    //public class NullableDateTimeConverter : JsonConverter<DateTime?>
    //{
    //    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (string.IsNullOrEmpty(reader.GetString()))
    //        {
    //            return null;
    //        }
    //        return DateTime.Parse(reader.GetString());
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateTime? dateTimeValue, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(dateTimeValue?.ToString(@"yyyy'-'MM'-'dd", CultureInfo.InvariantCulture));
    //    }
    //}
}
