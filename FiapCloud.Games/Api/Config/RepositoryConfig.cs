using FiapCloud.Games.Infra.Repositories;
using FiapCloud.Games.Infra.Repositories.Interfaces;

namespace FiapCloud.Games.Api.Config;

public static class RepositoryConfig
{
    public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IUserGameLibraryRepository, UserGameLibraryRepository>();
        services.AddScoped<IUserOwnedGameRepository, UserOwnedGameRepository>();

        return services;
    }
}

