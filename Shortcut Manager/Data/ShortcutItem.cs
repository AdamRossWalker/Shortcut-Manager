using System.Diagnostics;
using System.Text.Json.Serialization;
using ShortcutManager.Helpers;

namespace ShortcutManager.Data;

public sealed record ShortcutItem : IShortcutOrFolder
{
    public required string? Name { get; init; }

    [JsonConverter(typeof(JsonIconConverter))]
    public required Icon? Icon { get; init; }

    public required string? TargetPath { get; init; }

    public required string? Arguments { get; init; }

    public required string? StartInPath { get; init; }

    public required string? ToolTip { get; init; }

    public ProcessWindowStyle? WindowStyle { get; init; }

    public bool IsUsingShell { get; init; } = true;

    public void Execute()
    {
        if (String.IsNullOrWhiteSpace(TargetPath))
            return;

        Process.Start(new ProcessStartInfo()
        {
            FileName = TargetPath,
            Arguments = Arguments,
            WorkingDirectory = StartInPath,
            WindowStyle = WindowStyle ?? ProcessWindowStyle.Normal,
            UseShellExecute = IsUsingShell,
        });
    }
}
