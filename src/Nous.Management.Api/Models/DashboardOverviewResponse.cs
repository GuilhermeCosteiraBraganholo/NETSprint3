namespace Nous.Management.Api.Models;

public class DashboardOverviewResponse
{
    public int TotalStudents { get; set; }
    public int RiskStudents { get; set; }
    public int Alerts { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
