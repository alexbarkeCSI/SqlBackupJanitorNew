using System;

namespace SqlBackupJanitorCore.LogToFile
{
  public class FileSystemLogger
  {
    private readonly IFileSystemConfigProvider _provider;
    public FileSystemLogger(IFileSystemConfigProvider provider)
    {
      _provider = provider;
    }
    public (bool, string) WriteSummaryToFileSystem(string message)
    {
      if (_provider.DirectoryExists() == false)
      {
        Console.WriteLine($"Directory {_provider.GetDirectory()} does not exist.");
        return (false, message);
      }

      return (_provider.Write(message), message);
    }
  }
}