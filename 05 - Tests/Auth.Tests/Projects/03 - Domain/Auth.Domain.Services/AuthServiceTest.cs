//using Auth.App.Dto.Auth;
//using Auth.Domain.Contract.Services;
//using Auth.Domain.Services.Services;
//using Auth.Infrastruture.CrossCutting.Handle;
//using AutoMapper;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Moq;
//using Xunit;

//namespace Auth.Tests.Projects._03___Domain.Auth.Domain.Services;
//public class AuthServiceTest
//{
//    private readonly Mock<IConfiguration> _configurationMock;
//    private readonly Mock<INotificationHandle> _notificationMock;
//    private readonly Mock<IMapper> _mapperMock;
//    private readonly Mock<ITokenGeneratorService> _tokenGeneratorMock;
//    private readonly Mock<ILogger<AuthService>> _loggerMock;

//    private readonly AuthService _service;

//    public AuthServiceTest()
//    {
//        _configurationMock = new Mock<IConfiguration>();
//        _notificationMock = new Mock<INotificationHandle>();
//        _mapperMock = new Mock<IMapper>();
//        _tokenGeneratorMock = new Mock<ITokenGeneratorService>();
//        _loggerMock = new Mock<ILogger<AuthService>>();

//        _service = new AuthService(_configurationMock.Object, _notificationMock.Object, _mapperMock.Object, _tokenGeneratorMock.Object, _loggerMock.Object);
//    }

//    [Fact]
//    public async Task Auth_ValidLogin_ReturnsTokenDto()
//    {
//        // Arrange
//        var login = "testuser";
//        var password = "password";
//        var token = "testtoken";
//        var tokenExpires = DateTime.UtcNow.AddHours(1);

//        _configurationMock.SetupGet(c => c["Jwt:Login"]).Returns(login);
//        _configurationMock.SetupGet(c => c["Jwt:Password"]).Returns(password);
//        _configurationMock.SetupGet(c => c["Jwt:HoursToExpire"]).Returns("1");

//        _tokenGeneratorMock.Setup(t => t.GenerateToken()).Returns(token);

//        var dto = new LoginDto
//        {
//            Login = login,
//            Password = password
//        };

//        // Act
//        var result = await _service.Auth(dto);

//        // Assert
//        Assert.IsType<TokenDto>(result);
//        Assert.Equal(token, result.Token);
//        //Assert.Equal(tokenExpires, result.TokenExpires);
//    }

//    [Fact]
//    public async Task Auth_InvalidLogin_ReturnsNull()
//    {
//        // Arrange
//        var login = "testuser";
//        var password = "password";

//        _configurationMock.SetupGet(c => c["Jwt:Login"]).Returns(login);
//        _configurationMock.SetupGet(c => c["Jwt:Password"]).Returns(password);

//        var dto = new LoginDto
//        {
//            Login = "invalidlogin",
//            Password = password
//        };

//        // Act
//        var result = await _service.Auth(dto);

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public async Task Auth_InvalidPassword_ReturnsNull()
//    {
//        // Arrange
//        var login = "testuser";
//        var password = "password";

//        _configurationMock.SetupGet(c => c["Jwt:Login"]).Returns(login);
//        _configurationMock.SetupGet(c => c["Jwt:Password"]).Returns(password);

//        var dto = new LoginDto
//        {
//            Login = login,
//            Password = "invalidpassword"
//        };

//        // Act
//        var result = await _service.Auth(dto);

//        // Assert
//        Assert.Null(result);
//    }
//}