using System.Text.Json.Serialization;

namespace ShortcutManager.Data;

[JsonDerivedType(typeof(ShortcutItem), typeDiscriminator: "Shortcut")]
[JsonDerivedType(typeof(ShortcutFolder), typeDiscriminator: "Folder")]
public interface IShortcutOrFolder
{
    public string? Name { get; }

    public Icon? Icon { get; }
}
