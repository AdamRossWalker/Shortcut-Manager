namespace ShortcutManager.Data;

public sealed class ShortcutFolder : IShortcutOrFolder
{
    public string? Name { get; set; }
    
    public Icon? Icon { get; set; }

    public List<IShortcutOrFolder> Children { get; private set; } = [];

    public IShortcutOrFolder Clone() => new ShortcutFolder()
    {
        Name = Name,
        Icon = Icon,
        Children = [.. Children.Select(c => c.Clone())],
    };
}
