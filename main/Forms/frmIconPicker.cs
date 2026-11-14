using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using client.Classes;

namespace client.Forms
{
    public class frmIconPicker : Form
    {
        private ListView lvIcons;
        private ImageList imageList;
        private Button cmdOk;
        private Button cmdCancel;
        private Label lblHint;
        private readonly List<Bitmap> sourceIcons;

        public Bitmap SelectedIcon { get; private set; }

        public frmIconPicker(List<Bitmap> icons, string sourceFileName)
        {
            sourceIcons = icons ?? new List<Bitmap>();
            InitializeUi(sourceFileName);
            PopulateIcons();
        }

        private void InitializeUi(string sourceFileName)
        {
            this.Text = $"{Localization.T("picker_title")} - {sourceFileName}";
            this.BackColor = Color.FromArgb(31, 31, 31);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(460, 380);

            lblHint = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.White,
                Location = new Point(14, 12),
                Text = Localization.T("picker_hint")
            };

            imageList = new ImageList
            {
                ImageSize = new Size(48, 48),
                ColorDepth = ColorDepth.Depth32Bit
            };

            lvIcons = new ListView
            {
                BackColor = Color.FromArgb(24, 24, 24),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(14, 38),
                Size = new Size(432, 286),
                View = View.LargeIcon,
                MultiSelect = false,
                HideSelection = false,
                LargeImageList = imageList
            };
            lvIcons.DoubleClick += (s, e) => ConfirmSelection();
            lvIcons.SelectedIndexChanged += (s, e) => cmdOk.Enabled = lvIcons.SelectedIndices.Count > 0;

            cmdOk = new Button
            {
                BackColor = Color.FromArgb(76, 76, 76),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                Location = new Point(268, 336),
                Size = new Size(84, 30),
                Text = Localization.T("btn_ok"),
                Enabled = false
            };
            cmdOk.FlatAppearance.BorderSize = 0;
            cmdOk.Click += (s, e) => ConfirmSelection();

            cmdCancel = new Button
            {
                BackColor = Color.FromArgb(56, 56, 56),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                Location = new Point(362, 336),
                Size = new Size(84, 30),
                Text = Localization.T("btn_cancel"),
                DialogResult = DialogResult.Cancel
            };
            cmdCancel.FlatAppearance.BorderSize = 0;

            this.Controls.Add(lblHint);
            this.Controls.Add(lvIcons);
            this.Controls.Add(cmdOk);
            this.Controls.Add(cmdCancel);
            this.AcceptButton = cmdOk;
            this.CancelButton = cmdCancel;
        }

        private void PopulateIcons()
        {
            for (int i = 0; i < sourceIcons.Count; i++)
            {
                imageList.Images.Add(sourceIcons[i]);
                lvIcons.Items.Add(new ListViewItem($"#{i + 1}", i));
            }

            if (lvIcons.Items.Count > 0)
            {
                lvIcons.Items[0].Selected = true;
                lvIcons.Items[0].Focused = true;
            }
        }

        private void ConfirmSelection()
        {
            if (lvIcons.SelectedIndices.Count == 0)
                return;

            int idx = lvIcons.SelectedIndices[0];
            SelectedIcon = new Bitmap(sourceIcons[idx]);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                imageList?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

