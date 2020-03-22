using Xunit;
using SqlBackupJanitorCore.Configuration;
using Autofac.Extras.Moq;

namespace SqlBackupJanitor.Tests
{
  public class ValidateAppConfigTests
  {
    [Fact]
    public void ValidAppConfig_WithCorrectConfig_ReturnsTrue()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(60, true, "D:\\Backups"));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.True(isValid);
      }
    }

    [Fact]
    public void ValidAppConfig_WithEmptyBackupDir_ReturnsFalse()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(60, true, ""));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }

    [Fact]
    public void ValidAppConfig_WithNullBackupDir_ReturnsFalse()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(60, true, null));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }

    [Fact]
    public void ValidAppConfig_WithZeroMaxDays_ReturnsFalse()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(0, true, "D:\\Backups"));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }
  }
}