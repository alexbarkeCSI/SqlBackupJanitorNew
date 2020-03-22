using System;
using System.Threading.Tasks;
using SlackAPI;

namespace SqlBackupJanitorCore.SlackAPI
{
  public class MySlackClient
  {
    private readonly ISlackConfigProvider _provider;
    public MySlackClient(ISlackConfigProvider provider)
    {
      _provider = provider;
    }
    public async Task Send(string message)
    {
      SlackTaskClient slackClient = new SlackTaskClient(_provider.AccessCode);
      PostMessageResponse response = await slackClient.PostMessageAsync(_provider.ChannelName, message);
      Console.WriteLine(response.error);
    }
  }
}