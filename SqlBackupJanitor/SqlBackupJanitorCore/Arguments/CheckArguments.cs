using System;
namespace SqlBackupJanitorCore.Arguments
{
  public class CheckArguments
  {
    private const string ArgumentsErrorMessage = "Wrong number of arguments.  Please specify arguments: 1) Integer DaysAgoMax, Description: How many days ago do you want to delete SQL Backups., 2) String SafeMode, Description: True skips deletion and describes what would be deleted.  False is the default value and deletes SQL Backups found before the DaysAgoMax value";
    public bool ArgumentsAreCorrect(string[] args)
    {
      if (args.Length < 2 || args.Length > 2)
      {
        Console.WriteLine(ArgumentsErrorMessage);
        return false;
      }
      //parse first argument
      uint istArg = Convert.ToUInt32(args[0]);

      // parse 2nd arg
      if (args[1] == "True" || args[1] == "False") return true;
      Console.WriteLine(ArgumentsErrorMessage);
      return false;
    }
  }
}