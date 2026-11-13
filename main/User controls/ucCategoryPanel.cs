using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using client.Classes;
using client.Forms;

namespace client.User_controls
{
    public partial class ucCategoryPanel : UserControl
    {
        public Category Category;
        public frmClient Client;

        private readonly List<PictureBox> miniIconPanels = new List<PictureBox>();
        private Label lblOverflowBadge;

        private bool isIconMouseDown = false;
        private bool isDraggingIcon = false;
        private bool suppressNextClick = false;
        private int lastDragEndTick = 0;
        private int draggingIconIndex = -1;
        private Point iconDragStartScreen;

        private const int IconStartX = 24;
        private const int IconY = 53;
        private const int IconStepX = 34;
        private const int IconSize = 26;
        private const int MaxIconAreaRight = 435;

        public ucCategoryPanel(frmClient client, Category category)
        {
            InitializeComponent();
            Client = client;
            Category = category;

            string displayName = Regex.Replace(Category.Name, @"(_)+", " ");
            lblTitle.Text = displayName;
            lblCount.Text = $"({Category.ShortcutList.Count})";
            lblCount.Location = new Point(lblTitle.Left + lblTitle.PreferredWidth + 6, 18);

            picGroupIcon.BackgroundImage = Category.LoadIconImage();

            BuildMiniIcons();
        }

        private void BuildMiniIcons()
        {
            foreach (PictureBox pb in miniIconPanels)
            {
                Controls.Remove(pb);
                pb.Dispose();
            }
            miniIconPanels.Clear();

            if (lblOverflowBadge != null)
            {
                Controls.Remove(lblOverflowBadge);
                lblOverflowBadge.Dispose();
                lblOverflowBadge = null;
            }

            if (components == null)
                components = new System.ComponentModel.Container();

            ToolTip tt = new ToolTip(components)
            {
                InitialDelay = 200,
                ReshowDelay = 100,
                ShowAlways = true
            };

            int maxSlots = (MaxIconAreaRight - IconStartX) / IconStepX;
            bool hasOverflow = Category.ShortcutList.Count > maxSlots;
            int visibleCount = hasOverflow ? Math.Max(1, maxSlots - 1) : Category.ShortcutList.Count;

            for (int i = 0; i < visibleCount; i++)
            {
                ProgramShortcut programShortcut = Category.ShortcutList[i];
                PictureBox pb = new PictureBox
                {
                    BackColor = Color.Transparent,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Location = new Point(IconStartX + i * IconStepX, IconY),
                    Size = new Size(IconSize, IconSize),
                    Tag = i
                };

                bool exists = File.Exists(programShortcut.FilePath) || Directory.Exists(programShortcut.FilePath) || programShortcut.isWindowsApp;
                if (exists)
                {
                    pb.BackgroundImage = Category.loadImageCache(programShortcut);
                    tt.SetToolTip(pb, GetShortcutDisplayName(programShortcut));
                }
                else
                {
                    pb.BackgroundImage = global::client.Properties.Resources.Error;
                    tt.SetToolTip(pb, "Program does not exist");
                }

                pb.MouseEnter += (s, e) => Client.EnterControl(s, e, this);
                pb.MouseLeave += (s, e) => Client.LeaveControl(s, e, this);
                pb.MouseDown += MiniIcon_MouseDown;
                pb.MouseMove += MiniIcon_MouseMove;
                pb.MouseUp += MiniIcon_MouseUp;
                pb.Click += MiniIcon_Click;

                Controls.Add(pb);
                pb.BringToFront();
                miniIconPanels.Add(pb);
            }

            if (hasOverflow)
            {
                int remaining = Category.ShortcutList.Count - visibleCount;
                lblOverflowBadge = new Label
                {
                    AutoSize = false,
                    BackColor = Color.FromArgb(42, 42, 42),
                    ForeColor = Color.FromArgb(200, 200, 200),
                    Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                    Text = $"+{remaining}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(IconStartX + visibleCount * IconStepX, IconY + 2),
                    Size = new Size(28, 22),
                    Cursor = Cursors.Hand
                };
                lblOverflowBadge.Click += OpenFolder;
                tt.SetToolTip(lblOverflowBadge, $"{remaining} more shortcuts");
                Controls.Add(lblOverflowBadge);
                lblOverflowBadge.BringToFront();
            }
        }

        private static string GetShortcutDisplayName(ProgramShortcut psc)
        {
            if (psc == null)
                return string.Empty;
            if (!string.IsNullOrWhiteSpace(psc.name))
                return psc.name;
            if (psc.isWindowsApp)
                return handleWindowsApp.findWindowsAppsName(psc.FilePath);
            if (File.Exists(psc.FilePath) && Path.GetExtension(psc.FilePath).ToLower() == ".lnk")
                return frmGroup.handleExtName(psc.FilePath);
            string name = Path.GetFileNameWithoutExtension(psc.FilePath);
            return string.IsNullOrEmpty(name) ? psc.FilePath : name;
        }

        private void MiniIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || miniIconPanels.Count <= 1)
                return;

            if (sender is PictureBox pb && pb.Tag is int idx)
            {
                isIconMouseDown = true;
                isDraggingIcon = false;
                suppressNextClick = false;
                draggingIconIndex = idx;
                iconDragStartScreen = pb.PointToScreen(e.Location);
            }
        }

        private void MiniIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isIconMouseDown || !(sender is PictureBox pb))
                return;

            if (!isDraggingIcon)
            {
                Point currentScreen = pb.PointToScreen(e.Location);
                int dx = Math.Abs(currentScreen.X - iconDragStartScreen.X);
                int dy = Math.Abs(currentScreen.Y - iconDragStartScreen.Y);
                if (dx >= SystemInformation.DragSize.Width || dy >= SystemInformation.DragSize.Height)
                {
                    isDraggingIcon = true;
                    pb.Capture = true;
                    pb.BackColor = Color.FromArgb(55, 55, 55);
                    Cursor = Cursors.SizeAll;
                }
            }

            if (isDraggingIcon)
            {
                Point clientPt = PointToClient(Cursor.Position);
                int targetIndex = (clientPt.X - IconStartX) / IconStepX;
                if (targetIndex < 0) targetIndex = 0;
                if (targetIndex >= miniIconPanels.Count) targetIndex = miniIconPanels.Count - 1;

                if (targetIndex != draggingIconIndex)
                {
                    MoveShortcutInCard(draggingIconIndex, targetIndex);
                    draggingIconIndex = targetIndex;
                }
            }
        }

        private void MiniIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            bool wasDragging = isDraggingIcon;
            isIconMouseDown = false;
            isDraggingIcon = false;

            if (sender is PictureBox pb)
            {
                pb.Capture = false;
                pb.BackColor = Color.Transparent;
            }
            Cursor = Cursors.Hand;

            if (wasDragging)
            {
                suppressNextClick = true;
                lastDragEndTick = Environment.TickCount;
                SaveReorderedCategory();
            }
        }

        private void MiniIcon_Click(object sender, EventArgs e)
        {
            if (isDraggingIcon || suppressNextClick)
            {
                suppressNextClick = false;
                return;
            }
            OpenFolder(sender, e);
        }

        private void MoveShortcutInCard(int fromIndex, int toIndex)
        {
            if (fromIndex == toIndex || fromIndex < 0 || toIndex < 0 ||
                fromIndex >= Category.ShortcutList.Count || toIndex >= Category.ShortcutList.Count)
                return;

            ProgramShortcut item = Category.ShortcutList[fromIndex];
            Category.ShortcutList.RemoveAt(fromIndex);
            Category.ShortcutList.Insert(toIndex, item);

            PictureBox movedPb = miniIconPanels[fromIndex];
            miniIconPanels.RemoveAt(fromIndex);
            miniIconPanels.Insert(toIndex, movedPb);

            for (int i = 0; i < miniIconPanels.Count; i++)
            {
                miniIconPanels[i].Tag = i;
                miniIconPanels[i].Location = new Point(IconStartX + i * IconStepX, IconY);
            }
        }

        private void SaveReorderedCategory()
        {
            try
            {
                string xmlPath = Path.Combine(MainPath.path, "config", Category.Name, "ObjectData.xml");
                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Category));
                using (FileStream fs = File.Create(xmlPath))
                {
                    writer.Serialize(fs, Category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save new order: {ex.Message}", "Taskbar Groups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucNewCategory_Load(object sender, EventArgs e)
        {
        }

        public void OpenFolder(object sender, EventArgs e)
        {
            if (isDraggingIcon || suppressNextClick || unchecked(Environment.TickCount - lastDragEndTick) < 250)
            {
                suppressNextClick = false;
                return;
            }

            string filePath = Path.GetFullPath(new Uri($"{MainPath.path}\\Shortcuts").LocalPath + "\\" + Regex.Replace(Category.Name, @"(_)+", " ") + ".lnk");
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", @filePath));
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            Point pos = Cursor.Position;
            frmMain previewForm = new frmMain(Category.Name, pos.X, pos.Y);
            previewForm.Show();
            previewForm.Activate();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            frmGroup editGroup = new frmGroup(Client, Category);
            editGroup.Show();
            editGroup.BringToFront();
        }

        private void cmdClone_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceDir = Path.Combine(MainPath.path, "config", Category.Name);
                if (!Directory.Exists(sourceDir))
                    return;

                string newName = Category.Name + "_copy";
                int suffix = 2;
                while (Directory.Exists(Path.Combine(MainPath.path, "config", newName)))
                {
                    newName = $"{Category.Name}_copy{suffix}";
                    suffix++;
                }

                string targetDir = Path.Combine(MainPath.path, "config", newName);
                CopyDirectory(sourceDir, targetDir);

                Category cloned = new Category(targetDir)
                {
                    Name = newName
                };

                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Category));
                using (FileStream file = File.Create(Path.Combine(targetDir, "ObjectData.xml")))
                {
                    writer.Serialize(file, cloned);
                }

                string shortcutDisplayName = Regex.Replace(newName, @"(_)+", " ");
                string tempLnk = Path.Combine(targetDir, newName + ".lnk");
                string finalLnk = Path.GetFullPath(Path.Combine(MainPath.path, "Shortcuts", shortcutDisplayName + ".lnk"));
                ShellLink.InstallShortcut(
                    Path.GetFullPath(AppDomain.CurrentDomain.FriendlyName),
                    "tjackenpacken.taskbarGroup.menu." + newName,
                    targetDir + " shortcut",
                    Path.GetFullPath(targetDir),
                    Path.GetFullPath(Path.Combine(targetDir, "GroupIcon.ico")),
                    tempLnk,
                    newName
                );
                if (File.Exists(finalLnk))
                    File.Delete(finalLnk);
                File.Move(tempLnk, finalLnk);

                Client.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to clone group: {ex.Message}", "Clone Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceDir = Path.Combine(MainPath.path, "config", Category.Name);
                if (!Directory.Exists(sourceDir))
                    return;

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Title = "Export Taskbar Group",
                    Filter = "Taskbar Group Archive (*.tgroup)|*.tgroup|Zip Archive (*.zip)|*.zip",
                    FileName = Regex.Replace(Category.Name, @"(_)+", " ") + ".tgroup"
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                if (File.Exists(saveDialog.FileName))
                    File.Delete(saveDialog.FileName);

                ZipFile.CreateFromDirectory(sourceDir, saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export group: {ex.Message}", "Export Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            string displayName = Regex.Replace(Category.Name, @"(_)+", " ");
            DialogResult res = MessageBox.Show(
                $"Delete group \"{displayName}\"?",
                "Delete Group",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (res != DialogResult.Yes)
                return;

            try
            {
                string configPath = Path.Combine(MainPath.path, "config", Category.Name);
                string shortcutPath = Path.Combine(MainPath.path, "Shortcuts", displayName + ".lnk");
                if (Directory.Exists(configPath))
                    Directory.Delete(configPath, true);
                if (File.Exists(shortcutPath))
                    File.Delete(shortcutPath);

                Client.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete group: {ex.Message}", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);
            }
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                CopyDirectory(subDir, Path.Combine(destDir, Path.GetFileName(subDir)));
            }
        }

        public static Bitmap LoadBitmap(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                return new Bitmap(memoryStream);
            }
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            Client.EnterControl(sender, e, this);
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            Client.LeaveControl(sender, e, this);
        }
    }
}
