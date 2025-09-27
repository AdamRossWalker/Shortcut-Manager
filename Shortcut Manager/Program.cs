using Microsoft.Extensions.DependencyInjection;
using ShortcutManager.Data;
using ShortcutManager.UndoRedo;

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
            Application.ThreadException += Application_ThreadException;
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            var servicesProvider = services.BuildServiceProvider();

            Application.Run(servicesProvider.GetRequiredService<SystemTray>());
        }
        finally
        {
            mutex.ReleaseMutex();
            mutex.Dispose();
        }
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs eventArguments)
    { 
        var exception = eventArguments.Exception;

        var result = MessageBox.Show(
            exception.Message + 
                Environment.NewLine + 
                Environment.NewLine + 
                "Copy full error details to the clipboard?",
            "Error", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Error );

        if (result == DialogResult.Yes)
            Clipboard.SetText(exception.ToString());
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IViewModel, ViewModel>();
        services.AddSingleton<IShortcutData, ShortcutData>();
        services.AddSingleton<IUndoRedoManager, UndoRedoManager>();

        services.AddTransient<MainForm>();
        services.AddTransient<SystemTray>();
    }
}