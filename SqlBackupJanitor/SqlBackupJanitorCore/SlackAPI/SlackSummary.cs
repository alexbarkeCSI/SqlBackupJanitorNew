using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBackupJanitorCore.SlackAPI
{
  public interface ISlackSummary
  {
    string CreateSummaryForSafeMode(string environment, DateTime startedAt, List<string> backupsFound);
    string CreateSummaryForUnsafeMode(string environment, DateTime startedAt, List<string> backupsDeleted);
    string CreateFailureSummary(string environment, DateTime startedAt, string message, string stackTrace);
  }

  public class SlackSummary : ISlackSummary
  {
    public string CreateFailureSummary(string environment, DateTime startedAt, string message, string stackTrace)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"ENV: [{environment}]");
      sb.AppendLine("SafeMode: [TRUE]");
      sb.AppendLine($"Started On: {startedAt.ToString("dddd MMMM dd, yyyy hh:mm:ss")} UTC");
      sb.AppendLine($"FAILURE");
      sb.AppendLine($"[Message]: {message}");
      sb.AppendLine($"[Stacktrace]: {stackTrace}");
      return sb.ToString();
    }

    public string CreateSummaryForSafeMode(string environment, DateTime startedAt, List<string> backupsFound)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"ENV: [{environment}]");
      sb.AppendLine("SafeMode: [TRUE]");
      sb.AppendLine($"Started On: {startedAt.ToString("dddd MMMM dd, yyyy hh:mm:ss")} UTC");
      foreach (string backup in backupsFound)
      {
        sb.AppendLine($"File {backup} would have been deleted.");
      }
      return sb.ToString();
    }

    public string CreateSummaryForUnsafeMode(string environment, DateTime startedAt, List<string> backupsDeleted)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"ENV: [{environment}]");
      sb.AppendLine("SafeMode: FALSE");
      sb.AppendLine($"Started On: {startedAt.ToString("dddd MMMM dd, yyyy hh:mm:ss")}");
      foreach (string backup in backupsDeleted)
      {
        sb.AppendLine($"File {backup} was deleted.");
      }
      return sb.ToString();
    }
  }
}