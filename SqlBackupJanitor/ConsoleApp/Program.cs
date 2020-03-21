using System;
using System.IO;
using SqlBackupJanitorCore.FindBackups;
using SqlBackupJanitorCore.Arguments;
namespace ConsoleApp
{
  class Program
  {
    static int Main(string[] args)
    {
      CheckArguments checkArguments = new CheckArguments();
      try
      {
        bool argsAreCorrect = checkArguments.ArgumentsAreCorrect(args);
        if (!argsAreCorrect)
        {
          return 1;
        }
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        // failed to run
        return 1;
      }

      FindBackups findBackups = new FindBackups();
      string path = AppDomain.CurrentDomain.BaseDirectory + "Backups";
      findBackups.DeleteFiles(path, Convert.ToUInt32(args[0]), false);

      // ran correctly
      return 0;
    }
  }
}
