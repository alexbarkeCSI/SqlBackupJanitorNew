using Xunit;
using Autofac.Extras.Moq;
using SqlBackupJanitorCore.Configuration;
using SqlBackupJanitorCore.LogToFile;

namespace SqlBackupJanitor.Tests
{
  public class FileSystemConfigTests
  {
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void WriteSummaryToFileSystem_WithEmptyOrNullDirectory_ReturnsFalse(string dir)
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.GetDirectory()).Returns(dir);

        FileSystemLogger sut = mock.Create<FileSystemLogger>();

        (bool success, string message) = sut.WriteSummaryToFileSystem("hello");
        Assert.False(success);
        Assert.Equal("hello", message);
      }
    }

    [Fact]
    public void WriteSummaryToFileSystem_WithDirectoryExistsFalse_ReturnsFalse()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.GetDirectory()).Returns("D:\\Dir");
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.DirectoryExists()).Returns(false);

        FileSystemLogger sut = mock.Create<FileSystemLogger>();

        (bool success, string message) = sut.WriteSummaryToFileSystem("hello");
        Assert.False(success);
        Assert.Equal("hello", message);
      }
    }

    [Fact]
    public void WriteSummaryToFileSystem_WithCorrectConfig_ReturnsTrue()
    {
      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.GetDirectory()).Returns("D:\\dir");
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.DirectoryExists()).Returns(true);
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.GetPathToFile()).Returns("D:\\dir\\2020_Apr_10_04_52_01_PM");
        mock.Mock<IFileSystemConfigProvider>().Setup(s => s.Write("hello")).Returns(true);

        FileSystemLogger sut = mock.Create<FileSystemLogger>();

        (bool success, string message) = sut.WriteSummaryToFileSystem("hello");
        Assert.True(success);
        Assert.Equal("hello", message);
      }
    }
  }
}