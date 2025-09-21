namespace ShortcutManager.Data;

public sealed record ShortcutFolder : IShortcutOrFolder
{
    public required string? Name { get; init; }
    
    public required Icon? Icon { get; init; }

    public required IEnumerable<IShortcutOrFolder> Children { get; init; }
}
