namespace SqlBackupJanitorCore.Configuration
{
  public class AppConfig
  {
    public uint MaxDaysAgo { get; set; }
    public bool SafeMode { get; set; }
    public string BackupDirectory { get; set; }
    public string AccessCode { get; set; }
    public string SlackChannel { get; set; }

    public AppConfig(uint maxDaysAgo, bool safeMode, string backupDirectory, string accessCode, string slackChannel)
    {
      MaxDaysAgo = maxDaysAgo;
      SafeMode = safeMode;
      BackupDirectory = backupDirectory;
      AccessCode = accessCode;
      SlackChannel = slackChannel;
    }

    public AppConfig()
    {

    }
  }
}