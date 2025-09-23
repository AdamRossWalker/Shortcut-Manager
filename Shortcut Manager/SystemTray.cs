using System.Reflection;
using ShortcutManager.Data;

namespace ShortcutManager;

/// <summary>
/// Manages the system tray icon, popup menus, and loading the main window.
/// </summary>
public sealed class SystemTray : ApplicationContext
{
    private readonly NotifyIcon notifyIcon;
    private readonly ContextMenuStrip shortcutsContextMenu;
    private readonly ContextMenuStrip mainContextMenu;
    private int currentShortcutDataVersion = -1;

    public SystemTray()
    {
        shortcutsContextMenu = new() 
        { 
            ShowItemToolTips = true,
        };

        mainContextMenu = new()
        {
            Items =
            {
                new ToolStripMenuItem("&Open...", null, Open),
                new ToolStripMenuItem("E&xit", null, Exit)
            },
        };

        notifyIcon = new()
        {
            Icon = Properties.Resources.ApplicationIcon,
            Visible = true,
            ContextMenuStrip = mainContextMenu,
        };

        notifyIcon.MouseDown += MouseDown;
        notifyIcon.MouseClick += MouseClick;
        notifyIcon.DoubleClick += Open;

        // If the user hasn't set us up yet, open the full window.
        if (!ShortcutData.Instance.Root.Children.Any())
            Open();
    }

    private void MouseDown(object? sender, MouseEventArgs eventArguments)
    {
        if (eventArguments.Button == MouseButtons.Right)
            notifyIcon.ContextMenuStrip = mainContextMenu;
        else if (eventArguments.Button == MouseButtons.Left)
        {
            RefreshShortcutsContextMenu();
            notifyIcon.ContextMenuStrip = shortcutsContextMenu;
        }
    }

    private void MouseClick(object? sender, MouseEventArgs eventArguments)
    {
        if (eventArguments.Button != MouseButtons.Left)
            return;

        // Apparently it's not actually easy to open a menu on a LEFT click here.
        // If I try and wire it up myself in the obvious way, you see a task bar 
        // button and there are other problems.
        //
        // The Interwebs say calling the below private method via reflection is the 
        // only way.  I took a quick look at the source and it appears safe to me.
        var showContextMenuMethod = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
        showContextMenuMethod!.Invoke(notifyIcon, null);
    }

    private void Open(object? sender = null, EventArgs? eventArgs = null) => 
        new MainForm().Show();

    private void Exit(object? sender = null, EventArgs? eventArgs = null)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void RefreshShortcutsContextMenu()
    {
        if (currentShortcutDataVersion == ShortcutData.Instance.DataVersion)
            return;

        shortcutsContextMenu.Items.Clear();

        AddFolderMenuItems(
            shortcutsContextMenu.Items,
            ShortcutData.Instance.Root);

        currentShortcutDataVersion = ShortcutData.Instance.DataVersion;
    }

    private static bool AddFolderMenuItems(
        ToolStripItemCollection parentMenuItem,
        ShortcutFolder shortcutFolder)
    {
        var hasAddedItems = false;

        foreach (var sourceItem in shortcutFolder.Children)
        {
            var shouldAddThisMenuItem = false;

            var menuItem = new ToolStripMenuItem()
            {
                Text = sourceItem.Name,
                Image = sourceItem.Icon?.ToBitmap(),
            };

            if (sourceItem is ShortcutItem shortcut)
            {
                menuItem.Click += (sender, eventArguments) => shortcut.Execute();
                menuItem.ToolTipText = shortcut.ToolTip;
                shouldAddThisMenuItem = true;
            }

            if (sourceItem is ShortcutFolder folder)
                shouldAddThisMenuItem = AddFolderMenuItems(menuItem.DropDownItems, folder);

            if (shouldAddThisMenuItem)
            {
                parentMenuItem.Add(menuItem);
                hasAddedItems = true;
            }
        }

        return hasAddedItems;
    }
}
