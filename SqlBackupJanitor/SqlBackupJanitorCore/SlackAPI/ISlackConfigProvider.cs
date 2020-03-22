namespace SqlBackupJanitorCore.SlackAPI
{
  public interface ISlackConfigProvider
  {
    string AccessCode { get; set; }
    string ChannelName { get; set; }
  }
}