using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace SM.SqlBackup.Core
{
    public interface IBackupService
    {
        void ShrinkDatabase(string server, string database);
        void ShrinkDatabaseLog(string server, string database);
        void BackupDatabase(string server, string database, string backupPath);
        string CreateZip(string backupPath);
        void CopyToDestinations(string zipPath, List<string> destinations, int maxCopies = 7);
        void CopyToRemovable(string zipPath, int maxCopies = 7);
    }

    public class BackupService : IBackupService
    {
        private readonly ILogger<BackupService> _logger;

        public BackupService(ILogger<BackupService> logger)
        {
            _logger = logger;
        }

        public void ShrinkDatabase(string server, string database)
        {
            _logger.LogInformation("Calling ShrinkDatabase for server: {Server}, database: {Database}", server, database);
            try
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
                _logger.LogInformation("ShrinkDatabase completed for server: {Server}, database: {Database}", server, database);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "in ShrinkDatabase for server: {Server}, database: {Database}", server, database);
                throw;
            }
        }

        public void BackupDatabase(string server, string database, string backupPath)
        {
            _logger.LogInformation("Calling BackupDatabase for server: {Server}, database: {Database}, backupPath: {BackupPath}", server, database, backupPath);
            try
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
                _logger.LogInformation("BackupDatabase completed for server: {Server}, database: {Database}, backupPath: {BackupPath}", server, database, backupPath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "in BackupDatabase for server: {Server}, database: {Database}, backupPath: {BackupPath}", server, database, backupPath);
                throw;
            }
        }
        public void ShrinkDatabaseLog(string server, string database)
        {
            try
            {

                _logger.LogInformation("Calling Shrink Database Log for server: {Server}, database: {Database}", server, database);
                // Connect directly to the target database
                string connectionString = $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                // Get the logical log file name for the current database
                string getLogFileNameSql = @"
                                        SELECT name 
                                        FROM sys.database_files 
                                        WHERE type_desc = 'LOG'";

                string logFileName;
                using (var cmd = new SqlCommand(getLogFileNameSql, connection))
                {
                    logFileName = (string)cmd.ExecuteScalar();
                }

                // Shrink the log file (no need for USE statement)
                string shrinkLogSql = $"DBCC SHRINKFILE([{logFileName}], 1);";
                using (var cmd = new SqlCommand(shrinkLogSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "in ShrinkDatabaseLog for Server: {server}, Database: {database}",server, database);
                throw;
            }
        }
        public string CreateZip(string backupPath)
        {
            _logger.LogInformation("Calling CreateZip for backupPath: {BackupPath}", backupPath);
            try
            {
                string zipPath = backupPath + ".zip";
                using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(backupPath, Path.GetFileName(backupPath));
                }
                File.Delete(backupPath);
                _logger.LogInformation("CreateZip completed for backupPath: {BackupPath}", backupPath);
                return zipPath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateZip for backupPath: {BackupPath}", backupPath);
                throw;
            }
        }

        public void CopyToDestinations(string zipPath, List<string> destinations, int maxCopies = 7)
        {
            _logger.LogInformation("Calling CopyToDestinations for zipPath: {ZipPath}, destinations: {Destinations}, maxCopies: {MaxCopies}", zipPath, destinations, maxCopies);
            if (destinations.Count == 1)
            {
                var dest = destinations[0];
                _logger.LogInformation("Only one destination specified. Skipping copy for {Dest}", dest);
                CleanupOldBackups(dest, Path.GetFileNameWithoutExtension(zipPath), maxCopies);
                return;
            }
            foreach (var dest in destinations)
            {
                try
                {
                    Directory.CreateDirectory(dest);
                    var destFile = Path.Combine(dest, Path.GetFileName(zipPath));
                    File.Copy(zipPath, destFile, true);
                    _logger.LogInformation("Copied zip to destination: {Dest}", dest);
                    // Cleanup old files
                    CleanupOldBackups(dest, Path.GetFileNameWithoutExtension(zipPath), maxCopies);
                }
                catch (DirectoryNotFoundException ex)
                {
                    _logger.LogError(ex, "Destination not found: {Dest}", dest);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, "IO error copying to {Dest}", dest);
                }
                catch (UnauthorizedAccessException ex)
                {
                    _logger.LogError(ex, "Access denied to {Dest}", dest);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected exception copying to {Dest}", dest);
                }
            }
        }

        public void CopyToRemovable(string zipPath, int maxCopies = 7)
        {
            _logger.LogInformation("Calling CopyToRemovable for zipPath: {ZipPath}, maxCopies: {MaxCopies}", zipPath, maxCopies);
            var removables = DriveInfo.GetDrives()
                .Where(d => d.DriveType == DriveType.Removable && d.IsReady)
                .ToList();
            if (removables.Count == 0)
            {
                _logger.LogWarning("No removable drives found for backup.");
                return;
            }
            foreach (var removable in removables)
            {
                string removableDest = Path.Combine(removable.RootDirectory.FullName, Path.GetFileName(zipPath));
                try
                {
                    File.Copy(zipPath, removableDest, true);
                    _logger.LogInformation("Copied zip to removable: {RemovableDest}", removableDest);
                    // Cleanup old files
                    CleanupOldBackups(removable.RootDirectory.FullName, Path.GetFileNameWithoutExtension(zipPath), maxCopies);
                }
                catch (DirectoryNotFoundException ex)
                {
                    _logger.LogError(ex, "Removable destination not found: {RemovableDest}", removableDest);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, "IO error copying to removable: {RemovableDest}", removableDest);
                }
                catch (UnauthorizedAccessException ex)
                {
                    _logger.LogError(ex, "Access denied to removable: {RemovableDest}", removableDest);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected exception copying to removable: {RemovableDest}", removableDest);
                }
            }
        }

        private void CleanupOldBackups(string directory, string baseName, int maxCopies)
        {
            _logger.LogInformation("Calling CleanupOldBackups for directory: {Directory}, baseName: {BaseName}, maxCopies: {MaxCopies}", directory, baseName, maxCopies);
            try
            {
                var files = Directory.GetFiles(directory, baseName.Split('_')[0] + "_*.zip")
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.CreationTimeUtc)
                    .ToList();
                if (files.Count > maxCopies)
                {
                    foreach (var file in files.Skip(maxCopies))
                    {
                        _logger.LogInformation("Deleting old backup: {File}", file.FullName);
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to cleanup old backups in {Directory}", directory);
            }
        }


    }
}
