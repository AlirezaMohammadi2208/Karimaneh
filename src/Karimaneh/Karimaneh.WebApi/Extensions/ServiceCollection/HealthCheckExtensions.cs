using Karimaneh.WebApi.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Karimaneh.WebApi.Extensions.ServiceCollection
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var conStr = configuration.GetConnectionString("KarimanehContext")
                ?? throw new InvalidOperationException("Connection string 'KarimanehContext' not found.");

            services.AddHealthChecks()
            .AddSqlServer(conStr, tags: new[] { "ready" });

            services.Configure<HealthCheckPublisherOptions>(options =>
            {
                options.Delay = TimeSpan.FromSeconds(300);
            });

            services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();

            return services;
        }
    }
}
