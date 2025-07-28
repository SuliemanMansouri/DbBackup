using System;
using System.IO;
using System.Text.Json;

namespace DbBackup
{
    public interface IConfigService
    {
        BackupConfig LoadConfig();
    }

    public class ConfigService : IConfigService
    {
        private readonly string configPath;
        public ConfigService(string configPath)
        {
            this.configPath = configPath;
        }
        public BackupConfig LoadConfig()
        {
            string json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<BackupConfig>(json);
            if (config == null)
                throw new InvalidOperationException("Failed to deserialize backupconfig.json.");
            return config;
        }
    }
}
