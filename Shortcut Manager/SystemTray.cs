using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ShortcutManager.Data;
using ShortcutManager.Properties;

namespace ShortcutManager;

/// <summary>
/// Manages the system tray icon, popup menus, and loading the main window.
/// </summary>
public sealed class SystemTray : ApplicationContext, IApplicationContext
{
    private readonly IServiceProvider serviceProvider;
    private readonly IShortcutData shortcutData;
    private readonly NotifyIcon notifyIcon;
    private readonly ContextMenuStrip shortcutsContextMenu;
    private readonly ContextMenuStrip mainContextMenu;
    private int currentShortcutDataVersion = -1;

    public SystemTray(
        IServiceProvider serviceProvider,
        IShortcutData shortcutData)
    {
        this.serviceProvider = serviceProvider;
        this.shortcutData = shortcutData;

        shortcutsContextMenu = new()
        {
            ShowItemToolTips = true,
        };

        mainContextMenu = new()
        {
            Items =
            {
                new ToolStripMenuItem("&Open...", Resources.ApplicationIcon.ToBitmap(), Open),
                new ToolStripMenuItem("E&xit", Resources.Delete, (_, _) => ExitProgram())
            },
        };

        notifyIcon = new()
        {
            Icon = Resources.ApplicationIcon,
            Visible = true,
            ContextMenuStrip = mainContextMenu,
        };

        notifyIcon.MouseDown += MouseDown;
        notifyIcon.MouseClick += MouseClick;
        notifyIcon.DoubleClick += Open;

        // If the user hasn't set us up yet, open the full window.
        if (!shortcutData.Root.Children.Any())
            Open();
    }

    protected override void Dispose(bool disposing)
    {
        notifyIcon.Dispose();
        shortcutsContextMenu.Dispose();
        mainContextMenu.Dispose();
        base.Dispose(disposing);
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
        serviceProvider.GetRequiredService<MainForm>().Show();

    public void ExitProgram()
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void ClearContextMenuItems()
    {
        var allMenuItems = new List<ToolStripItem>();

        void CollectItems(ToolStripItemCollection items)
        {
            foreach (var item in items.Cast<ToolStripItem>())
            {
                allMenuItems.Add(item);

                if (item is ToolStripMenuItem menuItem)
                    CollectItems(menuItem.DropDownItems);
            }
        }

        CollectItems(shortcutsContextMenu.Items);
        shortcutsContextMenu.Items.Clear();

        foreach (var item in allMenuItems)
            item.Dispose();
    }

    private void RefreshShortcutsContextMenu()
    {
        if (currentShortcutDataVersion == shortcutData.DataVersion)
            return;

        ClearContextMenuItems();

        static bool AddFolder(
            ToolStripItemCollection parentMenuItem,
            ShortcutFolder shortcutFolder)
        {
            var hasAddedItems = false;

            foreach (var sourceItem in shortcutFolder.Children)
            {
                var shouldAddThisMenuItem = false;

#pragma warning disable CA2000 // Dispose objects before losing scope
                var menuItem = new ToolStripMenuItem()
                {
                    Text = sourceItem.Name,
                    Image = sourceItem.Icon?.ToBitmap(),
                };
#pragma warning restore CA2000 // Dispose objects before losing scope

                if (sourceItem is ShortcutItem shortcut)
                {
                    menuItem.Click += (sender, eventArguments) => shortcut.Execute();
                    menuItem.ToolTipText = shortcut.ToolTip;
                    shouldAddThisMenuItem = true;
                }

                if (sourceItem is ShortcutFolder folder)
                    shouldAddThisMenuItem = AddFolder(menuItem.DropDownItems, folder);

                if (shouldAddThisMenuItem)
                {
                    parentMenuItem.Add(menuItem);
                    hasAddedItems = true;
                }
            }

            return hasAddedItems;
        }

        AddFolder(
            shortcutsContextMenu.Items,
            shortcutData.Root);

        currentShortcutDataVersion = shortcutData.DataVersion;
    }
}
