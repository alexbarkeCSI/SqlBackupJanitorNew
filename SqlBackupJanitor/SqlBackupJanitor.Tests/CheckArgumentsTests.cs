using Xunit;
using SqlBackupJanitorCore.Arguments;
using System;
namespace SqlBackupJanitor.Tests
{
  public class CheckArgumentsTests
  {
    [Fact]
    public void CheckArguments_OneArgument_ReturnsTrue()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.True(actual);
    }

    [Fact]
    public void CheckArguments_TwoArguments_ReturnsFalse()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60", "120" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_IsNAN_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "hello" };
      Assert.Throws<FormatException>(() => checkArguments.ArgumentsAreCorrect(args));
    }

    [Fact]
    public void CheckArguments_OneArgument_IsEmptyString_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "" };
      Assert.Throws<FormatException>(() => checkArguments.ArgumentsAreCorrect(args));
    }

    [Fact]
    public void CheckArguments_OneArgument_IsIsAlphaNumeric_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "123abc" };
      Assert.Throws<FormatException>(() => checkArguments.ArgumentsAreCorrect(args));
    }

    [Fact]
    public void CheckArguments_OneArgument_IsIsAlphaNumeric_Backwards_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "abc123" };
      Assert.Throws<FormatException>(() => checkArguments.ArgumentsAreCorrect(args));
    }
  }
}