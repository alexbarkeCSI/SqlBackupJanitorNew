using System;
using System.IO;
using System.Collections.Generic;
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

    public void DeleteFiles(string path, uint daysAgoMax, bool safeMode = false)
    {
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      try
      {
        Console.WriteLine($"Checking for SQL Backups in {path}\n");
        IEnumerable<FileInfo> files = dirInfo.EnumerateFiles();
        foreach (var fi in files)
        {
          bool canDelete = CheckIfCanDelete(fi.LastWriteTime, daysAgoMax);
          if (canDelete)
          {
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
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Stacktrace: {ex.StackTrace}");
      }
    }
  }
}