using System;
using SqlBackupJanitorCore.FindBackups;
using SqlBackupJanitorCore.Configuration;
using SqlBackupJanitorCore.SlackAPI;
using System.Threading.Tasks;

namespace ConsoleApp
{
  class Program
  {
    static async Task TestSlack()
    {
      MySlackClient sendMessage = new MySlackClient(new SlackConfigProvider());
      await sendMessage.Send("hello world");
    }
    static async Task<int> Main(string[] args)
    {
      ValidateAppConfig validateAppConfig = new ValidateAppConfig(new GetAppConfig());
      bool isValid = validateAppConfig.Validate();
      if (!isValid)
      {
        return 1;
      }

      AppConfig appConfig = new GetAppConfig().FindAppConfig();

      try
      {
        FindBackups findBackups = new FindBackups();
        await findBackups.DeleteFiles(appConfig.BackupDirectory, daysAgoMax: appConfig.MaxDaysAgo, safeMode: appConfig.SafeMode, appConfig.Environment);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        // failed to run
        return 1;
      }

      // ran correctly
      return 0;
    }
  }
}
