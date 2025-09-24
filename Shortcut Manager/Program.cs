namespace ShortcutManager;

/// <summary>
/// Loads the system tray icon instead of the full window.
/// </summary>
public static class Program
{
    private static readonly Mutex mutex = new(initiallyOwned: true, "ShortcutManager single instance mutex b8958094-5541-48fe-8759-7636e2980f54.");

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // https://stackoverflow.com/a/522874
        if (!mutex.WaitOne(TimeSpan.Zero, exitContext: true))
            return;

        try
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SystemTray());
        }
        finally
        {
            mutex.ReleaseMutex();
            mutex.Dispose();
        }
    }
}