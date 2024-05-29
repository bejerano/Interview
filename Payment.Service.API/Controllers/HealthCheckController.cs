using Microsoft.Extensions.Diagnostics.HealthChecks;

[Route("api/[controller]")]
[Controller]

public class HealthCheckController : ControllerBase
{
        private readonly ILogger<HealthCheckController> _logger;
        private readonly HealthCheckService _service;
        public HealthCheckController(ILogger<HealthCheckController> logger, 
        HealthCheckService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("---- Get all healthcheck request");
            var report = await _service.CheckHealthAsync();
            string json = System.Text.Json.JsonSerializer.Serialize(report);
            _logger.LogInformation("---- Get all healthcheck completed");
            if (report.Status == HealthStatus.Healthy) 
                return Ok(json);
            return NotFound("Service unavailable");
        }
}