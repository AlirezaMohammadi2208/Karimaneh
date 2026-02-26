using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Karimaneh.Application
{
    public class JsonStringEnumDisplayConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            foreach (var field in typeof(T).GetFields())
            {
                var display = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                                   .Cast<DisplayAttribute>()
                                   .FirstOrDefault();
                if ((display?.Name ?? field.Name) == str)
                    return (T)field.GetValue(null)!;
            }
            throw new JsonException($"Cannot convert '{str}' to {typeof(T)}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var field = typeof(T).GetField(value.ToString()!)!;
            var display = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                               .Cast<DisplayAttribute>()
                               .FirstOrDefault();
            writer.WriteStringValue(display?.Name ?? value.ToString());
        }
    }
}
