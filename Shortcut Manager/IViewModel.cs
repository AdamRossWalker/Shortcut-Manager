using System.ComponentModel;
using ShortcutManager.Data;

namespace ShortcutManager;

public interface IViewModel : INotifyPropertyChanged
{
    public string? Arguments { get; set; }

    public bool CanRedo { get; set; }

    public bool CanUndo { get; set; }

    public IShortcutOrFolder? CurrentItem { get; set; }

    public Location SelectedNodeLocation { get; set; }

    public Bitmap? ShortcutBitmap { get; }

    public Icon? ShortcutIcon { get; set; }

    public string? ShortcutName { get; set; }

    public string? StartInPath { get; set; }

    public string? TargetPath { get; set; }

    public string? ToolTip { get; set; }

    public void LoadIcon(string filename);

    public void SetCurrentItem(Location selectedNodeLocation, IShortcutOrFolder? currentItem);
}