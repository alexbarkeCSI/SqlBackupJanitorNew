namespace SqlBackupJanitorCore.Configuration
{
  public class ValidateAppConfig : IValidateAppConfig
  {
    private readonly IGetAppConfig _provider;
    public ValidateAppConfig(IGetAppConfig provider)
    {
      _provider = provider;
    }
    public bool Validate()
    {
      AppConfig appConfig = _provider.FindAppConfig();
      if (appConfig.MaxDaysAgo <= 0) return false;
      if (appConfig.BackupDirectory == null || appConfig.BackupDirectory == "") return false;
      if (string.IsNullOrEmpty(appConfig.AccessCode)) return false;
      if (string.IsNullOrEmpty(appConfig.SlackChannel)) return false;
      if (string.IsNullOrEmpty(appConfig.Environment)) return false;
      return true;
    }
  }
}