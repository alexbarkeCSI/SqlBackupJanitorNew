using System;
using System.Text.Json;

namespace SqlBackupJanitorCore.Configuration
{
  public class GetAppConfig : IGetAppConfig
  {
    public AppConfig FindAppConfig()
    {
      string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.json");
      AppConfig appConfig = JsonSerializer.Deserialize<AppConfig>(text);
      return appConfig;
    }
  }
}