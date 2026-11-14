using System;
using System.Drawing;
using System.Windows.Forms;
using client.Classes;
using client.Forms;
using System.IO;
using System.Windows.Input;

namespace client.User_controls
{
    public partial class ucProgramShortcut : UserControl
    {
        public ProgramShortcut Shortcut { get; set; }
        public frmGroup MotherForm { get; set; }

        public bool IsSelected = false;
        public int Position { get; set; }

        public Bitmap logo;

        private bool isMouseDown = false;
        private bool isDragging = false;
        private bool suppressNextClick = false;
        private Point dragStartScreenPoint;
        public ucProgramShortcut()
        {
            InitializeComponent();
            cmdDelete.Text = Localization.T("btn_delete");
        }

        private void ucProgramShortcut_Load(object sender, EventArgs e)
        {
            // Grab the file name without the extension to be used later as the naming scheme for the icon .jpg image

            if (Shortcut.isWindowsApp)
            {
                txtShortcutName.Text = handleWindowsApp.findWindowsAppsName(Shortcut.FilePath);
            } else if (Shortcut.name == "")
            {
                if (File.Exists(Shortcut.FilePath) && Path.GetExtension(Shortcut.FilePath).ToLower() == ".lnk")
                {
                    txtShortcutName.Text = frmGroup.handleExtName(Shortcut.FilePath);
                }
                else
                {
                    txtShortcutName.Text = Path.GetFileNameWithoutExtension(Shortcut.FilePath);
                }
            } else
            {
                txtShortcutName.Text = Shortcut.name;
            }

            Size size = TextRenderer.MeasureText(txtShortcutName.Text, txtShortcutName.Font);
            txtShortcutName.Width = size.Width;
            txtShortcutName.Height = size.Height;


            Image pendingIcon = MotherForm.GetPendingCustomIcon(Shortcut);
            if (pendingIcon != null)
            {
                picShortcut.BackgroundImage = logo = new Bitmap(pendingIcon);
            }
            else if (!MotherForm.IsCustomIconCleared(Shortcut) && !string.IsNullOrEmpty(Shortcut.CustomIconPath))
            {
                string customIconFullPath = Path.Combine(MainPath.path, "config", MotherForm.Category.Name, "Icons", Shortcut.CustomIconPath);
                if (File.Exists(customIconFullPath))
                {
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(customIconFullPath)))
                    using (Image img = Image.FromStream(ms))
                    {
                        picShortcut.BackgroundImage = logo = new Bitmap(img);
                    }
                }
                else
                {
                    LoadDefaultIcon();
                }
            }
            else
            {
                LoadDefaultIcon();
            }

            UpdateOrderButtons();
        }

        public void SetCustomIcon(Bitmap icon)
        {
            if (icon == null)
                return;

            logo = new Bitmap(icon);
            picShortcut.BackgroundImage = logo;
        }

        public void ResetToDefaultIcon()
        {
            LoadDefaultIcon();
        }

        private void LoadDefaultIcon()
        {
            if (Shortcut.isWindowsApp)
            {
                logo = handleWindowsApp.getWindowsAppIcon(Shortcut.FilePath, true);
                picShortcut.BackgroundImage = logo;
            }
            else if (File.Exists(Shortcut.FilePath)) // Checks if the shortcut actually exists; if not then display an error image
            {
                String imageExtension = Path.GetExtension(Shortcut.FilePath).ToLower();

                // Start checking if the extension is an lnk (shortcut) file
                // Depending on the extension, the icon can be directly extracted or it has to be gotten through other methods as to not get the shortcut arrow
                if (imageExtension == ".lnk")
                {
                    picShortcut.BackgroundImage = logo = frmGroup.handleLnkExt(Shortcut.FilePath);
                }
                else
                {
                    picShortcut.BackgroundImage = logo = Icon.ExtractAssociatedIcon(Shortcut.FilePath).ToBitmap();
                }

            }
            else if (Directory.Exists(Shortcut.FilePath))
            {
                try
                {
                    picShortcut.BackgroundImage = logo = handleFolder.GetFolderIcon(Shortcut.FilePath).ToBitmap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                picShortcut.BackgroundImage = logo = global::client.Properties.Resources.Error;
            }
        }

        public void UpdateOrderButtons()
        {
            bool isFirst = (Position == 0);
            bool isLast = (Position == MotherForm.Category.ShortcutList.Count - 1);

            cmdNumUp.Enabled = !isFirst;
            cmdNumUp.BackgroundImage = isFirst
                ? global::client.Properties.Resources.NumUpGray
                : global::client.Properties.Resources.NumUpWhite;

            cmdNumDown.Enabled = !isLast;
            cmdNumDown.BackgroundImage = isLast
                ? global::client.Properties.Resources.NumDownGray
                : global::client.Properties.Resources.NumDownWhite;
        }

        private void ucProgramShortcut_MouseEnter(object sender, EventArgs e)
        {
            if (MotherForm.IsDraggingShortcut)
                return;

            ucSelected();
        }

        private void ucProgramShortcut_MouseLeave(object sender, EventArgs e)
        {
            if (MotherForm.IsDraggingShortcut)
                return;

            if (MotherForm.selectedShortcut != this)
            {
                ucDeselected();
            }
        }

        private void cmdNumUp_Click(object sender, EventArgs e)
        {
            MotherForm.Swap(MotherForm.Category.ShortcutList, Position, Position - 1);

        }

        private void cmdNumDown_Click(object sender, EventArgs e)
        {
            MotherForm.Swap(MotherForm.Category.ShortcutList, Position, Position + 1);

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            MotherForm.DeleteShortcut(Shortcut);
        }

        // Handle what is selected/deselected when a shortcut is clicked on
        // If current item is already selected, then deselect everything
        private void ucProgramShortcut_Click(object sender, EventArgs e)
        {
            if (isDragging || suppressNextClick)
            {
                suppressNextClick = false;
                return;
            }

            if (MotherForm.selectedShortcut == this)
            {
                MotherForm.resetSelection();
                //IsSelected = false;
            }
            else
            {
                if (MotherForm.selectedShortcut != null)
                {
                    MotherForm.resetSelection();
                    //IsSelected = false;
                }

                MotherForm.enableSelection(this);
                //IsSelected = true;
            }
        }

        public void ucDeselected()
        {
            txtShortcutName.DeselectAll();
            txtShortcutName.Enabled = false;
            txtShortcutName.Enabled = true;
            txtShortcutName.TabStop = false; // Deselecting textbox text

            this.BackColor = Color.FromArgb(31, 31, 31);
            txtShortcutName.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumUp.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumDown.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void ucSelected()
        {

            this.BackColor = Color.FromArgb(26, 26, 26);
            txtShortcutName.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumUp.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumDown.BackColor = Color.FromArgb(26, 26, 26);

        }

        public void ucDragging(bool active)
        {
            Color back = active ? Color.FromArgb(46, 46, 46) : Color.FromArgb(31, 31, 31);
            this.BackColor = back;
            txtShortcutName.BackColor = back;
            cmdNumUp.BackColor = back;
            cmdNumDown.BackColor = back;
        }

        private void ShortcutDrag_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || MotherForm.Category.ShortcutList.Count <= 1)
                return;

            isMouseDown = true;
            isDragging = false;
            suppressNextClick = false;
            dragStartScreenPoint = ((Control)sender).PointToScreen(e.Location);
        }

        private void ShortcutDrag_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!isMouseDown)
                return;

            if (!isDragging)
            {
                Point currentScreen = ((Control)sender).PointToScreen(e.Location);
                int dx = Math.Abs(currentScreen.X - dragStartScreenPoint.X);
                int dy = Math.Abs(currentScreen.Y - dragStartScreenPoint.Y);

                // Allow horizontal text selection when the user has already focused the name box
                if (sender == txtShortcutName && txtShortcutName.Focused && dy < 6)
                    return;

                if (dx >= SystemInformation.DragSize.Width || dy >= SystemInformation.DragSize.Height)
                {
                    isDragging = true;
                    ((Control)sender).Capture = true;
                    MotherForm.BeginShortcutDrag(this);
                }
            }

            if (isDragging)
            {
                MotherForm.UpdateShortcutDrag();
            }
        }

        private void ShortcutDrag_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            bool wasDragging = isDragging;
            isMouseDown = false;
            isDragging = false;

            if (wasDragging)
            {
                suppressNextClick = true;
                ((Control)sender).Capture = false;
                MotherForm.EndShortcutDrag();
            }
        }

        private void lbTextbox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtShortcutName.Text, txtShortcutName.Font);
            txtShortcutName.Width = size.Width;
            txtShortcutName.Height = size.Height;
            Shortcut.name = txtShortcutName.Text;
        }

        private void ucProgramShortcut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picShortcut.Focus();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtShortcutName_Click(object sender, EventArgs e)
        {
            
            if (!IsSelected)
                ucProgramShortcut_Click(sender, e);
        }

        private void ucProgramShortcut_Enter(object sender, EventArgs e)
        {
            //IsSelected = true;
        }

        private void ucProgramShortcut_Leave(object sender, EventArgs e)
        {
            //IsSelected = false;
        }

    }
}
