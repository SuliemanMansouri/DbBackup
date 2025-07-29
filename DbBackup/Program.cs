using BbBackup;
using DbBackup;
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