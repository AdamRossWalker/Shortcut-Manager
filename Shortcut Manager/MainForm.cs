

namespace ShortcutManager;

public partial class MainForm : Form
{
    public MainForm() => InitializeComponent();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        RefreshTree();
    }

    private void RefreshTree()
    {
        MainTree.Nodes.Clear();
        AddShortcutsToTree(parent: null, Shortcuts.Instance.TreeElements);
    }

    private void AddShortcutsToTree(
        TreeNode? parent,
        List<ITreeElement> elements)
    {
        var container = parent?.Nodes ?? MainTree.Nodes;

        foreach (var element in elements)
        {
            var node = new TreeNode(element.Name);

            if (element is ShortcutFolder folder)
                AddShortcutsToTree(node, folder.Children);

            container.Add(node);
        }

        container.Add("New...");
    }
}
