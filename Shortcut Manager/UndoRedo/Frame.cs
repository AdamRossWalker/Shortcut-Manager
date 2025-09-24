using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;

public sealed record Frame
{
    public required string Name { get; init; }

    public required int Index{ get; init; }

    public required ShortcutFolder Root { get; init; }
}
