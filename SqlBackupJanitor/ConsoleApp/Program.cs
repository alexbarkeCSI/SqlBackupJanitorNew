using System;
using SqlBackupJanitorCore.FindBackups;
using SqlBackupJanitorCore.Arguments;
using SqlBackupJanitorCore.Configuration;
namespace ConsoleApp
{
  class Program
  {
    static int Main(string[] args)
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
        findBackups.DeleteFiles(appConfig.BackupDirectory, daysAgoMax: appConfig.MaxDaysAgo, safeMode: appConfig.SafeMode);
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
