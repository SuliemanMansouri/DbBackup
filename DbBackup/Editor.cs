using System.Text.Json;

namespace DbBackup
{
    public partial class Editor : Form
    {
        private string configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backupconfig.json");
        private BackupConfig config;

        public Editor()
        {
            InitializeComponent();
            btnAddDestination.Click += BtnAddDestination_Click;
            btnRemoveDestination.Click += BtnRemoveDestination_Click;
            btnAddTime.Click += BtnAddTime_Click;
            btnRemoveTime.Click += BtnRemoveTime_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(configPath))
            {
                MessageBox.Show("·„ Ì „ «·⁄ÀÊ— ⁄·Ï „·› «·≈⁄œ«œ« .");
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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (config == null)
                config = new BackupConfig();
            config.Server = txtServer.Text;
            config.Database = txtDatabase.Text;
            config.Destinations = lstDestinations.Items.Cast<string>().ToList();
            config.SaveToRemovable = chkSaveToRemovable.Checked;
            config.UseSchedule = chkUseSchedule.Checked;
            config.ScheduledTimes = lstScheduledTimes.Items.Cast<string>().ToList();
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(configPath, json);
            MessageBox.Show(" „ Õ›Ÿ «·≈⁄œ«œ«  »‰Ã«Õ.");
        }

        private void BtnAddDestination_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("√œŒ· „”«— «·„Ã·œ:", "≈÷«›… ÊÃÂ…");
            if (!string.IsNullOrWhiteSpace(input))
                lstDestinations.Items.Add(input);
        }

        private void BtnRemoveDestination_Click(object sender, EventArgs e)
        {
            if (lstDestinations.SelectedItem != null)
                lstDestinations.Items.Remove(lstDestinations.SelectedItem);
        }

        private void BtnAddTime_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("√œŒ· «·Êﬁ  (HH:mm):", "≈÷«›… Êﬁ ");
            if (!string.IsNullOrWhiteSpace(input))
                lstScheduledTimes.Items.Add(input);
        }

        private void BtnRemoveTime_Click(object sender, EventArgs e)
        {
            if (lstScheduledTimes.SelectedItem != null)
                lstScheduledTimes.Items.Remove(lstScheduledTimes.SelectedItem);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            BtnLoad_Click(sender, e);
        }
    }


}
