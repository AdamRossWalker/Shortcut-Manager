using System.Text.Json.Serialization;
using ShortcutManager.Properties;

namespace ShortcutManager.Data;

public sealed record ShortcutFolder : IShortcutOrFolder
{
    public required string? Name { get; init; }

    [JsonConverter(typeof(JsonIconConverter))]
    public Icon? Icon { get; init; } = Resources.Folder;

    public required IEnumerable<IShortcutOrFolder> Children { get; init; }
}
