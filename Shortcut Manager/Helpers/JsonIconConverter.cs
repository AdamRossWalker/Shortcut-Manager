using System.Drawing.Imaging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShortcutManager.Helpers;

public class JsonIconConverter : JsonConverter<Icon>
{
    public override Icon? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var stream = new MemoryStream(reader.GetBytesFromBase64());
        using var bitmap = new Bitmap(stream);
        return bitmap.ToIcon();
    }

    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        // Specify PNG explicitly here.
        // Saving as an Icon directly or a BMP causes palette issues for some reason.
        using var bitmap = value.ToBitmap();
        using var memoryStream = new MemoryStream();
        bitmap.Save(memoryStream, ImageFormat.Png);
        writer.WriteBase64StringValue(memoryStream.ToArray());
    }
}

