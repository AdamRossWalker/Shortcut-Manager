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
            tableLayoutPanel1 = new TableLayoutPanel();
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
            BrowseIconButton = new Button();
            BrowsePathButton = new Button();
            MainTreeeMenuStrip = new ContextMenuStrip(components);
            MainTreeContextMenuAddShortcutButton = new ToolStripMenuItem();
            MainTreeContextMenuAddFolderButton = new ToolStripMenuItem();
            MainTreeContextMenuAddDeleteButton = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            MainTreeeMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainTree
            // 
            MainTree.ContextMenuStrip = MainTreeeMenuStrip;
            MainTree.Dock = DockStyle.Fill;
            MainTree.Location = new Point(3, 37);
            MainTree.Name = "MainTree";
            tableLayoutPanel1.SetRowSpan(MainTree, 5);
            MainTree.Size = new Size(319, 410);
            MainTree.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999924F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000038F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(MainTree, 0, 1);
            tableLayoutPanel1.Controls.Add(MainToolStrip, 0, 0);
            tableLayoutPanel1.Controls.Add(IconLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(PathLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(ArgumentsLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(ToolTipLabel, 1, 4);
            tableLayoutPanel1.Controls.Add(IconPictureBox, 2, 1);
            tableLayoutPanel1.Controls.Add(PathTextBox, 2, 2);
            tableLayoutPanel1.Controls.Add(ToolTipTextBox, 2, 4);
            tableLayoutPanel1.Controls.Add(ArgumentsTextBox, 2, 3);
            tableLayoutPanel1.Controls.Add(BrowseIconButton, 3, 1);
            tableLayoutPanel1.Controls.Add(BrowsePathButton, 3, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // MainToolStrip
            // 
            tableLayoutPanel1.SetColumnSpan(MainToolStrip, 4);
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
            // 
            // AddFolderButton
            // 
            AddFolderButton.Image = (Image)resources.GetObject("AddFolderButton.Image");
            AddFolderButton.ImageTransparentColor = Color.Magenta;
            AddFolderButton.Name = "AddFolderButton";
            AddFolderButton.Size = new Size(129, 29);
            AddFolderButton.Text = "Add Folder";
            // 
            // DeleteButton
            // 
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(90, 29);
            DeleteButton.Text = "Delete";
            // 
            // IconLabel
            // 
            IconLabel.AutoSize = true;
            IconLabel.Dock = DockStyle.Fill;
            IconLabel.Location = new Point(328, 34);
            IconLabel.Name = "IconLabel";
            IconLabel.Size = new Size(100, 118);
            IconLabel.TabIndex = 2;
            IconLabel.Text = "Icon";
            IconLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PathLabel
            // 
            PathLabel.AutoSize = true;
            PathLabel.Dock = DockStyle.Fill;
            PathLabel.Location = new Point(328, 152);
            PathLabel.Name = "PathLabel";
            PathLabel.Size = new Size(100, 42);
            PathLabel.TabIndex = 3;
            PathLabel.Text = "Path";
            PathLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ArgumentsLabel
            // 
            ArgumentsLabel.AutoSize = true;
            ArgumentsLabel.Dock = DockStyle.Fill;
            ArgumentsLabel.Location = new Point(328, 194);
            ArgumentsLabel.Name = "ArgumentsLabel";
            ArgumentsLabel.Size = new Size(100, 37);
            ArgumentsLabel.TabIndex = 4;
            ArgumentsLabel.Text = "Arguments";
            ArgumentsLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ToolTipLabel
            // 
            ToolTipLabel.AutoSize = true;
            ToolTipLabel.Dock = DockStyle.Fill;
            ToolTipLabel.Location = new Point(328, 231);
            ToolTipLabel.Name = "ToolTipLabel";
            ToolTipLabel.Size = new Size(100, 37);
            ToolTipLabel.TabIndex = 5;
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
            PathTextBox.Location = new Point(434, 155);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(320, 31);
            PathTextBox.TabIndex = 7;
            // 
            // ToolTipTextBox
            // 
            ToolTipTextBox.Dock = DockStyle.Fill;
            ToolTipTextBox.Location = new Point(434, 234);
            ToolTipTextBox.Name = "ToolTipTextBox";
            ToolTipTextBox.Size = new Size(320, 31);
            ToolTipTextBox.TabIndex = 8;
            // 
            // ArgumentsTextBox
            // 
            ArgumentsTextBox.Dock = DockStyle.Fill;
            ArgumentsTextBox.Location = new Point(434, 197);
            ArgumentsTextBox.Name = "ArgumentsTextBox";
            ArgumentsTextBox.Size = new Size(320, 31);
            ArgumentsTextBox.TabIndex = 9;
            // 
            // BrowseIconButton
            // 
            BrowseIconButton.Anchor = AnchorStyles.Left;
            BrowseIconButton.Location = new Point(760, 75);
            BrowseIconButton.Name = "BrowseIconButton";
            BrowseIconButton.Size = new Size(36, 36);
            BrowseIconButton.TabIndex = 10;
            BrowseIconButton.Text = "...";
            BrowseIconButton.UseVisualStyleBackColor = true;
            // 
            // BrowsePathButton
            // 
            BrowsePathButton.Anchor = AnchorStyles.Left;
            BrowsePathButton.AutoSize = true;
            BrowsePathButton.Location = new Point(760, 155);
            BrowsePathButton.Name = "BrowsePathButton";
            BrowsePathButton.Size = new Size(36, 36);
            BrowsePathButton.TabIndex = 11;
            BrowsePathButton.Text = "...";
            BrowsePathButton.UseVisualStyleBackColor = true;
            // 
            // MainTreeeMenuStrip
            // 
            MainTreeeMenuStrip.ImageScalingSize = new Size(24, 24);
            MainTreeeMenuStrip.Items.AddRange(new ToolStripItem[] { MainTreeContextMenuAddShortcutButton, MainTreeContextMenuAddFolderButton, MainTreeContextMenuAddDeleteButton });
            MainTreeeMenuStrip.Name = "MainTreeeMenuStrip";
            MainTreeeMenuStrip.Size = new Size(241, 133);
            // 
            // MainTreeContextMenuAddShortcutButton
            // 
            MainTreeContextMenuAddShortcutButton.Name = "MainTreeContextMenuAddShortcutButton";
            MainTreeContextMenuAddShortcutButton.Size = new Size(240, 32);
            MainTreeContextMenuAddShortcutButton.Text = "Add Shortcut";
            // 
            // MainTreeContextMenuAddFolderButton
            // 
            MainTreeContextMenuAddFolderButton.Name = "MainTreeContextMenuAddFolderButton";
            MainTreeContextMenuAddFolderButton.Size = new Size(240, 32);
            MainTreeContextMenuAddFolderButton.Text = "Add Folder";
            // 
            // MainTreeContextMenuAddDeleteButton
            // 
            MainTreeContextMenuAddDeleteButton.Name = "MainTreeContextMenuAddDeleteButton";
            MainTreeContextMenuAddDeleteButton.Size = new Size(240, 32);
            MainTreeContextMenuAddDeleteButton.Text = "Delete";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Shortcut Manager";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            MainToolStrip.ResumeLayout(false);
            MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            MainTreeeMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TreeView MainTree;
        private TableLayoutPanel tableLayoutPanel1;
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
        private Button BrowseIconButton;
        private Button BrowsePathButton;
        private ContextMenuStrip MainTreeeMenuStrip;
        private ToolStripMenuItem MainTreeContextMenuAddShortcutButton;
        private ToolStripMenuItem MainTreeContextMenuAddFolderButton;
        private ToolStripMenuItem MainTreeContextMenuAddDeleteButton;
    }
}
