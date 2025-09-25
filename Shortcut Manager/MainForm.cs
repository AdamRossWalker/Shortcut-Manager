using ShortcutManager.Data;
using ShortcutManager.Properties;
using ShortcutManager.UndoRedo;

namespace ShortcutManager;

public partial class MainForm : Form
{
    private readonly ViewModel viewModel = new();

    public MainForm()
    {
        InitializeComponent();

        AddTextBoxBinding(ShortcutNameTextBox, nameof(ViewModel.ShortcutName));
        AddTextBoxBinding(TargetPathTextBox, nameof(ViewModel.TargetPath));
        AddTextBoxBinding(ArgumentsTextBox, nameof(ViewModel.Arguments));
        AddTextBoxBinding(StartInTextBox, nameof(ViewModel.StartInPath));
        AddTextBoxBinding(ToolTipTextBox, nameof(ViewModel.ToolTip));

        IconPictureBox.DataBindings.Add(nameof(PictureBox.Image), viewModel, nameof(ViewModel.ShortcutBitmap), true);

        viewModel.PropertyChanged += (sender, property) =>
        {
            if (property.PropertyName != nameof(ViewModel.ShortcutName) &&
                property.PropertyName != nameof(ViewModel.ShortcutIcon))
                return;

            RefreshTree();
        };
    }

    private int treeLockCount = 0;

    private sealed class LockTreeRefresh : IDisposable
    {
        private readonly MainForm owner;

        public LockTreeRefresh(MainForm mainForm)
        {
            owner = mainForm;
            owner.treeLockCount++;
        }

        public void Dispose() => owner.treeLockCount--;
    }

    private LockTreeRefresh SuppressTreeRefresh() => new(this);

    private void AddTextBoxBinding(TextBox textBox, string propertyName) =>
        textBox.DataBindings.Add(
            nameof(TextBox.Text),
            viewModel,
            propertyName,
            formattingEnabled: false,
            DataSourceUpdateMode.OnPropertyChanged);

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        RefreshTree();
    }

    protected override void OnClosed(EventArgs e)
    {
        ShortcutData.Instance.Save();
        base.OnClosed(e);
    }

    private void RefreshTree()
    {
        void AddShortcutsToTree(
            TreeNode? parent,
            IEnumerable<IShortcutOrFolder> elements)
        {
            var container = parent?.Nodes ?? MainTree.Nodes;

            foreach (var element in elements)
            {
                var node = new TreeNode(element.Name);

                if (element.Icon is not null)
                {
                    var newImageIndex = MainTree.ImageList.Images.Count;
                    MainTree.ImageList.Images.Add(element.Icon);
                    node.ImageIndex = newImageIndex;
                    node.SelectedImageIndex = newImageIndex;
                }

                if (element is ShortcutFolder folder)
                    AddShortcutsToTree(node, folder.Children);

                container.Add(node);
            }
        }

        if (treeLockCount > 0)
            return;

        var selectedLocation = SelectedLocation();

        using var _ = SuppressTreeRefresh();

        MainTree.SuspendLayout();
        try
        {
            MainTree.Nodes.Clear();
            MainTree.ImageList ??= new ImageList();
            MainTree.ImageList.Images.Clear();
            MainTree.ImageList.Images.Add(Resources.MissingIcon);

            AddShortcutsToTree(parent: null, ShortcutData.Instance.Root.Children);
            MainTree.ExpandAll();
        }
        finally
        {
            MainTree.ResumeLayout();
        }

        SelectBestNodeFrom(selectedLocation);
    }

    private Location SelectedLocation()
    {
        static IEnumerable<ChildLocation> LocationOf(TreeNode? node)
        {
            if (node is null)
                yield break;

            foreach (var parentNodes in LocationOf(node.Parent))
                yield return parentNodes;

            yield return new()
            {
                Index = node.Index,
                Name = node.Text,
            };
        }

        return new()
        {
            Path = LocationOf(MainTree.SelectedNode),
        };
    }

    private void SelectBestNodeFrom(Location nodeLocation)
    {
        var currentNodeCollection = MainTree.Nodes;
        var currentNode = null as TreeNode;

        foreach (var location in nodeLocation.Path)
        {
            // Is this location a perfect match?
            if (currentNodeCollection.Count > location.Index &&
                currentNodeCollection[location.Index].Name == location.Name)
            {
                currentNode = currentNodeCollection[location.Index];
                currentNodeCollection = currentNode.Nodes;
                continue;
            }

            // Find other nodes that have the same name, then pick the nearest of those.
            var nearestNodeMatchingName =
                currentNodeCollection
                .Cast<TreeNode>()
                .Where(n => n.Name == location.Name)
                .OrderBy(n => Math.Abs(n.Index - location.Index))
                .ThenBy(n => n.Index)
                .FirstOrDefault();

            if (nearestNodeMatchingName is not null)
            {
                currentNode = nearestNodeMatchingName;
                currentNodeCollection = currentNode.Nodes;
                continue;
            }

            // Fallback to the same index
            if (location.Index < currentNodeCollection.Count)
            {
                currentNode = currentNodeCollection[location.Index];
                currentNodeCollection = currentNode.Nodes;
                continue;
            }

            if (currentNodeCollection.Count > 0)
            {
                currentNode = currentNodeCollection[^1];
                currentNodeCollection = currentNode.Nodes;
                continue;
            }

            break;
        }

        MainTree.SelectedNode = currentNode;
    }

    private static Location GetNearestParentFolderLocation(
        Location startingLocation)
    {
        var location = startingLocation;
        while (ShortcutData.Instance.GetItem(location) is ShortcutItem)
            location = location.ParentPath;

        return location;
    }

    private void AddShortcutButton_Click(object sender, EventArgs e)
    {
        ShortcutData.Instance.AddItem(
            GetNearestParentFolderLocation(SelectedLocation()),
            new ShortcutItem
            {
                Name = ShortcutData.NewShortcutText,
                Icon = null,
                TargetPath = null,
                Arguments = null,
                StartInPath = null,
                ToolTip = null,
            });

        RefreshTree();
    }

    private void AddFolderButton_Click(object sender, EventArgs e)
    {
        ShortcutData.Instance.AddItem(
            GetNearestParentFolderLocation(SelectedLocation()),
            new ShortcutFolder
            {
                Name = ShortcutData.NewFolderText,
                Children = [],
            });

        RefreshTree();
    }

    private void DeleteButton_Click(object? sender = null, EventArgs? e = null)
    {
        ShortcutData.Instance.DeleteItem(
            SelectedLocation());

        RefreshTree();
    }

    private void MainTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
        using var _ = SuppressTreeRefresh();
        RefreshSelectedShortcut();
    }

    private void RefreshSelectedShortcut()
    {
        var location = SelectedLocation();
        var item = ShortcutData.Instance.GetItem(location);
        var shortcut = item as ShortcutItem;

        var isFolder = item is ShortcutFolder;
        var isShortcut = shortcut is not null;
        var isEither = isFolder | isShortcut;

        MainTableLayoutPanel.SuspendLayout();
        try
        {
            IconLabel.Visible = isEither;
            IconPictureBox.Visible = isEither;
            IconBrowseButton.Visible = isEither;

            ShortcutNameLabel.Visible = isEither;
            ShortcutNameTextBox.Visible = isEither;

            TargetPathLabel.Visible = isShortcut;
            TargetPathTextBox.Visible = isShortcut;
            TargetPathBrowseButton.Visible = isShortcut;

            ArgumentsLabel.Visible = isShortcut;
            ArgumentsTextBox.Visible = isShortcut;

            StartInLabel.Visible = isShortcut;
            StartInTextBox.Visible = isShortcut;
            StartInBrowseButton.Visible = isShortcut;

            ToolTipLabel.Visible = isShortcut;
            ToolTipTextBox.Visible = isShortcut;

            DeleteButton.Visible = isEither;
            MainTreeContextMenuAddDeleteButton.Visible = isEither;

            // For some crazy reason setting all the controls to invisible doesn't shrink the row to zero, 
            // So I'm doing it manually.
            var shortcutRowSizeType = isShortcut ? SizeType.AutoSize : SizeType.Absolute;

            MainTableLayoutPanel.RowStyles[4].SizeType = shortcutRowSizeType;
            MainTableLayoutPanel.RowStyles[5].SizeType = shortcutRowSizeType;
            MainTableLayoutPanel.RowStyles[6].SizeType = shortcutRowSizeType;
            MainTableLayoutPanel.RowStyles[7].SizeType = shortcutRowSizeType;
            MainTableLayoutPanel.RowStyles[4].Height = 0;
            MainTableLayoutPanel.RowStyles[5].Height = 0;
            MainTableLayoutPanel.RowStyles[6].Height = 0;
            MainTableLayoutPanel.RowStyles[7].Height = 0;

            viewModel.SetCurrentItem(location, item);
        }
        finally
        {
            MainTableLayoutPanel.ResumeLayout();
        }

        // For some other crazy reason, I have to size twice to get it to work.  FML.
        MainTableLayoutPanel.PerformLayout();
        MainTableLayoutPanel.PerformLayout();
    }

    private void IconBrowseButton_Click(object sender, EventArgs e)
    {
        BrowseFileDialog.Filter = "Executable File (*.exe;*.com;*.cmd)|*.exe;*.com;*.cmd|Icons (*.ico)|*.ico|All Files (*.*)|*.*";
        BrowseFileDialog.FilterIndex = 0;

        if (BrowseFileDialog.ShowDialog() != DialogResult.OK)
            return;

        viewModel.LoadIcon(BrowseFileDialog.FileName);
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
        BrowseFileDialog.Filter = "Executable File (*.exe;*.com;*.cmd;*.bat)|*.exe;*.com;*.cmd;*.bat|All Files (*.*)|*.*";
        BrowseFileDialog.FilterIndex = 0;

        BrowseFileDialog.DefaultExt = "Executable File (*.exe;*.com;*.cmd;*.bat)";

        if (BrowseFileDialog.ShowDialog() != DialogResult.OK)
            return;

        var filename = BrowseFileDialog.FileName;

        viewModel.TargetPath = filename;
    }

    private void StartInBrowseButton_Click(object sender, EventArgs e)
    {
        if (BrowseFolderDialog.ShowDialog() != DialogResult.OK)
            return;

        viewModel.StartInPath = BrowseFolderDialog.SelectedPath;
    }

    private void MainTree_KeyDown(object sender, KeyEventArgs e)
    {
        var selectedItem = SelectedLocation();
        if (!selectedItem.Path.Any())
            return;

        switch (e.KeyCode)
        {
            case Keys.Delete:
                DeleteButton_Click();
                return;

            case Keys.F2:
                ShortcutNameTextBox.Focus();
                ShortcutNameTextBox.SelectAll();
                return;
        }
    }

    private void ExecuteShortcutButton_Click(object sender, EventArgs e)
    {
        if (viewModel.CurrentItem is not ShortcutItem shortcut)
            return;

        shortcut.Execute();
    }

    private void UndoButton_Click(object sender, EventArgs e)
    {
        if (UndoRedoManager.Instance.Undo())
            RefreshTree();
    }

    private void RedoButton_Click(object sender, EventArgs e)
    {
        if (UndoRedoManager.Instance.Redo())
            RefreshTree();
    }

    private void UndoButton_DropDownOpening(object sender, EventArgs e)
    {
        UndoButton.DropDownItems.Clear();

        foreach (var frame in UndoRedoManager.Instance.UndoFrames)
            UndoButton.DropDownItems.Add(
                frame.Change.Description,
                Resources.Undo,
                (sender, eventArguments) =>
                {
                    if (UndoRedoManager.Instance.SetFrameIndex(frame.Index - 1))
                        RefreshTree();
                });
    }

    private void RedoButton_DropDownOpening(object sender, EventArgs e)
    {
        RedoButton.DropDownItems.Clear();

        foreach (var frame in UndoRedoManager.Instance.RedoFrames)
            RedoButton.DropDownItems.Add(
                frame.Change.Description,
                Resources.Redo,
                (sender, eventArguments) =>
                {
                    if (UndoRedoManager.Instance.SetFrameIndex(frame.Index))
                        RefreshTree();
                });
    }
}
