using FiapCloud.Games.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Api.Config;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
