using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;

namespace Nous.Management.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetricsController : ControllerBase
{
    private static readonly Meter Meter = new("NOUS.Management.Api", "1.0.0");
    private static readonly Counter<long> MetricsRequestsCounter = Meter.CreateCounter<long>("nous_metrics_requests_total");

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetMetricsSnapshot()
    {
        MetricsRequestsCounter.Add(1);

        return Ok(new
        {
            service = "NOUS.Management.Api",
            timestamp = DateTime.UtcNow,
            metrics = new
            {
                responseTime = "Coletado pelo OpenTelemetry AspNetCoreInstrumentation",
                errorRate = "Coletado pelo OpenTelemetry AspNetCoreInstrumentation",
                runtime = "Coletado pelo OpenTelemetry RuntimeInstrumentation"
            }
        });
    }
}
