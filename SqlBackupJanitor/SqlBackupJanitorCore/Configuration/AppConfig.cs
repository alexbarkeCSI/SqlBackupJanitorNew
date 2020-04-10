namespace SqlBackupJanitorCore.Configuration
{
  public class AppConfig
  {
    public uint MaxDaysAgo { get; set; }
    public bool SafeMode { get; set; }
    public string BackupDirectory { get; set; }
    public string AccessCode { get; set; }
    public string WebhookCode { get; set; }
    public string SlackChannel { get; set; }
    public string Environment { get; set; }
    public bool ShouldLogToSlack { get; set; }
    public string FileSystemLoggingDirectory { get; set; }

    public AppConfig(
      uint maxDaysAgo,
      bool safeMode,
      string backupDirectory,
      string accessCode,
      string webhookCode,
      string slackChannel,
      string environment,
      bool shouldLogToSlack,
      string fileSystemLoggingDirectory)
    {
      MaxDaysAgo = maxDaysAgo;
      SafeMode = safeMode;
      BackupDirectory = backupDirectory;
      AccessCode = accessCode;
      WebhookCode = webhookCode;
      SlackChannel = slackChannel;
      Environment = environment;
      ShouldLogToSlack = shouldLogToSlack;
      FileSystemLoggingDirectory = fileSystemLoggingDirectory;
    }

    public AppConfig()
    {

    }
  }
}