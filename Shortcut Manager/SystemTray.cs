namespace ShortcutManager;

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
    }
    private void OnMouseDown(object? sender, MouseEventArgs eventArgs)
    { 
        if (eventArgs.Button != MouseButtons.Left)
            return;

        MessageBox.Show("TODO: Shortcut menu here.");
    }

    private void Open(object? sender, EventArgs eventArgs) => 
        new MainForm().Show();

    private void Exit(object? sender, EventArgs eventArgs)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }
}
