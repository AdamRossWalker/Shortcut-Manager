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

    public IEnumerable<Frame> UndoFrames => history.Skip(1).Take(currentFrameIndex).Reverse().Take(10);

    public IEnumerable<Frame> RedoFrames => history.Skip(currentFrameIndex + 1);

    public void AddFrame(Change change, ShortcutFolder newRoot)
    {
        void TrimLaterHistory()
        {
            var firstInvalidIndex = currentFrameIndex + 1;
            if (firstInvalidIndex >= history.Count)
                return;

            history.RemoveRange(firstInvalidIndex, history.Count - firstInvalidIndex);
        }

        // If we are editing text, we want to replace the last node, 
        // not add to it.
        if (currentFrameIndex >= 0 && currentFrameIndex < history.Count)
        {
            var previousChange = history[currentFrameIndex].Change;
        
            if (change.IsMergable && previousChange.IsMergable &&
                change.Description == previousChange.Description &&
                ReferenceEquals(change.OldItem, previousChange.NewItem))
            {
                history[currentFrameIndex] = new()
                {
                    Change = change,
                    Index = currentFrameIndex,
                    Root = newRoot,
                };

                TrimLaterHistory();
                ApplyNewShortcutTree?.Invoke(newRoot);
                return;
            }
        }

        TrimLaterHistory();
        currentFrameIndex++;

        history.Add(new()
        {
            Change = change,
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

    public bool SetFrameIndex(int newIndex)
    {
        if (newIndex >= history.Count)
            return false;

        currentFrameIndex = newIndex;
        ApplyNewShortcutTree?.Invoke(history[currentFrameIndex].Root);
        return true;
    }
}
