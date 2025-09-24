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
            UndoButton = new ToolStripSplitButton();
            RedoButton = new ToolStripSplitButton();
            IconLabel = new Label();
            TargetPathLabel = new Label();
            ArgumentsLabel = new Label();
            ToolTipLabel = new Label();
            IconPictureBox = new PictureBox();
            TargetPathTextBox = new TextBox();
            ToolTipTextBox = new TextBox();
            ArgumentsTextBox = new TextBox();
            IconBrowseButton = new Button();
            TargetPathBrowseButton = new Button();
            ShortcutNameLabel = new Label();
            ShortcutNameTextBox = new TextBox();
            StartInLabel = new Label();
            StartInTextBox = new TextBox();
            StartInBrowseButton = new Button();
            ExecuteShortcutButton = new Button();
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
            MainTree.HideSelection = false;
            MainTree.Location = new Point(3, 37);
            MainTree.Name = "MainTree";
            MainTableLayoutPanel.SetRowSpan(MainTree, 9);
            MainTree.Size = new Size(320, 410);
            MainTree.TabIndex = 0;
            MainTree.AfterSelect += MainTree_AfterSelect;
            MainTree.KeyDown += MainTree_KeyDown;
            // 
            // MainTreeeMenuStrip
            // 
            MainTreeeMenuStrip.ImageScalingSize = new Size(24, 24);
            MainTreeeMenuStrip.Items.AddRange(new ToolStripItem[] { MainTreeContextMenuAddShortcutButton, MainTreeContextMenuAddFolderButton, MainTreeContextMenuAddDeleteButton });
            MainTreeeMenuStrip.Name = "MainTreeeMenuStrip";
            MainTreeeMenuStrip.Size = new Size(199, 100);
            // 
            // MainTreeContextMenuAddShortcutButton
            // 
            MainTreeContextMenuAddShortcutButton.Image = Properties.Resources.Add;
            MainTreeContextMenuAddShortcutButton.Name = "MainTreeContextMenuAddShortcutButton";
            MainTreeContextMenuAddShortcutButton.Size = new Size(198, 32);
            MainTreeContextMenuAddShortcutButton.Text = "Add Shortcut";
            MainTreeContextMenuAddShortcutButton.Click += AddShortcutButton_Click;
            // 
            // MainTreeContextMenuAddFolderButton
            // 
            MainTreeContextMenuAddFolderButton.Image = Properties.Resources.Add;
            MainTreeContextMenuAddFolderButton.Name = "MainTreeContextMenuAddFolderButton";
            MainTreeContextMenuAddFolderButton.Size = new Size(198, 32);
            MainTreeContextMenuAddFolderButton.Text = "Add Folder";
            MainTreeContextMenuAddFolderButton.Click += AddFolderButton_Click;
            // 
            // MainTreeContextMenuAddDeleteButton
            // 
            MainTreeContextMenuAddDeleteButton.Image = Properties.Resources.Delete;
            MainTreeContextMenuAddDeleteButton.Name = "MainTreeContextMenuAddDeleteButton";
            MainTreeContextMenuAddDeleteButton.Size = new Size(198, 32);
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
            MainTableLayoutPanel.Controls.Add(IconLabel, 1, 2);
            MainTableLayoutPanel.Controls.Add(TargetPathLabel, 1, 4);
            MainTableLayoutPanel.Controls.Add(ArgumentsLabel, 1, 5);
            MainTableLayoutPanel.Controls.Add(ToolTipLabel, 1, 7);
            MainTableLayoutPanel.Controls.Add(IconPictureBox, 2, 1);
            MainTableLayoutPanel.Controls.Add(TargetPathTextBox, 2, 4);
            MainTableLayoutPanel.Controls.Add(ToolTipTextBox, 2, 7);
            MainTableLayoutPanel.Controls.Add(ArgumentsTextBox, 2, 5);
            MainTableLayoutPanel.Controls.Add(IconBrowseButton, 3, 2);
            MainTableLayoutPanel.Controls.Add(TargetPathBrowseButton, 3, 4);
            MainTableLayoutPanel.Controls.Add(ShortcutNameLabel, 1, 3);
            MainTableLayoutPanel.Controls.Add(ShortcutNameTextBox, 2, 3);
            MainTableLayoutPanel.Controls.Add(StartInLabel, 1, 6);
            MainTableLayoutPanel.Controls.Add(StartInTextBox, 2, 6);
            MainTableLayoutPanel.Controls.Add(StartInBrowseButton, 3, 6);
            MainTableLayoutPanel.Controls.Add(ExecuteShortcutButton, 2, 8);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 10;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle());
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(800, 450);
            MainTableLayoutPanel.TabIndex = 0;
            // 
            // MainToolStrip
            // 
            MainTableLayoutPanel.SetColumnSpan(MainToolStrip, 4);
            MainToolStrip.ImageScalingSize = new Size(24, 24);
            MainToolStrip.Items.AddRange(new ToolStripItem[] { AddShortcutButton, AddFolderButton, DeleteButton, UndoButton, RedoButton });
            MainToolStrip.Location = new Point(0, 0);
            MainToolStrip.Name = "MainToolStrip";
            MainToolStrip.Size = new Size(800, 34);
            MainToolStrip.TabIndex = 1;
            MainToolStrip.Text = "MainToolStrip";
            // 
            // AddShortcutButton
            // 
            AddShortcutButton.Image = Properties.Resources.Add;
            AddShortcutButton.ImageTransparentColor = Color.Magenta;
            AddShortcutButton.Name = "AddShortcutButton";
            AddShortcutButton.Size = new Size(146, 29);
            AddShortcutButton.Text = "Add Shortcut";
            AddShortcutButton.Click += AddShortcutButton_Click;
            // 
            // AddFolderButton
            // 
            AddFolderButton.Image = Properties.Resources.Add;
            AddFolderButton.ImageTransparentColor = Color.Magenta;
            AddFolderButton.Name = "AddFolderButton";
            AddFolderButton.Size = new Size(129, 29);
            AddFolderButton.Text = "Add Folder";
            AddFolderButton.Click += AddFolderButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Image = Properties.Resources.Delete;
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(90, 29);
            DeleteButton.Text = "Delete";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UndoButton
            // 
            UndoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            UndoButton.Image = Properties.Resources.Undo;
            UndoButton.ImageTransparentColor = Color.Magenta;
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(45, 29);
            UndoButton.Text = "Undo";
            UndoButton.ButtonClick += UndoButton_Click;
            UndoButton.DropDownOpening += UndoButton_DropDownOpening;
            // 
            // RedoButton
            // 
            RedoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            RedoButton.Image = Properties.Resources.Redo;
            RedoButton.ImageTransparentColor = Color.Magenta;
            RedoButton.Name = "RedoButton";
            RedoButton.Size = new Size(45, 29);
            RedoButton.Text = "Redo";
            RedoButton.ButtonClick += RedoButton_Click;
            RedoButton.DropDownOpening += RedoButton_DropDownOpening;
            // 
            // IconLabel
            // 
            IconLabel.AutoSize = true;
            IconLabel.Dock = DockStyle.Fill;
            IconLabel.Location = new Point(329, 111);
            IconLabel.Name = "IconLabel";
            IconLabel.Size = new Size(100, 41);
            IconLabel.TabIndex = 1;
            IconLabel.Text = "Icon";
            IconLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TargetPathLabel
            // 
            TargetPathLabel.AutoSize = true;
            TargetPathLabel.Dock = DockStyle.Fill;
            TargetPathLabel.Location = new Point(329, 189);
            TargetPathLabel.Name = "TargetPathLabel";
            TargetPathLabel.Size = new Size(100, 41);
            TargetPathLabel.TabIndex = 5;
            TargetPathLabel.Text = "Target Path";
            TargetPathLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ArgumentsLabel
            // 
            ArgumentsLabel.AutoSize = true;
            ArgumentsLabel.Dock = DockStyle.Fill;
            ArgumentsLabel.Location = new Point(329, 230);
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
            ToolTipLabel.Location = new Point(329, 308);
            ToolTipLabel.Name = "ToolTipLabel";
            ToolTipLabel.Size = new Size(100, 37);
            ToolTipLabel.TabIndex = 13;
            ToolTipLabel.Text = "ToolTip";
            ToolTipLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IconPictureBox
            // 
            IconPictureBox.Dock = DockStyle.Fill;
            IconPictureBox.Location = new Point(435, 37);
            IconPictureBox.Name = "IconPictureBox";
            MainTableLayoutPanel.SetRowSpan(IconPictureBox, 2);
            IconPictureBox.Size = new Size(321, 112);
            IconPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            IconPictureBox.TabIndex = 6;
            IconPictureBox.TabStop = false;
            // 
            // TargetPathTextBox
            // 
            TargetPathTextBox.Dock = DockStyle.Fill;
            TargetPathTextBox.Location = new Point(435, 192);
            TargetPathTextBox.MaxLength = 255;
            TargetPathTextBox.Name = "TargetPathTextBox";
            TargetPathTextBox.Size = new Size(321, 31);
            TargetPathTextBox.TabIndex = 6;
            // 
            // ToolTipTextBox
            // 
            ToolTipTextBox.Dock = DockStyle.Fill;
            ToolTipTextBox.Location = new Point(435, 311);
            ToolTipTextBox.MaxLength = 255;
            ToolTipTextBox.Name = "ToolTipTextBox";
            ToolTipTextBox.Size = new Size(321, 31);
            ToolTipTextBox.TabIndex = 14;
            // 
            // ArgumentsTextBox
            // 
            ArgumentsTextBox.Dock = DockStyle.Fill;
            ArgumentsTextBox.Location = new Point(435, 233);
            ArgumentsTextBox.MaxLength = 255;
            ArgumentsTextBox.Name = "ArgumentsTextBox";
            ArgumentsTextBox.Size = new Size(321, 31);
            ArgumentsTextBox.TabIndex = 9;
            // 
            // IconBrowseButton
            // 
            IconBrowseButton.AutoSize = true;
            IconBrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            IconBrowseButton.Dock = DockStyle.Fill;
            IconBrowseButton.Location = new Point(762, 114);
            IconBrowseButton.Name = "IconBrowseButton";
            IconBrowseButton.Size = new Size(35, 35);
            IconBrowseButton.TabIndex = 2;
            IconBrowseButton.Text = "...";
            IconBrowseButton.UseVisualStyleBackColor = true;
            IconBrowseButton.Click += IconBrowseButton_Click;
            // 
            // TargetPathBrowseButton
            // 
            TargetPathBrowseButton.AutoSize = true;
            TargetPathBrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TargetPathBrowseButton.Dock = DockStyle.Fill;
            TargetPathBrowseButton.Location = new Point(762, 192);
            TargetPathBrowseButton.Name = "TargetPathBrowseButton";
            TargetPathBrowseButton.Size = new Size(35, 35);
            TargetPathBrowseButton.TabIndex = 7;
            TargetPathBrowseButton.Text = "...";
            TargetPathBrowseButton.UseVisualStyleBackColor = true;
            TargetPathBrowseButton.Click += PathBrowseButton_Click;
            // 
            // ShortcutNameLabel
            // 
            ShortcutNameLabel.AutoSize = true;
            ShortcutNameLabel.Dock = DockStyle.Fill;
            ShortcutNameLabel.Location = new Point(329, 152);
            ShortcutNameLabel.Name = "ShortcutNameLabel";
            ShortcutNameLabel.Size = new Size(100, 37);
            ShortcutNameLabel.TabIndex = 3;
            ShortcutNameLabel.Text = "Name";
            ShortcutNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ShortcutNameTextBox
            // 
            ShortcutNameTextBox.Dock = DockStyle.Fill;
            ShortcutNameTextBox.Location = new Point(435, 155);
            ShortcutNameTextBox.MaxLength = 255;
            ShortcutNameTextBox.Name = "ShortcutNameTextBox";
            ShortcutNameTextBox.Size = new Size(321, 31);
            ShortcutNameTextBox.TabIndex = 4;
            // 
            // StartInLabel
            // 
            StartInLabel.AutoSize = true;
            StartInLabel.Dock = DockStyle.Fill;
            StartInLabel.Location = new Point(329, 267);
            StartInLabel.Name = "StartInLabel";
            StartInLabel.Size = new Size(100, 41);
            StartInLabel.TabIndex = 10;
            StartInLabel.Text = "Start In";
            StartInLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StartInTextBox
            // 
            StartInTextBox.Dock = DockStyle.Fill;
            StartInTextBox.Location = new Point(435, 270);
            StartInTextBox.MaxLength = 255;
            StartInTextBox.Name = "StartInTextBox";
            StartInTextBox.Size = new Size(321, 31);
            StartInTextBox.TabIndex = 11;
            // 
            // StartInBrowseButton
            // 
            StartInBrowseButton.AutoSize = true;
            StartInBrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartInBrowseButton.Dock = DockStyle.Fill;
            StartInBrowseButton.Location = new Point(762, 270);
            StartInBrowseButton.Name = "StartInBrowseButton";
            StartInBrowseButton.Size = new Size(35, 35);
            StartInBrowseButton.TabIndex = 12;
            StartInBrowseButton.Text = "...";
            StartInBrowseButton.UseVisualStyleBackColor = true;
            StartInBrowseButton.Click += StartInBrowseButton_Click;
            // 
            // ExecuteShortcutButton
            // 
            ExecuteShortcutButton.AutoSize = true;
            ExecuteShortcutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ExecuteShortcutButton.Dock = DockStyle.Fill;
            ExecuteShortcutButton.Location = new Point(435, 348);
            ExecuteShortcutButton.Name = "ExecuteShortcutButton";
            ExecuteShortcutButton.Size = new Size(321, 44);
            ExecuteShortcutButton.TabIndex = 15;
            ExecuteShortcutButton.Text = "Execute";
            ExecuteShortcutButton.UseVisualStyleBackColor = true;
            ExecuteShortcutButton.Click += ExecuteShortcutButton_Click;
            // 
            // BrowseFileDialog
            // 
            BrowseFileDialog.DefaultExt = "exe";
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
        private Label TargetPathLabel;
        private Label ArgumentsLabel;
        private Label ToolTipLabel;
        private PictureBox IconPictureBox;
        private TextBox TargetPathTextBox;
        private TextBox ToolTipTextBox;
        private TextBox ArgumentsTextBox;
        private Button IconBrowseButton;
        private Button TargetPathBrowseButton;
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
        private Button ExecuteShortcutButton;
        private ToolStripSplitButton UndoButton;
        private ToolStripSplitButton RedoButton;
    }
}
