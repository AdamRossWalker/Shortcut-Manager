using System.Text.Json.Serialization;

namespace ShortcutManager;

[JsonDerivedType(typeof(Shortcut), typeDiscriminator: "Shortcut")]
[JsonDerivedType(typeof(ShortcutFolder), typeDiscriminator: "Folder")]
public interface ITreeElement
{
    public string? Name { get; set; }

    public Icon? Icon { get; set; }
}
