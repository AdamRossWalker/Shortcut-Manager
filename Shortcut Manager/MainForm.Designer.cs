namespace ShortcutManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainTree = new TreeView();
            MainTreeeMenuStrip = new ContextMenuStrip(components);
            MainTreeContextMenuAddShortcutButton = new ToolStripMenuItem();
            MainTreeContextMenuAddFolderButton = new ToolStripMenuItem();
            MainTreeContextMenuAddDeleteButton = new ToolStripMenuItem();
            MainTableLayoutPanel = new TableLayoutPanel();
            MainToolStrip = new ToolStrip();
            AddShortcutButton = new ToolStripButton();
            AddFolderButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            IconLabel = new Label();
            PathLabel = new Label();
            ArgumentsLabel = new Label();
            ToolTipLabel = new Label();
            IconPictureBox = new PictureBox();
            PathTextBox = new TextBox();
            ToolTipTextBox = new TextBox();
            ArgumentsTextBox = new TextBox();
            IconBrowseButton = new Button();
            PathBrowseButton = new Button();
            ShortcutNameLabel = new Label();
            ShortcutNameTextBox = new TextBox();
            StartInLabel = new Label();
            StartInTextBox = new TextBox();
            StartInBrowseButton = new Button();
            BrowseFileDialog = new OpenFileDialog();
            BrowseFolderDialog = new FolderBrowserDialog();
            MainTreeeMenuStrip.SuspendLayout();
            MainTableLayoutPanel.SuspendLayout();
            MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // MainTree
            // 
            MainTree.ContextMenuStrip = MainTreeeMenuStrip;
            MainTree.Dock = DockStyle.Fill;
            MainTree.Location = new Point(3, 37);
            MainTree.Name = "MainTree";
            MainTableLayoutPanel.SetRowSpan(MainTree, 7);
            MainTree.Size = new Size(319, 410);
            MainTree.TabIndex = 0;
            MainTree.AfterSelect += MainTree_AfterSelect;
            // 
            // MainTreeeMenuStrip
            // 
            MainTreeeMenuStrip.ImageScalingSize = new Size(24, 24);
            MainTreeeMenuStrip.Items.AddRange(new ToolStripItem[] { MainTreeContextMenuAddShortcutButton, MainTreeContextMenuAddFolderButton, MainTreeContextMenuAddDeleteButton });
            MainTreeeMenuStrip.Name = "MainTreeeMenuStrip";
            MainTreeeMenuStrip.Size = new Size(191, 100);
            // 
            // MainTreeContextMenuAddShortcutButton
            // 
            MainTreeContextMenuAddShortcutButton.Name = "MainTreeContextMenuAddShortcutButton";
            MainTreeContextMenuAddShortcutButton.Size = new Size(190, 32);
            MainTreeContextMenuAddShortcutButton.Text = "Add Shortcut";
            MainTreeContextMenuAddShortcutButton.Click += AddShortcutButton_Click;
            // 
            // MainTreeContextMenuAddFolderButton
            // 
            MainTreeContextMenuAddFolderButton.Name = "MainTreeContextMenuAddFolderButton";
            MainTreeContextMenuAddFolderButton.Size = new Size(190, 32);
            MainTreeContextMenuAddFolderButton.Text = "Add Folder";
            MainTreeContextMenuAddFolderButton.Click += AddFolderButton_Click;
            // 
            // MainTreeContextMenuAddDeleteButton
            // 
            MainTreeContextMenuAddDeleteButton.Name = "MainTreeContextMenuAddDeleteButton";
            MainTreeContextMenuAddDeleteButton.Size = new Size(190, 32);
            MainTreeContextMenuAddDeleteButton.Text = "Delete";
            MainTreeContextMenuAddDeleteButton.Click += DeleteButton_Click;
            // 
            // MainTableLayoutPanel
            // 
            MainTableLayoutPanel.ColumnCount = 4;
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.99999F));
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            MainTableLayoutPanel.Controls.Add(MainTree, 0, 1);
            MainTableLayoutPanel.Controls.Add(MainToolStrip, 0, 0);
            MainTableLayoutPanel.Controls.Add(IconLabel, 1, 1);
            MainTableLayoutPanel.Controls.Add(PathLabel, 1, 3);
            MainTableLayoutPanel.Controls.Add(ArgumentsLabel, 1, 4);
            MainTableLayoutPanel.Controls.Add(ToolTipLabel, 1, 6);
            MainTableLayoutPanel.Controls.Add(IconPictureBox, 2, 1);
            MainTableLayoutPanel.Controls.Add(PathTextBox, 2, 3);
            MainTableLayoutPanel.Controls.Add(ToolTipTextBox, 2, 6);
            MainTableLayoutPanel.Controls.Add(ArgumentsTextBox, 2, 4);
            MainTableLayoutPanel.Controls.Add(IconBrowseButton, 3, 1);
            MainTableLayoutPanel.Controls.Add(PathBrowseButton, 3, 3);
            MainTableLayoutPanel.Controls.Add(ShortcutNameLabel, 1, 2);
            MainTableLayoutPanel.Controls.Add(ShortcutNameTextBox, 2, 2);
            MainTableLayoutPanel.Controls.Add(StartInLabel, 1, 5);
            MainTableLayoutPanel.Controls.Add(StartInTextBox, 2, 5);
            MainTableLayoutPanel.Controls.Add(StartInBrowseButton, 3, 5);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 8;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(800, 450);
            MainTableLayoutPanel.TabIndex = 0;
            // 
            // MainToolStrip
            // 
            MainTableLayoutPanel.SetColumnSpan(MainToolStrip, 4);
            MainToolStrip.ImageScalingSize = new Size(24, 24);
            MainToolStrip.Items.AddRange(new ToolStripItem[] { AddShortcutButton, AddFolderButton, DeleteButton });
            MainToolStrip.Location = new Point(0, 0);
            MainToolStrip.Name = "MainToolStrip";
            MainToolStrip.Size = new Size(800, 34);
            MainToolStrip.TabIndex = 1;
            MainToolStrip.Text = "MainToolStrip";
            // 
            // AddShortcutButton
            // 
            AddShortcutButton.Image = (Image)resources.GetObject("AddShortcutButton.Image");
            AddShortcutButton.ImageTransparentColor = Color.Magenta;
            AddShortcutButton.Name = "AddShortcutButton";
            AddShortcutButton.Size = new Size(146, 29);
            AddShortcutButton.Text = "Add Shortcut";
            AddShortcutButton.Click += AddShortcutButton_Click;
            // 
            // AddFolderButton
            // 
            AddFolderButton.Image = (Image)resources.GetObject("AddFolderButton.Image");
            AddFolderButton.ImageTransparentColor = Color.Magenta;
            AddFolderButton.Name = "AddFolderButton";
            AddFolderButton.Size = new Size(129, 29);
            AddFolderButton.Text = "Add Folder";
            AddFolderButton.Click += AddFolderButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(90, 29);
            DeleteButton.Text = "Delete";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // IconLabel
            // 
            IconLabel.AutoSize = true;
            IconLabel.Dock = DockStyle.Fill;
            IconLabel.Location = new Point(328, 34);
            IconLabel.Name = "IconLabel";
            IconLabel.Size = new Size(100, 118);
            IconLabel.TabIndex = 1;
            IconLabel.Text = "Icon";
            IconLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PathLabel
            // 
            PathLabel.AutoSize = true;
            PathLabel.Dock = DockStyle.Fill;
            PathLabel.Location = new Point(328, 189);
            PathLabel.Name = "PathLabel";
            PathLabel.Size = new Size(100, 42);
            PathLabel.TabIndex = 5;
            PathLabel.Text = "Path";
            PathLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ArgumentsLabel
            // 
            ArgumentsLabel.AutoSize = true;
            ArgumentsLabel.Dock = DockStyle.Fill;
            ArgumentsLabel.Location = new Point(328, 231);
            ArgumentsLabel.Name = "ArgumentsLabel";
            ArgumentsLabel.Size = new Size(100, 37);
            ArgumentsLabel.TabIndex = 8;
            ArgumentsLabel.Text = "Arguments";
            ArgumentsLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ToolTipLabel
            // 
            ToolTipLabel.AutoSize = true;
            ToolTipLabel.Dock = DockStyle.Fill;
            ToolTipLabel.Location = new Point(328, 310);
            ToolTipLabel.Name = "ToolTipLabel";
            ToolTipLabel.Size = new Size(100, 37);
            ToolTipLabel.TabIndex = 13;
            ToolTipLabel.Text = "ToolTip";
            ToolTipLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IconPictureBox
            // 
            IconPictureBox.Anchor = AnchorStyles.Left;
            IconPictureBox.Location = new Point(434, 37);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(121, 112);
            IconPictureBox.TabIndex = 6;
            IconPictureBox.TabStop = false;
            // 
            // PathTextBox
            // 
            PathTextBox.Dock = DockStyle.Fill;
            PathTextBox.Location = new Point(434, 192);
            PathTextBox.MaxLength = 255;
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(320, 31);
            PathTextBox.TabIndex = 6;
            // 
            // ToolTipTextBox
            // 
            ToolTipTextBox.Dock = DockStyle.Fill;
            ToolTipTextBox.Location = new Point(434, 313);
            ToolTipTextBox.MaxLength = 255;
            ToolTipTextBox.Name = "ToolTipTextBox";
            ToolTipTextBox.Size = new Size(320, 31);
            ToolTipTextBox.TabIndex = 14;
            // 
            // ArgumentsTextBox
            // 
            ArgumentsTextBox.Dock = DockStyle.Fill;
            ArgumentsTextBox.Location = new Point(434, 234);
            ArgumentsTextBox.MaxLength = 255;
            ArgumentsTextBox.Name = "ArgumentsTextBox";
            ArgumentsTextBox.Size = new Size(320, 31);
            ArgumentsTextBox.TabIndex = 9;
            // 
            // IconBrowseButton
            // 
            IconBrowseButton.Anchor = AnchorStyles.Left;
            IconBrowseButton.Location = new Point(760, 75);
            IconBrowseButton.Name = "IconBrowseButton";
            IconBrowseButton.Size = new Size(36, 36);
            IconBrowseButton.TabIndex = 2;
            IconBrowseButton.Text = "...";
            IconBrowseButton.UseVisualStyleBackColor = true;
            IconBrowseButton.Click += IconBrowseButton_Click;
            // 
            // PathBrowseButton
            // 
            PathBrowseButton.Anchor = AnchorStyles.Left;
            PathBrowseButton.AutoSize = true;
            PathBrowseButton.Location = new Point(760, 192);
            PathBrowseButton.Name = "PathBrowseButton";
            PathBrowseButton.Size = new Size(36, 36);
            PathBrowseButton.TabIndex = 7;
            PathBrowseButton.Text = "...";
            PathBrowseButton.UseVisualStyleBackColor = true;
            PathBrowseButton.Click += PathBrowseButton_Click;
            // 
            // ShortcutNameLabel
            // 
            ShortcutNameLabel.AutoSize = true;
            ShortcutNameLabel.Dock = DockStyle.Fill;
            ShortcutNameLabel.Location = new Point(328, 152);
            ShortcutNameLabel.Name = "ShortcutNameLabel";
            ShortcutNameLabel.Size = new Size(100, 37);
            ShortcutNameLabel.TabIndex = 3;
            ShortcutNameLabel.Text = "Name";
            ShortcutNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ShortcutNameTextBox
            // 
            ShortcutNameTextBox.Dock = DockStyle.Fill;
            ShortcutNameTextBox.Location = new Point(434, 155);
            ShortcutNameTextBox.MaxLength = 255;
            ShortcutNameTextBox.Name = "ShortcutNameTextBox";
            ShortcutNameTextBox.Size = new Size(320, 31);
            ShortcutNameTextBox.TabIndex = 4;
            // 
            // StartInLabel
            // 
            StartInLabel.AutoSize = true;
            StartInLabel.Dock = DockStyle.Fill;
            StartInLabel.Location = new Point(328, 268);
            StartInLabel.Name = "StartInLabel";
            StartInLabel.Size = new Size(100, 42);
            StartInLabel.TabIndex = 10;
            StartInLabel.Text = "Start In";
            StartInLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StartInTextBox
            // 
            StartInTextBox.Dock = DockStyle.Fill;
            StartInTextBox.Location = new Point(434, 271);
            StartInTextBox.MaxLength = 255;
            StartInTextBox.Name = "StartInTextBox";
            StartInTextBox.Size = new Size(320, 31);
            StartInTextBox.TabIndex = 11;
            // 
            // StartInBrowseButton
            // 
            StartInBrowseButton.Anchor = AnchorStyles.Left;
            StartInBrowseButton.Location = new Point(760, 271);
            StartInBrowseButton.Name = "StartInBrowseButton";
            StartInBrowseButton.Size = new Size(36, 36);
            StartInBrowseButton.TabIndex = 12;
            StartInBrowseButton.Text = "...";
            StartInBrowseButton.UseVisualStyleBackColor = true;
            StartInBrowseButton.Click += StartInBrowseButton_Click;
            // 
            // BrowseFileDialog
            // 
            BrowseFileDialog.DefaultExt = "exe";
            BrowseFileDialog.FileName = "*.exe";
            BrowseFileDialog.RestoreDirectory = true;
            BrowseFileDialog.Title = "Browse...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainTableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Shortcut Manager";
            MainTreeeMenuStrip.ResumeLayout(false);
            MainTableLayoutPanel.ResumeLayout(false);
            MainTableLayoutPanel.PerformLayout();
            MainToolStrip.ResumeLayout(false);
            MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TreeView MainTree;
        private TableLayoutPanel MainTableLayoutPanel;
        private ToolStrip MainToolStrip;
        private ToolStripButton AddShortcutButton;
        private ToolStripButton AddFolderButton;
        private ToolStripButton DeleteButton;
        private Label IconLabel;
        private Label PathLabel;
        private Label ArgumentsLabel;
        private Label ToolTipLabel;
        private PictureBox IconPictureBox;
        private TextBox PathTextBox;
        private TextBox ToolTipTextBox;
        private TextBox ArgumentsTextBox;
        private Button IconBrowseButton;
        private Button PathBrowseButton;
        private ContextMenuStrip MainTreeeMenuStrip;
        private ToolStripMenuItem MainTreeContextMenuAddShortcutButton;
        private ToolStripMenuItem MainTreeContextMenuAddFolderButton;
        private ToolStripMenuItem MainTreeContextMenuAddDeleteButton;
        private Label ShortcutNameLabel;
        private TextBox ShortcutNameTextBox;
        private OpenFileDialog BrowseFileDialog;
        private Label StartInLabel;
        private TextBox StartInTextBox;
        private Button StartInBrowseButton;
        private FolderBrowserDialog BrowseFolderDialog;
    }
}
