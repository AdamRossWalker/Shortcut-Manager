using System.Text.Json.Serialization;

namespace ShortcutManager;

[JsonDerivedType(typeof(ShortcutItem), typeDiscriminator: "Shortcut")]
[JsonDerivedType(typeof(ShortcutFolder), typeDiscriminator: "Folder")]
public interface IShortcutOrFolder
{
    public string? Name { get; set; }

    public Icon? Icon { get; set; }
}
