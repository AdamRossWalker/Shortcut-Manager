using System.Diagnostics;

namespace ShortcutManager;

public partial class AboutForm : Form
{
    public AboutForm() =>
        InitializeComponent();

    private void AboutForm_Load(object sender, EventArgs e) =>
        VersionLabel.Text = Application.ProductVersion;

    private void ProjectLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
        Process.Start(
            new ProcessStartInfo
            {
                FileName = ProjectLinkLabel.Text,
                UseShellExecute = true,
            });
}
