using System.IO;

namespace SqlBackupJanitorCore.Configuration
{
  public class BackupLocation : IBackupLocation
  {
    private const string Path = "D:\\MarkedForDeletion\\SqlBackupJanitor\\SqlBackupJanitor\\ConsoleApp\\backupLocation.json";

    public string GetBackupDir()
    {
      string json = System.IO.File.ReadAllText(Path);
      return "";

    }
  }
}