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

            string tooltipText = GetShortcutDisplayName();
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

        private void ApplyDefaultBackColor()
        {
            this.BackColor = IsRunning ? MotherForm.RunningColor : Color.Transparent;
        }

        public void ucShortcut_Click(object sender, EventArgs e)
        {
            if (Psc.isWindowsApp)
            {
                Process p = new Process() {StartInfo = new ProcessStartInfo() { UseShellExecute = true, FileName = $@"shell:appsFolder\{Psc.FilePath}" }};
                p.Start();
            } else
            {
                if(Path.GetExtension(Psc.FilePath).ToLower() == ".lnk" && Psc.FilePath == MainPath.exeString)

                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, MainPath.path);
                } else
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, Psc.WorkingDirectory);
                }
            }

            IsRunning = true;
            ApplyDefaultBackColor();
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
