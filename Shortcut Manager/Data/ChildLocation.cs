namespace ShortcutManager.Data;

public readonly record struct ChildLocation
{
    public required int Index { get; init; }

    public required string? Name { get; init; }
}
