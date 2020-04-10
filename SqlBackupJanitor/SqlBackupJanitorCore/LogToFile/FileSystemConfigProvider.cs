using System.IO;
using SqlBackupJanitorCore.Configuration;
using System;
using System.Text;

namespace SqlBackupJanitorCore.LogToFile
{
  public class FileSystemConfigProvider : IFileSystemConfigProvider
  {
    private readonly IGetAppConfig _appConfigProvider;
    public FileSystemConfigProvider(IGetAppConfig appConfigProvider)
    {
      _appConfigProvider = appConfigProvider;
    }
    public bool DirectoryExists()
    {
      string dir = GetDirectory();
      if (string.IsNullOrEmpty(dir)) return false;
      return System.IO.Directory.Exists(dir);
    }

    public string GetDirectory()
    {
      //GetAppConfig appConfig = new GetAppConfig();
      return _appConfigProvider.FindAppConfig().FileSystemLoggingDirectory;
    }

    public string GetPathToFile()
    {
      string filePath = Path.Combine(GetDirectory(), DateTime.Now.ToString("yyyy_MMM_dddd_hh_mm_ss_tt") + ".txt");
      return filePath;
    }

    public bool Write(string message)
    {
      try
      {
        using (StreamWriter writer = new StreamWriter(GetPathToFile(), true, Encoding.UTF8))
        {
          writer.Write(message);
          writer.Close();
          return true;
        }
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        return false;
      }
    }
  }
}