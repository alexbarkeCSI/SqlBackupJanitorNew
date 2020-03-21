using Xunit;
using SqlBackupJanitorCore.Arguments;
using System;
namespace SqlBackupJanitor.Tests
{
  public class CheckArgumentsTests
  {
    [Fact]
    public void CheckArguments_Sixty_And_True_ReturnsTrue()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60", "True" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.True(actual);
    }

    [Fact]
    public void CheckArguments_Sixty_And_true_ReturnsFalse()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60", "true" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_Sixty_And_False_ReturnsTrue()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60", "False" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.True(actual);
    }

    [Fact]
    public void CheckArguments_Sixty_And_false_ReturnsFalse()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60", "false" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_ReturnsFalse()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "60" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_IsNAN_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "hello" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_IsEmptyString_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_IsIsAlphaNumeric_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "123abc" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }

    [Fact]
    public void CheckArguments_OneArgument_IsIsAlphaNumeric_Backwards_ThrowsException()
    {
      CheckArguments checkArguments = new CheckArguments();
      string[] args = new string[] { "abc123" };
      var actual = checkArguments.ArgumentsAreCorrect(args);
      Assert.False(actual);
    }
  }
}