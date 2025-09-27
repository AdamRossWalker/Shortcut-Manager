namespace ShortcutManager.Helpers;

public static class IconExtensions
{
    public static Icon ToIcon(this Bitmap bitmap) =>
        Icon.FromHandle(bitmap.GetHicon());
}
