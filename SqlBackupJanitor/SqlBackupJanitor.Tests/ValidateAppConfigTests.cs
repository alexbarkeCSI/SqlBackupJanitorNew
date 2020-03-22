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
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(60, true, "D:\\Backups", "123abc", "#general"));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.True(isValid);
      }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ValidAppConfig_WithNullOrEmptyBackupDir_ReturnsFalse(string backupDir)
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(60, true, backupDir, "123abc", "#general"));

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
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(0, true, "D:\\Backups", "123abc", "#general"));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ValidAppConfig_WithNullOrEmptyAccessCode_ReturnsFalse(string accessCode)
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(0, true, "D:\\Backups", accessCode, "#general"));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ValidAppConfig_WithNullOrEmptyChannelName_ReturnsFalse(string channelName)
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IGetAppConfig>().Setup(s => s.FindAppConfig()).Returns(new AppConfig(0, true, "D:\\Backups", "123abc", channelName));

        ValidateAppConfig sut = mock.Create<ValidateAppConfig>();

        bool isValid = sut.Validate();
        Assert.False(isValid);
      }
    }

  }
}