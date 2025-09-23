using System.Text.Json;

namespace ShortcutManager.Data;

/// <summary>
/// Holds the collection of shortcuts, and manages saving and loading them.
/// </summary>
public sealed class ShortcutData
{
    public const string NewShortcutText = "New Shortcut";
    public const string NewFolderText = "New Folder";

    private static readonly string filename = "ShortcutData.json";

    public static ShortcutData Instance { get; } = new();

    public int DataVersion { get; private set; } = 1;

    private ShortcutFolder root = 
        new()
        {
            Name = "Root",
            Icon = null,
            Children = [],
        };

    public ShortcutFolder Root 
    { 
        get => root;
        private set
        {
            root = value;
            DataVersion++;
        }
    }

    private ShortcutData()
    {
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
        GetItem(Root, location);

    private static IShortcutOrFolder GetItem(
        IShortcutOrFolder parent,
        IEnumerable<(int Index, string Name)> location)
    {
        if (!location.Any())
            return parent;

        if (parent is not ShortcutFolder folder)
            return parent;

        var childCount = folder.Children.Count();

        var childLocation = location.First();
        if (childLocation.Index >= childCount)
            return parent;

        // Make sure the target oldChild lines up with the location.
        var childItem = folder.Children.Skip(childLocation.Index).First();
        if (childItem.Name != childLocation.Name)
            return parent;

        return GetItem(
            childItem,
            location.Skip(1));
    }

    public void AddItem(
        IEnumerable<(int Index, string Name)> location,
        IShortcutOrFolder newItem)
    =>
        CreateNewTree(
            location,
            oldItem =>
            {
                if (oldItem is not ShortcutFolder oldFolder)
                    return oldItem;

                return new ShortcutFolder
                {
                    Name = oldFolder.Name,
                    Icon = oldFolder.Icon,
                    Children = [.. oldFolder.Children, newItem],
                };
            });

    public void ReplaceItem(
        IEnumerable<(int Index, string Name)> location,
        IShortcutOrFolder newItem)
    =>
        CreateNewTree(
            location,
            oldItem => newItem);

    public void DeleteItem(
        IEnumerable<(int Index, string Name)> location)
    =>
        CreateNewTree(
            location,
            oldItem => null);

    private void CreateNewTree(
        IEnumerable<(int Index, string Name)> location,
        Func<IShortcutOrFolder, IShortcutOrFolder?> createNewItemFrom) 
    =>
        Root = (ShortcutFolder)CreateSubTree(
            Root,
            location,
            createNewItemFrom)!;

    private static IShortcutOrFolder? CreateSubTree(
        IShortcutOrFolder oldItem,
        IEnumerable<(int Index, string Name)> location,
        Func<IShortcutOrFolder, IShortcutOrFolder?> createNewItemFrom)
    {
        // If we are at the target leaf node, just make the change.
        if (!location.Any())
            return createNewItemFrom(oldItem);

        // Otherwise, we should be on a folder.
        if (oldItem is not ShortcutFolder oldFolder)
            return oldItem;
        
        var oldChildCount = oldFolder.Children.Count();

        var oldChildLocation = location.FirstOrDefault();
        if (oldChildLocation.Index >= oldChildCount)
            return oldItem;

        // Make sure the target oldChild lines up with the location.
        var oldChildItem = oldFolder.Children.Skip(oldChildLocation.Index).First();
        if (oldChildItem.Name != oldChildLocation.Name)
            return oldItem;

        // We now need a new folder to hold the mutated child.
        // Add one to the new capacity just in case this is an addition operation.
        var newChildren = new List<IShortcutOrFolder>(oldChildCount + 1);

        // Preceding items are unchanged.
        newChildren.AddRange(oldFolder.Children.Take(oldChildLocation.Index));

        var newChildItem = 
            CreateSubTree(
                oldChildItem,
                location.Skip(1),
                createNewItemFrom);

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
