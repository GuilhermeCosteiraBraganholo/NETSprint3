using Nous.Management.Api.Models;

namespace Nous.Management.Api.Services;

public interface IDashboardService
{
    DashboardOverviewResponse GetOverview();
    List<RiskStudentResponse> GetRiskStudents();
    int CalculateRiskLevelScore(int moodScore);
}
