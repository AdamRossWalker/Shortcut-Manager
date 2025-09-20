using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ShortcutManager;

/// <summary>
/// Holds the collection of shortcuts, and manages saving and loading them.
/// </summary>
public sealed class Shortcuts
{
    private static readonly string filename = "Shortcuts.json";

    public static Shortcuts Instance { get; } = new();

    public List<ITreeElement> TreeElements { get; }

    public Shortcuts()
    {
        try
        {
            TreeElements =
                JsonSerializer.Deserialize<List<ITreeElement>>(
                    File.ReadAllText(filename))
                ?? [];
        }
        catch (FileNotFoundException)
        {
            TreeElements = [];
        }
    }

    public Task Save() => 
        File.WriteAllTextAsync(
            filename, 
            JsonSerializer.Serialize(TreeElements));
}
