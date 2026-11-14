using client.Classes;
using client.User_controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace client
{

    public partial class frmMain : Form
    {

        // Allow doubleBuffering drawing each frame to memory and then onto screen
        // Solves flickering issues mostly as the entire rendering of the screen is done in 1 operation after being first loaded to memory
        protected override CreateParams CreateParams

        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Category ThisCategory;
        public List<ucShortcut> ControlList;
        public Color HoverColor;
        public Color RunningColor;
        public bool IsLightBackground { get; private set; }

        private bool isContextMenuOpen = false;
        private int selectedIndex = -1;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            WindowHelper.EnableRoundedCorners(this.Handle);
        }

        private string passedDirec;
        public Point mouseClick;

        //------------------------------------------------------------------------------------
        // CTOR AND LOAD
        //
        public frmMain(string passedDirectory, int cursorPosX, int cursorPosY)
        {
            InitializeComponent();

            System.Runtime.ProfileOptimization.StartProfile("frmMain.Profile");
            mouseClick = new Point(cursorPosX, cursorPosY); // Consstruct point p based on passed x y mouse values
            passedDirec = passedDirectory;
            FormBorderStyle = FormBorderStyle.None;

            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(MainPath.path + "\\config\\" + passedDirec + "\\GroupIcon.ico")))
                this.Icon = new Icon(ms);

            if (Directory.Exists(@MainPath.path + @"\config\" + passedDirec))
            {
                ControlList = new List<ucShortcut>();

                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                ThisCategory = new Category($"config\\{passedDirec}");
                this.BackColor = ImageFunctions.FromString(ThisCategory.ColorString);
                Opacity = (1 - (ThisCategory.Opacity / 100));

                IsLightBackground = BackColor.R * 0.2126 + BackColor.G * 0.7152 + BackColor.B * 0.0722 > 255 / 2;
                if (IsLightBackground)
                {
                    // If backcolor is light, set hover and running colors darker
                    HoverColor = Color.FromArgb(BackColor.A, Math.Max(0, BackColor.R - 50), Math.Max(0, BackColor.G - 50), Math.Max(0, BackColor.B - 50));
                    RunningColor = Color.FromArgb(32, 0, 0, 0);
                }
                else
                {
                    // If backcolor is dark, set hover and running colors lighter
                    HoverColor = Color.FromArgb(BackColor.A, Math.Min(255, BackColor.R + 50), Math.Min(255, BackColor.G + 50), Math.Min(255, BackColor.B + 50));
                    RunningColor = Color.FromArgb(36, 255, 255, 255);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadCategory();
            SetLocation();
        }

        // Sets location of form
        private void SetLocation()
        {
            List<Rectangle> taskbarList = FindDockedTaskBars();
            Rectangle taskbar = new Rectangle();
            Rectangle screen = new Rectangle();

            int i = 0;
            int locationy;
            int locationx;
            if (taskbarList.Count != 0)
            {
                foreach (var scr in Screen.AllScreens) // Get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                        taskbar = taskbarList[i];
                    }
                    i++;
                }

                if (taskbar.Contains(mouseClick)) // Click on taskbar
                {
                    if (taskbar.Top == screen.Top && taskbar.Width == screen.Width)
                    {
                        // TOP
                        locationy = screen.Y + taskbar.Height + 10;
                        locationx = mouseClick.X - (this.Width / 2);
                    }
                    else if (taskbar.Bottom == screen.Bottom && taskbar.Width == screen.Width)
                    {
                        // BOTTOM
                        locationy = screen.Y + screen.Height - this.Height - taskbar.Height - 10;
                        locationx = mouseClick.X - (this.Width / 2);
                    }
                    else if (taskbar.Left == screen.Left)
                    {
                        // LEFT
                        locationy = mouseClick.Y - (this.Height / 2);
                        locationx = screen.X + taskbar.Width + 10;

                    }
                    else
                    {
                        // RIGHT
                        locationy = mouseClick.Y - (this.Height / 2);
                        locationx = screen.X + screen.Width - this.Width - taskbar.Width - 10;
                    }

                }
                else // not click on taskbar
                {
                    locationy = mouseClick.Y - this.Height - 20;
                    locationx = mouseClick.X - (this.Width / 2);

                }

                this.Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;

                // If form goes over taskbar
                if (taskbar.Contains(this.Left, this.Top) && taskbar.Contains(this.Right, this.Top)) // Top taskbar
                    this.Top = screen.Top + 10 + taskbar.Height;
                if (taskbar.Contains(this.Left, this.Top)) // Left taskbar
                    this.Left = screen.Left + 10 + taskbar.Width;
                if (taskbar.Contains(this.Right, this.Top))  // Right taskbar
                    this.Left = screen.Right - this.Width - 10 - taskbar.Width;

            }
            else // Hidded taskbar
            {
                foreach (var scr in Screen.AllScreens) // get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                    }
                    i++;
                }

                if (mouseClick.Y > Screen.PrimaryScreen.Bounds.Height - 35)
                    locationy = Screen.PrimaryScreen.Bounds.Height - this.Height - 45;
                else
                    locationy = mouseClick.Y - this.Height - 20;
                locationx = mouseClick.X - (this.Width / 2);

                this.Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;

                // If form goes over taskbar
                if (taskbar.Contains(this.Left, this.Top) && taskbar.Contains(this.Right, this.Top)) // Top taskbar
                    this.Top = screen.Top + 10 + taskbar.Height;
                if (taskbar.Contains(this.Left, this.Top)) // Left taskbar
                    this.Left = screen.Left + 10 + taskbar.Width;
                if (taskbar.Contains(this.Right, this.Top))  // Right taskbar
                    this.Left = screen.Right - this.Width - 10 - taskbar.Width;
            }
        }
        // Search for active taskbars on screen
        public static List<Rectangle> FindDockedTaskBars()
        {
            List<Rectangle> dockedRects = new List<Rectangle>();
            foreach (var tmpScrn in Screen.AllScreens)
            {
                if (!tmpScrn.Bounds.Equals(tmpScrn.WorkingArea))
                {
                    Rectangle rect = new Rectangle();

                    var leftDockedWidth = Math.Abs((Math.Abs(tmpScrn.Bounds.Left) - Math.Abs(tmpScrn.WorkingArea.Left)));
                    var topDockedHeight = Math.Abs((Math.Abs(tmpScrn.Bounds.Top) - Math.Abs(tmpScrn.WorkingArea.Top)));
                    var rightDockedWidth = ((tmpScrn.Bounds.Width - leftDockedWidth) - tmpScrn.WorkingArea.Width);
                    var bottomDockedHeight = ((tmpScrn.Bounds.Height - topDockedHeight) - tmpScrn.WorkingArea.Height);
                    if ((leftDockedWidth > 0))
                    {
                        rect.X = tmpScrn.Bounds.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = leftDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((rightDockedWidth > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Right;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = rightDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((topDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = topDockedHeight;
                    }
                    else if ((bottomDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.WorkingArea.Bottom;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = bottomDockedHeight;
                    }
                    else
                    {
                        // Nothing found!
                    }

                    dockedRects.Add(rect);
                }
            }

            if (dockedRects.Count == 0)
            {
                // Taskbar is set to "Auto-Hide".
            }

            return dockedRects;
        }
        //
        //------------------------------------------------------------------------------------
        //

        private struct RunningProcInfo
        {
            public int Pid;
            public string FileName;
        }

        private void CaptureRunningProcesses(out Dictionary<string, List<RunningProcInfo>> runningByName, out List<RunningProcInfo> allRunning)
        {
            runningByName = new Dictionary<string, List<RunningProcInfo>>(StringComparer.OrdinalIgnoreCase);
            allRunning = new List<RunningProcInfo>();

            foreach (Process proc in Process.GetProcesses())
            {
                try
                {
                    string procName = proc.ProcessName;
                    int pid = proc.Id;
                    string modulePath = null;

                    try
                    {
                        modulePath = proc.MainModule?.FileName;
                    }
                    catch
                    {
                        // Access to MainModule can be denied for elevated/system processes
                    }

                    RunningProcInfo info = new RunningProcInfo { Pid = pid, FileName = modulePath };
                    allRunning.Add(info);

                    if (!runningByName.TryGetValue(procName, out List<RunningProcInfo> list))
                    {
                        list = new List<RunningProcInfo>();
                        runningByName[procName] = list;
                    }
                    list.Add(info);
                }
                catch
                {
                    // Process may have exited
                }
                finally
                {
                    proc.Dispose();
                }
            }
        }

        private List<int> GetShortcutProcessIds(ProgramShortcut psc, Dictionary<string, List<RunningProcInfo>> runningByName, List<RunningProcInfo> allRunning)
        {
            List<int> matchedPids = new List<int>();
            if (psc == null || string.IsNullOrWhiteSpace(psc.FilePath))
                return matchedPids;

            if (psc.isWindowsApp)
            {
                int underscoreIndex = psc.FilePath.IndexOf('_');
                string packagePrefix = underscoreIndex > 0 ? psc.FilePath.Substring(0, underscoreIndex) : psc.FilePath;
                if (string.IsNullOrEmpty(packagePrefix))
                    return matchedPids;

                string marker = "\\WindowsApps\\" + packagePrefix;
                foreach (RunningProcInfo info in allRunning)
                {
                    if (!string.IsNullOrEmpty(info.FileName) && info.FileName.IndexOf(marker, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        matchedPids.Add(info.Pid);
                    }
                }
                return matchedPids;
            }

            string targetExePath = null;
            string ext = Path.GetExtension(psc.FilePath).ToLowerInvariant();
            if (ext == ".lnk" && System.IO.File.Exists(psc.FilePath))
            {
                try
                {
                    IWshShortcut shortcut = (IWshShortcut)new WshShell().CreateShortcut(psc.FilePath);
                    if (!string.IsNullOrWhiteSpace(shortcut.TargetPath))
                    {
                        targetExePath = Environment.ExpandEnvironmentVariables(shortcut.TargetPath);
                    }
                }
                catch
                {
                    return matchedPids;
                }
            }
            else if (ext == ".exe")
            {
                targetExePath = psc.FilePath;
            }

            if (string.IsNullOrWhiteSpace(targetExePath) || Path.GetExtension(targetExePath).ToLowerInvariant() != ".exe")
                return matchedPids;

            string procName = Path.GetFileNameWithoutExtension(targetExePath);
            if (!runningByName.TryGetValue(procName, out List<RunningProcInfo> candidates))
                return matchedPids;

            bool anyAccessiblePath = false;
            foreach (RunningProcInfo info in candidates)
            {
                if (!string.IsNullOrEmpty(info.FileName))
                {
                    anyAccessiblePath = true;
                    if (string.Equals(info.FileName, targetExePath, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedPids.Add(info.Pid);
                    }
                }
            }

            if (matchedPids.Count == 0 && !anyAccessiblePath)
            {
                foreach (RunningProcInfo info in candidates)
                {
                    matchedPids.Add(info.Pid);
                }
            }

            return matchedPids;
        }

        private void GetCellDimensions(out int cellWidth, out int cellHeight, out int iconDimension)
        {
            switch (ThisCategory.IconSizeMode)
            {
                case 0: // Compact
                    cellWidth = ThisCategory.showLabels ? 52 : 44;
                    cellHeight = 38;
                    iconDimension = 18;
                    break;
                case 2: // Large
                    cellWidth = ThisCategory.showLabels ? 72 : 68;
                    cellHeight = 56;
                    iconDimension = 32;
                    break;
                default: // Medium (1)
                    cellWidth = ThisCategory.showLabels ? 62 : 55;
                    cellHeight = 45;
                    iconDimension = 23;
                    break;
            }

            if (ThisCategory.showLabels)
            {
                cellHeight += 15;
            }
        }

        // Loading category and building shortcuts
        private void LoadCategory()
        {
            GetCellDimensions(out int cellWidth, out int cellHeight, out int iconDimension);

            this.Width = 0;
            this.Height = cellHeight;
            int x = 0;
            int y = 0;
            int width = ThisCategory.Width;
            int columns = 1;

            // Check if icon caches exist for the category being loaded
            // If not then rebuild the icon cache
            if (!Directory.Exists(@MainPath.path + @"\config\" + ThisCategory.Name + @"\Icons\"))
            {
                ThisCategory.cacheIcons();
            }

            Dictionary<string, List<RunningProcInfo>> runningByName;
            List<RunningProcInfo> allRunning;
            CaptureRunningProcesses(out runningByName, out allRunning);

            foreach (ProgramShortcut psc in ThisCategory.ShortcutList)
            {

                if (columns > width)  // creating new row if there are more psc than max width
                {
                    x = 0;
                    y += cellHeight;
                    this.Height += cellHeight;
                    columns = 1;
                }

                if (this.Width < (width * cellWidth))
                    this.Width += cellWidth;

                List<int> pids = GetShortcutProcessIds(psc, runningByName, allRunning);

                // Building shortcut controls
                ucShortcut pscPanel = new ucShortcut() 
                {
                    Psc = psc, 
                    MotherForm = this, 
                    ThisCategory = ThisCategory,
                    IsRunning = pids.Count > 0,
                    RunningProcessIds = pids,
                    IconDimension = iconDimension,
                    ShowLabel = ThisCategory.showLabels,
                    Size = new Size(cellWidth, cellHeight)
                };
                pscPanel.Location = new System.Drawing.Point(x, y);
                this.Controls.Add(pscPanel);
                this.ControlList.Add(pscPanel);
                pscPanel.Show();
                pscPanel.BringToFront();

                // Reset values
                x += cellWidth;
                columns++;
            }

            this.Width -= 2; // For some reason the width is 2 pixels larger than the shortcuts. Temporary fix
        }

        // OLD (Having some issues with the uc build, so keeping the old code below)
        private void BuildShortcutPanel(int x, int y, ProgramShortcut psc)
        {
            this.shortcutPic = new System.Windows.Forms.PictureBox();
            this.shortcutPic.BackColor = System.Drawing.Color.Transparent;
            this.shortcutPic.Location = new System.Drawing.Point(25, 15);
            this.shortcutPic.Size = new System.Drawing.Size(25, 25);
            this.shortcutPic.BackgroundImage = ThisCategory.loadImageCache(psc); // Use the local icon cache for the file specified as the icon image
            this.shortcutPic.BackgroundImageLayout = ImageLayout.Stretch;
            this.shortcutPic.TabStop = false;
            this.shortcutPic.Click += new System.EventHandler((sender, e) => OpenFile(psc.Arguments, psc.FilePath, psc.WorkingDirectory));
            this.shortcutPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shortcutPanel.Controls.Add(this.shortcutPic);
            this.shortcutPic.Show();
            this.shortcutPic.BringToFront();
            this.shortcutPic.MouseEnter += new System.EventHandler((sender, e) => this.shortcutPanel.BackColor = Color.Black);
            this.shortcutPic.MouseLeave += new System.EventHandler((sender, e) => this.shortcutPanel.BackColor = System.Drawing.Color.Transparent);
        }

        // Click handler for shortcuts
        public void OpenFile(string arguments, string path, string workingDirec, bool runAsAdmin = false)
        {
            // starting program from psc panel click
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.Arguments = arguments;
            proc.FileName = path;
            proc.WorkingDirectory = workingDirec;
            if (runAsAdmin)
            {
                proc.Verb = "runas";
                proc.UseShellExecute = true;
            }

            try
            {
                Process.Start(proc);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void ShowShortcutContextMenu(ucShortcut shortcut, Point screenLocation)
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                BackColor = Color.FromArgb(31, 31, 31),
                ForeColor = Color.White,
                ShowImageMargin = false
            };

            if (shortcut.IsRunning && shortcut.RunningProcessIds != null && shortcut.RunningProcessIds.Count > 0)
            {
                ToolStripMenuItem switchItem = new ToolStripMenuItem(Localization.T("ctx_switch_window"))
                {
                    BackColor = Color.FromArgb(31, 31, 31),
                    ForeColor = Color.White
                };
                switchItem.Click += (s, e) =>
                {
                    WindowHelper.ActivateProcessWindow(shortcut.RunningProcessIds);
                    this.Close();
                };
                menu.Items.Add(switchItem);

                ToolStripMenuItem closeItem = new ToolStripMenuItem(Localization.T("ctx_close_window"))
                {
                    BackColor = Color.FromArgb(31, 31, 31),
                    ForeColor = Color.White
                };
                closeItem.Click += (s, e) =>
                {
                    WindowHelper.CloseProcessWindows(shortcut.RunningProcessIds);
                    shortcut.IsRunning = false;
                    shortcut.RunningProcessIds.Clear();
                    shortcut.ApplyDefaultBackColor();
                };
                menu.Items.Add(closeItem);
                menu.Items.Add(new ToolStripSeparator());
            }

            ToolStripMenuItem openNewItem = new ToolStripMenuItem(Localization.T("ctx_open_new"))
            {
                BackColor = Color.FromArgb(31, 31, 31),
                ForeColor = Color.White
            };
            openNewItem.Click += (s, e) =>
            {
                shortcut.LaunchShortcut(false);
                this.Close();
            };
            menu.Items.Add(openNewItem);

            if (!shortcut.Psc.isWindowsApp && !Directory.Exists(shortcut.Psc.FilePath))
            {
                ToolStripMenuItem adminItem = new ToolStripMenuItem(Localization.T("ctx_run_admin"))
                {
                    BackColor = Color.FromArgb(31, 31, 31),
                    ForeColor = Color.White
                };
                adminItem.Click += (s, e) =>
                {
                    shortcut.LaunchShortcut(true);
                    this.Close();
                };
                menu.Items.Add(adminItem);
            }

            if (!shortcut.Psc.isWindowsApp && (System.IO.File.Exists(shortcut.Psc.FilePath) || Directory.Exists(shortcut.Psc.FilePath)))
            {
                ToolStripMenuItem locationItem = new ToolStripMenuItem(Localization.T("ctx_open_location"))
                {
                    BackColor = Color.FromArgb(31, 31, 31),
                    ForeColor = Color.White
                };
                locationItem.Click += (s, e) =>
                {
                    Process.Start("explorer.exe", $"/select,\"{shortcut.Psc.FilePath}\"");
                    this.Close();
                };
                menu.Items.Add(locationItem);
            }

            menu.Closed += (s, e) =>
            {
                isContextMenuOpen = false;
                if (!this.IsDisposed)
                {
                    this.BeginInvoke((Action)(() => menu.Dispose()));
                }
            };

            isContextMenuOpen = true;
            menu.Show(screenLocation);
        }

        // Closes application upon deactivation
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            // closes program if user clicks outside form
            if (!isContextMenuOpen)
            {
                this.Close();
            }
        }

        private void SelectShortcutByIndex(int newIndex)
        {
            if (ControlList == null || ControlList.Count == 0)
                return;

            if (newIndex < 0)
                newIndex = 0;
            else if (newIndex >= ControlList.Count)
                newIndex = ControlList.Count - 1;

            if (selectedIndex >= 0 && selectedIndex < ControlList.Count)
            {
                ControlList[selectedIndex].ucShortcut_MouseLeave(this, EventArgs.Empty);
            }

            selectedIndex = newIndex;
            ControlList[selectedIndex].ucShortcut_MouseEnter(this, EventArgs.Empty);
        }

        // Keyboard shortcut handlers
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlList == null || ControlList.Count == 0)
                return;

            int cols = Math.Max(1, ThisCategory.Width);

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    return;
                case Keys.Left:
                    SelectShortcutByIndex(selectedIndex <= 0 ? 0 : selectedIndex - 1);
                    return;
                case Keys.Right:
                    SelectShortcutByIndex(selectedIndex < 0 ? 0 : selectedIndex + 1);
                    return;
                case Keys.Up:
                    SelectShortcutByIndex(selectedIndex < 0 ? 0 : Math.Max(0, selectedIndex - cols));
                    return;
                case Keys.Down:
                    SelectShortcutByIndex(selectedIndex < 0 ? 0 : Math.Min(ControlList.Count - 1, selectedIndex + cols));
                    return;
                case Keys.Enter:
                    if (e.Modifiers != Keys.Control && selectedIndex >= 0 && selectedIndex < ControlList.Count)
                    {
                        ControlList[selectedIndex].ucShortcut_Click(sender, e);
                    }
                    return;
            }

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.D1: SelectShortcutByIndex(0); break;
                    case Keys.D2: SelectShortcutByIndex(1); break;
                    case Keys.D3: SelectShortcutByIndex(2); break;
                    case Keys.D4: SelectShortcutByIndex(3); break;
                    case Keys.D5: SelectShortcutByIndex(4); break;
                    case Keys.D6: SelectShortcutByIndex(5); break;
                    case Keys.D7: SelectShortcutByIndex(6); break;
                    case Keys.D8: SelectShortcutByIndex(7); break;
                    case Keys.D9: SelectShortcutByIndex(8); break;
                    case Keys.D0: SelectShortcutByIndex(9); break;
                }
            }
            catch
            {
            }
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter && ThisCategory.allowOpenAll)
            {
                foreach (ucShortcut usc in this.ControlList)
                    usc.ucShortcut_Click(sender, e);
            }

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        ControlList[0].ucShortcut_MouseLeave(sender, e);
                        ControlList[0].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D2:
                        ControlList[1].ucShortcut_MouseLeave(sender, e);
                        ControlList[1].ucShortcut_Click(sender, e);

                        break;
                    case Keys.D3:
                        ControlList[2].ucShortcut_MouseLeave(sender, e);
                        ControlList[2].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D4:
                        ControlList[3].ucShortcut_MouseLeave(sender, e);
                        ControlList[3].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D5:
                        ControlList[4].ucShortcut_MouseLeave(sender, e);
                        ControlList[4].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D6:
                        ControlList[5].ucShortcut_MouseLeave(sender, e);
                        ControlList[5].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D7:
                        ControlList[6].ucShortcut_MouseLeave(sender, e);
                        ControlList[6].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D8:
                        ControlList[7].ucShortcut_MouseLeave(sender, e);
                        ControlList[7].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D9:
                        ControlList[8].ucShortcut_MouseLeave(sender, e);
                        ControlList[8].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D0:
                        ControlList[9].ucShortcut_MouseLeave(sender, e);
                        ControlList[9].ucShortcut_Click(sender, e);
                        break;
                }
            }
            catch
            {

            }
        }

        //
        // endregion
        //
        public System.Windows.Forms.PictureBox shortcutPic;
        public System.Windows.Forms.Panel shortcutPanel;
        //
        // END OF CLASS
        //
    }
}
