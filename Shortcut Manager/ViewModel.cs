using System.Windows.Forms;
using ShortcutManager.Data;

namespace ShortcutManager;

public sealed class ViewModel : ObservableObject
{
    private IShortcutOrFolder? currentItem;
    public IShortcutOrFolder? CurrentItem
    {
        get => currentItem;
        set
        {
            if (!SetFieldWithoutNotification(ref currentItem, value))
                return;

            if (value is not null)
            {
                ShortcutName = value.Name;
                ShortcutIcon = value.Icon;

                if (value is ShortcutItem item)
                {
                    TargetPath = item.TargetPath;
                    Arguments = item.Arguments;
                    StartInPath = item.StartInPath;
                    ToolTip = item.ToolTip;
                }
            }

            RaisePropertyChanged();
        }
    }

    private IEnumerable<(int Index, string Name)> selectedNodeLocation = [];
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
            if (!SetFieldWithoutNotification(ref targetPath, value))
                return;

            if (CurrentItem is ShortcutItem item)
                ShortcutData.Instance.ReplaceItem(
                    selectedNodeLocation,
                    item with { TargetPath = value });

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
}
