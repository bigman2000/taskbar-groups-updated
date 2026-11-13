using client.Classes;
using client.User_controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Json;

namespace client.Forms
{
    public partial class frmClient : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly List<Category> loadedCategories = new List<Category>();

        public frmClient()
        {
            System.Runtime.ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            cmbSort.SelectedIndex = 0;

            currentVersion.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            Reload();
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            githubVersion.Text = await getVersionData();
        }

        public void Reload()
        {
            loadedCategories.Clear();
            string configPath = @MainPath.path + @"\config";
            if (!Directory.Exists(configPath))
                Directory.CreateDirectory(configPath);

            string[] subDirectories = Directory.GetDirectories(configPath);
            foreach (string dir in subDirectories)
            {
                try
                {
                    loadedCategories.Add(new Category(dir));
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (loadedCategories.Count > 0)
            {
                lblHelpTitle.Text = "Click on a group to add a taskbar shortcut";
                pnlHelp.Visible = true;
            }
            else
            {
                lblHelpTitle.Text = "Press on \"Add taskbar group\" to get started";
                pnlHelp.Visible = false;
            }

            ApplyFilterAndSort();
        }

        public void LoadCategory(string dir)
        {
            Category category = new Category(dir);
            loadedCategories.Add(category);
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            pnlExistingGroups.SuspendLayout();
            pnlExistingGroups.Controls.Clear();
            pnlExistingGroups.Height = 0;

            string query = txtSearch.Text.Trim();
            IEnumerable<Category> filtered = loadedCategories;

            if (!string.IsNullOrEmpty(query))
            {
                filtered = filtered.Where(cat => MatchesQuery(cat, query));
            }

            if (cmbSort.SelectedIndex == 1)
            {
                filtered = filtered.OrderBy(cat => Regex.Replace(cat.Name, @"(_)+", " "), StringComparer.CurrentCultureIgnoreCase);
            }
            else if (cmbSort.SelectedIndex == 2)
            {
                filtered = filtered.OrderByDescending(cat => Regex.Replace(cat.Name, @"(_)+", " "), StringComparer.CurrentCultureIgnoreCase);
            }

            int cardWidth = Math.Max(660, pnlGroupsScroll.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 24);
            foreach (Category category in filtered)
            {
                ucCategoryPanel newCategory = new ucCategoryPanel(this, category);
                newCategory.Width = cardWidth;
                newCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                pnlExistingGroups.Height += newCategory.Height;
                pnlExistingGroups.Controls.Add(newCategory);
                newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
                newCategory.Show();
                newCategory.BringToFront();
                newCategory.MouseEnter += (sender, e) => EnterControl(sender, e, newCategory);
                newCategory.MouseLeave += (sender, e) => LeaveControl(sender, e, newCategory);
            }

            pnlExistingGroups.Width = cardWidth;
            pnlExistingGroups.ResumeLayout(true);
            Reset();
        }

        private static bool MatchesQuery(Category cat, string query)
        {
            string displayName = Regex.Replace(cat.Name ?? "", @"(_)+", " ");
            if (displayName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            if (cat.ShortcutList != null)
            {
                foreach (ProgramShortcut psc in cat.ShortcutList)
                {
                    if (!string.IsNullOrEmpty(psc.name) && psc.name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                    string fileName = Path.GetFileNameWithoutExtension(psc.FilePath ?? "");
                    if (!string.IsNullOrEmpty(fileName) && fileName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            int cardWidth = Math.Max(660, pnlGroupsScroll.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 24);
            pnlExistingGroups.Width = cardWidth;
            foreach (Control ctrl in pnlExistingGroups.Controls)
            {
                ctrl.Width = cardWidth;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bool hasText = !string.IsNullOrEmpty(txtSearch.Text);
            lblSearchHint.Visible = !hasText;
            cmdClearSearch.Visible = hasText;
            ApplyFilterAndSort();
        }

        private void cmdClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            frmGroup newGroup = new frmGroup(this);
            newGroup.Show();
            newGroup.BringToFront();
        }

        private void cmdImportGroup_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "Import Taskbar Group",
                CheckFileExists = true,
                Filter = "Taskbar Group Archive (*.tgroup;*.zip)|*.tgroup;*.zip"
            };

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            string tempDir = Path.Combine(Path.GetTempPath(), "TaskbarGroupImport_" + Guid.NewGuid().ToString("N"));
            try
            {
                ZipFile.ExtractToDirectory(openDialog.FileName, tempDir);
                string xmlPath = Path.Combine(tempDir, "ObjectData.xml");
                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show("Invalid group archive: ObjectData.xml not found.", "Import Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Category imported = new Category(tempDir);
                string baseName = string.IsNullOrWhiteSpace(imported.Name) ? "Imported_Group" : imported.Name;
                string finalName = baseName;
                int suffix = 2;
                while (Directory.Exists(Path.Combine(MainPath.path, "config", finalName)))
                {
                    finalName = $"{baseName}_{suffix}";
                    suffix++;
                }

                imported.Name = finalName;
                string targetDir = Path.Combine(MainPath.path, "config", finalName);
                Directory.CreateDirectory(targetDir);

                foreach (string file in Directory.GetFiles(tempDir, "*", SearchOption.AllDirectories))
                {
                    string relPath = file.Substring(tempDir.Length).TrimStart(Path.DirectorySeparatorChar);
                    string destFile = Path.Combine(targetDir, relPath);
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                    File.Copy(file, destFile, true);
                }

                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Category));
                using (FileStream fs = File.Create(Path.Combine(targetDir, "ObjectData.xml")))
                {
                    writer.Serialize(fs, imported);
                }

                string shortcutDisplayName = Regex.Replace(finalName, @"(_)+", " ");
                string tempLnk = Path.Combine(targetDir, finalName + ".lnk");
                string finalLnk = Path.GetFullPath(Path.Combine(MainPath.path, "Shortcuts", shortcutDisplayName + ".lnk"));
                ShellLink.InstallShortcut(
                    Path.GetFullPath(AppDomain.CurrentDomain.FriendlyName),
                    "tjackenpacken.taskbarGroup.menu." + finalName,
                    targetDir + " shortcut",
                    Path.GetFullPath(targetDir),
                    Path.GetFullPath(Path.Combine(targetDir, "GroupIcon.ico")),
                    tempLnk,
                    finalName
                );
                if (File.Exists(finalLnk))
                    File.Delete(finalLnk);
                File.Move(tempLnk, finalLnk);

                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to import group: {ex.Message}", "Import Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    try { Directory.Delete(tempDir, true); } catch { }
                }
            }
        }

        public void EnterControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(30, 30, 30);
        }

        public void LeaveControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(18, 18, 18);
        }

        private static async Task<string> getVersionData()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "taskbar-groups-updated");
                var res = await client.GetAsync("https://api.github.com/repos/bigman2000/taskbar-groups-updated/releases");
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();

                JsonArray responseJSON = JsonArray.Parse(responseBody);
                if (responseJSON.Count == 0)
                    return "No releases";

                JsonObject jsonObjectData = responseJSON[0].GetObject();
                return jsonObjectData["tag_name"].GetString();
            }
            catch
            {
                return "Not found";
            }
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bigman2000/taskbar-groups-updated/issues");
        }

        private void githubVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bigman2000/taskbar-groups-updated/releases");
        }

        private void frmClient_Resize(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
