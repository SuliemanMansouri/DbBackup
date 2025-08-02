using BbBackup;
using DbBackup;
using Serilog;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SM.SqlBackup.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ensure Serilog is configured before using Log.Error
            var logFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    logFilePath,
                    fileSizeLimitBytes: 1048576, // 1 MB
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 1, // Only keep the latest file
                    rollingInterval: Serilog.RollingInterval.Infinite,
                    shared: true,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                // Log the exception
                Log.Error(e.Exception, "Unhandled UI thread exception");
                MessageBox.Show("An unexpected error occurred: " + e.Exception.Message);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                Log.Error(ex, "Unhandled non-UI thread exception");
                MessageBox.Show("A fatal error occurred: " + ex?.Message);
            };

            bool createdNew;
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            using (var mutex = new Mutex(true, "DbBackup_SingleInstance_Mutex", out createdNew))
            {
                if (!createdNew)
                {
                    // Another instance is already running
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize();
                Application.Run(new Backup());
            }
        }
    }
}