using System;
using System.Text.Json;

namespace SqlBackupJanitorCore.Configuration
{
  public class GetAppConfig : IGetAppConfig
  {
    public AppConfig FindAppConfig()
    {
      if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.json"))
      {
        string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.json");
        AppConfig appConfig = JsonSerializer.Deserialize<AppConfig>(text);
        return appConfig;
      }
      else
      {
        throw new Exception($"Missing file config.json in {AppDomain.CurrentDomain.BaseDirectory}");
      }
    }
  }
}