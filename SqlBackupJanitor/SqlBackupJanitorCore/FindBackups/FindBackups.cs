using System;
using System.IO;
using System.Collections.Generic;
namespace SqlBackupJanitorCore.FindBackups
{
  public class FindBackups
  {

    public static bool CheckIfCanDelete(DateTime createdAt, uint daysAgoMax)
    {
      // input tests
      if (daysAgoMax == 0) throw new Exception("DaysAgoMax cannot be zero.");
      if (createdAt >= DateTime.Now) throw new Exception("Created At may not be in the future.");

      // if createdAt is before Now minus daysAgoMax, then delete the file
      if (createdAt < DateTime.Now.AddDays(-1 * daysAgoMax)) return true;
      return false;
    }
    public void GetFiles(string path)
    {
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      try
      {
        IEnumerable<FileInfo> files = dirInfo.EnumerateFiles();
        foreach (var fi in files)
        {
          bool canDelete = CheckIfCanDelete(fi.CreationTime, 60);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Stacktrace: {ex.StackTrace}");
      }
    }
  }
}