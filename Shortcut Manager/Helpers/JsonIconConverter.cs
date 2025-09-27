using System.Drawing.Imaging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShortcutManager.Helpers;

public class JsonIconConverter : JsonConverter<Icon>
{
    public override Icon? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new Bitmap(new MemoryStream(reader.GetBytesFromBase64())).ToIcon();

    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        // Specify PNG explicitly here.
        // Saving as an Icon directly or a BMP causes palette issues for some reason.
        using var memoryStream = new MemoryStream();
        value.ToBitmap().Save(memoryStream, ImageFormat.Png);
        writer.WriteBase64StringValue(memoryStream.ToArray());
    }
}

