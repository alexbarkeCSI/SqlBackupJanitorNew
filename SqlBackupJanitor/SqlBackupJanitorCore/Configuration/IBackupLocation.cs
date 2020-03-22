namespace SqlBackupJanitorCore.Configuration
{
  public interface IBackupLocation
  {
    string GetBackupDir();
  }
}