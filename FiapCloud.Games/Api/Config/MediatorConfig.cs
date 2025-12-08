using System.Reflection;

namespace FiapCloud.Games.Api.Config;

public static class MediatorConfig
{
    public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(currentAssembly));

        return services;
    }
}
