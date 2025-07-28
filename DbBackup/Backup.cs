using DbBackup;
using System;
using System.Windows.Forms;

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
        private readonly IConfigService configService;
        private readonly IBackupService backupService;

        public Backup() : this(
            new ConfigService(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backupconfig.json")),
            new BackupService())
        {
        }

        public Backup(IConfigService configService, IBackupService backupService)
        {
            InitializeComponent();
            this.configService = configService;
            this.backupService = backupService;
            // Add NotifyIcon for system tray
            trayIcon = new NotifyIcon();
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.Text = "»—‰«„Ã «·‰”Œ «·«Õ Ì«ÿÌ";
            trayIcon.Visible = false;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.Icon = new Icon("DbBackup.ico");
            // Start minimized
            WindowState = FormWindowState.Minimized;
            // Load config
            currentConfig = configService.LoadConfig();
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
            var settingsMenuItem = new ToolStripMenuItem("«·≈⁄œ«œ« ");
            settingsMenuItem.Click += (s, e) => OpenEditorButton_Click(this, EventArgs.Empty);
            var exitMenuItem = new ToolStripMenuItem("≈€·«ﬁ «·»—‰«„Ã");
            exitMenuItem.Click += (s, e) => ExitApp();
            removableStatusMenuItem = new ToolStripMenuItem("«·‰”Œ ≈·Ï ÊÕœ… Œ«—ÃÌ…") { Enabled = false };
            scheduleStatusMenuItem = new ToolStripMenuItem("«·ÃœÊ·… «· ·ﬁ«∆Ì…") { Enabled = false };
            trayMenu.Items.Add(backupMenuItem);
            trayMenu.Items.Add(settingsMenuItem);
            trayMenu.Items.Add(exitMenuItem);
            trayMenu.Items.Add(new ToolStripSeparator());
            trayMenu.Items.Add(removableStatusMenuItem);
            trayMenu.Items.Add(scheduleStatusMenuItem);
            trayIcon.ContextMenuStrip = trayMenu;
            trayMenu.Opening += TrayMenu_Opening;
        }

        private void ScheduleTimer_Tick(object sender, EventArgs e)
        {
            currentConfig = configService.LoadConfig(); // Reload config in case it changed
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

        private void BackpButton_Click(object sender, EventArgs e)
        {
            RunBackup(scheduled: false);
        }

        private void UpdateProgress(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = value));
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        private void UpdateProgressLabel(string text)
        {
            if (ProgressLabel.InvokeRequired)
            {
                ProgressLabel.Invoke(new Action(() => ProgressLabel.Text = text));
            }
            else
            {
                ProgressLabel.Text = text;
            }
        }

        private void RunBackup(bool scheduled)
        {
            try
            {
                var config = configService.LoadConfig();
                if (config.Destinations == null || config.Destinations.Count == 0)
                {
                    MessageBox.Show("ÌÃ»  ÕœÌœ „Ã·œ«  ··‰”Œ «·«Õ Ì«ÿÌ.");
                    return;
                }
                int steps = 5 + (config.Destinations.Count - 1) + (config.SaveToRemovable ? 1 : 0); // shrink, backup, zip, copy, removable, finish
                int progress = 0;
                progressBar1.Maximum = steps;
                UpdateProgress(progress++); // Start
                UpdateProgressLabel("»œ¡ «·‰”Œ «·«Õ Ì«ÿÌ...");

                string firstDest = config.Destinations[0];
                System.IO.Directory.CreateDirectory(firstDest); // Ensure folder exists
                string backupFile = $"{config.Database}_{DateTime.Now:yyyyMMddHHmmss}.bak";
                string backupPath = System.IO.Path.Combine(firstDest, backupFile); // Use first destination for .bak

                UpdateProgressLabel("Ã«—Ì  ﬁ·Ì’ ﬁ«⁄œ… «·»Ì«‰« ...");
                // Shrink and backup
                backupService.BackupDatabase(config.Server, config.Database, backupPath);
                UpdateProgress(progress++); // After shrink+backup
                UpdateProgressLabel("Ã«—Ì «·‰”Œ «·«Õ Ì«ÿÌ...");

                UpdateProgressLabel("Ã«—Ì «·÷€ÿ...");
                string zipPath = backupService.CreateZip(backupPath);
                UpdateProgress(progress++); // After zip

                // Copy zip to all destinations except the first
                backupService.CopyToDestinations(zipPath, config.Destinations);
                for (int i = 1; i < config.Destinations.Count; i++)
                {
                    UpdateProgressLabel($"Ã«—Ì «·‰”Œ ≈·Ï {config.Destinations[i]}...");
                    UpdateProgress(progress++); // After each copy
                }

                // Removable drive logic
                if (config.SaveToRemovable)
                {
                    UpdateProgressLabel("Ã«—Ì «·‰”Œ ≈·Ï ÊÕœ… Œ«—ÃÌ…...");
                    backupService.CopyToRemovable(zipPath);
                    UpdateProgress(progress++); // After removable
                }

                UpdateProgress(steps); // Finish
                UpdateProgressLabel("«ﬂ „· «·‰”Œ «·«Õ Ì«ÿÌ.");
                // Do NOT delete the zip file in the first destination
                if (!scheduled)
                    MessageBox.Show("«ﬂ „· «·‰”Œ «·«Õ Ì«ÿÌ Ê«·÷€ÿ Ê«·‰”Œ.");
                System.IO.File.Delete(zipPath); // Clean up zip file after copying
            }
            catch (Exception ex)
            {
                UpdateProgressLabel("ÕœÀ Œÿ√ √À‰«¡ «·‰”Œ «·«Õ Ì«ÿÌ.");
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
            var config = configService.LoadConfig();
            removableStatusMenuItem.Checked = config.SaveToRemovable;
            scheduleStatusMenuItem.Checked = config.UseSchedule;
        }
    }
}
