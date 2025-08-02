using SM.SqlBackup.WinForms;
using System.Text.Json;

namespace DbBackup
{
    public partial class Editor : Form
    {
        private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backupconfig.json");
        // Change the declarations of 'config' and 'lastLoadedConfig' to nullable types to resolve CS8618
        private BackupConfig? config;
        private bool hasPendingChanges = false;
        private BackupConfig? lastLoadedConfig;
        

        public Editor()
        {
            InitializeComponent();
            btnAddDestination.Click += BtnAddDestination_Click;
            btnRemoveDestination.Click += BtnRemoveDestination_Click;
            btnAddTime.Click += BtnAddTime_Click;
            btnRemoveTime.Click += BtnRemoveTime_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            // Track changes in controls
            txtServer.TextChanged += (s, e) => hasPendingChanges = true;
            txtDatabase.TextChanged += (s, e) => hasPendingChanges = true;
            lstDestinations.SelectedIndexChanged += (s, e) => hasPendingChanges = true;
            lstDestinations.TextChanged += (s, e) => hasPendingChanges = true;
            chkSaveToRemovable.CheckedChanged += (s, e) => hasPendingChanges = true;
            chkUseSchedule.CheckedChanged += (s, e) => hasPendingChanges = true;
            lstScheduledTimes.SelectedIndexChanged += (s, e) => hasPendingChanges = true;
            lstScheduledTimes.TextChanged += (s, e) => hasPendingChanges = true;
            
        }

        private void BtnLoad_Click(object? sender, EventArgs e)
        {
            if (!File.Exists(configPath))
            {
                MessageBox.Show("·« ÌÊÃœ „·› ≈⁄œ«œ«  »⁄œ.");
                return;
            }
            var json = System.IO.File.ReadAllText(configPath);
            config = JsonSerializer.Deserialize<BackupConfig>(json);
            if (config == null)
            {
                MessageBox.Show(" ⁄–— ﬁ—«¡… „·› «·≈⁄œ«œ« .");
                return;
            }
            txtServer.Text = config.Server;
            txtDatabase.Text = config.Database;
            lstDestinations.Items.Clear();
            if (config.Destinations != null)
                lstDestinations.Items.AddRange(config.Destinations.ToArray());
            chkSaveToRemovable.Checked = config.SaveToRemovable;
            chkUseSchedule.Checked = config.UseSchedule;
            lstScheduledTimes.Items.Clear();
            if (config.ScheduledTimes != null)
                lstScheduledTimes.Items.AddRange(config.ScheduledTimes.ToArray());
            numMaxCopies.Value = config.MaxCopies > 0 ? config.MaxCopies : 7;
            ShowConfirmationMessageCheckBox.Checked = config.ShowConfirmationMessage;
            lastLoadedConfig = CloneConfig(config);
            hasPendingChanges = false;
        }

        private BackupConfig CloneConfig(BackupConfig source)
        {
            return new BackupConfig
            {
                Server = source.Server,
                Database = source.Database,
                Destinations = source.Destinations != null ? new List<string>(source.Destinations) : new List<string>(),
                SaveToRemovable = source.SaveToRemovable,
                UseSchedule = source.UseSchedule,
                ScheduledTimes = source.ScheduledTimes != null ? new List<string>(source.ScheduledTimes) : new List<string>(),
                MaxCopies = source.MaxCopies,
                ShowConfirmationMessage = source.ShowConfirmationMessage
            };
        }

        private bool IsConfigChanged()
        {
            if (lastLoadedConfig == null) return false;
            if (txtServer.Text != lastLoadedConfig.Server) return true;
            if (txtDatabase.Text != lastLoadedConfig.Database) return true;
            if (chkSaveToRemovable.Checked != lastLoadedConfig.SaveToRemovable) return true;
            if (chkUseSchedule.Checked != lastLoadedConfig.UseSchedule) return true;
            if (lstDestinations.Items.Count != lastLoadedConfig.Destinations.Count) return true;
            for (int i = 0; i < lstDestinations.Items.Count; i++)
                if ((string)lstDestinations.Items[i] != lastLoadedConfig.Destinations[i]) return true;
            if (lstScheduledTimes.Items.Count != lastLoadedConfig.ScheduledTimes.Count) return true;
            for (int i = 0; i < lstScheduledTimes.Items.Count; i++)
                if ((string)lstScheduledTimes.Items[i] != lastLoadedConfig.ScheduledTimes[i]) return true;
            if ((int)numMaxCopies.Value != lastLoadedConfig.MaxCopies) return true;
            return false;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (config == null)
                config = new BackupConfig();
            config.Server = txtServer.Text;
            config.Database = txtDatabase.Text;
            config.Destinations = lstDestinations.Items.Cast<string>().ToList();
            config.SaveToRemovable = chkSaveToRemovable.Checked;
            config.UseSchedule = chkUseSchedule.Checked;
            config.ScheduledTimes = lstScheduledTimes.Items.Cast<string>().ToList();
            config.MaxCopies = (int)numMaxCopies.Value;
            config.ShowConfirmationMessage = ShowConfirmationMessageCheckBox.Checked;
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(configPath, json);
            MessageBox.Show(" „ Õ›Ÿ «·≈⁄œ«œ«  »‰Ã«Õ.");
            hasPendingChanges = false;
            lastLoadedConfig = CloneConfig(config); // Ensure config is up to date for change tracking
        }

        // Update all event handler signatures to explicitly allow nullable sender
        private void BtnAddDestination_Click(object? sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("√œŒ· „”«— «·„Ã·œ:", "≈÷«›… ÊÃÂ…");
            if (!string.IsNullOrWhiteSpace(input))
                lstDestinations.Items.Add(input);
        }

        private void BtnRemoveDestination_Click(object? sender, EventArgs e)
        {
            if (lstDestinations.SelectedItem != null)
                lstDestinations.Items.Remove(lstDestinations.SelectedItem);
        }

        private void BtnAddTime_Click(object? sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("√œŒ· «·Êﬁ  (HH:mm):", "≈÷«›… Êﬁ ");
            if (!string.IsNullOrWhiteSpace(input))
                lstScheduledTimes.Items.Add(input);
        }

        private void BtnRemoveTime_Click(object? sender, EventArgs e)
        {
            if (lstScheduledTimes.SelectedItem != null)
                lstScheduledTimes.Items.Remove(lstScheduledTimes.SelectedItem);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void Editor_Load(object? sender, EventArgs e)
        {
            BtnLoad_Click(sender, e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsConfigChanged())
            {
                var result = MessageBox.Show("Â‰«ﬂ  €ÌÌ—«  €Ì— „Õ›ÊŸ… ›Ì «·≈⁄œ«œ« . Â·  —Ìœ «·„ «»⁄… »œÊ‰ Õ›Ÿø", " √ﬂÌœ «·≈€·«ﬁ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (config == null || config.Destinations == null || config.Destinations.Count == 0)
            {
                MessageBox.Show("ÌÃ»  ÕœÌœ „Ã·œ Ê«Õœ ⁄·Ï «·√ﬁ· ··‰”Œ «·«Õ Ì«ÿÌ ﬁ»· ≈€·«ﬁ ‰«›–… «·≈⁄œ«œ« .");
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }
    }


}
