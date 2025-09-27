using System.Text.Json.Serialization;
using ShortcutManager.Helpers;

namespace ShortcutManager.Data;

[JsonDerivedType(typeof(ShortcutItem), typeDiscriminator: "Shortcut")]
[JsonDerivedType(typeof(ShortcutFolder), typeDiscriminator: "Folder")]
public interface IShortcutOrFolder
{
    public string? Name { get; }

    [JsonConverter(typeof(JsonIconConverter))]
    public Icon? Icon { get; }
}
