using ShortcutManager.Data;

namespace ShortcutManager.UndoRedo;

public sealed class UndoRedoManager
{
    private readonly List<Frame> history = [];
    private int currentFrameIndex = -1;

    private UndoRedoManager() { }

    public static UndoRedoManager Instance { get; } = new();

    public delegate void ApplyNewShortcutTreeEventHandler(ShortcutFolder newRoot);

    public event ApplyNewShortcutTreeEventHandler? ApplyNewShortcutTree;

    public IEnumerable<Frame> UndoFrames => history.Take(currentFrameIndex).Reverse();

    public IEnumerable<Frame> RedoFrames => history.Skip(currentFrameIndex + 1);

    public void AddFrame(string name, ShortcutFolder newRoot)
    {
        currentFrameIndex++;
        if (currentFrameIndex < history.Count)
            history.RemoveRange(currentFrameIndex, history.Count - currentFrameIndex);

        history.Add(new()
        {
            Name = name,
            Index = currentFrameIndex,
            Root = newRoot,
        });

        ApplyNewShortcutTree?.Invoke(newRoot);
    }

    public bool Undo()
    {
        if (currentFrameIndex <= 0)
            return false;

        currentFrameIndex--;
        ApplyNewShortcutTree?.Invoke(history[currentFrameIndex].Root);
        return true;
    }

    public bool Redo()
    {
        if (currentFrameIndex >= history.Count - 1)
            return false;

        currentFrameIndex++;
        ApplyNewShortcutTree?.Invoke(history[currentFrameIndex].Root);
        return true;
    }

    public bool SetFrame(Frame target)
    {
        var newIndex = target.Index;

        if (newIndex >= history.Count ||
            target != history[newIndex])
            return false;

        currentFrameIndex = newIndex;
        ApplyNewShortcutTree?.Invoke(history[currentFrameIndex].Root);
        return true;
    }
}
