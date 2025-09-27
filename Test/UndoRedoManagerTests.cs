using ShortcutManager.UndoRedo;
using FluentAssertions;
using ShortcutManager.Data;

namespace Test;

[TestClass]
public sealed class UndoRedoManagerTests
{
    private UndoRedoManager subject = null!;
    private int frameNumber = 0;
    private List<ShortcutFolder> publishedTrees = null!;
    private List<(bool CanUndo, bool CanRedo)> publishedStateChanges = null!;

    [TestInitialize]
    public void Initialize()
    {
        frameNumber = 0;

        publishedTrees = [];
        publishedStateChanges = [];

        subject = new();
        subject.ApplyNewShortcutTree += publishedTrees.Add;
        subject.UndoRedoStateChanged += (canUndo, canRedo) => publishedStateChanges.Add((canUndo, canRedo));
    }

    [TestMethod]
    public void Subject_ShouldStartEmpty()
    {
        // Assert
        AssertUndoFrames(0);
        AssertRedoFrames(0);
        AssertTreeChange(0);
        AssertStateChange(0);
    }

    [TestMethod]
    public void Subject_WithInitializationFrame_ShouldBeEmpty()
    {
        // Arrange
        SubjectAddFrame("Initialized");

        // Assert
        AssertUndoFrames(0);
        AssertRedoFrames(0);
        AssertTreeChange(1, "Initialized");
        AssertStateChange(1);
    }

    [TestMethod]
    public void AddFrame_ShouldBeAbleToUndo()
    {
        // Arrange
        SubjectAddFrame("Initialized");

        // Act
        SubjectAddFrame();

        // Assert
        AssertUndoFrames(1, "Change1");
        AssertRedoFrames(0);
        AssertTreeChange(2, "Tree1");
        AssertStateChange(2);
    }

    [TestMethod]
    public void AddFrames_ShouldBeAbleToUndo()
    {
        // Arrange
        SubjectAddFrame("Initialized");

        // Act
        SubjectAddFrame();
        SubjectAddFrame();

        // Assert
        AssertUndoFrames(2, "Change2");
        AssertRedoFrames(0);
        AssertTreeChange(3, "Tree2");
        AssertStateChange(3);
    }

    [TestMethod]
    public void Undo_ShouldUndo()
    {
        // Arrange
        SubjectAddFrame("Initialized");
        SubjectAddFrame();

        // Act
        subject.Undo();

        // Assert
        AssertUndoFrames(0);
        AssertRedoFrames(1, "Change1");
        AssertTreeChange(3, "Initialized");
        AssertStateChange(3);
    }

    [TestMethod]
    public void Redo_ShouldRedo()
    {
        // Arrange
        SubjectAddFrame("Initialized");
        SubjectAddFrame();
        subject.Undo();

        // Act
        subject.Redo();

        // Assert
        AssertUndoFrames(1, "Change1");
        AssertRedoFrames(0);
        AssertTreeChange(4, "Tree1");
        AssertStateChange(4);
    }

    [TestMethod]
    public void SetFrameIndex_ShouldSetFrame()
    {
        // Arrange
        SubjectAddFrame("Initialized");
        SubjectAddFrame();
        SubjectAddFrame();
        SubjectAddFrame();

        // Act
        subject.SetFrameIndex(1);

        // Assert
        AssertUndoFrames(1, "Change1");
        AssertRedoFrames(2, "Change2");
        AssertTreeChange(5, "Tree1");
        AssertStateChange(5);
    }

    private void SubjectAddFrame(string? name = null)
    {
        subject.AddFrame(
            CreateChange(name ?? "Change" + frameNumber),
            CreateTree(name ?? "Tree" + frameNumber));

        frameNumber++;
    }

    private static Change CreateChange(
        string name = "Name",
        string description = "Description",
        bool isMergable = false,
        IShortcutOrFolder? oldItem = null,
        IShortcutOrFolder? newItem = null)
    =>
        new()
        {
            IsMergable = isMergable,
            Name = name,
            Description = description,
            OldItem = oldItem,
            NewItem = newItem,
        };

    private static ShortcutFolder CreateTree(
        string name = "Tree")
    =>
        new()
        {
            Name = name,
            Children = [],
        };

    private void AssertStateChange(int expectedCount)
    {
        publishedStateChanges.Should().HaveCount(expectedCount);

        var (canUndo, canRedo) = publishedStateChanges.LastOrDefault();

        canUndo.Should().Be(subject.UndoFrames.Any());
        canRedo.Should().Be(subject.RedoFrames.Any());
    }

    private void AssertTreeChange(int expectedCount, string? expectedName = null)
    {
        publishedTrees.Should().HaveCount(expectedCount);

        if (expectedCount == 0)
            return;

        var tree = publishedTrees.Last();

        tree.Name.Should().Be(expectedName);
    }

    private void AssertUndoFrames(int expectedCount, string? expectedName = null)
    {
        subject.UndoFrames.Should().HaveCount(expectedCount);

        if (expectedCount == 0)
            return;

        var undoFrame = subject.UndoFrames.First();
        undoFrame.Change.Name.Should().Be(expectedName);
    }

    private void AssertRedoFrames(int expectedCount, string? expectedName = null)
    {
        subject.RedoFrames.Should().HaveCount(expectedCount);

        if (expectedCount == 0)
            return;

        var redoFrame = subject.RedoFrames.First();
        redoFrame.Change.Name.Should().Be(expectedName);
    }
}
