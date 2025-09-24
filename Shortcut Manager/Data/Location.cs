namespace ShortcutManager.Data;

public readonly struct Location
{
    public required IEnumerable<ChildLocation> Path { get; init; }

    public Location ChildPath => new()
    {
        Path = Path.Skip(1),
    };

    public Location ParentPath => new()
    {
        Path = Path.SkipLast(1),
    };

    public static readonly Location Empty =
        new()
        {
            Path = [],
        };
}
