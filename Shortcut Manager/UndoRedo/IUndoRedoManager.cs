using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;
public interface IUndoRedoManager
{
    public IEnumerable<Frame> RedoFrames { get; }

    public IEnumerable<Frame> UndoFrames { get; }

    public event UndoRedoManager.ApplyNewShortcutTreeEventHandler? ApplyNewShortcutTree;
    
    public event UndoRedoManager.UndoRedoStateChangedEventHandler? UndoRedoStateChanged;

    public void AddFrame(Change change, ShortcutFolder newRoot);
    
    public bool Undo();
    
    public bool Redo();
    
    public bool SetFrameIndex(int newIndex);
}