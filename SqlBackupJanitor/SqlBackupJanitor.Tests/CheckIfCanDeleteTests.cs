using Xunit;
using System;
using SqlBackupJanitorCore.FindBackups;

namespace SqlBackupJanitor.Tests
{
  public class CheckIfCanDeleteTests
  {
    [Fact]
    public void CheckIfCanDelete_CreatedAt_BeforeThreshold_Returns_True()
    {
      FindBackups findBackups = new FindBackups();
      var actual = FindBackups.CheckIfCanDelete(new System.DateTime(2019, 6, 1), 60);
      Assert.True(actual);
    }

    [Fact]
    public void CheckIfCanDelete_CreatedAt_AfterThreshold_Returns_False()
    {
      FindBackups findBackups = new FindBackups();
      var actual = FindBackups.CheckIfCanDelete(new System.DateTime(2020, 3, 1), 60);
      Assert.False(actual);
    }

    [Fact]
    public void CheckIfCanDelete_CreatedAt_InFuture_Throws_Exception()
    {
      FindBackups findBackups = new FindBackups();
      Assert.Throws<Exception>(() => FindBackups.CheckIfCanDelete(new System.DateTime(2030, 6, 1), 60));
    }

    [Fact]
    public void CheckIfCanDelete_Threshold_Zero_Value_Throws_Exception()
    {
      FindBackups findBackups = new FindBackups();
      Assert.Throws<Exception>(() => FindBackups.CheckIfCanDelete(new System.DateTime(2019, 6, 1), 0));
    }
  }
}