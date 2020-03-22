using System;
using SqlBackupJanitorCore.FindBackups;
using SqlBackupJanitorCore.Arguments;
using SqlBackupJanitorCore.Configuration;
namespace ConsoleApp
{
  class Program
  {

    static int ValidateArguments(string[] args)
    {
      CheckArguments checkArguments = new CheckArguments();
      try
      {
        bool argsAreCorrect = checkArguments.ArgumentsAreCorrect(args);
        if (!argsAreCorrect)
        {
          return 1;
        }
        return 0;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        // failed to run
        return 1;
      }
    }

    static int Main(string[] args)
    {
      // BackupLocation backupLocation = new BackupLocation();
      // backupLocation.GetBackupDir();
      // int exitCode = ValidateArguments(args);
      // if (exitCode == 1) return 1;

      // FindBackups findBackups = new FindBackups();
      // string path = "D:\\SqlBackupJanitor\\Backups";
      // try
      // {
      //   findBackups.DeleteFiles(path, daysAgoMax: Convert.ToUInt32(args[0]), safeMode: Convert.ToBoolean(args[1]));
      // }
      // catch (System.Exception ex)
      // {
      //   Console.WriteLine($"Error: {ex.Message}");
      //   Console.WriteLine($"StackTrace: {ex.StackTrace}");
      //   // failed to run
      //   return 1;
      // }

      // ran correctly
      return 0;
    }
  }
}
