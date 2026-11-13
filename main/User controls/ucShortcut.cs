using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.Classes;
using System.Diagnostics;
using System.IO;
using IWshRuntimeLibrary;
using client.Forms;

namespace client.User_controls
{
    public partial class ucShortcut : UserControl
    {
        public ProgramShortcut Psc { get; set; }
        public frmMain MotherForm { get; set; }
        public Category ThisCategory { get; set; }
        public bool IsRunning { get; set; }
        public List<int> RunningProcessIds { get; set; } = new List<int>();
        public int IconDimension { get; set; } = 23;
        public bool ShowLabel { get; set; } = false;
        public ucShortcut()
        {
            InitializeComponent();
        }

        private void ucShortcut_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            ApplyDefaultBackColor();
            picIcon.BackgroundImage = ThisCategory.loadImageCache(Psc); // Use the local icon cache for the file specified as the icon image
            picIcon.Size = new Size(IconDimension, IconDimension);

            string tooltipText = GetShortcutDisplayName();
            if (ShowLabel)
            {
                picIcon.Location = new Point((this.Width - IconDimension) / 2, 6);
                lblName.Location = new Point(2, IconDimension + 9);
                lblName.Size = new Size(this.Width - 4, 15);
                lblName.Text = tooltipText;
                lblName.ForeColor = MotherForm.IsLightBackground ? Color.FromArgb(30, 30, 30) : Color.White;
                lblName.Visible = true;
            }
            else
            {
                picIcon.Location = new Point((this.Width - IconDimension) / 2, (this.Height - IconDimension) / 2);
                lblName.Visible = false;
            }

            if (!string.IsNullOrEmpty(tooltipText))
            {
                if (components == null)
                {
                    components = new Container();
                }

                ToolTip shortcutToolTip = new ToolTip(components)
                {
                    InitialDelay = 200,
                    ReshowDelay = 100,
                    ShowAlways = true
                };
                shortcutToolTip.SetToolTip(this, tooltipText);
                shortcutToolTip.SetToolTip(picIcon, tooltipText);
                shortcutToolTip.SetToolTip(lblName, tooltipText);
            }
        }

        private string GetShortcutDisplayName()
        {
            if (Psc == null)
            {
                return string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(Psc.name))
            {
                return Psc.name;
            }

            if (Psc.isWindowsApp)
            {
                return handleWindowsApp.findWindowsAppsName(Psc.FilePath);
            }

            if (System.IO.File.Exists(Psc.FilePath) && Path.GetExtension(Psc.FilePath).ToLower() == ".lnk")
            {
                return frmGroup.handleExtName(Psc.FilePath);
            }

            string fileName = Path.GetFileNameWithoutExtension(Psc.FilePath);
            return string.IsNullOrEmpty(fileName) ? Psc.FilePath : fileName;
        }

        public void ApplyDefaultBackColor()
        {
            this.BackColor = IsRunning ? MotherForm.RunningColor : Color.Transparent;
        }

        public void ucShortcut_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs mouseArgs && mouseArgs.Button != MouseButtons.Left)
            {
                return;
            }

            if (ThisCategory != null && ThisCategory.activateRunningWindow && IsRunning && RunningProcessIds != null && RunningProcessIds.Count > 0)
            {
                if (WindowHelper.ActivateProcessWindow(RunningProcessIds))
                {
                    MotherForm.Close();
                    return;
                }
            }

            LaunchShortcut(false);
        }

        public void LaunchShortcut(bool asAdmin)
        {
            if (Psc.isWindowsApp)
            {
                Process p = new Process() { StartInfo = new ProcessStartInfo() { UseShellExecute = true, FileName = $@"shell:appsFolder\{Psc.FilePath}" } };
                p.Start();
            }
            else if (asAdmin && !Directory.Exists(Psc.FilePath))
            {
                string workingDir = (Path.GetExtension(Psc.FilePath).ToLower() == ".lnk" && Psc.FilePath == MainPath.exeString)
                    ? MainPath.path
                    : Psc.WorkingDirectory;
                MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, workingDir, true);
            }
            else
            {
                if (Path.GetExtension(Psc.FilePath).ToLower() == ".lnk" && Psc.FilePath == MainPath.exeString)
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, MainPath.path);
                }
                else
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, Psc.WorkingDirectory);
                }
            }

            IsRunning = true;
            ApplyDefaultBackColor();
        }

        private void ucShortcut_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is Control ctrl)
            {
                MotherForm.ShowShortcutContextMenu(this, ctrl.PointToScreen(e.Location));
            }
        }

        public void ucShortcut_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = MotherForm.HoverColor;
        }

        public void ucShortcut_MouseLeave(object sender, EventArgs e)
        {
            ApplyDefaultBackColor();
        }
    }
}
