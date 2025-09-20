using System.Text.Json;

namespace ShortcutManager.Data;

/// <summary>
/// Holds the collection of shortcuts, and manages saving and loading them.
/// </summary>
public sealed class ShortcutData
{
    private static readonly string filename = "ShortcutData.json";

    public static ShortcutData Instance { get; } = new();

    public List<IShortcutOrFolder> Root { get; }

    public ShortcutData()
    {
        try
        {
            Root =
                JsonSerializer.Deserialize<List<IShortcutOrFolder>>(
                    File.ReadAllText(filename))
                ?? [];
        }
        catch (FileNotFoundException)
        {
            Root = [];
        }
    }

    public Task Save() => 
        File.WriteAllTextAsync(
            filename, 
            JsonSerializer.Serialize(Root));
}
