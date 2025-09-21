using System.Text.Json.Serialization;

namespace ShortcutManager.Data;

[JsonDerivedType(typeof(ShortcutItem), typeDiscriminator: "Shortcut")]
[JsonDerivedType(typeof(ShortcutFolder), typeDiscriminator: "Folder")]
public interface IShortcutOrFolder : ICloneable
{
    public string? Name { get; set; }

    public Icon? Icon { get; set; }

    public new IShortcutOrFolder Clone();

    object ICloneable.Clone() => Clone();
}
