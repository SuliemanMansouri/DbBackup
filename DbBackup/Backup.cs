using DbBackup;
using Microsoft.Data.SqlClient;
using System.IO.Compression;
using System.Text.Json;

namespace BbBackup
{
    public partial class Backup : Form
    {
        private NotifyIcon trayIcon;
        private bool allowClose = false;
        private BackupConfig currentConfig;
        private System.Windows.Forms.Timer scheduleTimer;
        private HashSet<string> triggeredTimes = new HashSet<string>();
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem removableStatusMenuItem;
        private ToolStripMenuItem scheduleStatusMenuItem;

        public Backup()
        {
            InitializeComponent();
            // Add NotifyIcon for system tray
            trayIcon = new NotifyIcon();
            trayIcon.Icon = SystemIcons.Application; // You can set your own icon here
            trayIcon.Text = "»—‰«„Ã «·‰”Œ «·«Õ Ì«ÿÌ";
            trayIcon.Visible = false;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.Icon = new Icon("DbBackup.ico");

            // Start minimized
            WindowState = FormWindowState.Minimized;

            // Load config
            currentConfig = LoadConfig();

            // Setup schedule timer
            scheduleTimer = new System.Windows.Forms.Timer();
            scheduleTimer.Interval = 60 * 1000; // 1 minute
            scheduleTimer.Tick += ScheduleTimer_Tick;
            if (currentConfig.UseSchedule)
                scheduleTimer.Start();

            // Setup tray context menu
            trayMenu = new ContextMenuStrip();
            var backupMenuItem = new ToolStripMenuItem("‰”Œ «Õ Ì«ÿÌ «·¬‰");
            backupMenuItem.Click += (s, e) => BackpButton_Click(this, EventArgs.Empty);
            var exitMenuItem = new ToolStripMenuItem("≈€·«ﬁ «·»—‰«„Ã");
            exitMenuItem.Click += (s, e) => ExitApp();
            removableStatusMenuItem = new ToolStripMenuItem("«·‰”Œ ≈·Ï ÊÕœ… Œ«—ÃÌ…") { Enabled = false };
            scheduleStatusMenuItem = new ToolStripMenuItem("«·ÃœÊ·… «· ·ﬁ«∆Ì…") { Enabled = false };
            trayMenu.Items.Add(backupMenuItem);
            trayMenu.Items.Add(exitMenuItem);
            trayMenu.Items.Add(new ToolStripSeparator());
            trayMenu.Items.Add(removableStatusMenuItem);
            trayMenu.Items.Add(scheduleStatusMenuItem);
            trayIcon.ContextMenuStrip = trayMenu;
            trayMenu.Opening += TrayMenu_Opening;
        }

        private void ScheduleTimer_Tick(object sender, EventArgs e)
        {
            currentConfig = LoadConfig(); // Reload config in case it changed
            if (!currentConfig.UseSchedule || currentConfig.ScheduledTimes == null)
                return;
            string now = DateTime.Now.ToString("HH:mm");
            if (currentConfig.ScheduledTimes.Contains(now) && !triggeredTimes.Contains(now))
            {
                triggeredTimes.Add(now);
                RunBackup(scheduled: true);
            }
            // Reset triggeredTimes at midnight
            if (now == "00:00")
                triggeredTimes.Clear();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;

            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            trayIcon.Dispose();
            base.OnFormClosing(e);
        }

        public void ExitApp()
        {
            allowClose = true;
            Close();
        }

        private BackupConfig LoadConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backupconfig.json");
            string json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<BackupConfig>(json);
            if (config == null)
                throw new InvalidOperationException("Failed to deserialize backupconfig.json.");
            return config;
        }

        private void BackupDatabase(string server, string database, string backupPath)
        {
            string connectionString = $"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True;";
            string sql = $"BACKUP DATABASE [{database}] TO DISK = N'{backupPath}' WITH INIT, FORMAT";
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        private void BackpButton_Click(object sender, EventArgs e)
        {
            RunBackup(scheduled: false);
        }

        private void RunBackup(bool scheduled)
        {
            try
            {
                var config = LoadConfig();
                if (config.Destinations == null || config.Destinations.Count == 0)
                    throw new InvalidOperationException("No backup destinations configured.");
                string firstDest = config.Destinations[0];
                Directory.CreateDirectory(firstDest); // Ensure folder exists
                string backupFile = $"{config.Database}_{DateTime.Now:yyyyMMddHHmmss}.bak";
                string backupPath = Path.Combine(firstDest, backupFile); // Use first destination for .bak
                BackupDatabase(config.Server, config.Database, backupPath);

                string zipPath = backupPath + ".zip";
                using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(backupPath, Path.GetFileName(backupPath));
                }
                File.Delete(backupPath);

                // Copy zip to all destinations except the first
                for (int i = 1; i < config.Destinations.Count; i++)
                {
                    var dest = config.Destinations[i];
                    Directory.CreateDirectory(dest);
                    File.Copy(zipPath, Path.Combine(dest, Path.GetFileName(zipPath)), true);
                }

                // Removable drive logic
                if (config.SaveToRemovable)
                {
                    var removable = DriveInfo.GetDrives()
                        .FirstOrDefault(d => d.DriveType == DriveType.Removable && d.IsReady);
                    if (removable != null)
                    {
                        string removableDest = Path.Combine(removable.RootDirectory.FullName, Path.GetFileName(zipPath));
                        File.Copy(zipPath, removableDest, true);
                    }
                }

                // Do NOT delete the zip file in the first destination
                if (!scheduled)
                    MessageBox.Show("«ﬂ „· «·‰”Œ «·«Õ Ì«ÿÌ Ê«·÷€ÿ Ê«·‰”Œ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Œÿ√: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Already handled in constructor
        }

        
        private void OpenEditorButton_Click(object sender, EventArgs e)
        {
            var editor = new Editor();
            editor.ShowDialog();
        }

        private void TrayMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var config = LoadConfig();
            removableStatusMenuItem.Checked = config.SaveToRemovable;
            scheduleStatusMenuItem.Checked = config.UseSchedule;
        }
    }
}
