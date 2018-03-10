namespace SQCBEditor
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.LB_Files = new System.Windows.Forms.ListBox();
            this.TS_CEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackPanel1 = new SQCBEditor.PlaybackPanel();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.TS_CEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Open,
            this.TS_Save});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // TS_Open
            // 
            this.TS_Open.Name = "TS_Open";
            this.TS_Open.Size = new System.Drawing.Size(103, 22);
            this.TS_Open.Text = "Open";
            this.TS_Open.Click += new System.EventHandler(this.LoadFile);
            // 
            // TS_Save
            // 
            this.TS_Save.Name = "TS_Save";
            this.TS_Save.Size = new System.Drawing.Size(103, 22);
            this.TS_Save.Text = "Save";
            this.TS_Save.Click += new System.EventHandler(this.SaveFile);
            // 
            // LB_Files
            // 
            this.LB_Files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_Files.FormattingEnabled = true;
            this.LB_Files.Location = new System.Drawing.Point(0, 27);
            this.LB_Files.Name = "LB_Files";
            this.LB_Files.Size = new System.Drawing.Size(200, 420);
            this.LB_Files.TabIndex = 1;
            // 
            // TS_CEdit
            // 
            this.TS_CEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Import,
            this.TS_Export,
            this.exportAllToolStripMenuItem});
            this.TS_CEdit.Name = "TS_CEdit";
            this.TS_CEdit.Size = new System.Drawing.Size(39, 20);
            this.TS_CEdit.Text = "Edit";
            // 
            // TS_Import
            // 
            this.TS_Import.Name = "TS_Import";
            this.TS_Import.Size = new System.Drawing.Size(180, 22);
            this.TS_Import.Text = "Import new";
            this.TS_Import.Click += new System.EventHandler(this.TS_Import_Click);
            // 
            // TS_Export
            // 
            this.TS_Export.Name = "TS_Export";
            this.TS_Export.Size = new System.Drawing.Size(180, 22);
            this.TS_Export.Text = "Export selected";
            this.TS_Export.Click += new System.EventHandler(this.TS_Export_Click);
            // 
            // playbackPanel1
            // 
            this.playbackPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playbackPanel1.Location = new System.Drawing.Point(207, 28);
            this.playbackPanel1.Name = "playbackPanel1";
            this.playbackPanel1.Size = new System.Drawing.Size(593, 419);
            this.playbackPanel1.TabIndex = 2;
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportAllToolStripMenuItem.Text = "Export all";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playbackPanel1);
            this.Controls.Add(this.LB_Files);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TS_Open;
        private System.Windows.Forms.ListBox LB_Files;
        private PlaybackPanel playbackPanel1;
        private System.Windows.Forms.ToolStripMenuItem TS_Save;
        private System.Windows.Forms.ToolStripMenuItem TS_CEdit;
        private System.Windows.Forms.ToolStripMenuItem TS_Import;
        private System.Windows.Forms.ToolStripMenuItem TS_Export;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
    }
}

