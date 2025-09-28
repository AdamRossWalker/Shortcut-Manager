using System.Runtime.InteropServices;

namespace ShortcutManager;

// From: https://stackoverflow.com/a/487757
public sealed partial class DrawingControl
{
    [LibraryImport("user32.dll", EntryPoint = "SendMessageW")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int SendMessage(IntPtr hWnd, int wMsg, [MarshalAs(UnmanagedType.Bool)] bool wParam, int lParam);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(Control parent) => 
        SendMessage(parent.Handle, WM_SETREDRAW, false, 0);

    public static void ResumeDrawing(Control parent)
    {
        SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
        parent.Refresh();
    }
}
