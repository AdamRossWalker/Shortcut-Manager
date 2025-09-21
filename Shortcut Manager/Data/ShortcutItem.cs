namespace ShortcutManager.Data;

public sealed class ShortcutItem : IShortcutOrFolder
{
    public string? Name { get; set; }

    public Icon? Icon { get; set; }

    public string? TargetPath { get; set; }

    public string? Arguments { get; set; }

    public string? StartInPath { get; set; }

    public string? ToolTip { get; set; }

    public IShortcutOrFolder Clone() => new ShortcutItem()
    {
        Name = Name,
        Icon = Icon,
        TargetPath = TargetPath,
        Arguments = Arguments,
        StartInPath = StartInPath,
        ToolTip = ToolTip,
    };
}
