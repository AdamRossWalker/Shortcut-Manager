using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;
public interface IUndoRedoManager
{
    public IEnumerable<Frame> RedoFrames { get; }

    public IEnumerable<Frame> UndoFrames { get; }

#pragma warning disable CA1003 // Use generic event handler instances
    public event UndoRedoStateChangedHandler? UndoRedoStateChanged;
#pragma warning restore CA1003 // Use generic event handler instances

    public void AddFrame(Change change, ShortcutFolder newRoot);
    
    public bool Undo();
    
    public bool Redo();
    
    public bool SetFrameIndex(int newIndex);
}