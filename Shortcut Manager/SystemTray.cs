using ShortcutManager.Data;

namespace ShortcutManager;

/// <summary>
/// Manages the system tray icon, popup menus, and loading the main window.
/// </summary>
public sealed class SystemTray : ApplicationContext
{
    private readonly NotifyIcon notifyIcon;

    public SystemTray()
    {
        notifyIcon = new()
        {
            Icon = Properties.Resources.ApplicationIcon,
            Visible = true,
            ContextMenuStrip = new()
            {
                Items =
                {
                    new ToolStripMenuItem("&Open...", null, Open),
                    new ToolStripMenuItem("E&xit", null, Exit)
                },
            },
        };

        notifyIcon.MouseDown += OnMouseDown;

        // If the user hasn't set us up yet, open the full window.
        if (!ShortcutData.Instance.Root.Children.Any())
            Open();
    }
    private void OnMouseDown(object? sender, MouseEventArgs eventArgs)
    { 
        if (eventArgs.Button != MouseButtons.Left)
            return;

        // MessageBox.Show("TODO: Shortcut menu here.");
        Exit(); // To make development easier for now.
    }

    private void Open(object? sender = null, EventArgs? eventArgs = null) => 
        new MainForm().Show();

    private void Exit(object? sender = null, EventArgs? eventArgs = null)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }
}
