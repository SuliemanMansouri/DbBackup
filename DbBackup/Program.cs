using System;
using System.Threading;

namespace BbBackup
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
            using (var mutex = new Mutex(true, "DbBackup_SingleInstance_Mutex", out createdNew))
            {
                if (!createdNew)
                {
                    // Another instance is already running
                    return;
                }
                ApplicationConfiguration.Initialize();
                Application.Run(new Backup());
            }
        }
    }
}