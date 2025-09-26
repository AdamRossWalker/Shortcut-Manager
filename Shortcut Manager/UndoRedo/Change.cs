using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;

public record Change
{
    public required string Name { get; init; }

    public required string? Description { get; init; }

    public bool IsMergable { get; init; } = false;

    public IShortcutOrFolder? OldItem { get; init; }

    public IShortcutOrFolder? NewItem { get; init; }
}
