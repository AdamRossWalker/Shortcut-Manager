namespace ShortcutManager;

public partial class AboutForm : Form
{
    public AboutForm() => 
        InitializeComponent();

    private void AboutForm_Load(object sender, EventArgs e) => 
        VersionLabel.Text = Application.ProductVersion;
}
