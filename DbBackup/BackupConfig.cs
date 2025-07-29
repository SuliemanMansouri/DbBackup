namespace DbBackup;

public class BackupConfig
{
    public string Server { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public List<string> Destinations { get; set; } = [];
    public bool SaveToRemovable { get; set; } // Added property
    public bool UseSchedule { get; set; } // Added property
    public List<string> ScheduledTimes { get; set; } = []; // Added property
}
