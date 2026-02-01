using CQRSpattern.Domain.Abstractions;
using CQRSpattern.Infrastructure.Common.Interface;
using CQRSpattern.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSpattern.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection"))
                )
            );

            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

            return services;
        }
    }
}
