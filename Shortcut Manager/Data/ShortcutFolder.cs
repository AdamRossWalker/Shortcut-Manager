using System.Text.Json.Serialization;

namespace ShortcutManager.Data;

public sealed record ShortcutFolder : IShortcutOrFolder
{
    public required string? Name { get; init; }

    [JsonConverter(typeof(JsonIconConverter))]
    public required Icon? Icon { get; init; }

    public required IEnumerable<IShortcutOrFolder> Children { get; init; }
}
