using DbBackup;
using SM.SqlBackup.Core;
using SM.SqlBackup.WinForms;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BbBackup
{
    public partial class Backup : Form
    {
        private const string Error = "ERR";
        private const string Warning = "WRN";
        private const string Info = "INF";
        private const string Debug = "DBG";
        private const string Trace = "TRC";
        private const string Critical = "CRT";
        private const string Fatal = "FTL";

        private NotifyIcon trayIcon;
        private bool allowClose = false;
        private BackupConfig currentConfig;
        private System.Windows.Forms.Timer scheduleTimer;
        private HashSet<string> triggeredTimes = new HashSet<string>();
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem removableStatusMenuItem;
        private ToolStripMenuItem scheduleStatusMenuItem;
        private ToolStripMenuItem errorLogMenuItem;
        private ToolStripMenuItem restoreMenuItem;
        private readonly IConfigService configService;
        private readonly IBackupService backupService;

        public Backup() : this(
            new ConfigService(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backupconfig.json")),
            CreateBackupServiceWithLogger())

        {
            progressBar1.Maximum = 7; // Set max steps for progress bar
        }

        private static IBackupService CreateBackupServiceWithLogger()
        {
            // Assumes Serilog is already configured in Program.cs
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddProvider(new Serilog.Extensions.Logging.SerilogLoggerProvider());
            });
            var logger = loggerFactory.CreateLogger<BackupService>();
            return new BackupService(logger);
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
            errorLogMenuItem = new ToolStripMenuItem("”Ã· «·√Œÿ«¡ (0)");
            errorLogMenuItem.Click += ErrorLogMenuItem_Click;
            restoreMenuItem = new ToolStripMenuItem("«” ⁄«œ… ﬁ«⁄œ… «·»Ì«‰« ...");
            restoreMenuItem.Click += RestoreMenuItem_Click;
            trayMenu.Items.Add(backupMenuItem);
            trayMenu.Items.Add(settingsMenuItem);
            trayMenu.Items.Add(restoreMenuItem);
            trayMenu.Items.Add(exitMenuItem);
            trayMenu.Items.Add(new ToolStripSeparator());
            trayMenu.Items.Add(removableStatusMenuItem);
            trayMenu.Items.Add(scheduleStatusMenuItem);
            trayMenu.Items.Add(errorLogMenuItem);
            trayIcon.ContextMenuStrip = trayMenu;
            trayMenu.Opening += TrayMenu_Opening;
        }

        // Change the ScheduleTimer_Tick method signature to allow nullable sender
        private void ScheduleTimer_Tick(object? sender, EventArgs e)
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

        // Update the TrayIcon_DoubleClick method signature to allow nullable sender
        private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !allowClose)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                Hide();
                trayIcon.Visible = true;
                return;
            }
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
            RunBackupAsync(false);
        }

        private void RunBackupAsync(bool scheduled)
        {
            Task.Run(() => RunBackup(scheduled));
        }

        private void RunBackup(bool scheduled)
        {

            UpdateProgressLabelSafe(""); // Clear progress label before starting
            try
            {
                var config = configService.LoadConfig();
                if (config.Destinations == null || config.Destinations.Count == 0)
                {
                    UpdateProgressLabelSafe("ÌÃ»  ÕœÌœ „Ã·œ«  ··‰”Œ «·«Õ Ì«ÿÌ.");
                    return;
                }

                int progress = 0;
                UpdateProgressSafe(progress++); // Start
                UpdateProgressLabelSafe("»œ¡ «·‰”Œ «·«Õ Ì«ÿÌ...");

                string firstDest = config.Destinations[0];
                Directory.CreateDirectory(firstDest); // Ensure folder exists
                string backupFile = $"{config.Database}_{DateTime.Now:yyyyMMddHHmmss}.bak";
                string backupPath = System.IO.Path.Combine(firstDest, backupFile); // Use first destination for .bak

                UpdateProgressLabelSafe("Ã«—Ì  ﬁ·Ì’ „·› «·”Ã·« ...");
                backupService.ShrinkDatabaseLog(config.Server, config.Database);
                UpdateProgressSafe(progress++); // After shrink


                UpdateProgressLabelSafe("Ã«—Ì  ﬁ·Ì’ ﬁ«⁄œ… «·»Ì«‰« ...");
                backupService.ShrinkDatabase(config.Server, config.Database);
                UpdateProgressSafe(progress++); // After shrink

                UpdateProgressLabelSafe("Ã«—Ì «·‰”Œ «·«Õ Ì«ÿÌ...");
                backupService.BackupDatabase(config.Server, config.Database, backupPath);
                UpdateProgressSafe(progress++); // After backup

                UpdateProgressLabelSafe("Ã«—Ì «·÷€ÿ...");
                string zipPath = backupService.CreateZip(backupPath);
                UpdateProgressSafe(progress++); // After zip

                // Copy zip to all destinations except the first
                int maxCopies = config.MaxCopies > 0 ? config.MaxCopies : 7;
                UpdateProgressLabelSafe($"Ã«—Ì «·‰”Œ...");
                backupService.CopyToDestinations(zipPath, config.Destinations, maxCopies);
                UpdateProgressSafe(progress++);

                // Removable drive logic
                if (config.SaveToRemovable)
                {
                    UpdateProgressLabelSafe("Ã«—Ì «·‰”Œ ≈·Ï ÊÕœ… Œ«—ÃÌ…...");
                    backupService.CopyToRemovable(zipPath, maxCopies);
                    UpdateProgressSafe(progress++); // After removable
                }

                UpdateProgressSafe(progress++); // Finish
                UpdateProgressLabelSafe("«ﬂ „· «·‰”Œ «·«Õ Ì«ÿÌ.");

                // Show finish message if enabled
                if (config.ShowConfirmationMessage)
                {
                    MessageBox.Show(" „ «·«‰ Â«¡ „‰ «·‰”Œ «·«Õ Ì«ÿÌ »‰Ã«Õ.", "«ﬂ „«· «·‰”Œ «·«Õ Ì«ÿÌ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                UpdateProgressLabelSafe($"ÕœÀ Œÿ√ √À‰«¡ «·‰”Œ «·«Õ Ì«ÿÌ: {ex.Message}");
            }
        }

        private void UpdateProgressLabelSafe(string text)
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

        private void UpdateProgressSafe(int value)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Already handled in constructor
        }

        private void OpenEditorButton_Click(object sender, EventArgs e)
        {
            var editor = new Editor();
            editor.ShowDialog();
        }

        // Update the TrayMenu_Opening method signature to match the nullability of the CancelEventHandler delegate
        private void TrayMenu_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            var config = configService.LoadConfig();
            removableStatusMenuItem.Checked = config.SaveToRemovable;
            scheduleStatusMenuItem.Checked = config.UseSchedule;
            // Update error and warning log count
            try
            {
                var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
                int errorCount = 0;
                int warnCount = 0;
                if (File.Exists(logFilePath))
                {
                    // Use FileStream with FileShare.ReadWrite to avoid sharing violation
                    using (var fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(fs))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(Error)) errorCount++;
                            if (line.Contains(Warning)) warnCount++;
                        }
                    }
                }
                errorLogMenuItem.Text = $"«·√Œÿ«¡: {errorCount} | «· Õ–Ì—« : {warnCount}";
                errorLogMenuItem.Enabled = (errorCount > 0 || warnCount > 0);
            }
            catch (Exception ex)
            {
                errorLogMenuItem.Text = "”Ã· «·√Œÿ«¡ (Œÿ√)";
                errorLogMenuItem.Enabled = false;
                throw new Exception($" ⁄–—  ﬁ—«¡… ”Ã· «·√Œÿ«¡: {ex.Message}", ex);
            }
        }

        private void ErrorLogMenuItem_Click(object? sender, EventArgs e)
        {
            try
            {
                var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
                if (File.Exists(logFilePath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = logFilePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("·« ÌÊÃœ „·› ”Ã· «·√Œÿ«¡.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" ⁄–— › Õ ”Ã· «·√Œÿ«¡: {ex.Message}");
            }
        }

        private void RestoreMenuItem_Click(object? sender, EventArgs e)
        {
            try
            {
                var config = configService.LoadConfig();
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                    ofd.Title = "«Œ — „·› «·‰”Œ… «·«Õ Ì«ÿÌ… ·«” ⁄«œ Â«";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string backupFile = ofd.FileName;
                        backupService.RestoreDatabase(config.Server, config.Database, backupFile);
                        MessageBox.Show(" „  «” ⁄«œ… ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ.", "«” ⁄«œ… ﬁ«⁄œ… «·»Ì«‰« ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ÕœÀ Œÿ√ √À‰«¡ «·«” ⁄«œ…: {ex.Message}", "Œÿ√ ›Ì «·«” ⁄«œ…", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
