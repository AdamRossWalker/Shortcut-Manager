using ShortcutManager.Data;

namespace ShortcutManager;

public sealed class ViewModel : ObservableObject
{
    private IEnumerable<(int Index, string Name)> selectedNodeLocation = [];
    private IShortcutOrFolder? currentItem;

    public void SetCurrentItem(
        IEnumerable<(int Index, string Name)> selectedNodeLocation,
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
        set
        {
            if (!SetFieldWithoutNotification(ref currentItem, value))
                return;

            RaisePropertyChanged();
        }
    }

    public IEnumerable<(int Index, string Name)> SelectedNodeLocation
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

            if (CurrentItem is not null)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    CurrentItem switch
                    {
                        ShortcutFolder folder => folder with { Name = value },
                        ShortcutItem shortcut => shortcut with { Name = value },
                        _ => CurrentItem,
                    });

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

            if (CurrentItem is not null)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    CurrentItem switch
                    {
                        ShortcutFolder folder => folder with { Icon = value },
                        ShortcutItem shortcut => shortcut with { Icon = value },
                        _ => CurrentItem,
                    });

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

            if (CurrentItem is ShortcutItem item)
            {
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    item with { TargetPath = value });

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

            if (CurrentItem is ShortcutItem item)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    item with { Arguments = value });

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

            if (CurrentItem is ShortcutItem item)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    item with { StartInPath = value });

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

            if (CurrentItem is ShortcutItem item)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    item with { ToolTip = value });

            RaisePropertyChanged();
        }
    }

    public void LoadIcon(string filename)
    {
        Icon? newIcon;

        var extension = Path.GetExtension(filename).ToUpper();
        if (extension == ".EXE" ||
            extension == ".COM" ||
            extension == ".CMD")
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
