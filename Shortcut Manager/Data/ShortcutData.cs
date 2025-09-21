using System.Text.Json;

namespace ShortcutManager.Data;

/// <summary>
/// Holds the collection of shortcuts, and manages saving and loading them.
/// </summary>
public sealed class ShortcutData
{
    private static readonly string filename = "ShortcutData.json";

    public static ShortcutData Instance { get; } = new();

    public ShortcutFolder Root { get; private set; }

    public ShortcutData()
    {
        Root = 
            new ShortcutFolder
            {
                Name = "Root",
                Icon = null,
                Children = [],
            };

        try
        {
            Root =
                JsonSerializer.Deserialize<ShortcutFolder>(
                    File.ReadAllText(filename)) 
                ?? Root;
        }
        catch (FileNotFoundException) { }
    }

    public Task Save() => 
        File.WriteAllTextAsync(
            filename, 
            JsonSerializer.Serialize(Root));

    public IShortcutOrFolder GetItem(
        IEnumerable<(int Index, string Name)> location)
    =>
        GetItem(location, Root);

    private static IShortcutOrFolder GetItem(
        IEnumerable<(int Index, string Name)> location,
        IShortcutOrFolder parent)
    {
        if (!location.Any())
            return parent;

        if (parent is not ShortcutFolder folder)
        { 
            return parent;
        }

        var childCount = folder.Children.Count();

        var childLocation = location.First();
        if (childLocation.Index >= childCount)
        {
            return parent;
        }

        // Make sure the target oldChild lines up with the location.
        var childItem = folder.Children.Skip(childLocation.Index).First();
        if (childItem.Name != childLocation.Name)
        {
            return parent;
        }

        return GetItem(
            location.Skip(1),
            childItem);
    }

    public void AddItem(
        IEnumerable<(int Index, string Name)> location,
        IShortcutOrFolder newItem)
    =>
        Root =
            (ShortcutFolder)MutateTree(
                Root,
                location,
                parent =>
                {
                    if (parent is ShortcutFolder parentFolder)
                    {
                        return new ShortcutFolder
                        {
                            Name = parentFolder.Name,
                            Icon = parentFolder.Icon,
                            Children = [.. parentFolder.Children, newItem],
                        };
                    }

                    return parent;
                })!;

    public void ReplaceItem(
        IEnumerable<(int Index, string Name)> location,
        IShortcutOrFolder newItem)
    =>
        Root =
            (ShortcutFolder)MutateTree(
                Root,
                location,
                oldItem => newItem)!;

    public void DeleteItem(
        IEnumerable<(int Index, string Name)> location)
    =>
        Root =
            (ShortcutFolder)MutateTree(
                Root,
                location,
                oldItem => null)!;

    private static IShortcutOrFolder? MutateTree(
        IShortcutOrFolder oldItem,
        IEnumerable<(int Index, string Name)> location,
        Func<IShortcutOrFolder, IShortcutOrFolder?> mutation)
    {
        // If we are at the target leaf node, just make the change.
        if (!location.Any())
        {
            return mutation(oldItem);
        }

        // Otherwise, we should be on a folder.
        if (oldItem is not ShortcutFolder oldFolder)
        {
            return oldItem;
        }
        
        var oldChildCount = oldFolder.Children.Count();

        var oldChildLocation = location.FirstOrDefault();
        if (oldChildLocation.Index >= oldChildCount)
        {
            return oldItem;
        }

        // Make sure the target oldChild lines up with the location.
        var oldChildItem = oldFolder.Children.Skip(oldChildLocation.Index).First();
        if (oldChildItem.Name != oldChildLocation.Name)
        {
            return oldItem;
        }

        // We now need a new folder to hold the mutated child.
        // Add one to the new capacity just in case this is an addition operation.
        var newChildren = new List<IShortcutOrFolder>(oldChildCount + 1);

        // Preceding items are unchanged.
        newChildren.AddRange(oldFolder.Children.Take(oldChildLocation.Index));

        var newChildItem = 
            MutateTree(
                oldChildItem,
                location.Skip(1),
                mutation);

        if (newChildItem is not null)
            newChildren.Add(newChildItem);

        // Folowing items are unchanged.
        newChildren.AddRange(oldFolder.Children.Skip(oldChildLocation.Index + 1));

        return new ShortcutFolder
        {
            Name = oldFolder.Name,
            Icon = oldFolder.Icon,
            Children = newChildren,
        };
    }
}
