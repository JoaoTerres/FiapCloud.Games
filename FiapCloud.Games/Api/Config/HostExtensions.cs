using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Api.Config
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Iniciando a migração do banco de dados...");

                    if (context != null)
                    {
                        context.Database.Migrate();
                    }

                    logger.LogInformation("✅ Migração do banco de dados concluída com sucesso.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "❌ Ocorreu um erro durante a migração do banco de dados. Mensagem: {Message}", ex.Message);

                    throw;
                }
            }
            return host;
        }
    }
}
