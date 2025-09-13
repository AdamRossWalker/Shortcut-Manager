namespace ShortcutManager;

public sealed class Shortcut
{
    public string? Name { get; set; }

    public string? TargetPath { get; set; }

    public string? Arguments { get; set; }

    public string? StartInPath { get; set; }

    public Icon? Icon { get; set; }
}
