using System.Threading.Tasks;

namespace SqlBackupJanitorCore.SlackAPI
{
  public interface IMySlackClient
  {
    Task Send(string message);
  }
}