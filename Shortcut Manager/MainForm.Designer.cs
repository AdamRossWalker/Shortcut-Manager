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
            MainSplitContainer = new SplitContainer();
            MainTree = new TreeView();
            ShortcutDetailsLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(MainTree);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(ShortcutDetailsLayoutPanel);
            MainSplitContainer.Size = new Size(800, 450);
            MainSplitContainer.SplitterDistance = 266;
            MainSplitContainer.TabIndex = 0;
            // 
            // MainTree
            // 
            MainTree.Dock = DockStyle.Fill;
            MainTree.Location = new Point(0, 0);
            MainTree.Name = "MainTree";
            MainTree.Size = new Size(266, 450);
            MainTree.TabIndex = 0;
            // 
            // ShortcutDetailsLayoutPanel
            // 
            ShortcutDetailsLayoutPanel.ColumnCount = 2;
            ShortcutDetailsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ShortcutDetailsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ShortcutDetailsLayoutPanel.Dock = DockStyle.Fill;
            ShortcutDetailsLayoutPanel.Location = new Point(0, 0);
            ShortcutDetailsLayoutPanel.Name = "ShortcutDetailsLayoutPanel";
            ShortcutDetailsLayoutPanel.RowCount = 2;
            ShortcutDetailsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ShortcutDetailsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ShortcutDetailsLayoutPanel.Size = new Size(530, 450);
            ShortcutDetailsLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainSplitContainer);
            Name = "MainForm";
            Text = "Shortcut Manager";
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MainSplitContainer;
        private TreeView MainTree;
        private TableLayoutPanel ShortcutDetailsLayoutPanel;
    }
}
