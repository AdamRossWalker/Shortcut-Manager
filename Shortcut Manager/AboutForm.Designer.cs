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
        DetailsLabel = new Label();
        TitleLabel = new Label();
        CloseButton = new Button();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.Controls.Add(MainPictureBox, 0, 0);
        tableLayoutPanel1.Controls.Add(VersionLabel, 1, 1);
        tableLayoutPanel1.Controls.Add(DetailsLabel, 1, 2);
        tableLayoutPanel1.Controls.Add(TitleLabel, 1, 0);
        tableLayoutPanel1.Controls.Add(CloseButton, 1, 3);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.Size = new Size(740, 433);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // MainPictureBox
        // 
        MainPictureBox.Dock = DockStyle.Fill;
        MainPictureBox.Image = Properties.Resources.Shortcut_Manager_256;
        MainPictureBox.Location = new Point(3, 3);
        MainPictureBox.Name = "MainPictureBox";
        tableLayoutPanel1.SetRowSpan(MainPictureBox, 4);
        MainPictureBox.Size = new Size(414, 427);
        MainPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        MainPictureBox.TabIndex = 0;
        MainPictureBox.TabStop = false;
        // 
        // VersionLabel
        // 
        VersionLabel.AutoSize = true;
        VersionLabel.Dock = DockStyle.Fill;
        VersionLabel.Font = new Font("Segoe UI", 15F);
        VersionLabel.Location = new Point(423, 206);
        VersionLabel.Name = "VersionLabel";
        VersionLabel.Padding = new Padding(20);
        VersionLabel.Size = new Size(314, 81);
        VersionLabel.TabIndex = 1;
        VersionLabel.Text = "Version";
        VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // DetailsLabel
        // 
        DetailsLabel.AutoSize = true;
        DetailsLabel.Dock = DockStyle.Fill;
        DetailsLabel.Location = new Point(423, 287);
        DetailsLabel.Name = "DetailsLabel";
        DetailsLabel.Padding = new Padding(20);
        DetailsLabel.Size = new Size(314, 65);
        DetailsLabel.TabIndex = 2;
        DetailsLabel.Text = "Adam Walker 2025";
        DetailsLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // TitleLabel
        // 
        TitleLabel.AutoSize = true;
        TitleLabel.Dock = DockStyle.Fill;
        TitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        TitleLabel.Location = new Point(423, 0);
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Padding = new Padding(20);
        TitleLabel.Size = new Size(314, 206);
        TitleLabel.TabIndex = 3;
        TitleLabel.Text = "Shortcut Manager";
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // CloseButton
        // 
        CloseButton.AutoSize = true;
        CloseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        CloseButton.Dock = DockStyle.Fill;
        CloseButton.Location = new Point(423, 355);
        CloseButton.Name = "CloseButton";
        CloseButton.Padding = new Padding(20);
        CloseButton.Size = new Size(314, 75);
        CloseButton.TabIndex = 4;
        CloseButton.Text = "Close";
        CloseButton.UseVisualStyleBackColor = true;
        // 
        // AboutForm
        // 
        AcceptButton = CloseButton;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = CloseButton;
        ClientSize = new Size(740, 433);
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
    private Label DetailsLabel;
    private Label TitleLabel;
    private Button CloseButton;
}