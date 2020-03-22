using System;
using System.IO;
using System.Collections.Generic;
using SqlBackupJanitorCore.SlackAPI;
using System.Threading.Tasks;

namespace SqlBackupJanitorCore.FindBackups
{
  public class FindBackups
  {

    public static bool CheckIfCanDelete(DateTime lastWriteTime, uint daysAgoMax)
    {
      // input tests
      if (daysAgoMax == 0) throw new Exception("DaysAgoMax cannot be zero.");
      if (lastWriteTime >= DateTime.Now) throw new Exception("Created At may not be in the future.");

      // if lastWriteTime is before Now minus daysAgoMax, then delete the file
      if (lastWriteTime < DateTime.Now.AddDays(-1 * daysAgoMax)) return true;
      return false;
    }

    public async Task DeleteFiles(string path, uint daysAgoMax, bool safeMode = false)
    {
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      List<string> backups = new List<string>();
      try
      {
        Console.WriteLine($"Checking for SQL Backups in {path}\n");
        IEnumerable<FileInfo> files = dirInfo.EnumerateFiles();
        foreach (var fi in files)
        {
          bool canDelete = CheckIfCanDelete(fi.LastWriteTime, daysAgoMax);
          if (canDelete)
          {
            backups.Add(fi.Name);
            if (safeMode)
            {
              Console.WriteLine($"Safe mode!  File {fi.Name} would have been deleted.");
            }
            else
            {
              // delete the file from file system
              fi.Delete();
              Console.WriteLine($"Deleted file.");
            }
          }
        }
        await SendSummary(safeMode, backups);
        return;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Stacktrace: {ex.StackTrace}");
        return;
      }
    }

    private async Task SendSummary(bool safeMode, List<string> backups)
    {
      SlackSummary slackSummary = new SlackSummary();
      string summary;
      if (safeMode)
      {
        summary = slackSummary.CreateSummaryForSafeMode("DEV", DateTime.UtcNow, backups);
      }
      else
      {
        summary = slackSummary.CreateSummaryForUnsafeMode("DEV", DateTime.UtcNow, backups);
      }
      MySlackClient slackClient = new MySlackClient(new SlackConfigProvider());
      await slackClient.Send(summary);
    }
  }
}