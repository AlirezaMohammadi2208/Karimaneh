using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Karimaneh.WebApi.HealthChecks
{
    public class HealthCheckPublisher : IHealthCheckPublisher
    {
        private readonly ILogger<HealthCheckPublisher> _logger;

        public HealthCheckPublisher(ILogger<HealthCheckPublisher> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {

            if (report.Status == HealthStatus.Healthy)
            {
                _logger.LogInformation("Liveness And Readiness Health Checks: Healthy");
            }
            else
            {
                _logger.LogWarning("Liveness And Readiness Health Checks: UnHealthy");
            }

            return Task.CompletedTask;
        }
    }
}
