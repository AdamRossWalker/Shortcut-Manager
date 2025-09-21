using ShortcutManager.Data;

namespace ShortcutManager;

public partial class MainForm : Form
{
    private const string NewShortcutText = "New Shortcut";
    private const string NewFolderText = "New Folder";

    public MainForm() => InitializeComponent();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        RefreshTree();
        RefreshSelectedShortcut();
    }

    protected override void OnClosed(EventArgs e)
    {
        ShortcutData.Instance.Save();
        base.OnClosed(e);
    }

    private void RefreshTree()
    {
        MainTree.SuspendLayout();
        try
        {

            MainTree.Nodes.Clear();
            AddShortcutsToTree(parent: null, ShortcutData.Instance.Root.Children);
            RefreshSelectedShortcut();
            MainTree.ExpandAll();
        }
        finally 
        {
            MainTree.ResumeLayout();
        }
    }

    private void AddShortcutsToTree(
        TreeNode? parent,
        IEnumerable<IShortcutOrFolder> elements)
    {
        var container = parent?.Nodes ?? MainTree.Nodes;

        foreach (var element in elements)
        {
            var node = new TreeNode(element.Name);

            if (element is ShortcutFolder folder)
                AddShortcutsToTree(node, folder.Children);

            container.Add(node);
        }
    }

    private IEnumerable<(int Index, string Name)> SelectedNodeLocation() =>
        NodeLocation(MainTree.SelectedNode);

    private static IEnumerable<(int Index, string Name)> NodeLocation(TreeNode? node)
    {
        if (node is null)
            yield break;

        foreach (var parentNodes in NodeLocation(node.Parent))
            yield return parentNodes;

        yield return (node.Index, node.Text);
    }

    private void SelectBestNodeFrom(IEnumerable<(int Index, string Name)> nodeLocation)
    {
        var currentNodeCollection = MainTree.Nodes;
        var currentNode = null as TreeNode;

        foreach (var location in nodeLocation)
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

            // Give up, the tree has changed too much.
            break;
        }

        MainTree.SelectedNode = currentNode;
    }

    private IShortcutOrFolder? CurrentItem =>
        ShortcutData.Instance.GetItem(SelectedNodeLocation());

    private void AddShortcutButton_Click(object sender, EventArgs e)
    {
        ShortcutData.Instance.AddItem(
            SelectedNodeLocation(),
            new ShortcutItem
            {
                Name = NewShortcutText,
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
            SelectedNodeLocation(),
            new ShortcutFolder
            {
                Name = NewFolderText,
                Icon = null,
                Children = [],
            });

        RefreshTree();
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        ShortcutData.Instance.DeleteItem(
            SelectedNodeLocation());
        
        RefreshTree();
    }

    private void MainTree_AfterSelect(object sender, TreeViewEventArgs e) =>
        RefreshSelectedShortcut();

    private void RefreshSelectedShortcut()
    {
        var item = CurrentItem;
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

            PathLabel.Visible = isShortcut;
            PathTextBox.Visible = isShortcut;
            PathBrowseButton.Visible = isShortcut;

            ArgumentsLabel.Visible = isShortcut;
            ArgumentsTextBox.Visible = isShortcut;

            StartInLabel.Visible = isShortcut;
            StartInTextBox.Visible = isShortcut;
            StartInBrowseButton.Visible = isShortcut;

            ToolTipLabel.Visible = isEither;
            ToolTipTextBox.Visible = isEither;

            DeleteButton.Visible = isEither;
            MainTreeContextMenuAddDeleteButton.Visible = isEither;

            if (item is not null)
            {
                IconPictureBox.Image = item.Icon?.ToBitmap();
                ShortcutNameTextBox.Text = item.Name;
            }

            if (shortcut is not null)
            {
                PathTextBox.Text = shortcut.TargetPath;
                ArgumentsTextBox.Text = shortcut.Arguments;
                StartInTextBox.Text = shortcut.StartInPath;
                ToolTipTextBox.Text = shortcut.ToolTip;
            }
        }
        finally
        {
            MainTableLayoutPanel.ResumeLayout();
        }
    }

    private void SetName(string? name)
    {
        SetNameDataOnly(name);
        SetNameUiOnly(name);
    }

    private void SetIcon(Icon? icon)
    {
        SetIconDataOnly(icon);
        SetIconUiOnly(icon);
    }

    private void SetPath(string? path)
    {
        SetPathDataOnly(path);
        SetPathUiOnly(path);
    }

    private void SetArguments(string? arguments)
    {
        SetArgumentsDataOnly(arguments);
        SetArgumentsUiOnly(arguments);
    }

    private void SetStartIn(string? startInPath)
    {
        SetStartInDataOnly(startInPath);
        SetStartInUiOnly(startInPath);
    }
    private void SetToolTip(string? toolTip)
    {
        SetToolTipDataOnly(toolTip);
        SetToolTipUiOnly(toolTip);
    }

    private void SetNameDataOnly(string? name)
    {
        var item = CurrentItem;
        if (item is null)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item switch
            {
                ShortcutFolder folder => folder with { Name = name },
                ShortcutItem shortcut => shortcut with { Name = name },
                _ => item,
            });
    }

    private void SetIconDataOnly(Icon? icon)
    {
        var item = CurrentItem;
        if (item is null)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item switch
            {
                ShortcutFolder folder => folder with { Icon = icon },
                ShortcutItem shortcut => shortcut with { Icon = icon },
                _ => item,
            });
    }

    private void SetPathDataOnly(string? path)
    {
        if (CurrentItem is not ShortcutItem item)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item with { TargetPath = path });
    }

    private void SetArgumentsDataOnly(string? arguments)
    {
        if (CurrentItem is not ShortcutItem item)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item with { Arguments = arguments });
    }

    private void SetStartInDataOnly(string? startInPath)
    {
        if (CurrentItem is not ShortcutItem item)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item with { StartInPath = startInPath });
    }
    private void SetToolTipDataOnly(string? toolTip)
    {
        if (CurrentItem is not ShortcutItem item)
            return;

        ShortcutData.Instance.ReplaceItem(
            SelectedNodeLocation(),
            item with { ToolTip = toolTip });
    }

    private void SetNameUiOnly(string? name) =>
        ShortcutNameTextBox.Text = name;

    private void SetIconUiOnly(Icon? icon) =>
        IconPictureBox.Image = icon?.ToBitmap();

    private void SetPathUiOnly(string? path) =>
        PathTextBox.Text = path;

    private void SetArgumentsUiOnly(string? arguments) =>
        ArgumentsTextBox.Text = arguments;

    private void SetStartInUiOnly(string? startInPath) =>
        StartInTextBox.Text = startInPath;

    private void SetToolTipUiOnly(string? toolTip) =>
        ToolTipTextBox.Text = toolTip;

    private void IconBrowseButton_Click(object sender, EventArgs e)
    {
        BrowseFileDialog.Filter = "Icons (*.ico)|Executable File (*.exe;*.com;*.cmd;*.bat)|All Files (*.*)";
        BrowseFileDialog.FilterIndex = 0;

        if (BrowseFileDialog.ShowDialog() != DialogResult.OK)
            return;

        SetIcon(BrowseFileDialog.FileName);
    }

    private void SetIcon(string filename)
    {
        Icon? newIcon;

        var extension = Path.GetExtension(filename).ToUpper();
        if (extension == "EXE" ||
            extension == "COM" ||
            extension == "CMD")
        {
            newIcon = Icon.ExtractAssociatedIcon(filename);
        }
        else if (extension == "ICO")
        {
            newIcon = new Icon(filename);
        }
        else
        {
            newIcon = null;
        }

        SetIcon(newIcon);
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
        BrowseFileDialog.Filter = "Executable File (*.exe;*.com;*.cmd;*.bat)|All Files (*.*)";
        BrowseFileDialog.FilterIndex = 0;

        BrowseFileDialog.DefaultExt = "Executable File (*.exe;*.com;*.cmd;*.bat)";

        if (BrowseFileDialog.ShowDialog() != DialogResult.OK)
            return;

        var filename = BrowseFileDialog.FileName;

        SetPath(filename);

        if (String.IsNullOrWhiteSpace(ShortcutNameTextBox.Text) ||
            ShortcutNameTextBox.Text == NewShortcutText ||
            ShortcutNameTextBox.Text == NewFolderText)
        {
            SetName(Path.GetFileNameWithoutExtension(filename));
        }

        if (String.IsNullOrWhiteSpace(StartInTextBox.Text))
            SetStartIn(Path.GetDirectoryName(filename));

        if (IconPictureBox.Image is null)
            SetIcon(filename);
    }

    private void StartInBrowseButton_Click(object sender, EventArgs e)
    {
        if (BrowseFolderDialog.ShowDialog() != DialogResult.OK)
            return;

        SetStartIn(BrowseFolderDialog.SelectedPath);
    }

    private void ShortcutNameTextBox_TextChanged(object sender, EventArgs e) =>
        SetNameDataOnly(ShortcutNameTextBox.Text);

    private void PathTextBox_TextChanged(object sender, EventArgs e) => 
        SetPathDataOnly(PathTextBox.Text);

    private void ArgumentsTextBox_TextChanged(object sender, EventArgs e) => 
        SetArgumentsDataOnly(ArgumentsTextBox.Text);

    private void StartInTextBox_TextChanged(object sender, EventArgs e) => 
        SetStartInDataOnly(StartInTextBox.Text);

    private void ToolTipTextBox_TextChanged(object sender, EventArgs e) => 
        SetToolTipDataOnly(ToolTipTextBox.Text);
}
