using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Nous.Management.Api.Models;
using Xunit;

namespace Nous.Management.Tests;

public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthEndpoint_WhenApiIsRunning_ShouldReturnSuccess()
    {
        // Arrange
        const string endpoint = "/health";

        // Act
        var response = await _client.GetAsync(endpoint);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task DashboardOverview_WithoutToken_ShouldReturnUnauthorized()
    {
        // Arrange
        const string endpoint = "/api/Dashboard/overview";

        // Act
        var response = await _client.GetAsync(endpoint);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task DashboardOverview_WithValidToken_ShouldReturnSuccess()
    {
        // Arrange
        var loginRequest = new LoginRequest { UserName = "admin", Password = "Admin@123" };
        var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginRequest);
        var token = await loginResponse.Content.ReadFromJsonAsync<LoginResponse>();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token!.Token);

        // Act
        var response = await _client.GetAsync("/api/Dashboard/overview");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
