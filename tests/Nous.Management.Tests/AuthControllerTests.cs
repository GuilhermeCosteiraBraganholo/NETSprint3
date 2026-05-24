using Microsoft.AspNetCore.Mvc;
using Moq;
using Nous.Management.Api.Controllers;
using Nous.Management.Api.Models;
using Nous.Management.Api.Services;
using Xunit;

namespace Nous.Management.Tests;

public class AuthControllerTests
{
    [Fact]
    public void Login_ValidCredentials_ShouldReturnOkWithToken()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock
            .Setup(service => service.Login(It.IsAny<LoginRequest>()))
            .Returns(new LoginResponse
            {
                Token = "token-valido-para-teste",
                ExpiresAt = DateTime.UtcNow.AddHours(2)
            });

        var controller = new AuthController(authServiceMock.Object);
        var request = new LoginRequest { UserName = "admin", Password = "Admin@123" };

        // Act
        var result = controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<LoginResponse>(okResult.Value);
        Assert.False(string.IsNullOrWhiteSpace(response.Token));
    }

    [Fact]
    public void Login_InvalidCredentials_ShouldReturnUnauthorized()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock
            .Setup(service => service.Login(It.IsAny<LoginRequest>()))
            .Returns((LoginResponse?)null);

        var controller = new AuthController(authServiceMock.Object);
        var request = new LoginRequest { UserName = "erro", Password = "senha-errada" };

        // Act
        var result = controller.Login(request);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}
