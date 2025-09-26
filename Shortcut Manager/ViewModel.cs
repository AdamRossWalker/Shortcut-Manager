using ShortcutManager.Data;
using ShortcutManager.UndoRedo;

namespace ShortcutManager;

public sealed class ViewModel : ObservableObject
{
    private Location selectedNodeLocation = Location.Empty;
    private IShortcutOrFolder? currentItem;

    public ViewModel() =>
        UndoRedoManager.Instance.UndoRedoStateChanged += 
            (canUndo, canRedo) =>
            {
                CanUndo = canUndo;
                CanRedo = canRedo;
            };

    public void SetCurrentItem(
        Location selectedNodeLocation,
        IShortcutOrFolder? currentItem)
    {
        this.selectedNodeLocation = selectedNodeLocation;
        this.currentItem = currentItem;

        if (currentItem is null)
            return;

        ShortcutName = currentItem.Name;
        ShortcutIcon = currentItem.Icon;

        if (currentItem is not ShortcutItem shortcut)
            return;

        TargetPath = shortcut.TargetPath;
        Arguments = shortcut.Arguments;
        StartInPath = shortcut.StartInPath;
        ToolTip = shortcut.ToolTip;
    }

    public IShortcutOrFolder? CurrentItem
    {
        get => currentItem;
        set => SetField(ref currentItem, value);
    }

    public Location SelectedNodeLocation
    {
        get => selectedNodeLocation;
        set => SetField(ref selectedNodeLocation, value);
    }

    private string? shortcutName;
    public string? ShortcutName
    {
        get => shortcutName;
        set
        {
            if (!SetFieldWithoutNotification(ref shortcutName, value))
                return;

            if (CurrentItem is not null && CurrentItem.Name != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = CurrentItem switch
                {
                    ShortcutFolder folder => folder with { Name = value },
                    ShortcutItem shortcut => shortcut with { Name = value },
                    _ => CurrentItem,
                };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Name",
                    oldItem,
                    CurrentItem);
            }

            RaisePropertyChanged();
        }
    }

    private Icon? shortcutIcon;
    public Icon? ShortcutIcon
    {
        get => shortcutIcon;
        set
        {
            if (!SetFieldWithoutNotification(ref shortcutIcon, value))
                return;

            if (CurrentItem is not null && CurrentItem.Icon != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = CurrentItem switch
                {
                    ShortcutFolder folder => folder with { Icon = value },
                    ShortcutItem shortcut => shortcut with { Icon = value },
                    _ => CurrentItem,
                };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Icon",
                    oldItem,
                    CurrentItem);
            }

            SetField(ref shortcutBitmap, shortcutIcon?.ToBitmap(), nameof(ShortcutBitmap));
            RaisePropertyChanged();
        }
    }

    private Bitmap? shortcutBitmap;
    public Bitmap? ShortcutBitmap => shortcutBitmap;

    private string? targetPath;
    public string? TargetPath
    {
        get => targetPath;
        set
        {
            var oldTargetPath = targetPath;

            if (!SetFieldWithoutNotification(ref targetPath, value))
                return;

            if (CurrentItem is ShortcutItem item && item.TargetPath != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = item with { TargetPath = value };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Target Path",
                    oldItem,
                    CurrentItem);

                if (value is not null)
                {
                    if (String.IsNullOrWhiteSpace(ShortcutName) ||
                        ShortcutName == oldTargetPath ||
                        ShortcutName == ShortcutData.NewShortcutText ||
                        ShortcutName == ShortcutData.NewFolderText)
                    {
                        ShortcutName = Path.GetFileNameWithoutExtension(value);
                    }

                    if (String.IsNullOrWhiteSpace(StartInPath) ||
                        StartInPath == oldTargetPath)
                        StartInPath = Path.GetDirectoryName(value);

                    if (ShortcutIcon is null)
                        LoadIcon(value);
                }
            }

            RaisePropertyChanged();
        }
    }

    private string? arguments;
    public string? Arguments
    {
        get => arguments;
        set
        {
            if (!SetFieldWithoutNotification(ref arguments, value))
                return;

            if (CurrentItem is ShortcutItem item && item.Arguments != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = item with { Arguments = value };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Arguments",
                    oldItem,
                    CurrentItem);
            }

            RaisePropertyChanged();
        }
    }

    private string? startInPath;
    public string? StartInPath
    {
        get => startInPath;
        set
        {
            if (!SetFieldWithoutNotification(ref startInPath, value))
                return;

            if (CurrentItem is ShortcutItem item && item.StartInPath != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = item with { StartInPath = value };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Start In Path",
                    oldItem,
                    CurrentItem);
            }

            RaisePropertyChanged();
        }
    }

    private string? toolTip;
    public string? ToolTip
    {
        get => toolTip;
        set
        {
            if (!SetFieldWithoutNotification(ref toolTip, value))
                return;

            if (CurrentItem is ShortcutItem item && item.ToolTip != value)
            {
                var oldItem = CurrentItem;

                CurrentItem = item with { ToolTip = value };

                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    "Tool Tip",
                    oldItem,
                    CurrentItem);
            }

            RaisePropertyChanged();
        }
    }

    private bool canUndo;
    public bool CanUndo
    {
        get => canUndo;
        set => SetField(ref canUndo, value);
    }

    private bool canRedo;
    public bool CanRedo
    {
        get => canRedo;
        set => SetField(ref canRedo, value);
    }

    public void LoadIcon(string filename)
    {
        Icon? newIcon;

        var extension = Path.GetExtension(filename).ToUpper();
        if (extension == ".EXE" ||
            extension == ".COM" ||
            extension == ".CMD" ||
            extension == ".DLL")
        {
            newIcon = Icon.ExtractAssociatedIcon(filename);
        }
        else if (extension == ".ICO")
        {
            newIcon = new Icon(filename);
        }
        else
        {
            newIcon = null;
        }

        ShortcutIcon = newIcon;
    }
}
