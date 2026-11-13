namespace client.User_controls
{
    partial class ucCategoryPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmdPreview = new global::client.Classes.ModernButton();
            this.cmdDelete = new global::client.Classes.ModernButton();
            this.cmdClone = new global::client.Classes.ModernButton();
            this.cmdExport = new global::client.Classes.ModernButton();
            this.cmdRemove = new global::client.Classes.ModernButton();
            this.picGroupIcon = new System.Windows.Forms.PictureBox();
            this.pnlDivider = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picGroupIcon
            // 
            this.picGroupIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picGroupIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGroupIcon.Location = new System.Drawing.Point(20, 14);
            this.picGroupIcon.Name = "picGroupIcon";
            this.picGroupIcon.Size = new System.Drawing.Size(30, 30);
            this.picGroupIcon.TabIndex = 21;
            this.picGroupIcon.TabStop = false;
            this.picGroupIcon.Click += new System.EventHandler(this.OpenFolder);
            this.picGroupIcon.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.picGroupIcon.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(58, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 25);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Group Name";
            this.lblTitle.Click += new System.EventHandler(this.OpenFolder);
            this.lblTitle.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.lblCount.Location = new System.Drawing.Point(195, 19);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(40, 17);
            this.lblCount.TabIndex = 25;
            this.lblCount.Text = "(0)";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(138)))));
            this.cmdPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(120)))), ((int)(((byte)(185)))));
            this.cmdPreview.CornerRadius = 6;
            this.cmdPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPreview.ForeColor = System.Drawing.Color.White;
            this.cmdPreview.Location = new System.Drawing.Point(450, 14);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(84, 28);
            this.cmdPreview.TabIndex = 19;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // cmdDelete (Edit group)
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmdDelete.CornerRadius = 6;
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.ForeColor = System.Drawing.Color.White;
            this.cmdDelete.Location = new System.Drawing.Point(540, 14);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(102, 28);
            this.cmdDelete.TabIndex = 20;
            this.cmdDelete.Text = "Edit group";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClone
            // 
            this.cmdClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cmdClone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.cmdClone.CornerRadius = 6;
            this.cmdClone.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmdClone.ForeColor = System.Drawing.Color.White;
            this.cmdClone.Location = new System.Drawing.Point(450, 48);
            this.cmdClone.Name = "cmdClone";
            this.cmdClone.Size = new System.Drawing.Size(60, 26);
            this.cmdClone.TabIndex = 22;
            this.cmdClone.Text = "Clone";
            this.cmdClone.Click += new System.EventHandler(this.cmdClone_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cmdExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.cmdExport.CornerRadius = 6;
            this.cmdExport.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmdExport.ForeColor = System.Drawing.Color.White;
            this.cmdExport.Location = new System.Drawing.Point(515, 48);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(62, 26);
            this.cmdExport.TabIndex = 23;
            this.cmdExport.Text = "Export";
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cmdRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.cmdRemove.CornerRadius = 6;
            this.cmdRemove.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmdRemove.ForeColor = System.Drawing.Color.White;
            this.cmdRemove.Location = new System.Drawing.Point(582, 48);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(60, 26);
            this.cmdRemove.TabIndex = 24;
            this.cmdRemove.Text = "Delete";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDivider.Location = new System.Drawing.Point(0, 95);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(660, 1);
            this.pnlDivider.TabIndex = 26;
            // 
            // ucCategoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.picGroupIcon);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.cmdClone);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ucCategoryPanel";
            this.Size = new System.Drawing.Size(660, 96);
            this.Load += new System.EventHandler(this.ucNewCategory_Load);
            this.Click += new System.EventHandler(this.OpenFolder);
            ((System.ComponentModel.ISupportInitialize)(this.picGroupIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private global::client.Classes.ModernButton cmdPreview;
        private global::client.Classes.ModernButton cmdDelete;
        private global::client.Classes.ModernButton cmdClone;
        private global::client.Classes.ModernButton cmdExport;
        private global::client.Classes.ModernButton cmdRemove;
        private System.Windows.Forms.PictureBox picGroupIcon;
        private System.Windows.Forms.Panel pnlDivider;
    }
}
