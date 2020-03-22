namespace SqlBackupJanitorCore.Configuration
{
  public class AppConfig
  {
    public uint MaxDaysAgo { get; set; }
    public bool SafeMode { get; set; }
    public string BackupDirectory { get; set; }

    public AppConfig(uint maxDaysAgo, bool safeMode, string backupDirectory)
    {
      MaxDaysAgo = maxDaysAgo;
      SafeMode = safeMode;
      BackupDirectory = backupDirectory;
    }

    public AppConfig()
    {

    }
  }
}