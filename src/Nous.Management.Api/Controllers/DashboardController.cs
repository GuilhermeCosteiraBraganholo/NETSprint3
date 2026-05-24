using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nous.Management.Api.Models;
using Nous.Management.Api.Services;

namespace Nous.Management.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("overview")]
    [ProducesResponseType(typeof(DashboardOverviewResponse), StatusCodes.Status200OK)]
    public IActionResult GetOverview()
    {
        return Ok(_dashboardService.GetOverview());
    }

    [HttpGet("risk-students")]
    [ProducesResponseType(typeof(IEnumerable<RiskStudentResponse>), StatusCodes.Status200OK)]
    public IActionResult GetRiskStudents()
    {
        return Ok(_dashboardService.GetRiskStudents());
    }
}
