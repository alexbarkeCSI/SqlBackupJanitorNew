using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;
using SqlBackupJanitorCore.Configuration;

namespace SqlBackupJanitorCore.SlackAPI
{
  public sealed class MySlackWebClient : IMySlackClient
  {
    private readonly IGetAppConfig _appConfig;
    public MySlackWebClient(IGetAppConfig appConfig)
    {
      _appConfig = appConfig;
    }
    public async Task Send(string message)
    {
      string webhookCode = _appConfig.FindAppConfig().WebhookCode;

      RestClient client = new RestClient("https://hooks.slack.com/");

      RestRequest request = new RestRequest($"services/{webhookCode}", Method.POST) { RequestFormat = DataFormat.Json };

      string value = JsonSerializer.Serialize(new { text = message });

      request.AddParameter("application/json", value, ParameterType.RequestBody);

      IRestResponse restResponse = await client.ExecuteAsync(request, Method.POST);
    }
  }
}