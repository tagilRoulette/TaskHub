using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Converters
{
    public class StringToGuidConverter : JsonConverter<Guid>
    {
        public override Guid Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string guidString = reader.GetString();
            Guid.TryParse(guidString, out Guid result);
            return result;
        }

        public override void Write(
            Utf8JsonWriter writer,
            Guid value,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
