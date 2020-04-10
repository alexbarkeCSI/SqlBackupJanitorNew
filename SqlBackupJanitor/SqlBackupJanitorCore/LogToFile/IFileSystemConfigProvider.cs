namespace SqlBackupJanitorCore.LogToFile
{
  public interface IFileSystemConfigProvider
  {
    string GetDirectory();
    bool DirectoryExists();
    bool Write(string message);
    string GetPathToFile();
  }
}