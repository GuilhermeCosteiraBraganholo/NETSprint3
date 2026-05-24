using Nous.Management.Api.Services;
using Xunit;

namespace Nous.Management.Tests;

public class DashboardServiceTests
{
    [Fact]
    public void CalculateRiskLevelScore_LowMood_ShouldReturnRiskFlag()
    {
        // Arrange
        var service = new DashboardService();
        var lowMoodScore = 2;

        // Act
        var result = service.CalculateRiskLevelScore(lowMoodScore);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateRiskLevelScore_HighMood_ShouldReturnNoRiskFlag()
    {
        // Arrange
        var service = new DashboardService();
        var highMoodScore = 8;

        // Act
        var result = service.CalculateRiskLevelScore(highMoodScore);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetRiskStudents_WhenCalled_ShouldReturnThreeStudents()
    {
        // Arrange
        var service = new DashboardService();

        // Act
        var result = service.GetRiskStudents();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
    }
}
