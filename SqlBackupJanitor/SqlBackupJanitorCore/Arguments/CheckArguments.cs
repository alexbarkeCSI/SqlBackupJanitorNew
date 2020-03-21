using System;
namespace SqlBackupJanitorCore.Arguments
{
  public class CheckArguments
  {
    public bool ArgumentsAreCorrect(string[] args)
    {
      if (args.Length > 1)
      {
        Console.WriteLine("Wrong number of arguments.  Please only specify one unsigned integer daysAgoMax for how many days you want to go back to delete.");
        return false;
      }
      else if (args.Length == 1)
      {
        string arg = args[0];
        uint argAsNumber = Convert.ToUInt32(arg);
        return true;
      }
      Console.WriteLine("Wrong number of arguments.  Please only specify one unsigned integer daysAgoMax for how many days you want to go back to delete.");
      return false;
    }
  }
}