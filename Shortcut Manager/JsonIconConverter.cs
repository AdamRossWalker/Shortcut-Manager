using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShortcutManager;

public class JsonIconConverter : JsonConverter<Icon>
{
    public override Icon? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new(new MemoryStream(reader.GetBytesFromBase64()));

    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        using var memoryStream = new MemoryStream();
        value.Save(memoryStream);
        writer.WriteBase64StringValue(memoryStream.ToArray());
    }
}

