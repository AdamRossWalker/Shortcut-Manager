namespace ShortcutManager.Data;

public sealed class ShortcutFolder : IShortcutOrFolder
{
    public string? Name { get; set; }
    
    public Icon? Icon { get; set; }

    public List<IShortcutOrFolder> Children { get; } = [];
}
