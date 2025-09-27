using System.Text.Json;
using ShortcutManager.UndoRedo;

namespace ShortcutManager.Data;

/// <summary>
/// Holds the collection of shortcuts, and manages saving and loading them.
/// </summary>
public sealed class ShortcutData : IShortcutData
{
    private readonly IUndoRedoManager undoRedoManager;
    public const string NewShortcutText = "New Shortcut";
    public const string NewFolderText = "New Folder";

    private static readonly string filename = "ShortcutData.json";

    public int DataVersion { get; private set; } = 1;

    private ShortcutFolder root =
        new()
        {
            Name = "Root",
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

    public ShortcutData(
        IUndoRedoManager undoRedoManager)
    {
        this.undoRedoManager = undoRedoManager;
        var firstUndoRedoFrameDescription = "No Shortcuts";

        try
        {
            Root =
                JsonSerializer.Deserialize<ShortcutFolder>(
                    File.ReadAllText(filename))
                ?? Root;

            firstUndoRedoFrameDescription = "Shortcuts Loaded";
        }
        catch (FileNotFoundException) { }

        undoRedoManager.AddFrame(
            new()
            {
                Name = firstUndoRedoFrameDescription,
                Description = null,
            },
            Root);
        undoRedoManager.ApplyNewShortcutTree +=
            newRoot => Root = newRoot;
    }

    public Task Save() =>
        File.WriteAllTextAsync(
            filename,
            JsonSerializer.Serialize(Root));

    public IShortcutOrFolder GetItem(
        Location location)
    {
        static IShortcutOrFolder GetNextLevelIn(
            IShortcutOrFolder parent,
            Location location)
        {
            if (!location.Path.Any())
                return parent;

            if (parent is not ShortcutFolder folder)
                return parent;

            var childCount = folder.Children.Count();

            var childLocation = location.Path.First();
            if (childLocation.Index >= childCount)
                return parent;

            // Make sure the target oldChild lines up with the location.
            var childItem = folder.Children.Skip(childLocation.Index).First();
            if (childItem.Name != childLocation.Name)
                return parent;

            return GetNextLevelIn(
                childItem,
                location.ChildPath);
        }

        return GetNextLevelIn(Root, location);
    }

    public Location GetLocation(IShortcutOrFolder item, ShortcutFolder? root = null)
    {
        bool GetLocation(
            ShortcutFolder parent,
            List<ChildLocation> reversedPath)
        {
            foreach (var (child, index) in parent.Children.Select((child, index) => (child, index)))
            {
                if (ReferenceEquals(child, item) ||
                    (child is ShortcutFolder folder && GetLocation(folder, reversedPath)))
                {
                    reversedPath.Add(new()
                    {
                        Index = index,
                        Name = child.Name,
                    });

                    return true;
                }
            }

            return false;
        }

        var reversedPath = new List<ChildLocation>();
        GetLocation(root ?? Root, reversedPath);

        return new()
        {
            Path = [.. Enumerable.Reverse(reversedPath)],
        };
    }

    public void AddItem(
        Location location,
        IShortcutOrFolder newItem)
    =>
        ApplyNewTree(
            new Change()
            {
                Name = "Add",
                Description = null,
            },
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
                }));

    public void ReplaceItem(
        Location location,
        string fieldName,
        IShortcutOrFolder oldItem,
        IShortcutOrFolder newItem)
    =>
        ApplyNewTree(
            new Change()
            {
                Name = "Edited " + fieldName,
                Description = null,
                IsMergable = true,
                OldItem = oldItem,
                NewItem = newItem,
            },
            CreateNewTree(
                location,
                oldItem => newItem));

    public void DeleteItem(
        Location location)
    =>
        ApplyNewTree(
            new Change()
            {
                Name = "Delete",
                Description = null
            },
            CreateNewTree(
                location,
                oldItem => null));

    public Location MoveItem(
        Location sourceLocation,
        Location targetLocation)
    {
        if (!sourceLocation.Path.Any() ||
            !targetLocation.Path.Any())
            return sourceLocation;

        if (Enumerable.SequenceEqual(
            sourceLocation.ParentPath.Path,
            targetLocation.ParentPath.Path) &&
            sourceLocation.Path.Last().Index + 1 ==
            targetLocation.Path.Last().Index)
            return sourceLocation;

        var movedItem = GetItem(sourceLocation);
        var targetItem = GetItem(targetLocation);

        if (ReferenceEquals(movedItem, targetItem))
            return sourceLocation;

        var targetAsFolder = targetItem as ShortcutFolder;
        var isTargetAFolder = targetAsFolder is not null;

        var tempTree =
            CreateNewTree(
                sourceLocation,
                oldItem => null);

        // After the above delete, the target location may have now changed.
        var adjustedTargetLocation = GetLocation(targetItem, tempTree);
        if (!adjustedTargetLocation.Path.Any())
            return sourceLocation;

        var newIndex =
            targetAsFolder?.Children.Count()
            ?? adjustedTargetLocation.Path.Last().Index;

        tempTree =
            CreateNewTree(
                isTargetAFolder
                    ? adjustedTargetLocation
                    : adjustedTargetLocation.ParentPath,
                oldItem =>
                {
                    if (oldItem is not ShortcutFolder oldFolder)
                        return oldItem;

                    return new ShortcutFolder
                    {
                        Name = oldFolder.Name,
                        Icon = oldFolder.Icon,
                        Children =
                        [
                            ..oldFolder.Children.Take(newIndex),
                            movedItem,
                            ..oldFolder.Children.Skip(newIndex),
                        ],
                    };
                },
                tempTree);

        ApplyNewTree(
            new Change()
            {
                Name = "Move",
                Description =
                    String.Join('\\', sourceLocation.Path.Select(l => l.Name)) +
                    " (" +
                    sourceLocation.Path.Last().Index +
                    ")" +
                    " → " +
                    String.Join('\\', adjustedTargetLocation.Path.Select(l => l.Name)) +
                    " (" +
                    adjustedTargetLocation.Path.Last().Index +
                    ")",
            },
            tempTree);

        return GetLocation(movedItem);
    }

    private void ApplyNewTree(Change change, ShortcutFolder newTree) =>
        undoRedoManager.AddFrame(change, newTree);

    private ShortcutFolder CreateNewTree(
        Location location,
        Func<IShortcutOrFolder, IShortcutOrFolder?> createNewItemFrom,
        ShortcutFolder? oldRoot = null)
    {
        static IShortcutOrFolder? CreateSubTree(
            IShortcutOrFolder oldItem,
            Location location,
            Func<IShortcutOrFolder, IShortcutOrFolder?> createNewItemFrom)
        {
            // If we are at the target leaf node, just make the change.
            if (!location.Path.Any())
                return createNewItemFrom(oldItem);

            // Otherwise, we should be on a folder.
            if (oldItem is not ShortcutFolder oldFolder)
                return oldItem;

            var oldChildCount = oldFolder.Children.Count();

            var oldChildLocation = location.Path.FirstOrDefault();
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
                    location.ChildPath,
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

        return (ShortcutFolder)CreateSubTree(
            oldRoot ?? Root,
            location,
            createNewItemFrom)!;
    }
}
