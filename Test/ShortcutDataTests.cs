using ShortcutManager.Data;
using ShortcutManager.UndoRedo;
using NSubstitute;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace Test;

[TestClass]
public sealed class ShortcutDataTests
{
    private ShortcutData subject = null!;

    [TestInitialize]
    public void Initialize() => subject = new(new UndoRedoManager());

    [TestMethod]
    public void AddItem_ShouldAdd()
    {
        // Act
        subject.AddItem(
            CreateLocation(),
            CreateShortcutItem());

        // Assert
        AssertTree(
            CreateShortcutItem());
    }

    [TestMethod]
    public void AddFirstItemInRoot_ShouldAdd()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.AddItem(
            CreateLocation(),
            CreateShortcutItem());

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"),
            CreateShortcutItem());
    }

    [TestMethod]
    public void AddItemInFolder_ShouldAdd()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.AddItem(
            CreateLocation(
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1")),
            CreateShortcutItem());

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void ReplaceItem_ShouldReplace()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"));

        // Act
        subject.ReplaceItem(
            CreateLocation(CreateChildLocation(0, "0")),
            null!,
            CreateShortcutItem("0"),
            CreateShortcutItem("New"));

        // Assert
        AssertTree(
            CreateShortcutItem("New"));
    }

    [TestMethod]
    public void ReplaceFirstItemInRoot_ShouldReplace()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.ReplaceItem(
            CreateLocation(CreateChildLocation(0, "0")),
            null!,
            CreateShortcutItem("0"),
            CreateShortcutItem("New"));

        // Assert
        AssertTree(
            CreateShortcutItem("New"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void ReplaceLastItemInRoot_ShouldReplace()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.ReplaceItem(
            CreateLocation(CreateChildLocation(2, "2")),
            null!,
            CreateShortcutItem("2"),
            CreateShortcutItem("New"));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("New"));
    }

    [TestMethod]
    public void ReplaceItemInFolder_ShouldReplace()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.ReplaceItem(
            CreateLocation(
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1/1"),
                CreateChildLocation(0, "1/1/0")),
            null!,
            CreateShortcutItem("1/1/0"),
            CreateShortcutItem("New"));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("New"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void MoveFirstItemInRoot_ShouldMove()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.MoveItem(
            CreateLocation(
                CreateChildLocation(0, "0")),
            CreateLocation(
                CreateChildLocation(2, "2")));

        // Assert
        AssertTree(
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("New"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("0"),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void MoveLastItemInRoot_ShouldMove()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.MoveItem(
            CreateLocation(
                CreateChildLocation(2, "2")),
            CreateLocation(
                CreateChildLocation(0, "0")));

        // Assert
        AssertTree(
            CreateShortcutItem("2"),
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("New"),
                    CreateShortcutItem()),
                CreateShortcutItem("1/2")));
    }

    [TestMethod]
    public void MoveItemOutOfFolderToRoot_ShouldMove()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.MoveItem(
            CreateLocation(
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1/1"),
                CreateChildLocation(0, "1/1/0")),
            CreateLocation(
                CreateChildLocation(0, "0")));

        // Assert
        AssertTree(
            CreateShortcutItem("1/1/0"),
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1"),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void MoveItemIntoFolder_ShouldMove()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.MoveItem(
            CreateLocation(
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1/1"),
                CreateChildLocation(0, "1/1/0")),
            CreateLocation(
                CreateChildLocation(1, "1")));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1"),
                CreateShortcutItem("1/2"),
                CreateShortcutItem("1/1/0")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void DeleteItem_ShouldDelete()
    {
        // Arrange
        AddTree(CreateShortcutItem("0"));

        // Act
        subject.DeleteItem(CreateLocation(CreateChildLocation(0, "0")));

        // Assert
        AssertTree();
    }

    [TestMethod]
    public void DeleteFirstItemInRoot_ShouldDelete()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.DeleteItem(CreateLocation(CreateChildLocation(0, "0")));

        // Assert
        AssertTree(
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void DeleteLastItemInRoot_ShouldDelete()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.DeleteItem(CreateLocation(CreateChildLocation(2, "2")));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")));
    }

    [TestMethod]
    public void DeleteFolder_ShouldDelete()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.DeleteItem(CreateLocation(CreateChildLocation(1, "1")));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void DeleteChildItem_ShouldDelete()
    {
        // Arrange
        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    CreateShortcutItem("1/1/0")),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        subject.DeleteItem(CreateLocation(CreateChildLocation(0, "1/1/0")));

        // Assert
        AssertTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1"),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));
    }

    [TestMethod]
    public void GetLocation_ShouldReturnLocation()
    {
        // Arrange
        var target = CreateShortcutItem("1/1/0");

        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    target),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        var result = subject.GetLocation(target);

        // Assert
        result.Path.Should().BeEquivalentTo(
            [
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1/1"),
                CreateChildLocation(0, "1/1/0"),
            ]);
    }

    [TestMethod]
    public void GetItem_ShouldReturnItem()
    {
        // Arrange
        var target = CreateShortcutItem("1/1/0");

        AddTree(
            CreateShortcutItem("0"),
            CreateFolder(
                "1",
                CreateShortcutItem("1/0"),
                CreateFolder(
                    "1/1",
                    target),
                CreateShortcutItem("1/2")),
            CreateShortcutItem("2"));

        // Act
        var result = subject.GetItem(
            CreateLocation(
                CreateChildLocation(1, "1"),
                CreateChildLocation(1, "1/1"),
                CreateChildLocation(0, "1/1/0")));

        // Assert
        result.Should().Be(target);
    }

    [TestMethod]
    public void DataVersion_ShouldChange()
    {
        // Act
        var oldVersion = subject.DataVersion;
        subject.AddItem(
            CreateLocation(),
            CreateShortcutItem());

        // Assert
        subject.DataVersion.Should().NotBe(oldVersion);
    }

    private static ShortcutItem CreateShortcutItem(
        string name = "Shortcut") 
    =>
        new()
        {
            Name = name,
            TargetPath = null,
            Icon = null, 
            Arguments = null,
            StartInPath = null,
            ToolTip = null
        };

    private static ShortcutFolder CreateFolder(
        string name = "Folder", 
        params IEnumerable<IShortcutOrFolder> children)
    =>
        new()
        {
            Name = name,
            Children = children,
        };

    private static ChildLocation CreateChildLocation(int index, string name) =>
        new()
        {
            Index = index,
            Name = name,
        };

    private static Location CreateLocation(params IEnumerable<ChildLocation> path) =>
        new()
        {
            Path = path,
        };

    private void AddTree(params IEnumerable<IShortcutOrFolder> children)
    {
        foreach (var child in children)
            subject.AddItem(CreateLocation(), child);
    }

    private void AssertTree(params IEnumerable<IShortcutOrFolder> expectedChildren) =>
        subject.Root.Should().BeEquivalentTo(
            CreateFolder(
                "Root",
                expectedChildren),
            c => c
                .Excluding((IMemberInfo member) => member.Name == "Icon")
                .WithStrictOrdering());
}
