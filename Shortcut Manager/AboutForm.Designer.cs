namespace ShortcutManager;

partial class AboutForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
        tableLayoutPanel1 = new TableLayoutPanel();
        MainPictureBox = new PictureBox();
        VersionLabel = new Label();
        TitleLabel = new Label();
        CloseButton = new Button();
        DetailsTextBox = new TextBox();
        ProjectLinkLabel = new LinkLabel();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(MainPictureBox, 0, 0);
        tableLayoutPanel1.Controls.Add(VersionLabel, 1, 1);
        tableLayoutPanel1.Controls.Add(TitleLabel, 1, 0);
        tableLayoutPanel1.Controls.Add(CloseButton, 0, 4);
        tableLayoutPanel1.Controls.Add(DetailsTextBox, 1, 2);
        tableLayoutPanel1.Controls.Add(ProjectLinkLabel, 1, 3);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 5;
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.Size = new Size(826, 433);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // MainPictureBox
        // 
        MainPictureBox.Dock = DockStyle.Fill;
        MainPictureBox.Image = Properties.Resources.Shortcut_Manager_256;
        MainPictureBox.Location = new Point(0, 0);
        MainPictureBox.Margin = new Padding(0);
        MainPictureBox.Name = "MainPictureBox";
        tableLayoutPanel1.SetRowSpan(MainPictureBox, 4);
        MainPictureBox.Size = new Size(256, 372);
        MainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        MainPictureBox.TabIndex = 0;
        MainPictureBox.TabStop = false;
        // 
        // VersionLabel
        // 
        VersionLabel.AutoSize = true;
        VersionLabel.Dock = DockStyle.Fill;
        VersionLabel.Font = new Font("Segoe UI", 15F);
        VersionLabel.Location = new Point(261, 46);
        VersionLabel.Margin = new Padding(5, 0, 5, 0);
        VersionLabel.Name = "VersionLabel";
        VersionLabel.Size = new Size(560, 41);
        VersionLabel.TabIndex = 1;
        VersionLabel.Text = "Version";
        VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // TitleLabel
        // 
        TitleLabel.AutoSize = true;
        TitleLabel.Dock = DockStyle.Fill;
        TitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        TitleLabel.Location = new Point(261, 5);
        TitleLabel.Margin = new Padding(5, 5, 5, 0);
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Size = new Size(560, 41);
        TitleLabel.TabIndex = 3;
        TitleLabel.Text = "Shortcut Manager";
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // CloseButton
        // 
        CloseButton.AutoSize = true;
        CloseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tableLayoutPanel1.SetColumnSpan(CloseButton, 2);
        CloseButton.Dock = DockStyle.Fill;
        CloseButton.Location = new Point(3, 375);
        CloseButton.Name = "CloseButton";
        CloseButton.Padding = new Padding(10);
        CloseButton.Size = new Size(820, 55);
        CloseButton.TabIndex = 4;
        CloseButton.Text = "Close";
        CloseButton.UseVisualStyleBackColor = true;
        // 
        // DetailsTextBox
        // 
        DetailsTextBox.BorderStyle = BorderStyle.None;
        DetailsTextBox.Dock = DockStyle.Fill;
        DetailsTextBox.Location = new Point(261, 92);
        DetailsTextBox.Margin = new Padding(5);
        DetailsTextBox.Multiline = true;
        DetailsTextBox.Name = "DetailsTextBox";
        DetailsTextBox.ReadOnly = true;
        DetailsTextBox.ScrollBars = ScrollBars.Vertical;
        DetailsTextBox.Size = new Size(560, 240);
        DetailsTextBox.TabIndex = 5;
        DetailsTextBox.Text = resources.GetString("DetailsTextBox.Text");
        // 
        // ProjectLinkLabel
        // 
        ProjectLinkLabel.AutoEllipsis = true;
        ProjectLinkLabel.AutoSize = true;
        ProjectLinkLabel.Dock = DockStyle.Fill;
        ProjectLinkLabel.Location = new Point(259, 337);
        ProjectLinkLabel.Name = "ProjectLinkLabel";
        ProjectLinkLabel.Padding = new Padding(5);
        ProjectLinkLabel.Size = new Size(564, 35);
        ProjectLinkLabel.TabIndex = 6;
        ProjectLinkLabel.TabStop = true;
        ProjectLinkLabel.Text = "https://github.com/AdamRossWalker/Shortcut-Manager";
        ProjectLinkLabel.LinkClicked += ProjectLinkLabel_LinkClicked;
        // 
        // AboutForm
        // 
        AcceptButton = CloseButton;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = CloseButton;
        ClientSize = new Size(826, 433);
        Controls.Add(tableLayoutPanel1);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "AboutForm";
        Text = "About";
        Load += AboutForm_Load;
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private PictureBox MainPictureBox;
    private Label VersionLabel;
    private Label TitleLabel;
    private Button CloseButton;
    private TextBox DetailsTextBox;
    private LinkLabel ProjectLinkLabel;
}