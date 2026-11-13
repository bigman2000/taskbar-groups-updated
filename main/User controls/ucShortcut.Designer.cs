namespace client.User_controls
{
    partial class ucShortcut
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picIcon.Location = new System.Drawing.Point(16, 11);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(23, 23);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.ucShortcut_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.picIcon.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            this.picIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucShortcut_MouseUp);
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(2, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 14);
            this.lblName.TabIndex = 1;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Visible = false;
            this.lblName.Click += new System.EventHandler(this.ucShortcut_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucShortcut_MouseUp);
            // 
            // ucShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picIcon);
            this.Name = "ucShortcut";
            this.Size = new System.Drawing.Size(55, 45);
            this.Load += new System.EventHandler(this.ucShortcut_Load);
            this.Click += new System.EventHandler(this.ucShortcut_Click);
            this.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucShortcut_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblName;
    }
}
