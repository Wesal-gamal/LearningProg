using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AttendingLeaving.Erp.API.Infrastructure
{
    //public class NullableTimeSpanConverter : JsonConverter<TimeSpan?>
    //{
    //    public override TimeSpan? Read(
    //        ref Utf8JsonReader reader,
    //        Type typeToConvert,
    //        JsonSerializerOptions options)
    //    {
    //        if (string.IsNullOrEmpty(reader.GetString()))
    //        {
    //            return null;
    //        }
    //        return TimeSpan.ParseExact(reader.GetString(), new string[] { @"hh\:mm\:ss", @"hh\:mm" }, CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(
    //        Utf8JsonWriter writer,
    //        TimeSpan? dateTimeValue,
    //        JsonSerializerOptions options) =>
    //            writer.WriteStringValue(dateTimeValue?.ToString(@"hh\:mm", CultureInfo.InvariantCulture));
    //}

    //public class TimeSpanConverter : JsonConverter<TimeSpan>
    //{
    //    public override TimeSpan Read(
    //        ref Utf8JsonReader reader,
    //        Type typeToConvert,
    //        JsonSerializerOptions options)
    //    {
    //        return TimeSpan.ParseExact(reader.GetString(), new string[] { @"hh\:mm\:ss", @"hh\:mm" }, CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(
    //        Utf8JsonWriter writer,
    //        TimeSpan dateTimeValue,
    //        JsonSerializerOptions options) =>
    //            writer.WriteStringValue(dateTimeValue.ToString(@"hh\:mm", CultureInfo.InvariantCulture));
    //}
}
