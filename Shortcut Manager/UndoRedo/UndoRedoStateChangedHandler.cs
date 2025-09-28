using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;

public delegate void UndoRedoStateChangedHandler(
    ShortcutFolder newRoot,
    bool canUndo,
    bool canRedo);
