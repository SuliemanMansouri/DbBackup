using Microsoft.Data.SqlClient;
using System.IO.Compression;

namespace SM.SqlBackup.Core
{
    public interface IBackupService
    {
        void ShrinkDatabase(string server, string database);
        void BackupDatabase(string server, string database, string backupPath);
        string CreateZip(string backupPath);
        void CopyToDestinations(string zipPath, List<string> destinations);
        void CopyToRemovable(string zipPath);
    }

    public class BackupService : IBackupService
    {
        public void ShrinkDatabase(string server, string database)
        {
            string connectionString = $"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True;";
            string shrinkSql = $"DBCC SHRINKDATABASE([{database}])";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var shrinkCommand = new SqlCommand(shrinkSql, connection))
                {
                    shrinkCommand.ExecuteNonQuery();
                }
            }
        }

        public void BackupDatabase(string server, string database, string backupPath)
        {
            string connectionString = $"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True;";
            string backupSql = $"BACKUP DATABASE [{database}] TO DISK = N'{backupPath}' WITH INIT, FORMAT";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var backupCommand = new SqlCommand(backupSql, connection))
                {
                    backupCommand.ExecuteNonQuery();
                }
            }
        }

        public string CreateZip(string backupPath)
        {
            string zipPath = backupPath + ".zip";
            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(backupPath, Path.GetFileName(backupPath));
            }
            File.Delete(backupPath);
            return zipPath;
        }

        public void CopyToDestinations(string zipPath, List<string> destinations)
        {
            for (int i = 1; i < destinations.Count; i++)
            {
                var dest = destinations[i];
                Directory.CreateDirectory(dest);
                File.Copy(zipPath, Path.Combine(dest, Path.GetFileName(zipPath)), true);
            }
        }

        public void CopyToRemovable(string zipPath)
        {
            var removable = DriveInfo.GetDrives()
                .FirstOrDefault(d => d.DriveType == DriveType.Removable && d.IsReady);
            if (removable != null)
            {
                string removableDest = Path.Combine(removable.RootDirectory.FullName, Path.GetFileName(zipPath));
                File.Copy(zipPath, removableDest, true);
            }
        }
    }
}
