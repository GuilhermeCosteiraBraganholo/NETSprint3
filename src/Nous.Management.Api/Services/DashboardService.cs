using Nous.Management.Api.Models;

namespace Nous.Management.Api.Services;

public class DashboardService : IDashboardService
{
    public DashboardOverviewResponse GetOverview()
    {
        return new DashboardOverviewResponse
        {
            TotalStudents = 120,
            RiskStudents = 15,
            Alerts = 5,
            LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        };
    }

    public List<RiskStudentResponse> GetRiskStudents()
    {
        return new List<RiskStudentResponse>
        {
            new() { Name = "João Alves", RiskLevel = "Alta", MainFactor = "Baixa frequência de check-ins" },
            new() { Name = "Maria Costa", RiskLevel = "Média", MainFactor = "Oscilação emocional recorrente" },
            new() { Name = "Lucas Lima", RiskLevel = "Alta", MainFactor = "Queda recente no engajamento" }
        };
    }

    public int CalculateRiskLevelScore(int moodScore)
    {
        return moodScore <= 3 ? 1 : 0;
    }
}
