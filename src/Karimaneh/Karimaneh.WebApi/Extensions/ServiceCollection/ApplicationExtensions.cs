using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.WebApi.Extensions.ServiceCollection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<KarimanehDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("KarimanehContext")
             ?? throw new InvalidOperationException("Connection string 'KarimanehContext' not found.")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KarimanehIdentity")
                ?? throw new InvalidOperationException("Connection string 'KarimanehIdentity' not found.")));

            services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                //options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            //TODO: FIx This
            //services.AddScoped<ITransactionRepository, TransactionRepository>();
            //services.AddScoped<IFundRepository, FundRepository>();
            //services.AddScoped<ILoanRepository, LoanRepository>();
            //services.AddScoped<IMemberRepository, MemberRepository>();
            //services.AddScoped<IRequestRepository, RequestRepository>();
            //services.AddScoped<IWalletRepository, WalletRepository>();

            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddScoped<IJwtTokenService, JwtTokenService>();
            //services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            //services.AddScoped<IAuditLogService, AuditLogService>();
            //services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            //services.AddScoped<IRequestManager, RequestManager>();

            //services.AddAutoMapper(cfg =>
            //cfg.AddMaps(typeof(CreateTransactionCommand).Assembly));

            //services.AddValidatorsFromAssemblyContaining<LoginRequestDtoValidator>();

            return services;
        }
    }
}
