namespace client.Forms
{
    partial class frmClient
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.pnlVersionInfo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.githubVersion = new System.Windows.Forms.LinkLabel();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.githubLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHelp1 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.pnlRightArea = new System.Windows.Forms.Panel();
            this.pnlGroupsScroll = new System.Windows.Forms.Panel();
            this.pnlExistingGroups = new System.Windows.Forms.Panel();
            this.pnlBottomMain = new System.Windows.Forms.Panel();
            this.cmdAddGroupBtn = new global::client.Classes.ModernButton();
            this.cmdImportGroup = new global::client.Classes.ModernButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSearchHint = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdClearSearch = new global::client.Classes.ModernButton();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlVersionInfo.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlRightArea.SuspendLayout();
            this.pnlGroupsScroll.SuspendLayout();
            this.pnlBottomMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlLeftColumn.Controls.Add(this.pnlVersionInfo);
            this.pnlLeftColumn.Controls.Add(this.pnlHelp);
            this.pnlLeftColumn.Controls.Add(this.lblHelpTitle);
            this.pnlLeftColumn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftColumn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlLeftColumn.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(305, 720);
            this.pnlLeftColumn.TabIndex = 0;
            // 
            // pnlVersionInfo
            // 
            this.pnlVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlVersionInfo.Controls.Add(this.label6);
            this.pnlVersionInfo.Controls.Add(this.currentVersion);
            this.pnlVersionInfo.Controls.Add(this.githubVersion);
            this.pnlVersionInfo.Controls.Add(this.githubLink);
            this.pnlVersionInfo.Controls.Add(this.githubLabel);
            this.pnlVersionInfo.Controls.Add(this.label4);
            this.pnlVersionInfo.Controls.Add(this.label5);
            this.pnlVersionInfo.Location = new System.Drawing.Point(8, 520);
            this.pnlVersionInfo.Name = "pnlVersionInfo";
            this.pnlVersionInfo.Size = new System.Drawing.Size(288, 178);
            this.pnlVersionInfo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(60, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Current Version:";
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.BackColor = System.Drawing.Color.Transparent;
            this.currentVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.currentVersion.ForeColor = System.Drawing.Color.White;
            this.currentVersion.Location = new System.Drawing.Point(170, 101);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(17, 19);
            this.currentVersion.TabIndex = 15;
            this.currentVersion.Text = "0";
            // 
            // githubVersion
            // 
            this.githubVersion.AutoSize = true;
            this.githubVersion.BackColor = System.Drawing.Color.Transparent;
            this.githubVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.githubVersion.Location = new System.Drawing.Point(170, 130);
            this.githubVersion.Name = "githubVersion";
            this.githubVersion.Size = new System.Drawing.Size(65, 19);
            this.githubVersion.TabIndex = 14;
            this.githubVersion.TabStop = true;
            this.githubVersion.Text = "Checking...";
            this.githubVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubVersion_LinkClicked);
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.githubLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.githubLink.Location = new System.Drawing.Point(214, 34);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(34, 17);
            this.githubLink.TabIndex = 18;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "here";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.BackColor = System.Drawing.Color.Transparent;
            this.githubLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubLabel.ForeColor = System.Drawing.Color.Silver;
            this.githubLabel.Location = new System.Drawing.Point(69, 130);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(98, 19);
            this.githubLabel.TabIndex = 13;
            this.githubLabel.Text = "Latest Version:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 27);
            this.label4.TabIndex = 17;
            this.label4.Text = "Have issues/bugs?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(18, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Please report them to the Github";
            // 
            // pnlHelp
            // 
            this.pnlHelp.Controls.Add(this.label3);
            this.pnlHelp.Controls.Add(this.lblHelp1);
            this.pnlHelp.Controls.Add(this.lblHelp3);
            this.pnlHelp.Controls.Add(this.lblHelp2);
            this.pnlHelp.Location = new System.Drawing.Point(8, 126);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(288, 202);
            this.pnlHelp.TabIndex = 17;
            this.pnlHelp.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "When the folder opens:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelp1
            // 
            this.lblHelp1.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp1.ForeColor = System.Drawing.Color.Silver;
            this.lblHelp1.Location = new System.Drawing.Point(22, 59);
            this.lblHelp1.Name = "lblHelp1";
            this.lblHelp1.Size = new System.Drawing.Size(243, 40);
            this.lblHelp1.TabIndex = 14;
            this.lblHelp1.Text = "1. Right click on the shortcut named as your new group";
            // 
            // lblHelp3
            // 
            this.lblHelp3.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp3.ForeColor = System.Drawing.Color.Silver;
            this.lblHelp3.Location = new System.Drawing.Point(22, 155);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(243, 22);
            this.lblHelp3.TabIndex = 16;
            this.lblHelp3.Text = "3. Enjoy your new Taskbar group";
            // 
            // lblHelp2
            // 
            this.lblHelp2.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp2.ForeColor = System.Drawing.Color.Silver;
            this.lblHelp2.Location = new System.Drawing.Point(22, 115);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(243, 22);
            this.lblHelp2.TabIndex = 15;
            this.lblHelp2.Text = "2. Click on \"Pin to taskbar\"";
            // 
            // lblHelpTitle
            // 
            this.lblHelpTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F);
            this.lblHelpTitle.ForeColor = System.Drawing.Color.White;
            this.lblHelpTitle.Location = new System.Drawing.Point(32, 44);
            this.lblHelpTitle.Name = "lblHelpTitle";
            this.lblHelpTitle.Size = new System.Drawing.Size(240, 56);
            this.lblHelpTitle.TabIndex = 13;
            this.lblHelpTitle.Text = "Press on \"Add taskbar group\" to get started";
            this.lblHelpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRightArea
            // 
            this.pnlRightArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.pnlRightArea.Controls.Add(this.pnlGroupsScroll);
            this.pnlRightArea.Controls.Add(this.pnlBottomMain);
            this.pnlRightArea.Controls.Add(this.panel1);
            this.pnlRightArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightArea.Location = new System.Drawing.Point(305, 0);
            this.pnlRightArea.Name = "pnlRightArea";
            this.pnlRightArea.Size = new System.Drawing.Size(695, 720);
            this.pnlRightArea.TabIndex = 5;
            // 
            // pnlGroupsScroll
            // 
            this.pnlGroupsScroll.AutoScroll = true;
            this.pnlGroupsScroll.Controls.Add(this.pnlExistingGroups);
            this.pnlGroupsScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupsScroll.Location = new System.Drawing.Point(0, 148);
            this.pnlGroupsScroll.Name = "pnlGroupsScroll";
            this.pnlGroupsScroll.Size = new System.Drawing.Size(695, 504);
            this.pnlGroupsScroll.TabIndex = 3;
            // 
            // pnlExistingGroups
            // 
            this.pnlExistingGroups.Location = new System.Drawing.Point(16, 4);
            this.pnlExistingGroups.Margin = new System.Windows.Forms.Padding(0);
            this.pnlExistingGroups.Name = "pnlExistingGroups";
            this.pnlExistingGroups.Size = new System.Drawing.Size(660, 0);
            this.pnlExistingGroups.TabIndex = 3;
            // 
            // pnlBottomMain
            // 
            this.pnlBottomMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.pnlBottomMain.Controls.Add(this.cmdAddGroupBtn);
            this.pnlBottomMain.Controls.Add(this.cmdImportGroup);
            this.pnlBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomMain.Location = new System.Drawing.Point(0, 652);
            this.pnlBottomMain.Name = "pnlBottomMain";
            this.pnlBottomMain.Size = new System.Drawing.Size(695, 68);
            this.pnlBottomMain.TabIndex = 4;
            // 
            // cmdAddGroupBtn
            // 
            this.cmdAddGroupBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(138)))));
            this.cmdAddGroupBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(120)))), ((int)(((byte)(185)))));
            this.cmdAddGroupBtn.CornerRadius = 7;
            this.cmdAddGroupBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.cmdAddGroupBtn.ForeColor = System.Drawing.Color.White;
            this.cmdAddGroupBtn.Location = new System.Drawing.Point(168, 15);
            this.cmdAddGroupBtn.Name = "cmdAddGroupBtn";
            this.cmdAddGroupBtn.Size = new System.Drawing.Size(210, 38);
            this.cmdAddGroupBtn.TabIndex = 1;
            this.cmdAddGroupBtn.Text = "+ Add taskbar group";
            this.cmdAddGroupBtn.Click += new System.EventHandler(this.cmdAddGroup_Click);
            // 
            // cmdImportGroup
            // 
            this.cmdImportGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmdImportGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.cmdImportGroup.CornerRadius = 7;
            this.cmdImportGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.cmdImportGroup.ForeColor = System.Drawing.Color.White;
            this.cmdImportGroup.Location = new System.Drawing.Point(392, 15);
            this.cmdImportGroup.Name = "cmdImportGroup";
            this.cmdImportGroup.Size = new System.Drawing.Size(136, 38);
            this.cmdImportGroup.TabIndex = 2;
            this.cmdImportGroup.Text = "Import group";
            this.cmdImportGroup.Click += new System.EventHandler(this.cmdImportGroup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSearchHint);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmdClearSearch);
            this.panel1.Controls.Add(this.cmbSort);
            this.panel1.Controls.Add(this.cmbLanguage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 148);
            this.panel1.TabIndex = 2;
            // 
            // lblSearchHint
            // 
            this.lblSearchHint.AutoSize = true;
            this.lblSearchHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblSearchHint.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSearchHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.lblSearchHint.Location = new System.Drawing.Point(34, 111);
            this.lblSearchHint.Name = "lblSearchHint";
            this.lblSearchHint.Size = new System.Drawing.Size(172, 17);
            this.lblSearchHint.TabIndex = 16;
            this.lblSearchHint.Text = "Search groups or programs...";
            this.lblSearchHint.Click += (s, e) => this.txtSearch.Focus();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(28, 107);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 25);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmdClearSearch
            // 
            this.cmdClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cmdClearSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.cmdClearSearch.CornerRadius = 5;
            this.cmdClearSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmdClearSearch.ForeColor = System.Drawing.Color.White;
            this.cmdClearSearch.Location = new System.Drawing.Point(454, 107);
            this.cmdClearSearch.Name = "cmdClearSearch";
            this.cmdClearSearch.Size = new System.Drawing.Size(55, 25);
            this.cmdClearSearch.TabIndex = 14;
            this.cmdClearSearch.Text = "Clear";
            this.cmdClearSearch.Visible = false;
            this.cmdClearSearch.Click += new System.EventHandler(this.cmdClearSearch_Click);
            // 
            // cmbSort
            // 
            this.cmbSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSort.ForeColor = System.Drawing.Color.White;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Sort: Default",
            "Sort: A - Z",
            "Sort: Z - A"});
            this.cmbSort.Location = new System.Drawing.Point(534, 107);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(130, 24);
            this.cmbSort.TabIndex = 15;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLanguage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLanguage.ForeColor = System.Drawing.Color.White;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(504, 28);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(160, 24);
            this.cmbLanguage.TabIndex = 16;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(28, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Group your favourite programs and pin them to the taskbar for easy access";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 40);
            this.label1.TabIndex = 11;
            this.label1.Text = "Taskbar Groups";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.pnlRightArea);
            this.Controls.Add(this.pnlLeftColumn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 520);
            this.Name = "frmClient";
            this.Text = "Taskbar Groups";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.Resize += new System.EventHandler(this.frmClient_Resize);
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlVersionInfo.ResumeLayout(false);
            this.pnlVersionInfo.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            this.pnlRightArea.ResumeLayout(false);
            this.pnlGroupsScroll.ResumeLayout(false);
            this.pnlBottomMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlRightArea;
        private System.Windows.Forms.Panel pnlGroupsScroll;
        private System.Windows.Forms.Panel pnlExistingGroups;
        private System.Windows.Forms.Panel pnlBottomMain;
        private global::client.Classes.ModernButton cmdAddGroupBtn;
        private global::client.Classes.ModernButton cmdImportGroup;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchHint;
        private global::client.Classes.ModernButton cmdClearSearch;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblHelpTitle;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label lblHelp3;
        private System.Windows.Forms.Label lblHelp2;
        private System.Windows.Forms.Label lblHelp1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlVersionInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.LinkLabel githubVersion;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label label6;
    }
}
