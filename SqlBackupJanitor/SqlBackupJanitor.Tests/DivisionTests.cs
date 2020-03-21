using Xunit;
using SqlBackupJanitorCore.Math;

namespace SqlBackupJanitor.UnitTests
{
  public class DivisionTests
  {
    [Fact]
    public void Divide_Divides_Numbers_Normally()
    {
      Division division = new Division();
      var actual = division.Divide(6, 3);
      Assert.Equal(2, actual);
    }
  }
}