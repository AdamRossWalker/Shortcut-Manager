namespace ShortcutManager.Data;

public interface IShortcutData
{
    public int DataVersion { get; }

    public ShortcutFolder Root { get; }

    public IShortcutOrFolder GetItem(Location location);

    public Location GetLocation(IShortcutOrFolder item, ShortcutFolder? root = null);

    public void AddItem(Location location, IShortcutOrFolder newItem);

    public void DeleteItem(Location location);

    public Location MoveItem(Location sourceLocation, Location targetLocation);

    public void ReplaceItem(Location location, string fieldName, IShortcutOrFolder oldItem, IShortcutOrFolder newItem);

    public Task Save();
}