using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MEMAnalyzer_Backend.Helpers
{
    public class DateTimeConverter : JsonConverter<DateTimeOffset>
    {
        private const string DateFormat = "dd.MM.yyyy";

        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string date = reader.GetString();
            if (date[2] != '.')
                date = date.Insert(0,"0");
            if (date[5] != '.')
                date = date.Insert(3, "0");
            return DateTimeOffset.ParseExact(date, DateFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset value,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
