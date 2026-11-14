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
        private bool suppressLangChange = false;
        private bool suppressSortChange = false;
        private string latestVersionStatusKey = "checking";

        public frmClient()
        {
            System.Runtime.ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            InitLanguageSelector();
            ApplyLocalization();
            cmbSort.SelectedIndex = 0;

            currentVersion.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            Reload();
        }

        private void InitLanguageSelector()
        {
            suppressLangChange = true;
            cmbLanguage.Items.Clear();
            int selectedIndex = 0;
            for (int i = 0; i < Localization.SupportedLanguages.Length; i++)
            {
                LanguageInfo lang = Localization.SupportedLanguages[i];
                cmbLanguage.Items.Add(lang);
                if (string.Equals(lang.Code, Localization.CurrentLanguage, StringComparison.OrdinalIgnoreCase))
                    selectedIndex = i;
            }
            cmbLanguage.SelectedIndex = selectedIndex;
            suppressLangChange = false;
        }

        public void ApplyLocalization()
        {
            this.Text = Localization.T("app_title");
            label1.Text = Localization.T("app_title");
            label2.Text = Localization.T("app_subtitle");
            label3.Text = Localization.T("help_when_opens");
            lblHelp1.Text = Localization.T("help_step1");
            lblHelp2.Text = Localization.T("help_step2");
            lblHelp3.Text = Localization.T("help_step3");
            label4.Text = Localization.T("issues_title");
            label5.Text = Localization.T("issues_prompt");
            githubLink.Text = Localization.T("issues_link");
            label6.Text = Localization.T("current_version");
            githubLabel.Text = Localization.T("latest_version");
            if (latestVersionStatusKey != null)
                githubVersion.Text = Localization.T(latestVersionStatusKey);

            lblSearchHint.Text = Localization.T("search_hint");
            cmdClearSearch.Text = Localization.T("btn_clear");
            cmdAddGroupBtn.Text = Localization.T("btn_add_group");
            cmdImportGroup.Text = Localization.T("btn_import_group");

            int currentSort = cmbSort.SelectedIndex >= 0 ? cmbSort.SelectedIndex : 0;
            suppressSortChange = true;
            cmbSort.Items.Clear();
            cmbSort.Items.AddRange(new object[]
            {
                Localization.T("sort_default"),
                Localization.T("sort_az"),
                Localization.T("sort_za")
            });
            cmbSort.SelectedIndex = currentSort;
            suppressSortChange = false;

            UpdateHelpTitle();
        }

        private void UpdateHelpTitle()
        {
            if (loadedCategories.Count > 0)
            {
                lblHelpTitle.Text = Localization.T("help_title_has_groups");
                pnlHelp.Visible = true;
            }
            else
            {
                lblHelpTitle.Text = Localization.T("help_title_empty");
                pnlHelp.Visible = false;
            }
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            var (statusKey, tag) = await getVersionData();
            latestVersionStatusKey = statusKey;
            githubVersion.Text = statusKey != null ? Localization.T(statusKey) : tag;
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

            UpdateHelpTitle();

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
            if (suppressSortChange)
                return;
            ApplyFilterAndSort();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressLangChange)
                return;
            if (cmbLanguage.SelectedItem is LanguageInfo lang)
            {
                Localization.SetLanguage(lang.Code);
                ApplyLocalization();
                ApplyFilterAndSort();
            }
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
                Title = Localization.T("import_group_title"),
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
                    MessageBox.Show(Localization.T("import_invalid_archive"), Localization.T("import_group_title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(Localization.F("import_failed", ex.Message), Localization.T("import_group_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private static async Task<(string statusKey, string tag)> getVersionData()
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
                    return ("no_releases", null);

                JsonObject jsonObjectData = responseJSON[0].GetObject();
                return (null, jsonObjectData["tag_name"].GetString());
            }
            catch
            {
                return ("not_found", null);
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
