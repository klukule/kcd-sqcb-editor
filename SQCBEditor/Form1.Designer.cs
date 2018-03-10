﻿namespace SQCBEditor
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
            this.LB_Files = new System.Windows.Forms.ListBox();
            this.playbackPanel1 = new SQCBEditor.PlaybackPanel();
            this.TS_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            this.TS_Open.Size = new System.Drawing.Size(180, 22);
            this.TS_Open.Text = "Open";
            this.TS_Open.Click += new System.EventHandler(this.LoadFile);
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
            // TS_Save
            // 
            this.TS_Save.Name = "TS_Save";
            this.TS_Save.Size = new System.Drawing.Size(180, 22);
            this.TS_Save.Text = "Save";
            this.TS_Save.Click += new System.EventHandler(this.SaveFile);
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
    }
}

