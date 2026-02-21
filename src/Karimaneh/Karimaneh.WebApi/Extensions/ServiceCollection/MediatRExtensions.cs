using Karimaneh.Application.Behaviors;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Infrastructure.Behaviors;

namespace Karimaneh.WebApi.Extensions.ServiceCollection
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediatR(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateTransactionCommand).Assembly);

                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });
            return services;
        }
    }
}
