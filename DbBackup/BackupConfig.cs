using System.Collections.Generic;

namespace BbBackup
{
    public class BackupConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public List<string> Destinations { get; set; }
        public bool SaveToRemovable { get; set; } // Added property
        public bool UseSchedule { get; set; } // Added property
        public List<string> ScheduledTimes { get; set; } // Added property
    }
}
