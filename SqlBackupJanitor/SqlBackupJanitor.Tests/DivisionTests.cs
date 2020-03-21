using System;
using Xunit;
using SqlBackupJanitorCore.Math;

namespace SqlBackupJanitor.UnitTests
{
  public class DivisionTests
  {
    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(10, 2, 5)]
    public void Divide_Divides_Numbers_Normally(int upper, int lower, int expected)
    {
      Division division = new Division();
      var actual = division.Divide(upper, lower);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_By_Zero_Throws_Exception()
    {
      Division division = new Division();
      Assert.Throws<Exception>(() => division.Divide(1, 0));
    }
  }
}