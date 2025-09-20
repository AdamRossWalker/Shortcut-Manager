namespace ShortcutManager;

public sealed class ShortcutFolder : ITreeElement
{
    public string? Name { get; set; }
    
    public Icon? Icon { get; set; }

    public List<ITreeElement> Children { get; } = [];
}
