using SqlBackupJanitorCore.Configuration;
namespace SqlBackupJanitorCore.SlackAPI
{
  public class SlackConfigProvider : ISlackConfigProvider
  {
    public string AccessCode { get; set; }
    public string ChannelName { get; set; }
    public SlackConfigProvider()
    {
      ValidateAppConfig validateAppConfig = new ValidateAppConfig(new GetAppConfig());
      bool isValid = validateAppConfig.Validate();
      if (!isValid)
      {
        return;
      }

      AppConfig appConfig = new GetAppConfig().FindAppConfig();
      AccessCode = appConfig.AccessCode;
      ChannelName = appConfig.SlackChannel;
    }
  }
}